using System.Collections.Generic;

namespace NW.WIDJobs
{
    public interface IXPathManager
    {

        /// <summary>
        /// Returns all the inner texts for the provided XPath expression.
        /// </summary>
        List<string> GetInnerTexts(string html, string xpath);

        /// <summary>
        /// Returns the inner text for the provided XPath expression.
        /// </summary>
        string GetInnerText(string html, string xpath, uint valueNr = 0);

        /// <summary>
        /// Returns the InnerText for the provided XPath expression or null.
        /// </summary>
        string TryGetInnerText(string html, string xpath, uint valueNr = 0);


        /// <summary>
        /// Returns all the attribute values for the provided XPath expression.
        /// <para>Expects XPath expressions like '//tr[contains(@id, 'subrow-')]/@*' and returns the equivalent of //tr[contains(@id, 'subrow-')]/@*[2].</para>
        /// <para>This is a workaround for the lack of support by HTMLAgilityPack of expressions like the second one.</para>
        /// </summary>
        List<string> GetAttributeValues(string html, string xpath, uint attributeNr = 0);

        /// <summary>
        /// Returns the first attribute value for the provided XPath expression.
        /// <para>This method expects XPath expressions like: '//a[contains(., 'complete')]/@href'.</para>
        /// </summary>
        string GetFirstAttributeValue(string html, string xpath);

        /// <summary>
        /// Returns the first attribute value for the provided XPath expression or null.
        /// <para>This method expects XPath expressions like: '//a[contains(., 'complete')]/@href'.</para>
        /// </summary>
        string TryGetFirstAttributeValue(string html, string xpath);

    }
}

/*
    Author: numbworks@gmail.com
    Last Update: 13.05.2021
*/