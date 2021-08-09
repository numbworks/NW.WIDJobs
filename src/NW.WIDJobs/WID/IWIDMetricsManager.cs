using System;
using System.Collections.Generic;

namespace NW.WIDJobs
{
    /// <summary>Collects all the helper methods related to <see cref="WIDMetrics"/>.</summary>
    public interface IWIDMetricsManager
    {

        /// <summary>
        /// Calculates <see cref="WIDMetrics"/> out of <paramref name="exploration"/>.
        /// <para>Only explorations on <see cref="Stages.Stage3_UpToAllJobPostingsExtended"/> are supported.</para>
        /// </summary>
        /// <exception cref="ArgumentNullException"/>
        /// <exception cref="ArgumentException"/> 
        WIDMetrics Calculate(Exploration exploration);

        /// <summary>
        /// Convert each value in <paramref name="dict"/> to the corresponding percentage.
        /// <para>Intended to be executed against <see cref="WIDMetrics"/> dictionaries.</para>
        /// </summary>
        /// <exception cref="ArgumentNullException"/>
        Dictionary<string, string> ConvertToPercentages(Dictionary<string, uint> dict);
    
    }
}

/*
    Author: numbworks@gmail.com
    Last Update: 27.05.2021
*/