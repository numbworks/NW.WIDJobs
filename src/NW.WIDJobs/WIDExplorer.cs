using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Text;
using System.Threading;

namespace NW.WIDJobs
{

    public class WIDExplorer
    {

        // Fields
        private WIDExplorerComponents _components;
        private WIDExplorerSettings _settings;

        // Properties
        // Constructors
        public WIDExplorer
            (WIDExplorerComponents components, WIDExplorerSettings settings)
        {

            Validator.ValidateObject(components, nameof(components));
            Validator.ValidateObject(settings, nameof(settings));

            _components = components;
            _settings = settings;

        }
        public WIDExplorer()
            : this(new WIDExplorerComponents(), new WIDExplorerSettings()) { }

        // Methods (public)
        public uint GetTotalResults()
        {

            string url = _components.PageManager.CreateUrl(1);
            string content = _components.PageManager.GetContent(url);
            uint totalResults = _components.PageManager.GetTotalResults(content);

            return totalResults;

        }
        public ushort GetTotalEstimatedPages()
        {

            uint totalResults = GetTotalResults();
            ushort totalEstimatedPages = _components.PageManager.GetTotalEstimatedPages(totalResults);

            return totalEstimatedPages;

        }

        public List<Page> GetPages
            (string runId, ushort initialPageNumber, ushort finalPageNumber, Categories category)
        {

            Validator.ValidateStringNullOrWhiteSpace(runId, nameof(runId));
            Validator.ThrowIfLessThanOne(initialPageNumber, nameof(initialPageNumber));
            Validator.ThrowIfLessThanOne(finalPageNumber, nameof(finalPageNumber));

            List<Page> pages = new List<Page>();

            /* ... */

            return pages;

        }
        public List<Page> GetPages
            (string runId, ushort initialPageNumber, ushort finalPageNumber)
        {

            Validator.ValidateStringNullOrWhiteSpace(runId, nameof(runId));
            Validator.ThrowIfLessThanOne(initialPageNumber, nameof(initialPageNumber));
            Validator.ThrowIfLessThanOne(finalPageNumber, nameof(finalPageNumber));

            List<Page> pages = new List<Page>();

            /* ... */

            return pages;

        }
        public List<Page> GetPages
            (ushort initialPageNumber, ushort finalPageNumber, Categories category)
                => GetPages(_components.RunIdManager.Create(DateTime.Now), initialPageNumber, finalPageNumber, category);
        public List<Page> GetPages
            (ushort initialPageNumber, ushort finalPageNumber)
                => GetPages(_components.RunIdManager.Create(DateTime.Now), initialPageNumber, finalPageNumber);

        public List<PageItem> GetPageItems
            (string runId, ushort initialPageNumber, ushort finalPageNumber)
        {

            List<Page> pages = GetPages(runId, initialPageNumber, finalPageNumber);
            List<PageItem> pageItems = new List<PageItem>();

            /* ... */

            return pageItems;

        }
        public List<PageItem> GetPageItems
            (ushort initialPageNumber, ushort finalPageNumber)
                => GetPageItems(_components.RunIdManager.Create(DateTime.Now), initialPageNumber, finalPageNumber);
        public List<PageItem> GetPageItems(string runId, DateTime untilDate)
        {

            // Validate: untilDate can't be later than DateTime.Now
            
            List<PageItem> pageItems = new List<PageItem>();

            /* ... */

            return pageItems;

        }
        public List<PageItem> GetPageItems(DateTime untilDate)
            => GetPageItems(_components.RunIdManager.Create(DateTime.Now), untilDate);

        public List<PageItemExtended> GetPageItemsExtended
            (string runId, ushort initialPageNumber, ushort finalPageNumber)
        {

            List<PageItem> pageItems = GetPageItems(runId, initialPageNumber, finalPageNumber);
            List<PageItemExtended> pageItemsExtended = new List<PageItemExtended>();

            /* ... */

            return pageItemsExtended;

        }
        public List<PageItemExtended> GetPageItemsExtended
            (ushort initialPageNumber, ushort finalPageNumber)
                => GetPageItemsExtended(_components.RunIdManager.Create(DateTime.Now), initialPageNumber, finalPageNumber);
        public List<PageItemExtended> GetPageItemsExtended(string runId, DateTime untilDate)
        {

            // Validate: untilDate can't be later than DateTime.Now

            List<PageItemExtended> pageItemsExtended = new List<PageItemExtended>();

            /* ... */

            return pageItemsExtended;

        }
        public List<PageItemExtended> GetPageItemsExtended(DateTime untilDate)
            => GetPageItemsExtended(_components.RunIdManager.Create(DateTime.Now), untilDate);

        // Methods (private)
        private void ConditionallySleep
            (ushort i, ushort parallelRequests, int pauseBetweenRequestsMs)
        {

            // Do a pause of x each y requests
            // i != 0, because 0 % x = 0...
            if (i != 0 && i % parallelRequests == 0)
                Thread.Sleep(pauseBetweenRequestsMs);

        }

    }
}

/*
    Author: numbworks@gmail.com
    Last Update: 16.05.2021
*/