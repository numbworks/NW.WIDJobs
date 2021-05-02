using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Threading;
using RUBN.Shared;

namespace NW.WebsiteExploration
{
    /// <summary>
    /// It explores a website starting from the first page and going backwards.
    /// </summary>
    public abstract class AWebsiteExplorer : IWebsiteExplorer
    {

        // Fields
        // Properties
        public string WebsiteName { get; private set; }
        public ushort ResultsPerPage { get; private set; }
        public IParametersValidator ParametersValidator { get; set; } = new ParametersValidator();
        public IGetRequestFactory GetRequestFactory { get; set; } = new GetRequestFactory();
        public IAntiFloodingStrategy AntiFloodingStrategy { get; set; } = new AntiFloodingStrategy();

        // Constructors	
        protected AWebsiteExplorer(string strWebsiteName, ushort uintResultsPerPage)
        {

            if (String.IsNullOrEmpty(strWebsiteName))
                throw new Exception("The website name can't be empty or null.");

            if (uintResultsPerPage < 1)
                throw new Exception("The ResultsPerPage can't be less than one.");

            WebsiteName = strWebsiteName;
            ResultsPerPage = uintResultsPerPage;

        }

        // Methods
        public virtual Outcome Explore(string strConnectionString)
        {

            string errFailure = $"It hasn't been possible to complete the exploration of {WebsiteName}.";
            string msgSuccess = $"The exploration of {WebsiteName} has been successfully completed.";

            List<string> listMessages = new List<string>();
            try
            {

                Outcome objReturn = ParametersValidator.IsNullOrEmpty(strConnectionString);
                if (objReturn.IsFailureOrException())
                    return OutcomeBuilder.Clone(objReturn).Append(errFailure).Get();
                listMessages.AddRange(objReturn.Messages);

                objReturn = GetPage(1, strConnectionString);
                if (objReturn.IsFailureOrException())
                    return OutcomeBuilder.Clone(objReturn).Append(errFailure).Get();
                ResultsPageBundle objFirstPageBundle = (ResultsPageBundle)objReturn.Result;
                listMessages.AddRange(objReturn.Messages);

                objReturn = InitializeExploration(objFirstPageBundle.Response);
                if (objReturn.IsFailureOrException())
                    return OutcomeBuilder.Clone(objReturn).Append(errFailure).Get();
                ResultsExploration objExploration = (ResultsExploration)objReturn.Result;
                listMessages.AddRange(objReturn.Messages);

                List<ResultsPage> listPages = new List<ResultsPage>();
                listPages.Add(objFirstPageBundle.Page);
                if (objFirstPageBundle.Page.IsLastForCurrentExploration == false)
                {

                    objReturn = GetPages(2, objExploration.TotalPagesExpected, strConnectionString);
                    if (objReturn.IsFailureOrException())
                        return OutcomeBuilder.Clone(objReturn).Append(errFailure).Get();
                    List<ResultsPage> listMorePages = (List<ResultsPage>)objReturn.Result;

                    listMessages.AddRange(objReturn.Messages);
                    listPages.AddRange(listMorePages);

                }
                objExploration.Pages = listPages;

                return OutcomeBuilder.CreateSuccess(msgSuccess, objExploration).Prepend(listMessages).Get();

            }
            catch (Exception e)
            {

                return OutcomeBuilder.CreateException(e).Prepend(listMessages).Append(errFailure).Get();

            }

        }

        /// <summary>
        /// It generates an initial ResultsExploration object out of the content of the first search results page.
        /// This object will have the TotalResults and TotalPagesExpected properties filled-in.
        /// </summary>
        protected virtual Outcome InitializeExploration(string strResponse)
        {

            string msgSuccess = $"The exploration of {WebsiteName} has been successfully initialized.";

            ResultsExploration objExploration = new ResultsExploration();
            List<string> listMessages = new List<string>();
            Outcome objReturn = GetTotalResults(strResponse);
            if (objReturn.IsFailureOrException())
                return objReturn;
            listMessages.AddRange(objReturn.Messages);

            objExploration.TotalResults = (UInt32)objReturn.Result;
            objExploration.TotalPagesExpected = GetTotalPagesExpected(objExploration.TotalResults);

            return OutcomeBuilder.CreateSuccess(msgSuccess, objExploration).Prepend(listMessages).Get();

        }
        protected virtual UInt16 GetTotalPagesExpected(UInt32 uintTotalResults)
        {

            /*
             *  Since ResultsPerPage is a read-only value, we assume it will always be > 0.
             * 
             *  Example:
             *  
             *  1243 total results / 20 results per page = 62.15.
             *  
             *  In the case above, 63 must be returned, because:
             *     a) 62 pages with 20 results each = 1240;
             *     b) 1 page with the 3 results left.
             *   
             */

            int intReminder = 0;
            int intQuotient = Math.DivRem((int)uintTotalResults, ResultsPerPage, out intReminder);
            if (intReminder > 0) intQuotient++;

            return (UInt16)intQuotient;

        }
        protected abstract Outcome GetTotalResults(string strResponse);


