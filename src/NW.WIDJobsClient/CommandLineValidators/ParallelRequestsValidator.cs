using System.ComponentModel.DataAnnotations;
using McMaster.Extensions.CommandLineUtils;
using McMaster.Extensions.CommandLineUtils.Validation;
using NW.WIDJobsClient.Messages;

namespace NW.WIDJobsClient.CommandLineValidators
{
    /// <inheritdoc cref="IOptionValidator"/>
    public class ParallelRequestsValidator : IOptionValidator
    {

        #region Fields

        IParallelRequestsManager _parallelRequestsManager;

        #endregion

        #region Properties

        #endregion

        #region Constructors

        /// <summary>Initializes a <see cref="ParallelRequestsValidator"/> instance.</summary>	
        public ParallelRequestsValidator(IParallelRequestsManager parallelRequestsManager)
        {

            WIDJobs.Validation.Validator.ValidateObject(parallelRequestsManager, nameof(parallelRequestsManager));

            _parallelRequestsManager = parallelRequestsManager;

        }

        /// <summary>Initializes a <see cref="ParallelRequestsValidator"/> instance with default parameters.</summary>	
        public ParallelRequestsValidator()
            : this(new ParallelRequestsManager()) { }

        #endregion

        #region Methods_public

        public ValidationResult GetValidationResult(CommandOption option, ValidationContext context)
        {

            if (_parallelRequestsManager.IsWithinRange(option.Value()))
                return ValidationResult.Success;

            return new ValidationResult(MessageCollection.ParallelRequestsValidator_ValueNotInExpectedRange.Invoke(option.Value()));

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