using System;
using System.ComponentModel.DataAnnotations;
using McMaster.Extensions.CommandLineUtils;
using McMaster.Extensions.CommandLineUtils.Validation;
using NW.WIDJobsClient.Messages;

namespace NW.WIDJobsClient
{
    /// <inheritdoc cref="IOptionValidator"/>
    public class ThresholdValueValidator : IOptionValidator
    {

        #region Fields

        IThresholdValueManager _thresholdValueManager;

        #endregion

        #region Properties

        #endregion

        #region Constructors

        /// <summary>Initializes a <see cref="ThresholdValueValidator"/> instance.</summary>	
        public ThresholdValueValidator(IThresholdValueManager thresholdValueManager) 
        {

            // To-Do: validation

            _thresholdValueManager = thresholdValueManager;

        }

        /// <summary>Initializes a <see cref="ThresholdValueValidator"/> instance with default parameters.</summary>	
        public ThresholdValueValidator()
            : this(new ThresholdValueManager()) { }

        #endregion

        #region Methods_public

        public ValidationResult GetValidationResult(CommandOption option, ValidationContext context)
        {

            // PageNumber: 1, 2, ...
            // Date: 20210722
            // JobPostingId: 5376524visgerrengringsassistenter

            if (_thresholdValueManager.IsValidFinalPageNumber(option.Value()))
                return ValidationResult.Success;

            if (_thresholdValueManager.IsValidThresholdDate(option.Value()))
                return ValidationResult.Success;

            if (_thresholdValueManager.IsValidJobPostingId(option.Value()))
                return ValidationResult.Success;

            return new ValidationResult(MessageCollection.ThresholdValidator_ThresholdValueNotValidFormat.Invoke(option.Value()));

        }

        #endregion

        #region Methods_private

        #endregion

    }
}

/*
    Author: numbworks@gmail.com
    Last Update: 27.08.2021
*/