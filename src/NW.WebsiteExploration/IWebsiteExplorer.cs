using RUBN.Shared;

namespace NW.WebsiteExploration
{
    public interface IWebsiteExplorer
    {
        IAntiFloodingStrategy AntiFloodingStrategy { get; set; }
        IGetRequestFactory GetRequestFactory { get; set; }
        IParametersValidator ParametersValidator { get; set; }
        ushort ResultsPerPage { get; }
        string WebsiteName { get; }

        Outcome Explore(string strConnectionString);
    }
}

/*
 *
 *  Author: numbworks@gmail.com
 *  Last Update: 22.09.2018
 * 
 */