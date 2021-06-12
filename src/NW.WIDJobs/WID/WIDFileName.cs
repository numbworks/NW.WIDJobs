using System;

namespace NW.WIDJobs
{
    /// <summary>A collection of information to aid <see cref="WIDExplorer"/>'s filename generation.</summary>
    public class WIDFileName
    {

        #region Fields
        #endregion

        #region Properties

        public static string DefaultFormatNow { get; } = "yyyyMMddHHmmssfff";
        public static string DefaultFormatFileName { get; } = "{0}_{1}.{2}";
        public static string DefaultJsonExtension { get; } = "json";
        public static string DefaultSQLiteDatabaseExtension { get; } = "db";
        public static string DefaultExplorationToken { get; } = "Exploration";
        public static string DefaultMetricsToken { get; } = "Metrics";
        public static string DefaultDatabaseToken { get; } = "WIDjobs";

        public string FilePath { get; }
        public DateTime Now { get; }

        #endregion

        #region Constructors

        ///<summary>Initializes a <see cref="WIDFileName"/> instance.</summary>
        /// <exception cref="ArgumentNullException"/>
        public WIDFileName(string filePath, DateTime now) 
        {

            Validator.ValidateStringNullOrWhiteSpace(filePath, nameof(filePath));

            FilePath = filePath;
            Now = now;

        }

        #endregion

        #region Methods_public
        #endregion

    }
}

/*
    Author: numbworks@gmail.com
    Last Update: 12.06.2021
*/