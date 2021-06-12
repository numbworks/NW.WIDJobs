using System;

namespace NW.WIDJobs
{
    /// <summary><inheritdoc cref="IRunIdManager"/></summary>
    public class RunIdManager : IRunIdManager
    {

        #region Fields
        #endregion

        #region Properties

        public static string DefaultTemplateId { get; } = "ID:{0}";
        public static string DefaultTemplateThreshold { get; } = "{0}|THRESHOLD:{1}";
        public static string DefaultTemplateFromTo { get; } = "{0}|FROM:{1}|TO:{2}";
        public static string DefaultFormatDateTime { get; } = "yyyyMMddHHmmssfff";
        public static string DefaultFormatDate { get; } = "yyyyMMdd";

        #endregion

        #region Constructors

        /// <summary>Initializes a <see cref="RunIdManager"/> instance.</summary>
        public RunIdManager() { }

        #endregion

        #region Methods_public

        public string Create(DateTime now)
        {

            return string.Format(
                DefaultTemplateId,
                now.ToString(DefaultFormatDateTime)
            );

        }
        public string Create(DateTime now, DateTime startDate, DateTime endDate)
        {

            return string.Format(
                DefaultTemplateFromTo,
                Create(now),
                startDate.ToString(DefaultFormatDate),
                endDate.ToString(DefaultFormatDate)
            );

        }
        public string Create(DateTime now, DateTime thresholdDate)
        {

            return string.Format(
                DefaultTemplateThreshold,
                Create(now),
                thresholdDate.ToString(DefaultFormatDate)
            );

        }
        public string Create(DateTime now, ushort initialPageNumber, ushort finalPageNumber)
        {

            return string.Format(
                DefaultTemplateFromTo,
                Create(now),
                initialPageNumber,
                finalPageNumber
            );

        }

        #endregion

    }
}

/*
    Author: numbworks@gmail.com
    Last Update: 16.05.2021
*/