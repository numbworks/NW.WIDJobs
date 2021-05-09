using System.Collections.Generic;

namespace NW.WIDJobs
{
    public class BulletPointScraper : IBulletPointScraper
    {

        // Fields
        private IXPathManager _xpathManager;

        // Properties
        // Constructors
        public BulletPointScraper(IXPathManager xpathManager)
        {

            Validator.ValidateObject(xpathManager, nameof(xpathManager));

            _xpathManager = xpathManager;

        }
        public BulletPointScraper()
            : this(new XPathManager()) { }

        // Methods (public)
        public HashSet<string> TryExtract(string description)
        {

            Validator.ValidateStringNullOrWhiteSpace(description, nameof(description));

            /* ... */

            return new HashSet<string>();

        }

        // Methods (private)

    }
}

/*
    Author: numbworks@gmail.com
    Last Update: 09.05.2021
*/