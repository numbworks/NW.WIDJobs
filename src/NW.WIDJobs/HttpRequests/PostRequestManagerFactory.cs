using System;
using System.Net;
using System.Text;

namespace NW.WIDJobs.HttpRequests
{
    /// <summary><inheritdoc cref="IPostRequestManagerFactory"/></summary>
    public class PostRequestManagerFactory : IPostRequestManagerFactory
    {

        #region Fields
        #endregion

        #region Properties
        #endregion

        #region Constructors

        /// <summary>Initializes a <see cref="PostRequestManagerFactory"/> instance.</summary>
        public PostRequestManagerFactory() { }

        #endregion

        #region Methods_public

        public IPostRequestManager Create(
            WebHeaderCollection headers,
            string contentType,
            CookieContainer cookieContainer,
            Version protocolVersion,
            string postData,
            Encoding postDataEncoding
            )
        {

            return
                new PostRequestManager(
                        new HttpWebRequestFactory(),
                        headers,
                        contentType,
                        cookieContainer,
                        protocolVersion,
                        postData,
                        postDataEncoding
                );

        }

        #endregion

    }
}

/*
    Author: numbworks@gmail.com
    Last Update: 02.09.2021
*/