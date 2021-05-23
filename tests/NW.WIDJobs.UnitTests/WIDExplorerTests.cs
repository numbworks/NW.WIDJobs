using NUnit.Framework;
using System;
using System.Collections;
using System.Collections.Generic;

namespace NW.WIDJobs.UnitTests
{
    [TestFixture]
    public class WIDExplorerTests
    {

        // Fields
        private static TestCaseData[] widExplorerExceptionTestCases =
        {

            new TestCaseData(
                new TestDelegate(
                    () => new WIDExplorer(null, new WIDExplorerSettings(), ObjectMother.WIDExplorer_FakeNow)
				),
                typeof(ArgumentNullException),
                new ArgumentNullException("components").Message
            ).SetArgDisplayNames($"{nameof(widExplorerExceptionTestCases)}_01"),

            new TestCaseData(
                new TestDelegate(
                    () => new WIDExplorer(new WIDExplorerComponents(), null, ObjectMother.WIDExplorer_FakeNow)
                ),
                typeof(ArgumentNullException),
                new ArgumentNullException("settings").Message
            ).SetArgDisplayNames($"{nameof(widExplorerExceptionTestCases)}_01"),

        };
        private static TestCaseData[] exploreExceptionTestCases =
        {

            new TestCaseData(
                new TestDelegate(
                    () => new WIDExplorer()
                            .Explore(
                                null, 
                                2, 
                                WIDCategories.AllCategories, 
                                WIDStages.Stage1_OnlyMetrics
                        )),
                typeof(ArgumentNullException),
                new ArgumentNullException("runId").Message
            ).SetArgDisplayNames($"{nameof(widExplorerExceptionTestCases)}_01"),

            new TestCaseData(
                new TestDelegate(
                    () => new WIDExplorer()
                            .Explore(
                                ObjectMother.Shared_FakeRunId, 
                                0, 
                                WIDCategories.AllCategories, 
                                WIDStages.Stage1_OnlyMetrics
                        )),
                typeof(ArgumentException),
                MessageCollection.Validator_VariableCantBeLessThanOne.Invoke("finalPageNumber")
            ).SetArgDisplayNames($"{nameof(widExplorerExceptionTestCases)}_02"),

            new TestCaseData(
                new TestDelegate(
                    () => new WIDExplorer()
                            .Explore(
                                null, 
                                ObjectMother.WIDExplorer_FakeNow,
                                WIDCategories.AllCategories, 
                                WIDStages.Stage1_OnlyMetrics
                        )),
                typeof(ArgumentNullException),
                new ArgumentNullException("runId").Message
            ).SetArgDisplayNames($"{nameof(widExplorerExceptionTestCases)}_03")

        };

        private static TestCaseData[] exploreTestCases =
        {

            new TestCaseData(
                    "Some message",
                    false
                ).SetArgDisplayNames($"{nameof(exploreTestCases)}_01")

        };


        // SetUp
        // Tests
        [TestCaseSource(nameof(widExplorerExceptionTestCases))]
        public void WIDExplorer_ShouldThrowACertainException_WhenUnproperArguments
            (TestDelegate del, Type expectedType, string expectedMessage)
                => ObjectMother.Method_ShouldThrowACertainException_WhenUnproperArguments(del, expectedType, expectedMessage);

        [TestCaseSource(nameof(exploreExceptionTestCases))]
        public void Explore_ShouldThrowACertainException_WhenUnproperArguments
            (TestDelegate del, Type expectedType, string expectedMessage)
                => ObjectMother.Method_ShouldThrowACertainException_WhenUnproperArguments(del, expectedType, expectedMessage);



        [TestCaseSource(nameof(exploreTestCases))]
        public void SomeMethod_Should_When
            (string message, bool expected)
        {

            // Arrange
            // Act
            // Assert

        }

        [Test]
        public void SomeMethod_Should_When()
        {

            // Arrange
            // Act
            // Assert

        }

    }
}

/*
    Author: numbworks@gmail.com
    Last Update: 23.05.2021
*/
