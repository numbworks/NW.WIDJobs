using System;
using NW.WIDJobs;

namespace NW.WIDJobsClient
{
    /// <inheritdoc cref="IWIDExplorerSettingsFactory"/>
    public class WIDExplorerSettingsFactory : IWIDExplorerSettingsFactory
    {

        #region Fields

        #endregion

        #region Properties

        #endregion

        #region Constructors

        /// <summary>Initializes a <see cref="WIDExplorerSettingsFactory"/> instance.</summary>	
        public WIDExplorerSettingsFactory() { }

        #endregion

        #region Methods_public

        public WIDExplorerSettings Create
            (string parallelRequests = null, string pauseBetweenRequestsMs = null, string folderPath = null, bool? deleteAndRecreateDatabase = null)
        {

            return new WIDExplorerSettings(
                            parallelRequests: TryParseParallelRequests(parallelRequests) ?? WIDExplorerSettings.DefaultParallelRequests,
                            pauseBetweenRequestsMs: TryParsePauseBetweenRequestsMs(pauseBetweenRequestsMs) ?? WIDExplorerSettings.DefaultPauseBetweenRequestsMs,
                            folderPath: folderPath ?? WIDExplorerSettings.DefaultFolderPath,
                            deleteAndRecreateDatabase: deleteAndRecreateDatabase ?? WIDExplorerSettings.DefaultDeleteAndRecreateDatabase
                        );

        }

        #endregion

        #region Methods_private

        private ushort? TryParseParallelRequests(string parallelRequests)
        {

            if (parallelRequests == null)
                return null;

            return ushort.Parse(parallelRequests);

        }
        private uint? TryParsePauseBetweenRequestsMs(string pauseBetweenRequestsMs)
        {

            if (pauseBetweenRequestsMs == null)
                return null;

            return uint.Parse(pauseBetweenRequestsMs);

        }

        #endregion

    }
}

/*
    Author: numbworks@gmail.com
    Last Update: 28.08.2021
*/