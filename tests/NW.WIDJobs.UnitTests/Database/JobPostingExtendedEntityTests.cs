using NUnit.Framework;
using System;
using NW.WIDJobs.Database;
using NW.WIDJobs.JobPostingsExtended;

namespace NW.WIDJobs.UnitTests
{
    [TestFixture]
    public class JobPostingExtededEntityTests
    {

        #region Fields

        private static TestCaseData[] jobPostingExtendedEntityTestCases =
        {

            new TestCaseData(
                    ObjectMother.Shared_JobPage01_JobPostingExtended01,
                    true
                ).SetArgDisplayNames($"{nameof(jobPostingExtendedEntityTestCases)}_01")

        };
        private static TestCaseData[] jobPostingExtendedEntityExceptionTestCases =
        {

            new TestCaseData(
                new TestDelegate(
                    () => new JobPostingExtendedEntity(null)
                ),
                typeof(ArgumentNullException),
                new ArgumentNullException("jobPostingExtended").Message
            ).SetArgDisplayNames($"{nameof(jobPostingExtendedEntityExceptionTestCases)}_01")

        };

        #endregion

        #region SetUp
        #endregion

        #region Tests

        [TestCaseSource(nameof(jobPostingExtendedEntityTestCases))]
        public void JobPostingExtendedEntity_ShouldInstantiateANewObject_WhenProperArguments
            (JobPostingExtended jobPostingExtended, bool ignorePurposeResponse)
        {

            // Arrange
            // Act
            JobPostingExtendedEntity actual = new JobPostingExtendedEntity(jobPostingExtended);

            // Assert
            Assert.IsTrue(
                ObjectMother.AreEqual(jobPostingExtended, actual, ignorePurposeResponse)
                );


        }

        [TestCaseSource(nameof(jobPostingExtendedEntityExceptionTestCases))]
        public void JobPostingExtendedEntity_ShouldThrowACertainException_WhenUnproperArguments
            (TestDelegate del, Type expectedType, string expectedMessage)
                => ObjectMother.Method_ShouldThrowACertainException_WhenUnproperArguments(del, expectedType, expectedMessage);

        [Test]
        public void JobPostingExtendedEntity_ShouldCreateAnObjectOfTypeJobPostingExtendedEntity_WhenInvoked()
        {

            // Arrange
            // Act
            JobPostingExtendedEntity actual = new JobPostingExtendedEntity();

            // Assert
            Assert.IsInstanceOf<JobPostingExtendedEntity>(actual);

        }

        #endregion

        #region TearDown
        #endregion

    }
}

/*
    Author: numbworks@gmail.com
    Last Update: 08.10.2021
*/