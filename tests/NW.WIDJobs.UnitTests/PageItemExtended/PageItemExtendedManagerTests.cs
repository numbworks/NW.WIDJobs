using System;
using NUnit.Framework;

namespace NW.WIDJobs.UnitTests
{
    [TestFixture]
    public class PageItemExtendedManagerTests
    {

        // Fields
        private static TestCaseData[] getTestCases =
        {

            new TestCaseData(
                    ObjectMother.PageItemExtendedManager_FakeGetRequestManager.Invoke(ObjectMother.Shared_Page01_PageItemExtended01.PageItem.Url),
                    ObjectMother.Shared_Page01_PageItem01,
                    ObjectMother.Shared_Page01_PageItemExtended01
                ).SetArgDisplayNames($"{nameof(getTestCases)}_01"),

            new TestCaseData(
                    ObjectMother.PageItemExtendedManager_FakeGetRequestManager.Invoke(ObjectMother.Shared_Page01_PageItemExtended14.PageItem.Url),
                    ObjectMother.Shared_Page01_PageItem14,
                    ObjectMother.Shared_Page01_PageItemExtended14
                ).SetArgDisplayNames($"{nameof(getTestCases)}_02"),

            new TestCaseData(
                    ObjectMother.PageItemExtendedManager_FakeGetRequestManager.Invoke(ObjectMother.Shared_Page02_PageItemExtended18.PageItem.Url),
                    ObjectMother.Shared_Page02_PageItem18,
                    ObjectMother.Shared_Page02_PageItemExtended18
                ).SetArgDisplayNames($"{nameof(getTestCases)}_03"),

            new TestCaseData(
                    ObjectMother.PageItemExtendedManager_FakeGetRequestManager.Invoke(ObjectMother.Shared_Page03_PageItemExtended01.PageItem.Url),
                    ObjectMother.Shared_Page03_PageItem01,
                    ObjectMother.Shared_Page03_PageItemExtended01
                ).SetArgDisplayNames($"{nameof(getTestCases)}_04"),

            new TestCaseData(
                    ObjectMother.PageItemExtendedManager_FakeGetRequestManager.Invoke(ObjectMother.Shared_Page03_PageItemExtended02.PageItem.Url),
                    ObjectMother.Shared_Page03_PageItem02,
                    ObjectMother.Shared_Page03_PageItemExtended02
                ).SetArgDisplayNames($"{nameof(getTestCases)}_05"),

            new TestCaseData(
                    ObjectMother.PageItemExtendedManager_FakeGetRequestManager.Invoke(ObjectMother.Shared_Page03_PageItemExtended03.PageItem.Url),
                    ObjectMother.Shared_Page03_PageItem03,
                    ObjectMother.Shared_Page03_PageItemExtended03
                ).SetArgDisplayNames($"{nameof(getTestCases)}_06"),

            new TestCaseData(
                    ObjectMother.PageItemExtendedManager_FakeGetRequestManager.Invoke(ObjectMother.Shared_Page03_PageItemExtended04.PageItem.Url),
                    ObjectMother.Shared_Page03_PageItem04,
                    ObjectMother.Shared_Page03_PageItemExtended04
                ).SetArgDisplayNames($"{nameof(getTestCases)}_07")

        };
        private static TestCaseData[] pageItemExtendedManagerExceptionTestCases =
        {

            new TestCaseData(
                new TestDelegate(
                    () => new PageItemExtendedManager(null, new PageItemExtendedScraper())
                ),
                typeof(ArgumentNullException),
                new ArgumentNullException("getRequestManager").Message
            ).SetArgDisplayNames($"{nameof(pageItemExtendedManagerExceptionTestCases)}_01"),

            new TestCaseData(
                new TestDelegate(
                    () => new PageItemExtendedManager(new GetRequestManager(), null)
                ),
                typeof(ArgumentNullException),
                new ArgumentNullException("pageItemExtendedScraper").Message
            ).SetArgDisplayNames($"{nameof(pageItemExtendedManagerExceptionTestCases)}_02")

        };
        private static TestCaseData[] getExceptionTestCases =
        {

            new TestCaseData(
                new TestDelegate(
                    () => new PageItemExtendedManager().Get(null)
                ),
                typeof(ArgumentNullException),
                new ArgumentNullException("pageItem").Message
            ).SetArgDisplayNames($"{nameof(getExceptionTestCases)}_01")

        };
        private static TestCaseData[] getContentExceptionTestCases =
        {

            new TestCaseData(
                new TestDelegate(
                    () => new PageItemExtendedManager().GetContent(null)
                ),
                typeof(ArgumentNullException),
                new ArgumentNullException("url").Message
            ).SetArgDisplayNames($"{nameof(getContentExceptionTestCases)}_01")

        };

        // SetUp
        // Tests
        [TestCaseSource(nameof(getTestCases))]
        public void Get_ShouldReturnExpectedPageItemExtendedObject_WhenInvoked
            (IGetRequestManager getRequestManager, PageItem pageItem, PageItemExtended expected)
        {

            // Arrange
            PageItemExtendedManager pageItemExtendedManager
                = new PageItemExtendedManager(getRequestManager, new PageItemExtendedScraper());

            // Act
            PageItemExtended actual = pageItemExtendedManager.Get(pageItem);

            // Assert
            Assert.IsTrue(
                    ObjectMother.AreEqual(expected, actual));

        }

        [TestCaseSource(nameof(pageItemExtendedManagerExceptionTestCases))]
        public void PageItemExtendedManager_ShouldThrowACertainException_WhenUnproperArguments
            (TestDelegate del, Type expectedType, string expectedMessage)
                => ObjectMother.Method_ShouldThrowACertainException_WhenUnproperArguments(del, expectedType, expectedMessage);

        [TestCaseSource(nameof(getExceptionTestCases))]
        public void Get_ShouldThrowACertainException_WhenUnproperArguments
            (TestDelegate del, Type expectedType, string expectedMessage)
                => ObjectMother.Method_ShouldThrowACertainException_WhenUnproperArguments(del, expectedType, expectedMessage);

        [TestCaseSource(nameof(getContentExceptionTestCases))]
        public void GetContent_ShouldThrowACertainException_WhenUnproperArguments
            (TestDelegate del, Type expectedType, string expectedMessage)
                => ObjectMother.Method_ShouldThrowACertainException_WhenUnproperArguments(del, expectedType, expectedMessage);

    }
}

/*
    Author: numbworks@gmail.com
    Last Update: 15.05.2021
*/
