﻿using System;
using NW.WIDJobs.Explorations;
using NW.WIDJobs.Validation;
using NW.WIDJobs.Metrics;
using NW.WIDJobs.Messages;
using NW.WIDJobs.JobPostingsExtended;
using NW.WIDJobs.JobPostings;

namespace NW.WIDJobs.Formatting
{
    /// <inheritdoc cref="IFormatter"/>
    public class Formatter : IFormatter
    {

        #region Fields

        private IMetricCollectionManager _metricCollectionManager;

        #endregion

        #region Properties

        public static string NullString { get; } = "null";
        public static string BulletPointsString { get; } = "BulletPoints";

        #endregion

        #region Constructors

        /// <summary>Initializes a <see cref="Formatter"/> instance.</summary>
        /// <exception cref="ArgumentNullException"/>
        public Formatter(IMetricCollectionManager metricCollectionManager)
        {

            Validator.ValidateObject(metricCollectionManager, nameof(metricCollectionManager));

            _metricCollectionManager = metricCollectionManager;

        }

        /// <summary>Initializes a <see cref="Formatter"/> instance using default parameters.</summary>	
        public Formatter()
            : this(new MetricCollectionManager()) { }

        #endregion

        #region Methods_public

        public string Format(JobPosting jobPosting)
        {

            Validator.ValidateObject(jobPosting, nameof(jobPosting));

            return string.Concat(
                        $"{nameof(JobPosting)}: ",
                        $"'{jobPosting.JobPostingId}', ",
                        $"'{jobPosting.HiringOrgName}', ",
                        $"'{jobPosting.WorkPlaceCityWithoutZone}'."
                    );

        }
        public string Format(JobPostingExtended jobPostingExtended)
        {

            Validator.ValidateObject(jobPostingExtended, nameof(jobPostingExtended));

            return string.Concat(
                        $"{nameof(JobPostingExtended)}: ",
                        $"'{jobPostingExtended.JobPosting.JobPostingId}', ",
                        $"'{jobPostingExtended.JobPosting.HiringOrgName}', ",
                        $"'{jobPostingExtended.JobPosting.WorkPlaceCityWithoutZone}', ",
                        $"'{(uint)jobPostingExtended.BulletPoints.Count}' {BulletPointsString}."
                    );

        }
        public string Format(Exploration exploration)
        {

            Validator.ValidateObject(exploration, nameof(exploration));

            if (exploration.Stage == Stages.Stage1_OnlyMetrics)
                return string.Concat(
                            $"{nameof(Exploration)}: ",
                            $"'{exploration.TotalResultCount}' {nameof(Exploration.JobPostings)}, ",
                            $"'{exploration.TotalJobPages}' {nameof(Exploration.JobPages)}."
                        );

            if (exploration.Stage == Stages.Stage2_UpToAllJobPostings)
                return string.Concat(
                            $"{nameof(Exploration)}: ",
                            $"'{exploration.JobPages?.Count.ToString() ?? NullString}' {nameof(Exploration.JobPages)}, ",
                            $"'{exploration.JobPostings?.Count.ToString() ?? NullString}' {nameof(Exploration.JobPostings)}."
                        );

            if (exploration.Stage == Stages.Stage3_UpToAllJobPostingsExtended)
                return string.Concat(
                            $"{nameof(Exploration)}: ",
                            $"'{exploration.JobPages?.Count.ToString() ?? NullString}' {nameof(Exploration.JobPages)}, ",
                            $"'{exploration.JobPostingsExtended?.Count.ToString() ?? NullString}' {nameof(Exploration.JobPostingsExtended)}, ",
                            $"'{_metricCollectionManager.TrySumBulletPoints(exploration)?.ToString() ?? NullString}' {BulletPointsString}."
                        );

            throw new Exception(MessageCollection.Formatter_NoFormattingStrategyAvailableFor(exploration.Stage.ToString()));

        }
        public string Format(MetricCollection metricCollection)
        {

            Validator.ValidateObject(metricCollection, nameof(metricCollection));

            return string.Concat(
                        $"{nameof(MetricCollection)}: ",
                        $"'{metricCollection.TotalJobPages}' {nameof(Exploration.JobPages)}, ",
                        $"'{metricCollection.TotalJobPostings}' {nameof(Exploration.JobPostings)}, ",
                        $"'{metricCollection.TotalBulletPoints}' {BulletPointsString}."
                    );

        }

        #endregion

        #region Methods_private

        #endregion

    }
}

/*
    Author: numbworks@gmail.com
    Last Update: 05.09.2021
*/