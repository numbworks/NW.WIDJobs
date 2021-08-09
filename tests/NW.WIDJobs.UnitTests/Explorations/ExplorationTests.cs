using System;
using NUnit.Framework;

namespace NW.WIDJobs.UnitTests
{
    [TestFixture]
    public class ExplorationTests
    {

        // Fields
        private static TestCaseData[] explorationExceptionTestCases =
        {

            new TestCaseData(
                new TestDelegate(
                    () => new Exploration(
                                null,
                                ObjectMother.Exploration01_TotalResultCount,
                                ObjectMother.Exploration01_TotalJobPages,
                                ObjectMother.Exploration01_Stage,
                                ObjectMother.Exploration01_IsCompleted,
                                ObjectMother.Exploration01_JobPages,
                                ObjectMother.Exploration01_JobPostings,
                                ObjectMother.Exploration01_JobPostingsExtended
                            )
                ),
                typeof(ArgumentNullException),
                new ArgumentNullException("runId").Message
            ).SetArgDisplayNames($"{nameof(explorationExceptionTestCases)}_01")

        };
        private static TestCaseData[] toStringTestCases =
        {

            new TestCaseData(
                    ObjectMother.Exploration01,
                    ObjectMother.Exploration01_AsString
                ).SetArgDisplayNames($"{nameof(toStringTestCases)}_01"),

            new TestCaseData(
                    ObjectMother.Exploration02,
                    ObjectMother.Exploration02_AsString
                ).SetArgDisplayNames($"{nameof(toStringTestCases)}_02")

        };

        // SetUp
        // Tests
        [TestCaseSource(nameof(explorationExceptionTestCases))]
        public void Exploration_ShouldThrowACertainException_WhenUnproperArguments
            (TestDelegate del, Type expectedType, string expectedMessage)
                => ObjectMother.Method_ShouldThrowACertainException_WhenUnproperArguments(del, expectedType, expectedMessage);

        [TestCaseSource(nameof(toStringTestCases))]
        public void ToString_ShouldReturnExpectedString_WhenInvoked
            (Exploration exploration, string expected)
        {

            // Arrange
            // Act
            string actual = exploration.ToString();

            // Assert
            Assert.AreEqual(expected, actual);

        }

        [Test]
        public void Exploration_ShouldInitializeANewExplorationObject_WhenDefaultConstructor()
        {

            // Arrange
            // Act
            Exploration actual =
                new Exploration(
                    ObjectMother.Exploration01_RunId,
                    ObjectMother.Exploration01_TotalResultCount,
                    ObjectMother.Exploration01_TotalJobPages,
                    ObjectMother.Exploration01_Stage,
                    ObjectMother.Exploration01_IsCompleted,
                    ObjectMother.Exploration01_JobPages,
                    ObjectMother.Exploration01_JobPostings,
                    ObjectMother.Exploration01_JobPostingsExtended
                    );

            // Assert
            Assert.IsInstanceOf<Exploration>(actual);

        }

        // TearDown		

    }
}

/*
    Author: numbworks@gmail.com
    Last Update: 08.08.2021
*/
