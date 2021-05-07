using System;

namespace NW.WIDJobs
{
    public class WIDExplorerComponents
    {

        // Fields
        // Properties
        public static Action<string> DefaultLoggingAction { get; }
            = (message) => Console.WriteLine($"[{DateTime.UtcNow.ToString("yyyy-MM-dd HH:mm:ss:fff")}] {message}");

        public Action<string> LoggingAction { get; }
        public IXPathManager XPathManager { get; }
        public IGetRequestManager GetRequestManager { get; }

        // Constructors	
        public WIDExplorerComponents(
            Action<string> loggingAction, 
            IXPathManager xpathManager, 
            IGetRequestManager getRequestManager)
        {

            Validator.ValidateObject(loggingAction, nameof(loggingAction));
            Validator.ValidateObject(xpathManager, nameof(xpathManager));
            Validator.ValidateObject(getRequestManager, nameof(getRequestManager));

            LoggingAction = loggingAction;
            XPathManager = xpathManager;
            GetRequestManager = getRequestManager;

        }
        public WIDExplorerComponents()
            : this(
                  DefaultLoggingAction,
                  new XPathManager(), 
                  new GetRequestManager()) { }

        // Methods

    }
}

/*
    Author: numbworks@gmail.com
    Last Update: 08.05.2021
*/