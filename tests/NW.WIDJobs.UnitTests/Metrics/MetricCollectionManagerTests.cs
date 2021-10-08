using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Globalization;
using NW.WIDJobs.Metrics;

namespace NW.WIDJobs.UnitTests
{
    [TestFixture]
    public class MetricCollectionManagerTests
    {

        #region Fields

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
            ).SetArgDisplayNames($"{nameof(calculateExceptionTestCases)}_02")

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

        #endregion

        #region SetUp
        #endregion

        #region Tests

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
        public void TryConvertToPercentages_ShouldReturnNull_WhenDictionaryIsNull()
        {

            // Arrange
            // Act
            Dictionary<string, string> actual
                = new MetricCollectionManager().TryConvertToPercentages(null);

            // Assert
            Assert.IsTrue(
                ObjectMother.AreEqual(null, actual)
                );

        }

        [Test]
        public void TryConvertToPercentages_ShouldReturnExpectedPercentages_WhenProperDictionary()
        {

            // Arrange
            // Act
            Dictionary<string, string> actual
                = new MetricCollectionManager().TryConvertToPercentages(ObjectMother.MetricCollectionManager_WorkPlaceCityWithoutZones);

            // Assert
            Assert.IsTrue(
                ObjectMother.AreEqual(ObjectMother.MetricCollectionManager_WorkPlaceCityWithoutZonesAsPercentages, actual)
                );

        }

        [TestCaseSource(nameof(calculateExceptionTestCases))]
        public void Calculate_ShouldThrowACertainException_WhenUnproperArguments
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
        public void Calculate_ShouldReturnExpectedMetrics_WhenExplorationStage3()
        {

            // Arrange
            // Act        
            MetricCollection actual = new MetricCollectionManager().Calculate(ObjectMother.Shared_ExplorationStage3);

            // Assert
            Assert.IsTrue(
                ObjectMother.AreEqual(ObjectMother.MetricCollection_ExplorationStage3, actual)
                );

        }

        [Test]
        public void Calculate_ShouldReturnExpectedMetrics_WhenExplorationStage2()
        {

            // Arrange
            // Act        
            MetricCollection actual = new MetricCollectionManager().Calculate(ObjectMother.Shared_ExplorationStage2);

            // Assert
            Assert.IsTrue(
                ObjectMother.AreEqual(ObjectMother.MetricCollection_ExplorationStage2, actual)
                );

        }

        [Test]
        public void TrySumBulletPoints_ShouldReturnNull_WhenExplorationIsNull()
        {

            // Arrange
            // Act
            uint? actual = new MetricCollectionManager().TrySumBulletPoints(null);

            // Assert
            Assert.AreEqual(null, actual);

        }

        [Test]
        public void TrySumBulletPoints_ShouldReturnExpectedValue_WhenExplorationStage3()
        {

            // Arrange
            // Act
            uint? actual = new MetricCollectionManager().TrySumBulletPoints(ObjectMother.Shared_ExplorationStage3);

            // Assert
            Assert.AreEqual(ObjectMother.Shared_ExplorationStage3_TotalBulletPoints, actual);

        }

        #endregion

        #region TearDown
        #endregion

    }
}

/*
    Author: numbworks@gmail.com
    Last Update: 08.10.2021
*/
