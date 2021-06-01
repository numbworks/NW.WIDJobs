using NUnit.Framework;
using System;

namespace NW.WIDJobs.UnitTests
{
    [TestFixture]
    public class PageItemExtendedScraperTests
    {

        // Fields
        private static TestCaseData[] pageItemExtendedScraperExceptionTestCases =
        {

            new TestCaseData(
                new TestDelegate(
                    () => new PageItemExtendedScraper(null, new PageItemScraperHelper())
                ),
                typeof(ArgumentNullException),
                new ArgumentNullException("xpathManager").Message
            ).SetArgDisplayNames($"{nameof(pageItemExtendedScraperExceptionTestCases)}_01"),

            new TestCaseData(
                new TestDelegate(
                    () => new PageItemExtendedScraper(new XPathManager(), null)
                ),
                typeof(ArgumentNullException),
                new ArgumentNullException("scraperHelper").Message
            ).SetArgDisplayNames($"{nameof(pageItemExtendedScraperExceptionTestCases)}_02")

        };
        private static TestCaseData[] doTestCases =
        {

            new TestCaseData(
                    ObjectMother.Shared_Page01_PageItem01,
                    ObjectMother.Shared_Page01_PageItemExtended01_Content,
                    ObjectMother.Shared_Page01_PageItemExtended01
                ).SetArgDisplayNames($"{nameof(doTestCases)}_01"),

            new TestCaseData(
                    ObjectMother.Shared_Page01_PageItem14,
                    ObjectMother.Shared_Page01_PageItemExtended14_Content,
                    ObjectMother.Shared_Page01_PageItemExtended14
                ).SetArgDisplayNames($"{nameof(doTestCases)}_02"),

            new TestCaseData(
                    ObjectMother.Shared_Page02_PageItem18,
                    ObjectMother.Shared_Page02_PageItemExtended18_Content,
                    ObjectMother.Shared_Page02_PageItemExtended18
                ).SetArgDisplayNames($"{nameof(doTestCases)}_03"),

            new TestCaseData(
                    ObjectMother.Shared_Page03_PageItem01,
                    ObjectMother.Shared_Page03_PageItemExtended01_Content,
                    ObjectMother.Shared_Page03_PageItemExtended01
                ).SetArgDisplayNames($"{nameof(doTestCases)}_04"),

            new TestCaseData(
                    ObjectMother.Shared_Page03_PageItem02,
                    ObjectMother.Shared_Page03_PageItemExtended02_Content,
                    ObjectMother.Shared_Page03_PageItemExtended02
                ).SetArgDisplayNames($"{nameof(doTestCases)}_05"),

            new TestCaseData(
                    ObjectMother.Shared_Page03_PageItem03,
                    ObjectMother.Shared_Page03_PageItemExtended03_Content,
                    ObjectMother.Shared_Page03_PageItemExtended03
                ).SetArgDisplayNames($"{nameof(doTestCases)}_06"),

            new TestCaseData(
                    ObjectMother.Shared_Page03_PageItem04,
                    ObjectMother.Shared_Page03_PageItemExtended04_Content,
                    ObjectMother.Shared_Page03_PageItemExtended04
                ).SetArgDisplayNames($"{nameof(doTestCases)}_07")

        };
        private static TestCaseData[] doExceptionTestCases =
        {

            new TestCaseData(
                new TestDelegate(
                    () => new PageItemExtendedScraper().Do(null, ObjectMother.Shared_Page01_Content) 
                ),
                typeof(ArgumentNullException),
                new ArgumentNullException("pageItem").Message
            ).SetArgDisplayNames($"{nameof(doExceptionTestCases)}_01"),

            new TestCaseData(
                new TestDelegate(
                    () => new PageItemExtendedScraper().Do(ObjectMother.Shared_Page01_PageItem01, null)
                ),
                typeof(ArgumentNullException),
                new ArgumentNullException("content").Message
            ).SetArgDisplayNames($"{nameof(doExceptionTestCases)}_02"),

        };

        // SetUp
        // Tests
        [TestCaseSource(nameof(pageItemExtendedScraperExceptionTestCases))]
        public void PageItemExtendedScraper_ShouldThrowACertainException_WhenUnproperArguments
            (TestDelegate del, Type expectedType, string expectedMessage)
                => ObjectMother.Method_ShouldThrowACertainException_WhenUnproperArguments(del, expectedType, expectedMessage);

        [TestCaseSource(nameof(doTestCases))]
        public void Do_ShouldReturnExpectedPageItemExtended_WhenProperArguments
            (PageItem pageItem, string content, PageItemExtended expected)
        {

            // Arrange
            // Act
            PageItemExtended actual = new PageItemExtendedScraper().Do(pageItem, content);

            // Assert
            Assert.IsTrue(
                     ObjectMother.AreEqual(expected, actual)
                 );

        }
        
        [TestCaseSource(nameof(doExceptionTestCases))]
        public void Do_ShouldThrowACertainException_WhenUnproperArguments
            (TestDelegate del, Type expectedType, string expectedMessage)
                => ObjectMother.Method_ShouldThrowACertainException_WhenUnproperArguments(del, expectedType, expectedMessage);

        // TearDown		

    }
}

/*
    Author: numbworks@gmail.com
    Last Update: 13.05.2021
*/