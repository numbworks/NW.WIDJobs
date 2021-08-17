using NUnit.Framework;
using System;
using NW.WIDJobs.Database;

namespace NW.WIDJobs.UnitTests
{
    [TestFixture]
    public class DatabaseContextTests
    {

        // Fields
        private static TestCaseData[] databaseContextTestCases =
        {

            new TestCaseData(
                    ObjectMother.DatabaseContext_DatabasePath,
                    ObjectMother.DatabaseContext_DatabaseName01,
                    ObjectMother.DatabaseContext_ConnectionString
                ).SetArgDisplayNames($"{nameof(databaseContextTestCases)}_01"),

            new TestCaseData(
                    ObjectMother.DatabaseContext_DatabasePath,
                    ObjectMother.DatabaseContext_DatabaseName02,
                    ObjectMother.DatabaseContext_ConnectionString
                ).SetArgDisplayNames($"{nameof(databaseContextTestCases)}_02")

        };
        private static TestCaseData[] databaseContextExceptionTestCases =
        {

            new TestCaseData(
                new TestDelegate(
                    () => new DatabaseContext(
                                (string)null, 
                                ObjectMother.DatabaseContext_DatabaseName01
                            )
				),
                typeof(ArgumentNullException),
                new ArgumentNullException("databasePath").Message
            ).SetArgDisplayNames($"{nameof(databaseContextExceptionTestCases)}_01"),

            new TestCaseData(
                new TestDelegate(
                    () => new DatabaseContext(
                                ObjectMother.DatabaseContext_DatabasePath, 
                                null
                            )
                ),
                typeof(ArgumentNullException),
                new ArgumentNullException("databaseName").Message
            ).SetArgDisplayNames($"{nameof(databaseContextExceptionTestCases)}_02")

        };

        // SetUp
        // Tests
        [TestCaseSource(nameof(databaseContextTestCases))]
        public void DatabaseContext_ShouldInstantiateObject_WhenProperArguments
            (string databasePath, string databaseName, string expectedConnectionString)
        {

            // Arrange
            // Act
            string actual = new DatabaseContext(databasePath, databaseName).ConnectionString;

            // Assert
            Assert.AreEqual(expectedConnectionString, actual);

        }
        
        [TestCaseSource(nameof(databaseContextExceptionTestCases))]
        public void DatabaseContext_ShouldThrowACertainException_WhenUnproperArguments
            (TestDelegate del, Type expectedType, string expectedMessage)
                => ObjectMother.Method_ShouldThrowACertainException_WhenUnproperArguments(del, expectedType, expectedMessage);

        // TearDown		

    }
}

/*
    Author: numbworks@gmail.com
    Last Update: 09.06.2021
*/