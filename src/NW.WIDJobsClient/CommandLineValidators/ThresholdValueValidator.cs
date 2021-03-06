using System.ComponentModel.DataAnnotations;
using McMaster.Extensions.CommandLineUtils;
using McMaster.Extensions.CommandLineUtils.Validation;
using NW.WIDJobsClient.Messages;

namespace NW.WIDJobsClient.CommandLineValidators
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
        /// <exception cref="ArgumentNullException"/>
        public ThresholdValueValidator(IThresholdValueManager thresholdValueManager) 
        {

            WIDJobs.Validation.Validator.ValidateObject(thresholdValueManager, nameof(thresholdValueManager));

            _thresholdValueManager = thresholdValueManager;

        }

        /// <summary>Initializes a <see cref="ThresholdValueValidator"/> instance with default parameters.</summary>	
        public ThresholdValueValidator()
            : this(new ThresholdValueManager()) { }

        #endregion

        #region Methods_public

        public ValidationResult GetValidationResult(CommandOption option, ValidationContext context)
        {

            if (_thresholdValueManager.IsValid(option.Value()))
                return ValidationResult.Success;

            return new ValidationResult(MessageCollection.ThresholdValueValidator_ThresholdValueNotValidFormat.Invoke(option.Value()));

        }

        #endregion

        #region Methods_private

        #endregion

    }
}

/*
    Author: numbworks@gmail.com
    Last Update: 08.10.2021
*/