using System;
using System.Net;
using System.Text.RegularExpressions;
using NW.WIDJobs.Headers;
using NW.WIDJobs.HttpRequests;
using NW.WIDJobs.JobPostings;
using NW.WIDJobs.Validation;

namespace NW.WIDJobs.JobPostingsExtended
{
    /// <summary><inheritdoc cref="IJobPostingExtendedManager"/></summary>
    public class JobPostingExtendedManager : IJobPostingExtendedManager
    {

        #region Fields

        private IGetRequestManagerFactory _getRequestManagerFactory;
        private IJobPostingExtendedDeserializer _jobPostingExtendedDeserializer;
        private IHeaderFactory _headerFactory;

        #endregion

        #region Properties

        public static string JobnetWebpageUrlPattern { get; } = "(https://job.jobnet.dk/CV/FindWork/Details/)[0-9]{7,}";
        public static string JobnetRequestUrlTemplate { get; } = "https://job.jobnet.dk/CV/FindWork/JobDetailJsonWIDK?id={0}";

        #endregion

        #region Constructors

        /// <summary>Initializes a <see cref="JobPostingExtendedManager"/> instance.</summary>
        /// <exception cref="ArgumentNullException"/>
        public JobPostingExtendedManager
            (IGetRequestManagerFactory getRequestManagerFactory, IJobPostingExtendedDeserializer jobPostingExtendedDeserializer, IHeaderFactory headerFactory)
        {

            Validator.ValidateObject(getRequestManagerFactory, nameof(getRequestManagerFactory));
            Validator.ValidateObject(jobPostingExtendedDeserializer, nameof(jobPostingExtendedDeserializer));
            Validator.ValidateObject(headerFactory, nameof(headerFactory));

            _getRequestManagerFactory = getRequestManagerFactory;
            _jobPostingExtendedDeserializer = jobPostingExtendedDeserializer;
            _headerFactory = headerFactory;

        }

        /// <summary>Initializes a <see cref="JobPostingExtendedManager"/> instance using default parameters.</summary>
        public JobPostingExtendedManager()
            : this(new GetRequestManagerFactory(), new JobPostingExtendedDeserializer(), new HeaderFactory()) { }

        #endregion

        #region Methods_public

        public JobPostingExtended GetJobPostingExtended(JobPosting jobPosting)
        {

            Validator.ValidateObject(jobPosting, nameof(jobPosting));

            string response = string.Empty;
            if (HasWebpageUrl(jobPosting))
            {

                // We use the Request Url instead of the Webpage Url to fetch the response. 
                string requestUrl = CreateRequesttUrl(jobPosting.Id);
                response = SendGetRequest(requestUrl);

            }
            else
            {

                response = SendGetRequest(jobPosting);

            }

            JobPostingExtended jobPostingExtended = _jobPostingExtendedDeserializer.Do(jobPosting, response);

            return jobPostingExtended;

        }
        public string SendGetRequest(JobPosting jobPosting)
        {

            Validator.ValidateObject(jobPosting, nameof(jobPosting));

            return SendGetRequest(jobPosting.Url);

        }
        public string SendGetRequest(string url)
        {

            Validator.ValidateStringNullOrEmpty(url, nameof(url));

            WebHeaderCollection headers = _headerFactory.Create();
            IGetRequestManager getRequestManager = _getRequestManagerFactory.Create(headers, null, null, null);

            return getRequestManager.Send(url);

        }
        public string CreateRequesttUrl(ulong id)
        {

            /*	
                Webpage Url: https://job.jobnet.dk/CV/FindWork/Details/5424719
                Request Url: https://job.jobnet.dk/CV/FindWork/JobDetailJsonWIDK?id=5424719

                The Request Url is always easier to parse, because it returns a Json.		
            */

            string requestUrl = string.Format(JobnetRequestUrlTemplate, id);

            return requestUrl;

        }

        #endregion

        #region Methods_private

        private bool IsWebpageUrl(string webpageUrl)
            => Regex.IsMatch(webpageUrl, JobnetWebpageUrlPattern);
        private bool HasWebpageUrl(JobPosting jobPosting)
        {

            if (jobPosting == null)
                return false;

            return IsWebpageUrl(jobPosting.Url);

        }


        #endregion

    }
}

/*
    Author: numbworks@gmail.com
    Last Update: 10.09.2021
*/