using System;

namespace NW.WIDJobs
{
    public interface IRunIdManager
    {
        string Create(DateTime now);
        string Create(DateTime now, DateTime untilDate);
        string Create(DateTime now, DateTime startDate, DateTime endDate);
    }
}

/*
    Author: numbworks@gmail.com
    Last Update: 09.05.2021
*/