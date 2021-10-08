using System;
using NW.WIDJobs.Validation;

namespace NW.WIDJobs.JobPostingsExtended
{
    /// <summary>Initializes a bullet point for <see cref="JobPostingExtended"/>.</summary>
    public class BulletPoint
    {

        #region Fields

        #endregion

        #region Properties

        public string Text { get; }
        public string Type { get; }

        #endregion

        #region Constructors

        /// <summary>Initializes a <see cref="BulletPoint"/> instance.</summary>
        /// <exception cref="ArgumentNullException"/>
        public BulletPoint(string text, string type) 
        {

            Validator.ValidateObject(text, nameof(text));

            Text = text;
            Type = type;

        }

        #endregion

        #region Methods_public

        #endregion

        #region Methods_private

        #endregion

    }
}

/*
    Author: numbworks@gmail.com
    Last Update: 08.10.2021
*/