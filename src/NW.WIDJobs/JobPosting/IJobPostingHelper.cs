﻿using System;

namespace NW.WIDJobs
{
    /// <summary>Collects all the helper methods related to <see cref="JobPosting"/>.</summary>
    public interface IJobPostingHelper
    {

        /// <summary>
        /// Expect date strings in the following format: <code>"2021-06-22T00:00:00"</code>
        /// </summary>
        DateTime ParseDate(string date);

    }
}

/*
    Author: numbworks@gmail.com
    Last Update: 25.06.2021
*/