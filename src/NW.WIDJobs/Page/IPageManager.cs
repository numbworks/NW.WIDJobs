namespace NW.WIDJobs
{
    public interface IPageManager
    {
        string GetContent(string url);
        Page GetPage(string runId, ushort pageNumber);
        ushort GetTotalEstimatedPages(uint totalResults);
        uint GetTotalResults(string content);
        string CreateUrl(ushort pageNumber);
        string CreateUrl(ushort pageNumber, Categories category);
    }
}

/*
    Author: numbworks@gmail.com
    Last Update: 16.05.2021
*/