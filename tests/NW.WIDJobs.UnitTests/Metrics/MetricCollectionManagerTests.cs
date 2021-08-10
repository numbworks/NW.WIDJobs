﻿using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Globalization;

namespace NW.WIDJobs.UnitTests
{
    [TestFixture]
    public class MetricCollectionManagerTests
    {

        // Fields
        private static TestCaseData[] calculateExceptionTestCases =
        {

            new TestCaseData(
                new TestDelegate(
                    () => new MetricCollectionManager().Calculate(null)
                ),
                typeof(ArgumentNullException),
                new ArgumentNullException("exploration").Message
            ).SetArgDisplayNames($"{nameof(calculateExceptionTestCases)}_01"),

            new TestCaseData(
                new TestDelegate(
                    () => new MetricCollectionManager().Calculate(ObjectMother.Shared_ExplorationStage3WithNullJobPostings)
                ),
                typeof(ArgumentNullException),
                new ArgumentNullException("JobPostings").Message
            ).SetArgDisplayNames($"{nameof(calculateExceptionTestCases)}_02"),

            new TestCaseData(
                new TestDelegate(
                    () => new MetricCollectionManager().Calculate(ObjectMother.Shared_ExplorationStage3WithNullJobPostingsExtended)
                ),
                typeof(ArgumentNullException),
                new ArgumentNullException("JobPostingsExtended").Message
            ).SetArgDisplayNames($"{nameof(calculateExceptionTestCases)}_03")

        };
        private static TestCaseData[] convertToPercentagesExceptionTestCases =
        {


            new TestCaseData(
                new TestDelegate(
                    () => new MetricCollectionManager().ConvertToPercentages(null)
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
            ).SetArgDisplayNames($"{nameof(calculatePercentageTestCases)}_02"),

            new TestCaseData(
                    (uint)1,
                    (uint)1,
                    (double?)100
            ).SetArgDisplayNames($"{nameof(calculatePercentageTestCases)}_03"),

            new TestCaseData(
                    (uint)5,
                    (uint)10,
                    (double?)50
            ).SetArgDisplayNames($"{nameof(calculatePercentageTestCases)}_04")

        };

        // SetUp
        // Tests
        [Test]
        public void FormatPercentage_ShouldReturnExpectedString_WhenInvoked()
        {

            // Arrange
            double value = 73.67;
            CultureInfo culture = CultureInfo.CreateSpecificCulture("en-US");
            string expected = $"{value.ToString(culture)}%";

            // Act
            string actual = MetricCollectionManager.FormatPercentage(value);

            // Assert
            Assert.AreEqual(expected, actual);

        }

        [Test]
        public void ConvertToPercentages_ShouldReturnExpectedPercentages_WhenInvoked()
        {

            // Arrange
            // Act
            Dictionary<string, string> actual
                = new MetricCollectionManager().ConvertToPercentages(ObjectMother.MetricCollectionManager_WorkPlaceCityWithoutZones);

            // Assert
            Assert.IsTrue(
                ObjectMother.AreEqual(ObjectMother.MetricCollectionManager_WorkPlaceCityWithoutZonesAsPercentages, actual)
                );

        }

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
            double? actual = MetricCollectionManager.CalculatePercentage(value, totalValue);

            // Assert
            Assert.AreEqual(expected, actual);

        }

        [Test]
        public void Calculate_ShouldReturnExpectedMetrics_WhenInvoked()
        {

            // Arrange
            // Act        
            MetricCollection actual = new MetricCollectionManager().Calculate(ObjectMother.Shared_ExplorationStage3);

            // Assert
            Assert.IsTrue(
                ObjectMother.AreEqual(ObjectMother.MetricCollection_ExplorationStage3, actual)
                );

        }

    }
}

/*
    Author: numbworks@gmail.com
    Last Update: 09.08.2021
*/