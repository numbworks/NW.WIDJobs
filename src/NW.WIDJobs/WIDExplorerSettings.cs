namespace NW.WIDJobs
{
    public class WIDExplorerSettings
    {

        // Fields
        // Properties
        public static string DefaultWebsiteName = "WorkInDenmark.dk";
        public static ushort DefaultResultsPerPage = 10;
        public static ushort DefaultParallelRequests = 3;
        public static uint DefaultPauseBetweenRequestsMs = 25000; // 25 seconds

        public ushort ResultsPerPage { get; }
        public ushort ParallelRequests { get; }
        public uint PauseBetweenRequestsMs { get; }

        // Constructors
        public WIDExplorerSettings(
            ushort resultsPerPage,
            ushort parallelRequests,
            uint pauseBetweenRequestsMs
            )
        {

            Validator.ThrowIfLessThanOne(resultsPerPage, nameof(resultsPerPage));

            ResultsPerPage = resultsPerPage;
            ParallelRequests = parallelRequests;
            PauseBetweenRequestsMs = pauseBetweenRequestsMs;

        }
        public WIDExplorerSettings()
            : this(
                  DefaultResultsPerPage,
                  DefaultParallelRequests,
                  DefaultPauseBetweenRequestsMs) { }

        // Methods

    }
}

/*
    Author: numbworks@gmail.com
    Last Update: 08.05.2021
*/