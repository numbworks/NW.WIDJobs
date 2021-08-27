using System;

namespace NW.WIDJobsClient
{
    public interface IThresholdValueManager
    {
        uint MininumFinalPageNumber { get; }

        bool IsValidFinalPageNumber(string value);
        bool IsValidJobPostingId(string value);
        bool IsValidThresholdDate(string value);
        ushort ParseFinalPageNumber(string value);
        DateTime ParseThresholdDate(string value);
    }
}