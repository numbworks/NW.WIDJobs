using System;
using System.Net;
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

            string response = SendGetRequest(jobPosting);
            JobPostingExtended jobPostingExtended = _jobPostingExtendedDeserializer.Do(jobPosting, response);

            return jobPostingExtended;

        }
        public string SendGetRequest(JobPosting jobPosting)
        {

            Validator.ValidateObject(jobPosting, nameof(jobPosting));

            WebHeaderCollection headers = _headerFactory.Create();
            IGetRequestManager getRequestManager
                = _getRequestManagerFactory.Create(headers, null, null, null);

            return getRequestManager.Send(jobPosting.Url);

        }

        #endregion

    }
}

/*
    Author: numbworks@gmail.com
    Last Update: 02.09.2021
*/