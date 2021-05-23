﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text.RegularExpressions;
using System.Linq;
using System.Web;

namespace NW.WIDJobs
{
    /// <inheritdoc cref="IPageItemExtendedScraper"/>
    public class PageItemExtendedScraper : IPageItemExtendedScraper
    {

        #region Fields

        private IXPathManager _xpathManager;

        #endregion

        #region Properties
        #endregion

        #region Constructors

        /// <summary>Initializes a <see cref="PageItemExtendedScraper"/> instance.</summary>
        /// <exception cref="ArgumentNullException"/>
        public PageItemExtendedScraper(IXPathManager xpathManager)
        {

            Validator.ValidateObject(xpathManager, nameof(xpathManager));

            _xpathManager = xpathManager;

        }

        /// <summary>Initializes a <see cref="PageItemExtendedScraper"/> instance using default parameters.</summary>
        public PageItemExtendedScraper()
            : this(new XPathManager()) { }

        #endregion

        #region Methods_public

        public PageItemExtended Do(PageItem pageItem, string content)
        {

            Validator.ValidateObject(pageItem, nameof(pageItem));
            Validator.ValidateStringNullOrWhiteSpace(content, nameof(content));

            string description = ExtractAndCleanDescription(content);
            string seeCompleteTextAt = TryExtractDescriptionSeeCompleteTextAt(content);

            HashSet<string> bulletPoints = TryExtractDescriptionBulletPointsWithXPath(content);
            if (bulletPoints.Count == 0)
                bulletPoints = TryExtractDescriptionBulletPointsWithRegex(description);
            bulletPoints = TryCleanBulletPoints(bulletPoints);

            string employerName = TryExtractEmployerName(content);
            ushort? numberOfOpenings = TryExtractAndParseNumberOfOpenings(content);
            DateTime? advertisementPublishDate = TryExtractAndParseAdvertisementPublishDate(content);
            DateTime? applicationDeadline = TryExtractAndParseApplicationDeadline(content);
            string startDateOfEmployment = TryExtractAndFormatStartDateOfEmployment(content);
            string reference = TryExtractReference(content);
            string position = TryExtractPosition(content);
            string typeOfEmployment = TryExtractTypeOfEmployment(content);
            string contact = TryExtractAndCleanContact(content);
            string employerAddress = TryExtractAndCleanEmployerAddress(content);
            string howToApply = TryExtractAndCleanHowToApply(content);

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

        #endregion

        #region Methods_private

        private string ExtractAndCleanDescription(string content)
        {

            /*
                "     Technology Finance Business PartnerDenmark Copenhagen Local Finance/Accounting...   "
                "     Apply now »\\u00A0\\u00A0Lean Professional\\u00A0DK,...     "
                ...
             */

            string xpath = "//div[@class='row']/div[@class='col-sm-11']/div[@class='JobPresentation job-description' or @class='job-description']";

            string result = _xpathManager.GetInnerText(content, xpath);
            result = ReplaceNonBreakingSpaceCharacters(result);
            result = result.Trim();

            return result;

        }

        private string TryExtractDescriptionSeeCompleteTextAt(string content)
        {

            /*
                https://jobsearch.maersk.com/jobposting/index.html?id=MA-268026
             */

            string xpath = "//div[@class='row']/div[@class='col-sm-11']/a/@href";

            string result = _xpathManager.TryGetFirstAttributeValue(content, xpath);

            return result;

        }
        private HashSet<string> TryExtractDescriptionBulletPointsWithXPath(string content)
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
        private HashSet<string> TryExtractDescriptionBulletPointsWithRegex(string description)
        {

            string pattern = "(?<=-\\t)[\\w ]{1,}(?=-\\t)";

            HashSet<string> bulletPoints = new HashSet<string>();

            MatchCollection matchCollection = Regex.Matches(description, pattern);
            if (matchCollection != null)
                matchCollection.Cast<Match>().ToList().ForEach(match => bulletPoints.Add(match.ToString()));

            return bulletPoints;

        }
        private string TryExtractEmployerName(string content)
        {

            /*
                "	DINEX A/S"
             */

            string xpath = "//div[@id='scphpage_0_scphcontent_1_ctl00_uiEntireJobPostingSpan']/h2";

            string result = _xpathManager.TryGetInnerText(content, xpath);
            result = result?.Trim();

            return result;

        }
        private ushort? TryExtractAndParseNumberOfOpenings(string content)
        {

            /*
                "	 1"
             */

            string xpath = "//div[@class='col-sm-11 ']/dl[@class='dl-justify nomargin']/dt/following-sibling::dd";

            string result = _xpathManager.TryGetInnerText(content, xpath);
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

            string result = _xpathManager.TryGetInnerText(content, xpath);
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

            string result = _xpathManager.TryGetInnerText(content, xpath);
            result = result?.Trim();

            DateTime? applicationDeadline = TryParseDate(result);

            return applicationDeadline;

        }
        private string TryExtractAndFormatStartDateOfEmployment(string content)
        {

            /*
                "	 As soon as possible"
                "09/06/2021"
            */

            string xpath = "//div[@class='col-sm-11 ']/dl[@class='dl-justify nomargin']/dt[contains(.,'Start date of employment')]/following-sibling::dd[1]";

            string result = _xpathManager.TryGetInnerText(content, xpath);
            result = result?.Trim();

            DateTime? date = TryParseDate(result);
            if (date != null)
                return ((DateTime)date).ToString("yyyy-MM-dd");

            return result;

        }
        private string TryExtractReference(string content)
        {

            string xpath = "//div[@class='col-ms-6 col-sm-4']/h3[contains(., 'Reference')]/following-sibling::p[1]";

            string result = _xpathManager.TryGetInnerText(content, xpath);
            result = result?.Trim();

            return result;

        }
        private string TryExtractPosition(string content)
        {

            /*
                "    Academical work / Engineering professionals"
             */

            string xpath = "//div[@class='col-ms-6 col-sm-4']/h3[contains(., 'Position')]/following-sibling::p[1]";

            string result = _xpathManager.TryGetInnerText(content, xpath);
            result = result?.Trim();

            return result;

        }
        private string TryExtractTypeOfEmployment(string content)
        {

            /*
                "    Regular position"
            */

            string xpath = "//div[@class='col-ms-6 col-sm-4']/h3[contains(., 'Type of employment')]/following-sibling::p[1]";

            string result = _xpathManager.TryGetInnerText(content, xpath);
            result = result?.Trim();

            return result;

        }
        private string TryExtractAndCleanContact(string content)
        {
            /*
                "    Global Test Centre Manager Christian Berg Philipp"

                "    Team Manager - Life Science Mette Meincke
                     Phone: +45 26 77 70 83
                     Mobile: +45 26 77 70 83
                "Team Manager - Life Science Mette Meincke\\r\\n                        \\r\\n                            Phone: +45 26 77 70 83\\r\\n                        \\r\\n                            Mobile: +45 26 77 70 83"
             */

            string xpath = "//div[@class='col-ms-6 col-sm-4']/h3[contains(., 'Contact')]/following-sibling::p[1]";

            string result = _xpathManager.TryGetInnerText(content, xpath);
            result = TryRemoveNewLines(result);
            result = TryRemoveExtraWhiteSpaces(result);
            result = result?.Trim();

            return result;

        }
        private string TryExtractAndCleanEmployerAddress(string content)
        {

            /*
                 "    DINEX A/S
                     Fynsvej 39
                     DK 5500 Middelfart
                     Denmark"
                "DINEX A/S                        Fynsvej 39                        DK 5500 Middelfart                        Denmark"

                "PREVAS A/S Lysk&#230;r 3 DK 2730 Herlev Denmark"
            */

            string xpath = "//div[@class='col-ms-6 col-sm-4']/h3[contains(., 'Employer')]/following-sibling::p[1]";

            string result = _xpathManager.TryGetInnerText(content, xpath);
            result = TryRemoveNewLines(result);
            result = TryRemoveExtraWhiteSpaces(result);
            result = TryHtmlDecode(result);
            result = result?.Trim();

            return result;

        }
        private string TryExtractAndCleanHowToApply(string content)
        {

            /*
                "     Online:
                      Application form"
                https://dinex.career.emply.com/ad/nvh-test-engineer/03leyh"

                "   Via e-mail:                             
                    nj@bixter.com                                                                            
                    Written"
                "Via e-mail:                             nj@bixter.com                                                                            Written"
            */

            string xpath = "//div[@class='col-ms-6 col-sm-4']//ul|//a[@id='scphpage_0_scphcontent_1_ctl00_uiLnkHowToApplyOnline']/@href";

            string result = _xpathManager.TryGetInnerText(content, xpath);
            result = TryRemoveNewLines(result);
            result = TryRemoveExtraWhiteSpaces(result);
            result = result?.Trim();

            return result;

        }

        private string ReplaceNonBreakingSpaceCharacters(string str)
            => str.Replace("\u00A0", " ");
        private string RemoveNonBreakingSpaceCharacters(string str)
            => str.Replace("\u00A0", string.Empty);
        private string TryRemoveNewLines(string str)
            => str?.Replace(Environment.NewLine, string.Empty);
        private string TryRemoveExtraWhiteSpaces(string str)
        {

            if (str != null)
                return String.Join(" ", str.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries));

            return str;
        }
        private DateTime? TryParseDate(string str)
        {

            /*
                AdvertisementPublishDate can be:
                    - null
                    - date in "dd/MM/yyyy" format

                ApplicationDeadline can be:
                    - null
                    - date in "dd/MM/yyyy" format
                    - "As soon as possible"
            */

            DateTime? date = null;
            try
            {

                if (str != null)
                    date = DateTime.ParseExact(str, "dd/MM/yyyy", CultureInfo.InvariantCulture);

                return date;

            }
            catch
            {

                return date;

            }

        }
        private string TryHtmlDecode(string str)
        {

            if (str != null)
                return HttpUtility.HtmlDecode(str);

            return str;

        }
        private HashSet<string> TryCleanBulletPoints(HashSet<string> bulletPoints)
        {

            /*
                ...
                "Competitive - as we're driven by performance",
                "A great communicator in English (As English is our Company language)\\u00A0"
                ...
            */

            if (bulletPoints.Count == 0)
                return bulletPoints;

            List<string> results
                = bulletPoints.Select(bulletPoint => RemoveNonBreakingSpaceCharacters(bulletPoint)).ToList();

            return new HashSet<string>(results);

        }

        #endregion

    }
}

/*
    Author: numbworks@gmail.com
    Last Update: 13.05.2021
*/