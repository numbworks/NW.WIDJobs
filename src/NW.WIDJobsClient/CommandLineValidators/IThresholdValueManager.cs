using System;

namespace NW.WIDJobsClient
{
    public interface IThresholdValueManager
    {

        bool IsValid(string value);
        bool IsValidFinalPageNumber(string value);
        bool IsValidJobPostingId(string value);
        bool IsValidThresholdDate(string value);
        ushort ParseFinalPageNumber(string value);
        DateTime ParseThresholdDate(string value);
    }
}

/*
    Author: numbworks@gmail.com
    Last Update: 27.08.2021
*/