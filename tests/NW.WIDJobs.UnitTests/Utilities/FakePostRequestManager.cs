using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using NW.WIDJobs.HttpRequests;

namespace NW.WIDJobs.UnitTests
{

    public class FakePostRequestManager : IPostRequestManager
    {

        #region Fields

        #endregion

        #region Properties

        public string Method { get; } = "POST";
        public IHttpWebRequestFactory HttpWebRequestFactory { get; }
        public WebHeaderCollection Headers { get; }
        public string ContentType { get; }
        public CookieContainer CookieContainer { get; }
        public string UserAgent { get; }
        public Version ProtocolVersion { get; }
        public string PostData { get; }
        public Encoding PostDataEncoding { get; }

        public List<(string bodyUrl, string response)> BodyUrlResponses { get; }

        #endregion

        #region Constructors

        public FakePostRequestManager(
            IHttpWebRequestFactory httpWebRequestFactory,
            WebHeaderCollection headers,
            string contentType,
            CookieContainer cookieContainer,
            string userAgent,
            Version protocolVersion,
            string postData,
            Encoding postDataEncoding,
            List<(string bodyUrl, string response)> bodyUrlResponses) 
        {

            HttpWebRequestFactory = httpWebRequestFactory;
            Headers = headers;
            ContentType = contentType;
            CookieContainer = cookieContainer;
            UserAgent = userAgent;

            ProtocolVersion = protocolVersion;
            if (ProtocolVersion == null)
                ProtocolVersion = HttpVersion.Version11;

            PostData = postData;
            PostDataEncoding = postDataEncoding;

            BodyUrlResponses = bodyUrlResponses;
        
        }

        #endregion

        #region Methods_public

        public string Send(string url)
        {

            foreach ((string bodyUrl, string response) tuple in BodyUrlResponses)
                if (PostData.Contains(tuple.bodyUrl))
                    return tuple.response;

            throw new Exception($"'{PostData}' has a 'url' field that is not available in '{BodyUrlResponses}'. No response to send.");

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