using NUnit.Framework;
using System;

namespace NW.WIDJobs.UnitTests
{
    [TestFixture]
    public class RunIdManagerTests
    {

        // Fields
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
                                    ObjectMother.RunIdManager_StartDate,
                                    ObjectMother.RunIdManager_EndDate
                        )),
                    ObjectMother.RunIdManager_RunId_StartDateEndDate
                ).SetArgDisplayNames($"{nameof(createTestCases)}_02"),

            new TestCaseData(
                new Func<string>(
                    () => new RunIdManager()
                            .Create(
                                ObjectMother.RunIdManager_Now,
                                ObjectMother.RunIdManager_Until
                        )),
                    ObjectMother.RunIdManager_RunId_Until
                ).SetArgDisplayNames($"{nameof(createTestCases)}_03")

        };

        // SetUp
        // Tests
        [TestCaseSource(nameof(createTestCases))]
        public void Create_ShouldReturnExpectedRunId_WhenInvoked
            (Func<string> func, string expected)
        {

            // Arrange
            // Act
            string actual = func.Invoke();

            // Assert
            Assert.AreEqual(expected, actual);

        }

        // TearDown		

    }
}

/*
    Author: numbworks@gmail.com
    Last Update: 15.05.2021
*/
