using System;
using System.Net;
using System.IO;
using System.Text;
using NW.WIDJobs.Validation;

namespace NW.WIDJobs.HttpRequests
{
    /// <summary><inheritdoc cref="IGetRequestManager"/></summary>
    public class GetRequestManager : IGetRequestManager
    {

        #region Fields 
        #endregion

        #region Properties
        
        public string Method { get; } = "GET";
        public IHttpWebRequestFactory HttpWebRequestFactory { get; }
        public WebHeaderCollection Headers { get; }
        public string ContentType { get; }
        public CookieContainer CookieContainer { get; }
        public Version ProtocolVersion { get; }

        #endregion

        #region Constructors

        /// <summary>Initializes a <see cref="GetRequestManager"/> instance.</summary>
        /// <exception cref="ArgumentNullException"/>
        public GetRequestManager(
            IHttpWebRequestFactory httpWebRequestFactory,
            WebHeaderCollection headers,
            string contentType,
            CookieContainer cookieContainer,
            Version protocolVersion
            )
        {

            Validator.ValidateObject(httpWebRequestFactory, nameof(httpWebRequestFactory));

            HttpWebRequestFactory = httpWebRequestFactory;
            Headers = headers;
            ContentType = contentType;
            CookieContainer = cookieContainer;

            ProtocolVersion = protocolVersion;
            if (ProtocolVersion == null)
                ProtocolVersion = HttpVersion.Version11;

        }

        /// <summary>Initializes a <see cref="GetRequestManager"/> instance using default parameters.</summary>
        public GetRequestManager()
            : this(new HttpWebRequestFactory(), null, null, null, null) { }

        #endregion

        #region Methods_public

        public string Send(string url, Encoding encoding = null)
        {

            Validator.ValidateStringNullOrWhiteSpace(url, nameof(url));

            if (encoding == null)
                encoding = Encoding.ASCII;

            HttpWebResponse httpWebResponse = Send(url);
            string response = ConvertToString(httpWebResponse, encoding);

            return response;

        }

        #endregion

        #region Methods_private

        private HttpWebResponse Send(string url)
        {

            HttpWebRequest httpWebRequest = HttpWebRequestFactory.Create(url);
            httpWebRequest.Method = Method;

            if (Headers != null)
                httpWebRequest.Headers = Headers;

            if (ContentType != null)
                httpWebRequest.ContentType = ContentType;

            if (ProtocolVersion == null)
                httpWebRequest.ProtocolVersion = HttpVersion.Version11;
            else
                httpWebRequest.ProtocolVersion = ProtocolVersion;

            if (CookieContainer == null)
                httpWebRequest.CookieContainer = new CookieContainer();
            else
                httpWebRequest.CookieContainer = CookieContainer;

            return (HttpWebResponse)httpWebRequest.GetResponse();

        }
        private string ConvertToString(HttpWebResponse httpWebResponse, Encoding encoding)
        {

            string response = string.Empty;
            Stream stream = httpWebResponse.GetResponseStream();
            using (StreamReader streamReader = new StreamReader(stream, encoding))
                response = streamReader.ReadToEnd();

            return response;

        }

        #endregion

    }
}

/*
    Author: numbworks@gmail.com
    Last Update: 02.09.2021
*/