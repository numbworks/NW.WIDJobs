using System;
using System.Net;

namespace NW.WIDJobs.HttpRequests
{
    /// <summary>A factory for <see cref="IGetRequestManager"/>.</summary>
    public interface IGetRequestManagerFactory
    {

        /// <summary>
        /// Creates a <see cref="IGetRequestManager"/> instance with a default <see cref="IHttpWebRequestFactory"/>.
        /// </summary>
        IGetRequestManager Create(
            WebHeaderCollection headers, 
            string contentType, 
            CookieContainer cookieContainer, 
            string userAgent, 
            Version protocolVersion
            );

    }
}

/*
    Author: numbworks@gmail.com
    Last Update: 25.06.2021
*/