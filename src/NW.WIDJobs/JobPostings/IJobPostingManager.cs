using System;
using System.Collections.Generic;
using NW.WIDJobs.JobPages;

namespace NW.WIDJobs.JobPostings
{
    /// <summary>Collects all the helper methods related to <see cref="JobPosting"/>.</summary>
    public interface IJobPostingManager
    {

        /// <summary>
        /// During an exploration and while evaluating the content of a <see cref="JobPage"/>, 
        /// this method establishes if the <paramref name="thresholdDate"/> condition is met 
        /// and the exploration must stop ("True" case), or if the exploration 
        /// must continue ("False" case).
        /// </summary>
        /// <exception cref="ArgumentNullException"/>      
        bool IsThresholdConditionMet(DateTime thresholdDate, List<DateTime> postingCreatedCollection);

        /// <summary>
        /// If <see cref="IsThresholdConditionMet"/> returns "True" for a given <see cref="JobPage"/>, 
        /// the exploration must stop and the unsuitable <see cref="JobPosting"/> objects must be removed.
        /// </summary>
        /// <exception cref="ArgumentNullException"/>        
        List<JobPosting> RemoveUnsuitable(DateTime thresholdDate, List<JobPosting> jobPostings);

        /// <summary>
        /// During an exploration and while evaluating the content of a <see cref="JobPage"/>, 
        /// this method establishes if <paramref name="jobPostings"/> contains a <see cref="JobPosting"/> 
        /// object with <see cref="JobPosting.JobPostingId"/> equal to <paramref name="jobPostingId"/>. 
        /// If "True", the exploration must stop.
        /// </summary>
        /// <exception cref="ArgumentNullException"/>      
        bool IsThresholdConditionMet(string jobPostingId, List<JobPosting> jobPostings);

        /// <summary>
        /// If <see cref="IsThresholdConditionMet"/> returns "True" for a given <see cref="JobPosting.JobPostingId"/>, 
        /// the exploration must stop and the unsuitable <see cref="JobPosting"/> objects must be removed.
        /// </summary>
        /// <exception cref="ArgumentNullException"/>        
        List<JobPosting> RemoveUnsuitable(string jobPostingId, List<JobPosting> jobPostings);

    }
}

/*
    Author: numbworks@gmail.com
    Last Update: 08.10.2021
*/