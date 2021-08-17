using HtmlAgilityPack;

namespace NW.WIDJobs.XPath
{
    /// <inheritdoc cref="IHtmlDocumentAdapter"/>
    public class HtmlDocumentAdapter : IHtmlDocumentAdapter
    {

        #region Fields

        private HtmlDocument _htmlDocument;

        #endregion

        #region Properties
        #endregion

        #region Constructors

        /// <summary>Initializes a <see cref="HtmlDocumentAdapter"/> instance.</summary>
        public HtmlDocumentAdapter()
        {

            _htmlDocument = new HtmlDocument();

        }

        #endregion

        #region Methods_public

        public void LoadHtml(string html)
            => _htmlDocument.LoadHtml(html);
        public HtmlNodeCollection SelectNodes(string xpath)
            => _htmlDocument.DocumentNode.SelectNodes(xpath);

        #endregion

    }
}

/*
    Author: numbworks@gmail.com
    Last Update: 06.05.2021
*/