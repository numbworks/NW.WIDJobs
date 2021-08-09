using System;

namespace NW.WIDJobs
{
    /// <summary>A <see href="http://www.workindenmark.dk">WorkInDenmark</see>'s job page.</summary>
    public class JobPage
    {

        #region Fields
        #endregion

        #region Properties

        public string RunId { get; }
        public ushort PageNumber { get; }
        public string Response { get; }

        #endregion

        #region Constructors

        ///<summary>Initializes a <see cref="JobPage"/> instance.</summary>
        /// <exception cref="ArgumentNullException"/>
        /// <exception cref="ArgumentException"/> 
        public JobPage
            (string runId, ushort pageNumber, string response)
        {

            Validator.ValidateStringNullOrWhiteSpace(runId, nameof(runId));
            Validator.ThrowIfLessThanOne(pageNumber, nameof(pageNumber));
            Validator.ValidateStringNullOrWhiteSpace(response, nameof(response));

            RunId = runId;
            PageNumber = pageNumber;
            Response = response;

        }

        #endregion

        #region Methods_public
        #endregion

    }
}

/*
    Author: numbworks@gmail.com
    Last Update: 25.06.2021
*/