using System;
using System.Collections.Generic;

namespace NW.WIDJobs
{
    /// <summary>A scraper for <see href="http://www.workindenmark.dk">WorkInDenmark</see>'s page items.</summary>
    public interface IPageItemScraper
    {

        /// <summary>
        /// Extracts all the page items from <paramref name="page"/> as <see cref="PageItem"/> objects.
        /// </summary>
        /// <exception cref="ArgumentNullException"/>
        /// <exception cref="Exception"/> 
        List<PageItem> Do(Page page);


        /// <summary>
        /// Extracts all the create dates from <paramref name="content"/> as <see cref="DateTime"/> objects.
        /// </summary>
        /// <exception cref="ArgumentNullException"/>
        /// <exception cref="Exception"/> 
        List<DateTime> ExtractAndParseCreateDates(string content);

        /// <summary>
        /// During an exploration and while evaluating the content of a <see cref="Page"/>, 
        /// this method establishes if the <paramref name="thresholdDate"/> condition is met 
        /// and the exploration should stop ("true" case), or if the exploration 
        /// should continue ("false" case).
        /// </summary>
        /// <exception cref="ArgumentNullException"/>      
        bool IsThresholdConditionMet(DateTime thresholdDate, List<DateTime> createDates);

        /// <summary>
        /// If <see cref="IsThresholdConditionMet"/> returns "True" for a given <see cref="Page"/>, 
        /// the exploration must stop and the unsuitable <see cref="PageItem"/> objects must be removed.
        /// </summary>
        /// <exception cref="ArgumentNullException"/>        
        List<PageItem> RemoveUnsuitable(DateTime thresholdDate, List<PageItem> pageItems);

    }
}

/*
    Author: numbworks@gmail.com
    Last Update: 19.05.2021
*/