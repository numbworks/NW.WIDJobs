using NUnit.Framework;
using System;
using NW.WIDJobs.JobPostingsExtended;

namespace NW.WIDJobs.UnitTests
{
    [TestFixture]
    public class JobPostingExtendedTests
    {

        #region Fields

        private static TestCaseData[] jobPostingExtendedExceptionTestCases =
        {

            new TestCaseData(
                new TestDelegate(
                    () => new JobPostingExtended(
                                null, 
                                ObjectMother.Shared_FakeResponse,
                                ObjectMother.Shared_JobPage01_JobPostingExtended01.HiringOrgDescription,
                                ObjectMother.Shared_JobPage01_JobPostingExtended01.PublicationStartDate,
                                ObjectMother.Shared_JobPage01_JobPostingExtended01.PublicationEndDate,
                                ObjectMother.Shared_FakePurpose,
                                ObjectMother.Shared_JobPage01_JobPostingExtended01.NumberToFill,
                                ObjectMother.Shared_JobPage01_JobPostingExtended01.ContactEmail,
                                ObjectMother.Shared_JobPage01_JobPostingExtended01.ContactPersonName,
                                ObjectMother.Shared_JobPage01_JobPostingExtended01.EmploymentDate,
                                ObjectMother.Shared_JobPage01_JobPostingExtended01.ApplicationDeadlineDate,
                                ObjectMother.Shared_JobPage01_JobPostingExtended01.BulletPoints,
                                ObjectMother.Shared_JobPage01_JobPostingExtended01.BulletPointScenario
                                )
                ),
                typeof(ArgumentNullException),
                new ArgumentNullException("jobPosting").Message
            ).SetArgDisplayNames($"{nameof(jobPostingExtendedExceptionTestCases)}_01"),

            new TestCaseData(
                new TestDelegate(
                    () => new JobPostingExtended(
                                ObjectMother.Shared_JobPage01_JobPosting01,
                                null,
                                ObjectMother.Shared_JobPage01_JobPostingExtended01.HiringOrgDescription,
                                ObjectMother.Shared_JobPage01_JobPostingExtended01.PublicationStartDate,
                                ObjectMother.Shared_JobPage01_JobPostingExtended01.PublicationEndDate,
                                ObjectMother.Shared_FakePurpose,
                                ObjectMother.Shared_JobPage01_JobPostingExtended01.NumberToFill,
                                ObjectMother.Shared_JobPage01_JobPostingExtended01.ContactEmail,
                                ObjectMother.Shared_JobPage01_JobPostingExtended01.ContactPersonName,
                                ObjectMother.Shared_JobPage01_JobPostingExtended01.EmploymentDate,
                                ObjectMother.Shared_JobPage01_JobPostingExtended01.ApplicationDeadlineDate,
                                ObjectMother.Shared_JobPage01_JobPostingExtended01.BulletPoints,
                                ObjectMother.Shared_JobPage01_JobPostingExtended01.BulletPointScenario
                                )
                ),
                typeof(ArgumentNullException),
                new ArgumentNullException("response").Message
            ).SetArgDisplayNames($"{nameof(jobPostingExtendedExceptionTestCases)}_02")

        };

        #endregion

        #region SetUp

        #endregion

        #region Tests

        [TestCaseSource(nameof(jobPostingExtendedExceptionTestCases))]
        public void JobPostingExtended_ShouldThrowACertainException_WhenUnproperArguments
            (TestDelegate del, Type expectedType, string expectedMessage)
                => ObjectMother.Method_ShouldThrowACertainException_WhenUnproperArguments(del, expectedType, expectedMessage);

        [Test]
        public void JobPostingExtended_ShouldInitializeSuccessfully_WhenProperParameters()
        {

            // Arrange
            bool compareJobPostingLanguage = true;
            bool ignorePurposeResponse = true;
            bool compareBulletPointType = false;

            // Act
            JobPostingExtended actual 
                = new JobPostingExtended(
                    ObjectMother.Shared_JobPage01_JobPosting01,
                    ObjectMother.Shared_FakeResponse,
                    ObjectMother.Shared_JobPage01_JobPostingExtended01.HiringOrgDescription,
                    ObjectMother.Shared_JobPage01_JobPostingExtended01.PublicationStartDate,
                    ObjectMother.Shared_JobPage01_JobPostingExtended01.PublicationEndDate,
                    ObjectMother.Shared_FakePurpose,
                    ObjectMother.Shared_JobPage01_JobPostingExtended01.NumberToFill,
                    ObjectMother.Shared_JobPage01_JobPostingExtended01.ContactEmail,
                    ObjectMother.Shared_JobPage01_JobPostingExtended01.ContactPersonName,
                    ObjectMother.Shared_JobPage01_JobPostingExtended01.EmploymentDate,
                    ObjectMother.Shared_JobPage01_JobPostingExtended01.ApplicationDeadlineDate,
                    ObjectMother.Shared_JobPage01_JobPostingExtended01.BulletPoints,
                    ObjectMother.Shared_JobPage01_JobPostingExtended01.BulletPointScenario
                    );

            // Assert
            Assert.IsTrue(
                    ObjectMother.AreEqual(ObjectMother.Shared_JobPage01_JobPostingExtended01, actual, compareJobPostingLanguage, ignorePurposeResponse, compareBulletPointType)
                );

        }

        #endregion

        #region TearDown

        #endregion

    }
}

/*
    Author: numbworks@gmail.com
    Last Update: 27.09.2021
*/