using HtmlAgilityPack;

namespace NW.WIDJobs
{
    /// <summary>Adapter for HtmlAgilityPack's <see cref="HtmlDocument"/>.</summary>
    public interface IHtmlDocumentAdapter
    {

        /// <summary>
        /// Loads the HTML document from <paramref name="html"/>.
        /// </summary>
        void LoadHtml(string html);

        /// <summary>
        /// Selects a list of nodes matching <paramref name="xpath"/>.
        /// </summary>        
        HtmlNodeCollection SelectNodes(string xpath);
    
    }
}

/*
    Author: numbworks@gmail.com
    Last Update: 06.05.2021
*/