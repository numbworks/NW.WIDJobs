using System;
using NW.WIDJobs.Explorations;
using NW.WIDJobs.JobPostings;
using NW.WIDJobs.JobPostingsExtended;
using NW.WIDJobs.Metrics;

namespace NW.WIDJobs.Formatting
{
    /// <summary>Collects all the methods to format the library's objects.</summary>	
    public interface IFormatter
    {

        /// <summary>Returns a compact and readable textual representation of the provided <paramref name="jobPosting"/>.</summary>
        /// <exception cref="ArgumentNullException"/>
        string Format(JobPosting jobPosting);

        /// <summary>Returns a compact and readable textual representation of the provided <paramref name="jobPostingExtended"/>.</summary>	
        /// <exception cref="ArgumentNullException"/>
        string Format(JobPostingExtended jobPostingExtended);

        /// <summary>Returns a compact and readable textual representation of the provided <paramref name="exploration"/>.</summary>
        /// <exception cref="ArgumentNullException"/>
        /// <exception cref="Exception"/> 
        string Format(Exploration exploration);

        /// <summary>Returns a compact and readable textual representation of the provided <paramref name="metricCollection"/>.</summary>
        /// <exception cref="ArgumentNullException"/>
        string Format(MetricCollection metricCollection);

        /// <summary>Add a leading zero to one-digit numbers.</summary>
        string Format(uint value);

    }
}

/*
    Author: numbworks@gmail.com
    Last Update: 06.09.2021
*/