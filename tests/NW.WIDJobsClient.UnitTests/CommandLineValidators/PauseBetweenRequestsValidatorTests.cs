using NUnit.Framework;
using System;
using NW.WIDJobsClient.CommandLineValidators;

namespace NW.WIDJobsClient.UnitTests
{
    [TestFixture]
    public class PauseBetweenRequestsValidatorTests
    {

        #region Fields

        private static TestCaseData[] pauseBetweenRequestsValidatorExceptionTestCases =
        {

            new TestCaseData(
                new TestDelegate(
                    () => new PauseBetweenRequestsValidator(null)
                ),
                typeof(ArgumentNullException),
                new ArgumentNullException("pauseBetweenRequestsManager").Message
            ).SetArgDisplayNames($"{nameof(pauseBetweenRequestsValidatorExceptionTestCases)}_01")

        };

        #endregion

        #region SetUp

        #endregion

        #region Tests

        [TestCaseSource(nameof(pauseBetweenRequestsValidatorExceptionTestCases))]
        public void PauseBetweenRequestsValidator_ShouldThrowACertainException_WhenUnproperArguments
            (TestDelegate del, Type expectedType, string expectedMessage)
                => ObjectMother.Method_ShouldThrowACertainException_WhenUnproperArguments(del, expectedType, expectedMessage);

        [Test]
        public void PauseBetweenRequestsValidator_ShouldCreateAnObjectOfTypeThresholdValueValidator_WhenInvoked()
        {

            // Arrange
            // Act
            PauseBetweenRequestsValidator actual = new PauseBetweenRequestsValidator();

            // Assert
            Assert.IsInstanceOf<PauseBetweenRequestsValidator>(actual);

        }

        #endregion

        #region TearDown

        #endregion

        #region Support_methods

        #endregion

    }
}

/*
    Author: numbworks@gmail.com
    Last Update: 29.08.2021
*/
