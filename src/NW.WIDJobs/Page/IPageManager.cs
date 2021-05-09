namespace NW.WIDJobs
{
    public interface IPageManager
    {
        string GetContent(string url);
        Page GetPage(string runId, ushort pageNumber);
        ushort GetTotalEstimatedPages(uint totalResults);
        uint GetTotalResults();
        uint GetTotalResults(string content);
    }
}

/*
    Author: numbworks@gmail.com
    Last Update: 09.05.2021
*/