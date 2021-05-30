using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Globalization;

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
        private static TestCaseData[] calculatePercentageTestCases =
        {

            new TestCaseData(
                    (uint)0,
                    (uint)61,
                    (double?)0
            ).SetArgDisplayNames($"{nameof(calculatePercentageTestCases)}_01"),

            new TestCaseData(
                    (uint)45,
                    (uint)0,
                    null
            ).SetArgDisplayNames($"{nameof(calculatePercentageTestCases)}_02")

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

        [TestCaseSource(nameof(calculatePercentageTestCases))]
        public void CalculatePercentage_ShouldReturnExpectedPercentage_WhenInvoked
            (uint value, uint totalValue, double? expected)
        {

            // Arrange
            // Act        
            double? actual = WIDMetricsManager.CalculatePercentage(value, totalValue);

            // Assert
            Assert.AreEqual(expected, actual);

        }

        [Test]
        public void Calculate_ShouldReturnExpectedMetrics_WhenInvoked()
        {

            // Arrange
            // Act        
            WIDMetrics actual = new WIDMetricsManager().Calculate(ObjectMother.WIDExploration_Exploration02);

            // Assert
            Assert.IsTrue(
                ObjectMother.AreEqual(ObjectMother.WIDMetrics_Exploration02_Metrics, actual)
                );

        }

        [Test]
        public void ConvertToPercentages_ShouldReturnExpectedPercentages_WhenInvoked()
        {

            // Arrange
            // Act
            Dictionary<string, string> actual 
                = new WIDMetricsManager().ConvertToPercentages(ObjectMother.WIDMetricsManager_WorkAreas);

            // Assert
            Assert.IsTrue(
                ObjectMother.AreEqual(ObjectMother.WIDMetricsManager_WorkAreasAsPercentages, actual)
                );

        }

        [Test]
        public void FormatPercentage_ShouldReturnExpectedString_WhenInvoked()
        {

            // Arrange
            double value = 73.67;
            CultureInfo culture = CultureInfo.CreateSpecificCulture("en-US");
            string expected = $"{value.ToString(culture)}%";

            // Act
            string actual = WIDMetricsManager.FormatPercentage(value);

            // Assert
            Assert.AreEqual(expected, actual);

        }

    }
}

/*
    Author: numbworks@gmail.com
    Last Update: 30.05.2021
*/
