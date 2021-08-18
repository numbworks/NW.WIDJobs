using System;
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

        public IPostRequestManager FakePostRequestManager { get; private set; }

        #endregion

        #region Constructors

        public FakePostRequestManagerFactory(IPostRequestManager fakePostRequestManager) 
        {

            FakePostRequestManager = fakePostRequestManager;

        }

        #endregion

        #region Methods_public

        public IPostRequestManager Create
            (WebHeaderCollection headers, string contentType, CookieContainer cookieContainer,
            string userAgent, Version protocolVersion, string postData, Encoding postDataEncoding)
            => FakePostRequestManager;

        #endregion

        #region Methods_private

        #endregion

    }
}

/*
    Author: numbworks@gmail.com
    Last Update: 18.08.2021
*/