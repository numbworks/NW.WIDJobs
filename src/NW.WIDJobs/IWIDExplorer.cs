using NW.WIDJobs.BulletPoints;
using NW.WIDJobs.Explorations;
using NW.WIDJobs.Files;
using NW.WIDJobs.JobPostings;
using NW.WIDJobs.JobPostingsExtended;
using NW.WIDJobs.Metrics;
using System;
using System.Collections.Generic;

namespace NW.WIDJobs
{
    /// <summary>The entry point of this library.</summary>
    public interface IWIDExplorer
    {

        /// <summary>Logs the library's ascii banner.</summary>
        void LogAsciiBanner();

        /// <summary>Returns a collection of pre-labeled <see cref="BulletPoint"/> objects for further machine learning applications.</summary>
        List<BulletPoint> GetPreLabeledBulletPoints();

        /// <summary>Converts the provided <see cref="Exploration"/> to <see cref="MetricCollection"/>.</summary>
        MetricCollection ConvertToMetricCollection(Exploration exploration);

        /// <summary>Converts the provided <see cref="Exploration"/> to JSON format.</summary>
        string ConvertToJson(Exploration exploration);

        /// <summary>Converts the provided <see cref="MetricCollection"/> to JSON format.</summary>
        string ConvertToJson(MetricCollection metricCollection, bool numbersAsPercentages);

        /// <summary>Converts the provided JSON format to a collection of <see cref="JobPosting"/> objects.</summary>
        List<JobPosting> LoadJobPostingsFromJsonFile(IFileInfoAdapter jsonFile);

        /// <summary>Converts the provided JSON format to a collection of <see cref="JobPosting"/> objects.</summary>
        List<JobPosting> LoadJobPostingsFromJsonFile(string filePath);

        /// <summary>Save the provided <see cref="Exploration"/> to a JSON file using a default filename and path.</summary>
        IFileInfoAdapter SaveToJsonFile(Exploration exploration);

        /// <summary>Save the provided <see cref="Exploration"/> to a JSON file.</summary>
        IFileInfoAdapter SaveToJsonFile(Exploration exploration, IFileInfoAdapter jsonFile);

        /// <summary>Save the provided <see cref="MetricCollection"/> to a JSON file using a default filename and path.</summary>
        IFileInfoAdapter SaveToJsonFile(MetricCollection metricCollection, bool numbersAsPercentages);

        /// <summary>Save the provided <see cref="MetricCollection"/> to a JSON file.</summary>
        IFileInfoAdapter SaveToJsonFile(MetricCollection metricCollection, bool numbersAsPercentages, IFileInfoAdapter jsonFile);

        /// <summary>Save the provided <see cref="JobPostingExtended"/> objects to a SQLite database using a default filename and path.</summary>
        IFileInfoAdapter SaveToSQLiteDatabase(List<JobPostingExtended> jobPostingsExtended);

        /// <summary>Save the provided <see cref="JobPostingExtended"/> objects to a SQLite database.</summary>
        IFileInfoAdapter SaveToSQLiteDatabase(List<JobPostingExtended> jobPostingsExtended, IFileInfoAdapter databaseFile, bool deleteAndRecreateDatabase);

        /// <summary>Explores <see href="WorkInDenmark.dk"/> until <paramref name="finalPageNumber"/> using an automatically generated <paramref name="runId"/>.</summary>
        Exploration Explore(ushort finalPageNumber, Stages stage);

        /// <summary>Explores <see href="WorkInDenmark.dk"/> until <paramref name="finalPageNumber"/>.</summary>
        Exploration Explore(string runId, ushort finalPageNumber, Stages stage);

        /// <summary>Explores <see href="WorkInDenmark.dk"/> until <paramref name="thresholdDate"/> is found and using an automatically generated <paramref name="runId"/>.</summary>
        Exploration Explore(DateTime thresholdDate, Stages stage);

        /// <summary>Explores <see href="WorkInDenmark.dk"/> until <paramref name="thresholdDate"/> is found.</summary>
        Exploration Explore(string runId, DateTime thresholdDate, Stages stage);

        /// <summary>Explores <see href="WorkInDenmark.dk"/> until <paramref name="jobPostingId"/> is found and using an automatically generated <paramref name="runId"/>.</summary>
        Exploration Explore(string jobPostingId, Stages stage);

        /// <summary>Explores <see href="WorkInDenmark.dk"/> until <paramref name="jobPostingId"/> is found.</summary>
        Exploration Explore(string runId, string jobPostingId, Stages stage);

        /// <summary>Explores <see href="WorkInDenmark.dk"/> using an automatically generated <paramref name="runId"/>.</summary>
        Exploration ExploreAll(Stages stage);

        /// <summary>Explores <see href="WorkInDenmark.dk"/>.</summary>
        Exploration ExploreAll(string runId, Stages stage);

    }
}

/*
    Author: numbworks@gmail.com
    Last Update: 24.08.2021
*/