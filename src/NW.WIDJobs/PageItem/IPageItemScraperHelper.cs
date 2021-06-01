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
    
    }
}

/*
    Author: numbworks@gmail.com
    Last Update: 01.06.2021
*/