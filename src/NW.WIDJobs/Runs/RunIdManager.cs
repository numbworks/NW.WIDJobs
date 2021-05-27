using System;

namespace NW.WIDJobs
{
    /// <summary><inheritdoc cref="IRunIdManager"/></summary>
    public class RunIdManager : IRunIdManager
    {

        #region Fields
        #endregion

        #region Properties

        public static string TemplateId { get; } = "ID:{0}";
        public static string TemplateThreshold { get; } = "{0}|THRESHOLD:{1}";
        public static string TemplateFromTo { get; } = "{0}|FROM:{1}|TO:{2}";
        public static string FormatDateTime { get; } = "yyyyMMddHHmmssfff";
        public static string FormatDate { get; } = "yyyyMMdd";

        #endregion

        #region Constructors

        /// <summary>Initializes a <see cref="RunIdManager"/> instance.</summary>
        public RunIdManager() { }

        #endregion

        #region Methods_public

        public string Create(DateTime now)
        {

            return string.Format(
                TemplateId,
                now.ToString(FormatDateTime)
            );

        }
        public string Create(DateTime now, DateTime startDate, DateTime endDate)
        {

            return string.Format(
                TemplateFromTo,
                Create(now),
                startDate.ToString(FormatDate),
                endDate.ToString(FormatDate)
            );

        }
        public string Create(DateTime now, DateTime thresholdDate)
        {

            return string.Format(
                TemplateThreshold,
                Create(now),
                thresholdDate.ToString(FormatDate)
            );

        }
        public string Create(DateTime now, ushort initialPageNumber, ushort finalPageNumber)
        {

            return string.Format(
                TemplateFromTo,
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