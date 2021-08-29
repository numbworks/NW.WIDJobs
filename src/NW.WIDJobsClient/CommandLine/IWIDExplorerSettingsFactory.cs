﻿using NW.WIDJobs;

namespace NW.WIDJobsClient.CommandLine
{
    /// <summary>Factory for <see cref="WIDExplorerSettings"/>.</summary>
    public interface IWIDExplorerSettingsFactory
    {

        /// <summary>Creates a <see cref="WIDExplorerSettings"/> instance with provided parameters or default parameters when null.</summary>
        WIDExplorerSettings Create
            (string parallelRequests = null, string pauseBetweenRequestsMs = null, string folderPath = null, bool? deleteAndRecreateDatabase = null);
    
    }
}

/*
    Author: numbworks@gmail.com
    Last Update: 28.08.2021
*/