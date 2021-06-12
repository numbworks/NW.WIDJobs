using System;

namespace NW.WIDJobs
{
    /// <summary>Collects all the dependencies required by <see cref="WIDExplorer"/>.</summary>
    public class WIDExplorerComponents
    {

        #region Fields
        #endregion

        #region Properties

        public static Action<string> DefaultLoggingAction { get; }
            = (message) => Console.WriteLine($"[{DateTime.UtcNow.ToString("yyyy-MM-dd HH:mm:ss:fff")}] {message}");
        public static Action<string> DefaultLoggingActionAsciiBanner { get; }
            = (message) => Console.WriteLine($"{message}");

        public Action<string> LoggingAction { get; }
        public Action<string> LoggingActionAsciiBanner { get; }
        public IXPathManager XPathManager { get; }
        public IGetRequestManager GetRequestManager { get; }
        public IPageManager PageManager { get; }
        public IPageScraper PageScraper { get; }
        public IPageItemScraper PageItemScraper { get; }
        public IPageItemExtendedManager PageItemExtendedManager { get; }
        public IPageItemExtendedScraper PageItemExtendedScraper { get; }
        public IRunIdManager RunIdManager { get; }
        public IWIDMetricsManager MetricsManager { get; }
        public IFileManager FileManager { get; }
        public IRepositoryFactory RepositoryFactory { get; }
        public IAsciiBannerManager AsciiBannerManager { get; }
        public IWIDFileNameFactory FileNameFactory { get; }
        public IBulletPointManager BulletPointManager { get; }

        #endregion

        #region Constructors

        /// <summary>Initializes a <see cref="WIDExplorerComponents"/> instance.</summary>
        /// <exception cref="ArgumentNullException"/>
        public WIDExplorerComponents(
            Action<string> loggingAction,
            Action<string> loggingActionAsciiBanner,
            IXPathManager xpathManager,
            IGetRequestManager getRequestManager,
            IPageManager pageManager,
            IPageScraper pageScraper,
            IPageItemScraper pageItemScraper,
            IPageItemExtendedManager pageItemExtendedManager,
            IPageItemExtendedScraper pageItemExtendedScraper,
            IRunIdManager runIdManager,
            IWIDMetricsManager metricsManager,
            IFileManager fileManager,
            IRepositoryFactory repositoryFactory,
            IAsciiBannerManager asciiBannerManager,
            IWIDFileNameFactory fileNameFactory,
            IBulletPointManager bulletPointManager
            )
        {

            Validator.ValidateObject(loggingAction, nameof(loggingAction));
            Validator.ValidateObject(loggingActionAsciiBanner, nameof(loggingActionAsciiBanner));
            Validator.ValidateObject(xpathManager, nameof(xpathManager));
            Validator.ValidateObject(getRequestManager, nameof(getRequestManager));
            Validator.ValidateObject(pageManager, nameof(pageManager));
            Validator.ValidateObject(pageScraper, nameof(pageScraper));
            Validator.ValidateObject(pageItemScraper, nameof(pageItemScraper));
            Validator.ValidateObject(pageItemExtendedManager, nameof(pageItemExtendedManager));
            Validator.ValidateObject(pageItemExtendedScraper, nameof(pageItemExtendedScraper));
            Validator.ValidateObject(runIdManager, nameof(runIdManager));
            Validator.ValidateObject(metricsManager, nameof(metricsManager));
            Validator.ValidateObject(fileManager, nameof(fileManager));
            Validator.ValidateObject(repositoryFactory, nameof(repositoryFactory));
            Validator.ValidateObject(asciiBannerManager, nameof(asciiBannerManager));
            Validator.ValidateObject(fileNameFactory, nameof(fileNameFactory));
            Validator.ValidateObject(bulletPointManager, nameof(bulletPointManager));

            LoggingAction = loggingAction;
            LoggingActionAsciiBanner = loggingActionAsciiBanner;
            XPathManager = xpathManager;
            GetRequestManager = getRequestManager;
            PageManager = pageManager;
            PageScraper = pageScraper;
            PageItemScraper = pageItemScraper;
            PageItemExtendedManager = pageItemExtendedManager;
            PageItemExtendedScraper = pageItemExtendedScraper;
            RunIdManager = runIdManager;
            MetricsManager = metricsManager;
            FileManager = fileManager;
            RepositoryFactory = repositoryFactory;
            AsciiBannerManager = asciiBannerManager;
            FileNameFactory = fileNameFactory;
            BulletPointManager = bulletPointManager;

        }

        /// <summary>Initializes a <see cref="WIDExplorerComponents"/> instance using default parameters.</summary>
        public WIDExplorerComponents()
            : this(
                  DefaultLoggingAction,
                  DefaultLoggingActionAsciiBanner,
                  new XPathManager(),
                  new GetRequestManager(),
                  new PageManager(),
                  new PageScraper(),
                  new PageItemScraper(),
                  new PageItemExtendedManager(),
                  new PageItemExtendedScraper(),
                  new RunIdManager(),
                  new WIDMetricsManager(),
                  new FileManager(),
                  new RepositoryFactory(),
                  new AsciiBannerManager(),
                  new WIDFileNameFactory(),
                  new BulletPointManager()
                  )
        { }

        #endregion

        #region Methods_public
        #endregion

    }
}

/*
    Author: numbworks@gmail.com
    Last Update: 28.05.2021
*/