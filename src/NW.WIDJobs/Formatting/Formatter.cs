using System;
using System.Collections;
using NW.WIDJobs.Explorations;
using NW.WIDJobs.Validation;
using NW.WIDJobs.Metrics;
using NW.WIDJobs.Messages;

namespace NW.WIDJobs.Formatting
{
    /// <inheritdoc cref="IFormatter"/>
    public class Formatter
    {

        #region Fields

        private IMetricCollectionManager _metricCollectionManager;

        #endregion

        #region Properties

        public static string TotalResultCountSynonym { get; } = "TotalJobPostings";

        #endregion

        #region Constructors

        /// <summary>Initializes a <see cref="Formatter"/> instance.</summary>	
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

        public string Format(Exploration exploration)
        {

            Validator.ValidateObject(exploration, nameof(exploration));

            if (exploration.Stage == Stages.Stage1_OnlyMetrics)
                return $"{nameof(Exploration)}: '{TotalResultCountSynonym}':'{exploration.TotalResultCount}', '{nameof(exploration.TotalJobPages)}':'{exploration.TotalJobPages}'.";

            if (exploration.Stage == Stages.Stage2_UpToAllJobPostings)
                return $"{nameof(Exploration)}: '{nameof(JobPages)}':'{exploration.JobPages?.Count.ToString() ?? "null"}', '{nameof(JobPostings)}':'{exploration.JobPostings?.Count.ToString() ?? "null"}'.";

            if (exploration.Stage == Stages.Stage3_UpToAllJobPostingsExtended)
                return $"{nameof(Exploration)}: '{nameof(JobPages)}':'{exploration.JobPages?.Count.ToString() ?? "null"}', '{nameof(JobPostingsExtended)}':'{exploration.JobPostingsExtended?.Count.ToString() ?? "null"}', 'TotalBulletPoints':'{_metricCollectionManager.TrySumBulletPoints(exploration)?.ToString() ?? "null"}'.";

            throw new Exception(MessageCollection.Formatter_NoFormattingStrategyAvailableFor(exploration.Stage.ToString()));

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