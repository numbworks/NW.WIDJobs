using NUnit.Framework;
using System;
using NW.WIDJobs.Filenames;

namespace NW.WIDJobs.UnitTests
{
    [TestFixture]
    public class FilenameFactoryTests
    {

        #region Fields

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
        private static TestCaseData[] createForMetricCollectionJsonTestCases =
        {

            new TestCaseData(
                    new Func<string>(
                            () => new FilenameFactory()
                                        .CreateForMetricCollectionJson(
                                            ObjectMother.FileNameFactory_FakeFilePath,
                                            ObjectMother.FileNameFactory_FakeNow,
                                            true)
                        ),
                    ObjectMother.FileNameFactory_MetricCollectionJsonIfTrue
                ).SetArgDisplayNames($"{nameof(createForMetricCollectionJsonTestCases)}_01"),

            new TestCaseData(
                    new Func<string>(
                            () => new FilenameFactory()
                                        .CreateForMetricCollectionJson(
                                            ObjectMother.FileNameFactory_FakeFilePath,
                                            ObjectMother.FileNameFactory_FakeNow,
                                            false)
                        ),
                    ObjectMother.FileNameFactory_MetricCollectionJsonIfFalse
                ).SetArgDisplayNames($"{nameof(createForMetricCollectionJsonTestCases)}_02")

        };
        private static TestCaseData[] createForMetricCollectionJsonExceptionTestCases =
        {

            new TestCaseData(
                new TestDelegate(
                    () => new FilenameFactory()
                                .CreateForMetricCollectionJson(
                                    null,
                                    ObjectMother.FileNameFactory_FakeNow,
                                    true)
                ),
                typeof(ArgumentNullException),
                new ArgumentNullException("filePath").Message
            ).SetArgDisplayNames($"{nameof(createForMetricCollectionJsonExceptionTestCases)}_01")

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
                ).SetArgDisplayNames($"{nameof(createForMetricCollectionJsonTestCases)}_01")

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
            ).SetArgDisplayNames($"{nameof(createForExplorationJsonExceptionTestCases)}_01")


        };
        private static TestCaseData[] createForBulletPointsJsonTestCases =
        {

            new TestCaseData(
                    new Func<string>(
                            () => new FilenameFactory()
                                        .CreateForBulletPointTypesJson(
                                            ObjectMother.FileNameFactory_FakeFilePath,
                                            ObjectMother.FileNameFactory_FakeNow)
                        ),
                    ObjectMother.FileNameFactory_BulletPointsJsonIfFilePathNow
                ).SetArgDisplayNames($"{nameof(createForBulletPointsJsonTestCases)}_01")

        };
        private static TestCaseData[] createForBulletPointsJsonExceptionTestCases =
        {

            new TestCaseData(
                new TestDelegate(
                    () => new FilenameFactory()
                                .CreateForBulletPointTypesJson(
                                    null,
                                    ObjectMother.FileNameFactory_FakeNow)
                ),
                typeof(ArgumentNullException),
                new ArgumentNullException("filePath").Message
            ).SetArgDisplayNames($"{nameof(createForBulletPointsJsonExceptionTestCases)}_01")


        };

        #endregion

        #region SetUp
        #endregion

        #region Tests

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

        [TestCaseSource(nameof(createForMetricCollectionJsonTestCases))]
        public void CreateForMetricCollectionJson_ShouldReturnExpectedString_WhenInvoked
            (Func<string> func, string expected)
        {

            // Arrange
            // Act
            string actual = func.Invoke();

            // Assert
            Assert.AreEqual(expected, actual);

        }
        [TestCaseSource(nameof(createForMetricCollectionJsonExceptionTestCases))]
        public void CreateForMetricCollectionJson_ShouldThrowACertainException_WhenUnproperArguments
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

        [TestCaseSource(nameof(createForBulletPointsJsonTestCases))]
        public void CreateForBulletPointsJson_ShouldReturnExpectedString_WhenInvoked
            (Func<string> func, string expected)
        {

            // Arrange
            // Act
            string actual = func.Invoke();

            // Assert
            Assert.AreEqual(expected, actual);

        }
        [TestCaseSource(nameof(createForBulletPointsJsonExceptionTestCases))]
        public void CreateForBulletPointsJson_ShouldThrowACertainException_WhenUnproperArguments
            (TestDelegate del, Type expectedType, string expectedMessage)
                => ObjectMother.Method_ShouldThrowACertainException_WhenUnproperArguments(del, expectedType, expectedMessage);

        #endregion

        #region TearDown
        #endregion

    }
}

/*
    Author: numbworks@gmail.com
    Last Update: 08.10.2021
*/