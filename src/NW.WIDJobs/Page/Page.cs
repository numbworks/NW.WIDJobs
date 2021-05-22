using System;

namespace NW.WIDJobs
{
    /// <summary>A <see href="http://www.workindenmark.dk">WorkInDenmark</see>'s page.</summary>
    public class Page
    {

        #region Fields
        #endregion

        #region Properties

        public string RunId { get; }
        public ushort PageNumber { get; }
        public string Content { get; }

        #endregion

        #region Constructors

        ///<summary>Initializes a <see cref="Page"/> instance.</summary>
        /// <exception cref="ArgumentNullException"/>
        /// <exception cref="ArgumentException"/> 
        public Page
            (string runId, ushort pageNumber, string content)
        {

            Validator.ValidateStringNullOrWhiteSpace(runId, nameof(runId));
            Validator.ThrowIfLessThanOne(pageNumber, nameof(pageNumber));
            Validator.ValidateStringNullOrWhiteSpace(content, nameof(content));

            RunId = runId;
            PageNumber = pageNumber;
            Content = content;

        }

        #endregion

        #region Methods_public
        #endregion

    }
}

/*
    Author: numbworks@gmail.com
    Last Update: 09.05.2021
*/