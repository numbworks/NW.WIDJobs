using System;

namespace NW.WIDJobs.Runs
{
    /// <summary>Collects all the helper methods related to a RunId.</summary>
    public interface IRunIdManager
    {

        /// <summary>Creates a RunId based upon <see cref="RunIdManager.DefaultTemplateId"/>.</summary>
        string Create(DateTime now);

        /// <summary>Creates a RunId based upon <see cref="RunIdManager.DefaultTemplateThreshold"/>.</summary>
        string Create(DateTime now, DateTime thresholdDate);

        /// <summary>Creates a RunId based upon <see cref="RunIdManager.DefaultTemplateFromTo"/>.</summary>
        string Create(DateTime now, ushort initialPageNumber, ushort finalPageNumber);

        /// <summary>Creates a RunId based upon <see cref="RunIdManager.DefaultTemplateJobPostingId"/>.</summary>
        string Create(DateTime now, string jobPostingId);

    }
}

/*
    Author: numbworks@gmail.com
    Last Update: 19.08.2021
*/