using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using NW.WIDJobs.HttpRequests;

namespace NW.WIDJobs.UnitTests
{
    public class FakeGetRequestManager : IGetRequestManager
    {

        #region Fields

        #endregion

        #region Properties

        public string ContentType 
            => throw new NotImplementedException();
        public CookieContainer CookieContainer 
            => throw new NotImplementedException();
        public WebHeaderCollection Headers 
            => throw new NotImplementedException();
        public IHttpWebRequestFactory HttpWebRequestFactory 
            => throw new NotImplementedException();
        public string Method 
            => throw new NotImplementedException();
        public Version ProtocolVersion 
            => throw new NotImplementedException();
        public string UserAgent 
            => throw new NotImplementedException();

        public Dictionary<string, string> UrlsResponses { get; private set; }

        #endregion

        #region Constructors

        public FakeGetRequestManager(Dictionary<string, string> urlsResponses)
        {

            UrlsResponses = urlsResponses;

        }

        #endregion

        #region Methods_public

        public string Send(string url, Encoding encoding = null)
        {

            string response = UrlsResponses[url]; // We don't consider the "not found" case.

            return response;

        }

        #endregion

        #region Methods_private

        #endregion

    }
}

/*
    Author: numbworks@gmail.com
    Last Update: 19.08.2021
*/