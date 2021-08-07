using NUnit.Framework;
using System;

namespace NW.WIDJobs.UnitTests
{
    [TestFixture]
    public class JobPostingExtendedManagerTests
    {

        #region Fields

        private static TestCaseData[] jobPostingExtendedManagerExceptionTestCases =
        {

            new TestCaseData(
                new TestDelegate(
                    () => new JobPostingExtendedManager(null, new JobPostingExtendedDeserializer())
                ),
                typeof(ArgumentNullException),
                new ArgumentNullException("getRequestManagerFactory").Message
            ).SetArgDisplayNames($"{nameof(jobPostingExtendedManagerExceptionTestCases)}_01"),

            new TestCaseData(
                new TestDelegate(
                    () => new JobPostingExtendedManager(new GetRequestManagerFactory(), null)
                ),
                typeof(ArgumentNullException),
                new ArgumentNullException("jobPostingExtendedDeserializer").Message
            ).SetArgDisplayNames($"{nameof(jobPostingExtendedManagerExceptionTestCases)}_02")

        };
        private static TestCaseData[] jobPostingExtendedManagerTestCases =
        {

            new TestCaseData(
                    "Some message",
                    false
                ).SetArgDisplayNames($"{nameof(jobPostingExtendedManagerTestCases)}_01")

        };

        #endregion

        #region SetUp

        #endregion

        #region Tests

        [TestCaseSource(nameof(jobPostingExtendedManagerExceptionTestCases))]
        public void JobPostingExtendedManager_ShouldThrowACertainException_WhenUnproperArguments
            (TestDelegate del, Type expectedType, string expectedMessage)
                => ObjectMother.Method_ShouldThrowACertainException_WhenUnproperArguments(del, expectedType, expectedMessage);

        [TestCaseSource(nameof(jobPostingExtendedManagerTestCases))]
        public void JobPostingExtendedManager_Should_When
            (string message, bool expected)
        {

            // Arrange
            // Act
            // Assert

        }

        #endregion

        #region TearDown

        #endregion

    }
}

/*
    Author: numbworks@gmail.com
    Last Update: 07.08.2021
*/