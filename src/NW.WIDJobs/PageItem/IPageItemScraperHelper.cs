using System;

namespace NW.WIDJobs
{
    /// <summary>Collects all the helper methods in common between <see cref="PageItemScraper"/> and <see cref="PageItemExtendedScraper"/>.</summary>
    public interface IPageItemScraperHelper
    {

        /// <summary>
        /// Converts <see href="http://www.workindenmark.dk">WorkInDenmark</see>'s relative urls to absolute ones.
        /// </summary>
        /// <exception cref="ArgumentNullException"/> 
        string ConvertToAbsoluteUrl(string relativeUrl);

        /// <summary>
        /// Prepares <paramref name="workArea"/> so that it can be assigned to <see cref="PageItem.WorkArea"/>.
        /// </summary>
        /// <exception cref="ArgumentNullException"/> 
        string CleanWorkArea(string workArea);

        /// <summary>
        /// Prepares <paramref name="workingHours"/> so that it can be assigned to <see cref="PageItem.WorkingHours"/>.
        /// </summary>
        /// <exception cref="ArgumentNullException"/>  
        string CleanWorkingHours(string workingHours);

        /// <summary>
        /// Prepares <paramref name="jobType"/> so that it can be assigned to <see cref="PageItem.JobType"/>.
        /// </summary>
        /// <exception cref="ArgumentNullException"/> 
        string CleanJobType(string jobType);

        /// <summary>
        /// Processes <paramref name="workArea"/> so that the resulting string can be assigned to <see cref="PageItem.WorkAreaWithoutZone"/>.
        /// </summary>
        /// <exception cref="ArgumentNullException"/> 
        string CreateWorkAreaWithoutZone(string workArea);

        /// <summary>
        /// Processes <paramref name="url"/> so that the resulting string can be assigned to <see cref="PageItem.JobId"/>.
        /// </summary>
        /// <exception cref="ArgumentNullException"/> 
        /// <exception cref="Exception"/> 
        string ExtractJobId(string url);

    }
}

/*
    Author: numbworks@gmail.com
    Last Update: 01.06.2021
*/