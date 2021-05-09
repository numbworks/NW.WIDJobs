using System.Collections.Generic;

namespace NW.WIDJobs
{
    public interface IPageItemScraper
    {
        List<PageItem> Do(Page page);
    }
}

/*
    Author: numbworks@gmail.com
    Last Update: 09.05.2021
*/