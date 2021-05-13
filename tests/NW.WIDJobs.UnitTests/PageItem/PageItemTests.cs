using NUnit.Framework;
using System;

namespace NW.WIDJobs.UnitTests
{
    [TestFixture]
    public class PageItemTests
    {

        // Fields
        private static TestCaseData[] pageItemExceptionTestCases =
        {

            new TestCaseData(
                new TestDelegate(
                    () => new PageItem(
                                null,
                                ObjectMother.Shared_Page01_PageItem01.PageNumber,
                                ObjectMother.Shared_Page01_PageItem01.Url,
                                ObjectMother.Shared_Page01_PageItem01.Title,
                                ObjectMother.Shared_Page01_PageItem01.CreateDate,
                                ObjectMother.Shared_Page01_PageItem01.ApplicationDate,
                                ObjectMother.Shared_Page01_PageItem01.WorkArea,
                                ObjectMother.Shared_Page01_PageItem01.WorkAreaWithoutZone,
                                ObjectMother.Shared_Page01_PageItem01.WorkingHours,
                                ObjectMother.Shared_Page01_PageItem01.JobType,
                                ObjectMother.Shared_Page01_PageItem01.JobId,
                                ObjectMother.Shared_Page01_PageItem01.PageItemNumber,
                                ObjectMother.Shared_Page01_PageItem01.PageItemId
                        )
				),
                typeof(ArgumentNullException),
                new ArgumentNullException("runId").Message
            ).SetArgDisplayNames($"{nameof(pageItemExceptionTestCases)}_01"),

            new TestCaseData(
                new TestDelegate(
                    () => new PageItem(
                                ObjectMother.Shared_Page01_PageItem01.RunId,
                                0,
                                ObjectMother.Shared_Page01_PageItem01.Url,
                                ObjectMother.Shared_Page01_PageItem01.Title,
                                ObjectMother.Shared_Page01_PageItem01.CreateDate,
                                ObjectMother.Shared_Page01_PageItem01.ApplicationDate,
                                ObjectMother.Shared_Page01_PageItem01.WorkArea,
                                ObjectMother.Shared_Page01_PageItem01.WorkAreaWithoutZone,
                                ObjectMother.Shared_Page01_PageItem01.WorkingHours,
                                ObjectMother.Shared_Page01_PageItem01.JobType,
                                ObjectMother.Shared_Page01_PageItem01.JobId,
                                ObjectMother.Shared_Page01_PageItem01.PageItemNumber,
                                ObjectMother.Shared_Page01_PageItem01.PageItemId
                        )
                ),
                typeof(ArgumentException),
                MessageCollection.Validator_VariableCantBeLessThanOne.Invoke("pageNumber")
            ).SetArgDisplayNames($"{nameof(pageItemExceptionTestCases)}_02"),

            new TestCaseData(
                new TestDelegate(
                    () => new PageItem(
                                ObjectMother.Shared_Page01_PageItem01.RunId,
                                ObjectMother.Shared_Page01_PageItem01.PageNumber,
                                null,
                                ObjectMother.Shared_Page01_PageItem01.Title,
                                ObjectMother.Shared_Page01_PageItem01.CreateDate,
                                ObjectMother.Shared_Page01_PageItem01.ApplicationDate,
                                ObjectMother.Shared_Page01_PageItem01.WorkArea,
                                ObjectMother.Shared_Page01_PageItem01.WorkAreaWithoutZone,
                                ObjectMother.Shared_Page01_PageItem01.WorkingHours,
                                ObjectMother.Shared_Page01_PageItem01.JobType,
                                ObjectMother.Shared_Page01_PageItem01.JobId,
                                ObjectMother.Shared_Page01_PageItem01.PageItemNumber,
                                ObjectMother.Shared_Page01_PageItem01.PageItemId
                        )
                ),
                typeof(ArgumentNullException),
                new ArgumentNullException("url").Message
            ).SetArgDisplayNames($"{nameof(pageItemExceptionTestCases)}_03"),

            new TestCaseData(
                new TestDelegate(
                    () => new PageItem(
                                ObjectMother.Shared_Page01_PageItem01.RunId,
                                ObjectMother.Shared_Page01_PageItem01.PageNumber,
                                ObjectMother.Shared_Page01_PageItem01.Url,
                                null,
                                ObjectMother.Shared_Page01_PageItem01.CreateDate,
                                ObjectMother.Shared_Page01_PageItem01.ApplicationDate,
                                ObjectMother.Shared_Page01_PageItem01.WorkArea,
                                ObjectMother.Shared_Page01_PageItem01.WorkAreaWithoutZone,
                                ObjectMother.Shared_Page01_PageItem01.WorkingHours,
                                ObjectMother.Shared_Page01_PageItem01.JobType,
                                ObjectMother.Shared_Page01_PageItem01.JobId,
                                ObjectMother.Shared_Page01_PageItem01.PageItemNumber,
                                ObjectMother.Shared_Page01_PageItem01.PageItemId
                        )
                ),
                typeof(ArgumentNullException),
                new ArgumentNullException("title").Message
            ).SetArgDisplayNames($"{nameof(pageItemExceptionTestCases)}_04"),

            new TestCaseData(
                new TestDelegate(
                    () => new PageItem(
                                ObjectMother.Shared_Page01_PageItem01.RunId,
                                ObjectMother.Shared_Page01_PageItem01.PageNumber,
                                ObjectMother.Shared_Page01_PageItem01.Url,
                                ObjectMother.Shared_Page01_PageItem01.Title,
                                ObjectMother.Shared_Page01_PageItem01.CreateDate,
                                ObjectMother.Shared_Page01_PageItem01.ApplicationDate,
                                null,
                                ObjectMother.Shared_Page01_PageItem01.WorkAreaWithoutZone,
                                ObjectMother.Shared_Page01_PageItem01.WorkingHours,
                                ObjectMother.Shared_Page01_PageItem01.JobType,
                                ObjectMother.Shared_Page01_PageItem01.JobId,
                                ObjectMother.Shared_Page01_PageItem01.PageItemNumber,
                                ObjectMother.Shared_Page01_PageItem01.PageItemId
                        )
                ),
                typeof(ArgumentNullException),
                new ArgumentNullException("workArea").Message
            ).SetArgDisplayNames($"{nameof(pageItemExceptionTestCases)}_05"),

            new TestCaseData(
                new TestDelegate(
                    () => new PageItem(
                                ObjectMother.Shared_Page01_PageItem01.RunId,
                                ObjectMother.Shared_Page01_PageItem01.PageNumber,
                                ObjectMother.Shared_Page01_PageItem01.Url,
                                ObjectMother.Shared_Page01_PageItem01.Title,
                                ObjectMother.Shared_Page01_PageItem01.CreateDate,
                                ObjectMother.Shared_Page01_PageItem01.ApplicationDate,
                                ObjectMother.Shared_Page01_PageItem01.WorkArea,
                                null,
                                ObjectMother.Shared_Page01_PageItem01.WorkingHours,
                                ObjectMother.Shared_Page01_PageItem01.JobType,
                                ObjectMother.Shared_Page01_PageItem01.JobId,
                                ObjectMother.Shared_Page01_PageItem01.PageItemNumber,
                                ObjectMother.Shared_Page01_PageItem01.PageItemId
                        )
                ),
                typeof(ArgumentNullException),
                new ArgumentNullException("workAreaWithoutZone").Message
            ).SetArgDisplayNames($"{nameof(pageItemExceptionTestCases)}_06"),

            new TestCaseData(
                new TestDelegate(
                    () => new PageItem(
                                ObjectMother.Shared_Page01_PageItem01.RunId,
                                ObjectMother.Shared_Page01_PageItem01.PageNumber,
                                ObjectMother.Shared_Page01_PageItem01.Url,
                                ObjectMother.Shared_Page01_PageItem01.Title,
                                ObjectMother.Shared_Page01_PageItem01.CreateDate,
                                ObjectMother.Shared_Page01_PageItem01.ApplicationDate,
                                ObjectMother.Shared_Page01_PageItem01.WorkArea,
                                ObjectMother.Shared_Page01_PageItem01.WorkAreaWithoutZone,
                                null,
                                ObjectMother.Shared_Page01_PageItem01.JobType,
                                ObjectMother.Shared_Page01_PageItem01.JobId,
                                ObjectMother.Shared_Page01_PageItem01.PageItemNumber,
                                ObjectMother.Shared_Page01_PageItem01.PageItemId
                        )
                ),
                typeof(ArgumentNullException),
                new ArgumentNullException("workingHours").Message
            ).SetArgDisplayNames($"{nameof(pageItemExceptionTestCases)}_07"),

            new TestCaseData(
                new TestDelegate(
                    () => new PageItem(
                                ObjectMother.Shared_Page01_PageItem01.RunId,
                                ObjectMother.Shared_Page01_PageItem01.PageNumber,
                                ObjectMother.Shared_Page01_PageItem01.Url,
                                ObjectMother.Shared_Page01_PageItem01.Title,
                                ObjectMother.Shared_Page01_PageItem01.CreateDate,
                                ObjectMother.Shared_Page01_PageItem01.ApplicationDate,
                                ObjectMother.Shared_Page01_PageItem01.WorkArea,
                                ObjectMother.Shared_Page01_PageItem01.WorkAreaWithoutZone,
                                ObjectMother.Shared_Page01_PageItem01.WorkingHours,
                                null,
                                ObjectMother.Shared_Page01_PageItem01.JobId,
                                ObjectMother.Shared_Page01_PageItem01.PageItemNumber,
                                ObjectMother.Shared_Page01_PageItem01.PageItemId
                        )
                ),
                typeof(ArgumentNullException),
                new ArgumentNullException("jobType").Message
            ).SetArgDisplayNames($"{nameof(pageItemExceptionTestCases)}_08"),

            new TestCaseData(
                new TestDelegate(
                    () => new PageItem(
                                ObjectMother.Shared_Page01_PageItem01.RunId,
                                ObjectMother.Shared_Page01_PageItem01.PageNumber,
                                ObjectMother.Shared_Page01_PageItem01.Url,
                                ObjectMother.Shared_Page01_PageItem01.Title,
                                ObjectMother.Shared_Page01_PageItem01.CreateDate,
                                ObjectMother.Shared_Page01_PageItem01.ApplicationDate,
                                ObjectMother.Shared_Page01_PageItem01.WorkArea,
                                ObjectMother.Shared_Page01_PageItem01.WorkAreaWithoutZone,
                                ObjectMother.Shared_Page01_PageItem01.WorkingHours,
                                ObjectMother.Shared_Page01_PageItem01.JobType,
                                ObjectMother.Shared_Page01_PageItem01.JobId,
                                0,
                                ObjectMother.Shared_Page01_PageItem01.PageItemId
                        )
                ),
                typeof(ArgumentException),
                MessageCollection.Validator_VariableCantBeLessThanOne.Invoke("pageItemNumber")
            ).SetArgDisplayNames($"{nameof(pageItemExceptionTestCases)}_09"),

            new TestCaseData(
                new TestDelegate(
                    () => new PageItem(
                                ObjectMother.Shared_Page01_PageItem01.RunId,
                                ObjectMother.Shared_Page01_PageItem01.PageNumber,
                                ObjectMother.Shared_Page01_PageItem01.Url,
                                ObjectMother.Shared_Page01_PageItem01.Title,
                                ObjectMother.Shared_Page01_PageItem01.CreateDate,
                                ObjectMother.Shared_Page01_PageItem01.ApplicationDate,
                                ObjectMother.Shared_Page01_PageItem01.WorkArea,
                                ObjectMother.Shared_Page01_PageItem01.WorkAreaWithoutZone,
                                ObjectMother.Shared_Page01_PageItem01.WorkingHours,
                                ObjectMother.Shared_Page01_PageItem01.JobType,
                                ObjectMother.Shared_Page01_PageItem01.JobId,
                                ObjectMother.Shared_Page01_PageItem01.PageItemNumber,
                                null
                        )
                ),
                typeof(ArgumentNullException),
                new ArgumentNullException("pageItemId").Message
            ).SetArgDisplayNames($"{nameof(pageItemExceptionTestCases)}_10"),

        };

