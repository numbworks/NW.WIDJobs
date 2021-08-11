using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace NW.WIDJobs
{
    /// <inheritdoc cref="IJobPostingManager"/>
    public class JobPostingManager : IJobPostingManager
    {

        #region Fields

        #endregion

        #region Properties

        #endregion

        #region Constructors

        /// <summary>Initializes a <see cref="JobPostingManager"/> instance.</summary>	
        public JobPostingManager() { }

        #endregion

        #region Methods_public

        public bool IsThresholdConditionMet(DateTime thresholdDate, List<DateTime> postingCreatedCollection)
        {

            Validator.ValidateList(postingCreatedCollection, nameof(postingCreatedCollection));

            DateTime mostRecent = postingCreatedCollection.OrderByDescending(createDate => createDate.Date).First();
            DateTime leastRecent = postingCreatedCollection.OrderByDescending(createDate => createDate.Date).Reverse().First();

            if (thresholdDate > leastRecent && thresholdDate <= mostRecent)
                return true;

            return false;

        }
        public List<JobPosting> RemoveUnsuitable(DateTime thresholdDate, List<JobPosting> jobPostings)
        {

            Validator.ValidateList(jobPostings, nameof(jobPostings));

            List<JobPosting> subset = jobPostings.Where(pageItem => pageItem.PostingCreated >= thresholdDate).ToList();

            return subset;

        }

        public bool IsThresholdConditionMet(string jobPostingId, List<JobPosting> jobPostings)
        {

            Validator.ValidateStringNullOrWhiteSpace(jobPostingId, nameof(jobPostingId));
            Validator.ValidateList(jobPostings, nameof(jobPostings));

            return jobPostings.Any(jobPosting => jobPosting.JobPostingId == jobPostingId);

        }
        public List<JobPosting> RemoveUnsuitable(string jobPostingId, List<JobPosting> jobPostings)
        {

            Validator.ValidateStringNullOrWhiteSpace(jobPostingId, nameof(jobPostingId));
            Validator.ValidateList(jobPostings, nameof(jobPostings));

            List<JobPosting> subset = new List<JobPosting>();
            foreach (JobPosting jobPosting in jobPostings)
                if (jobPosting.JobPostingId == jobPostingId)
                    break;
                else
                    subset.Add(jobPosting);

            return subset;

        }

        #endregion

        #region Methods_private

        #endregion

    }
}

/*
    Author: numbworks@gmail.com
    Last Update: 11.08.2021
*/