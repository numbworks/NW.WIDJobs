using System;
using System.Net;
using System.Text;

namespace NW.WIDJobs
{
    /// <summary>Collects methods related to HTTP POST requests.</summary>
    public interface IPostRequestManager
    {

        string ContentType { get; }
        CookieContainer CookieContainer { get; }
        WebHeaderCollection Headers { get; }
        IHttpWebRequestFactory HttpWebRequestFactory { get; }
        string Method { get; }
        string PostData { get; }
        Encoding PostDataEncoding { get; }
        Version ProtocolVersion { get; }
        string UserAgent { get; }

        /// <summary>Sends a HTTP POST request.</summary>
        /// <exception cref="ArgumentNullException"/>
        string Send(string url);

    }
}

/*
    Author: numbworks@gmail.com
    Last Update: 25.06.2021
*/