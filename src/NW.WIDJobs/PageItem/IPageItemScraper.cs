using System;
using System.Collections.Generic;

namespace NW.WIDJobs
{
    public interface IPageItemScraper
    {

        List<PageItem> Do(Page page);
        List<DateTime> ExtractAndParseCreateDates(string content);
        bool IsWithinRange(DateTime untilDate, List<DateTime> createDates);
        List<PageItem> RemoveOlderThan(List<PageItem> pageItems, DateTime createDate);

    }
}

/*
    Author: numbworks@gmail.com
    Last Update: 19.05.2021
*/