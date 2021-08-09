using System;
using NUnit.Framework;

namespace NW.WIDJobs.UnitTests
{
    [TestFixture]
    public class WIDExplorationTests
    {

        // Fields
        private static TestCaseData[] widExplorationExceptionTestCases =
        {

            new TestCaseData(
                new TestDelegate(
                    () => new WIDExploration(
                                null,
                                ObjectMother.WIDExploration_Exploration01_TotalResultCount,
                                ObjectMother.WIDExploration_Exploration01_TotalJobPages,
                                ObjectMother.WIDExploration_Exploration01_IsCompleted,
                                ObjectMother.WIDExploration_Exploration01_JobPages,
                                ObjectMother.WIDExploration_Exploration01_JobPostings,
                                ObjectMother.WIDExploration_Exploration01_JobPostingsExtended
                            )
                ),
                typeof(ArgumentNullException),
                new ArgumentNullException("runId").Message
            ).SetArgDisplayNames($"{nameof(widExplorationExceptionTestCases)}_01")

        };
        private static TestCaseData[] toStringTestCases =
        {

            new TestCaseData(
                    ObjectMother.WIDExploration_Exploration01,
                    ObjectMother.WIDExploration_Exploration01_ToString
                ).SetArgDisplayNames($"{nameof(toStringTestCases)}_01"),

            new TestCaseData(
                    ObjectMother.WIDExploration_Exploration02,
                    ObjectMother.WIDExploration_Exploration02_ToString
                ).SetArgDisplayNames($"{nameof(toStringTestCases)}_02")

        };

        // SetUp
        // Tests
        [TestCaseSource(nameof(widExplorationExceptionTestCases))]
        public void WIDExploration_ShouldThrowACertainException_WhenUnproperArguments
            (TestDelegate del, Type expectedType, string expectedMessage)
                => ObjectMother.Method_ShouldThrowACertainException_WhenUnproperArguments(del, expectedType, expectedMessage);

        [TestCaseSource(nameof(toStringTestCases))]
        public void ToString_ShouldReturnExpectedString_WhenInvoked
            (WIDExploration exploration, string expected)
        {

            // Arrange
            // Act
            string actual = exploration.ToString();

            // Assert
            Assert.AreEqual(expected, actual);

        }

        [Test]
        public void WIDExploration_ShouldInitializeANewWIDExplorationObject_WhenDefaultConstructor()
        {

            // Arrange
            // Act
            WIDExploration actual =
                new WIDExploration(
                    ObjectMother.WIDExploration_Exploration01_RunId,
                    ObjectMother.WIDExploration_Exploration01_TotalResultCount,
                    ObjectMother.WIDExploration_Exploration01_TotalJobPages,
                    ObjectMother.WIDExploration_Exploration01_IsCompleted,
                    ObjectMother.Shared_Pages_Page01,
                    ObjectMother.Shared_Page01_PageItems,
                    ObjectMother.Shared_Page01_PageItemsExtended
                    );

            // Assert
            Assert.IsInstanceOf<WIDExploration>(actual);

        }

        // TearDown		

    }
}

/*
    Author: numbworks@gmail.com
    Last Update: 22.05.2021
*/
