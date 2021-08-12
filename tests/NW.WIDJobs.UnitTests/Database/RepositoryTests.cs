using NUnit.Framework;
using System;
using System.Linq;
using System.Collections.Generic;

namespace NW.WIDJobs.UnitTests
{
    [TestFixture]
    public class RepositoryTests
    {

        // Fields
        private static TestCaseData[] repositoryTestCases =
        {

            new TestCaseData(
                    new Func<Repository>( 
                            () => new Repository(
                                        ObjectMother.DatabaseContext_DatabasePath,
                                        ObjectMother.DatabaseContext_DatabaseName01,
                                        false))
                ).SetArgDisplayNames($"{nameof(repositoryTestCases)}_01"),

            new TestCaseData(
                    new Func<Repository>(
                            () => new Repository(
                                        ObjectMother.CreateInMemoryContext(),
                                        false))
                ).SetArgDisplayNames($"{nameof(repositoryTestCases)}_02")

        };
        private static TestCaseData[] repositoryExceptionTestCases =
        {

            new TestCaseData(
                new TestDelegate(
                    () => new Repository(null, true)
                ),
                typeof(ArgumentNullException),
                new ArgumentNullException("databaseContext").Message
            ).SetArgDisplayNames($"{nameof(repositoryExceptionTestCases)}_01"),

            new TestCaseData(
                new TestDelegate(
                    () => new Repository(null, ObjectMother.DatabaseContext_DatabaseName01, true)
                ),
                typeof(ArgumentNullException),
                new ArgumentNullException("databasePath").Message
            ).SetArgDisplayNames($"{nameof(repositoryExceptionTestCases)}_02"),

            new TestCaseData(
                new TestDelegate(
                    () => new Repository(ObjectMother.DatabaseContext_DatabasePath, null, true)
                ),
                typeof(ArgumentNullException),
                new ArgumentNullException("databaseName").Message
            ).SetArgDisplayNames($"{nameof(repositoryExceptionTestCases)}_03")

        };
        private static TestCaseData[] conditionallyInsertJobPostingExtendedTestCases =
        {

            new TestCaseData(
                    new Func<int>(
                            () => ObjectMother
                                    .CreateInMemoryRepository()
                                        .ConditionallyInsert(ObjectMother.Shared_JobPage01_JobPostingsExtended)),
                    (ObjectMother.Shared_JobPage01_JobPostingsExtended.Count * 2)
                        + ObjectMother.Shared_JobPage01_JobPostingsExtended
                            .Select(jobPostingExtended => jobPostingExtended.BulletPoints)
                            .ToList().Count
                ).SetArgDisplayNames($"{nameof(conditionallyInsertJobPostingExtendedTestCases)}_01"),

            new TestCaseData(
                    new Func<int>(
                            () => ObjectMother
                                    .CreateInMemoryRepository()
                                        .ConditionallyInsert(ObjectMother.Shared_JobPage01_JobPostingsExtended)),
                    (2) + ObjectMother.Shared_JobPage01_JobPostingExtended01.BulletPoints.Count
                ).SetArgDisplayNames($"{nameof(conditionallyInsertJobPostingExtendedTestCases)}_02")

        };
        private static TestCaseData[] conditionallyInsertJobPostingExtendedExceptionTestCases =
        {

            new TestCaseData(
                new TestDelegate(
                    () => ObjectMother
                            .CreateInMemoryRepository()
                                .ConditionallyInsert((JobPostingExtended)null)
                ),
                typeof(ArgumentNullException),
                new ArgumentNullException("jobPostingExtended").Message
            ).SetArgDisplayNames($"{nameof(conditionallyInsertJobPostingExtendedExceptionTestCases)}_01"),

            new TestCaseData(
                new TestDelegate(
                    () => ObjectMother
                            .CreateInMemoryRepository()
                                .ConditionallyInsert((List<JobPostingExtended>)null)
                ),
                typeof(ArgumentNullException),
                new ArgumentNullException("jobPostingsExtended").Message
            ).SetArgDisplayNames($"{nameof(conditionallyInsertJobPostingExtendedExceptionTestCases)}_02"),

            new TestCaseData(
                new TestDelegate(
                    () => ObjectMother
                            .CreateInMemoryRepository()
                                .ConditionallyInsert(new List<JobPostingExtended>())
                ),
                typeof(ArgumentException),
                MessageCollection.Validator_VariableContainsZeroItems.Invoke("jobPostingsExtended")
            ).SetArgDisplayNames($"{nameof(conditionallyInsertJobPostingExtendedExceptionTestCases)}_03")

        };
        private static TestCaseData[] conditionallyInsertPageItemsTestCases =
        {

            new TestCaseData(
                    new Func<int>(
                            () => ObjectMother
                                    .CreateInMemoryRepository()
                                        .ConditionallyInsert(ObjectMother.Shared_Page01_PageItems)),
                    ObjectMother.Shared_Page01_PageItems.Count
                ).SetArgDisplayNames($"{nameof(conditionallyInsertPageItemsTestCases)}_01"),

            new TestCaseData(
                    new Func<int>(
                            () => ObjectMother
                                    .CreateInMemoryRepository()
                                        .ConditionallyInsert(ObjectMother.Shared_Page01_PageItem01)),
                    1
                ).SetArgDisplayNames($"{nameof(conditionallyInsertPageItemsTestCases)}_02"),

        };
        private static TestCaseData[] conditionallyInsertPageItemsExceptionTestCases =
        {

            new TestCaseData(
                new TestDelegate(
                    () => ObjectMother
                            .CreateInMemoryRepository()
                                .ConditionallyInsert((PageItem)null)
                ),
                typeof(ArgumentNullException),
                new ArgumentNullException("pageItem").Message
            ).SetArgDisplayNames($"{nameof(conditionallyInsertPageItemsExceptionTestCases)}_01"),

            new TestCaseData(
                new TestDelegate(
                    () => ObjectMother
                            .CreateInMemoryRepository()
                                .ConditionallyInsert((List<PageItem>)null)
                ),
                typeof(ArgumentNullException),
                new ArgumentNullException("pageItems").Message
            ).SetArgDisplayNames($"{nameof(conditionallyInsertPageItemsExceptionTestCases)}_02"),

            new TestCaseData(
                new TestDelegate(
                    () => ObjectMother
                            .CreateInMemoryRepository()
                                .ConditionallyInsert(new List<PageItem>())
                ),
                typeof(ArgumentException),
                MessageCollection.Validator_VariableContainsZeroItems.Invoke("pageItems")
            ).SetArgDisplayNames($"{nameof(conditionallyInsertPageItemsExceptionTestCases)}_03")

        };

