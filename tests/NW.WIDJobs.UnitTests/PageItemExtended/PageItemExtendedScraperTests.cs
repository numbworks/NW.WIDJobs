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
        private static TestCaseData[] tryExtractPageItemTestCases =
        {

            new TestCaseData(
                    ObjectMother.Shared_Page03_PageItemExtended01_Content
                ).SetArgDisplayNames($"{nameof(tryExtractPageItemTestCases)}_01"),

            new TestCaseData(
                    ObjectMother.Shared_Page03_PageItemExtended02_Content
                ).SetArgDisplayNames($"{nameof(tryExtractPageItemTestCases)}_02"),

            new TestCaseData(
                    ObjectMother.Shared_Page03_PageItemExtended03_Content
                ).SetArgDisplayNames($"{nameof(tryExtractPageItemTestCases)}_03"),

            new TestCaseData(
                    ObjectMother.Shared_Page03_PageItemExtended04_Content
                ).SetArgDisplayNames($"{nameof(tryExtractPageItemTestCases)}_04")

        };
        private static TestCaseData[] tryExtractPageItemExceptionTestCases =
        {

            new TestCaseData(
                new TestDelegate(
                    () => new PageItemExtendedScraper()
                                .TryExtractPageItem(
                                    null, 
                                    PageItemExtendedScraper.DummyPageNumber,
                                    PageItemExtendedScraper.DummyPageItemNumber,
                                    ObjectMother.Shared_Page01_PageItemExtended14_Content
                                )
                ),
                typeof(ArgumentNullException),
                new ArgumentNullException("runId").Message
            ).SetArgDisplayNames($"{nameof(tryExtractPageItemExceptionTestCases)}_01"),

            new TestCaseData(
                new TestDelegate(
                    () => new PageItemExtendedScraper()
                                .TryExtractPageItem(
                                    PageItemExtendedScraper.DummyPageItemRunId,
                                    0,
                                    PageItemExtendedScraper.DummyPageItemNumber,
                                    ObjectMother.Shared_Page01_PageItemExtended14_Content
                                )
                ),
                typeof(ArgumentException),
                MessageCollection.Validator_VariableCantBeLessThanOne.Invoke("pageNumber")
            ).SetArgDisplayNames($"{nameof(tryExtractPageItemExceptionTestCases)}_02"),

            new TestCaseData(
                new TestDelegate(
                    () => new PageItemExtendedScraper()
                                .TryExtractPageItem(
                                    PageItemExtendedScraper.DummyPageItemRunId,
                                    PageItemExtendedScraper.DummyPageNumber,
                                    0,
                                    ObjectMother.Shared_Page01_PageItemExtended14_Content
                                )
                ),
                typeof(ArgumentException),
                MessageCollection.Validator_VariableCantBeLessThanOne.Invoke("pageItemNumber")
            ).SetArgDisplayNames($"{nameof(tryExtractPageItemExceptionTestCases)}_03"),

            new TestCaseData(
                new TestDelegate(
                    () => new PageItemExtendedScraper()
                                .TryExtractPageItem(
                                    PageItemExtendedScraper.DummyPageItemRunId,
                                    PageItemExtendedScraper.DummyPageNumber,
                                    PageItemExtendedScraper.DummyPageItemNumber,
                                    null
                                )
                ),
                typeof(ArgumentNullException),
                new ArgumentNullException("content").Message
            ).SetArgDisplayNames($"{nameof(tryExtractPageItemExceptionTestCases)}_04")

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

        [Test]
        public void TryExtractPageItem_ShouldReturnExpectedPageItem_WhenWebpageContainsAllFields()
        {

            // Arrange
            string content = ObjectMother.Shared_Page01_PageItemExtended14_Content;
            PageItem expected = new PageItem(
                         runId: PageItemExtendedScraper.DummyPageItemRunId,
                         pageNumber: PageItemExtendedScraper.DummyPageNumber,
                         url: ObjectMother.Shared_Page01_PageItem14.Url,
                         title: ObjectMother.Shared_Page01_PageItem14.Title,
                         createDate: ObjectMother.Shared_Page01_PageItem14.CreateDate,
                         applicationDate: ObjectMother.Shared_Page01_PageItem14.ApplicationDate,
                         workArea: ObjectMother.Shared_Page01_PageItem14.WorkArea,
                         workAreaWithoutZone: ObjectMother.Shared_Page01_PageItem14.WorkAreaWithoutZone,
                         workingHours: ObjectMother.Shared_Page01_PageItem14.WorkingHours,
                         jobType: ObjectMother.Shared_Page01_PageItem14.JobType,
                         jobId: ObjectMother.Shared_Page01_PageItem14.JobId,
                         pageItemNumber: PageItemExtendedScraper.DummyPageItemNumber,
                         pageItemId: ObjectMother.Shared_Page01_PageItem14.PageItemId
                      );

            // Act
            PageItem actual = new PageItemExtendedScraper().TryExtractPageItem(content);

            // Assert
            Assert.IsTrue(
                     ObjectMother.AreEqual(expected, actual)
                 );

        }

        [TestCaseSource(nameof(tryExtractPageItemTestCases))]
        public void TryExtractPageItem_ShouldReturnNull_WhenWebpageDoesntContainsAllFields
            (string content)
        {

            // Arrange
            // Act
            PageItem actual = new PageItemExtendedScraper().TryExtractPageItem(content);

            // Assert
            Assert.IsNull(actual);

        }

        [TestCaseSource(nameof(tryExtractPageItemExceptionTestCases))]
        public void TryExtractPageItem_ShouldThrowACertainException_WhenUnproperArguments
            (TestDelegate del, Type expectedType, string expectedMessage)
                => ObjectMother.Method_ShouldThrowACertainException_WhenUnproperArguments(del, expectedType, expectedMessage);

        // TearDown		

    }
}

/*
    Author: numbworks@gmail.com
    Last Update: 12.06.2021
*/