using System;

namespace NW.WIDJobs
{
    /// <summary>Collects all the global settings required by this library.</summary>
    public class WIDExplorerSettings
    {

        #region Fields
        #endregion

        #region Properties

        public static ushort DefaultParallelRequests { get; } = 3;
        public static uint DefaultPauseBetweenRequestsMs { get; } = 25000; // 25 seconds

        public ushort ParallelRequests { get; }
        public uint PauseBetweenRequestsMs { get; }

        #endregion

        #region Constructors

        /// <summary>Initializes a <see cref="WIDExplorerSettings"/> instance.</summary>
        /// <exception cref="ArgumentException"/>
        public WIDExplorerSettings(
            ushort parallelRequests,
            uint pauseBetweenRequestsMs
            )
        {

            Validator.ThrowIfLessThanOne(parallelRequests, nameof(parallelRequests));

            ParallelRequests = parallelRequests;
            PauseBetweenRequestsMs = pauseBetweenRequestsMs;

        }

        /// <summary>Initializes a <see cref="WIDExplorerSettings"/> instance using default parameters.</summary>
        public WIDExplorerSettings()
            : this(
                  DefaultParallelRequests,
                  DefaultPauseBetweenRequestsMs) { }

        #endregion

        #region Methods_public
        #endregion

    }
}

/*
    Author: numbworks@gmail.com
    Last Update: 09.05.2021
*/