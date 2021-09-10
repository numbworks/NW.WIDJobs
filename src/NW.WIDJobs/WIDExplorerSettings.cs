using System;
using System.IO;
using NW.WIDJobs.Validation;

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
        public static string DefaultFolderPath { get; } = Directory.GetCurrentDirectory();
        public static bool DefaultDeleteAndRecreateDatabase { get; } = true;
        public static bool DefaultTranslateOccupation { get; } = true;

        public ushort ParallelRequests { get; }
        public uint PauseBetweenRequestsMs { get; }
        public string FolderPath { get; }
        public bool DeleteAndRecreateDatabase { get; }
        public bool TranslateOccupation { get; }

        #endregion

        #region Constructors

        /// <summary>Initializes a <see cref="WIDExplorerSettings"/> instance.</summary>
        /// <exception cref="ArgumentException"/>
        public WIDExplorerSettings(
            ushort parallelRequests,
            uint pauseBetweenRequestsMs,
            string folderPath,
            bool deleteAndRecreateDatabase,
            bool translateOccupation
            )
        {

            Validator.ThrowIfLessThanOne(parallelRequests, nameof(parallelRequests));
            Validator.ValidateStringNullOrWhiteSpace(folderPath, nameof(folderPath));

            ParallelRequests = parallelRequests;
            PauseBetweenRequestsMs = pauseBetweenRequestsMs;
            FolderPath = folderPath;
            DeleteAndRecreateDatabase = deleteAndRecreateDatabase;
            TranslateOccupation = translateOccupation;

        }

        /// <summary>Initializes a <see cref="WIDExplorerSettings"/> instance using default parameters.</summary>
        public WIDExplorerSettings()
            : this(
                  DefaultParallelRequests,
                  DefaultPauseBetweenRequestsMs,
                  DefaultFolderPath,
                  DefaultDeleteAndRecreateDatabase,
                  DefaultTranslateOccupation
                  ) { }

        #endregion

        #region Methods_public
        #endregion

    }
}

/*
    Author: numbworks@gmail.com
    Last Update: 10.09.2021
*/