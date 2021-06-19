using NUnit.Framework;
using System;
using System.Collections;
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

        [Test]
        public void SomeMethod_Should_When()
        {

            // Arrange
            // Act
            // Assert

        }

        // TearDown		

    }
}

/*
    Author: numbworks@gmail.com
    Last Update: 19.06.2021
*/