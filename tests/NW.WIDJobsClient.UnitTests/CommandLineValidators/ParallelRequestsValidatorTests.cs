using NUnit.Framework;
using System;
using NW.WIDJobsClient.CommandLineValidators;

namespace NW.WIDJobsClient.UnitTests
{
    [TestFixture]
    public class ParallelRequestsValidatorTests
    {

        #region Fields

        private static TestCaseData[] parallelRequestsValidatorExceptionTestCases =
        {

            new TestCaseData(
                new TestDelegate(
                    () => new ParallelRequestsValidator(null)
                ),
                typeof(ArgumentNullException),
                new ArgumentNullException("parallelRequestsManager").Message
            ).SetArgDisplayNames($"{nameof(parallelRequestsValidatorExceptionTestCases)}_01")

        };

        #endregion

        #region SetUp

        #endregion

        #region Tests

        [TestCaseSource(nameof(parallelRequestsValidatorExceptionTestCases))]
        public void ParallelRequestsValidator_ShouldThrowACertainException_WhenUnproperArguments
            (TestDelegate del, Type expectedType, string expectedMessage)
                => ObjectMother.Method_ShouldThrowACertainException_WhenUnproperArguments(del, expectedType, expectedMessage);

        [Test]
        public void ParallelRequestsValidator_ShouldCreateAnObjectOfTypeThresholdValueValidator_WhenInvoked()
        {

            // Arrange
            // Act
            ParallelRequestsValidator actual = new ParallelRequestsValidator();

            // Assert
            Assert.IsInstanceOf<ParallelRequestsValidator>(actual);

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
