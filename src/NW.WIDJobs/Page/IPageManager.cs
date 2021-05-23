using System;

namespace NW.WIDJobs
{
    /// <summary>Collects all the helper methods related to <see cref="Page"/>.</summary>
    public interface IPageManager
    {

        /// <summary>
        /// Creates urls for <see href="http://www.workindenmark.dk">WorkInDenmark</see> pages.
        /// </summary>
        /// <exception cref="ArgumentException"/>
        string CreateUrl(ushort pageNumber, WIDCategories category);

        /// <summary>
        /// Estimates the total amount of pages on <see href="http://www.workindenmark.dk">WorkInDenmark</see> according to the provided <paramref name="totalResults"/>.
        /// </summary>
        ushort GetTotalEstimatedPages(uint totalResults);

        /// <summary>
        /// Retrieves the HTML content of a <see href="http://www.workindenmark.dk">WorkInDenmark</see>'s page via HTTP GET Request.
        /// </summary>
        /// <exception cref="ArgumentNullException"/>
        string GetContent(string url);

        /// <summary>
        /// Retrieves a <see href="http://www.workindenmark.dk">WorkInDenmark</see>'s page via HTTP GET Request as a <see cref="Page"/> object.
        /// </summary>
        /// <exception cref="ArgumentNullException"/>
        /// <exception cref="ArgumentException"/>
        Page GetPage(string runId, ushort pageNumber, WIDCategories category);
    
    }
}

/*
    Author: numbworks@gmail.com
    Last Update: 19.05.2021
*/