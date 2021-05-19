namespace NW.WIDJobs
{
    public interface IPageManager
    {
        string GetContent(string url);
        ushort GetTotalEstimatedPages(uint totalResults);
        uint GetTotalResults(string content);
        string CreateUrl(ushort pageNumber, WIDCategories category);
        Page GetPage(string runId, ushort pageNumber, WIDCategories category);
    }
}

/*
    Author: numbworks@gmail.com
    Last Update: 19.05.2021
*/