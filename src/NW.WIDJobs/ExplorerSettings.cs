namespace NW.WIDJobs
{
    public class ExplorerSettings
    {

        // Fields
        // Properties
        public static ushort DefaultResultsPerPage = 10;
        public static string DefaultWebsiteName = "WorkInDenmark.dk";
        public static ushort DefaultParallelRequests = 3;
        public static uint DefaultPauseBetweenRequestsMs = 25000; // 25 seconds

        public string WebsiteName { get; }
        public ushort ResultsPerPage { get; }
        public ushort ParallelRequests { get; }
        public uint PauseBetweenRequestsMs { get; }

        // Constructors
        public ExplorerSettings(
            string websiteName,
            ushort resultsPerPage,
            ushort parallelRequests,
            uint pauseBetweenRequestsMs
            )
        {

            WebsiteName = websiteName;
            ResultsPerPage = resultsPerPage;
            ParallelRequests = parallelRequests;
            PauseBetweenRequestsMs = pauseBetweenRequestsMs;

        }
        public ExplorerSettings()
            : this(
                  DefaultWebsiteName,
                  DefaultResultsPerPage,
                  DefaultParallelRequests,
                  DefaultPauseBetweenRequestsMs)
        { }

        // Methods

    }
}

/*
    Author: numbworks@gmail.com
    Last Update: 05.05.2021
*/