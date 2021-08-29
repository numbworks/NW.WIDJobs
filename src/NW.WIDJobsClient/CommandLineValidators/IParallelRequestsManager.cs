namespace NW.WIDJobsClient.CommandLineValidators
{
    /// <summary>Groups all the utility methods related to <see cref="CommandLineManager.Option_ParallelRequests_Template"/>.</summary>
    public interface IParallelRequestsManager
    {

        /// <summary>Establishes if the value for <see cref="CommandLineManager.Option_ParallelRequests_Template"/> is valid or not.</summary>
        bool IsWithinRange(string value);

    }
}

/*
    Author: numbworks@gmail.com
    Last Update: 28.08.2021
*/