using System;
using System.Net;
using System.IO;
using System.Text;
using NW.WIDJobs.Validation;

namespace NW.WIDJobs.HttpRequests
{
    /// <summary><inheritdoc cref="IPostRequestManager"/></summary>
    public class PostRequestManager : IPostRequestManager
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

        #endregion

        #region Constructors

        /// <summary>Initializes a <see cref="PostRequestManager"/> instance.</summary>
        /// <exception cref="ArgumentNullException"/>
        public PostRequestManager(
            IHttpWebRequestFactory httpWebRequestFactory,
            WebHeaderCollection headers,
            string contentType,
            CookieContainer cookieContainer,
            string userAgent,
            Version protocolVersion,
            string postData,
            Encoding postDataEncoding
            )
        {

            Validator.ValidateObject(httpWebRequestFactory, nameof(httpWebRequestFactory));

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

        }

        /// <summary>Initializes a <see cref="PostRequestManager"/> instance using default parameters.</summary>
        public PostRequestManager()
            : this(new HttpWebRequestFactory(), null, null, null, null, null, null, null) { }

        #endregion

        #region Methods_public

        public string Send(string url)
        {

            Validator.ValidateStringNullOrWhiteSpace(url, nameof(url));

            HttpWebRequest httpWebRequest = CreateHttpWebRequest(url);
            string response = null;

            using (HttpWebResponse httpWebResponse = (HttpWebResponse)httpWebRequest.GetResponse())
            using (Stream responseStream = httpWebResponse.GetResponseStream())
            using (StreamReader reader = new StreamReader(responseStream))
                response = reader.ReadToEnd();

            return response;

        }

        #endregion

        #region Methods_public

        private HttpWebRequest CreateHttpWebRequest(string url)
        {

            HttpWebRequest httpWebRequest = HttpWebRequestFactory.Create(url);
            httpWebRequest.Method = Method;

            if (Headers != null)
                httpWebRequest.Headers = Headers;

            if (!string.IsNullOrWhiteSpace(ContentType))
                httpWebRequest.ContentType = ContentType;

            if (CookieContainer != null)
                httpWebRequest.CookieContainer = CookieContainer;

            if (UserAgent != null)
                httpWebRequest.UserAgent = UserAgent;

            httpWebRequest.ProtocolVersion = ProtocolVersion;

            byte[] postDataBytes = null;
            if (PostData != null)
            {

                postDataBytes = Encode(PostData, PostDataEncoding);
                httpWebRequest.ContentLength = postDataBytes.Length;

            }
            Stream stream = httpWebRequest.GetRequestStream();
            if (PostData != null)
            {

                stream.Write(postDataBytes, 0, postDataBytes.Length);
                stream.Close();
            
            }

            return httpWebRequest;

        }
        private byte[] Encode(string postData, Encoding postDataEncoding)
        {

            if (postDataEncoding == null)
                postDataEncoding = Encoding.ASCII;

            return postDataEncoding.GetBytes(postData);

        }

        #endregion

    }
}

/*
    Author: numbworks@gmail.com
    Last Update: 02.09.2021
*/