﻿using NUnit.Framework;
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

        [Test]
        public void Explore_ShouldReturnExpectedWIDExploration_WhenFinalPageNumberAndStage1()
        {

            // Arrange
            FakeLogger fakeLogger = new FakeLogger();
            Action<string> fakeLoggingAction = (message) => fakeLogger.Log(message);
            WIDExplorerComponents components = new WIDExplorerComponents(
                    fakeLoggingAction,
                    new XPathManager(),
                    ObjectMother.WIDExplorer_FakeGetRequestManagerAlternate(),
                    new PageManager(
                            ObjectMother.WIDExplorer_FakeGetRequestManagerAlternate(),
                            new PageScraper(),
                            new WIDCategoryManager()
                            ),
                    new PageScraper(),
                    new PageItemScraper(),
                    new PageItemExtendedManager(
                            ObjectMother.WIDExplorer_FakeGetRequestManagerAlternate(),
                            new PageItemExtendedScraper()
                            ),
                    new PageItemExtendedScraper(),
                    new RunIdManager(),
                    new BulletPointManager()
                  );
            WIDExplorerSettings settings = new WIDExplorerSettings(3, 0);
            WIDExplorer explorer
                = new WIDExplorer(components, settings, ObjectMother.WIDExplorer_FakeNow);

            string runIdFakeNow = new RunIdManager().Create(ObjectMother.WIDExplorer_FakeNow, 1, 2);
            List<Page> pages = new List<Page>()
            {

                new Page(
                    runIdFakeNow,
                    ObjectMother.Shared_Page01Alternate.PageNumber,
                    ObjectMother.Shared_Page01Alternate.Content
                    )
            
            };
            WIDExploration expected
                = new WIDExploration(
                        runIdFakeNow,
                        ObjectMother.Shared_Page01_TotalResults,
                        ObjectMother.Shared_Page01_TotalEstimatedPages,
                        WIDCategories.AllCategories,
                        WIDStages.Stage1_OnlyMetrics,
                        true,
                        pages                          
                        );                          

            // Act
            WIDExploration actual = explorer.Explore(2, WIDCategories.AllCategories, WIDStages.Stage1_OnlyMetrics);

            // Assert
            Assert.IsTrue(
                    ObjectMother.AreEqual(expected, actual)
                );

        }

    }
}

/*
    Author: numbworks@gmail.com
    Last Update: 23.05.2021
*/
