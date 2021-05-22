using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Text.RegularExpressions;
using System.Linq;

namespace NW.WIDJobs
{
    public class PageItemScraper : IPageItemScraper
    {

        // Fields
        private IXPathManager _xpathManager;

        // Properties
        // Constructors
        public PageItemScraper(IXPathManager xpathManager)
        {

            Validator.ValidateObject(xpathManager, nameof(xpathManager));

            _xpathManager = xpathManager;

        }
        public PageItemScraper()
            : this(new XPathManager()) { }

        // Methods (public)
        public List<PageItem> Do(Page page)
        {

            Validator.ValidateObject(page, nameof(page));

            List<string> urls = ExtractAndFixUrls(page.Content);
            List<string> titles = ExtractAndCleanTitles(page.Content);
            List<DateTime> createDates = ExtractAndParseCreateDates(page.Content);
            List<DateTime?> applicationDates = ExtractCleanAndParseApplicationDates(page.Content);
            List<string> workAreas = ExtractAndCleanWorkAreas(page.Content);
            List<string> workAreasWithoutZones = CreateWorkAreasWithoutZones(workAreas);
            List<string> workingHours = ExtractAndCleanWorkingHours(page.Content);
            List<string> jobTypes = ExtractAndCleanJobTypes(page.Content);
            List<ulong> jobIds = ExtractAndParseJobIds(urls);

            Dictionary<string, int> subscrapers = new Dictionary<string, int>()
            {
                { nameof(urls), urls.Count },
                { nameof(titles), titles.Count },
                { nameof(createDates), createDates.Count },
                { nameof(applicationDates), applicationDates.Count },
                { nameof(workAreas), workAreas.Count },
                { nameof(workAreasWithoutZones), workAreasWithoutZones.Count },
                { nameof(workingHours), workingHours.Count },
                { nameof(jobTypes), jobTypes.Count },
                { nameof(jobIds), jobIds.Count }
            };
            Validator.ThrowIfCountsAreNotEqual<Exception>(subscrapers);

            List<PageItem> pageItems 
                = CreatePageItems(
                    page, 
                    urls, 
                    titles, 
                    createDates, 
                    applicationDates, 
                    workAreas,
                    workAreasWithoutZones,
                    workingHours, 
                    jobTypes, 
                    jobIds
                    );

            return pageItems;

        }
        public List<DateTime> ExtractAndParseCreateDates(string content)
        {

            /*
                2021-05-09
                2021-05-09
                ...
            */

            Validator.ValidateStringNullOrEmpty(content, nameof(content));

            string xpath = "//div[@class='col-sm-9 ']/p[contains(.,'Created')]/time/@datetime";
            uint attributeNr = 0;

            List<string> results = _xpathManager.GetAttributeValues(content, xpath, attributeNr);
            List<DateTime> createDates = results.Select(result => ParseCreateDate(result)).ToList();

            return createDates;

        }
        public bool IsThresholdConditionMet(DateTime thresholdDate, List<DateTime> createDates)
        {

            Validator.ValidateList(createDates, nameof(createDates));

            DateTime mostRecent = createDates.OrderByDescending(createDate => createDate.Date).First();
            DateTime leastRecent = createDates.OrderByDescending(createDate => createDate.Date).Reverse().First();

            if (thresholdDate > leastRecent && thresholdDate <= mostRecent)
                return true;

            return false;

        }
        public List<PageItem> RemoveOlderThan(List<PageItem> pageItems, DateTime thresholdDate)
        {

            Validator.ValidateList(pageItems, nameof(pageItems));

            List<PageItem> subset = pageItems.Where(pageItem => pageItem.CreateDate >= thresholdDate).ToList();

            return subset;

        }

