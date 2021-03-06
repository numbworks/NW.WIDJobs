using System;
using System.IO;
using NW.WIDJobs.Validation;

namespace NW.WIDJobs.Filenames
{
    /// <inheritdoc cref="IFilenameFactory"/>
    public class FilenameFactory : IFilenameFactory
    {

        #region Fields
        #endregion

        #region Properties

        public static string DefaultFileNameDatedTemplate { get; } = "{0}_{1}.{2}";
        public static string DefaultFileNameUndatedTemplate { get; } = "{0}.{1}";
        public static string DefaultFormatNow { get; } = "yyyyMMddHHmmssfff";
        public static string DefaultExplorationJsonToken { get; } = "widjobs_exploration";
        public static string DefaultMetricCollectionJsonToken { get; } = "widjobs_metrics";
        public static string DefaultMetricCollectionPctJsonToken { get; } = "widjobs_metricspct";
        public static string DefaultDatabaseToken { get; } = "widjobs_exploration";
        public static string DefaultBulletPointTypesToken { get; } = "widjobs_bulletpointtypes";
        public static string DefaultJsonExtension { get; } = "json";
        public static string DefaultDatabaseExtension { get; } = "db";

        #endregion

        #region Constructors

        ///<summary>Initializes a <see cref="FilenameFactory"/> instance.</summary>
        public FilenameFactory() { }

        #endregion

        #region Methods_public

        public string CreateForDatabase(string filePath)
            => ValidateAndCreate(
                    filePath,
                    string.Format(DefaultFileNameUndatedTemplate, DefaultDatabaseToken, DefaultDatabaseExtension));
        public string CreateForDatabase(string filePath, string fileName)
            => ValidateAndCreate(filePath, fileName);
        public string CreateForDatabase(string filePath, string token, DateTime now)
            => ValidateAndCreate(filePath, token, now, DefaultDatabaseExtension);
        public string CreateForDatabase(string filePath, DateTime now)
            => ValidateAndCreate(filePath, DefaultDatabaseToken, now, DefaultDatabaseExtension);

        public string CreateForMetricCollectionJson(string filePath, DateTime now, bool numbersAsPercentages)
        {

            if (numbersAsPercentages)
                return ValidateAndCreate(filePath, DefaultMetricCollectionPctJsonToken, now, DefaultJsonExtension);

            return ValidateAndCreate(filePath, DefaultMetricCollectionJsonToken, now, DefaultJsonExtension);

        }
        public string CreateForExplorationJson(string filePath, DateTime now)
            => ValidateAndCreate(filePath, DefaultExplorationJsonToken, now, DefaultJsonExtension);
        public string CreateForBulletPointTypesJson(string filePath, DateTime now)
            => ValidateAndCreate(filePath, DefaultBulletPointTypesToken, now, DefaultJsonExtension);

        #endregion

        #region Methods_private

        private string ValidateAndCreate
            (string filePath, string fileName)
        {

            Validator.ValidateStringNullOrWhiteSpace(filePath, nameof(filePath));
            Validator.ValidateStringNullOrWhiteSpace(fileName, nameof(fileName));

            return Path.Combine(filePath, fileName);

        }
        private string ValidateAndCreate
            (string filePath, string token, DateTime now, string extension)
        {

            Validator.ValidateStringNullOrWhiteSpace(filePath, nameof(filePath));
            Validator.ValidateStringNullOrWhiteSpace(token, nameof(token));
            // Extension doesn't need to be validated, it's "internally" provided.

            string template = DefaultFileNameDatedTemplate;
            string nowstring = now.ToString(DefaultFormatNow);

            string fileName = string.Format(template, token, nowstring, extension);

            return Path.Combine(filePath, fileName);

        }

        #endregion

    }
}

/*
    Author: numbworks@gmail.com
    Last Update: 14.09.2021
*/