﻿using System;
using NUnit.Framework;

namespace NW.WIDJobs.UnitTests
{
    [TestFixture]
    public class WIDExplorerComponentsTests
    {

        // Fields
        private static TestCaseData[] widExplorerComponentsExceptionTestCases =
        {

            new TestCaseData(
                new TestDelegate(
                    () => new WIDExplorerComponents(
                                null,
                                new XPathManager(),
                                new GetRequestManager(),
                                new PageManager(),
                                new PageScraper(),
                                new PageItemScraper(),
                                new PageItemExtendedManager(),
                                new PageItemExtendedScraper(),
                                new RunIdManager(),
                                new BulletPointManager()
                        )
                ),
                typeof(ArgumentNullException),
                new ArgumentNullException("loggingAction").Message
            ).SetArgDisplayNames($"{nameof(widExplorerComponentsExceptionTestCases)}_01"),

            new TestCaseData(
                new TestDelegate(
                    () => new WIDExplorerComponents(
                                WIDExplorerComponents.DefaultLoggingAction,
                                null,
                                new GetRequestManager(),
                                new PageManager(),
                                new PageScraper(),
                                new PageItemScraper(),
                                new PageItemExtendedManager(),
                                new PageItemExtendedScraper(),
                                new RunIdManager(),
                                new BulletPointManager()
                        )
                ),
                typeof(ArgumentNullException),
                new ArgumentNullException("xpathManager").Message
            ).SetArgDisplayNames($"{nameof(widExplorerComponentsExceptionTestCases)}_02"),

            new TestCaseData(
                new TestDelegate(
                    () => new WIDExplorerComponents(
                                WIDExplorerComponents.DefaultLoggingAction,
                                new XPathManager(),
                                null,
                                new PageManager(),
                                new PageScraper(),
                                new PageItemScraper(),
                                new PageItemExtendedManager(),
                                new PageItemExtendedScraper(),
                                new RunIdManager(),
                                new BulletPointManager()
                        )
                ),
                typeof(ArgumentNullException),
                new ArgumentNullException("getRequestManager").Message
            ).SetArgDisplayNames($"{nameof(widExplorerComponentsExceptionTestCases)}_03"),

            new TestCaseData(
                new TestDelegate(
                    () => new WIDExplorerComponents(
                                WIDExplorerComponents.DefaultLoggingAction,
                                new XPathManager(),
                                new GetRequestManager(),
                                null,
                                new PageScraper(),
                                new PageItemScraper(),
                                new PageItemExtendedManager(),
                                new PageItemExtendedScraper(),
                                new RunIdManager(),
                                new BulletPointManager()
                        )
                ),
                typeof(ArgumentNullException),
                new ArgumentNullException("pageManager").Message
            ).SetArgDisplayNames($"{nameof(widExplorerComponentsExceptionTestCases)}_04"),

            new TestCaseData(
                new TestDelegate(
                    () => new WIDExplorerComponents(
                                WIDExplorerComponents.DefaultLoggingAction,
                                new XPathManager(),
                                new GetRequestManager(),
                                new PageManager(),
                                null,
                                new PageItemScraper(),
                                new PageItemExtendedManager(),
                                new PageItemExtendedScraper(),
                                new RunIdManager(),
                                new BulletPointManager()
                        )
                ),
                typeof(ArgumentNullException),
                new ArgumentNullException("pageScraper").Message
            ).SetArgDisplayNames($"{nameof(widExplorerComponentsExceptionTestCases)}_05"),

            new TestCaseData(
                new TestDelegate(
                    () => new WIDExplorerComponents(
                                WIDExplorerComponents.DefaultLoggingAction,
                                new XPathManager(),
                                new GetRequestManager(),
                                new PageManager(),
                                new PageScraper(),
                                null,
                                new PageItemExtendedManager(),
                                new PageItemExtendedScraper(),
                                new RunIdManager(),
                                new BulletPointManager()
                        )
                ),
                typeof(ArgumentNullException),
                new ArgumentNullException("pageItemScraper").Message
            ).SetArgDisplayNames($"{nameof(widExplorerComponentsExceptionTestCases)}_06"),

            new TestCaseData(
                new TestDelegate(
                    () => new WIDExplorerComponents(
                                WIDExplorerComponents.DefaultLoggingAction,
                                new XPathManager(),
                                new GetRequestManager(),
                                new PageManager(),
                                new PageScraper(),
                                new PageItemScraper(),
                                null,
                                new PageItemExtendedScraper(),
                                new RunIdManager(),
                                new BulletPointManager()
                        )
                ),
                typeof(ArgumentNullException),
                new ArgumentNullException("pageItemExtendedManager").Message
            ).SetArgDisplayNames($"{nameof(widExplorerComponentsExceptionTestCases)}_07"),

            new TestCaseData(
                new TestDelegate(
                    () => new WIDExplorerComponents(
                                WIDExplorerComponents.DefaultLoggingAction,
                                new XPathManager(),
                                new GetRequestManager(),
                                new PageManager(),
                                new PageScraper(),
                                new PageItemScraper(),
                                new PageItemExtendedManager(),
                                null,
                                new RunIdManager(),
                                new BulletPointManager()
                        )
                ),
                typeof(ArgumentNullException),
                new ArgumentNullException("pageItemExtendedScraper").Message
            ).SetArgDisplayNames($"{nameof(widExplorerComponentsExceptionTestCases)}_08"),

            new TestCaseData(
                new TestDelegate(
                    () => new WIDExplorerComponents(
                                WIDExplorerComponents.DefaultLoggingAction,
                                new XPathManager(),
                                new GetRequestManager(),
                                new PageManager(),
                                new PageScraper(),
                                new PageItemScraper(),
                                new PageItemExtendedManager(),
                                new PageItemExtendedScraper(),
                                null,
                                new BulletPointManager()
                        )
                ),
                typeof(ArgumentNullException),
                new ArgumentNullException("runIdManager").Message
            ).SetArgDisplayNames($"{nameof(widExplorerComponentsExceptionTestCases)}_09"),

            new TestCaseData(
                new TestDelegate(
                    () => new WIDExplorerComponents(
                                WIDExplorerComponents.DefaultLoggingAction,
                                new XPathManager(),
                                new GetRequestManager(),
                                new PageManager(),
                                new PageScraper(),
                                new PageItemScraper(),
                                new PageItemExtendedManager(),
                                new PageItemExtendedScraper(),
                                new RunIdManager(),
                                null
                        )
                ),
                typeof(ArgumentNullException),
                new ArgumentNullException("bulletPointManager").Message
            ).SetArgDisplayNames($"{nameof(widExplorerComponentsExceptionTestCases)}_10")

        };

