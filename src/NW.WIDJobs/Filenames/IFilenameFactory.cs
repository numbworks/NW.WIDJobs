using System;

namespace NW.WIDJobs.Filenames
{
    /// <summary>Collects all the methods related to create filenames for <see cref="WIDExplorer"/>.</summary>
    public interface IFilenameFactory
    {

        /// <summary>
        /// Returns an undated filename based on <paramref name="filePath"/> and <see cref="FilenameFactory.DefaultDatabaseToken"/>.
        /// </summary>
        /// <exception cref="ArgumentNullException"/>
        string CreateForDatabase(string filePath);

        /// <summary>
        /// Returns a dated filename based on <paramref name="filePath"/> and <see cref="FilenameFactory.DefaultDatabaseToken"/>.
        /// </summary>
        /// <exception cref="ArgumentNullException"/>
        string CreateForDatabase(string filePath, DateTime now);

        /// <summary>
        /// Returns an undated filename based on <paramref name="filePath"/> and <paramref name="fileName"/>.
        /// </summary>
        /// <exception cref="ArgumentNullException"/> 
        string CreateForDatabase(string filePath, string fileName);

        /// <summary>
        /// Returns a dated filename based on <paramref name="filePath"/> and <paramref name="token"/>.
        /// </summary>
        /// <exception cref="ArgumentNullException"/>
        string CreateForDatabase(string filePath, string token, DateTime now);

        /// <summary>
        /// Returns a dated filename based on <paramref name="filePath"/> and <see cref="FilenameFactory.DefaultMetricCollectionJsonToken"/> (or <see cref="FilenameFactory.DefaultMetricCollectionPctJsonToken"/>).
        /// </summary>
        /// <exception cref="ArgumentNullException"/>
        string CreateForMetricCollectionJson(string filePath, DateTime now, bool numbersAsPercentages);

        /// <summary>
        /// Returns a dated filename based on <paramref name="filePath"/> and <see cref="FilenameFactory.DefaultExplorationJsonToken"/>.
        /// </summary>
        /// <exception cref="ArgumentNullException"/>
        string CreateForExplorationJson(string filePath, DateTime now);

        /// <summary>
        /// Returns a dated filename based on <paramref name="filePath"/> and <see cref="FilenameFactory.DefaultBulletPointTypesToken"/>.
        /// </summary>
        /// <exception cref="ArgumentNullException"/>
        string CreateForBulletPointTypesJson(string filePath, DateTime now);

    }
}

/*
    Author: numbworks@gmail.com
    Last Update: 30.08.2021
*/