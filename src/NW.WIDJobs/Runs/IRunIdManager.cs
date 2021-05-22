using System;

namespace NW.WIDJobs
{
    public interface IRunIdManager
    {
        string Create(DateTime now);
        string Create(DateTime now, DateTime thresholdDate);
        string Create(DateTime now, DateTime startDate, DateTime endDate);
        string Create(DateTime now, ushort initialPageNumber, ushort finalPageNumber);
    }
}

/*
    Author: numbworks@gmail.com
    Last Update: 16.05.2021
*/