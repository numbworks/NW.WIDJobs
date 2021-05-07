using System.Collections.Generic;
using HtmlAgilityPack;

namespace NW.WIDJobs
{
    public class XPathManager : IXPathManager
    {

        // Fields
        private IHtmlDocumentAdapter _htmlDocumentAdapter;

        // Properties
        // Constructors
        public XPathManager(IHtmlDocumentAdapter htmlDocumentAdapter)
        {

            // Validation

            _htmlDocumentAdapter = htmlDocumentAdapter;

        }
        public XPathManager()
            : this(new HtmlDocumentAdapter()) { }

        // Methods
        public List<string> GetInnerTexts(string html, string xpath)
        {

            // Validation

            _htmlDocumentAdapter.LoadHtml(html);
            HtmlNodeCollection nodeCollection = _htmlDocumentAdapter.SelectNodes(xpath);

            // if (nodeCollection == null)

            List<string> innerTexts = new List<string>();
            if (nodeCollection != null)
                foreach (HtmlNode node in nodeCollection)
                    innerTexts.Add(node.InnerText);

            return innerTexts;

        }
        public string GetInnerText(string html, string xpath, uint valueNr = 0)
            => GetInnerTexts(html, xpath)[(int)valueNr];

        public List<string> GetAttributeValues(string html, string xpath, uint attributeNr = 0)
        {

            // Validation

            _htmlDocumentAdapter.LoadHtml(html);
            HtmlNodeCollection nodeCollection = _htmlDocumentAdapter.SelectNodes(xpath);

            // if (nodeCollection == null)

            List<string> attributeValues = new List<string>();
            if (nodeCollection != null)
                foreach (HtmlNode htmlNode in nodeCollection)
                    attributeValues.Add(htmlNode.Attributes[(int)attributeNr].Value);

            return attributeValues;

        }
        public string GetFirstAttributeValue(string html, string xpath)
            => GetAttributeValues(html, xpath, 0)[0];

    }
}

/*
    Author: numbworks@gmail.com
    Last Update: 06.05.2021
*/