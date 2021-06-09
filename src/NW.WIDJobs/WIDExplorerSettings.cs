using System;
using System.IO;

namespace NW.WIDJobs
{
    /// <summary>Collects all the global settings required by this library.</summary>
    public class WIDExplorerSettings
    {

        #region Fields
        #endregion

        #region Properties

        public static ushort DefaultParallelRequests { get; } = 3;
        public static uint DefaultPauseBetweenRequestsMs { get; } = 25000; // 25 seconds
        public static string DefaultDatabasePath { get; } = Directory.GetCurrentDirectory();
        public static string DefaultDatabaseName { get; } = "widjobs.db";
        public static bool DefaultDeleteAndRecreateDatabase { get; } = true;

        public ushort ParallelRequests { get; }
        public uint PauseBetweenRequestsMs { get; }
        public string DatabasePath { get; }
        public string DatabaseName { get; }
        public bool DeleteAndRecreateDatabase { get; }

        #endregion

        #region Constructors

        /// <summary>Initializes a <see cref="WIDExplorerSettings"/> instance.</summary>
        /// <exception cref="ArgumentException"/>
        public WIDExplorerSettings(
            ushort parallelRequests,
            uint pauseBetweenRequestsMs,
            string databasePath,
            string databaseName,
            bool deleteAndRecreateDatabase
            )
        {

            Validator.ThrowIfLessThanOne(parallelRequests, nameof(parallelRequests));
            Validator.ValidateStringNullOrWhiteSpace(databasePath, nameof(databasePath));
            Validator.ValidateStringNullOrWhiteSpace(databaseName, nameof(databaseName));

            ParallelRequests = parallelRequests;
            PauseBetweenRequestsMs = pauseBetweenRequestsMs;
            DatabasePath = databasePath;
            DatabaseName = databaseName;
            DeleteAndRecreateDatabase = deleteAndRecreateDatabase;

        }

        /// <summary>Initializes a <see cref="WIDExplorerSettings"/> instance using default parameters.</summary>
        public WIDExplorerSettings()
            : this(
                  DefaultParallelRequests,
                  DefaultPauseBetweenRequestsMs,
                  DefaultDatabasePath,
                  DefaultDatabaseName,
                  DefaultDeleteAndRecreateDatabase
                  ) { }

        #endregion

        #region Methods_public
        #endregion

    }
}

/*
    Author: numbworks@gmail.com
    Last Update: 09.05.2021
*/