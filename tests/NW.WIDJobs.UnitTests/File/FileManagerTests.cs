﻿using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace NW.WIDJobs.UnitTests
{

    [TestFixture]
    public class FileManagerTests
    {

        // Fields
        private static TestCaseData[] fileManagerExceptionTestCases =
        {

            new TestCaseData(
                new TestDelegate( () => new FileManager(null) ),
                typeof(ArgumentNullException),
                new ArgumentNullException("fileAdapter").Message
                ).SetArgDisplayNames($"{nameof(fileManagerExceptionTestCases)}_01"),

        };
        private static TestCaseData[] readAllLinesExceptionTestCases =
        {

            new TestCaseData(
                new TestDelegate(
                        () => new FileManager().ReadAllLines(null)
                    ),
                typeof(ArgumentNullException),
                new ArgumentNullException("file").Message
                ).SetArgDisplayNames($"{nameof(readAllLinesExceptionTestCases)}_01"),

            new TestCaseData(
                new TestDelegate(
                        () => new FileManager().ReadAllLines(ObjectMother.FileManager_FileInfoAdapterDoesntExist)
                    ),
                typeof(ArgumentException),
                MessageCollection.Validator_ProvidedPathDoesntExist.Invoke(ObjectMother.FileManager_FileInfoAdapterDoesntExist)
                ).SetArgDisplayNames($"{nameof(readAllLinesExceptionTestCases)}_02"),

            new TestCaseData(
                new TestDelegate(
                        () => new FileManager(ObjectMother.FileManager_FileAdapterReadAllMethodsThrowIOException)
                                    .ReadAllLines(ObjectMother.FileManager_FileInfoAdapterExists)
                    ),
                typeof(Exception),
                MessageCollection.FileManager_NotPossibleToRead.Invoke(
                                    ObjectMother.FileManager_FileInfoAdapterExists,
                                    ObjectMother.FileManager_FileAdapterIOException)
                ).SetArgDisplayNames($"{nameof(readAllLinesExceptionTestCases)}_03")

        };
        private static TestCaseData[] readAllTextExceptionTestCases =
        {

            new TestCaseData(
                new TestDelegate(
                        () => new FileManager().ReadAllText(null)
                    ),
                typeof(ArgumentNullException),
                new ArgumentNullException("file").Message
                ).SetArgDisplayNames($"{nameof(readAllTextExceptionTestCases)}_01"),

            new TestCaseData(
                new TestDelegate(
                        () => new FileManager().ReadAllText(ObjectMother.FileManager_FileInfoAdapterDoesntExist)
                    ),
                typeof(ArgumentException),
                MessageCollection.Validator_ProvidedPathDoesntExist.Invoke(ObjectMother.FileManager_FileInfoAdapterDoesntExist)
                ).SetArgDisplayNames($"{nameof(readAllTextExceptionTestCases)}_02"),

            new TestCaseData(
                new TestDelegate(
                        () => new FileManager(ObjectMother.FileManager_FileAdapterReadAllMethodsThrowIOException)
                                    .ReadAllText(ObjectMother.FileManager_FileInfoAdapterExists)
                    ),
                typeof(Exception),
                MessageCollection.FileManager_NotPossibleToRead.Invoke(
                                    ObjectMother.FileManager_FileInfoAdapterExists,
                                    ObjectMother.FileManager_FileAdapterIOException)
                ).SetArgDisplayNames($"{nameof(readAllTextExceptionTestCases)}_03")

        };
        private static TestCaseData[] writeAllLinesExceptionTestCases =
        {

            new TestCaseData(
                new TestDelegate(
                        () => new FileManager().WriteAllLines(null, ObjectMother.FileManager_ContentMultipleLines)
                    ),
                typeof(ArgumentNullException),
                new ArgumentNullException("file").Message
                ).SetArgDisplayNames($"{nameof(writeAllLinesExceptionTestCases)}_01"),

            new TestCaseData(
                new TestDelegate(
                        () => new FileManager(ObjectMother.FileManager_FileAdapterWriteAllMethodsThrowIOException)
                                    .WriteAllLines(
                                        ObjectMother.FileManager_FileInfoAdapterExists,
                                        ObjectMother.FileManager_ContentMultipleLines)
                    ),
                typeof(Exception),
                MessageCollection.FileManager_NotPossibleToWrite.Invoke(
                                    ObjectMother.FileManager_FileInfoAdapterExists,
                                    ObjectMother.FileManager_FileAdapterIOException)
                ).SetArgDisplayNames($"{nameof(writeAllLinesExceptionTestCases)}_02")

        };
        private static TestCaseData[] writeAllTextExceptionTestCases =
        {

            new TestCaseData(
                new TestDelegate(
                        () => new FileManager().WriteAllText(null, ObjectMother.FileManager_ContentSingleLine)
                    ),
                typeof(ArgumentNullException),
                new ArgumentNullException("file").Message
                ).SetArgDisplayNames($"{nameof(writeAllTextExceptionTestCases)}_01"),

            new TestCaseData(
                new TestDelegate(
                        () => new FileManager(ObjectMother.FileManager_FileAdapterWriteAllMethodsThrowIOException)
                                    .WriteAllText(
                                        ObjectMother.FileManager_FileInfoAdapterExists,
                                        ObjectMother.FileManager_ContentSingleLine)
                    ),
                typeof(Exception),
                MessageCollection.FileManager_NotPossibleToWrite.Invoke(
                                    ObjectMother.FileManager_FileInfoAdapterExists,
                                    ObjectMother.FileManager_FileAdapterIOException)
                ).SetArgDisplayNames($"{nameof(writeAllTextExceptionTestCases)}_02")

        };

        // SetUp
        // Tests
        [TestCaseSource(nameof(fileManagerExceptionTestCases))]
        public void FileManager_ShouldThrowACertainException_WhenUnproperArguments
            (TestDelegate del, Type expectedType, string expectedMessage)
                => ObjectMother.Method_ShouldThrowACertainException_WhenUnproperArguments(del, expectedType, expectedMessage);

        [TestCaseSource(nameof(readAllLinesExceptionTestCases))]
        public void ReadAllLines_ShouldThrowACertainException_WhenUnproperArguments
            (TestDelegate del, Type expectedType, string expectedMessage)
                => ObjectMother.Method_ShouldThrowACertainException_WhenUnproperArguments(del, expectedType, expectedMessage);

        [TestCaseSource(nameof(readAllTextExceptionTestCases))]
        public void ReadAllText_ShouldThrowACertainException_WhenUnproperArguments
            (TestDelegate del, Type expectedType, string expectedMessage)
                => ObjectMother.Method_ShouldThrowACertainException_WhenUnproperArguments(del, expectedType, expectedMessage);

        [TestCaseSource(nameof(writeAllLinesExceptionTestCases))]
        public void WriteAllLines_ShouldThrowACertainException_WhenUnproperArguments
            (TestDelegate del, Type expectedType, string expectedMessage)
                => ObjectMother.Method_ShouldThrowACertainException_WhenUnproperArguments(del, expectedType, expectedMessage);

        [TestCaseSource(nameof(writeAllTextExceptionTestCases))]
        public void WriteAllText_ShouldThrowACertainException_WhenUnproperArguments
            (TestDelegate del, Type expectedType, string expectedMessage)
                => ObjectMother.Method_ShouldThrowACertainException_WhenUnproperArguments(del, expectedType, expectedMessage);

        [Test]
        public void ReadAllLines_ShouldReturnStrings_WhenFileExists()
        {

            // Arrange
            // Act
            IEnumerable<string> actual
                = new FileManager(ObjectMother.FileManager_FileAdapterAllMethodsWork)
                            .ReadAllLines(ObjectMother.FileManager_FileInfoAdapterExists);

            // Assert
            Assert.AreEqual(ObjectMother.FileManager_ContentMultipleLines, actual);

        }

        [Test]
        public void ReadAllText_ShouldReturnString_WhenFileExists()
        {

            // Arrange
            // Act
            string actual
                = new FileManager(ObjectMother.FileManager_FileAdapterAllMethodsWork)
                            .ReadAllText(ObjectMother.FileManager_FileInfoAdapterExists);

            // Assert
            Assert.AreEqual(ObjectMother.FileManager_ContentSingleLine, actual);

        }

        [Test]
        public void WriteAllLines_ShouldSuccessfullyWriteToFile_WhenNoIOIssuesArise()
        {

            // Arrange
            // Act
            // Assert
            try
            {

                new FileManager(ObjectMother.FileManager_FileAdapterAllMethodsWork)
                        .WriteAllLines(ObjectMother.FileManager_FileInfoAdapterExists, ObjectMother.FileManager_ContentMultipleLines);
                Assert.IsTrue(true);

            }
            catch
            {

                Assert.IsFalse(false);

            }

        }

        [Test]
        public void WriteAllText_ShouldSuccessfullyWriteToFile_WhenNoIOIssuesArise()
        {

            // Arrange
            // Act
            // Assert
            try
            {

                new FileManager(ObjectMother.FileManager_FileAdapterAllMethodsWork)
                        .WriteAllText(ObjectMother.FileManager_FileInfoAdapterExists, ObjectMother.FileManager_ContentSingleLine);
                Assert.IsTrue(true);

            }
            catch
            {

                Assert.IsFalse(false);

            }

        }

        // TearDown
        // Support methods

    }

}
/*
    Author: numbworks@gmail.com
    Last Update: 30.05.2021
*/
