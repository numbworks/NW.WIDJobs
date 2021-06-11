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

        /// <summary>
        /// Try to extract a <see cref="PageItem"/> from a <paramref name="content"/> intended for a <see cref="PageItemExtended"/> object or returns null.
        /// </summary>
        /// <exception cref="ArgumentNullException"/>
        /// <exception cref="Exception"/> 
        PageItem TryExtractPageItem(string runId, ushort pageNumber, ushort pageItemNumber, string content);

        /// <summary>
        /// Try to extract a <see cref="PageItem"/> from a <paramref name="content"/> intended for a <see cref="PageItemExtended"/> object or returns null.
        /// <para>Dummy values will be assigned to <see cref="PageItem.RunId"/>, <see cref="PageItem.PageNumber"/> and <see cref="PageItem.PageItemNumber"/>.</para>
        /// </summary>
        /// <exception cref="ArgumentNullException"/>
        /// <exception cref="Exception"/> 
        PageItem TryExtractPageItem(string content);

    }
}

/*
    Author: numbworks@gmail.com
    Last Update: 12.06.2021
*/