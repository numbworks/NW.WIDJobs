using System;
using System.Net;
using NW.WIDJobs.HttpRequests;

namespace NW.WIDJobs.UnitTests
{
    public class FakeGetRequestManagerFactory : IGetRequestManagerFactory
    {

        #region Fields

        #endregion

        #region Properties

        public IGetRequestManager FakeGetRequestManager { get; private set; }

        #endregion

        #region Constructors

        public FakeGetRequestManagerFactory(IGetRequestManager fakeGetRequestManager) 
        {

            FakeGetRequestManager = fakeGetRequestManager;

        }

        #endregion

        #region Methods_public

        public IGetRequestManager Create
            (WebHeaderCollection headers, string contentType, CookieContainer cookieContainer, Version protocolVersion)
        {

            return FakeGetRequestManager;
        
        }

        #endregion

        #region Methods_private

        #endregion

    }
}

/*
    Author: numbworks@gmail.com
    Last Update: 02.09.2021
*/