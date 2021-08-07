using NUnit.Framework;
using System;

namespace NW.WIDJobs.UnitTests
{
    [TestFixture]
    public class JobPostingExtendedDeserializerTests
    {

        #region Fields

        private static TestCaseData[] jobPostingExtendedDeserializerExceptionTestCases =
        {

            new TestCaseData(
                new TestDelegate(
                    () => new JobPostingExtendedDeserializer(null)
                ),
                typeof(ArgumentNullException),
                new ArgumentNullException("xpathManager").Message
            ).SetArgDisplayNames($"{nameof(jobPostingExtendedDeserializerExceptionTestCases)}_01")

        };
        private static TestCaseData[] jobPostingExtendedDeserializerTestCases =
        {

            new TestCaseData(
                    ObjectMother.Shared_JobPage01_JobPosting01,
                    ObjectMother.Shared_JobPage01_JobPostingExtended01_Content,
                    ObjectMother.Shared_JobPage01_JobPostingExtended01
                ).SetArgDisplayNames($"{nameof(jobPostingExtendedDeserializerTestCases)}_01"),

            new TestCaseData(
                    ObjectMother.Shared_JobPage01_JobPosting02,
                    ObjectMother.Shared_JobPage01_JobPostingExtended02_Content,
                    ObjectMother.Shared_JobPage01_JobPostingExtended02
                ).SetArgDisplayNames($"{nameof(jobPostingExtendedDeserializerTestCases)}_02"),

            new TestCaseData(
                    ObjectMother.Shared_JobPage01_JobPosting03,
                    ObjectMother.Shared_JobPage01_JobPostingExtended03_Content,
                    ObjectMother.Shared_JobPage01_JobPostingExtended03
                ).SetArgDisplayNames($"{nameof(jobPostingExtendedDeserializerTestCases)}_03"),

            new TestCaseData(
                    ObjectMother.Shared_JobPage01_JobPosting04,
                    ObjectMother.Shared_JobPage01_JobPostingExtended04_Content,
                    ObjectMother.Shared_JobPage01_JobPostingExtended04
                ).SetArgDisplayNames($"{nameof(jobPostingExtendedDeserializerTestCases)}_04"),

            new TestCaseData(
                    ObjectMother.Shared_JobPage01_JobPosting05,
                    ObjectMother.Shared_JobPage01_JobPostingExtended05_Content,
                    ObjectMother.Shared_JobPage01_JobPostingExtended05
                ).SetArgDisplayNames($"{nameof(jobPostingExtendedDeserializerTestCases)}_05"),

            new TestCaseData(
                    ObjectMother.Shared_JobPage01_JobPosting06,
                    ObjectMother.Shared_JobPage01_JobPostingExtended06_Content,
                    ObjectMother.Shared_JobPage01_JobPostingExtended06
                ).SetArgDisplayNames($"{nameof(jobPostingExtendedDeserializerTestCases)}_06"),

            new TestCaseData(
                    ObjectMother.Shared_JobPage01_JobPosting07,
                    ObjectMother.Shared_JobPage01_JobPostingExtended07_Content,
                    ObjectMother.Shared_JobPage01_JobPostingExtended07
                ).SetArgDisplayNames($"{nameof(jobPostingExtendedDeserializerTestCases)}_07"),

            new TestCaseData(
                    ObjectMother.Shared_JobPage01_JobPosting08,
                    ObjectMother.Shared_JobPage01_JobPostingExtended08_Content,
                    ObjectMother.Shared_JobPage01_JobPostingExtended08
                ).SetArgDisplayNames($"{nameof(jobPostingExtendedDeserializerTestCases)}_08"),

            new TestCaseData(
                    ObjectMother.Shared_JobPage01_JobPosting09,
                    ObjectMother.Shared_JobPage01_JobPostingExtended09_Content,
                    ObjectMother.Shared_JobPage01_JobPostingExtended09
                ).SetArgDisplayNames($"{nameof(jobPostingExtendedDeserializerTestCases)}_09"),

            new TestCaseData(
                    ObjectMother.Shared_JobPage01_JobPosting10,
                    ObjectMother.Shared_JobPage01_JobPostingExtended10_Content,
                    ObjectMother.Shared_JobPage01_JobPostingExtended10
                ).SetArgDisplayNames($"{nameof(jobPostingExtendedDeserializerTestCases)}_10"),

            new TestCaseData(
                    ObjectMother.Shared_JobPage01_JobPosting11,
                    ObjectMother.Shared_JobPage01_JobPostingExtended11_Content,
                    ObjectMother.Shared_JobPage01_JobPostingExtended11
                ).SetArgDisplayNames($"{nameof(jobPostingExtendedDeserializerTestCases)}_11"),

            new TestCaseData(
                    ObjectMother.Shared_JobPage01_JobPosting12,
                    ObjectMother.Shared_JobPage01_JobPostingExtended12_Content,
                    ObjectMother.Shared_JobPage01_JobPostingExtended12
                ).SetArgDisplayNames($"{nameof(jobPostingExtendedDeserializerTestCases)}_12"),

            new TestCaseData(
                    ObjectMother.Shared_JobPage01_JobPosting13,
                    ObjectMother.Shared_JobPage01_JobPostingExtended13_Content,
                    ObjectMother.Shared_JobPage01_JobPostingExtended13
                ).SetArgDisplayNames($"{nameof(jobPostingExtendedDeserializerTestCases)}_13"),

            new TestCaseData(
                    ObjectMother.Shared_JobPage01_JobPosting14,
                    ObjectMother.Shared_JobPage01_JobPostingExtended14_Content,
                    ObjectMother.Shared_JobPage01_JobPostingExtended14
                ).SetArgDisplayNames($"{nameof(jobPostingExtendedDeserializerTestCases)}_14"),

            new TestCaseData(
                    ObjectMother.Shared_JobPage01_JobPosting15,
                    ObjectMother.Shared_JobPage01_JobPostingExtended15_Content,
                    ObjectMother.Shared_JobPage01_JobPostingExtended15
                ).SetArgDisplayNames($"{nameof(jobPostingExtendedDeserializerTestCases)}_15"),

            new TestCaseData(
                    ObjectMother.Shared_JobPage01_JobPosting16,
                    ObjectMother.Shared_JobPage01_JobPostingExtended16_Content,
                    ObjectMother.Shared_JobPage01_JobPostingExtended16
                ).SetArgDisplayNames($"{nameof(jobPostingExtendedDeserializerTestCases)}_16"),

            new TestCaseData(
                    ObjectMother.Shared_JobPage01_JobPosting17,
                    ObjectMother.Shared_JobPage01_JobPostingExtended17_Content,
                    ObjectMother.Shared_JobPage01_JobPostingExtended17
                ).SetArgDisplayNames($"{nameof(jobPostingExtendedDeserializerTestCases)}_17"),

            new TestCaseData(
                    ObjectMother.Shared_JobPage01_JobPosting18,
                    ObjectMother.Shared_JobPage01_JobPostingExtended18_Content,
                    ObjectMother.Shared_JobPage01_JobPostingExtended18
                ).SetArgDisplayNames($"{nameof(jobPostingExtendedDeserializerTestCases)}_18"),

            new TestCaseData(
                    ObjectMother.Shared_JobPage01_JobPosting19,
                    ObjectMother.Shared_JobPage01_JobPostingExtended19_Content,
                    ObjectMother.Shared_JobPage01_JobPostingExtended19
                ).SetArgDisplayNames($"{nameof(jobPostingExtendedDeserializerTestCases)}_19"),

            new TestCaseData(
                    ObjectMother.Shared_JobPage01_JobPosting20,
                    ObjectMother.Shared_JobPage01_JobPostingExtended20_Content,
                    ObjectMother.Shared_JobPage01_JobPostingExtended20
                ).SetArgDisplayNames($"{nameof(jobPostingExtendedDeserializerTestCases)}_20"),

        };

        #endregion

        #region SetUp

        #endregion

        #region Tests

        [TestCaseSource(nameof(jobPostingExtendedDeserializerExceptionTestCases))]
        public void JobPostingExtendedDeserializer_ShouldThrowACertainException_WhenUnproperArguments
            (TestDelegate del, Type expectedType, string expectedMessage)
                => ObjectMother.Method_ShouldThrowACertainException_WhenUnproperArguments(del, expectedType, expectedMessage);


        [TestCaseSource(nameof(jobPostingExtendedDeserializerTestCases))]
        public void Do_ShouldReturnTheExpectedJobPostingExtended_WhenInvoked
            (JobPosting jobPosting, string response, JobPostingExtended expected)
        {

            // Arrange
            // Act
            JobPostingExtended actual = new JobPostingExtendedDeserializer().Do(jobPosting, response);

            // Assert
            Assert.IsTrue(
                    ObjectMother.AreEqual(expected, actual)
                );

        }

        #endregion

        #region TearDown

        #endregion

    }
}

/*
    Author: numbworks@gmail.com
    Last Update: 07.08.2021
*/