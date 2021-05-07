namespace NW.WIDJobs
{
    public class ExplorerComponents
    {

        // Fields
        // Properties
        public IXPathManager XPathManager { get; }
        public IGetRequestManager GetRequestManager { get; }

        // Constructors	
        public ExplorerComponents
            (IXPathManager xpathManager, IGetRequestManager getRequestManager)
        {

            // Validation

            XPathManager = xpathManager;
            GetRequestManager = getRequestManager;

        }
        public ExplorerComponents()
            : this(new XPathManager(), new GetRequestManager()) { }

        // Methods

    }
}

/*
    Author: numbworks@gmail.com
    Last Update: 05.05.2021
*/