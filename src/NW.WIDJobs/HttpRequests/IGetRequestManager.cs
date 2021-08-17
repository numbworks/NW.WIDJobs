using System;
using System.Net;
using System.Text;

namespace NW.WIDJobs.HttpRequests
{
    /// <summary>Collects methods related to HTTP GET requests.</summary>
    public interface IGetRequestManager
    {
        string ContentType { get; }
        CookieContainer CookieContainer { get; }
        WebHeaderCollection Headers { get; }
        IHttpWebRequestFactory HttpWebRequestFactory { get; }
        string Method { get; }
        Version ProtocolVersion { get; }
        string UserAgent { get; }

        /// <summary>Sends a HTTP GET request.</summary>
        /// <exception cref="ArgumentNullException"/>
        string Send(string url, Encoding encoding = null);
    }
}

/*
    Author: numbworks@gmail.com
    Last Update: 22.05.2021
*/