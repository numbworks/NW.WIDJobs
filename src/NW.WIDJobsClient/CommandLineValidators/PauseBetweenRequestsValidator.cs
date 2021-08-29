using System.ComponentModel.DataAnnotations;
using McMaster.Extensions.CommandLineUtils;
using McMaster.Extensions.CommandLineUtils.Validation;
using NW.WIDJobsClient.Messages;
using NW.WIDJobs.Validation;

namespace NW.WIDJobsClient.CommandLineValidators
{
    /// <inheritdoc cref="IOptionValidator"/>
    public class PauseBetweenRequestsValidator : IOptionValidator
    {

        #region Fields

        IPauseBetweenRequestsManager _pauseBetweenRequestsManager;

        #endregion

        #region Properties

        #endregion

        #region Constructors

        /// <summary>Initializes a <see cref="PauseBetweenRequestsValidator"/> instance.</summary>	
        public PauseBetweenRequestsValidator(IPauseBetweenRequestsManager pauseBetweenRequestsManager)
        {

            WIDJobs.Validation.Validator.ValidateObject(pauseBetweenRequestsManager, nameof(pauseBetweenRequestsManager));

            _pauseBetweenRequestsManager = pauseBetweenRequestsManager;

        }

        /// <summary>Initializes a <see cref="PauseBetweenRequestsValidator"/> instance with default parameters.</summary>	
        public PauseBetweenRequestsValidator()
            : this(new PauseBetweenRequestsManager()) { }

        #endregion

        #region Methods_public

        public ValidationResult GetValidationResult(CommandOption option, ValidationContext context)
        {

            if (_pauseBetweenRequestsManager.IsValid(option.Value()))
                return ValidationResult.Success;

            return new ValidationResult(MessageCollection.PauseBetweenRequestsValidator_ValueNotValid.Invoke(option.Value()));

        }

        #endregion

        #region Methods_private

        #endregion

    }
}

/*
    Author: numbworks@gmail.com
    Last Update: 28.08.2021
*/