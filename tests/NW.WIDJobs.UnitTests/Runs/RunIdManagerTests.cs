using NUnit.Framework;
using System;
using NW.WIDJobs.Runs;

namespace NW.WIDJobs.UnitTests
{
    [TestFixture]
    public class RunIdManagerTests
    {

        #region Fields

        private static TestCaseData[] createTestCases =
        {

            new TestCaseData(
                new Func<string>(
                    () => new RunIdManager()
                                .Create(ObjectMother.RunIdManager_Now
                        )),
                    ObjectMother.RunIdManager_RunId_Now
                ).SetArgDisplayNames($"{nameof(createTestCases)}_01"),

            new TestCaseData(
                new Func<string>(
                    () => new RunIdManager()
                            .Create(
                                ObjectMother.RunIdManager_Now,
                                ObjectMother.RunIdManager_Threshold
                        )),
                    ObjectMother.RunIdManager_RunId_Threshold
                ).SetArgDisplayNames($"{nameof(createTestCases)}_02"),

            new TestCaseData(
                new Func<string>(
                    () => new RunIdManager()
                            .Create(
                                ObjectMother.RunIdManager_Now,
                                ObjectMother.RunIdManager_InitialPageNumber,
                                ObjectMother.RunIdManager_FinalPageNumber
                        )),
                    ObjectMother.RunIdManager_RunId_FromTo
                ).SetArgDisplayNames($"{nameof(createTestCases)}_03"),

            new TestCaseData(
                new Func<string>(
                    () => new RunIdManager()
                            .Create(
                                ObjectMother.RunIdManager_Now,
                                ObjectMother.Shared_JobPage01_JobPosting01.JobPostingId
                        )),
                    ObjectMother.RunIdManager_RunId_JobPostingId
                ).SetArgDisplayNames($"{nameof(createTestCases)}_04")

        };

        #endregion

        #region SetUp
        #endregion

        #region Tests

        [TestCaseSource(nameof(createTestCases))]
        public void Create_ShouldReturnExpectedRunId_WhenInvoked(Func<string> func, string expected)
        {

            // Arrange
            // Act
            string actual = func.Invoke();

            // Assert
            Assert.AreEqual(expected, actual);

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
