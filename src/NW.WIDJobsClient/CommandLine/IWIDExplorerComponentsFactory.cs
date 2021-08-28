using NW.WIDJobs;

namespace NW.WIDJobsClient
{
    public interface IWIDExplorerComponentsFactory
    {

        WIDExplorerComponents CreateDefault();
        WIDExplorerComponents CreateForDemoData();

    }
}

/*
    Author: numbworks@gmail.com
    Last Update: 28.08.2021
*/