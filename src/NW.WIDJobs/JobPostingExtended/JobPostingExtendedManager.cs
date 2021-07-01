using System;

namespace NW.WIDJobs
{
    /// <summary><inheritdoc cref="IJobPostingExtendedManager"/></summary>
    public class JobPostingExtendedManager : IJobPostingExtendedManager
    {

        #region Fields

        private IGetRequestManagerFactory _getRequestManagerFactory;

        #endregion

        #region Properties
        #endregion

        #region Constructors

        /// <summary>Initializes a <see cref="JobPostingExtendedManager"/> instance.</summary>
        /// <exception cref="ArgumentNullException"/>
        public JobPostingExtendedManager(IGetRequestManagerFactory getRequestManagerFactory)
        {

            Validator.ValidateObject(getRequestManagerFactory, nameof(getRequestManagerFactory));

            _getRequestManagerFactory = getRequestManagerFactory;

        }

        /// <summary>Initializes a <see cref="JobPostingExtendedManager"/> instance using default parameters.</summary>
        public JobPostingExtendedManager()
            : this(new GetRequestManagerFactory()) { }

        #endregion

        #region Methods_public

        public JobPostingExtended GetJobPostingExtended(JobPosting jobPosting)
        {

            Validator.ValidateObject(jobPosting, nameof(jobPosting));

            string response = SendGetRequest(jobPosting);

            throw new NotImplementedException();

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
    Last Update: 01.07.2021
*/