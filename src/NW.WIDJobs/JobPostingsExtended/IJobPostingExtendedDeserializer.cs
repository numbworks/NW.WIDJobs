using System;

namespace NW.WIDJobs
{
    /// <summary>A deserializer for <see href="http://www.workindenmark.dk">WorkInDenmark</see>'s job postings extended.</summary>
    public interface IJobPostingExtendedDeserializer
    {

        /// <summary>
        /// Extracts a <see cref="JobPostingExtended"/> object from the provided <paramref name="response"/>.
        /// </summary>
        /// <exception cref="ArgumentNullException"/>
        /// <exception cref="Exception"/>
        JobPostingExtended Do(JobPosting jobPosting, string response);

    }
}

/*
    Author: numbworks@gmail.com
    Last Update: 02.07.2021
*/