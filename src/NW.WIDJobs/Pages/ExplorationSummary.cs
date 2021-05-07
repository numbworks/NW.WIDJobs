using System.Collections.Generic;

namespace NW.WIDJobs
{
    public class ExplorationSummary
    {

        // Fields
        // Properties
        public uint TotalResults { get; }
        public ushort TotalPagesExpected { get; }
        public List<Page> Pages { get; }

        // Constructors
        public ExplorationSummary
            (uint totalResults, ushort totalPagesExpected, List<Page> pages)
        {

            TotalResults = totalResults;
            TotalPagesExpected = totalPagesExpected;
            Pages = pages;

        }

        // Methods

    }
}

/*
    Author: numbworks@gmail.com
    Last Update: 05.05.2021
*/