using System;

namespace NW.WIDJobs
{
    /// <summary>Collects all the helper methods related to <see cref="JobPostingExtended"/>.</summary>
    public interface IJobPostingExtendedManager
    {

        /// <summary>
        /// Sends a HTTP GET Request for <see cref="JobPosting.Url"/> and returns a <see cref="JobPostingExtended"/>'s object.
        /// </summary>
        /// <exception cref="ArgumentNullException"/>   
        JobPostingExtended GetJobPostingExtended(JobPosting jobPosting);

        /// <summary>
        /// Sends a HTTP GET Request for <see cref="JobPosting.Url"/> and returns a JSON string.
        /// </summary>
        /// <exception cref="ArgumentNullException"/>        
        string SendGetRequest(JobPosting jobPosting);
    
    }
}

/*
    Author: numbworks@gmail.com
    Last Update: 01.07.2021
*/