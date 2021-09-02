using System;
using System.Net;
using System.Text;

namespace NW.WIDJobs.HttpRequests
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

        /// <summary>Sends a HTTP POST request.</summary>
        /// <exception cref="ArgumentNullException"/>
        string Send(string url);

    }
}

/*
    Author: numbworks@gmail.com
    Last Update: 02.09.2021
*/