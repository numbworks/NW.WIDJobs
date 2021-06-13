using NUnit.Framework;
using System;

namespace NW.WIDJobs.UnitTests
{
    [TestFixture]
    public class WIDFileNameFactoryTests
    {

        // Fields
        private static TestCaseData[] createForDatabaseTestCases =
        {

            new TestCaseData(
                    new Func<string>( 
                            () => new WIDFileNameFactory()
                                        .CreateForDatabase(
                                            ObjectMother.WIDFileNameFactory_FakeFilePath) 
                        ),
                    ObjectMother.WIDFileNameFactory_DatabaseNameIfFilePath
                ).SetArgDisplayNames($"{nameof(createForDatabaseTestCases)}_01"),

            new TestCaseData(
                    new Func<string>(
                            () => new WIDFileNameFactory()
                                        .CreateForDatabase(
                                            ObjectMother.WIDFileNameFactory_FakeFilePath,
                                            ObjectMother.WIDFileNameFactory_FakeDatabaseFileName)
                        ),
                    ObjectMother.WIDFileNameFactory_DatabaseNameIfFilePathFileName
                ).SetArgDisplayNames($"{nameof(createForDatabaseTestCases)}_02"),

            new TestCaseData(
                    new Func<string>(
                            () => new WIDFileNameFactory()
                                        .CreateForDatabase(
                                            ObjectMother.WIDFileNameFactory_FakeFilePath,
                                            ObjectMother.WIDFileNameFactory_FakeToken,
                                            ObjectMother.WIDFileNameFactory_FakeNow)
                        ),
                    ObjectMother.WIDFileNameFactory_DatabaseNameIfFilePathTokenNow
                ).SetArgDisplayNames($"{nameof(createForDatabaseTestCases)}_03"),

            new TestCaseData(
                    new Func<string>(
                            () => new WIDFileNameFactory()
                                        .CreateForDatabase(
                                            ObjectMother.WIDFileNameFactory_FakeFilePath,
                                            ObjectMother.WIDFileNameFactory_FakeNow)
                        ),
                    ObjectMother.WIDFileNameFactory_DatabaseNameIfFilePathNow
                ).SetArgDisplayNames($"{nameof(createForDatabaseTestCases)}_04")

        };
        private static TestCaseData[] createForDatabaseExceptionTestCases =
        {

            new TestCaseData(
                new TestDelegate(
                    () => new WIDFileNameFactory()
                                .CreateForDatabase(null)
				),
                typeof(ArgumentNullException),
                new ArgumentNullException("filePath").Message
            ).SetArgDisplayNames($"{nameof(createForDatabaseExceptionTestCases)}_01"),

            new TestCaseData(
                new TestDelegate(
                    () => new WIDFileNameFactory()
                                .CreateForDatabase(
                                    ObjectMother.WIDFileNameFactory_FakeFilePath,
                                    null)
                ),
                typeof(ArgumentNullException),
                new ArgumentNullException("fileName").Message
            ).SetArgDisplayNames($"{nameof(createForDatabaseExceptionTestCases)}_02"),

            new TestCaseData(
                new TestDelegate(
                    () => new WIDFileNameFactory()
                                .CreateForDatabase(
                                    ObjectMother.WIDFileNameFactory_FakeFilePath,
                                    null,
                                    ObjectMother.WIDFileNameFactory_FakeNow)
                ),
                typeof(ArgumentNullException),
                new ArgumentNullException("token").Message
            ).SetArgDisplayNames($"{nameof(createForDatabaseExceptionTestCases)}_03")

        };

        // SetUp
        // Tests
        [TestCaseSource(nameof(createForDatabaseTestCases))]
        public void CreateForDatabase_ShouldReturnExpectedString_WhenInvoked
            (Func<string> func, string expected)
        {

            // Arrange
            // Act
            string actual = func.Invoke();

            // Assert
            Assert.AreEqual(expected, actual);

        }
        [TestCaseSource(nameof(createForDatabaseExceptionTestCases))]
        public void SomeMethod_ShouldThrowACertainException_WhenUnproperArguments
            (TestDelegate del, Type expectedType, string expectedMessage)
                => ObjectMother.Method_ShouldThrowACertainException_WhenUnproperArguments(del, expectedType, expectedMessage);

        // TearDown		

    }
}

/*
    Author: numbworks@gmail.com
    Last Update: 12.06.2021
*/