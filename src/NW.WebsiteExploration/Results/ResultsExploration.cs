using System.Collections.Generic;

namespace NW.WebsiteExploration
{
    public class ResultsExploration
    {

        // Fields
        // Properties
        public uint TotalResults { get; set; }
        public ushort TotalPagesExpected { get; set; }
        public List<ResultsPage> Pages { get; set; }

        // Constructors
        public ResultsExploration() { }
        public ResultsExploration(ResultsExploration exploration)
        {

            if (exploration == null)
                new ResultsExploration();

            if (exploration != null)
            {

                TotalResults = exploration.TotalResults;
                TotalPagesExpected = exploration.TotalPagesExpected;

                if (exploration.Pages != null)
                    Pages = new List<ResultsPage>(exploration.Pages);

            };

        }

        // Methods

    }
}

/*
 *
 *  Author: numbworks@gmail.com
 *  Last Update: 22.09.2018
 * 
 */