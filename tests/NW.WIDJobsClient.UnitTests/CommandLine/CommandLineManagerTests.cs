using NUnit.Framework;
using System;
using NW.WIDJobs;
using NW.WIDJobs.Explorations;
using NW.WIDJobs.Metrics;
using NW.WIDJobs.Files;
using NW.WIDJobs.Validation;
using NW.WIDJobsClient.Messages;
using NW.WIDJobsClient.CommandLineAccepts;
using NW.WIDJobsClient.CommandLineValidators;
using McMaster.Extensions.CommandLineUtils;
using NW.WIDJobsClient.CommandLine;

namespace NW.WIDJobsClient.UnitTests
{
    [TestFixture]
    public class CommandLineManagerTests
    {

        #region Fields

        private static TestCaseData[] commandLineManagerExceptionTestCases =
        {

            new TestCaseData(
                new TestDelegate(
                    () => new CommandLineManager(
                                thresholdValueManager: null,
                                componentsFactory: new WIDExplorerComponentsFactory(),
                                settingsFactory: new WIDExplorerSettingsFactory()
                            )
                ),
                typeof(ArgumentNullException),
                new ArgumentNullException("thresholdValueManager").Message
            ).SetArgDisplayNames($"{nameof(commandLineManagerExceptionTestCases)}_01"),

            new TestCaseData(
                new TestDelegate(
                    () => new CommandLineManager(
                                thresholdValueManager: new ThresholdValueManager(),
                                componentsFactory: null,
                                settingsFactory: new WIDExplorerSettingsFactory()
                            )
                ),
                typeof(ArgumentNullException),
                new ArgumentNullException("componentsFactory").Message
            ).SetArgDisplayNames($"{nameof(commandLineManagerExceptionTestCases)}_02"),

            new TestCaseData(
                new TestDelegate(
                    () => new CommandLineManager(
                                thresholdValueManager: new ThresholdValueManager(),
                                componentsFactory: new WIDExplorerComponentsFactory(),
                                settingsFactory: null
                            )
                ),
                typeof(ArgumentNullException),
                new ArgumentNullException("settingsFactory").Message
            ).SetArgDisplayNames($"{nameof(commandLineManagerExceptionTestCases)}_03")

        };

        #endregion

        #region SetUp

        #endregion

        #region Tests

        [Test]
        public void CommandLineManager_ShouldCreateAnObjectOfTypeCommandLineManager_WhenInvoked()
        {

            // Arrange
            // Act
            CommandLineManager actual = new CommandLineManager();

            // Assert
            Assert.IsInstanceOf<CommandLineManager>(actual);

        }

        [TestCaseSource(nameof(commandLineManagerExceptionTestCases))]
        public void CommandLineManager_ShouldThrowACertainException_WhenUnproperArguments
            (TestDelegate del, Type expectedType, string expectedMessage)
                => ObjectMother.Method_ShouldThrowACertainException_WhenUnproperArguments(del, expectedType, expectedMessage);

        #endregion

        #region TearDown

        #endregion

        #region Support_methods

        #endregion

    }
}

/*
    Author: numbworks@gmail.com
    Last Update: 29.08.2021
*/
