using System;
using System.Collections.Generic;

namespace NW.WIDJobs
{
    /// <summary>Collects all the helper methods related to <see cref="WIDMetrics"/>.</summary>
    public interface IWIDMetricsManager
    {

        /// <summary>
        /// Calculates <see cref="WIDMetrics"/> out of <paramref name="exploration"/>.
        /// </summary>
        /// <exception cref="ArgumentNullException"/>
        /// <exception cref="ArgumentException"/> 
        WIDMetrics Calculate(WIDExploration exploration);

        /// <summary>
        /// Convert each value in <paramref name="dict"/> to the corresponding percentage.
        /// </summary>
        /// <exception cref="ArgumentNullException"/>
        Dictionary<string, string> ConvertToPercentages(Dictionary<string, uint> dict);
    
    }
}

/*
    Author: numbworks@gmail.com
    Last Update: 27.05.2021
*/