using System.Collections.Generic;

namespace NW.WIDJobs
{
    public interface IWIDMetricsManager
    {
        WIDMetrics Calculate(WIDExploration exploration);
        Dictionary<string, string> ConvertToPercentages(Dictionary<string, uint> dict);
    }
}

/*
    Author: numbworks@gmail.com
    Last Update: 27.05.2021
*/