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
        public IJobPageManager JobPageManager { get; }
        public IJobPageDeserializer JobPageDeserializer { get; }
        public IJobPostingDeserializer JobPostingDeserializer { get; }
        public IJobPostingExtendedManager JobPostingExtendedManager { get; }
        public IJobPostingExtendedDeserializer JobPostingExtendedDeserializer { get; }
        public IRunIdManager RunIdManager { get; }
        public IMetricCollectionManager MetricCollectionManager { get; }
        public IFileManager FileManager { get; }
        public IRepositoryFactory RepositoryFactory { get; }
        public IAsciiBannerManager AsciiBannerManager { get; }
        public IFilenameFactory FilenameFactory { get; }
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
            IJobPageManager jobPageManager,
            IJobPageDeserializer jobPageDeserializer,
            IJobPostingDeserializer jobPostingDeserializer,
            IJobPostingExtendedManager jobPostingExtendedManager,
            IJobPostingExtendedDeserializer jobPostingExtendedDeserializer,
            IRunIdManager runIdManager,
            IMetricCollectionManager metricCollectionManager,
            IFileManager fileManager,
            IRepositoryFactory repositoryFactory,
            IAsciiBannerManager asciiBannerManager,
            IFilenameFactory filenameFactory,
            IBulletPointManager bulletPointManager
            )
        {

            Validator.ValidateObject(loggingAction, nameof(loggingAction));
            Validator.ValidateObject(loggingActionAsciiBanner, nameof(loggingActionAsciiBanner));
            Validator.ValidateObject(xpathManager, nameof(xpathManager));
            Validator.ValidateObject(getRequestManager, nameof(getRequestManager));
            Validator.ValidateObject(jobPageManager, nameof(jobPageManager));
            Validator.ValidateObject(jobPageDeserializer, nameof(jobPageDeserializer));
            Validator.ValidateObject(jobPostingDeserializer, nameof(jobPostingDeserializer));
            Validator.ValidateObject(jobPostingExtendedManager, nameof(jobPostingExtendedManager));
            Validator.ValidateObject(jobPostingExtendedDeserializer, nameof(jobPostingExtendedDeserializer));
            Validator.ValidateObject(runIdManager, nameof(runIdManager));
            Validator.ValidateObject(metricCollectionManager, nameof(metricCollectionManager));
            Validator.ValidateObject(fileManager, nameof(fileManager));
            Validator.ValidateObject(repositoryFactory, nameof(repositoryFactory));
            Validator.ValidateObject(asciiBannerManager, nameof(asciiBannerManager));
            Validator.ValidateObject(filenameFactory, nameof(filenameFactory));
            Validator.ValidateObject(bulletPointManager, nameof(bulletPointManager));

            LoggingAction = loggingAction;
            LoggingActionAsciiBanner = loggingActionAsciiBanner;
            XPathManager = xpathManager;
            GetRequestManager = getRequestManager;
            JobPageManager = jobPageManager;
            JobPageDeserializer = jobPageDeserializer;
            JobPostingDeserializer = jobPostingDeserializer;
            JobPostingExtendedManager = jobPostingExtendedManager;
            JobPostingExtendedDeserializer = jobPostingExtendedDeserializer;
            RunIdManager = runIdManager;
            MetricCollectionManager = metricCollectionManager;
            FileManager = fileManager;
            RepositoryFactory = repositoryFactory;
            AsciiBannerManager = asciiBannerManager;
            FilenameFactory = filenameFactory;
            BulletPointManager = bulletPointManager;

        }

        /// <summary>Initializes a <see cref="WIDExplorerComponents"/> instance using default parameters.</summary>
        public WIDExplorerComponents()
            : this(
                  DefaultLoggingAction,
                  DefaultLoggingActionAsciiBanner,
                  new XPathManager(),
                  new GetRequestManager(),
                  new JobPageManager(),
                  new JobPageDeserializer(),
                  new JobPostingDeserializer(),
                  new JobPostingExtendedManager(),
                  new JobPostingExtendedDeserializer(),
                  new RunIdManager(),
                  new MetricCollectionManager(),
                  new FileManager(),
                  new RepositoryFactory(),
                  new AsciiBannerManager(),
                  new FilenameFactory(),
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
    Last Update: 10.08.2021
*/