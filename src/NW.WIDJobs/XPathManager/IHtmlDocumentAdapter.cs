using HtmlAgilityPack;

namespace NW.WIDJobs
{
    public interface IHtmlDocumentAdapter
    {
        void LoadHtml(string html);
        HtmlNodeCollection SelectNodes(string xpath);
    }
}

/*
    Author: numbworks@gmail.com
    Last Update: 06.05.2021
*/