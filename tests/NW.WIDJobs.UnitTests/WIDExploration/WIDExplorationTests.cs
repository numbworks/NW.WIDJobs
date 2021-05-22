using NUnit.Framework;
using System;
using System.Collections.Generic;

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
                                ObjectMother.WIDExploration_Exploration1_TotalResults,
                                ObjectMother.WIDExploration_Exploration1_TotalEstimatedPages,
                                ObjectMother.WIDExploration_Exploration1_Category,
                                ObjectMother.WIDExploration_Exploration1_Stage,
                                ObjectMother.WIDExploration_Exploration1_IsCompleted,
                                ObjectMother.WIDExploration_Exploration1_Pages,
                                ObjectMother.WIDExploration_Exploration1_PageItems,
                                ObjectMother.WIDExploration_Exploration1_PageItemsExtended
                            )
                ),
                typeof(ArgumentNullException),
                new ArgumentNullException("runId").Message
            ).SetArgDisplayNames($"{nameof(widExplorationExceptionTestCases)}_01")

        };
        private static TestCaseData[] toStringTestCases =
        {

            new TestCaseData(
                    ObjectMother.WIDExploration_Exploration1,
                    ObjectMother.WIDExploration_Exploration1_ToString
                ).SetArgDisplayNames($"{nameof(toStringTestCases)}_01")

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

        // TearDown		

    }
}

/*
    Author: numbworks@gmail.com
    Last Update: 22.05.2021
*/
