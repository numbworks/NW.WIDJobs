using System;
using System.Net;
using System.Text;

namespace NW.WIDJobs.UnitTests
{
    /// <inheritdoc cref="IFakePostRequestManager"/>
    public class FakePostRequestManager : IPostRequestManager
    {

        #region Fields

        private string _response;

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
        public string PostData
            => throw new NotImplementedException();
        public Encoding PostDataEncoding
            => throw new NotImplementedException();
        public Version ProtocolVersion
            => throw new NotImplementedException();
        public string UserAgent
            => throw new NotImplementedException();

        #endregion

        #region Constructors

        public FakePostRequestManager(string response) 
        {

                _response = response;
        
        }

        #endregion

        #region Methods_public

        public string Send(string url)
            => _response;

        #endregion

        #region Methods_private

        #endregion

    }
}

/*
    Author: numbworks@gmail.com
    Last Update: 06.08.2021
*/