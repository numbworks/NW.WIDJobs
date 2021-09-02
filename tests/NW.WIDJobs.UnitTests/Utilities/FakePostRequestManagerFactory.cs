using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using NW.WIDJobs.HttpRequests;

namespace NW.WIDJobs.UnitTests
{

    public class FakePostRequestManagerFactory : IPostRequestManagerFactory
    {

        #region Fields

        #endregion

        #region Properties

        public List<(string bodyUrl, string response)> BodyUrlResponses { get; }

        #endregion

        #region Constructors

        public FakePostRequestManagerFactory(List<(string bodyUrl, string response)> bodyUrlResponses)
        {

            BodyUrlResponses = bodyUrlResponses;

        }

        #endregion

        #region Methods_public

        public IPostRequestManager Create
            (WebHeaderCollection headers, string contentType, CookieContainer cookieContainer,
            string userAgent, Version protocolVersion, string postData, Encoding postDataEncoding)
        {

            return
                new FakePostRequestManager(
                        new HttpWebRequestFactory(),
                        headers,
                        contentType,
                        cookieContainer,
                        userAgent,
                        protocolVersion,
                        postData,
                        postDataEncoding,
                        BodyUrlResponses
                );

        }

        #endregion

        #region Methods_private

        #endregion

    }
}

/*
    Author: numbworks@gmail.com
    Last Update: 18.08.2021
*/