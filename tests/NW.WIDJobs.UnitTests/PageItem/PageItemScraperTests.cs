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
                    () => new PageItemScraper(null, new PageItemScraperHelper())
                ),
                typeof(ArgumentNullException),
                new ArgumentNullException("xpathManager").Message
            ).SetArgDisplayNames($"{nameof(doExceptionTestCases)}_01"),

            new TestCaseData(
                new TestDelegate(
                    () => new PageItemScraper(new XPathManager(), null)
                ),
                typeof(ArgumentNullException),
                new ArgumentNullException("scraperHelper").Message
            ).SetArgDisplayNames($"{nameof(doExceptionTestCases)}_02")

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
                ).SetArgDisplayNames($"{nameof(doTestCases)}_02"),

            new TestCaseData(
                    ObjectMother.AdditionalCases_PageItemScraper01_Page.Invoke(),
                    ObjectMother.AdditionalCases_PageItemScraper01_ExpectedPageItems
                ).SetArgDisplayNames($"{nameof(doTestCases)}_03"),

            new TestCaseData(
                    ObjectMother.AdditionalCases_PageItemScraper02_Page.Invoke(),
                    ObjectMother.AdditionalCases_PageItemScraper02_ExpectedPageItems
                ).SetArgDisplayNames($"{nameof(doTestCases)}_04")

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
                    () => new PageItemScraper().Do(ObjectMother.AdditionalCases_PageItemScraper03_Page.Invoke())
                ),
                typeof(Exception),
                MessageCollection.PageItemScraperHelper_NotPossibleToExtractJobId.Invoke(
                        ObjectMother.AdditionalCases_PageItemScraper03_Url, 
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
        private static TestCaseData[] isThresholdConditionMetExceptionTestCases =
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
            ).SetArgDisplayNames($"{nameof(isThresholdConditionMetExceptionTestCases)}_01"),

            new TestCaseData(
                new TestDelegate(
                    () => new PageItemScraper()
                            .IsThresholdConditionMet(
                                null,
                                ObjectMother.Shared_Page01_PageItems
                                )
                ),
                typeof(ArgumentNullException),
                new ArgumentNullException("pageItemId").Message
            ).SetArgDisplayNames($"{nameof(isThresholdConditionMetExceptionTestCases)}_02"),

            new TestCaseData(
                new TestDelegate(
                    () => new PageItemScraper()
                            .IsThresholdConditionMet(
                                ObjectMother.Shared_FakeRunId,
                                null
                                )
                ),
                typeof(ArgumentNullException),
                new ArgumentNullException("pageItems").Message
            ).SetArgDisplayNames($"{nameof(isThresholdConditionMetExceptionTestCases)}_03")

        };
        private static TestCaseData[] removeUnsuitableExceptionTestCases =
        {

            new TestCaseData(
                new TestDelegate(
                    () => new PageItemScraper()
                            .RemoveUnsuitable(
                                ObjectMother.Shared_Page01Alternate_ThresholdDate,
                                null
                                )
                ),
                typeof(ArgumentNullException),
                new ArgumentNullException("pageItems").Message
            ).SetArgDisplayNames($"{nameof(removeUnsuitableExceptionTestCases)}_01"),

            new TestCaseData(
                new TestDelegate(
                    () => new PageItemScraper()
                            .RemoveUnsuitable(
                                null,
                                ObjectMother.Shared_Page01_PageItems
                                )
                ),
                typeof(ArgumentNullException),
                new ArgumentNullException("pageItemId").Message
            ).SetArgDisplayNames($"{nameof(removeUnsuitableExceptionTestCases)}_02"),

            new TestCaseData(
                new TestDelegate(
                    () => new PageItemScraper()
                            .RemoveUnsuitable(
                                ObjectMother.Shared_FakeRunId,
                                null
                                )
                ),
                typeof(ArgumentNullException),
                new ArgumentNullException("pageItems").Message
            ).SetArgDisplayNames($"{nameof(removeUnsuitableExceptionTestCases)}_03")

        };
        private static TestCaseData[] isThresholdConditionMetThresholdDateTestCases =
        {

            // ThresholdDate > MostRecent
            new TestCaseData(
                   ObjectMother.Shared_Page01Alternate_CreateDates.OrderByDescending(createDate => createDate.Date).First().AddDays(1),
                   ObjectMother.Shared_Page01Alternate_CreateDates,
                   false
            ).SetArgDisplayNames($"{nameof(isThresholdConditionMetThresholdDateTestCases)}_01"),

            // ThresholdDate > LeastRecent && ThresholdDate <= MostRecent
            new TestCaseData(
                   ObjectMother.Shared_Page01Alternate_ThresholdDate,
                   ObjectMother.Shared_Page01Alternate_CreateDates,
                   true
            ).SetArgDisplayNames($"{nameof(isThresholdConditionMetThresholdDateTestCases)}_02"),

            // ThresholdDate == LeastRecent
            new TestCaseData(
                   ObjectMother.Shared_Page01Alternate_CreateDates.OrderByDescending(createDate => createDate.Date).Reverse().First(),
                   ObjectMother.Shared_Page01Alternate_CreateDates,
                   false
            ).SetArgDisplayNames($"{nameof(isThresholdConditionMetThresholdDateTestCases)}_03"),

            // ThresholdDate < LeastRecent
            new TestCaseData(
                   ObjectMother.Shared_Page01Alternate_CreateDates.OrderByDescending(createDate => createDate.Date).Reverse().First().AddDays(-1),
                   ObjectMother.Shared_Page01Alternate_CreateDates,
                   false
            ).SetArgDisplayNames($"{nameof(isThresholdConditionMetThresholdDateTestCases)}_04")

        };
        private static TestCaseData[] removeUnsuitableThresholdDateTestCases =
        {

            new TestCaseData(
                   ObjectMother.Shared_Page01Alternate_ThresholdDate,
                   ObjectMother.Shared_Page01Alternate_PageItems,
                   ObjectMother.Shared_Page01Alternate_PageItems.GetRange(0, 16)
            ).SetArgDisplayNames($"{nameof(removeUnsuitableThresholdDateTestCases)}_01"),

        };
        private static TestCaseData[] isThresholdConditionMetPageItemIdTestCases =
        {

            new TestCaseData(
                "0000000fakeid",
                ObjectMother.Shared_Page01_PageItems,
                false
            ).SetArgDisplayNames($"{nameof(isThresholdConditionMetPageItemIdTestCases)}_01"),

            new TestCaseData(
                ObjectMother.Shared_Page01_PageItems[0].PageItemId,
                ObjectMother.Shared_Page01_PageItems,
                true
            ).SetArgDisplayNames($"{nameof(isThresholdConditionMetPageItemIdTestCases)}_02"),

        };        
        private static TestCaseData[] removeUnsuitablePageItemIdTestCases =
        {

            new TestCaseData(
                "0000000fakeid",
                ObjectMother.Shared_Page01_PageItems,
                ObjectMother.Shared_Page01_PageItems
            ).SetArgDisplayNames($"{nameof(removeUnsuitablePageItemIdTestCases)}_01"),

            new TestCaseData(
                ObjectMother.Shared_Page01_PageItems[5].PageItemId,
                ObjectMother.Shared_Page01_PageItems,
                ObjectMother.Shared_Page01_PageItems.Take(5).ToList()
            ).SetArgDisplayNames($"{nameof(removeUnsuitablePageItemIdTestCases)}_02")

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

        [TestCaseSource(nameof(isThresholdConditionMetExceptionTestCases))]
        public void IsThresholdConditionMet_ShouldThrowACertainException_WhenUnproperArguments
            (TestDelegate del, Type expectedType, string expectedMessage)
                => ObjectMother.Method_ShouldThrowACertainException_WhenUnproperArguments(del, expectedType, expectedMessage);
        [TestCaseSource(nameof(isThresholdConditionMetThresholdDateTestCases))]
        public void IsThresholdConditionMet_ShouldReturnExpectedBoolean_WhenThresholdDate
            (DateTime thresholdDate, List<DateTime> createDates, bool expected)
        {

            // Arrange
            // Act
            bool actual = new PageItemScraper().IsThresholdConditionMet(thresholdDate, createDates);

            // Assert
            Assert.AreEqual(expected, actual);

        }
        [TestCaseSource(nameof(isThresholdConditionMetPageItemIdTestCases))]
        public void IsThresholdConditionMet_ShouldReturnExpectedBoolean_WhenPageItemId
            (string pageItemId, List<PageItem> pageItems, bool expected)
        {

            // Arrange
            // Act
            bool actual = new PageItemScraper().IsThresholdConditionMet(pageItemId, pageItems);

            // Assert
            Assert.AreEqual(expected, actual);

        }

        [TestCaseSource(nameof(removeUnsuitableExceptionTestCases))]
        public void RemoveUnsuitable_ShouldThrowACertainException_WhenUnproperArguments
            (TestDelegate del, Type expectedType, string expectedMessage)
                => ObjectMother.Method_ShouldThrowACertainException_WhenUnproperArguments(del, expectedType, expectedMessage);
        [TestCaseSource(nameof(removeUnsuitableThresholdDateTestCases))]
        public void RemoveUnsuitable_ShouldReturnExpectedBoolean_WhenThresholdDate
            (DateTime thresholdDate, List<PageItem> pageItems, List<PageItem> expected)
        {

            // Arrange
            // Act
            List<PageItem> actual = new PageItemScraper().RemoveUnsuitable(thresholdDate, pageItems);

            // Assert
            Assert.IsTrue(
                    ObjectMother.AreEqual(expected, actual)
                );

        }
        [TestCaseSource(nameof(removeUnsuitablePageItemIdTestCases))]
        public void RemoveUnsuitable_ShouldReturnExpectedBoolean_WhenPageItemId
            (string pageItemId, List<PageItem> pageItems, List<PageItem> expected)
        {

            // Arrange
            // Act
            List<PageItem> actual = new PageItemScraper().RemoveUnsuitable(pageItemId, pageItems);

            // Assert
            Assert.IsTrue(
                    ObjectMother.AreEqual(expected, actual)
                );

        }

        // TearDown		

    }
}

/*
    Author: numbworks@gmail.com
    Last Update: 20.06.2021
*/
