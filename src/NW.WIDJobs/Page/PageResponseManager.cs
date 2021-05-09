using System;
using System.Collections;
using System.Collections.Generic;

namespace NW.WIDJobs
{
    public class PageResponseManager
    {

        // Fields
        private IGetRequestManager _getResponseManager;

        // Properties
        // Constructors
        public PageResponseManager(IGetRequestManager getResponseManager)
        {

            Validator.ValidateObject(getResponseManager, nameof(getResponseManager));

            _getResponseManager = getResponseManager;

        }
        public PageResponseManager()
            : this(new GetRequestManager()) { }

        // Methods (public)
        // Methods (private)

    }
}

/*
    Author: numbworks@gmail.com
    Last Update: 09.05.2021
*/