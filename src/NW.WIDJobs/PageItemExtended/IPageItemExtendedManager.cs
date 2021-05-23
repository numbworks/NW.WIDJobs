using System;

namespace NW.WIDJobs
{
    /// <summary>Collects all the helper methods related to <see cref="PageItemExtended"/>.</summary>
    public interface IPageItemExtendedManager
    {

        /// <summary>
        /// Retrieves the <see cref="PageItemExtended"/> object that corresponds to <paramref name="pageItem"/>.
        /// </summary>
        /// <exception cref="ArgumentNullException"/>
        /// <exception cref="Exception"/> 
        PageItemExtended Get(PageItem pageItem);

        /// <summary>
        /// Retrieves the HTML content of a <see href="http://www.workindenmark.dk">WorkInDenmark</see>'s page item extended via HTTP GET Request.
        /// </summary>
        /// <exception cref="ArgumentNullException"/>        
        string GetContent(string url);

    }
}

/*
    Author: numbworks@gmail.com
    Last Update: 23.05.2021
*/