using NSubstitute;
using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace NW.WIDJobs.UnitTests
{
    [TestFixture]
    public class WIDExplorerTests
    {

        // Fields
        private static TestCaseData[] exploreTestCases =
        {

            new TestCaseData(
                ObjectMother.Explorer_FuncPage1Page2,
                ObjectMother.Explorer_Summary1
                ).SetName(nameof(Explore_ShouldReturnTheExpectedExplorationSummary_WhenInvoked) + " {01}"),

            new TestCaseData(
                ObjectMother.Explorer_FuncPage1Page2,
                ObjectMother.Explorer_Summary1
                ).SetName(nameof(Explore_ShouldReturnTheExpectedExplorationSummary_WhenInvoked) + " {02}"),

            new TestCaseData(
                ObjectMother.Explorer_FuncPage1,
                null
                ).SetName(nameof(Explore_ShouldReturnTheExpectedExplorationSummary_WhenInvoked) + " {03}"
                ).SetDescription("ExecuteScalar() returns Failure."),

            new TestCaseData(
                ObjectMother.Explorer_FuncPage1WithoutDivColSm9,
                null
                ).SetName(nameof(Explore_ShouldReturnTheExpectedExplorationSummary_WhenInvoked) + " {04}"
                ).SetDescription("GetRelativeUrls() returns failure."),

            new TestCaseData(
                ObjectMother.Explorer_FuncSomeMessage,
                null
                ).SetName(nameof(Explore_ShouldReturnTheExpectedExplorationSummary_WhenInvoked) + " {05}"
                ).SetDescription("ResponseStreamToString() returns Failure."),

            new TestCaseData(
                ObjectMother.Explorer_FuncEmptyString,
                null
                ).SetName(nameof(Explore_ShouldReturnTheExpectedExplorationSummary_WhenInvoked) + " {11}"
                ).SetDescription("SendAndGetHttpWebResponse for GetPage(1, ...) returns Success but empty response, GetItems() returns Failure."),

            new TestCaseData(
                new Func<IGetRequestManager>( () => { return null; }),
                null
                ).SetName(nameof(Explore_ShouldReturnTheExpectedExplorationSummary_WhenInvoked) + " {14}"
                ).SetDescription("SendAndGetHttpWebResponse for GetPage(1, ...) returns Exception."),

            new TestCaseData(
                ObjectMother.Explorer_FuncPage1WithoutColSm6,
                null
                ).SetName(nameof(Explore_ShouldReturnTheExpectedExplorationSummary_WhenInvoked) + " {15}"
                ).SetDescription("GetTotalResults() returns failure => InitializeExploration returns Failure."),

            new TestCaseData(
                ObjectMother.Explorer_FuncPage1WithoutStrong1234,
                null
                ).SetName(nameof(Explore_ShouldReturnTheExpectedExplorationSummary_WhenInvoked) + " {16}"
                ).SetDescription("GetTotalResults() returns exception => InitializeExploration returns Exception."),

            new TestCaseData(
                ObjectMother.Explorer_FuncPage1WithoutColSm12,
                null
                ).SetName(nameof(Explore_ShouldReturnTheExpectedExplorationSummary_WhenInvoked) + " {18}"
                ).SetDescription("GetWorkAreas() returns Failure => GetItems() returns Failure => GetPage() returns Failure."),

            new TestCaseData(
                ObjectMother.Explorer_FuncPage1WithoutFirstColSm9,
                null
                ).SetName(nameof(Explore_ShouldReturnTheExpectedExplorationSummary_WhenInvoked) + " {19}"
                ).SetDescription("GetRelativeUrls() != GetWorkAreas() => GetItems() returns Failure => GetPage() returns Failure."),

            ObjectMother.GenerateScenarioPageFour()
                .SetName(nameof(Explore_ShouldReturnTheExpectedExplorationSummary_WhenInvoked) + " {20}")
                .SetDescription(string.Concat(
                    "Page1: 20 new items, Page2: 20 new items, Page3: 20 new items, Page4: 16 new items + 6 already imported.",
                    "It also tests the AntiFloodingStrategy and GetItems() when some <li></li> are missing.",
                    "This method is a workaround due of NUnit issues into manipulate Properties.Resources.* as static property on the fly."))

        };
        private static TestCaseData[] exploreTestCasesException =
        {

            new TestCaseData(null)
                .SetName(nameof(Explorer_ShouldThrowAnException_WhenComponentsAreNull) + " {01}"),

            new TestCaseData(
                    new WIDExplorerComponents(WIDExplorerComponents.DefaultLoggingAction, null, new GetRequestManager()))
                .SetName(nameof(Explorer_ShouldThrowAnException_WhenComponentsAreNull) + " {02}")

        };

        // SetUp
        // Tests
        [TestCaseSource(nameof(exploreTestCases))]
        public void Explore_ShouldReturnTheExpectedExplorationSummary_WhenInvoked
            (Func<IGetRequestManager> func, ExplorationSummary expected)
        {

            // Arrange
            WIDExplorerComponents components 
                = new WIDExplorerComponents(WIDExplorerComponents.DefaultLoggingAction, new XPathManager(), func.Invoke());
            WIDExplorerSettings settings = new WIDExplorerSettings(
                WIDExplorerSettings.DefaultResultsPerPage,
                WIDExplorerSettings.DefaultParallelRequests,
                0 // To avoid waiting time when hit by the tests.
                );
            WIDExplorer explorer = new WIDExplorer(components, settings);

            // Act
            ExplorationSummary actual = explorer.Explore();

            // Assert
            Assert.IsTrue(
                ObjectMother.AreEqual(expected, actual));

        }

        [Test]
        public void Explore_ShouldReturnKgsDotLyngby_WhenWorkAreaIsKgsDotLyngby()
        {

            // Arrange
            string newPage1 = ObjectMother.Explorer_Page1HTML.Replace("Kolding", "Kgs. Lyngby");
            Func<IGetRequestManager> func = new Func<IGetRequestManager>(
                () => {
                    IGetRequestManager fakeGetRequest = Substitute.For<IGetRequestManager>();
                    fakeGetRequest.Send(Arg.Any<string>()).Returns(newPage1, ObjectMother.Explorer_Page2HTML);
                    return fakeGetRequest;
                });
            WIDExplorerComponents components 
                = new WIDExplorerComponents(WIDExplorerComponents.DefaultLoggingAction, new XPathManager(), func.Invoke());
            WIDExplorer explorer = new WIDExplorer(components, new WIDExplorerSettings());
            ExplorationSummary expected =
                new ExplorationSummary
                     (
                         1243,
                         63,
                         new List<Page>() {
                                new Page() {
                                    Url = ObjectMother.Explorer_Page1.Url,
                                    PageNumber = ObjectMother.Explorer_Page1.PageNumber,
                                    IsLastForCurrentExploration = ObjectMother.Explorer_Page1.IsLastForCurrentExploration,
                                    Items = new List<PageItem>() {
                                                new PageItem() {
                                                    Title = "Logistics Specialist",
                                                    Url = "https://www.workindenmark.dk/job/6765129/Logistics-Specialist",
                                                    JobId = "6765129Logistics-Specialist",
                                                    WorkArea = "Kgs. Lyngby"
                                                }
                                    }
                                }
                        }
                     );

            // Act
            ExplorationSummary actual = explorer.Explore();

            // Assert
            Assert.IsTrue(
                ObjectMother.AreEqual(expected, actual));

        }

        [TestCaseSource(nameof(exploreTestCasesException))]
        public void Explorer_ShouldThrowAnException_WhenComponentsAreNull
            (WIDExplorerComponents components)
        {

            // Arrange
            // Act
            // Assert
            Assert.Throws<Exception>(
                () => new WIDExplorer(components, new WIDExplorerSettings()));

        }

        // TearDown
        // Utility methods

    }

}

/*
    Author: numbworks@gmail.com
    Last Update: 06.05.2021
*/