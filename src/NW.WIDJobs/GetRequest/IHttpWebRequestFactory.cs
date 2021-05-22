using System.Net;

namespace NW.WIDJobs
{
    /// <summary>Wrapper for WebRequest.Create().</summary>
    public interface IHttpWebRequestFactory
    {

        /// <summary>Creates a <see cref="HttpWebRequest"/> object for the provided <paramref name="url"/>.</summary>
        HttpWebRequest Create(string url);

    }
}

/*
    Author: numbworks@gmail.com
    Last Update: 22.05.2021
*/