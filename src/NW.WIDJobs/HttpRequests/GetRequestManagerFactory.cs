using System;
using System.Net;

namespace NW.WIDJobs.HttpRequests
{
    /// <summary><inheritdoc cref="IGetRequestManagerFactory"/></summary>
    public class GetRequestManagerFactory : IGetRequestManagerFactory
    {

        #region Fields
        #endregion

        #region Properties
        #endregion

        #region Constructors

        /// <summary>Initializes a <see cref="GetRequestManagerFactory"/> instance.</summary>
        public GetRequestManagerFactory() { }

        #endregion

        #region Methods_public

        public IGetRequestManager Create(
            WebHeaderCollection headers,
            string contentType,
            CookieContainer cookieContainer,
            string userAgent,
            Version protocolVersion
            )
        {

            return
                new GetRequestManager(
                        new HttpWebRequestFactory(),
                        headers,
                        contentType,
                        cookieContainer,
                        userAgent,
                        protocolVersion
                );

        }

        #endregion

    }
}

/*
    Author: numbworks@gmail.com
    Last Update: 25.06.2021
*/