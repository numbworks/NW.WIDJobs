using System;

namespace NW.WIDJobs
{

    /// <summary>A scraper for <see href="http://www.workindenmark.dk">WorkInDenmark</see>'s pages.</summary>
    public interface IPageScraper
    {

        /// <summary>
        /// Extracts the total results from a <see href="http://www.workindenmark.dk">WorkInDenmark</see>'s page (usually the first one).
        /// </summary>
        /// <exception cref="ArgumentNullException"/>
        uint GetTotalResults(string content);    
    
    }
}

/*
    Author: numbworks@gmail.com
    Last Update: 09.05.2021
*/