        // SetUp
        // Tests
        [TestCaseSource(nameof(pageItemExceptionTestCases))]
        public void SomeMethod_ShouldThrowACertainException_WhenUnproperArguments
            (TestDelegate del, Type expectedType, string expectedMessage)
                => ObjectMother.Method_ShouldThrowACertainException_WhenUnproperArguments(del, expectedType, expectedMessage);

        [Test]
        public void PageItem_ShouldInitializeANewPageItemObject_WhenProperArguments()
        {

            // Arrange
            // Act
            PageItem actual
                = new PageItem(
                                ObjectMother.Shared_Page01_PageItem01.RunId,
                                ObjectMother.Shared_Page01_PageItem01.PageNumber,
                                ObjectMother.Shared_Page01_PageItem01.Url,
                                ObjectMother.Shared_Page01_PageItem01.Title,
                                ObjectMother.Shared_Page01_PageItem01.CreateDate,
                                ObjectMother.Shared_Page01_PageItem01.ApplicationDate,
                                ObjectMother.Shared_Page01_PageItem01.WorkArea,
                                ObjectMother.Shared_Page01_PageItem01.WorkAreaWithoutZone,
                                ObjectMother.Shared_Page01_PageItem01.WorkingHours,
                                ObjectMother.Shared_Page01_PageItem01.JobType,
                                ObjectMother.Shared_Page01_PageItem01.JobId,
                                ObjectMother.Shared_Page01_PageItem01.PageItemNumber,
                                ObjectMother.Shared_Page01_PageItem01.PageItemId
                        );

            // Assert
            Assert.IsTrue(
                    ObjectMother.AreEqual(ObjectMother.Shared_Page01_PageItem01, actual)
                );

        }

        // TearDown

    }
}

/*
    Author: numbworks@gmail.com
    Last Update: 13.05.2021
*/
