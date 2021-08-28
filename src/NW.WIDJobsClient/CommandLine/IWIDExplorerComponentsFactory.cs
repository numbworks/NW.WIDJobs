﻿using NW.WIDJobs;

namespace NW.WIDJobsClient
{
    /// <summary>Factory for <see cref="WIDExplorerComponents"/>.</summary>
    public interface IWIDExplorerComponentsFactory
    {

        /// <summary>Create a <see cref="WIDExplorerComponents"/> instance with default parameters.</summary>
        WIDExplorerComponents CreateDefault();

        /// <summary>Create a <see cref="WIDExplorerComponents"/> instance for demo usage.</summary>
        WIDExplorerComponents CreateForDemoData();

    }
}

/*
    Author: numbworks@gmail.com
    Last Update: 28.08.2021
*/