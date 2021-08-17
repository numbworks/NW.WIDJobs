using NUnit.Framework;
using System;
using NW.WIDJobs.HttpRequests;
using NW.WIDJobs.JobPostings;

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
        private static TestCaseData[] getJobPostingExtendedExceptionTestCases =
        {

            new TestCaseData(
                new TestDelegate(
                    () => new JobPostingExtendedManager().GetJobPostingExtended(null)
                ),
                typeof(ArgumentNullException),
                new ArgumentNullException("jobPosting").Message
            ).SetArgDisplayNames($"{nameof(getJobPostingExtendedExceptionTestCases)}_01")

        };
        private static TestCaseData[] sendGetRequestExceptionTestCases =
        {

            new TestCaseData(
                new TestDelegate(
                    () => new JobPostingExtendedManager().SendGetRequest(null)
                ),
                typeof(ArgumentNullException),
                new ArgumentNullException("jobPosting").Message
            ).SetArgDisplayNames($"{nameof(sendGetRequestExceptionTestCases)}_01")

        };
        private static TestCaseData[] getJobPostingExtendedTestCases =
        {

            new TestCaseData(
                    ObjectMother.Shared_JobPage01_JobPostingExtended01_Content,
                    ObjectMother.Shared_JobPage01_JobPosting01,
                    ObjectMother.Shared_JobPage01_JobPostingExtended01
                ).SetArgDisplayNames($"{nameof(getJobPostingExtendedTestCases)}_01")

        };

        #endregion

        #region SetUp

        #endregion

        #region Tests

        [TestCaseSource(nameof(jobPostingExtendedManagerExceptionTestCases))]
        public void JobPostingExtendedManager_ShouldThrowACertainException_WhenUnproperArguments
            (TestDelegate del, Type expectedType, string expectedMessage)
                => ObjectMother.Method_ShouldThrowACertainException_WhenUnproperArguments(del, expectedType, expectedMessage);

        [TestCaseSource(nameof(getJobPostingExtendedExceptionTestCases))]
        public void GetJobPostingExtended_ShouldThrowACertainException_WhenUnproperArguments
            (TestDelegate del, Type expectedType, string expectedMessage)
                => ObjectMother.Method_ShouldThrowACertainException_WhenUnproperArguments(del, expectedType, expectedMessage);

        [TestCaseSource(nameof(sendGetRequestExceptionTestCases))]
        public void SendPostRequest_ShouldThrowACertainException_WhenUnproperArguments
            (TestDelegate del, Type expectedType, string expectedMessage)
                => ObjectMother.Method_ShouldThrowACertainException_WhenUnproperArguments(del, expectedType, expectedMessage);

        [TestCaseSource(nameof(getJobPostingExtendedTestCases))]
        public void GetJobPostingExtended_ShouldReturnExpectedJobPostingExtended_WhenInvoked
            (string fakeResponse, JobPosting jobPosting, JobPostingExtended expected)
        {

            // Arrange
            FakeGetRequestManager fakeGetRequestManager = new FakeGetRequestManager(fakeResponse);
            FakeGetRequestManagerFactory fakeGetRequestManagerFactory = new FakeGetRequestManagerFactory(fakeGetRequestManager);

            // Act
            JobPostingExtended actual 
                = new JobPostingExtendedManager(fakeGetRequestManagerFactory, new JobPostingExtendedDeserializer()).GetJobPostingExtended(jobPosting);

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
    Last Update: 07.08.2021
*/