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
                                ObjectMother.Shared_ExplorationStage1_TotalResultCount,
                                ObjectMother.Shared_ExplorationStage1_TotalJobPages,
                                ObjectMother.Shared_ExplorationStage1_Stage,
                                ObjectMother.Shared_ExplorationStage1_IsCompleted,
                                ObjectMother.Shared_ExplorationStage1_JobPages,
                                ObjectMother.Shared_ExplorationStage1_JobPostings,
                                ObjectMother.Shared_ExplorationStage1_JobPostingsExtended
                            )
                ),
                typeof(ArgumentNullException),
                new ArgumentNullException("runId").Message
            ).SetArgDisplayNames($"{nameof(explorationExceptionTestCases)}_01")

        };
        private static TestCaseData[] toStringTestCases =
        {

            new TestCaseData(
                    ObjectMother.Shared_ExplorationStage1,
                    ObjectMother.Shared_ExplorationStage1_AsString
                ).SetArgDisplayNames($"{nameof(toStringTestCases)}_01"),

            new TestCaseData(
                    ObjectMother.Shared_ExplorationStage3,
                    ObjectMother.Shared_ExplorationStage3_AsString
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
                    ObjectMother.Shared_ExplorationStage1_RunId,
                    ObjectMother.Shared_ExplorationStage1_TotalResultCount,
                    ObjectMother.Shared_ExplorationStage1_TotalJobPages,
                    ObjectMother.Shared_ExplorationStage1_Stage,
                    ObjectMother.Shared_ExplorationStage1_IsCompleted,
                    ObjectMother.Shared_ExplorationStage1_JobPages,
                    ObjectMother.Shared_ExplorationStage1_JobPostings,
                    ObjectMother.Shared_ExplorationStage1_JobPostingsExtended
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