        /// <summary>
        /// It returns a List<ResultsPage> object for each page in a range of page numbers.
        /// It requires a StartPage (usually equals to 2), an EndPage, and a connection string.
        /// </summary>
        protected virtual Outcome GetPages(UInt16 uintStartPage, UInt16 uintEndPage, string strConnectionString)
        {

            string strPageRange = $"StartPage: '{uintStartPage.ToString()}', EndPage: '{uintEndPage.ToString()}'";
            string errFailure = $"It hasn't been possible to retrieve all the pages in the provided range ({strPageRange}).";
            string msgSuccess = $"All the pages in the provided range ({strPageRange}) have been successfully completed.";

            List<ResultsPage> listPages = new List<ResultsPage>();
            List<string> listMessages = new List<string>();
            for (UInt16 i = uintStartPage; i <= uintEndPage; i++)
            {

                Outcome objReturn = GetPage(i, strConnectionString);
                if (objReturn.IsFailureOrException())
                    return OutcomeBuilder.Clone(objReturn).Append(errFailure).Get();
                listMessages.AddRange(objReturn.Messages);

                ResultsPageBundle objPageBundle = (ResultsPageBundle)objReturn.Result;
                ResultsPage objPage = objPageBundle.Page;
                listPages.Add(objPage);

                if (objPage.IsLastForCurrentExploration == true)
                    break;

                // Do a pause of x each y requests
                if (i != 0 && i % AntiFloodingStrategy.DetailsParallelRequests == 0) // i != 0, because 0 % x = 0...
                    Thread.Sleep((int)AntiFloodingStrategy.DetailsPauseMs);

            }

            return OutcomeBuilder.CreateSuccess(msgSuccess, listPages).Prepend(listMessages).Get();

        }

        /// <summary>
        /// It generates an absolute url for the provided page number, and it performs a GET request to retrieve the content of the page.
        /// The *Items that have been already imported in the database will be removed from the *Page.
        /// The method returns a ResultsPageBundle object for (eventual) further processing.
        /// </summary>
        protected virtual Outcome GetPage(UInt16 uintPageNumber, string strConnectionString)
        {

            string errFailure = "It hasn't been possible to retrieve the page with the provided page number ('{0}').";
            string msgSuccess = "The page with the provided page number ('{0}') has been successfully retrieved.";

            List<string> listMessages = new List<string>();
            try
            {

                string strAbsoluteUrl = GetPageAbsoluteUrl(uintPageNumber);
                IGetRequest objGetRequest = GetRequestFactory.Create();
                Outcome objReturn = objGetRequest.SendAndGetHttpWebResponse(strAbsoluteUrl);
                if (objReturn.IsFailureOrException())
                    return OutcomeBuilder.Clone(objReturn).Append(
                        String.Format(errFailure, uintPageNumber.ToString())).Get();
                listMessages.AddRange(objReturn.Messages);

                HttpWebResponse objResponse = objReturn.Result as HttpWebResponse;
                objReturn = objGetRequest.ResponseStreamToString(objResponse, Encoding.UTF8);
                if (objReturn.IsFailureOrException())
                    return OutcomeBuilder.Clone(objReturn).Append(
                        String.Format(errFailure, uintPageNumber.ToString())).Get();
                listMessages.AddRange(objReturn.Messages);

                string strResponse = (string)objReturn.Result;
                objReturn = GetItems(strResponse);
                if (objReturn.IsFailureOrException())
                    return OutcomeBuilder.Clone(objReturn).Append(
                        String.Format(errFailure, uintPageNumber.ToString())).Get();
                listMessages.AddRange(objReturn.Messages);

                List<ResultsPageItem> listItems = (List<ResultsPageItem>)objReturn.Result;
                ResultsPage objPage = new ResultsPage();
                objPage.PageNumber = uintPageNumber;
                objPage.AbsoluteUrl = strAbsoluteUrl;
                objPage.Items = listItems;

                objReturn = RemoveAlreadyImportedItems(objPage, strConnectionString);
                if (objReturn.IsFailureOrException())
                    return OutcomeBuilder.Clone(objReturn).Append(errFailure).Get();
                objPage = (ResultsPage)objReturn.Result;
                listMessages.AddRange(objReturn.Messages);

                ResultsPageBundle objBundle = new ResultsPageBundle();
                objBundle.Response = strResponse;
                objBundle.Page = objPage;

                return OutcomeBuilder.CreateSuccess(msgSuccess, objBundle).Prepend(listMessages).Get();

            }
            catch (Exception e)
            {

                return OutcomeBuilder.CreateException(e).Append(
                    String.Format(errFailure, uintPageNumber.ToString())).Prepend(listMessages).Get();

            }

        }
        protected abstract string GetPageAbsoluteUrl(UInt16 uintPageNumber);
        protected abstract Outcome GetItems(string strResponse);
        protected abstract Outcome RemoveAlreadyImportedItems(ResultsPage objPage, string strConnectionString);

        protected virtual bool CompareIntegers(int[] arr)
        {

            if (arr.Length < 2) return false;

            return Array.TrueForAll<int>(arr, val => (arr[0] == val));

        }

    }
}

/*

    Author: numbworks@gmail.com
    Last Update: 22.09.2018

*/