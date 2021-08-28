using NW.WIDJobs;

namespace NW.WIDJobsClient
{
    public interface IWIDExplorerSettingsFactory
    {
        WIDExplorerSettings Create(string parallelRequests = null, string pauseBetweenRequestsMs = null, string folderPath = null, bool? deleteAndRecreateDatabase = null);
    }
}

/*
    Author: numbworks@gmail.com
    Last Update: 28.08.2021
*/