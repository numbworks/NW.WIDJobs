using System;

namespace NW.WIDJobsClient
{
    /// <summary>A threshold value provided thru the command-line interface.</summary>
    public class ThresholdValue
    {

        #region Fields

        #endregion

        #region Properties

        public uint? FinalPageNumber { get; }
        public DateTime? ThresholdDate { get; }
        public string JobPostingId { get; }

        #endregion

        #region Constructors

        /// <summary>Initializes a <see cref="ThresholdValue"/> instance.</summary>	
        public ThresholdValue(uint? finalPageNumber, DateTime? thresholdDate, string jobPostingId) 
        {

            FinalPageNumber = finalPageNumber;
            ThresholdDate = thresholdDate;
            JobPostingId = jobPostingId;

        }

        #endregion

        #region Methods_public

        #endregion

        #region Methods_private

        #endregion

    }
}

/*
    Author: numbworks@gmail.com
    Last Update: 27.08.2021
*/