using System;
using System.Collections.Generic;
using System.Globalization;

namespace NW.WIDJobs
{
    public class PageItemExtendedScraper : IPageItemExtendedScraper
    {

        // Fields
        private IXPathManager _xpathManager;

        // Properties
        // Constructors
        public PageItemExtendedScraper(IXPathManager xpathManager)
        {

            Validator.ValidateObject(xpathManager, nameof(xpathManager));

            _xpathManager = xpathManager;

        }
        public PageItemExtendedScraper()
            : this(new XPathManager()) { }

        // Methods (public)
        public PageItemExtended Do(PageItem pageItem, string content)
        {

            Validator.ValidateObject(pageItem, nameof(pageItem));
            Validator.ValidateStringNullOrWhiteSpace(content, nameof(content));

            string description = ExtractDescription(content);
            string seeCompleteTextAt = TryExtractDescriptionSeeCompleteTextAt(content);
            HashSet<string> bulletPoints = TryExtractDescriptionBulletPoints(content);
            string employerName = TryExtractEmployerName(content);
            ushort? numberOfOpenings = TryExtractAndParseNumberOfOpenings(content);
            DateTime? advertisementPublishDate = TryExtractAndParseAdvertisementPublishDate(content);
            DateTime? applicationDeadline = TryExtractAndParseApplicationDeadline(content);
            string startDateOfEmployment = TryExtractStartDateOfEmployment(content);
            string reference = TryExtractReference(content);
            string position = TryExtractPosition(content);
            string typeOfEmployment = TryExtractTypeOfEmployment(content);
            string contact = TryExtractContact(content);
            string employerAddress = TryExtractEmployerAddress(content);
            string howToApply = TryExtractHowToApply(content);

            PageItemExtended pageItemExtended = new PageItemExtended(

                    pageItem: pageItem,
                    description: description,
                    seeCompleteTextAt: seeCompleteTextAt,
                    bulletPoints: bulletPoints,
                    employerName: employerName,
                    numberOfOpenings: numberOfOpenings,
                    advertisementPublishDate: advertisementPublishDate,
                    applicationDeadline: applicationDeadline,
                    startDateOfEmployment: startDateOfEmployment,
                    reference: reference,
                    position: position,
                    typeOfEmployment: typeOfEmployment,
                    contact: contact,
                    employerAddress: employerAddress,
                    howToApply: howToApply

                );

            return pageItemExtended;

        }

        // Methods (private)
        private string ExtractDescription(string content)
        {

            /*
                "     Technology Finance Business PartnerDenmark Copenhagen Local Finance/Accounting...   "
             */

            string xpath = "//div[@class='row']/div[@class='col-sm-11']/div[@class='JobPresentation job-description']";

            string result = _xpathManager.GetInnerText(content, xpath);
            result = result.Trim();

            return result;

        }

