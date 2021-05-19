using System;
using System.Collections.Generic;

namespace NW.WIDJobs
{
    public interface IPageItemScraper
    {

        List<PageItem> Do(Page page);
        List<DateTime> ExtractAndParseCreateDates(string content);

    }
}

/*
    Author: numbworks@gmail.com
    Last Update: 19.05.2021
*/