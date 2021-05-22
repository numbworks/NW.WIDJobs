using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace NW.WIDJobs.UnitTests
{
    [TestFixture]
    public class PageItemScraperTests
    {

        // Fields
        private static TestCaseData[] pageItemScraperExceptionTestCases =
        {

            new TestCaseData(
                new TestDelegate(
                    () => new PageItemScraper(null)
                ),
                typeof(ArgumentNullException),
                new ArgumentNullException("xpathManager").Message
            ).SetArgDisplayNames($"{nameof(doExceptionTestCases)}_01"),

        };
        private static TestCaseData[] doTestCases =
        {

            new TestCaseData(
                    ObjectMother.Shared_Page01,
                    ObjectMother.Shared_Page01_PageItems
                ).SetArgDisplayNames($"{nameof(doTestCases)}_01"),


            new TestCaseData(
                    ObjectMother.Shared_Page02,
                    ObjectMother.Shared_Page02_PageItems
                ).SetArgDisplayNames($"{nameof(doTestCases)}_02")

        };
        private static TestCaseData[] doExceptionTestCases =
        {

            new TestCaseData(
                new TestDelegate(
                    () => new PageItemScraper().Do(null)
                ),
                typeof(ArgumentNullException),
                new ArgumentNullException("page").Message
            ).SetArgDisplayNames($"{nameof(doExceptionTestCases)}_01"),

            new TestCaseData(
                new TestDelegate(
                    () => new PageItemScraper().Do(ObjectMother.Shared_Page01_NotPossibleToExtractJobId.Invoke())
                ),
                typeof(Exception),
                MessageCollection.PageItemScraper_NotPossibleToExtractJobId.Invoke(
                        ObjectMother.Shared_Page01_NotPossibleToExtractJobId_Url, 
                        "(?<=/job/)[0-9]{5,}"
                    )
            ).SetArgDisplayNames($"{nameof(doExceptionTestCases)}_02")

        };
        private static TestCaseData[] extractAndParseCreateDatesExceptionTestCases =
        {

            new TestCaseData(
                new TestDelegate(
                    () => new PageItemScraper().ExtractAndParseCreateDates(null)
                ),
                typeof(ArgumentNullException),
                new ArgumentNullException("content").Message
            ).SetArgDisplayNames($"{nameof(extractAndParseCreateDatesExceptionTestCases)}_01")

        };
        private static TestCaseData[] hasBeenFoundExceptionTestCases =
        {

            new TestCaseData(
                new TestDelegate(
                    () => new PageItemScraper()
                            .IsThresholdConditionMet(
                                ObjectMother.Shared_Page01Alternate_ThresholdDate,
                                null
                                )
                ),
                typeof(ArgumentNullException),
                new ArgumentNullException("createDates").Message
            ).SetArgDisplayNames($"{nameof(hasBeenFoundExceptionTestCases)}_01")

        };
        private static TestCaseData[] isThresholdConditionMetTestCases =
        {

            // ThresholdDate > MostRecent
            new TestCaseData(
                   ObjectMother.Shared_Page01Alternate_CreateDates.OrderByDescending(createDate => createDate.Date).First().AddDays(1),
                   ObjectMother.Shared_Page01Alternate_CreateDates,
                   false
            ).SetArgDisplayNames($"{nameof(isThresholdConditionMetTestCases)}_01"),

            // ThresholdDate > LeastRecent && ThresholdDate <= MostRecent
            new TestCaseData(
                   ObjectMother.Shared_Page01Alternate_ThresholdDate,
                   ObjectMother.Shared_Page01Alternate_CreateDates,
                   true
            ).SetArgDisplayNames($"{nameof(isThresholdConditionMetTestCases)}_02"),

            // ThresholdDate == LeastRecent
            new TestCaseData(
                   ObjectMother.Shared_Page01Alternate_CreateDates.OrderByDescending(createDate => createDate.Date).Reverse().First(),
                   ObjectMother.Shared_Page01Alternate_CreateDates,
                   false
            ).SetArgDisplayNames($"{nameof(isThresholdConditionMetTestCases)}_03"),

            // ThresholdDate < LeastRecent
            new TestCaseData(
                   ObjectMother.Shared_Page01Alternate_CreateDates.OrderByDescending(createDate => createDate.Date).Reverse().First().AddDays(-1),
                   ObjectMother.Shared_Page01Alternate_CreateDates,
                   false
            ).SetArgDisplayNames($"{nameof(isThresholdConditionMetTestCases)}_04"),

        };

        // SetUp
        // Tests
        [TestCaseSource(nameof(pageItemScraperExceptionTestCases))]
        public void PageItemScraper_ShouldThrowACertainException_WhenUnproperArguments
            (TestDelegate del, Type expectedType, string expectedMessage)
                => ObjectMother.Method_ShouldThrowACertainException_WhenUnproperArguments(del, expectedType, expectedMessage);

        [TestCaseSource(nameof(doTestCases))]
        public void Do_ShouldReturnExpectedPageItems_WhenProperArguments
            (Page page, List<PageItem> expected)
        {

            // Arrange
            // Act
            List<PageItem> actual = new PageItemScraper().Do(page);

            // Assert
            Assert.IsTrue(
                    ObjectMother.AreEqual(expected, actual)
                );

        }
        
        [TestCaseSource(nameof(doExceptionTestCases))]
        public void Do_ShouldThrowACertainException_WhenUnproperArguments
            (TestDelegate del, Type expectedType, string expectedMessage)
                => ObjectMother.Method_ShouldThrowACertainException_WhenUnproperArguments(del, expectedType, expectedMessage);

        [TestCaseSource(nameof(extractAndParseCreateDatesExceptionTestCases))]
        public void ExtractAndParseCreateDates_ShouldThrowACertainException_WhenUnproperArguments
            (TestDelegate del, Type expectedType, string expectedMessage)
                => ObjectMother.Method_ShouldThrowACertainException_WhenUnproperArguments(del, expectedType, expectedMessage);

        [TestCaseSource(nameof(hasBeenFoundExceptionTestCases))]
        public void HasBeenFound_ShouldThrowACertainException_WhenUnproperArguments
            (TestDelegate del, Type expectedType, string expectedMessage)
                => ObjectMother.Method_ShouldThrowACertainException_WhenUnproperArguments(del, expectedType, expectedMessage);

        [TestCaseSource(nameof(isThresholdConditionMetTestCases))]
        public void IsThresholdConditionMet_ShouldReturnExpectedBoolean_WhenProperArguments
            (DateTime thresholdDate, List<DateTime> createDates, bool expected)
        {

            // Arrange
            // Act
            bool actual = new PageItemScraper().IsThresholdConditionMet(thresholdDate, createDates);

            // Assert
            Assert.AreEqual(expected, actual);

        }

        // TearDown		

    }
}

/*
    Author: numbworks@gmail.com
    Last Update: 22.05.2021
*/
