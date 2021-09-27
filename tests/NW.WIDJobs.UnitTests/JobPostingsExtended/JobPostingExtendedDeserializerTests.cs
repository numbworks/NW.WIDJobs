using NUnit.Framework;
using System;
using NW.WIDJobs.JobPostings;
using NW.WIDJobs.JobPostingsExtended;
using NW.WIDJobs.Classification;
using NW.WIDJobs.XPath;

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
                    () => new JobPostingExtendedDeserializer(
                                null, 
                                new ClassificationManager(),
                                JobPostingExtendedDeserializer.DefaultPredictBulletPointType
                            )
                ),
                typeof(ArgumentNullException),
                new ArgumentNullException("xpathManager").Message
            ).SetArgDisplayNames($"{nameof(jobPostingExtendedDeserializerExceptionTestCases)}_01"),

            new TestCaseData(
                new TestDelegate(
                    () => new JobPostingExtendedDeserializer(
                                new XPathManager(),
                                null,
                                JobPostingExtendedDeserializer.DefaultPredictBulletPointType
                            )
                ),
                typeof(ArgumentNullException),
                new ArgumentNullException("classificationManager").Message
            ).SetArgDisplayNames($"{nameof(jobPostingExtendedDeserializerExceptionTestCases)}_02")

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

            new TestCaseData(
                    ObjectMother.Shared_JobPage02_JobPosting01,
                    ObjectMother.Shared_JobPage02_JobPostingExtended01_Content,
                    ObjectMother.Shared_JobPage02_JobPostingExtended01
                ).SetArgDisplayNames($"{nameof(jobPostingExtendedDeserializerTestCases)}_21"),

            new TestCaseData(
                    ObjectMother.Shared_JobPage02_JobPosting02,
                    ObjectMother.Shared_JobPage02_JobPostingExtended02_Content,
                    ObjectMother.Shared_JobPage02_JobPostingExtended02
                ).SetArgDisplayNames($"{nameof(jobPostingExtendedDeserializerTestCases)}_22"),

            new TestCaseData(
                    ObjectMother.Shared_JobPage02_JobPosting03,
                    ObjectMother.Shared_JobPage02_JobPostingExtended03_Content,
                    ObjectMother.Shared_JobPage02_JobPostingExtended03
                ).SetArgDisplayNames($"{nameof(jobPostingExtendedDeserializerTestCases)}_23"),

            new TestCaseData(
                    ObjectMother.Shared_JobPage02_JobPosting04,
                    ObjectMother.Shared_JobPage02_JobPostingExtended04_Content,
                    ObjectMother.Shared_JobPage02_JobPostingExtended04
                ).SetArgDisplayNames($"{nameof(jobPostingExtendedDeserializerTestCases)}_24"),

            new TestCaseData(
                    ObjectMother.Shared_JobPage02_JobPosting05,
                    ObjectMother.Shared_JobPage02_JobPostingExtended05_Content,
                    ObjectMother.Shared_JobPage02_JobPostingExtended05
                ).SetArgDisplayNames($"{nameof(jobPostingExtendedDeserializerTestCases)}_25"),

            new TestCaseData(
                    ObjectMother.Shared_JobPage02_JobPosting06,
                    ObjectMother.Shared_JobPage02_JobPostingExtended06_Content,
                    ObjectMother.Shared_JobPage02_JobPostingExtended06
                ).SetArgDisplayNames($"{nameof(jobPostingExtendedDeserializerTestCases)}_26"),

            new TestCaseData(
                    ObjectMother.Shared_JobPage02_JobPosting07,
                    ObjectMother.Shared_JobPage02_JobPostingExtended07_Content,
                    ObjectMother.Shared_JobPage02_JobPostingExtended07
                ).SetArgDisplayNames($"{nameof(jobPostingExtendedDeserializerTestCases)}_27"),

            new TestCaseData(
                    ObjectMother.Shared_JobPage02_JobPosting08,
                    ObjectMother.Shared_JobPage02_JobPostingExtended08_Content,
                    ObjectMother.Shared_JobPage02_JobPostingExtended08
                ).SetArgDisplayNames($"{nameof(jobPostingExtendedDeserializerTestCases)}_28"),

            new TestCaseData(
                    ObjectMother.Shared_JobPage02_JobPosting09,
                    ObjectMother.Shared_JobPage02_JobPostingExtended09_Content,
                    ObjectMother.Shared_JobPage02_JobPostingExtended09
                ).SetArgDisplayNames($"{nameof(jobPostingExtendedDeserializerTestCases)}_29"),

            new TestCaseData(
                    ObjectMother.Shared_JobPage02_JobPosting10,
                    ObjectMother.Shared_JobPage02_JobPostingExtended10_Content,
                    ObjectMother.Shared_JobPage02_JobPostingExtended10
                ).SetArgDisplayNames($"{nameof(jobPostingExtendedDeserializerTestCases)}_30"),

            new TestCaseData(
                    ObjectMother.Shared_JobPage02_JobPosting11,
                    ObjectMother.Shared_JobPage02_JobPostingExtended11_Content,
                    ObjectMother.Shared_JobPage02_JobPostingExtended11
                ).SetArgDisplayNames($"{nameof(jobPostingExtendedDeserializerTestCases)}_31"),

            new TestCaseData(
                    ObjectMother.Shared_JobPage02_JobPosting12,
                    ObjectMother.Shared_JobPage02_JobPostingExtended12_Content,
                    ObjectMother.Shared_JobPage02_JobPostingExtended12
                ).SetArgDisplayNames($"{nameof(jobPostingExtendedDeserializerTestCases)}_32"),

            new TestCaseData(
                    ObjectMother.Shared_JobPage02_JobPosting13,
                    ObjectMother.Shared_JobPage02_JobPostingExtended13_Content,
                    ObjectMother.Shared_JobPage02_JobPostingExtended13
                ).SetArgDisplayNames($"{nameof(jobPostingExtendedDeserializerTestCases)}_33"),

            new TestCaseData(
                    ObjectMother.Shared_JobPage02_JobPosting14,
                    ObjectMother.Shared_JobPage02_JobPostingExtended14_Content,
                    ObjectMother.Shared_JobPage02_JobPostingExtended14
                ).SetArgDisplayNames($"{nameof(jobPostingExtendedDeserializerTestCases)}_34"),

            new TestCaseData(
                    ObjectMother.Shared_JobPage02_JobPosting15,
                    ObjectMother.Shared_JobPage02_JobPostingExtended15_Content,
                    ObjectMother.Shared_JobPage02_JobPostingExtended15
                ).SetArgDisplayNames($"{nameof(jobPostingExtendedDeserializerTestCases)}_35"),

            new TestCaseData(
                    ObjectMother.Shared_JobPage02_JobPosting16,
                    ObjectMother.Shared_JobPage02_JobPostingExtended16_Content,
                    ObjectMother.Shared_JobPage02_JobPostingExtended16
                ).SetArgDisplayNames($"{nameof(jobPostingExtendedDeserializerTestCases)}_36"),

            new TestCaseData(
                    ObjectMother.Shared_JobPage02_JobPosting17,
                    ObjectMother.Shared_JobPage02_JobPostingExtended17_Content,
                    ObjectMother.Shared_JobPage02_JobPostingExtended17
                ).SetArgDisplayNames($"{nameof(jobPostingExtendedDeserializerTestCases)}_37"),

            new TestCaseData(
                    ObjectMother.Shared_JobPage02_JobPosting18,
                    ObjectMother.Shared_JobPage02_JobPostingExtended18_Content,
                    ObjectMother.Shared_JobPage02_JobPostingExtended18
                ).SetArgDisplayNames($"{nameof(jobPostingExtendedDeserializerTestCases)}_38"),

            new TestCaseData(
                    ObjectMother.Shared_JobPage02_JobPosting19,
                    ObjectMother.Shared_JobPage02_JobPostingExtended19_Content,
                    ObjectMother.Shared_JobPage02_JobPostingExtended19
                ).SetArgDisplayNames($"{nameof(jobPostingExtendedDeserializerTestCases)}_39"),

            new TestCaseData(
                    ObjectMother.Shared_JobPage02_JobPosting20,
                    ObjectMother.Shared_JobPage02_JobPostingExtended20_Content,
                    ObjectMother.Shared_JobPage02_JobPostingExtended20
                ).SetArgDisplayNames($"{nameof(jobPostingExtendedDeserializerTestCases)}_40"),

        };
        private static TestCaseData[] doExceptionTestCases =
        {

            new TestCaseData(
                new TestDelegate(
                    () => new JobPostingExtendedDeserializer()
                            .Do(null, ObjectMother.Shared_JobPage01_JobPostingExtended01_Content)
                ),
                typeof(ArgumentNullException),
                new ArgumentNullException("jobPosting").Message
            ).SetArgDisplayNames($"{nameof(doExceptionTestCases)}_01"),

            new TestCaseData(
                new TestDelegate(
                    () => new JobPostingExtendedDeserializer()
                            .Do(ObjectMother.Shared_JobPage01_JobPosting01, null)
                ),
                typeof(ArgumentNullException),
                new ArgumentNullException("response").Message
            ).SetArgDisplayNames($"{nameof(doExceptionTestCases)}_02")

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
            bool predictBulletPointType = false;
            JobPostingExtendedDeserializer jobPostingExtendedDeserializer 
                = new JobPostingExtendedDeserializer(
                        xpathManager: JobPostingExtendedDeserializer.DefaultXPathManager, 
                        classificationManager: JobPostingExtendedDeserializer.DefaultClassificationManager,
                        predictBulletPointType: predictBulletPointType);

            bool compareJobPostingLanguage = true;
            bool ignorePurposeResponse = true;

            // Act
            JobPostingExtended actual = jobPostingExtendedDeserializer.Do(jobPosting, response);

            // Assert
            Assert.IsTrue(
                    ObjectMother.AreEqual(expected, actual, compareJobPostingLanguage, ignorePurposeResponse, predictBulletPointType)
                );

        }

        [TestCaseSource(nameof(doExceptionTestCases))]
        public void Do_ShouldThrowACertainException_WhenUnproperArguments
            (TestDelegate del, Type expectedType, string expectedMessage)
                => ObjectMother.Method_ShouldThrowACertainException_WhenUnproperArguments(del, expectedType, expectedMessage);

        [Test]
        public void Do_ShouldReturnAnEmptyJobPostingExtendedObject_WhenUnproperResponse()
        {

            // Arrange
            string unproperResponse = "{ }";
            JobPostingExtended expected
                    = new JobPostingExtended(
                            jobPosting: ObjectMother.Shared_JobPage01_JobPosting01,
                            response: unproperResponse,
                            hiringOrgDescription: null,
                            publicationStartDate: null,
                            publicationEndDate: null,
                            purpose: null,
                            numberToFill: null,
                            contactEmail: null,
                            contactPersonName: null,
                            employmentDate: null,
                            applicationDeadlineDate: null,
                            bulletPoints: null,
                            bulletPointScenario: null
                        );

            bool predictBulletPointType = false;
            JobPostingExtendedDeserializer jobPostingExtendedDeserializer
                = new JobPostingExtendedDeserializer(
                        xpathManager: JobPostingExtendedDeserializer.DefaultXPathManager,
                        classificationManager: JobPostingExtendedDeserializer.DefaultClassificationManager,
                        predictBulletPointType: predictBulletPointType);

            bool compareJobPostingLanguage = true;
            bool ignorePurposeResponse = true;

            // Act
            JobPostingExtended actual
                    = jobPostingExtendedDeserializer.Do(ObjectMother.Shared_JobPage01_JobPosting01, unproperResponse);

            // Assert
            Assert.IsTrue(
                    ObjectMother.AreEqual(expected, actual, compareJobPostingLanguage, ignorePurposeResponse, predictBulletPointType)
                );

        }

        #endregion

        #region TearDown

        #endregion

    }
}

/*
    Author: numbworks@gmail.com
    Last Update: 27.09.2021
*/