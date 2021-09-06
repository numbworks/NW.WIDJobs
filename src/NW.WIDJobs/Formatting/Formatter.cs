using System;
using NW.WIDJobs.Explorations;
using NW.WIDJobs.Validation;
using NW.WIDJobs.Metrics;
using NW.WIDJobs.Messages;
using NW.WIDJobs.JobPostingsExtended;
using NW.WIDJobs.JobPostings;
using System.Text.RegularExpressions;
using System.Linq;

namespace NW.WIDJobs.Formatting
{
    /// <inheritdoc cref="IFormatter"/>
    public class Formatter : IFormatter
    {

        #region Fields

        private IMetricCollectionManager _metricCollectionManager;

        #endregion

        #region Properties

        public static string ZeroString { get; } = "0";
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
                        $"'{jobPosting.Id}', ",
                        $"'{Format(jobPosting.Title)}', ",
                        $"'{Format(jobPosting.HiringOrgName)}', ",
                        $"'{jobPosting.WorkPlaceCityWithoutZone}'."
                    );

        }
        public string Format(JobPostingExtended jobPostingExtended)
        {

            Validator.ValidateObject(jobPostingExtended, nameof(jobPostingExtended));

            return string.Concat(
                        $"{nameof(JobPostingExtended)}: ",
                        $"'{jobPostingExtended.JobPosting.Id}', ",
                        $"'{Format(jobPostingExtended.JobPosting.Title)}', ",
                        $"'{jobPostingExtended.BulletPoints?.Count.ToString() ?? ZeroString}' {BulletPointsString}."
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
                            $"'{exploration.JobPages?.Count.ToString() ?? ZeroString}' {nameof(Exploration.JobPages)}, ",
                            $"'{exploration.JobPostings?.Count.ToString() ?? ZeroString}' {nameof(Exploration.JobPostings)}."
                        );

            if (exploration.Stage == Stages.Stage3_UpToAllJobPostingsExtended)
                return string.Concat(
                            $"{nameof(Exploration)}: ",
                            $"'{exploration.JobPages?.Count.ToString() ?? ZeroString}' {nameof(Exploration.JobPages)}, ",
                            $"'{exploration.JobPostingsExtended?.Count.ToString() ?? ZeroString}' {nameof(Exploration.JobPostingsExtended)}, ",
                            $"'{_metricCollectionManager.TrySumBulletPoints(exploration)?.ToString() ?? ZeroString}' {BulletPointsString}."
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
        public string Format(uint value)
        {

            if (value < 10)
                return $"{0}{value}";

            return value.ToString();

        }
        public string Format(string longString)
        {

            /*
                "Motivated forklift drivers for temporary positions during the summer in Skanderborg"
                    => "Motivated forklift drivers for temporary..."
            */

            if (string.IsNullOrWhiteSpace(longString))
                return longString;

            string pattern = "[a-zA-Z]{1,}";
            string[] words = Regex.Matches(longString, pattern).Cast<Match>().Select(m => m.Value).ToArray();

            int threshold = 5;
            if (words.Length <= threshold)
                return longString;

            words = words.Take(threshold).ToArray();

            string result = string.Join(" ", words);
            result = $"{result}...";

            return result;

        }

        #endregion

        #region Methods_private

        #endregion

    }
}

/*
    Author: numbworks@gmail.com
    Last Update: 06.09.2021
*/