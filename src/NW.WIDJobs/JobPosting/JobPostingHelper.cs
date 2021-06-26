using System;
using System.Globalization;

namespace NW.WIDJobs
{
    /// <inheritdoc cref="IJobPostingHelper"/>
    public class JobPostingHelper : IJobPostingHelper
    {

        #region Fields
        #endregion

        #region Properties
        #endregion

        #region Constructors

        ///<summary>Initializes a <see cref="JobPostingHelper"/> instance.</summary>
        public JobPostingHelper() { }

        #endregion

        #region Methods_public

        public DateTime ParseDate(string date)
            => DateTime.ParseExact(date, "yyyy-MM-dd", CultureInfo.InvariantCulture);

        #endregion

    }
}

/*
    Author: numbworks@gmail.com
    Last Update: 25.06.2021
*/