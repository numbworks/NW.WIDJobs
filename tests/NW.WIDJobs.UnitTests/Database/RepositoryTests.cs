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
        private static TestCaseData[] conditionallyInsertPageItemsExtendedTestCases =
        {

            new TestCaseData(
                    new Func<int>(
                            () => ObjectMother
                                    .CreateInMemoryRepository()
                                        .ConditionallyInsert(ObjectMother.Shared_Page01_PageItemsExtended)),
                    (ObjectMother.Shared_Page01_PageItemsExtended.Count * 2)
                        + ObjectMother.Shared_Page01_PageItemsExtended
                            .Select(pageItemExtended => pageItemExtended.DescriptionBulletPoints)
                            .ToList().Count
                ).SetArgDisplayNames($"{nameof(conditionallyInsertPageItemsExtendedTestCases)}_01"),

            new TestCaseData(
                    new Func<int>(
                            () => ObjectMother
                                    .CreateInMemoryRepository()
                                        .ConditionallyInsert(ObjectMother.Shared_Page01_PageItemExtended01)),
                    (2) + ObjectMother.Shared_Page01_PageItemExtended01.DescriptionBulletPoints.Count
                ).SetArgDisplayNames($"{nameof(conditionallyInsertPageItemsExtendedTestCases)}_02")

        };
        private static TestCaseData[] conditionallyInsertPageItemsExtendedExceptionTestCases =
        {

            new TestCaseData(
                new TestDelegate(
                    () => ObjectMother
                            .CreateInMemoryRepository()
                                .ConditionallyInsert((PageItemExtended)null)
                ),
                typeof(ArgumentNullException),
                new ArgumentNullException("pageItemExtended").Message
            ).SetArgDisplayNames($"{nameof(conditionallyInsertPageItemsExtendedExceptionTestCases)}_01"),

            new TestCaseData(
                new TestDelegate(
                    () => ObjectMother
                            .CreateInMemoryRepository()
                                .ConditionallyInsert((List<PageItemExtended>)null)
                ),
                typeof(ArgumentNullException),
                new ArgumentNullException("pageItemsExtended").Message
            ).SetArgDisplayNames($"{nameof(conditionallyInsertPageItemsExtendedExceptionTestCases)}_02"),

            new TestCaseData(
                new TestDelegate(
                    () => ObjectMother
                            .CreateInMemoryRepository()
                                .ConditionallyInsert(new List<PageItemExtended>())
                ),
                typeof(ArgumentException),
                MessageCollection.Validator_VariableContainsZeroItems.Invoke("pageItemsExtended")
            ).SetArgDisplayNames($"{nameof(conditionallyInsertPageItemsExtendedExceptionTestCases)}_03")

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

        [TestCaseSource(nameof(conditionallyInsertPageItemsExtendedTestCases))]
        public void ConditionallyInsert_ShouldInsertTheExpectedNumberOfRows_WhenPageItemExtended
            (Func<int> func, int expected)
        {

            // Arrange
            // Act
            int actual = func.Invoke();

            // Assert
            Assert.AreEqual(expected, actual);

        }
        [TestCaseSource(nameof(conditionallyInsertPageItemsExtendedExceptionTestCases))]
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