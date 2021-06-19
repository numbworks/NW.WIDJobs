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
        private static TestCaseData[] conditionallyInsertTestCases =
        {

            new TestCaseData(
                    new Func<int>(
                            () => ObjectMother.CreateInMemoryRepository()
                                    .ConditionallyInsert(ObjectMother.Shared_Page01_PageItemsExtended)),
                    (ObjectMother.Shared_Page01_PageItemsExtended.Count * 2)
                        + ObjectMother.Shared_Page01_PageItemsExtended
                            .Select(pageItemExtended => pageItemExtended.DescriptionBulletPoints)
                            .ToList().Count
                ).SetArgDisplayNames($"{nameof(conditionallyInsertTestCases)}_01"),

            new TestCaseData(
                    new Func<int>(
                            () => ObjectMother.CreateInMemoryRepository()
                                    .ConditionallyInsert(ObjectMother.Shared_Page01_PageItemExtended01)),
                    (2) + ObjectMother.Shared_Page01_PageItemExtended01.DescriptionBulletPoints.Count
                ).SetArgDisplayNames($"{nameof(conditionallyInsertTestCases)}_02"),

        };
        private static TestCaseData[] conditionallyInsertExceptionTestCases =
        {

            new TestCaseData(
                new TestDelegate(
                    () => ObjectMother
                            .CreateInMemoryRepository()
                                .ConditionallyInsert((PageItemExtended)null)
                ),
                typeof(ArgumentNullException),
                new ArgumentNullException("pageItemExtended").Message
            ).SetArgDisplayNames($"{nameof(conditionallyInsertExceptionTestCases)}_01"),

            new TestCaseData(
                new TestDelegate(
                    () => ObjectMother
                            .CreateInMemoryRepository()
                                .ConditionallyInsert((List<PageItemExtended>)null)
                ),
                typeof(ArgumentNullException),
                new ArgumentNullException("pageItemsExtended").Message
            ).SetArgDisplayNames($"{nameof(conditionallyInsertExceptionTestCases)}_02"),

            new TestCaseData(
                new TestDelegate(
                    () => ObjectMother
                            .CreateInMemoryRepository()
                                .ConditionallyInsert(new List<PageItemExtended>())
                ),
                typeof(ArgumentException),
                MessageCollection.Validator_VariableContainsZeroItems.Invoke("pageItemsExtended")
            ).SetArgDisplayNames($"{nameof(conditionallyInsertExceptionTestCases)}_03")

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

        [TestCaseSource(nameof(conditionallyInsertTestCases))]
        public void ConditionallyInsert_ShouldInsertTheExpectedNumberOfRows_WhenPageItemsExtended
            (Func<int> func, int expected)
        {

            // Arrange
            // Act
            int actual = func.Invoke();

            // Assert
            Assert.AreEqual(expected, actual);

        }
        [TestCaseSource(nameof(conditionallyInsertExceptionTestCases))]
        public void ConditionallyInsert_ShouldThrowACertainException_WhenUnproperArguments
            (TestDelegate del, Type expectedType, string expectedMessage)
                => ObjectMother.Method_ShouldThrowACertainException_WhenUnproperArguments(del, expectedType, expectedMessage);

        // TearDown		

    }
}

/*
    Author: numbworks@gmail.com
    Last Update: 19.06.2021
*/