        // Methods (private)
        private List<string> ExtractAndFixUrls(string content)
        {

            /*
                /job/8148179/Principal-Professional-Pharmacovigilance-Specialist
                /job/8148174/Technology-Finance-Business-Partner
                ...
             */

            string xpath = "//div[@class='col-sm-9 ']/h1/a/@href";
            uint attributeNr = 1;

            List<string> relativeUrls = _xpathManager.GetAttributeValues(content, xpath, attributeNr);
            List<string> urls = relativeUrls.Select(relativeUrl => ConvertToAbsoluteUrl(relativeUrl)).ToList();

            return urls;

        }
        private List<string> ExtractAndCleanTitles(string content)
        {

            /*
                Principal Professional Pharmacovigilance Specialist &nbsp;
                Administrative Project Manager for the European Horizon 2020 Project "REFLOW" &nbsp;
                ...
            */

            string xpath = "//div[@class='col-sm-9 ']/h1";

            List<string> titles = _xpathManager.GetInnerTexts(content, xpath);
            titles = titles.Select(title => CleanTitle(title)).ToList();

            return titles;

        }
        private List<DateTime?> ExtractCleanAndParseApplicationDates(string content)
        {

            /*
                Application date: As soon as possible
                Application date: May 25, 2021
                Application date: June 06, 2021
                ...
            */

            string xpath = "//div[@class='col-sm-9 ']/p[contains(.,'Application date')]/strong";

            List<string> results = _xpathManager.GetInnerTexts(content, xpath);
            results = results.Select(result => CleanApplicationDate(result)).ToList();
            
            List<DateTime?> applicationDates = results.Select(result => ParseApplicationDate(result)).ToList();

            return applicationDates;

        }
        private List<string> ExtractAndCleanWorkAreas(string content)
        {

            /*
                Work area: Ballerup
                Work area: København
                ...
            */

            string xpath = "//ul[@class='list-inline']/li[contains(.,'Work area')]";

            List<string> results = _xpathManager.GetInnerTexts(content, xpath);
            List<string> workAreas = results.Select(result => CleanWorkArea(result)).ToList();

            return workAreas;

        }
        private List<string> CreateWorkAreasWithoutZones(List<string> workAreas)
            => workAreas.Select(workArea => CreateWorkAreaWithoutZone(workArea)).ToList();
        private List<string> ExtractAndCleanWorkingHours(string content)
        {

            /*
                Working hours: Full time (37 hours)
                Working hours: Full time (37 hours)
                ...
            */

            string xpath = "//ul[@class='list-inline']/li[contains(.,'Working hours')]";

            List<string> results = _xpathManager.GetInnerTexts(content, xpath);
            List<string> workingHours = results.Select(result => CleanWorkingHours(result)).ToList();

            return workingHours;

        }
        private List<string> ExtractAndCleanJobTypes(string content)
        {

            /*
                Job type: Regular position
                Job type: Limited period
                ....
            */

            string xpath = "//ul[@class='list-inline']/li[contains(.,'Job type')]";

            List<string> results = _xpathManager.GetInnerTexts(content, xpath);
            List<string> jobTypes = results.Select(result => CleanJobType(result)).ToList();

            return jobTypes;

        }
        private List<ulong> ExtractAndParseJobIds(List<string> urls)
        {

            /*
                /job/8148179/Principal-Professional-Pharmacovigilance-Specialist => 8148179
                /job/8148174/Technology-Finance-Business-Partner                 => 8148174
                ...
             */

            List<string> results = urls.Select(result => ExtractJobId(result)).ToList();
            List<ulong> jobIds = results.Select(result => ulong.Parse(result)).ToList();

            return jobIds;

        }

