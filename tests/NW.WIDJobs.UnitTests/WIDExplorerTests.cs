﻿using System;
using System.Collections.Generic;
using NUnit.Framework;

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
                    () => new WIDExplorer(null, new WIDExplorerSettings(), ObjectMother.WIDExplorer_FakeNowFunction)
				),
                typeof(ArgumentNullException),
                new ArgumentNullException("components").Message
            ).SetArgDisplayNames($"{nameof(widExplorerExceptionTestCases)}_01"),

            new TestCaseData(
                new TestDelegate(
                    () => new WIDExplorer(new WIDExplorerComponents(), null, ObjectMother.WIDExplorer_FakeNowFunction)
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
        private static TestCaseData[] exploreThresholdDateAndStage2TestCases =
        {

            new TestCaseData(
                    ObjectMother.Shared_Page02Alternate_ThresholdDate01,
                    ObjectMother.Shared_Page02Alternate_PageItemsIndex01
            ).SetArgDisplayNames($"{nameof(exploreThresholdDateAndStage2TestCases)}_01"),

            new TestCaseData(
                    ObjectMother.Shared_Page02Alternate_ThresholdDate02,
                    ObjectMother.Shared_Page02Alternate_PageItemsIndex02
            ).SetArgDisplayNames($"{nameof(exploreThresholdDateAndStage2TestCases)}_02"),

            new TestCaseData(
                    ObjectMother.Shared_Page02Alternate_ThresholdDate03,
                    ObjectMother.Shared_Page02Alternate_PageItemsIndex03
            ).SetArgDisplayNames($"{nameof(exploreThresholdDateAndStage2TestCases)}_03")

        };
        private static TestCaseData[] exploreThresholdDateAndStage3TestCases =
        {

            new TestCaseData(
                    ObjectMother.Shared_Page02Alternate_ThresholdDate01,
                    ObjectMother.Shared_Page02Alternate_PageItemsIndex01,
                    ObjectMother.Shared_Page02Alternate_PageItemsExtendedIndex01
            ).SetArgDisplayNames($"{nameof(exploreThresholdDateAndStage3TestCases)}_01"),

            new TestCaseData(
                    ObjectMother.Shared_Page02Alternate_ThresholdDate02,
                    ObjectMother.Shared_Page02Alternate_PageItemsIndex02,
                    ObjectMother.Shared_Page02Alternate_PageItemsExtendedIndex02
            ).SetArgDisplayNames($"{nameof(exploreThresholdDateAndStage3TestCases)}_02"),

            new TestCaseData(
                    ObjectMother.Shared_Page02Alternate_ThresholdDate03,
                    ObjectMother.Shared_Page02Alternate_PageItemsIndex03,
                    ObjectMother.Shared_Page02Alternate_PageItemsExtendedIndex03
            ).SetArgDisplayNames($"{nameof(exploreThresholdDateAndStage3TestCases)}_03")

        };
        private static TestCaseData[] exploreAllExceptionTestCases =
        {

            new TestCaseData(
                new TestDelegate(
                    () => new WIDExplorer()
                            .ExploreAll(
                                null,
                                WIDCategories.AllCategories,
                                WIDStages.Stage1_OnlyMetrics
                        )),
                typeof(ArgumentNullException),
                new ArgumentNullException("runId").Message
            ).SetArgDisplayNames($"{nameof(exploreAllExceptionTestCases)}_01")

        };        
        private static TestCaseData[] extractFromHtmlExceptionTestCases =
        {

            new TestCaseData(
                new TestDelegate(
                        () => new WIDExplorer().ExtractFromHtml((IFileInfoAdapter)null)
                    ),
                typeof(ArgumentNullException),
                new ArgumentNullException("htmlFile").Message
            ).SetArgDisplayNames($"{nameof(extractFromHtmlExceptionTestCases)}_01"),

            new TestCaseData(
                new TestDelegate(
                        () => new WIDExplorer().ExtractFromHtml(ObjectMother.FileManager_FileInfoAdapterDoesntExist)
                    ),
                typeof(ArgumentException),
                MessageCollection.Validator_ProvidedPathDoesntExist.Invoke(ObjectMother.FileManager_FileInfoAdapterDoesntExist)
            ).SetArgDisplayNames($"{nameof(extractFromHtmlExceptionTestCases)}_02"),           

            new TestCaseData(
                new TestDelegate(
                        () => new WIDExplorer().ExtractFromHtml((string)null)
                    ),
                typeof(ArgumentNullException),
                new ArgumentNullException("filePath").Message
            ).SetArgDisplayNames($"{nameof(extractFromHtmlExceptionTestCases)}_03")

        };
        private static TestCaseData[] tryExtractFromHtmlExceptionTestCases =
        {

            new TestCaseData(
                new TestDelegate(
                        () => new WIDExplorer().TryExtractFromHtml((IFileInfoAdapter)null)
                    ),
                typeof(ArgumentNullException),
                new ArgumentNullException("htmlFile").Message
            ).SetArgDisplayNames($"{nameof(tryExtractFromHtmlExceptionTestCases)}_01"),

            new TestCaseData(
                new TestDelegate(
                        () => new WIDExplorer().TryExtractFromHtml(ObjectMother.FileManager_FileInfoAdapterDoesntExist)
                    ),
                typeof(ArgumentException),
                MessageCollection.Validator_ProvidedPathDoesntExist.Invoke(ObjectMother.FileManager_FileInfoAdapterDoesntExist)
            ).SetArgDisplayNames($"{nameof(tryExtractFromHtmlExceptionTestCases)}_02"),

            new TestCaseData(
                new TestDelegate(
                        () => new WIDExplorer().TryExtractFromHtml((string)null)
                    ),
                typeof(ArgumentNullException),
                new ArgumentNullException("filePath").Message
            ).SetArgDisplayNames($"{nameof(tryExtractFromHtmlExceptionTestCases)}_03")

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
        [TestCaseSource(nameof(exploreThresholdDateAndStage2TestCases))]
        public void Explore_ShouldReturnExpectedWIDExploration_WhenThresholdDateAndStage2
            (DateTime thresholdDate, ushort expectedPageItemsIndex)
        {

            // Arrange
            FakeLogger fakeLogger = new FakeLogger();
            Action<string> fakeLoggingAction = (message) => fakeLogger.Log(message);
            FakeLogger fakeLoggerAsciiBanner = new FakeLogger();
            Action<string> fakeLoggingActionAsciiBanner = (message) => fakeLoggerAsciiBanner.Log(message);
            WIDExplorerComponents components = new WIDExplorerComponents(
                    fakeLoggingAction,
                    fakeLoggingActionAsciiBanner,
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
                    new WIDMetricsManager(),
                    new FileManager(),
                    new RepositoryFactory(),
                    new AsciiBannerManager(),
                    new WIDFileNameFactory(),
                    new BulletPointManager()
                  );
            WIDExplorerSettings settings
                = new WIDExplorerSettings(
                        3,
                        0,
                        WIDExplorerSettings.DefaultFolderPath,
                        WIDExplorerSettings.DefaultDeleteAndRecreateDatabase
                    );
            WIDExplorer explorer
                = new WIDExplorer(components, settings, ObjectMother.WIDExplorer_FakeNowFunction);

            List<Page> pages = new List<Page>()
            {

                ObjectMother.Shared_Page01Alternate,
                ObjectMother.Shared_Page02Alternate

            };

            WIDExploration expected
                = new WIDExploration(
                        ObjectMother.Shared_FakeRunId,
                        ObjectMother.Shared_Page01_TotalResults,
                        ObjectMother.Shared_Page01_TotalEstimatedPages,
                        WIDCategories.AllCategories,
                        WIDStages.Stage2_UpToAllPageItems,
                        true,
                        pages,
                        ObjectMother.Shared_Page02Alternate_GetPageItemsSubset.Invoke(expectedPageItemsIndex)
                        );

            // Act
            WIDExploration actual
                = explorer.Explore(
                            ObjectMother.Shared_FakeRunId,
                            thresholdDate,
                            WIDCategories.AllCategories,
                            WIDStages.Stage2_UpToAllPageItems);

            // Assert
            Assert.IsTrue(
                    ObjectMother.AreEqual(expected, actual)
                );

        }
        [TestCaseSource(nameof(exploreThresholdDateAndStage3TestCases))]
        public void Explore_ShouldReturnExpectedWIDExploration_WhenThresholdDateAndStage3
            (DateTime thresholdDate, ushort expectedPageItemsIndex, ushort expectedPageItemsExtendedIndex)
        {

            // Arrange
            FakeLogger fakeLogger = new FakeLogger();
            Action<string> fakeLoggingAction = (message) => fakeLogger.Log(message);
            FakeLogger fakeLoggerAsciiBanner = new FakeLogger();
            Action<string> fakeLoggingActionAsciiBanner = (message) => fakeLoggerAsciiBanner.Log(message);
            WIDExplorerComponents components = new WIDExplorerComponents(
                    fakeLoggingAction,
                    fakeLoggingActionAsciiBanner,
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
                    new WIDMetricsManager(),
                    new FileManager(),
                    new RepositoryFactory(),
                    new AsciiBannerManager(),
                    new WIDFileNameFactory(),
                    new BulletPointManager()
                  );
            WIDExplorerSettings settings
                = new WIDExplorerSettings(
                        3,
                        0,
                        WIDExplorerSettings.DefaultFolderPath,
                        WIDExplorerSettings.DefaultDeleteAndRecreateDatabase
                    );
            WIDExplorer explorer
                = new WIDExplorer(components, settings, ObjectMother.WIDExplorer_FakeNowFunction);

            List<Page> pages = new List<Page>()
            {

                ObjectMother.Shared_Page01Alternate,
                ObjectMother.Shared_Page02Alternate

            };

            WIDExploration expected
                = new WIDExploration(
                        ObjectMother.Shared_FakeRunId,
                        ObjectMother.Shared_Page01_TotalResults,
                        ObjectMother.Shared_Page01_TotalEstimatedPages,
                        WIDCategories.AllCategories,
                        WIDStages.Stage3_UpToAllPageItemsExtended,
                        true,
                        pages,
                        ObjectMother.Shared_Page02Alternate_GetPageItemsSubset.Invoke(expectedPageItemsIndex),
                        ObjectMother.Shared_Page02Alternate_GetPageItemsExtendedSubset.Invoke(expectedPageItemsExtendedIndex)
                        );

            // Act
            WIDExploration actual
                = explorer.Explore(
                            ObjectMother.Shared_FakeRunId,
                            thresholdDate,
                            WIDCategories.AllCategories,
                            WIDStages.Stage3_UpToAllPageItemsExtended);

            // Assert
            Assert.IsTrue(
                    ObjectMother.AreEqual(expected, actual)
                );

        }
        [Test]
        public void Explore_ShouldReturnExpectedWIDExploration_WhenFinalPageNumberAndStage1()
        {

            // Arrange
            FakeLogger fakeLogger = new FakeLogger();
            Action<string> fakeLoggingAction = (message) => fakeLogger.Log(message);
            FakeLogger fakeLoggerAsciiBanner = new FakeLogger();
            Action<string> fakeLoggingActionAsciiBanner = (message) => fakeLoggerAsciiBanner.Log(message);
            WIDExplorerComponents components = new WIDExplorerComponents(
                    fakeLoggingAction,
                    fakeLoggingActionAsciiBanner,
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
                    new WIDMetricsManager(),
                    new FileManager(),
                    new RepositoryFactory(),
                    new AsciiBannerManager(),
                    new WIDFileNameFactory(),
                    new BulletPointManager()
                  );
            WIDExplorerSettings settings
                = new WIDExplorerSettings(
                        3,
                        0,
                        WIDExplorerSettings.DefaultFolderPath,
                        WIDExplorerSettings.DefaultDeleteAndRecreateDatabase
                    );
            WIDExplorer explorer
                = new WIDExplorer(components, settings, ObjectMother.WIDExplorer_FakeNowFunction);

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
        [Test]
        public void Explore_ShouldReturnExpectedWIDExploration_WhenFinalPageNumberAndStage2()
        {

            // Arrange
            FakeLogger fakeLogger = new FakeLogger();
            Action<string> fakeLoggingAction = (message) => fakeLogger.Log(message);
            FakeLogger fakeLoggerAsciiBanner = new FakeLogger();
            Action<string> fakeLoggingActionAsciiBanner = (message) => fakeLoggerAsciiBanner.Log(message);
            WIDExplorerComponents components = new WIDExplorerComponents(
                    fakeLoggingAction,
                    fakeLoggingActionAsciiBanner,
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
                    new WIDMetricsManager(),
                    new FileManager(),
                    new RepositoryFactory(),
                    new AsciiBannerManager(),
                    new WIDFileNameFactory(),
                    new BulletPointManager()
                  );
            WIDExplorerSettings settings
                = new WIDExplorerSettings(
                        3,
                        0,
                        WIDExplorerSettings.DefaultFolderPath,
                        WIDExplorerSettings.DefaultDeleteAndRecreateDatabase
                    );
            WIDExplorer explorer
                = new WIDExplorer(components, settings, ObjectMother.WIDExplorer_FakeNowFunction);

            List<Page> pages = new List<Page>()
            {

                ObjectMother.Shared_Page01Alternate,
                ObjectMother.Shared_Page02Alternate

            };
            List<PageItem> pageItems = new List<PageItem>() { };
            pageItems.AddRange(ObjectMother.Shared_Page01Alternate_PageItems);
            pageItems.AddRange(ObjectMother.Shared_Page02Alternate_PageItems);
            WIDExploration expected
                = new WIDExploration(
                        ObjectMother.Shared_FakeRunId,
                        ObjectMother.Shared_Page01_TotalResults,
                        ObjectMother.Shared_Page01_TotalEstimatedPages,
                        WIDCategories.AllCategories,
                        WIDStages.Stage2_UpToAllPageItems,
                        true,
                        pages,
                        pageItems
                        );

            // Act
            WIDExploration actual
                = explorer.Explore(
                            ObjectMother.Shared_FakeRunId,
                            2,
                            WIDCategories.AllCategories,
                            WIDStages.Stage2_UpToAllPageItems);

            // Assert
            Assert.IsTrue(
                    ObjectMother.AreEqual(expected, actual)
                );

        }
        [Test]
        public void Explore_ShouldReturnExpectedWIDExploration_WhenFinalPageNumberAndStage3()
        {

            // Arrange
            FakeLogger fakeLogger = new FakeLogger();
            Action<string> fakeLoggingAction = (message) => fakeLogger.Log(message);
            FakeLogger fakeLoggerAsciiBanner = new FakeLogger();
            Action<string> fakeLoggingActionAsciiBanner = (message) => fakeLoggerAsciiBanner.Log(message);
            WIDExplorerComponents components = new WIDExplorerComponents(
                    fakeLoggingAction,
                    fakeLoggingActionAsciiBanner,
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
                    new WIDMetricsManager(),
                    new FileManager(),
                    new RepositoryFactory(),
                    new AsciiBannerManager(),
                    new WIDFileNameFactory(),
                    new BulletPointManager()
                  );
            WIDExplorerSettings settings
                = new WIDExplorerSettings(
                        3,
                        0,
                        WIDExplorerSettings.DefaultFolderPath,
                        WIDExplorerSettings.DefaultDeleteAndRecreateDatabase
                    );
            WIDExplorer explorer
                = new WIDExplorer(components, settings, ObjectMother.WIDExplorer_FakeNowFunction);

            List<Page> pages = new List<Page>()
            {

                ObjectMother.Shared_Page01Alternate,
                ObjectMother.Shared_Page02Alternate

            };
            List<PageItem> pageItems = new List<PageItem>() { };
            pageItems.AddRange(ObjectMother.Shared_Page01Alternate_PageItems);
            pageItems.AddRange(ObjectMother.Shared_Page02Alternate_PageItems);
            WIDExploration expected
                = new WIDExploration(
                        ObjectMother.Shared_FakeRunId,
                        ObjectMother.Shared_Page01_TotalResults,
                        ObjectMother.Shared_Page01_TotalEstimatedPages,
                        WIDCategories.AllCategories,
                        WIDStages.Stage3_UpToAllPageItemsExtended,
                        true,
                        pages,
                        pageItems,
                        ObjectMother.WIDExplorer_FakePageItemsExtended.Invoke()
                        );

            // Act
            WIDExploration actual
                = explorer.Explore(
                            ObjectMother.Shared_FakeRunId,
                            2,
                            WIDCategories.AllCategories,
                            WIDStages.Stage3_UpToAllPageItemsExtended);

            // Assert
            Assert.IsTrue(
                    ObjectMother.AreEqual(expected, actual)
                );

        }
        [Test]
        public void Explore_ShouldReturnExpectedWIDExploration_WhenThresholdDateAndStage1()
        {

            // Arrange
            FakeLogger fakeLogger = new FakeLogger();
            Action<string> fakeLoggingAction = (message) => fakeLogger.Log(message);
            FakeLogger fakeLoggerAsciiBanner = new FakeLogger();
            Action<string> fakeLoggingActionAsciiBanner = (message) => fakeLoggerAsciiBanner.Log(message);
            WIDExplorerComponents components = new WIDExplorerComponents(
                    fakeLoggingAction,
                    fakeLoggingActionAsciiBanner,
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
                    new WIDMetricsManager(),
                    new FileManager(),
                    new RepositoryFactory(),
                    new AsciiBannerManager(),
                    new WIDFileNameFactory(),
                    new BulletPointManager()
                  );
            WIDExplorerSettings settings
                = new WIDExplorerSettings(
                        3,
                        0,
                        WIDExplorerSettings.DefaultFolderPath,
                        WIDExplorerSettings.DefaultDeleteAndRecreateDatabase
                    );
            WIDExplorer explorer
                = new WIDExplorer(components, settings, ObjectMother.WIDExplorer_FakeNowFunction);

            string runIdFakeNow = new RunIdManager().Create(ObjectMother.WIDExplorer_FakeNow, ObjectMother.Shared_Page02Alternate_ThresholdDate01);
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
            WIDExploration actual
                = explorer.Explore(
                            ObjectMother.Shared_Page02Alternate_ThresholdDate01,
                            WIDCategories.AllCategories,
                            WIDStages.Stage1_OnlyMetrics);

            // Assert
            Assert.IsTrue(
                    ObjectMother.AreEqual(expected, actual)
                );

        }

        [TestCaseSource(nameof(exploreAllExceptionTestCases))]
        public void ExploreAll_ShouldThrowACertainException_WhenUnproperArguments
            (TestDelegate del, Type expectedType, string expectedMessage)
                => ObjectMother.Method_ShouldThrowACertainException_WhenUnproperArguments(del, expectedType, expectedMessage);

        [TestCaseSource(nameof(extractFromHtmlExceptionTestCases))]
        public void ExploreFromHtml_ShouldThrowACertainException_WhenUnproperArguments
            (TestDelegate del, Type expectedType, string expectedMessage)
                => ObjectMother.Method_ShouldThrowACertainException_WhenUnproperArguments(del, expectedType, expectedMessage);

        [TestCaseSource(nameof(tryExtractFromHtmlExceptionTestCases))]
        public void TryExploreFromHtml_ShouldThrowACertainException_WhenUnproperArguments
            (TestDelegate del, Type expectedType, string expectedMessage)
                => ObjectMother.Method_ShouldThrowACertainException_WhenUnproperArguments(del, expectedType, expectedMessage);

    }
}

/*
    Author: numbworks@gmail.com
    Last Update: 19.06.2021
*/
