using System;
using System.IO;
using NW.WIDJobs.Validation;
using NW.WIDJobs.JobPostings;
using NW.WIDJobs.JobPostingsExtended;

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
        public static bool DefaultTranslateJobPostingOccupation { get; } = true;
        public static bool DefaultPredictJobPostingLanguage { get; } = true;
        public static bool DefaultPredictBulletPointType { get; } = false;

        public ushort ParallelRequests { get; }
        public uint PauseBetweenRequestsMs { get; }
        public string FolderPath { get; }
        public bool DeleteAndRecreateDatabase { get; }
        public bool TranslateJobPostingOccupation { get; }
        public bool PredictJobPostingLanguage { get; }
        public bool PredictBulletPointType { get; }

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a <see cref="WIDExplorerSettings"/> instance.
        /// <para>If <paramref name="translateJobPostingOccupation"/> is true, <see cref="JobPosting.Occupation"/> is translated from Danish to English.</para>
        /// <para>If <paramref name="predictJobPostingLanguage"/> is true, a language prediction is attempted out of <see cref="JobPosting.Title"/> and <see cref="JobPosting.Presentation"/>. It may be moderately expensive on the CPU.</para>  
        /// <para>If <paramref name="predictBulletPointType"/> is true, a type prediction is attempted out of <see cref="BulletPoint.Text"/>. It may be moderately expensive on the CPU.</para>         
        /// </summary>
        /// <exception cref="ArgumentException"/>
        public WIDExplorerSettings(
            ushort parallelRequests,
            uint pauseBetweenRequestsMs,
            string folderPath,
            bool deleteAndRecreateDatabase,
            bool translateJobPostingOccupation,
            bool predictJobPostingLanguage,
            bool predictBulletPointType
            )
        {

            Validator.ThrowIfLessThanOne(parallelRequests, nameof(parallelRequests));
            Validator.ValidateStringNullOrWhiteSpace(folderPath, nameof(folderPath));

            ParallelRequests = parallelRequests;
            PauseBetweenRequestsMs = pauseBetweenRequestsMs;
            FolderPath = folderPath;
            DeleteAndRecreateDatabase = deleteAndRecreateDatabase;
            TranslateJobPostingOccupation = translateJobPostingOccupation;
            PredictJobPostingLanguage = predictJobPostingLanguage;
            PredictBulletPointType = predictBulletPointType;

        }

        /// <summary>Initializes a <see cref="WIDExplorerSettings"/> instance using default parameters.</summary>
        public WIDExplorerSettings()
            : this(
                  DefaultParallelRequests,
                  DefaultPauseBetweenRequestsMs,
                  DefaultFolderPath,
                  DefaultDeleteAndRecreateDatabase,
                  DefaultTranslateJobPostingOccupation,
                  DefaultPredictJobPostingLanguage,
                  DefaultPredictBulletPointType
                  ) { }

        #endregion

        #region Methods_public
        #endregion

    }
}

/*
    Author: numbworks@gmail.com
    Last Update: 16.09.2021
*/