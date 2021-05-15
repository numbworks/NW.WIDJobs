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

            Validator.ValidateObject(htmlDocumentAdapter, nameof(htmlDocumentAdapter));

            _htmlDocumentAdapter = htmlDocumentAdapter;

        }
        public XPathManager()
            : this(new HtmlDocumentAdapter()) { }

        // Methods
        public List<string> GetInnerTexts(string html, string xpath)
        {

            Validator.ValidateStringNullOrWhiteSpace(html, nameof(html));
            Validator.ValidateStringNullOrWhiteSpace(xpath, nameof(xpath));

            _htmlDocumentAdapter.LoadHtml(html);
            HtmlNodeCollection nodeCollection = _htmlDocumentAdapter.SelectNodes(xpath);

            List<string> innerTexts = new List<string>();
            if (nodeCollection != null)
                foreach (HtmlNode node in nodeCollection)
                    innerTexts.Add(node.InnerText);

            return innerTexts;

        }
        public string GetInnerText(string html, string xpath, uint valueNr = 0)
            => GetInnerTexts(html, xpath)[(int)valueNr];
        public string TryGetInnerText(string html, string xpath, uint valueNr = 0)
        {

            List<string> innerTexts = GetInnerTexts(html, xpath);
            if (innerTexts.Count == 0)
                return null;

            return innerTexts[(int)valueNr];

        }

        public List<string> GetAttributeValues(string html, string xpath, uint attributeNr = 0)
        {

            Validator.ValidateStringNullOrWhiteSpace(html, nameof(html));
            Validator.ValidateStringNullOrWhiteSpace(xpath, nameof(xpath));

            _htmlDocumentAdapter.LoadHtml(html);
            HtmlNodeCollection nodeCollection = _htmlDocumentAdapter.SelectNodes(xpath);

            List<string> attributeValues = new List<string>();
            if (nodeCollection != null)
                foreach (HtmlNode htmlNode in nodeCollection)
                    attributeValues.Add(htmlNode.Attributes[(int)attributeNr].Value);

            return attributeValues;

        }
        public string GetFirstAttributeValue(string html, string xpath)
            => GetAttributeValues(html, xpath, 0)[0];
        public string TryGetFirstAttributeValue(string html, string xpath)
        {

            List<string> attributeValues = GetAttributeValues(html, xpath, 0);
            if (attributeValues.Count == 0)
                return null;

            return attributeValues[0];

        }

    }
}

/*
    Author: numbworks@gmail.com
    Last Update: 13.05.2021
*/