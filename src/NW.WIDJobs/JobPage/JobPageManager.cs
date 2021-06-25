using System;
using System.Text.RegularExpressions;

namespace NW.WIDJobs
{
    /// <summary><inheritdoc cref="IJobPageManager"/></summary>
    public class JobPageManager : IJobPageManager
    {

        #region Fields

        private IPostRequestManager _postRequestManager;
        private IPageScraper _pageScraper;

        #endregion

        #region Properties

        public static ushort JobPostingsPerPage = 20;
        public static Func<ushort, string> UrlTemplate
            = (offset) => $"https://job.jobnet.dk/CV/FindWork?Offset={offset}&SortValue=CreationDate&widk=true";

        #endregion

        #region Constructors

        /// <summary>Initializes a <see cref="JobPageManager"/> instance.</summary>
        /// <exception cref="ArgumentNullException"/>
        public JobPageManager(
           IPostRequestManager postRequestManager, IPageScraper pageScraper)
        {

            Validator.ValidateObject(postRequestManager, nameof(postRequestManager));
            Validator.ValidateObject(pageScraper, nameof(pageScraper));

            _postRequestManager = postRequestManager;
            _pageScraper = pageScraper;

        }

        /// <summary>Initializes a <see cref="JobPageManager"/> instance using default parameters.</summary>
        public JobPageManager()
            : this(new PostRequestManager(), new PageScraper()) { }

        #endregion

        #region Methods_public

        public JobPage GetJobPage(string runId, ushort pageNumber)
        {

            Validator.ValidateStringNullOrWhiteSpace(runId, nameof(runId));
            Validator.ThrowIfLessThanOne(pageNumber, nameof(pageNumber));

            string url = CreateUrl(pageNumber);
            string response = PostRequest(url);

            JobPage jobPage = new JobPage(runId, pageNumber, response);

            return jobPage;

        }
        public ushort GetTotalPages(uint totalJobPostings)
        {

            /*
             * 
             *  1243 Job postings / 20 results per page = 62.15.
             *  
             *  In the case above, 63 must be returned, because:
             *     a) 62 pages with 20 results each = 1240;
             *     b) 1 page with the 3 results left.
             *   
             */

            int reminder;
            int totalPages = Math.DivRem((int)totalJobPostings, JobPostingsPerPage, out reminder);
            if (reminder > 0)
                totalPages++;

            return (ushort)totalPages;

        }
        public string CreateUrl(ushort pageNumber)
        {

            Validator.ThrowIfLessThanOne(pageNumber, nameof(pageNumber));

            ushort offset = GetOffset(pageNumber);
            string url = UrlTemplate.Invoke(offset);

            return url;

        }
        public string PostRequest(string url)
        {

            Validator.ValidateStringNullOrWhiteSpace(url, nameof(url));

            string offset = ExtractOffset(url);
            string body = CreateBody(offset);

            return _postRequestManager.Send(url); // replace with POST

        }

        #endregion

        #region Methods_public

        private ushort GetOffset(ushort pageNumber)
        {

            /*

                | PageNumber | Offset |
                | -----------|--------|
                |     1      |    0   |
                |     2      |   20   |
                |     3      |   40   |    
                |    ...     |  ....  |
                           
                (1 * 20) - 20 => 20 - 20 => 0
                (2 * 20) - 20 => 40 - 20 => 20
                ... 

             */

            ushort offset = (ushort)((pageNumber * JobPostingsPerPage) - JobPostingsPerPage);

            return offset;

        }
        private string CreateBody(string offset)
        {

            string body
                = string.Join(
                    Environment.NewLine,
                    "{",
                    "    \"model\": {",
                    $"        \"Offset\": \"{offset}\",",
                    "        \"Count\": 20,",
                    "        \"SearchString\": \"\",",
                    "        \"SortValue\": \"CreationDate\",",
                    "        \"Id\": [],",
                    "        \"EarliestPublicationDate\": null,",
                    "        \"HotJob\": null,",
                    "        \"Abroad\": null,",
                    "        \"NearBy\": \"\",",
                    "        \"OnlyGeoPoints\": false,",
                    "        \"WorkPlaceNotStatic\": null,",
                    "        \"WorkHourMin\": null,",
                    "        \"WorkHourMax\": null,",
                    "        \"Facets\": {",
                    "            \"Region\": null,",
                    "            \"Country\": null,",
                    "            \"Municipality\": null,",
                    "            \"PostalCode\": null,",
                    "            \"OccupationAreas\": null,",
                    "            \"OccupationGroups\": null,",
                    "            \"Occupations\": null,",
                    "            \"EmploymentType\": null,",
                    "            \"WorkHours\": null,",
                    "            \"WorkHourPartTime\": null,",
                    "            \"JobAnnouncementType\": null,",
                    "            \"WorkPlaceNotStatic\": null",
                    "        },",
                    "        \"LocatedIn\": null,",
                    "        \"LocationZip\": null,",
                    "        \"Location\": null,",
                    "        \"SearchInGeoDistance\": 0",
                    "    },",
                    $"    \"url\": \"/CV/FindWork?Offset={offset}&SortValue=CreationDate&widk=true\"",
                    "}"
                );

            return body;

        }
        private string ExtractOffset(string url)
        {

            /*
                "https://job.jobnet.dk/CV/FindWork?Offset=0&SortValue=CreationDate&widk=true"
                    => "Offset=0" => "0"
                "https://job.jobnet.dk/CV/FindWork?Offset=20&SortValue=CreationDate&widk=true"
                    => "Offset=20" => "20"
            */

            string pattern = "(?<=Offset=)[0-9]{1,}";
            if (!Regex.IsMatch(url, pattern))
                throw new Exception(MessageCollection.JobPageManager_NotPossibleExtractOffset.Invoke(url));

            string offset = Regex.Match(url, pattern).ToString();

            return offset;

        }

        #endregion

    }
}

/*
    Author: numbworks@gmail.com
    Last Update: 25.06.2021
*/