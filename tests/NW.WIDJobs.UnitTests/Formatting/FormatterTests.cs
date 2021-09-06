using NUnit.Framework;
using System;
using NW.WIDJobs.Explorations;
using NW.WIDJobs.Metrics;
using NW.WIDJobs.JobPostingsExtended;
using NW.WIDJobs.JobPostings;
using NW.WIDJobs.Formatting;
using NW.WIDJobs.Messages;

namespace NW.WIDJobs.UnitTests
{
    [TestFixture]
    public class FormatterTests
    {

        #region Fields

        private static TestCaseData[] formatterExceptionTestCases =
        {

            new TestCaseData(
                new TestDelegate(
                    () => new Formatter(null)
				),
                typeof(ArgumentNullException),
                new ArgumentNullException("metricCollectionManager").Message
            ).SetArgDisplayNames($"{nameof(formatterExceptionTestCases)}_01")

        };
        private static TestCaseData[] formatExceptionTestCases =
        {

            new TestCaseData(
                new TestDelegate(
                    () => new Formatter().Format((JobPosting)null)
                ),
                typeof(ArgumentNullException),
                new ArgumentNullException("jobPosting").Message
            ).SetArgDisplayNames($"{nameof(formatterExceptionTestCases)}_01"),

            new TestCaseData(
                new TestDelegate(
                    () => new Formatter().Format((JobPostingExtended)null)
                ),
                typeof(ArgumentNullException),
                new ArgumentNullException("jobPostingExtended").Message
            ).SetArgDisplayNames($"{nameof(formatterExceptionTestCases)}_02"),

            new TestCaseData(
                new TestDelegate(
                    () => new Formatter().Format((Exploration)null)
                ),
                typeof(ArgumentNullException),
                new ArgumentNullException("exploration").Message
            ).SetArgDisplayNames($"{nameof(formatterExceptionTestCases)}_03"),

            new TestCaseData(
                new TestDelegate(
                    () => new Formatter()
                            .Format(
                                new Exploration(
                                        runId: ObjectMother.Shared_FakeRunId,
                                        totalResultCount: 1,
                                        totalJobPages: 1,
                                        stage: (Stages)(-1),
                                        isCompleted: true
                                    )
                            )
                ),
                typeof(Exception),
                MessageCollection.Formatter_NoFormattingStrategyAvailableFor(((Stages)(-1)).ToString())
            ).SetArgDisplayNames($"{nameof(formatterExceptionTestCases)}_04"),

            new TestCaseData(
                new TestDelegate(
                    () => new Formatter().Format((MetricCollection)null)
                ),
                typeof(ArgumentNullException),
                new ArgumentNullException("metricCollection").Message
            ).SetArgDisplayNames($"{nameof(formatterExceptionTestCases)}_05")

        };
        private static TestCaseData[] formatTestCases =
        {

            new TestCaseData(
                    new Func<string>(
                        () => new Formatter().Format(ObjectMother.Shared_JobPage01_JobPosting01)
                    ),
                    string.Concat(
                        $"{nameof(JobPosting)}: ",
                        $"'{ObjectMother.Shared_JobPage01_JobPosting01.Id}', ",
                        $"'{new Formatter().Format(ObjectMother.Shared_JobPage01_JobPosting01.Title)}', ",
                        $"'{new Formatter().Format(ObjectMother.Shared_JobPage01_JobPosting01.HiringOrgName)}', ",
                        $"'{ObjectMother.Shared_JobPage01_JobPosting01.WorkPlaceCityWithoutZone}'."
                    )
                ).SetArgDisplayNames($"{nameof(formatTestCases)}_01"),

            new TestCaseData(
                    new Func<string>(
                        () => new Formatter().Format(ObjectMother.Shared_JobPage01_JobPostingExtended01)
                    ),
                    string.Concat(
                        $"{nameof(JobPostingExtended)}: ",
                        $"'{ObjectMother.Shared_JobPage01_JobPostingExtended01.JobPosting.Id}', ",
                        $"'{new Formatter().Format(ObjectMother.Shared_JobPage01_JobPosting01.Title)}', ",
                        $"'{ObjectMother.Shared_JobPage01_JobPostingExtended01.BulletPoints?.Count.ToString() ?? Formatter.ZeroString}' {Formatter.BulletPointsString}."
                    )
                ).SetArgDisplayNames($"{nameof(formatTestCases)}_02"),

            new TestCaseData(
                    new Func<string>(
                        () => new Formatter().Format(ObjectMother.Shared_ExplorationStage1)
                    ),
                    string.Concat(
                            $"{nameof(Exploration)}: ",
                            $"'{ObjectMother.Shared_ExplorationStage1.TotalResultCount}' {nameof(Exploration.JobPostings)}, ",
                            $"'{ObjectMother.Shared_ExplorationStage1.TotalJobPages}' {nameof(Exploration.JobPages)}."
                        )
                ).SetArgDisplayNames($"{nameof(formatTestCases)}_03"),

            new TestCaseData(
                    new Func<string>(
                        () => new Formatter().Format(ObjectMother.Shared_ExplorationStage2)
                    ),
                    string.Concat(
                            $"{nameof(Exploration)}: ",
                            $"'{ObjectMother.Shared_ExplorationStage2.JobPages?.Count.ToString() ?? Formatter.ZeroString}' {nameof(Exploration.JobPages)}, ",
                            $"'{ObjectMother.Shared_ExplorationStage2.JobPostings?.Count.ToString() ?? Formatter.ZeroString}' {nameof(Exploration.JobPostings)}."
                        )
                ).SetArgDisplayNames($"{nameof(formatTestCases)}_04"),

            new TestCaseData(
                    new Func<string>(
                        () => new Formatter().Format(ObjectMother.Shared_ExplorationStage3)
                    ),
                    string.Concat(
                            $"{nameof(Exploration)}: ",
                            $"'{ObjectMother.Shared_ExplorationStage3.JobPages?.Count.ToString() ?? Formatter.ZeroString}' {nameof(Exploration.JobPages)}, ",
                            $"'{ObjectMother.Shared_ExplorationStage3.JobPostingsExtended?.Count.ToString() ?? Formatter.ZeroString}' {nameof(Exploration.JobPostingsExtended)}, ",
                            $"'{new MetricCollectionManager().TrySumBulletPoints(ObjectMother.Shared_ExplorationStage3)?.ToString() ?? Formatter.ZeroString}' {Formatter.BulletPointsString}."
                        )
                ).SetArgDisplayNames($"{nameof(formatTestCases)}_05"),

            new TestCaseData(
                    new Func<string>(
                        () => new Formatter().Format(ObjectMother.MetricCollection_ExplorationStage3)
                    ),
                    string.Concat(
                        $"{nameof(MetricCollection)}: ",
                        $"'{ObjectMother.MetricCollection_ExplorationStage3.TotalJobPages}' {nameof(Exploration.JobPages)}, ",
                        $"'{ObjectMother.MetricCollection_ExplorationStage3.TotalJobPostings}' {nameof(Exploration.JobPostings)}, ",
                        $"'{ObjectMother.MetricCollection_ExplorationStage3.TotalBulletPoints}' {Formatter.BulletPointsString}."
                    )
                ).SetArgDisplayNames($"{nameof(formatTestCases)}_06")

        };