        // SetUp
        // Tests
        [Test]
        public void WIDExplorerComponents_ShouldInitializeANewWIDExplorerComponentsObject_WhenProperArguments()
        {

            // Arrange
            // Act
            WIDExplorerComponents actual =
                new WIDExplorerComponents(
                            WIDExplorerComponents.DefaultLoggingAction,
                            new XPathManager(),
                            new GetRequestManager(),
                            new PageManager(),
                            new PageScraper(),
                            new PageItemScraper(),
                            new PageItemExtendedManager(),
                            new PageItemExtendedScraper(),
                            new RunIdManager(),
                            new BulletPointManager()
                        );

            // Assert
            Assert.IsInstanceOf<WIDExplorerComponents>(actual);

        }

        [Test]
        public void WIDExplorerComponents_ShouldInitializeANewWIDExplorerComponentsObject_WhenDefaultConstructor()
        {

            // Arrange
            // Act
            WIDExplorerComponents actual =
                new WIDExplorerComponents();

            // Assert
            Assert.IsInstanceOf<WIDExplorerComponents>(actual);

        }

        [TestCaseSource(nameof(widExplorerComponentsExceptionTestCases))]
        public void WIDExplorerComponents_ShouldThrowACertainException_WhenUnproperArguments
            (TestDelegate del, Type expectedType, string expectedMessage)
                => ObjectMother.Method_ShouldThrowACertainException_WhenUnproperArguments(del, expectedType, expectedMessage);

        // TearDown		

    }
}

/*
    Author: numbworks@gmail.com
    Last Update: 15.05.2021
*/