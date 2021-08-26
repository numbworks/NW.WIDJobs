using System;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Text.RegularExpressions;
using McMaster.Extensions.CommandLineUtils;
using McMaster.Extensions.CommandLineUtils.Validation;
using NW.WIDJobsClient.Messages;

namespace NW.WIDJobsClient
{
    /// <inheritdoc cref="IOptionValidator"/>
    public class ThresholdValidator : IOptionValidator
    {

        #region Fields

        #endregion

        #region Properties

        public uint MininumPageNumber { get; } = 1;
        public static string DateFormat { get; } = "yyyyMMdd";
        public static string JobPostingIdPattern = "[0-9]{1,}[a-zA-Z]{1,}";

        #endregion

        #region Constructors

        /// <summary>Initializes a <see cref="ThresholdValidator"/> instance.</summary>	
        public ThresholdValidator() { }

        #endregion

        #region Methods_public

        public ValidationResult GetValidationResult(CommandOption option, ValidationContext context)
        {

            // PageNumber: 1, 2, ...
            // Date: 20210722
            // JobPostingId: 5376524visgerrengringsassistenter

            if (IsValidPageNumber(option.Value()))
                return ValidationResult.Success;

            if (IsValidDate(option.Value()))
                return ValidationResult.Success;

            if (IsValidJobPostingId(option.Value()))
                return ValidationResult.Success;

            return new ValidationResult(MessageCollection.ThresholdValidator_ThresholdValueNotValidFormat.Invoke(option.Value()));

        }

        #endregion

        #region Methods_private

        private bool IsValidPageNumber(string value)
        {

            try
            {

                int pageNumber = int.Parse(value);

                if (pageNumber < MininumPageNumber)
                    return false;

                return true;

            }
            catch
            {

                return false;

            }

        }
        private bool IsValidDate(string value)
        {

            try 
            {

                DateTime date = DateTime.ParseExact(value, DateFormat, CultureInfo.InvariantCulture);

                return true;

            }
            catch
            {

                return false;

            }

        }
        private bool IsValidJobPostingId(string value)
        {

            return Regex.IsMatch(value, JobPostingIdPattern);

        }

        #endregion

    }
}

/*
    Author: numbworks@gmail.com
    Last Update: 26.08.2021
*/