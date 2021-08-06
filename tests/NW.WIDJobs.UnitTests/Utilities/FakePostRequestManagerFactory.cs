using System;
using System.Net;
using System.Text;

namespace NW.WIDJobs.UnitTests
{

    public class FakePostRequestManagerFactory : IPostRequestManagerFactory
    {

        #region Fields

        #endregion

        #region Properties

        public FakePostRequestManager FakePostRequestManager { get; private set; }

        #endregion

        #region Constructors

        public FakePostRequestManagerFactory(FakePostRequestManager fakePostRequestManager) 
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
    Last Update: 06.08.2021
*/