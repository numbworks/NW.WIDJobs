using NUnit.Framework;
using System;

namespace NW.WIDJobs.UnitTests
{
    [TestFixture]
    public class WIDMetricsManagerTests
    {

        // Fields
        private static TestCaseData[] calculateExceptionTestCases =
        {

            new TestCaseData(
                new TestDelegate(
                    () => new WIDMetricsManager().Calculate(null)
                ),
                typeof(ArgumentNullException),
                new ArgumentNullException("exploration").Message
            ).SetArgDisplayNames($"{nameof(calculateExceptionTestCases)}_01"),

            new TestCaseData(
                new TestDelegate(
                    () => new WIDMetricsManager().Calculate(ObjectMother.WIDMetricsManager_ExplorationWithNullPageItems)
                ),
                typeof(ArgumentNullException),
                new ArgumentNullException("PageItems").Message
            ).SetArgDisplayNames($"{nameof(calculateExceptionTestCases)}_02"),

            new TestCaseData(
                new TestDelegate(
                    () => new WIDMetricsManager().Calculate(ObjectMother.WIDMetricsManager_ExplorationWithNullPageItemsExtended)
                ),
                typeof(ArgumentNullException),
                new ArgumentNullException("PageItemsExtended").Message
            ).SetArgDisplayNames($"{nameof(calculateExceptionTestCases)}_03")

        };
        private static TestCaseData[] convertToPercentagesExceptionTestCases =
        {


            new TestCaseData(
                new TestDelegate(
                    () => new WIDMetricsManager().ConvertToPercentages(null)
                ),
                typeof(ArgumentNullException),
                new ArgumentNullException("dict").Message
            ).SetArgDisplayNames($"{nameof(convertToPercentagesExceptionTestCases)}_01")


        };

        // SetUp
        // Tests
        [TestCaseSource(nameof(calculateExceptionTestCases))]
        public void Calculate_ShouldThrowACertainException_WhenUnproperArguments
            (TestDelegate del, Type expectedType, string expectedMessage)
                => ObjectMother.Method_ShouldThrowACertainException_WhenUnproperArguments(del, expectedType, expectedMessage);

        [TestCaseSource(nameof(convertToPercentagesExceptionTestCases))]
        public void ConvertToPercentages_ShouldThrowACertainException_WhenUnproperArguments
            (TestDelegate del, Type expectedType, string expectedMessage)
                => ObjectMother.Method_ShouldThrowACertainException_WhenUnproperArguments(del, expectedType, expectedMessage);

        [Test]
        public void Calculate_Should_When()
        {

            // Arrange
            // Act
            // Assert

        }

    }
}

/*
    Author: numbworks@gmail.com
    Last Update: 30.05.2021
*/
