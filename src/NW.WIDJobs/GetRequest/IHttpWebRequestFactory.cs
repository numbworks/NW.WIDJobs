using System.Net;

namespace NW.WIDJobs
{
    /// <summary>Wrapper for WebRequest.Create().</summary>
    public interface IHttpWebRequestFactory
    {

        HttpWebRequest Create(string url);

    }
}

/*
    Author: numbworks@gmail.com
    Last Update: 06.05.2021
*/