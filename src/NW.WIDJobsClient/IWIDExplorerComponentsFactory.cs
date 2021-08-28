using NW.WIDJobs;

namespace NW.WIDJobsClient
{
    public interface IWIDExplorerComponentsFactory
    {
        WIDExplorerComponents Create(bool useDemoData);
    }
}

/*
    Author: numbworks@gmail.com
    Last Update: 28.08.2021
*/