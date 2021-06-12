using System;

namespace NW.WIDJobs
{
    /// <summary>A labeled bullet point.</summary>
    public class BulletPoint
    {

        #region Fields
        #endregion

        #region Properties

        public string Label { get; }
        public string Text { get; }

        #endregion

        #region Constructors

        /// <summary>Initializes a <see cref="BulletPoint"/> instance.</summary>
        /// <exception cref="ArgumentNullException"/>
        public BulletPoint(string label, string text)
        {

            Validator.ValidateStringNullOrWhiteSpace(label, nameof(label));
            Validator.ValidateStringNullOrWhiteSpace(text, nameof(text));

            Label = label;
            Text = text;

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