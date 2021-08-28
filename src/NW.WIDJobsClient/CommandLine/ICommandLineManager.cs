namespace NW.WIDJobsClient
{
    /// <summary>Groups all the logic related to the processing of the command-line arguments.</summary>
    public interface ICommandLineManager
    {

        /// <summary>Processes the command-line arguments.</summary>
        int Execute(params string[] args);

    }
}

/*
    Author: numbworks@gmail.com
    Last Update: 28.08.2021
*/