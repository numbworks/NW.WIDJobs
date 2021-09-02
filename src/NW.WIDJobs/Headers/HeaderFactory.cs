using System.Net;

namespace NW.WIDJobs.Headers
{
    /// <inheritdoc cref="IHeaderFactory"/>
    public class HeaderFactory : IHeaderFactory
    {

        #region Fields

        #endregion

        #region Properties

        public static string DefaultUserAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64; rv:91.0) Gecko/20100101 Firefox/91.0";

        #endregion

        #region Constructors

        /// <summary>Initializes a <see cref="HeaderFactory"/> instance.</summary>	
        public HeaderFactory() { }

        #endregion

        #region Methods_public

        public WebHeaderCollection Create()
        {

            WebHeaderCollection headers = new WebHeaderCollection();
            headers.Add(HttpRequestHeader.UserAgent, DefaultUserAgent);

            return headers;

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