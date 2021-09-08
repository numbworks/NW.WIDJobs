﻿using System;
using System.Collections.Generic;
using NW.WIDJobs.JobPages;

namespace NW.WIDJobs.JobPostings
{
    /// <summary>A deserializer for <see href="http://www.workindenmark.dk">WorkInDenmark</see>'s job postings.</summary>
    public interface IJobPostingDeserializer
    {

        /// <summary>
        /// Extracts a collection of <see cref="JobPosting"/> objects from the provided <see cref="JobPage.Response"/>.
        /// <para>If <paramref name="translateOccupation"/> is true, <see cref="JobPosting.Occupation"/> is translated from Danish to English.</para>
        /// </summary>
        /// <exception cref="ArgumentNullException"/>
        /// <exception cref="Exception"/>
        List<JobPosting> Do(JobPage jobPage, bool translateOccupation = true);

    }
}

/*
    Author: numbworks@gmail.com
    Last Update: 08.09.2021
*/