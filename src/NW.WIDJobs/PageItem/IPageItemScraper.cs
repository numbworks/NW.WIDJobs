using System;
using System.Collections.Generic;

namespace NW.WIDJobs
{
    public interface IPageItemScraper
    {

        List<PageItem> Do(Page page);
        List<DateTime> ExtractAndParseCreateDates(string content);
        bool IsThresholdConditionMet(DateTime thresholdDate, List<DateTime> createDates);
        List<PageItem> RemoveUnsuitable(DateTime thresholdDate, List<PageItem> pageItems);

    }
}

/*
    Author: numbworks@gmail.com
    Last Update: 19.05.2021
*/