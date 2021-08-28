using System;
using System.Linq;

namespace NW.WIDJobsClient
{
    /// <inheritdoc cref="IParallelRequestsManager/>
    public class ParallelRequestsManager : IParallelRequestsManager
    {

        #region Fields

        #endregion

        #region Properties

        public static ushort MininumParallelRequests { get; } = 1;
        public static ushort MaximumParallelRequests { get; } = 65535; // Max for ushort

        #endregion

        #region Constructors

        /// <summary>Initializes a <see cref="ParallelRequestsManager"/> instance.</summary>	
        public ParallelRequestsManager() { }

        #endregion

        #region Methods_public

        public bool IsWithinRange(string value)
        {

            try
            {
                ushort parallelRequests = ushort.Parse(value);

                if (Enumerable.Range(MininumParallelRequests, MaximumParallelRequests).Contains(parallelRequests))
                    return true;

                return false;

            }
            catch
            {

                return false;

            }

        }

        #endregion

        #region Methods_private

        #endregion

    }
}

/*
    Author: numbworks@gmail.com
    Last Update: 28.08.2021
*/