        // SetUp
        // Tests
        [TestCaseSource(nameof(repositoryTestCases))]
        public void Repository_ShouldInitializeANewRepositoryObject_WhenProperArguments
            (Func<Repository> func)
        {

            // Arrange
            // Act
            Repository repository = func.Invoke();

            // Assert
            Assert.IsNotNull(repository.DatabaseContext);

        }
        [TestCaseSource(nameof(repositoryExceptionTestCases))]
        public void Repository_ShouldThrowACertainException_WhenUnproperArguments
            (TestDelegate del, Type expectedType, string expectedMessage)
                => ObjectMother.Method_ShouldThrowACertainException_WhenUnproperArguments(del, expectedType, expectedMessage);

        [TestCaseSource(nameof(conditionallyInsertJobPostingExtendedTestCases))]
        public void ConditionallyInsert_ShouldInsertTheExpectedNumberOfRows_WhenPageItemExtended
            (Func<int> func, int expected)
        {

            // Arrange
            // Act
            int actual = func.Invoke();

            // Assert
            Assert.AreEqual(expected, actual);

        }
        [TestCaseSource(nameof(conditionallyInsertJobPostingExtendedExceptionTestCases))]
        public void ConditionallyInsert_ShouldThrowACertainExceptionForPageItemExtended_WhenUnproperArguments
            (TestDelegate del, Type expectedType, string expectedMessage)
                => ObjectMother.Method_ShouldThrowACertainException_WhenUnproperArguments(del, expectedType, expectedMessage);

        [TestCaseSource(nameof(conditionallyInsertPageItemsTestCases))]
        public void ConditionallyInsert_ShouldInsertTheExpectedNumberOfRows_WhenPageItem
            (Func<int> func, int expected)
        {

            // Arrange
            // Act
            int actual = func.Invoke();

            // Assert
            Assert.AreEqual(expected, actual);

        }
        [TestCaseSource(nameof(conditionallyInsertPageItemsExceptionTestCases))]
        public void ConditionallyInsert_ShouldThrowACertainExceptionForPageItem_WhenUnproperArguments
            (TestDelegate del, Type expectedType, string expectedMessage)
                => ObjectMother.Method_ShouldThrowACertainException_WhenUnproperArguments(del, expectedType, expectedMessage);

        // TearDown		

    }
}

/*
    Author: numbworks@gmail.com
    Last Update: 19.06.2021
*/