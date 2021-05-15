using System;

namespace NW.WIDJobs
{
    public class RunIdManager : IRunIdManager
    {

        // Fields
        // Properties
        public static string TemplateId { get; } = "ID:{0}";
        public static string TemplateFromTo { get; } = "{0}|FROM:{1}|TO:{2}";
        public static string TemplateUntil{ get; } = "{0}|UNTIL:{1}";
        public static string FormatDateTime { get; } = "yyyyMMddHHmmssfff";
        public static string FormatDate { get; } = "yyyyMMddHH";

        // Constructors
        public RunIdManager() { }

        // Methods (public)
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
        public string Create(DateTime now, DateTime untilDate)
        {

            return string.Format(
                TemplateUntil,
                Create(now),
                untilDate.ToString(FormatDate)
            );

        }

        // Methods (private)

    }
}

/*
    Author: numbworks@gmail.com
    Last Update: 09.05.2021
*/