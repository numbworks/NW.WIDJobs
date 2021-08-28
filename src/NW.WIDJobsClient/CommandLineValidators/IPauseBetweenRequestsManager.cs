namespace NW.WIDJobsClient
{
    public interface IPauseBetweenRequestsManager
    {
        bool IsValid(string value);
        uint ParsePauseBetweenRequests(string value);
    }
}

/*
    Author: numbworks@gmail.com
    Last Update: 28.08.2021
*/