        private string ConvertToAbsoluteUrl(string relativeUrl)
        {
            /*
                /job/8148174/Technology-Finance-Business-Partner
                => https://www.workindenmark.dk/job/8148174/Technology-Finance-Business-Partner
            */

            return string.Concat("https://www.workindenmark.dk", relativeUrl);

        }
        private DateTime ParseCreateDate(string createDate)
            => DateTime.ParseExact(createDate, "yyyy-MM-dd", CultureInfo.InvariantCulture);
        private DateTime? ParseApplicationDate(string applicationDate)
        {

            try
            {

                CultureInfo cultureInfo = new CultureInfo("en-US");
                return DateTime.ParseExact(applicationDate, "MMMM dd, yyyy", cultureInfo);

            }
            catch
            {

                return null;

            }

        }
        private string CreateWorkAreaWithoutZone(string workArea)
        {

            /*

                København K 	=> København
                Kgs. Lyngby		=> Kgs. Lyngby
                København V 	=> København
                København Ø 	=> København
                København S		=> København
                Aarhus C 		=> Aarhus
                Viby J 			=> Viby
                Odense S 		=> Odense
                Kongens Lyngby 	=> Kongens Lyngby
                Billund 		=> Billund
                København SV 	=> København
                Esbjerg V 		=> Esbjerg
                Odense SØ 		=> Odense
                Lem St 			=> Lem 
                ...				

            */

            string pattern = "^[a-zA-ZÀ-ÖØ-öø-ÿ.]{1,}$|^[a-zA-ZÀ-ÖØ-öø-ÿ.]{1,}[ ]{1}[a-zA-ZÀ-ÖØ-öø-ÿ.]{3,}|^[a-zA-ZÀ-ÖØ-öø-ÿ.]{1,}";

            return Regex.Match(workArea, pattern).ToString();

        }
        private string CleanTitle(string title)
        {

            string cleanTitle = ReplaceWithEmptyString(title, " &nbsp;");
            cleanTitle = ReplaceWithEmptyString(cleanTitle, "\"");

            return cleanTitle;

        }
        private string CleanApplicationDate(string applicationDate)
            => ReplaceWithEmptyString(applicationDate, "Application date: ");
        private string CleanWorkArea(string workArea)
            => ReplaceWithEmptyString(workArea, "Work area: ");
        private string CleanWorkingHours(string workingHours)
            => ReplaceWithEmptyString(workingHours, "Working hours: ");
        private string CleanJobType(string jobType)
            => ReplaceWithEmptyString(jobType, "Job type: ");
        private string ReplaceWithEmptyString(string str, string toReplace)
            => str.Replace(toReplace, string.Empty);
        private string ExtractJobId(string url)
        {

            /*
                https://www.workindenmark.dk/job/8148174/Technology-Finance-Business-Partner
                    => 8148174
            */

            string pattern = "(?<=/job/)[0-9]{5,}";

            if (!Regex.IsMatch(url, pattern))
                throw new Exception(MessageCollection.PageItemScraper_NotPossibleToExtractJobId.Invoke(url, pattern));

            return Regex.Match(url, pattern).ToString();

        }
        private ushort CalculatePageItemNumber(ushort i)
            => (ushort)(i + 1);
        private string CreatePageItemId(ulong jobId, string title)
        {

            /*
                8144089, "Business Support & Pricing Manager"            
                    => 8144089businesssupportpricingmanager
            */

            string pattern = "[a-zA-Z]{1,}";

            MatchCollection matches = Regex.Matches(title, pattern);

            StringBuilder stringBuilder = new StringBuilder();
            matches.Cast<Match>().ToList().ForEach(match => stringBuilder.Append(match));

            string pageItemId = stringBuilder.ToString();
            pageItemId = pageItemId.ToLower();
            pageItemId = string.Concat(jobId, pageItemId);

            return pageItemId;

        }

        private List<PageItem> CreatePageItems(
                    Page page,
                    List<string> urls,
                    List<string> titles,
                    List<DateTime> createDates,
                    List<DateTime?> applicationDates,
                    List<string> workAreas,
                    List<string> workAreasWithoutZones,
                    List<string> workingHours,
                    List<string> jobTypes,
                    List<ulong> jobIds
                    )
        {

            List<PageItem> pageItems = new List<PageItem>();
            for (int i = 0; i < urls.Count; i++)
            {

                PageItem pageItem = new PageItem(

                        runId: page.RunId,
                        pageNumber: page.PageNumber,
                        url: urls[i],
                        title: titles[i],
                        createDate: createDates[i],
                        applicationDate: applicationDates[i],
                        workArea: workAreas[i],
                        workAreaWithoutZone: workAreasWithoutZones[i],
                        workingHours: workingHours[i],
                        jobType: jobTypes[i],
                        jobId: jobIds[i],
                        pageItemNumber: CalculatePageItemNumber((ushort)i),
                        pageItemId: CreatePageItemId(jobIds[i], titles[i])

                    );

                pageItems.Add(pageItem);

            }

            return pageItems;

        }

    }
}

/*
    Author: numbworks@gmail.com
    Last Update: 19.05.2021
*/