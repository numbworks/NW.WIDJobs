using System;
using NW.WIDJobs.AsciiBanner;
using NW.WIDJobs.Classification;
using NW.WIDJobs.Database;
using NW.WIDJobs.Filenames;
using NW.WIDJobs.Files;
using NW.WIDJobs.HttpRequests;
using NW.WIDJobs.JobPages;
using NW.WIDJobs.JobPostings;
using NW.WIDJobs.JobPostingsExtended;
using NW.WIDJobs.Metrics;
using NW.WIDJobs.Runs;
using NW.WIDJobs.Validation;
using NW.WIDJobs.XPath;
using NW.WIDJobs.Formatting;
using NW.NGramTextClassification;

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
        public static Func<DateTime> DefaultNowFunction { get; } = () => DateTime.Now;
        public static Action<string> DefaultTextClassifierLoggingAction { get; } 
            = (message) => { };
        public static bool DefaultPredictJobPostingLanguage { get; } = WIDExplorerSettings.DefaultPredictJobPostingLanguage;
        public static bool DefaultPredictBulletPointType { get; } = WIDExplorerSettings.DefaultPredictBulletPointType;

        public Action<string> LoggingAction { get; }
        public Action<string> LoggingActionAsciiBanner { get; }
        public IXPathManager XPathManager { get; }
        public IGetRequestManager GetRequestManager { get; }
        public IJobPageDeserializer JobPageDeserializer { get; }
        public IJobPageManager JobPageManager { get; }
        public IJobPostingDeserializer JobPostingDeserializer { get; }
        public IJobPostingManager JobPostingManager { get; }
        public IJobPostingExtendedDeserializer JobPostingExtendedDeserializer { get; }
        public IJobPostingExtendedManager JobPostingExtendedManager { get; }
        public IRunIdManager RunIdManager { get; }
        public IMetricCollectionManager MetricCollectionManager { get; }
        public IFileManager FileManager { get; }
        public IRepositoryFactory RepositoryFactory { get; }
        public IAsciiBannerManager AsciiBannerManager { get; }
        public IFilenameFactory FilenameFactory { get; }
        public IClassificationManager ClassificationManager { get; }
        public Func<DateTime> NowFunction { get; }
        public IFormatter Formatter { get; }
        public Action<string> TextClassifierLoggingAction { get; }

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a <see cref="WIDExplorerComponents"/> instance.
        /// <para>If we are interested into the <see cref="ITextClassifier"/> log, we define <paramref name="textClassifierLoggingAction"/> equal to <paramref name="loggingAction"/>, otherwise we can use <see cref="DefaultTextClassifierLoggingAction"/> that does nothing.</para>
        /// </summary>
        /// <exception cref="ArgumentNullException"/>
        public WIDExplorerComponents(
            Action<string> loggingAction,
            Action<string> loggingActionAsciiBanner,
            IXPathManager xpathManager,
            IGetRequestManager getRequestManager,
            IJobPageDeserializer jobPageDeserializer,
            IJobPageManager jobPageManager,
            IJobPostingDeserializer jobPostingDeserializer,
            IJobPostingManager jobPostingManager,
            IJobPostingExtendedDeserializer jobPostingExtendedDeserializer,
            IJobPostingExtendedManager jobPostingExtendedManager,
            IRunIdManager runIdManager,
            IMetricCollectionManager metricCollectionManager,
            IFileManager fileManager,
            IRepositoryFactory repositoryFactory,
            IAsciiBannerManager asciiBannerManager,
            IFilenameFactory filenameFactory,
            IClassificationManager classificationManager,
            Func<DateTime> nowFunction,
            IFormatter formatter,
            Action<string> textClassifierLoggingAction
            )
        {

            Validator.ValidateObject(loggingAction, nameof(loggingAction));
            Validator.ValidateObject(loggingActionAsciiBanner, nameof(loggingActionAsciiBanner));
            Validator.ValidateObject(xpathManager, nameof(xpathManager));
            Validator.ValidateObject(getRequestManager, nameof(getRequestManager));
            Validator.ValidateObject(jobPageDeserializer, nameof(jobPageDeserializer));
            Validator.ValidateObject(jobPageManager, nameof(jobPageManager));
            Validator.ValidateObject(jobPostingDeserializer, nameof(jobPostingDeserializer));
            Validator.ValidateObject(jobPostingManager, nameof(jobPostingManager));
            Validator.ValidateObject(jobPostingExtendedDeserializer, nameof(jobPostingExtendedDeserializer));
            Validator.ValidateObject(jobPostingExtendedManager, nameof(jobPostingExtendedManager));
            Validator.ValidateObject(runIdManager, nameof(runIdManager));
            Validator.ValidateObject(metricCollectionManager, nameof(metricCollectionManager));
            Validator.ValidateObject(fileManager, nameof(fileManager));
            Validator.ValidateObject(repositoryFactory, nameof(repositoryFactory));
            Validator.ValidateObject(asciiBannerManager, nameof(asciiBannerManager));
            Validator.ValidateObject(filenameFactory, nameof(filenameFactory));
            Validator.ValidateObject(classificationManager, nameof(classificationManager));
            Validator.ValidateObject(nowFunction, nameof(nowFunction));
            Validator.ValidateObject(formatter, nameof(formatter));
            Validator.ValidateObject(textClassifierLoggingAction, nameof(textClassifierLoggingAction));

            LoggingAction = loggingAction;
            LoggingActionAsciiBanner = loggingActionAsciiBanner;
            XPathManager = xpathManager;
            GetRequestManager = getRequestManager;
            JobPageDeserializer = jobPageDeserializer;
            JobPageManager = jobPageManager;
            JobPostingDeserializer = jobPostingDeserializer;
            JobPostingManager = jobPostingManager;
            JobPostingExtendedDeserializer = jobPostingExtendedDeserializer;
            JobPostingExtendedManager = jobPostingExtendedManager;
            RunIdManager = runIdManager;
            MetricCollectionManager = metricCollectionManager;
            FileManager = fileManager;
            RepositoryFactory = repositoryFactory;
            AsciiBannerManager = asciiBannerManager;
            FilenameFactory = filenameFactory;
            ClassificationManager = classificationManager;
            NowFunction = nowFunction;
            Formatter = formatter;
            TextClassifierLoggingAction = textClassifierLoggingAction;

        }

        /// <summary>Initializes a <see cref="WIDExplorerComponents"/> instance using <paramref name="settings"/> and default parameters.</summary>
        public WIDExplorerComponents(WIDExplorerSettings settings)
            : this(
                  DefaultLoggingAction,
                  DefaultLoggingActionAsciiBanner,
                  new XPathManager(),
                  new GetRequestManager(),
                  new JobPageDeserializer(),
                  new JobPageManager(),
                  new JobPostingDeserializer(settings.PredictJobPostingLanguage, settings.PredictBulletPointType),
                  new JobPostingManager(),
                  new JobPostingExtendedDeserializer(),
                  new JobPostingExtendedManager(),
                  new RunIdManager(),
                  new MetricCollectionManager(),
                  new FileManager(),
                  new RepositoryFactory(),
                  new AsciiBannerManager(),
                  new FilenameFactory(),
                  new ClassificationManager(DefaultTextClassifierLoggingAction),
                  DefaultNowFunction,
                  new Formatter(),
                  DefaultTextClassifierLoggingAction
                  )
        { }

        /// <summary>Initializes a <see cref="WIDExplorerComponents"/> instance using a default <see cref="WIDExplorerSettings"/> and default parameters.</summary>
        public WIDExplorerComponents()
            : this(new WIDExplorerSettings()) { }

        #endregion

        #region Methods_public
        #endregion

    }
}

/*
    Author: numbworks@gmail.com
    Last Update: 08.10.2021
*/