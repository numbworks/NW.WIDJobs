using System;
using NW.WIDJobs.HttpRequests;

namespace NW.WIDJobs
{
    /// <summary><inheritdoc cref="IJobPostingExtendedManager"/></summary>
    public class JobPostingExtendedManager : IJobPostingExtendedManager
    {

        #region Fields

        private IGetRequestManagerFactory _getRequestManagerFactory;
        private IJobPostingExtendedDeserializer _jobPostingExtendedDeserializer;

        #endregion

        #region Properties
        #endregion

        #region Constructors

        /// <summary>Initializes a <see cref="JobPostingExtendedManager"/> instance.</summary>
        /// <exception cref="ArgumentNullException"/>
        public JobPostingExtendedManager
            (IGetRequestManagerFactory getRequestManagerFactory, IJobPostingExtendedDeserializer jobPostingExtendedDeserializer)
        {

            Validator.ValidateObject(getRequestManagerFactory, nameof(getRequestManagerFactory));
            Validator.ValidateObject(jobPostingExtendedDeserializer, nameof(jobPostingExtendedDeserializer));

            _getRequestManagerFactory = getRequestManagerFactory;
            _jobPostingExtendedDeserializer = jobPostingExtendedDeserializer;

        }

        /// <summary>Initializes a <see cref="JobPostingExtendedManager"/> instance using default parameters.</summary>
        public JobPostingExtendedManager()
            : this(new GetRequestManagerFactory(), new JobPostingExtendedDeserializer()) { }

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

            IGetRequestManager getRequestManager
                = _getRequestManagerFactory.Create(null, null, null, null, null);

            return getRequestManager.Send(jobPosting.Url);

        }

        #endregion

    }
}

/*
    Author: numbworks@gmail.com
    Last Update: 07.08.2021
*/