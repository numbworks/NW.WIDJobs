using System;
using System.Collections.Generic;
using NW.WIDJobs.JobPostings;
using NW.WIDJobs.JobPostingsExtended;

namespace NW.WIDJobs.Database
{
    /// <summary>Collects all the database-related methods.</summary>
    public interface IRepository
    {

        /// <summary>
        /// Conditionally insert <paramref name="jobPosting"/> into the database and returns affected rows.
        /// </summary>
        /// <exception cref="ArgumentNullException"></exception>
        int ConditionallyInsert(JobPosting jobPosting);

        /// <summary>
        /// Conditionally insert <paramref name="jobPostings"/> into the database and returns affected rows.
        /// </summary>
        /// <exception cref="ArgumentNullException"></exception>
        int ConditionallyInsert(List<JobPosting> jobPostings);

        /// <summary>
        /// Conditionally insert <paramref name="jobPostingExtended"/> into the database and returns affected rows.
        /// </summary>
        /// <exception cref="ArgumentNullException"></exception>
        int ConditionallyInsert(JobPostingExtended jobPostingExtended);

        /// <summary>
        /// Conditionally insert <paramref name="jobPostingsExtended"/> into the database and returns affected rows.
        /// </summary>
        /// <exception cref="ArgumentNullException"></exception>
        int ConditionallyInsert(List<JobPostingExtended> jobPostingsExtended);

    }
}

/*
    Author: numbworks@gmail.com
    Last Update: 08.08.2021
*/