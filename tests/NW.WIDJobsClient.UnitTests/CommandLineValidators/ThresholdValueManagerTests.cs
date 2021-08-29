using NUnit.Framework;
using System;
using NW.WIDJobsClient.CommandLineValidators;

namespace NW.WIDJobsClient.UnitTests
{
    [TestFixture]
    public class ThresholdValueManagerTests
    {

        #region Fields

        private static TestCaseData[] thresholdValueValidatorExceptionTestCases =
        {

            new TestCaseData(
                new TestDelegate(
                    () => new ThresholdValueValidator(null)
                ),
                typeof(ArgumentNullException),
                new ArgumentNullException("thresholdValueManager").Message
            ).SetArgDisplayNames($"{nameof(thresholdValueValidatorExceptionTestCases)}_01")

        };

        #endregion

        #region SetUp

        #endregion

        #region Tests

        [TestCaseSource(nameof(thresholdValueValidatorExceptionTestCases))]
        public void ThresholdValueValidator_ShouldThrowACertainException_WhenUnproperArguments
            (TestDelegate del, Type expectedType, string expectedMessage)
                => ObjectMother.Method_ShouldThrowACertainException_WhenUnproperArguments(del, expectedType, expectedMessage);

        [Test]
        public void ThresholdValueValidator_ShouldCreateAnObjectOfTypeThresholdValueValidator_WhenInvoked()
        {

            // Arrange
            // Act
            ThresholdValueValidator actual = new ThresholdValueValidator();

            // Assert
            Assert.IsInstanceOf<ThresholdValueValidator>(actual);

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
