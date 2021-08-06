using System;
using System.Net;
using System.Text;

namespace NW.WIDJobs.UnitTests
{

    public class FakePostRequestManager : IPostRequestManager
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
        public string PostData
            => throw new NotImplementedException();
        public Encoding PostDataEncoding
            => throw new NotImplementedException();
        public Version ProtocolVersion
            => throw new NotImplementedException();
        public string UserAgent
            => throw new NotImplementedException();

        public string Response { get; private set; }
        public string Url { get; private set; }

        #endregion

        #region Constructors

        public FakePostRequestManager(string response) 
        {

            Response = response;
        
        }

        #endregion

        #region Methods_public

        public string Send(string url)
        {

            Url = url;

            return Response;

        }

        #endregion

        #region Methods_private

        #endregion

    }
}

/*
    Author: numbworks@gmail.com
    Last Update: 06.08.2021
*/