using System.Net;

namespace NW.WIDJobs
{
    /// <inheritdoc cref="IHttpWebRequestFactory"/>
    public class HttpWebRequestFactory : IHttpWebRequestFactory
    {

        #region Fields
        #endregion

        #region Properties
        #endregion

        #region Constructors

        /// <summary>Initializes a <see cref="HttpWebRequestFactory"/> instance.</summary>
        public HttpWebRequestFactory() { }

        #endregion

        #region Methods_public

        public HttpWebRequest Create(string url)
            => (HttpWebRequest)WebRequest.Create(url);

        #endregion

    }
}

/*
    Author: numbworks@gmail.com
    Last Update: 22.05.2021
*/