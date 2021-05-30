using NUnit.Framework;
using System;
using System.Collections.Generic;

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
            WIDMetrics WIDMetrics_Exploration02_Metrics =
                new WIDMetrics(
                        ObjectMother.WIDExploration_Exploration01_RunId,
                        (uint)ObjectMother.Shared_Pages_Page01.Count,
                        (uint)ObjectMother.Shared_Page01_PageItems.Count,
                        ObjectMother.WIDMetrics_Page01_ItemsByWorkAreaWithoutZone,
                        ObjectMother.WIDMetrics_Page01_ItemsByCreateDate,
                        ObjectMother.WIDMetrics_Page01_ItemsByApplicationDate,
                        ObjectMother.WIDMetrics_Page01_ItemsByEmployerName,
                        ObjectMother.WIDMetrics_Page01_ItemsByNumberOfOpenings,
                        ObjectMother.WIDMetrics_Page01_ItemsByAdvertisementPublishDate,
                        ObjectMother.WIDMetrics_Page01_ItemsByApplicationDeadline,
                        ObjectMother.WIDMetrics_Page01_ItemsByStartDateOfEmployment,
                        ObjectMother.WIDMetrics_Page01_ItemsByReference,
                        ObjectMother.WIDMetrics_Page01_ItemsByPosition,
                        ObjectMother.WIDMetrics_Page01_ItemsByTypeOfEmployment,
                        ObjectMother.WIDMetrics_Page01_ItemsByContact,
                        ObjectMother.WIDMetrics_Page01_ItemsByEmployerAddress,
                        ObjectMother.WIDMetrics_Page01_ItemsByHowToApply,
                        ObjectMother.WIDMetrics_Page01_DescriptionLengthByPageItemId,
                        ObjectMother.WIDMetrics_Page01_BulletPointsByPageItemId,
                        ObjectMother.WIDMetrics_Page01_TotalBulletPoints
                    );

            // Act        
            WIDMetrics actual = new WIDMetricsManager().Calculate(ObjectMother.WIDExploration_Exploration02);

            // Assert
            Assert.IsTrue(
                ObjectMother.AreEqual(WIDMetrics_Exploration02_Metrics, actual)
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

    }
}

/*
    Author: numbworks@gmail.com
    Last Update: 30.05.2021
*/
