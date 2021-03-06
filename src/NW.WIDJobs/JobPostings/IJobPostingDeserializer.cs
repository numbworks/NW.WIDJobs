using System;
using System.Collections.Generic;
using NW.WIDJobs.JobPages;

namespace NW.WIDJobs.JobPostings
{
    /// <summary>A deserializer for <see href="http://www.workindenmark.dk">WorkInDenmark</see>'s job postings.</summary>
    public interface IJobPostingDeserializer
    {

        /// <summary>
        /// Extracts a collection of <see cref="JobPosting"/> objects from the provided <see cref="JobPage.Response"/>.
        /// </summary>
        /// <exception cref="ArgumentNullException"/>
        /// <exception cref="Exception"/>
        List<JobPosting> Do(JobPage jobPage);

    }
}

/*
    Author: numbworks@gmail.com
    Last Update: 15.09.2021
*/