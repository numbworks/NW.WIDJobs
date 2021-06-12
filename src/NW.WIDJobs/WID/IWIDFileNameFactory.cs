using System;

namespace NW.WIDJobs
{
    /// <summary>Collects all the methods related to create filenames for <see cref="WIDExplorer"/>.</summary>
    public interface IWIDFileNameFactory
    {

        /// <summary>
        /// Returns an undated filename based on <paramref name="filePath"/> and <see cref="WIDFileNameFactory.DefaultDatabaseToken"/>.
        /// </summary>
        /// <exception cref="ArgumentNullException"/>
        string CreateForDatabase(string filePath);

        /// <summary>
        /// Returns a dated filename based on <paramref name="filePath"/> and <see cref="WIDFileNameFactory.DefaultDatabaseToken"/>.
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
        /// Returns a dated filename based on <paramref name="filePath"/> and <see cref="WIDFileNameFactory.DefaultMetricsJsonToken"/> (or <see cref="WIDFileNameFactory.DefaultMetricsPctJsonToken"/>).
        /// </summary>
        /// <exception cref="ArgumentNullException"/>
        string CreateForMetricsJson(string filePath, DateTime now, bool numbersAsPercentages);

        /// <summary>
        /// Returns a dated filename based on <paramref name="filePath"/> and <paramref name="token"/>.
        /// </summary>
        /// <exception cref="ArgumentNullException"/>
        string CreateForMetricsJson(string filePath, string token, DateTime now);

        /// <summary>
        /// Returns a dated filename based on <paramref name="filePath"/> and <see cref="WIDFileNameFactory.DefaultExplorationJsonToken"/>.
        /// </summary>
        /// <exception cref="ArgumentNullException"/>
        string CreateForExplorationJson(string filePath, DateTime now);

        /// <summary>
        /// Returns a dated filename based on <paramref name="filePath"/> and <paramref name="token"/>.
        /// </summary>
        /// <exception cref="ArgumentNullException"/>        
        string CreateForExplorationJson(string filePath, string token, DateTime now);
        
    }
}

/*
    Author: numbworks@gmail.com
    Last Update: 12.06.2021
*/