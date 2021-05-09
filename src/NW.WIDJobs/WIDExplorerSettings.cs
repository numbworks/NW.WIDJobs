namespace NW.WIDJobs
{
    public class WIDExplorerSettings
    {

        // Fields
        // Properties
        public static ushort DefaultParallelRequests = 3;
        public static uint DefaultPauseBetweenRequestsMs = 25000; // 25 seconds

        public ushort ParallelRequests { get; }
        public uint PauseBetweenRequestsMs { get; }

        // Constructors
        public WIDExplorerSettings(
            ushort parallelRequests,
            uint pauseBetweenRequestsMs
            )
        {

            Validator.ThrowIfLessThanOne(parallelRequests, nameof(parallelRequests));

            ParallelRequests = parallelRequests;
            PauseBetweenRequestsMs = pauseBetweenRequestsMs;

        }
        public WIDExplorerSettings()
            : this(
                  DefaultParallelRequests,
                  DefaultPauseBetweenRequestsMs) { }

        // Methods

    }
}

/*
    Author: numbworks@gmail.com
    Last Update: 09.05.2021
*/