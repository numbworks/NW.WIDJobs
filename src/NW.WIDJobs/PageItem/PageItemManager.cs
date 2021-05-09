using System;
using System.Collections;
using System.Collections.Generic;

namespace NW.WIDJobs
{
    public class PageItemManager
    {

        // Fields
        private IGetRequestManager _getRequestManager;
        private IPageItemScraper _pageScraper;

        // Properties
        // Constructors
        public PageItemManager(IGetRequestManager getRequestManager, IPageItemScraper pageItemScraper)
        {

            Validator.ValidateObject(getRequestManager, nameof(getRequestManager));
            Validator.ValidateObject(pageItemScraper, nameof(pageItemScraper));

            _getRequestManager = getRequestManager;
            _pageScraper = pageItemScraper;

        }
        public PageItemManager()
            : this(new GetRequestManager(), new PageItemScraper()) { }

        // Methods (public)
        // Methods (private)

    }
}

/*
    Author: numbworks@gmail.com
    Last Update: 09.05.2021
*/