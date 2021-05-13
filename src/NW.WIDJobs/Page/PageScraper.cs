namespace NW.WIDJobs
{
    public class PageScraper : IPageScraper
    {

        // Fields
        private IXPathManager _xpathManager;

        // Properties
        // Constructors
        public PageScraper(IXPathManager xpathManager)
        {

            Validator.ValidateObject(xpathManager, nameof(xpathManager));

            _xpathManager = xpathManager;

        }
        public PageScraper() 
            : this (new XPathManager()) { }

        // Methods (public)
        public uint GetTotalResults(string content)
        {

            Validator.ValidateStringNullOrWhiteSpace(content, nameof(content));

            string xpath = "//div[@class='col-sm-6']//strong//strong";

            string totalResults = _xpathManager.GetInnerText(content, xpath);

            return uint.Parse(totalResults);

        }

        // Methods (private)

    }
}

/*
    Author: numbworks@gmail.com
    Last Update: 09.05.2021
*/