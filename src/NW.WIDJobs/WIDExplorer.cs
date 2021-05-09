using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Text;
using System.Threading;

namespace NW.WIDJobs
{

    public class WIDExplorer
    {

        // Fields
        private WIDExplorerComponents _components;
        private WIDExplorerSettings _settings;

        // Properties
        // Constructors
        public WIDExplorer
            (WIDExplorerComponents components, WIDExplorerSettings settings)
        {

            Validator.ValidateObject(components, nameof(components));
            Validator.ValidateObject(settings, nameof(settings));

            _components = components;
            _settings = settings;

        }
        public WIDExplorer()
            : this(new WIDExplorerComponents(), new WIDExplorerSettings()) { }

        // Methods (public)

        // Methods (private)
        private string CreatePageAbsoluteUrl(ushort pageNumber)
        {

            if (pageNumber == 1)
                return "https://www.workindenmark.dk/Search/Job-search?q=";

            return $"https://www.workindenmark.dk/Search/Job-search?q=&PageNum={pageNumber}";

        }
        private void ConditionallySleep
            (ushort i, ushort parallelRequests, int pauseBetweenRequestsMs)
        {

            // Do a pause of x each y requests
            // i != 0, because 0 % x = 0...
            if (i != 0 && i % parallelRequests == 0)
                Thread.Sleep(pauseBetweenRequestsMs);

        }

    }
}

/*
    Author: numbworks@gmail.com
    Last Update: 09.05.2021
*/