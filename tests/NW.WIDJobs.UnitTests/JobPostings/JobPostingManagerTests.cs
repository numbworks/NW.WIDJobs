using NUnit.Framework;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using NW.WIDJobs.JobPostings;

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
                                ObjectMother.JobPostingManager_JobPage01Alt_ThresholdDateMostRecentPostingCreated,
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
                                ObjectMother.JobPostingManager_JobPage01Alt_ThresholdDateMostRecentPostingCreated,
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
        private static TestCaseData[] isThresholdConditionMetForThresholdDateTestCases =
        {

            // ThresholdDate > MostRecent
            new TestCaseData(
                   ObjectMother.JobPostingManager_JobPage01Alt_ThresholdDateMostRecentPostingCreatedPlusOneDay,
                   ObjectMother.JobPostingManager_JobPage01Alt_PostingCreatedCollection,
                   false
            ).SetArgDisplayNames($"{nameof(isThresholdConditionMetForThresholdDateTestCases)}_01"),

            // ThresholdDate > LeastRecent && ThresholdDate <= MostRecent
            new TestCaseData(
                   ObjectMother.JobPostingManager_JobPage01Alt_ThresholdDateMostRecentPostingCreatedMinusOneDay,
                   ObjectMother.JobPostingManager_JobPage01Alt_PostingCreatedCollection,
                   true
            ).SetArgDisplayNames($"{nameof(isThresholdConditionMetForThresholdDateTestCases)}_02"),

            // ThresholdDate == LeastRecent
            new TestCaseData(
                   ObjectMother.JobPostingManager_JobPage01Alt_ThresholdDateLeastRecentPostingCreated,
                   ObjectMother.JobPostingManager_JobPage01Alt_PostingCreatedCollection,
                   false
            ).SetArgDisplayNames($"{nameof(isThresholdConditionMetForThresholdDateTestCases)}_03"),

            // ThresholdDate < LeastRecent
            new TestCaseData(
                   ObjectMother.JobPostingManager_JobPage01Alt_ThresholdDateLeastRecentPostingCreatedMinusOneDay,
                   ObjectMother.JobPostingManager_JobPage01Alt_PostingCreatedCollection,
                   false
            ).SetArgDisplayNames($"{nameof(isThresholdConditionMetForThresholdDateTestCases)}_04")

        };
        private static TestCaseData[] isThresholdConditionMetForJobPostingIdTestCases =
        {

            new TestCaseData(
                ObjectMother.JobPostingManager_UnexistantJobPostingId,
                ObjectMother.Shared_JobPage01Alt_JobPostings,
                false
            ).SetArgDisplayNames($"{nameof(isThresholdConditionMetForJobPostingIdTestCases)}_01"),

            new TestCaseData(
                ObjectMother.Shared_JobPage01Alt_JobPostings[0].JobPostingId,
                ObjectMother.Shared_JobPage01Alt_JobPostings,
                true
            ).SetArgDisplayNames($"{nameof(isThresholdConditionMetForJobPostingIdTestCases)}_02")

        };
        private static TestCaseData[] removeUnsuitableForThresholdDateTestCases =
        {

            new TestCaseData(
                   ObjectMother.JobPostingManager_JobPage01Alt_ThresholdDate01,
                   ObjectMother.Shared_JobPage01Alt_JobPostings,
                   ObjectMother.JobPostingManager_JobPage01Alt_RangeForThresholdDate01
            ).SetArgDisplayNames($"{nameof(removeUnsuitableForThresholdDateTestCases)}_01"),

        };
        private static TestCaseData[] removeUnsuitableForJobPostingIdTestCases =
        {

            new TestCaseData(
                ObjectMother.JobPostingManager_UnexistantJobPostingId,
                ObjectMother.Shared_JobPage01Alt_JobPostings,
                ObjectMother.Shared_JobPage01Alt_JobPostings
            ).SetArgDisplayNames($"{nameof(removeUnsuitableForJobPostingIdTestCases)}_01"),

            new TestCaseData(
                ObjectMother.Shared_JobPage01Alt_JobPostings[5].JobPostingId,
                ObjectMother.Shared_JobPage01Alt_JobPostings,
                ObjectMother.Shared_JobPage01Alt_JobPostings.Take(5).ToList()
            ).SetArgDisplayNames($"{nameof(removeUnsuitableForJobPostingIdTestCases)}_02")

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

        [TestCaseSource(nameof(isThresholdConditionMetForThresholdDateTestCases))]
        public void IsThresholdConditionMet_ShouldReturnExpectedBoolean_WhenThresholdDate
            (DateTime thresholdDate, List<DateTime> postingCreatedCollection, bool expected)
        {

            // Arrange
            // Act
            bool actual = new JobPostingManager().IsThresholdConditionMet(thresholdDate, postingCreatedCollection);

            // Assert
            Assert.AreEqual(expected, actual);

        }

        [TestCaseSource(nameof(isThresholdConditionMetForJobPostingIdTestCases))]
        public void IsThresholdConditionMet_ShouldReturnExpectedBoolean_WhenJobPostingId
            (string jobPostingId, List<JobPosting> jobPostings, bool expected)
        {

            // Arrange
            // Act
            bool actual = new JobPostingManager().IsThresholdConditionMet(jobPostingId, jobPostings);

            // Assert
            Assert.AreEqual(expected, actual);

        }

        [TestCaseSource(nameof(removeUnsuitableForThresholdDateTestCases))]
        public void RemoveUnsuitable_ShouldReturnExpectedBoolean_WhenThresholdDate
            (DateTime thresholdDate, List<JobPosting> jobPostings, List<JobPosting> expected)
        {

            // Arrange
            // Act
            List<JobPosting> actual = new JobPostingManager().RemoveUnsuitable(thresholdDate, jobPostings);

            // Assert
            Assert.IsTrue(
                    ObjectMother.AreEqual(expected, actual)
                );

        }

        [TestCaseSource(nameof(removeUnsuitableForJobPostingIdTestCases))]
        public void RemoveUnsuitable_ShouldReturnExpectedBoolean_WhenJobPostingId
            (string jobPostingId, List<JobPosting> jobPostings, List<JobPosting> expected)
        {

            // Arrange
            // Act
            List<JobPosting> actual = new JobPostingManager().RemoveUnsuitable(jobPostingId, jobPostings);

            // Assert
            Assert.IsTrue(
                    ObjectMother.AreEqual(expected, actual)
                );

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
