using System;
using NW.WIDJobs.JobPostings;

namespace NW.WIDJobs.JobPostingsExtended
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
        /// Sends a HTTP GET Request for <see cref="JobPosting.Url"/> using custom parameters and returns the response as string.
        /// </summary>
        /// <exception cref="ArgumentNullException"/>        
        string SendGetRequest(JobPosting jobPosting);

        /// <summary>
        /// Sends a HTTP GET Request for <paramref name="url"/> using custom parameters and returns the response as string.
        /// </summary>
        /// <exception cref="ArgumentNullException"/>        
        string SendGetRequest(string url);

    }
}

/*
    Author: numbworks@gmail.com
    Last Update: 10.09.2021
*/