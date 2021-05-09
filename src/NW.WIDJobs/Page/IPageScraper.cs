namespace NW.WIDJobs
{
    public interface IPageScraper
    {
        ushort GetTotalEstimatedPages(uint totalResults);
        uint GetTotalResults(string content);
    }
}

/*
    Author: numbworks@gmail.com
    Last Update: 09.05.2021
*/