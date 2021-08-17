using System;
using System.Collections.Generic;
using NW.WIDJobs.JobPages;

namespace NW.WIDJobs.Explorations
{
    /// <summary>The result of an exploration on <see href="http://www.workindenmark.dk">WorkInDenmark</see>.</summary>
    public class Exploration
    {

        #region Fields
        #endregion

        #region Properties

        public string RunId { get; }
        public ushort TotalResultCount { get; }
        public ushort TotalJobPages { get; }
        public Stages Stage { get; }
        public bool IsCompleted { get; }
        public List<JobPage> JobPages { get; }
        public List<JobPosting> JobPostings { get; }
        public List<JobPostingExtended> JobPostingsExtended { get; }

        #endregion

        #region Constructors

        /// <summary>Initializes a <see cref="Exploration"/> instance.</summary>
        /// <exception cref="ArgumentNullException"/>
        public Exploration(
            string runId,
            ushort totalResultCount,
            ushort totalJobPages,
            Stages stage,
            bool isCompleted,
            List<JobPage> jobPages = null,
            List<JobPosting> jobPostings = null,
            List<JobPostingExtended> jobPostingsExtended = null
            )
        {

            Validator.ValidateStringNullOrWhiteSpace(runId, nameof(runId));

            RunId = runId;
            TotalResultCount = totalResultCount;
            TotalJobPages = totalJobPages;
            Stage = stage;
            IsCompleted = isCompleted;
            JobPages = jobPages;
            JobPostings = jobPostings;
            JobPostingsExtended = jobPostingsExtended;

        }

        #endregion

        #region Methods_public

        public override string ToString()
        {

            return string.Concat(
                "{ ",
                $"'{nameof(RunId)}':'{RunId}', ",
                $"'{nameof(TotalResultCount)}':'{TotalResultCount}', ",
                $"'{nameof(TotalJobPages)}':'{TotalJobPages}', ",
                $"'{nameof(Stage)}':'{Stage}', ",
                $"'{nameof(IsCompleted)}':'{IsCompleted}', ",
                $"'{nameof(JobPages)}':'{JobPages?.Count.ToString() ?? "null"}', ",
                $"'{nameof(JobPostings)}':'{JobPostings?.Count.ToString() ?? "null"}', ",
                $"'{nameof(JobPostingsExtended)}':'{JobPostingsExtended?.Count.ToString() ?? "null"}'",
                " }"
                );

        }

        #endregion

    }
}

/*
    Author: numbworks@gmail.com
    Last Update: 08.08.2021
*/