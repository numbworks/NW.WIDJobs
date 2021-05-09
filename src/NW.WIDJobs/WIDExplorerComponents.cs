using System;

namespace NW.WIDJobs
{
    public class WIDExplorerComponents
    {

        // Fields
        // Properties
        public static Action<string> DefaultLoggingAction { get; }
            = (message) => Console.WriteLine($"[{DateTime.UtcNow.ToString("yyyy-MM-dd HH:mm:ss:fff")}] {message}");

        public Action<string> LoggingAction { get; }
        public IXPathManager XPathManager { get; }
        public IGetRequestManager GetRequestManager { get; }
        public IPageManager PageManager { get; }
        public IPageScraper PageScraper { get; }
        public IPageItemScraper PageItemScraper { get; }
        public IPageItemExtendedManager PageItemExtendedManager { get; }
        public IPageItemExtendedScraper PageItemExtendedScraper { get; }
        public IRunIdManager RunIdManager { get; }
        public IBulletPointManager BulletPointManager { get; }

        // Constructors	
        public WIDExplorerComponents(
            Action<string> loggingAction, 
            IXPathManager xpathManager, 
            IGetRequestManager getRequestManager,
            IPageManager pageManager,
            IPageScraper pageScraper,
            IPageItemScraper pageItemScraper,
            IPageItemExtendedManager pageItemExtendedManager,
            IPageItemExtendedScraper pageItemExtendedScraper,
            IRunIdManager runIdManager,
            IBulletPointManager bulletPointManager
            )
        {

            Validator.ValidateObject(loggingAction, nameof(loggingAction));
            Validator.ValidateObject(xpathManager, nameof(xpathManager));
            Validator.ValidateObject(getRequestManager, nameof(getRequestManager));
            Validator.ValidateObject(pageManager, nameof(pageManager));
            Validator.ValidateObject(pageScraper, nameof(pageScraper));
            Validator.ValidateObject(pageItemScraper, nameof(pageItemScraper));
            Validator.ValidateObject(pageItemExtendedManager, nameof(pageItemExtendedManager));
            Validator.ValidateObject(pageItemExtendedScraper, nameof(pageItemExtendedScraper));
            Validator.ValidateObject(runIdManager, nameof(runIdManager));
            Validator.ValidateObject(bulletPointManager, nameof(bulletPointManager));

            LoggingAction = loggingAction;
            XPathManager = xpathManager;
            GetRequestManager = getRequestManager;
            PageManager = pageManager;
            PageScraper = pageScraper;
            PageItemScraper = pageItemScraper;
            PageItemExtendedManager = pageItemExtendedManager;
            PageItemExtendedScraper = pageItemExtendedScraper;
            RunIdManager = runIdManager;
            BulletPointManager = bulletPointManager;

        }
        public WIDExplorerComponents()
            : this(
                  DefaultLoggingAction,
                  new XPathManager(), 
                  new GetRequestManager(),
                  new PageManager(),
                  new PageScraper(),
                  new PageItemScraper(),
                  new PageItemExtendedManager(),
                  new PageItemExtendedScraper(),
                  new RunIdManager(),
                  new BulletPointManager()
                  ) { }

        // Methods

    }
}

/*
    Author: numbworks@gmail.com
    Last Update: 09.05.2021
*/