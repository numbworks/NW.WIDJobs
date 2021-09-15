using System;
using System.Collections.Generic;
using NW.WIDJobs.Explorations;

namespace NW.WIDJobs.Metrics
{
    /// <summary>Collects all the helper methods related to <see cref="MetricCollection"/>.</summary>
    public interface IMetricCollectionManager
    {

        /// <summary>
        /// Calculates <see cref="MetricCollection"/> out of <paramref name="exploration"/>.
        /// <para>Only explorations on <see cref="Stages.Stage3_UpToAllJobPostingsExtended"/> are supported.</para>
        /// </summary>
        /// <exception cref="ArgumentNullException"/>
        /// <exception cref="ArgumentException"/> 
        MetricCollection Calculate(Exploration exploration);

        /// <summary>
        /// Converts each value in <paramref name="dict"/> to the corresponding percentage. Returns null when <paramref name="dict"/> is null.
        /// <para>Intended to be executed against <see cref="MetricCollection"/> dictionaries.</para>
        /// </summary>
        Dictionary<string, string> TryConvertToPercentages(Dictionary<string, uint> dict);

        /// <summary>
        /// Returns the total amount of bulletpoints.
        /// <para>Returns null when <paramref name="exploration"/> or <see cref="Exploration.JobPostingsExtended"/> are null.</para>
        /// </summary>
        uint? TrySumBulletPoints(Exploration exploration);

    }
}

/*
    Author: numbworks@gmail.com
    Last Update: 14.09.2021
*/