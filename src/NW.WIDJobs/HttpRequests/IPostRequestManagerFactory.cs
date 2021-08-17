using System;
using System.Net;
using System.Text;

namespace NW.WIDJobs.HttpRequests
{
    /// <summary>A factory for <see cref="IPostRequestManager"/>.</summary>
    public interface IPostRequestManagerFactory
    {

        /// <summary>
        /// Creates a <see cref="IPostRequestManager"/> instance with a default <see cref="IHttpWebRequestFactory"/>.
        /// </summary>
        IPostRequestManager Create(
            WebHeaderCollection headers, 
            string contentType, 
            CookieContainer cookieContainer, 
            string userAgent, 
            Version protocolVersion, 
            string postData, 
            Encoding postDataEncoding
            );

    }
}

/*
    Author: numbworks@gmail.com
    Last Update: 25.06.2021
*/