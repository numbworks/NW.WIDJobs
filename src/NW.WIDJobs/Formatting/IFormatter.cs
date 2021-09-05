using NW.WIDJobs.Explorations;
using NW.WIDJobs.JobPostings;
using NW.WIDJobs.JobPostingsExtended;
using NW.WIDJobs.Metrics;

namespace NW.WIDJobs.Formatting
{
    /// <summary>Collects all the methods to format the library's objects.</summary>	
    public interface IFormatter
    {

        /// <summary>Returns a compact and readable textual representation of the provided <paramref name="exploration"/>.</summary>	
        string Format(Exploration exploration);

        /// <summary>Returns a compact and readable textual representation of the provided <paramref name="jobPosting"/>.</summary>	
        string Format(JobPosting jobPosting);

        /// <summary>Returns a compact and readable textual representation of the provided <paramref name="jobPostingExtended"/>.</summary>	
        string Format(JobPostingExtended jobPostingExtended);

        /// <summary>Returns a compact and readable textual representation of the provided <paramref name="metricCollection"/>.</summary>	
        string Format(MetricCollection metricCollection);

    }
}

/*
    Author: numbworks@gmail.com
    Last Update: 05.09.2021
*/