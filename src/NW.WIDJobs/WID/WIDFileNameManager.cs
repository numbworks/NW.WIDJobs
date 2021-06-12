using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;

namespace NW.WIDJobs
{
    public class WIDFileNameManager
    {

        #region Fields
        #endregion

        #region Properties

        public static string DefaultFileNameTemplate { get; } = "{0}_{1}.{2}";
        public static string DefaultFormatNow { get; } = "yyyyMMddHHmmssfff";
        public static string DefaultExplorationJsonToken { get; } = "Exploration";
        public static string DefaultMetricsJsonToken { get; } = "Metrics";
        public static string DefaultDatabaseToken { get; } = "WIDjobs";
        public static string DefaultJsonExtension { get; } = "json";
        public static string DefaultDatabaseExtension { get; } = "db";

        #endregion

        #region Constructors

        ///<summary>Initializes a <see cref="WIDFileNameManager"/> instance.</summary>
        public WIDFileNameManager() { }

        #endregion

        #region Methods_public

        public string CreateForExplorationJson
            (string filePath, string token, DateTime now)
        {

            Validator.ValidateStringNullOrWhiteSpace(filePath, nameof(filePath));
            Validator.ValidateStringNullOrWhiteSpace(token, nameof(token));

            string template = DefaultFileNameTemplate;
            string nowstring = now.ToString(DefaultFormatNow);
            string extension = DefaultJsonExtension;

            string fileName = string.Format(template, token, nowstring, extension);

            return Path.Combine(filePath, fileName);

        }
        public string CreateForExplorationJson
            (string filePath, DateTime now)
            => CreateForExplorationJson(filePath, DefaultExplorationJsonToken, now);


        #endregion

    }
}

/*
    Author: numbworks@gmail.com
    Last Update: 12.06.2021
*/