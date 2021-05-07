using HtmlAgilityPack;

namespace NW.WIDJobs
{
    public class HtmlDocumentAdapter : IHtmlDocumentAdapter
    {

        // Fields
        private HtmlDocument _htmlDocument;

        // Properties
        // Constructors
        public HtmlDocumentAdapter()
        {

            _htmlDocument = new HtmlDocument();

        }

        // Methods (public)
        public void LoadHtml(string html)
            => _htmlDocument.LoadHtml(html);
        public HtmlNodeCollection SelectNodes(string xpath)
            => _htmlDocument.DocumentNode.SelectNodes(xpath);

        // Methods (private)

    }
}

/*
    Author: numbworks@gmail.com
    Last Update: 06.05.2021
*/