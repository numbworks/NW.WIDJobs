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
        private static TestCaseData[] executeTestCases =
        {

            new TestCaseData(
                    new string[] { "about" },
                    new FakeWIDExplorerComponentsFactory(FakeWIDExplorerComponentsTypes.allsuccess),
                    CommandLineManager.Success
                ).SetArgDisplayNames($"{nameof(executeTestCases)}_01"),

            new TestCaseData(
                    new string[] { "session" },
                    new FakeWIDExplorerComponentsFactory(FakeWIDExplorerComponentsTypes.allsuccess),
                    CommandLineManager.Success
                ).SetArgDisplayNames($"{nameof(executeTestCases)}_02"),

            new TestCaseData(
                    new string[] { "session", "calculate" },
                    new FakeWIDExplorerComponentsFactory(FakeWIDExplorerComponentsTypes.allsuccess),
                    CommandLineManager.Failure
                ).SetArgDisplayNames($"{nameof(executeTestCases)}_03"),

            new TestCaseData(
                    new string[] { "session", "convert" },
                    new FakeWIDExplorerComponentsFactory(FakeWIDExplorerComponentsTypes.allsuccess),
                    CommandLineManager.Failure
                ).SetArgDisplayNames($"{nameof(executeTestCases)}_04"),

            new TestCaseData(
                    new string[] { "session", "describe" },
                    new FakeWIDExplorerComponentsFactory(FakeWIDExplorerComponentsTypes.allsuccess),
                    CommandLineManager.Failure
                ).SetArgDisplayNames($"{nameof(executeTestCases)}_05"),

            new TestCaseData(
                    new string[] { "session", "explore" },
                    new FakeWIDExplorerComponentsFactory(FakeWIDExplorerComponentsTypes.allsuccess),
                    CommandLineManager.Failure
                ).SetArgDisplayNames($"{nameof(executeTestCases)}_06"),

            new TestCaseData(
                    new string[] { "service" },
                    new FakeWIDExplorerComponentsFactory(FakeWIDExplorerComponentsTypes.allsuccess),
                    CommandLineManager.Success
                ).SetArgDisplayNames($"{nameof(executeTestCases)}_07")

            // The option:argument pairs can be tested because they rely on the internal FileExistance() validators.

        };
        private static TestCaseData[] executeExceptionTestCases =
        {

            new TestCaseData(
                new TestDelegate(
                    () => new CommandLineManager().Execute( new string[] { "session", "calculate", "--jsonpath" } )
                ),
                typeof(CommandParsingException),
                "Missing value for option 'jsonpath'"
            ).SetArgDisplayNames($"{nameof(executeExceptionTestCases)}_01"),

            new TestCaseData(
                new TestDelegate(
                    () => new CommandLineManager().Execute( new string[] { "session", "calculate", "--jsonpath:'F:\\exploration.json'", "--output" } )
                ),
                typeof(CommandParsingException),
                "Missing value for option 'output'"
            ).SetArgDisplayNames($"{nameof(executeExceptionTestCases)}_02")

        };
        private static TestCaseData[] createOptionValueExceptionExceptionTestCases =
        {

            new TestCaseData(
                new TestDelegate(
                    () => ObjectMother.CallPrivateMethod<CommandLineManager, CalculateOutputs>(new CommandLineManager(), "ConvertToCalculateOutputs", new object[1] { "nonexistantvalue" })
                ),
                typeof(Exception),
                MessageCollection.CommandLineManager_OptionValueCantBeConvertedTo.Invoke("nonexistantvalue", typeof(CalculateOutputs))
            ).SetArgDisplayNames($"{nameof(createOptionValueExceptionExceptionTestCases)}_01"),

            new TestCaseData(
                new TestDelegate(
                    () => ObjectMother.CallPrivateMethod<CommandLineManager, DescribeOutputs>(new CommandLineManager(), "ConvertToDescribeOutputs", new object[1] { "nonexistantvalue" })
                ),
                typeof(Exception),
                MessageCollection.CommandLineManager_OptionValueCantBeConvertedTo.Invoke("nonexistantvalue", typeof(DescribeOutputs))
            ).SetArgDisplayNames($"{nameof(createOptionValueExceptionExceptionTestCases)}_02"),

            new TestCaseData(
                new TestDelegate(
                    () => ObjectMother.CallPrivateMethod<CommandLineManager, MetricsOutputs>(new CommandLineManager(), "ConvertToMetricsOutputs", new object[1] { "nonexistantvalue" })
                ),
                typeof(Exception),
                MessageCollection.CommandLineManager_OptionValueCantBeConvertedTo.Invoke("nonexistantvalue", typeof(MetricsOutputs))
            ).SetArgDisplayNames($"{nameof(createOptionValueExceptionExceptionTestCases)}_03"),

            new TestCaseData(
                new TestDelegate(
                    () => ObjectMother.CallPrivateMethod<CommandLineManager, ConvertOutputs>(new CommandLineManager(), "ConvertToConvertOutputs", new object[1] { "nonexistantvalue" })
                ),
                typeof(Exception),
                MessageCollection.CommandLineManager_OptionValueCantBeConvertedTo.Invoke("nonexistantvalue", typeof(ConvertOutputs))
            ).SetArgDisplayNames($"{nameof(createOptionValueExceptionExceptionTestCases)}_04"),

            new TestCaseData(
                new TestDelegate(
                    () => ObjectMother.CallPrivateMethod<CommandLineManager, ExploreOutputs>(new CommandLineManager(), "ConvertToExploreOutputs", new object[1] { "nonexistantvalue" })
                ),
                typeof(Exception),
                MessageCollection.CommandLineManager_OptionValueCantBeConvertedTo.Invoke("nonexistantvalue", typeof(ExploreOutputs))
            ).SetArgDisplayNames($"{nameof(createOptionValueExceptionExceptionTestCases)}_05"),

            new TestCaseData(
                new TestDelegate(
                    () => ObjectMother.CallPrivateMethod<CommandLineManager, ExploreStages>(new CommandLineManager(), "ConvertToExploreStages", new object[1] { "nonexistantvalue" })
                ),
                typeof(Exception),
                MessageCollection.CommandLineManager_OptionValueCantBeConvertedTo.Invoke("nonexistantvalue", typeof(ExploreStages))
            ).SetArgDisplayNames($"{nameof(createOptionValueExceptionExceptionTestCases)}_06"),

            new TestCaseData(
                new TestDelegate(
                    () => ObjectMother.CallPrivateMethod<CommandLineManager, ThresholdTypes>(new CommandLineManager(), "ConvertToThresholdTypes", new object[1] { "nonexistantvalue" })
                ),
                typeof(Exception),
                MessageCollection.CommandLineManager_OptionValueCantBeConvertedTo.Invoke("nonexistantvalue", typeof(ThresholdTypes))
            ).SetArgDisplayNames($"{nameof(createOptionValueExceptionExceptionTestCases)}_07"),

            new TestCaseData(
                new TestDelegate(
                    () => ObjectMother.CallPrivateMethod<CommandLineManager, Stages>(new CommandLineManager(), "ConvertToStages", new object[1] { (ExploreStages)(-1) })
                ),
                typeof(Exception),
                MessageCollection.CommandLineManager_OptionValueCantBeConvertedTo.Invoke("-1", typeof(Stages))
            ).SetArgDisplayNames($"{nameof(createOptionValueExceptionExceptionTestCases)}_08")

        };
        private static TestCaseData[] createMappingExceptionExceptionTestCases =
        {

            new TestCaseData(
                new TestDelegate(
                    () => ObjectMother.CallPrivateMethod<CommandLineManager, MetricsOutputs>(new CommandLineManager(), "MapCalculateToMetrics", new object[1] { (CalculateOutputs)(-1) })
                ),
                typeof(Exception),
                MessageCollection.CommandLineManager_FirstEnumCantBeMapped.Invoke(typeof(CalculateOutputs), typeof(MetricsOutputs), "-1")
            ).SetArgDisplayNames($"{nameof(createMappingExceptionExceptionTestCases)}_01")

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

        [TestCaseSource(nameof(executeTestCases))]
        public void Execute_ShouldReturnExpectedExitCode_WhenInvoked
            (string[] args, IWIDExplorerComponentsFactory fakeComponentsFactory, int expected)
        {

            // Arrange
            // Act
            CommandLineManager commandLineManager = new CommandLineManager(new ThresholdValueManager(), fakeComponentsFactory, new WIDExplorerSettingsFactory());
            int actual = commandLineManager.Execute(args);

            // Assert
            Assert.AreEqual(expected, actual);

        }

        [TestCaseSource(nameof(executeExceptionTestCases))]
        public void Execute_ShouldThrowACertainException_WhenUnproperArguments
            (TestDelegate del, Type expectedType, string expectedMessage)
                => ObjectMother.Method_ShouldThrowACertainException_WhenUnproperArguments(del, expectedType, expectedMessage);

        [TestCaseSource(nameof(createOptionValueExceptionExceptionTestCases))]
        public void CreateOptionValueException_ShouldThrowACertainInnerException_WhenCallPrivateMethodAndUnproperArguments
            (TestDelegate del, Type expectedInnerType, string expectedInnerMessage)
                => ObjectMother.Method_ShouldThrowACertainInnnerException_WhenCallPrivateMethodAndUnproperArguments(del, expectedInnerType, expectedInnerMessage);

        [TestCaseSource(nameof(createMappingExceptionExceptionTestCases))]
        public void CreateMappingException_ShouldThrowACertainInnerException_WhenCallPrivateMethodAndUnproperArguments
            (TestDelegate del, Type expectedInnerType, string expectedInnerMessage)
                => ObjectMother.Method_ShouldThrowACertainInnnerException_WhenCallPrivateMethodAndUnproperArguments(del, expectedInnerType, expectedInnerMessage);

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
