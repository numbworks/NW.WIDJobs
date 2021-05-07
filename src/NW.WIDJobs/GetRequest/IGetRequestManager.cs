using System;
using System.Net;
using System.Text;

namespace NW.WIDJobs
{
    public interface IGetRequestManager
    {
        string ContentType { get; }
        CookieContainer CookieContainer { get; }
        WebHeaderCollection Headers { get; }
        IHttpWebRequestFactory HttpWebRequestFactory { get; }
        string Method { get; }
        Version ProtocolVersion { get; }
        string UserAgent { get; }

        string Send(string url, Encoding encoding = null);
    }
}

/*
    Author: numbworks@gmail.com
    Last Update: 06.05.2021
*/