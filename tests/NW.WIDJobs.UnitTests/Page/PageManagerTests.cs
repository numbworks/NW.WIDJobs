using System;
using NUnit.Framework;

namespace NW.WIDJobs.UnitTests
{
    [TestFixture]
    public class PageManagerTests
    {

        // Fields
        private static TestCaseData[] pageManagerExceptionTestCases =
        {

            new TestCaseData(
                new TestDelegate(
                    () => new PageManager(null, new PageScraper())
                ),
                typeof(ArgumentNullException),
                new ArgumentNullException("getRequestManager").Message
            ).SetArgDisplayNames($"{nameof(pageManagerExceptionTestCases)}_01"),

            new TestCaseData(
                new TestDelegate(
                    () => new PageManager(new GetRequestManager(), null)
                ),
                typeof(ArgumentNullException),
                new ArgumentNullException("pageScraper").Message
            ).SetArgDisplayNames($"{nameof(pageManagerExceptionTestCases)}_02")

        };
        private static TestCaseData[] getPageExceptionTestCases =
        {

            new TestCaseData(
                new TestDelegate(
                    () => new PageManager().GetPage(null, 1)
                ),
                typeof(ArgumentNullException),
                new ArgumentNullException("runId").Message
            ).SetArgDisplayNames($"{nameof(getPageExceptionTestCases)}_01"),

            new TestCaseData(
                new TestDelegate(
                    () => new PageManager().GetPage(ObjectMother.Shared_FakeRunId, 0)
                ),
                typeof(ArgumentException),
                MessageCollection.Validator_VariableCantBeLessThanOne.Invoke("pageNumber")
            ).SetArgDisplayNames($"{nameof(getPageExceptionTestCases)}_02")

        };
        private static TestCaseData[] getTotalResultsExceptionTestCases =
        {

            new TestCaseData(
                new TestDelegate(
                    () => new PageManager().GetTotalResults(null)
                ),
                typeof(ArgumentNullException),
                new ArgumentNullException("content").Message
            ).SetArgDisplayNames($"{nameof(getTotalResultsExceptionTestCases)}_01")

        };
        private static TestCaseData[] getContentExceptionTestCases =
        {

            new TestCaseData(
                new TestDelegate(
                    () => new PageManager().GetContent(null)
                ),
                typeof(ArgumentNullException),
                new ArgumentNullException("url").Message
            ).SetArgDisplayNames($"{nameof(getContentExceptionTestCases)}_01")

        };
        private static TestCaseData[] getTotalEstimatedPagesTestCases =
        {

            new TestCaseData(
                    (uint)0,
                    (ushort)0
                ).SetArgDisplayNames($"{nameof(getTotalEstimatedPagesTestCases)}_01"),

            new TestCaseData(
                    (uint)1,
                    (ushort)1
                ).SetArgDisplayNames($"{nameof(getTotalEstimatedPagesTestCases)}_02"),

            new TestCaseData(
                    (uint)20,
                    (ushort)1
                ).SetArgDisplayNames($"{nameof(getTotalEstimatedPagesTestCases)}_03"),

            new TestCaseData(
                    (uint)22,
                    (ushort)2
                ).SetArgDisplayNames($"{nameof(getTotalEstimatedPagesTestCases)}_04"),

            new TestCaseData(
                    (uint)2000,
                    (ushort)100
                ).SetArgDisplayNames($"{nameof(getTotalEstimatedPagesTestCases)}_05")

        };

        // SetUp
        // Tests       
        [TestCaseSource(nameof(pageManagerExceptionTestCases))]
        public void PageManager_ShouldThrowACertainException_WhenUnproperArguments
            (TestDelegate del, Type expectedType, string expectedMessage)
                => ObjectMother.Method_ShouldThrowACertainException_WhenUnproperArguments(del, expectedType, expectedMessage);

        [TestCaseSource(nameof(getPageExceptionTestCases))]
        public void GetPage_ShouldThrowACertainException_WhenUnproperArguments
            (TestDelegate del, Type expectedType, string expectedMessage)
                => ObjectMother.Method_ShouldThrowACertainException_WhenUnproperArguments(del, expectedType, expectedMessage);

        [TestCaseSource(nameof(getTotalResultsExceptionTestCases))]
        public void GetTotalResults_ShouldThrowACertainException_WhenUnproperArguments
            (TestDelegate del, Type expectedType, string expectedMessage)
                => ObjectMother.Method_ShouldThrowACertainException_WhenUnproperArguments(del, expectedType, expectedMessage);

        [TestCaseSource(nameof(getTotalResultsExceptionTestCases))]
        public void GetTotal_ShouldThrowACertainException_WhenUnproperArguments
            (TestDelegate del, Type expectedType, string expectedMessage)
                => ObjectMother.Method_ShouldThrowACertainException_WhenUnproperArguments(del, expectedType, expectedMessage);

        [TestCaseSource(nameof(getTotalEstimatedPagesTestCases))]
        public void GetTotalEstimatedPages_ShouldReturnExpectedTotalEstimatedPages_WhenInvoked
            (uint totalResults, ushort expected)
        {

            // Arrange
            // Act
            ushort actual = new PageManager().GetTotalEstimatedPages(totalResults);

            // Assert
            Assert.AreEqual(expected, actual);

        }

        // TearDown		

    }
}

/*
    Author: numbworks@gmail.com
    Last Update: 15.05.2021
*/