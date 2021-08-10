using NUnit.Framework;
using System;

namespace NW.WIDJobs.UnitTests
{
    [TestFixture]
    public class FilenameFactoryTests
    {

        // Fields
        private static TestCaseData[] createForDatabaseTestCases =
        {

            new TestCaseData(
                    new Func<string>( 
                            () => new FilenameFactory()
                                        .CreateForDatabase(
                                            ObjectMother.FileNameFactory_FakeFilePath) 
                        ),
                    ObjectMother.FileNameFactory_DatabaseNameIfFilePath
                ).SetArgDisplayNames($"{nameof(createForDatabaseTestCases)}_01"),

            new TestCaseData(
                    new Func<string>(
                            () => new FilenameFactory()
                                        .CreateForDatabase(
                                            ObjectMother.FileNameFactory_FakeFilePath,
                                            ObjectMother.FileNameFactory_FakeDatabaseFileName)
                        ),
                    ObjectMother.FileNameFactory_DatabaseNameIfFilePathFileName
                ).SetArgDisplayNames($"{nameof(createForDatabaseTestCases)}_02"),

            new TestCaseData(
                    new Func<string>(
                            () => new FilenameFactory()
                                        .CreateForDatabase(
                                            ObjectMother.FileNameFactory_FakeFilePath,
                                            ObjectMother.FileNameFactory_FakeToken,
                                            ObjectMother.FileNameFactory_FakeNow)
                        ),
                    ObjectMother.FileNameFactory_DatabaseNameIfFilePathTokenNow
                ).SetArgDisplayNames($"{nameof(createForDatabaseTestCases)}_03"),

            new TestCaseData(
                    new Func<string>(
                            () => new FilenameFactory()
                                        .CreateForDatabase(
                                            ObjectMother.FileNameFactory_FakeFilePath,
                                            ObjectMother.FileNameFactory_FakeNow)
                        ),
                    ObjectMother.FileNameFactory_DatabaseNameIfFilePathNow
                ).SetArgDisplayNames($"{nameof(createForDatabaseTestCases)}_04")

        };
        private static TestCaseData[] createForDatabaseExceptionTestCases =
        {

            new TestCaseData(
                new TestDelegate(
                    () => new FilenameFactory()
                                .CreateForDatabase(null)
				),
                typeof(ArgumentNullException),
                new ArgumentNullException("filePath").Message
            ).SetArgDisplayNames($"{nameof(createForDatabaseExceptionTestCases)}_01"),

            new TestCaseData(
                new TestDelegate(
                    () => new FilenameFactory()
                                .CreateForDatabase(
                                    ObjectMother.FileNameFactory_FakeFilePath,
                                    null)
                ),
                typeof(ArgumentNullException),
                new ArgumentNullException("fileName").Message
            ).SetArgDisplayNames($"{nameof(createForDatabaseExceptionTestCases)}_02"),

            new TestCaseData(
                new TestDelegate(
                    () => new FilenameFactory()
                                .CreateForDatabase(
                                    ObjectMother.FileNameFactory_FakeFilePath,
                                    null,
                                    ObjectMother.FileNameFactory_FakeNow)
                ),
                typeof(ArgumentNullException),
                new ArgumentNullException("token").Message
            ).SetArgDisplayNames($"{nameof(createForDatabaseExceptionTestCases)}_03")

        };
        private static TestCaseData[] createForMetricsJsonTestCases =
        {

            new TestCaseData(
                    new Func<string>(
                            () => new FilenameFactory()
                                        .CreateForMetricsJson(
                                            ObjectMother.FileNameFactory_FakeFilePath,
                                            ObjectMother.FileNameFactory_FakeNow,
                                            true)
                        ),
                    ObjectMother.FileNameFactory_MetricsJsonIfTrue
                ).SetArgDisplayNames($"{nameof(createForMetricsJsonTestCases)}_01"),

            new TestCaseData(
                    new Func<string>(
                            () => new FilenameFactory()
                                        .CreateForMetricsJson(
                                            ObjectMother.FileNameFactory_FakeFilePath,
                                            ObjectMother.FileNameFactory_FakeNow,
                                            false)
                        ),
                    ObjectMother.FileNameFactory_MetricsJsonIfFalse
                ).SetArgDisplayNames($"{nameof(createForMetricsJsonTestCases)}_02")

        };
        private static TestCaseData[] createForMetricsJsonExceptionTestCases =
        {

            new TestCaseData(
                new TestDelegate(
                    () => new FilenameFactory()
                                .CreateForMetricsJson(
                                    null,
                                    ObjectMother.FileNameFactory_FakeNow,
                                    true)
                ),
                typeof(ArgumentNullException),
                new ArgumentNullException("filePath").Message
            ).SetArgDisplayNames($"{nameof(createForMetricsJsonExceptionTestCases)}_01"),

            new TestCaseData(
                new TestDelegate(
                    () => new FilenameFactory()
                                .CreateForMetricsJson(
                                    ObjectMother.FileNameFactory_FakeFilePath,
                                    null,
                                    ObjectMother.FileNameFactory_FakeNow
                                    )
                ),
                typeof(ArgumentNullException),
                new ArgumentNullException("token").Message
            ).SetArgDisplayNames($"{nameof(createForMetricsJsonExceptionTestCases)}_02")


        };
        private static TestCaseData[] createForExplorationJsonTestCases =
        {

            new TestCaseData(
                    new Func<string>(
                            () => new FilenameFactory()
                                        .CreateForExplorationJson(
                                            ObjectMother.FileNameFactory_FakeFilePath,
                                            ObjectMother.FileNameFactory_FakeNow)
                        ),
                    ObjectMother.FileNameFactory_ExplorationJsonIfFilePathNow
                ).SetArgDisplayNames($"{nameof(createForMetricsJsonTestCases)}_01"),

            new TestCaseData(
                    new Func<string>(
                            () => new FilenameFactory()
                                        .CreateForExplorationJson(
                                            ObjectMother.FileNameFactory_FakeFilePath,
                                            ObjectMother.FileNameFactory_FakeToken,
                                            ObjectMother.FileNameFactory_FakeNow)
                        ),
                    ObjectMother.FileNameFactory_ExplorationJsonIfFilePathTokenNow
                ).SetArgDisplayNames($"{nameof(createForMetricsJsonTestCases)}_02")

        };
        private static TestCaseData[] createForExplorationJsonExceptionTestCases =
        {

            new TestCaseData(
                new TestDelegate(
                    () => new FilenameFactory()
                                .CreateForExplorationJson(
                                    null,
                                    ObjectMother.FileNameFactory_FakeNow)
                ),
                typeof(ArgumentNullException),
                new ArgumentNullException("filePath").Message
            ).SetArgDisplayNames($"{nameof(createForExplorationJsonExceptionTestCases)}_01"),

            new TestCaseData(
                new TestDelegate(
                    () => new FilenameFactory()
                                .CreateForExplorationJson(
                                    ObjectMother.FileNameFactory_FakeFilePath,
                                    null,
                                    ObjectMother.FileNameFactory_FakeNow
                                    )
                ),
                typeof(ArgumentNullException),
                new ArgumentNullException("token").Message
            ).SetArgDisplayNames($"{nameof(createForExplorationJsonExceptionTestCases)}_02")


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
        public void CreateForDatabase_ShouldThrowACertainException_WhenUnproperArguments
            (TestDelegate del, Type expectedType, string expectedMessage)
                => ObjectMother.Method_ShouldThrowACertainException_WhenUnproperArguments(del, expectedType, expectedMessage);

        [TestCaseSource(nameof(createForMetricsJsonTestCases))]
        public void CreateForMetricsJson_ShouldReturnExpectedString_WhenInvoked
            (Func<string> func, string expected)
        {

            // Arrange
            // Act
            string actual = func.Invoke();

            // Assert
            Assert.AreEqual(expected, actual);

        }
        [TestCaseSource(nameof(createForMetricsJsonExceptionTestCases))]
        public void CreateForMetricsJson_ShouldThrowACertainException_WhenUnproperArguments
            (TestDelegate del, Type expectedType, string expectedMessage)
                => ObjectMother.Method_ShouldThrowACertainException_WhenUnproperArguments(del, expectedType, expectedMessage);

        [TestCaseSource(nameof(createForExplorationJsonTestCases))]
        public void CreateForExplorationJson_ShouldReturnExpectedString_WhenInvoked
            (Func<string> func, string expected)
        {

            // Arrange
            // Act
            string actual = func.Invoke();

            // Assert
            Assert.AreEqual(expected, actual);

        }
        [TestCaseSource(nameof(createForExplorationJsonExceptionTestCases))]
        public void CreateForExplorationJson_ShouldThrowACertainException_WhenUnproperArguments
            (TestDelegate del, Type expectedType, string expectedMessage)
                => ObjectMother.Method_ShouldThrowACertainException_WhenUnproperArguments(del, expectedType, expectedMessage);

        // TearDown		

    }
}

/*
    Author: numbworks@gmail.com
    Last Update: 12.06.2021
*/