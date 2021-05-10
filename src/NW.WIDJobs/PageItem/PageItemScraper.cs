using System;
using System.Collections.Generic;
using System.Globalization;
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
            List<string> workingHours = ExtractAndCleanWorkingHours(page.Content);
            List<string> jobTypes = ExtractAndCleanJobTypes(page.Content);
            List<ulong> jobIds = ExtractAndParseJobIds(urls);

            Validator.ThrowIfCountsAreNotEqual<Exception>
                (urls, titles, createDates, applicationDates, workAreas, workingHours, jobTypes, jobIds);

            List<PageItem> pageItems
                = CreatePageItems(page, urls, titles, createDates, applicationDates, workAreas, workingHours, jobTypes, jobIds);

            return pageItems;

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
                Technology Finance Business Partner &nbsp;
                ...
            */

            string xpath = "//div[@class='col-sm-9 ']/h1";

            List<string> titles = _xpathManager.GetInnerTexts(content, xpath);
            titles = titles.Select(title => CleanTitle(title)).ToList();

            return titles;

        }
        private List<DateTime> ExtractAndParseCreateDates(string content)
        {

            /*
                2021-05-09
                2021-05-09
                ...
            */

            string xpath = "//div[@class='col-sm-9 ']/p[contains(.,'Created')]/time/@datetime";
            uint attributeNr = 0;

            List<string> results = _xpathManager.GetAttributeValues(content, xpath, attributeNr);
            List<DateTime> createDates = results.Select(result => ParseCreateDate(result)).ToList();

            return createDates;

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
        private string CleanTitle(string title)
            => ReplaceWithEmptyString(title, " &nbsp;");
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
                throw new Exception($"Not possible to extract JobId from '{url}' with pattern: '{pattern}'.");

            return Regex.Match(url, pattern).ToString();

        }
        private ushort CalculatePageItemNumber(ushort i)
            => (ushort)(i + 1);
        private string CreatePageItemId(ulong jobId, string title)
        {

            /*
                8148179, Principal Professional Pharmacovigilance Specialist             
                    => 8148179principalprofessionalpharmacovigilancespecialist
            */

            string pageItemId = string.Concat(jobId, title);
            pageItemId = ReplaceWithEmptyString(pageItemId, " ");
            pageItemId = ReplaceWithEmptyString(pageItemId, "\\");
            pageItemId = ReplaceWithEmptyString(pageItemId, "/");
            pageItemId = ReplaceWithEmptyString(pageItemId, "&nbsp;");
            pageItemId = pageItemId.ToLower();

            return pageItemId;

        }

        private List<PageItem> CreatePageItems(
                    Page page,
                    List<string> urls,
                    List<string> titles,
                    List<DateTime> createDates,
                    List<DateTime?> applicationDates,
                    List<string> workAreas,
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
    Last Update: 10.05.2021
*/