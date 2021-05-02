using System;
using System.Collections.Generic;

namespace NW.WebsiteExploration
{
    public class ResultsExploration
    {

        // Fields
        // Properties
        public UInt32 TotalResults { get; set; }
        public UInt16 TotalPagesExpected { get; set; }
        public List<ResultsPage> Pages { get; set; }

        // Constructors
        public ResultsExploration() { }
        public ResultsExploration(ResultsExploration objExploration)
        {

            if (objExploration == null)
                new ResultsExploration();

            if (objExploration != null)
            {

                TotalResults = objExploration.TotalResults;
                TotalPagesExpected = objExploration.TotalPagesExpected;

                if (objExploration.Pages != null)
                    Pages = new List<ResultsPage>(objExploration.Pages);

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