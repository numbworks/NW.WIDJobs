namespace NW.WIDJobsClient
{

    /// <summary>Groups all the utility methods related to <see cref="CommandLineManager.Option_PauseBetweenRequestsMs_Template"/>.</summary>
    public interface IPauseBetweenRequestsManager
    {

        /// <summary>Establishes if the value for <see cref="CommandLineManager.Option_PauseBetweenRequestsMs_Template"/> is valid or not.</summary>
        bool IsValid(string value);

        /// <summary>Parses the value for <see cref="CommandLineManager.Option_PauseBetweenRequestsMs_Template"/>.</summary>
        uint ParsePauseBetweenRequests(string value);

    }
}

/*
    Author: numbworks@gmail.com
    Last Update: 28.08.2021
*/