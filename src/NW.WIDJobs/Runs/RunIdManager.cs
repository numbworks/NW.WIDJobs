using System;

namespace NW.WIDJobs
{
    public class RunIdManager : IRunIdManager
    {

        // Fields
        // Properties
        // Constructors
        public RunIdManager() { }

        // Methods (public)
        public string Create(DateTime now)
        {

            return string.Format(
                "ID:{0}",
                now.ToString("yyyyMMddHHmmssfff")
            );

        }
        public string Create(DateTime now, DateTime startDate, DateTime endDate)
        {

            return string.Format(
                "{0}|FROM:{1}|TO:{2}",
                Create(now),
                startDate.ToString("yyyyMMddHH"),
                endDate.ToString("yyyyMMddHH")
            );

        }
        public string Create(DateTime now, DateTime untilDate)
        {

            return string.Format(
                "{0}|UNTIL:{1}",
                Create(now),
                untilDate.ToString("yyyyMMddHH")
            );

        }

        // Methods (private)

    }
}

/*
    Author: numbworks@gmail.com
    Last Update: 09.05.2021
*/