        private string TryExtractDescriptionSeeCompleteTextAt(string content)
        {

            /*
                https://jobsearch.maersk.com/jobposting/index.html?id=MA-268026
             */

            string xpath = "//div[@class='row']/div[@class='col-sm-11']/a/@href";

            string result = _xpathManager.GetFirstAttributeValue(content, xpath);

            return result;

        }
        private HashSet<string> TryExtractDescriptionBulletPoints(string content)
        {

            /*
                Engineering degree within acoustics & vibration
                Detailed knowledge of material testing and dynamic vibration testing
                Detailed knowledge within NVH data acquisition systems and electrodynamic test equipment
            ...
             */

            string xpath = "//div[@class='row']/div[@class='col-sm-11']/div[@class='JobPresentation job-description' or @class='job-description']/ul/li";

            List<string> results = _xpathManager.GetInnerTexts(content, xpath);
            HashSet<string> bulletPoints = new HashSet<string>(results);

            return bulletPoints;

        }
        private string TryExtractEmployerName(string content)
        {

            /*
                "	DINEX A/S"
             */

            string xpath = "//div[@id='scphpage_0_scphcontent_1_ctl00_uiEntireJobPostingSpan']/h2";

            string result = _xpathManager.GetInnerText(content, xpath);
            result = result.Trim();

            return result;

        }
        private ushort? TryExtractAndParseNumberOfOpenings(string content)
        {

            /*
                "	 1"
             */

            string xpath = "//div[@class='col-sm-11 ']/dl[@class='dl-justify nomargin']/dt/following-sibling::dd";

            string result = _xpathManager.GetInnerText(content, xpath);
            result = result?.Trim();

            ushort? numberOfOpenings = null;
            if (result != null)
                numberOfOpenings = ushort.Parse(result);

            return numberOfOpenings;

        }
        private DateTime? TryExtractAndParseAdvertisementPublishDate(string content)
        {

            /*
                "	 07/05/2021"
             */

            string xpath = "//div[@class='col-sm-11 ']/dl[@class='dl-justify nomargin']/dt[contains(.,'Advertisement publish date')]/following-sibling::dd[1]";

            string result = _xpathManager.GetInnerText(content, xpath);
            result = result?.Trim();

            DateTime? advertisementPublishDate = TryParseDate(result);

            return advertisementPublishDate;

        }
        private DateTime? TryExtractAndParseApplicationDeadline(string content)
        {

            /*
                "	 07/05/2021"
             */

            string xpath = "//div[@class='col-sm-11 ']/dl[@class='dl-justify nomargin']/dt[contains(.,'Application deadline')]/following-sibling::dd[1]";

            string result = _xpathManager.GetInnerText(content, xpath);
            result = result?.Trim();

            DateTime? applicationDeadline = TryParseDate(result);

            return applicationDeadline;

        }
        private string TryExtractStartDateOfEmployment(string content)
        {

            /*
                "	 As soon as possible"
            */

            string xpath = "";

            string result = _xpathManager.GetInnerText(content, xpath);
            result = result?.Trim();

            return result;

        }      
        private string TryExtractReference(string content)
        {

            string xpath = "//div[@class='col-ms-6 col-sm-4']/h3[contains(., 'Reference')]/following-sibling::p[1]";

            string result = _xpathManager.GetInnerText(content, xpath);
            result = result?.Trim();

            return result;

        }
        private string TryExtractPosition(string content)
        {

            /*
                "    Academical work / Engineering professionals"
             */

            string xpath = "//div[@class='col-ms-6 col-sm-4']/h3[contains(., 'Position')]/following-sibling::p[1]";

            string result = _xpathManager.GetInnerText(content, xpath);
            result = result?.Trim();

            return result;

        }
        private string TryExtractTypeOfEmployment(string content)
        {

            /*
                "    Regular position"
            */

            string xpath = "//div[@class='col-ms-6 col-sm-4']/h3[contains(., 'Type of employment')]/following-sibling::p[1]";

            string result = _xpathManager.GetInnerText(content, xpath);
            result = result?.Trim();

            return result;

        }
        private string TryExtractContact(string content)
        {
            /*
                "    Global Test Centre Manager Christian Berg Philipp"
             */

            string xpath = "//div[@class='col-ms-6 col-sm-4']/h3[contains(., 'Contact')]/following-sibling::p[1]";

            string result = _xpathManager.GetInnerText(content, xpath);
            result = result?.Trim();

            return result;

        }
        private string TryExtractEmployerAddress(string content)
        {

            /*
                 "    DINEX A/S
                     Fynsvej 39
                     DK 5500 Middelfart
                     Denmark"
            */

            string xpath = "//div[@class='col-ms-6 col-sm-4']/h3[contains(., 'Employer')]/following-sibling::p[1]";

            string result = _xpathManager.GetInnerText(content, xpath);
            result = result?.Trim();

            return result;

        }
        private string TryExtractHowToApply(string content)
        {

            /*
                "     Online:
                      Application form"
                https://dinex.career.emply.com/ad/nvh-test-engineer/03leyh"
            */

            string xpath = "//div[@class='col-ms-6 col-sm-4']//ul|//a[@id='scphpage_0_scphcontent_1_ctl00_uiLnkHowToApplyOnline']/@href";

            string result = _xpathManager.GetInnerText(content, xpath);
            result = result?.Trim();

            return result;

        }

        private DateTime? TryParseDate(string result)
        {

            DateTime? date = null;
            if (result != null)
                date = DateTime.ParseExact(result, "dd/MM/yyyy", CultureInfo.InvariantCulture);

            return date;

        }

    }
}

/*
    Author: numbworks@gmail.com
    Last Update: 11.05.2021
*/