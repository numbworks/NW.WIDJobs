using System;
using System.Text.RegularExpressions;
using NW.WIDJobs.HttpRequests;

namespace NW.WIDJobs.JobPages
{
    /// <summary><inheritdoc cref="IJobPageManager"/></summary>
    public class JobPageManager : IJobPageManager
    {

        #region Fields

        private IPostRequestManagerFactory _postRequestManagerFactory;

        #endregion

        #region Properties

        public static ushort JobPostingsPerPage = 20;
        public static Func<ushort, string> UrlTemplate
            = (offset) => $"https://job.jobnet.dk/CV/FindWork?Offset={offset}&SortValue=CreationDate&widk=true";
        public static string OffsetPattern = "(?<=Offset=)[0-9]{1,}";

        #endregion

        #region Constructors

        /// <summary>Initializes a <see cref="JobPageManager"/> instance.</summary>
        /// <exception cref="ArgumentNullException"/>
        public JobPageManager(IPostRequestManagerFactory postRequestManagerFactory)
        {

            Validator.ValidateObject(postRequestManagerFactory, nameof(postRequestManagerFactory));

            _postRequestManagerFactory = postRequestManagerFactory;

        }

        /// <summary>Initializes a <see cref="JobPageManager"/> instance using default parameters.</summary>
        public JobPageManager()
            : this(new PostRequestManagerFactory()) { }

        #endregion

        #region Methods_public

        public JobPage GetJobPage(string runId, ushort pageNumber)
        {

            Validator.ValidateStringNullOrWhiteSpace(runId, nameof(runId));
            Validator.ThrowIfLessThanOne(pageNumber, nameof(pageNumber));

            string url = CreateUrl(pageNumber);
            string response = SendPostRequest(url);

            JobPage jobPage = new JobPage(runId, pageNumber, response);

            return jobPage;

        }
        public ushort GetTotalJobPages(uint totalResultCount)
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
            int totalJobPages = Math.DivRem((int)totalResultCount, JobPostingsPerPage, out reminder);
            if (reminder > 0)
                totalJobPages++;

            return (ushort)totalJobPages;

        }
        public string CreateUrl(ushort pageNumber)
        {

            Validator.ThrowIfLessThanOne(pageNumber, nameof(pageNumber));

            ushort offset = GetOffset(pageNumber);
            string url = UrlTemplate.Invoke(offset);

            return url;

        }
        public string SendPostRequest(string url)
        {

            Validator.ValidateStringNullOrWhiteSpace(url, nameof(url));
            ValidateUrl(url, OffsetPattern);

            string offset = ExtractOffset(url, OffsetPattern);
            string body = CreateBody(offset);

            IPostRequestManager postRequestManager
                = _postRequestManagerFactory.Create(null, null, null, null, null, body, null);

            return postRequestManager.Send(url);

        }

        #endregion

        #region Methods_private

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
        private void ValidateUrl(string url, string pattern)
        {

            if (!Regex.IsMatch(url, pattern))
                throw new Exception(MessageCollection.JobPageManager_NotPossibleExtractOffset.Invoke(url));

        }
        private string ExtractOffset(string url, string pattern)
        {

            /*
                "https://job.jobnet.dk/CV/FindWork?Offset=0&SortValue=CreationDate&widk=true"
                    => "Offset=0" => "0"
                "https://job.jobnet.dk/CV/FindWork?Offset=20&SortValue=CreationDate&widk=true"
                    => "Offset=20" => "20"
            */

            string offset = Regex.Match(url, pattern).ToString();

            return offset;

        }

        #endregion

    }
}

/*
    Author: numbworks@gmail.com
    Last Update: 06.08.2021
*/