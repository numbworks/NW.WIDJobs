using System;
using System.Net;
using System.Text;

namespace NW.WIDJobs.UnitTests
{

    public class FakePostRequestManagerFactory : IPostRequestManagerFactory
    {

        #region Fields

        private IPostRequestManager _postRequestManager;

        #endregion

        #region Properties

        #endregion

        #region Constructors

        public FakePostRequestManagerFactory(string response) 
        {

            _postRequestManager = new FakePostRequestManager(response);

        }

        #endregion

        #region Methods_public

        public IPostRequestManager Create
            (WebHeaderCollection headers, string contentType, CookieContainer cookieContainer,
            string userAgent, Version protocolVersion, string postData, Encoding postDataEncoding)
            => _postRequestManager;

        #endregion

        #region Methods_private

        #endregion

    }
}

/*
    Author: numbworks@gmail.com
    Last Update: 06.08.2021
*/