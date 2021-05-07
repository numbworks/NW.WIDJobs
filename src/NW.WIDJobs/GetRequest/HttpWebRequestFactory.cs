using System.Net;

namespace NW.WIDJobs
{
    /// <summary>Wrapper for WebRequest.Create().</summary>
    public class HttpWebRequestFactory : IHttpWebRequestFactory
    {

        // Fields
        // Properties
        // Constructors
        public HttpWebRequestFactory() { }

        // Methods
        public HttpWebRequest Create(string url)
            => (HttpWebRequest)WebRequest.Create(url);

    }
}

/*
    Author: numbworks@gmail.com
    Last Update: 06.05.2021
*/