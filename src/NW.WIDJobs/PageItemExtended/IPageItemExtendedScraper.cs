using System;

namespace NW.WIDJobs
{
    /// <summary>A scraper for <see href="http://www.workindenmark.dk">WorkInDenmark</see>'s page items extended.</summary>
    public interface IPageItemExtendedScraper
    {

        /// <summary>
        /// Extracts the page item extended from <paramref name="content"/> as <see cref="PageItemExtended"/> object.
        /// </summary>
        /// <exception cref="ArgumentNullException"/>
        /// <exception cref="Exception"/> 
        PageItemExtended Do(PageItem pageItem, string content);
    
    }
}

/*
    Author: numbworks@gmail.com
    Last Update: 09.05.2021
*/