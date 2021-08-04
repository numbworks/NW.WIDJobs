using NUnit.Framework;
using System;
using System.Collections;
using System.Collections.Generic;

namespace NW.WIDJobs.UnitTests
{
    [TestFixture]
    public class JobPostingDeserializerTests
    {

        #region Fields

        private static TestCaseData[] jobPostingDeserializerExceptionTestCases =
        {

            new TestCaseData(
                new TestDelegate(
                    () => new JobPostingDeserializer(null)
                ),
                typeof(ArgumentNullException),
                new ArgumentNullException("jobPostingHelper").Message
            ).SetArgDisplayNames($"{nameof(jobPostingDeserializerExceptionTestCases)}_01")

        };
        private static TestCaseData[] doExceptionTestCases =
        {

            new TestCaseData(
                new TestDelegate(
                    () => new JobPostingDeserializer().Do(null)
                ),
                typeof(ArgumentNullException),
                new ArgumentNullException("jobPage").Message
            ).SetArgDisplayNames($"{nameof(doExceptionTestCases)}_01")

        };
        private static TestCaseData[] doTestCases =
        {

            new TestCaseData(
                    ObjectMother.Shared_JobPage01_Object,
                    ObjectMother.Shared_JobPage01_JobPostings
                ).SetArgDisplayNames($"{nameof(doTestCases)}_01")

        };

        #endregion

        #region SetUp

        #endregion

        #region Tests

        [TestCaseSource(nameof(jobPostingDeserializerExceptionTestCases))]
        public void JobPostingDeserializer_ShouldThrowACertainException_WhenUnproperArguments
            (TestDelegate del, Type expectedType, string expectedMessage)
                => ObjectMother.Method_ShouldThrowACertainException_WhenUnproperArguments(del, expectedType, expectedMessage);

        [TestCaseSource(nameof(doExceptionTestCases))]
        public void Do_ShouldThrowACertainException_WhenUnproperArguments
            (TestDelegate del, Type expectedType, string expectedMessage)
                => ObjectMother.Method_ShouldThrowACertainException_WhenUnproperArguments(del, expectedType, expectedMessage);

        [TestCaseSource(nameof(doTestCases))]
        public void Do_ShouldReturnAListofJobPostingObjects_WhenProperArguments
            (JobPage jobPage, List<JobPosting> expected)
        {

            // Arrange
            // Act
            List<JobPosting> actual = new JobPostingDeserializer().Do(jobPage);

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
    Last Update: 04.08.2021
*/
