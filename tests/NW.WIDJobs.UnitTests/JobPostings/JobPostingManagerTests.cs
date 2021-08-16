using NUnit.Framework;
using System;
using System.Collections;
using System.Collections.Generic;

namespace NW.WIDJobs.UnitTests
{
    [TestFixture]
    public class JobPostingManagerTests
    {

        #region Fields

        private static TestCaseData[] isThresholdConditionMetForThresholdDateExceptionTestCases =
        {

            new TestCaseData(
                new TestDelegate(
                    () => new JobPostingManager()
                            .IsThresholdConditionMet(
                                ObjectMother.JobPostingManager_JobPage01_PostingCreated,
                                null
                                )
                ),
                typeof(ArgumentNullException),
                new ArgumentNullException("postingCreatedCollection").Message
            ).SetArgDisplayNames($"{nameof(isThresholdConditionMetForThresholdDateExceptionTestCases)}_01")

        };
        private static TestCaseData[] isThresholdConditionMetForJobPostingIdExceptionTestCases =
        {

            new TestCaseData(
                new TestDelegate(
                    () => new JobPostingManager()
                            .IsThresholdConditionMet(
                                null,
                                ObjectMother.Shared_JobPage01_JobPostings
                                )
                ),
                typeof(ArgumentNullException),
                new ArgumentNullException("jobPostingId").Message
            ).SetArgDisplayNames($"{nameof(isThresholdConditionMetForThresholdDateExceptionTestCases)}_01"),

            new TestCaseData(
                new TestDelegate(
                    () => new JobPostingManager()
                            .IsThresholdConditionMet(
                                ObjectMother.Shared_FakeRunId,
                                null
                                )
                ),
                typeof(ArgumentNullException),
                new ArgumentNullException("jobPostings").Message
            ).SetArgDisplayNames($"{nameof(isThresholdConditionMetForThresholdDateExceptionTestCases)}_02")

        };
        private static TestCaseData[] removeUnsuitableForThresholdDateExceptionTestCases =
        {

            new TestCaseData(
                new TestDelegate(
                    () => new JobPostingManager()
                            .RemoveUnsuitable(
                                ObjectMother.JobPostingManager_JobPage01_PostingCreated,
                                null
                                )
                ),
                typeof(ArgumentNullException),
                new ArgumentNullException("jobPostings").Message
            ).SetArgDisplayNames($"{nameof(isThresholdConditionMetForThresholdDateExceptionTestCases)}_01")

        };
        private static TestCaseData[] removeUnsuitableForJobPostingIdExceptionTestCases =
        {

            new TestCaseData(
                new TestDelegate(
                    () => new JobPostingManager()
                            .RemoveUnsuitable(
                                null,
                                ObjectMother.Shared_JobPage01_JobPostings
                                )
                ),
                typeof(ArgumentNullException),
                new ArgumentNullException("jobPostingId").Message
            ).SetArgDisplayNames($"{nameof(isThresholdConditionMetForThresholdDateExceptionTestCases)}_01"),

            new TestCaseData(
                new TestDelegate(
                    () => new JobPostingManager()
                            .RemoveUnsuitable(
                                ObjectMother.Shared_FakeRunId,
                                null
                                )
                ),
                typeof(ArgumentNullException),
                new ArgumentNullException("jobPostings").Message
            ).SetArgDisplayNames($"{nameof(isThresholdConditionMetForThresholdDateExceptionTestCases)}_02")

        };



        private static TestCaseData[] someMethodTestCases =
        {

            new TestCaseData(
                    "Some message",
                    false
                ).SetArgDisplayNames($"{nameof(someMethodTestCases)}_01")

        };

        #endregion

        #region SetUp

        #endregion

        #region Tests

        [TestCaseSource(nameof(isThresholdConditionMetForThresholdDateExceptionTestCases))]
        public void IsThresholdConditionMetForThresholdDate_ShouldThrowACertainException_WhenUnproperArguments
            (TestDelegate del, Type expectedType, string expectedMessage)
                => ObjectMother.Method_ShouldThrowACertainException_WhenUnproperArguments(del, expectedType, expectedMessage);

        [TestCaseSource(nameof(isThresholdConditionMetForJobPostingIdExceptionTestCases))]
        public void IsThresholdConditionMetForJobPostings_ShouldThrowACertainException_WhenUnproperArguments
            (TestDelegate del, Type expectedType, string expectedMessage)
                => ObjectMother.Method_ShouldThrowACertainException_WhenUnproperArguments(del, expectedType, expectedMessage);

        [TestCaseSource(nameof(removeUnsuitableForThresholdDateExceptionTestCases))]
        public void RemoveUnsuitableForThresholdDate_ShouldThrowACertainException_WhenUnproperArguments
            (TestDelegate del, Type expectedType, string expectedMessage)
                => ObjectMother.Method_ShouldThrowACertainException_WhenUnproperArguments(del, expectedType, expectedMessage);

        [TestCaseSource(nameof(removeUnsuitableForJobPostingIdExceptionTestCases))]
        public void RemoveUnsuitableForJobPostingId_ShouldThrowACertainException_WhenUnproperArguments
            (TestDelegate del, Type expectedType, string expectedMessage)
                => ObjectMother.Method_ShouldThrowACertainException_WhenUnproperArguments(del, expectedType, expectedMessage);



        [TestCaseSource(nameof(someMethodTestCases))]
        public void SomeMethod_Should_When
            (string message, bool expected)
        {

            // Arrange
            // Act
            // Assert

        }

        [Test]
        public void SomeMethod_Should_When()
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
    Last Update: 16.08.2021
*/