        #endregion

        #region SetUp

        #endregion

        #region Tests

        [TestCaseSource(nameof(formatterExceptionTestCases))]
        public void Formatter_ShouldThrowACertainException_WhenUnproperArguments
            (TestDelegate del, Type expectedType, string expectedMessage)
                => ObjectMother.Method_ShouldThrowACertainException_WhenUnproperArguments(del, expectedType, expectedMessage);

        [TestCaseSource(nameof(formatExceptionTestCases))]
        public void Format_ShouldThrowACertainException_WhenUnproperArguments
            (TestDelegate del, Type expectedType, string expectedMessage)
                => ObjectMother.Method_ShouldThrowACertainException_WhenUnproperArguments(del, expectedType, expectedMessage);

        [TestCaseSource(nameof(formatTestCases))]
        public void Format_ShouldReturnExpectedString_WhenInvoked(Func<string> func, string expected)
        {

            // Arrange
            // Act
            string actual = func.Invoke();

            // Assert
            Assert.AreEqual(expected, actual);

        }

        [Test]
        public void Formatter_ShouldCreateAnObjectOfTypeFormatter_WhenInvoked()
        {

            // Arrange
            // Act
            Formatter actual = new Formatter();

            // Assert
            Assert.IsInstanceOf<Formatter>(actual);
            Assert.AreEqual("BulletPoints", Formatter.BulletPointsString);
            Assert.AreEqual("0", Formatter.ZeroString);

        }

        #endregion

        #region TearDown

        #endregion

    }
}

/*
    Author: numbworks@gmail.com
    Last Update: 06.09.2021
*/
