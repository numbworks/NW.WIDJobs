using System.Collections.Generic;

namespace NW.WIDJobs
{
    public interface IXPathManager
    {

        /// <summary>
        /// It returns all the InnerTexts found for the provided XPath expression.
        /// </summary>
        List<string> GetInnerTexts(string html, string xpath);

        /// <summary>
        /// It returns the InnerText for the provided XPath expression.
        /// </summary>
        string GetInnerText(string html, string xpath, uint valueNr = 0);

        /// <summary>
        /// This method expects XPath expressions like '//tr[contains(@id, 'subrow-')]/@*' and returns the equivalent of //tr[contains(@id, 'subrow-')]/@*[2].
        /// This is a workaround for the lack of support by HTMLAgilityPack of expressions like the second one.
        /// </summary>
        List<string> GetAttributeValues(string html, string xpath, uint attributeNr = 0);

        /// <summary>
        /// This method expects XPath expressions like: '//a[contains(., 'complete')]/@href'.
        /// </summary>
        string GetFirstAttributeValue(string html, string xpath);

    }
}

/*
    Author: numbworks@gmail.com
    Last Update: 06.05.2021
*/