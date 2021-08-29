using NW.WIDJobs;

namespace NW.WIDJobsClient.CommandLine
{
    /// <summary>Factory for <see cref="WIDExplorerComponents"/>.</summary>
    public interface IWIDExplorerComponentsFactory
    {

        /// <summary>Creates a <see cref="WIDExplorerComponents"/> instance with default parameters.</summary>
        WIDExplorerComponents CreateDefault();

        /// <summary>Creates a <see cref="WIDExplorerComponents"/> instance for demo usage.</summary>
        WIDExplorerComponents CreateForDemoData();

    }
}

/*
    Author: numbworks@gmail.com
    Last Update: 28.08.2021
*/