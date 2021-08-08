﻿using NUnit.Framework;
using System;

namespace NW.WIDJobs.UnitTests
{
    [TestFixture]
    public class JobPostingEntityTests
    {

        // Fields
        private static TestCaseData[] jobPostingEntityTestCases =
        {

            new TestCaseData(
                    ObjectMother.Shared_JobPage01_JobPosting01
                ).SetArgDisplayNames($"{nameof(jobPostingEntityTestCases)}_01")

        };
        private static TestCaseData[] jobPostingEntityExceptionTestCases =
        {

            new TestCaseData(
                new TestDelegate(
                    () => new JobPostingEntity(null)
				),
                typeof(ArgumentNullException),
                new ArgumentNullException("jobPosting").Message
            ).SetArgDisplayNames($"{nameof(jobPostingEntityExceptionTestCases)}_01")

        };

        // SetUp
        // Tests
        [TestCaseSource(nameof(jobPostingEntityTestCases))]
        public void JobPostingEntity_ShouldInstantiateANewObject_WhenProperArguments(JobPosting jobPosting)
        {

            // Arrange
            // Act
            JobPostingEntity actual = new JobPostingEntity(jobPosting);

            // Assert
            Assert.IsTrue(
                ObjectMother.AreEqual(jobPosting, actual)
                );


        }

        [TestCaseSource(nameof(jobPostingEntityExceptionTestCases))]
        public void JobPostingEntity_ShouldThrowACertainException_WhenUnproperArguments
            (TestDelegate del, Type expectedType, string expectedMessage)
                => ObjectMother.Method_ShouldThrowACertainException_WhenUnproperArguments(del, expectedType, expectedMessage);

        [Test]
        public void JobPostingEntity_ShouldCreateAnObjectOfTypeJobPostingEntity_WhenInvoked()
        {

            // Arrange
            // Act
            JobPostingEntity actual = new JobPostingEntity();

            // Assert
            Assert.IsInstanceOf<JobPostingEntity>(actual);

        }

        // TearDown		

    }
}

/*
    Author: numbworks@gmail.com
    Last Update: 08.08.2021
*/
