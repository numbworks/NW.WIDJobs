namespace NW.WIDJobsClient.CommandLineValidators
{
    /// <inheritdoc cref="IPauseBetweenRequestsManager"/>
    public class PauseBetweenRequestsManager : IPauseBetweenRequestsManager
    {

        #region Fields

        #endregion

        #region Properties

        #endregion

        #region Constructors

        /// <summary>Initializes a <see cref="PauseBetweenRequestsManager"/> instance.</summary>	
        public PauseBetweenRequestsManager() { }

        #endregion

        #region Methods_public

        public bool IsValid(string value)
        {

            try
            {
                uint pauseBetweenRequests = ParsePauseBetweenRequests(value);

                return true;

            }
            catch
            {

                return false;

            }

        }
        public uint ParsePauseBetweenRequests(string value)
            => uint.Parse(value);

        #endregion

        #region Methods_private

        #endregion

    }
}

/*
    Author: numbworks@gmail.com
    Last Update: 28.08.2021
*/