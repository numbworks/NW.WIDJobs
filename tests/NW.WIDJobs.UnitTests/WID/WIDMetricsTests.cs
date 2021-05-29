using NUnit.Framework;
using System;
using System.Collections;
using System.Collections.Generic;

namespace NW.WIDJobs.UnitTests
{
    [TestFixture]
    public class WIDMetricsTests
    {

        // Fields
        private static TestCaseData[] widMetricsExceptionTestCases =
        {

            new TestCaseData(
                new TestDelegate(
                    () => new WIDMetrics(
                                null,
                                ObjectMother.Shared_Page01_TotalResults,
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
                            )
				),
                typeof(ArgumentNullException),
                new ArgumentNullException("runId").Message
            ).SetArgDisplayNames($"{nameof(widMetricsExceptionTestCases)}_01")

        };

        // SetUp
        // Tests
        [TestCaseSource(nameof(widMetricsExceptionTestCases))]
        public void WIDMetrics_ShouldThrowACertainException_WhenUnproperArguments
            (TestDelegate del, Type expectedType, string expectedMessage)
                => ObjectMother.Method_ShouldThrowACertainException_WhenUnproperArguments(del, expectedType, expectedMessage);

    }
}

/*
    Author: numbworks@gmail.com
    Last Update: 28.05.2021
*/