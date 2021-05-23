using System;

namespace NW.WIDJobs
{
    /// <summary>Collects all the helper methods related to a RunId.</summary>
    public interface IRunIdManager
    {

        /// <summary>Creates a RunId based upon <see cref="RunIdManager.TemplateId"/>.</summary>
        string Create(DateTime now);

        /// <summary>Creates a RunId based upon <see cref="RunIdManager.TemplateThreshold"/>.</summary>
        string Create(DateTime now, DateTime thresholdDate);

        /// <summary>Creates a RunId based upon <see cref="RunIdManager.TemplateFromTo"/>.</summary>
        string Create(DateTime now, DateTime startDate, DateTime endDate);

        /// <summary>Creates a RunId based upon <see cref="RunIdManager.TemplateFromTo"/>.</summary>
        string Create(DateTime now, ushort initialPageNumber, ushort finalPageNumber);

    }
}

/*
    Author: numbworks@gmail.com
    Last Update: 16.05.2021
*/