using NUnit.Framework;
using System;
using System.Collections.Generic;
using NW.WIDJobs.JobPages;
using NW.WIDJobs.JobPostings;
using NW.WIDJobs.Classification;

namespace NW.WIDJobs.UnitTests
{
    [TestFixture]
    public class JobPostingDeserializerTests
    {

        #region Fields

        private static TestCaseData[] doExceptionTestCases =
        {

            new TestCaseData(
                new TestDelegate(
                    () => new JobPostingDeserializer().Do(null)
                ),
                typeof(ArgumentNullException),
                new ArgumentNullException("jobPage").Message
            ).SetArgDisplayNames($"{nameof(doExceptionTestCases)}_01"),

            new TestCaseData(
                new TestDelegate(
                    () => new JobPostingDeserializer().Do(ObjectMother.Shared_JobPage01WithEmptyResponse_Object)
                ),
                typeof(KeyNotFoundException),
                "The given key was not present in the dictionary."
            ).SetArgDisplayNames($"{nameof(doExceptionTestCases)}_02")

        };
        private static TestCaseData[] doTestCases =
        {

            new TestCaseData(
                    ObjectMother.Shared_JobPage01_Object,
                    false,
                    true,
                    ObjectMother.Shared_JobPage01_JobPostings
                ).SetArgDisplayNames($"{nameof(doTestCases)}_01"),

            new TestCaseData(
                    ObjectMother.Shared_JobPage02_Object,
                    false,
                    false,
                    ObjectMother.Shared_JobPage02_JobPostings
                ).SetArgDisplayNames($"{nameof(doTestCases)}_02"),

            new TestCaseData(
                    ObjectMother.Shared_JobPage01_Object,
                    true,
                    false,
                    ObjectMother.TranslateOccupations(
                        ObjectMother.Shared_JobPage01_JobPostings
                    )
                ).SetArgDisplayNames($"{nameof(doTestCases)}_03")

        };
        private static TestCaseData[] jobPostingDeserializerExceptionTestCases =
        {

            new TestCaseData(
                new TestDelegate(
                    () => new JobPostingDeserializer(
                                    occupationTranslator: null,
                                    classificationManager: new ClassificationManager(),
                                    JobPostingDeserializer.DefaultTranslateJobPostingOccupation,
                                    JobPostingDeserializer.DefaultPredictJobPostingLanguage
                                )
                ),
                typeof(ArgumentNullException),
                new ArgumentNullException("occupationTranslator").Message
            ).SetArgDisplayNames($"{nameof(jobPostingDeserializerExceptionTestCases)}_01"),

            new TestCaseData(
                new TestDelegate(
                    () => new JobPostingDeserializer(
                                    occupationTranslator: new OccupationTranslator(),
                                    classificationManager: null,
                                    translateJobPostingOccupation: JobPostingDeserializer.DefaultTranslateJobPostingOccupation,
                                    predictJobPostingLanguage: JobPostingDeserializer.DefaultPredictJobPostingLanguage
                                )
                ),
                typeof(ArgumentNullException),
                new ArgumentNullException("classificationManager").Message
            ).SetArgDisplayNames($"{nameof(jobPostingDeserializerExceptionTestCases)}_02"),

        };

        #endregion

        #region SetUp

        #endregion

        #region Tests

        [TestCaseSource(nameof(doExceptionTestCases))]
        public void Do_ShouldThrowACertainException_WhenUnproperArguments
            (TestDelegate del, Type expectedType, string expectedMessage)
                => ObjectMother.Method_ShouldThrowACertainException_WhenUnproperArguments(del, expectedType, expectedMessage);

        [TestCaseSource(nameof(doTestCases))]
        public void Do_ShouldReturnAListofJobPostingObjects_WhenProperArguments
            (JobPage jobPage, bool translateJobPostingOccupation, bool predictJobPostingLanguage, List <JobPosting> expected)
        {

            // Arrange
            bool compareJobPostingLanguage = predictJobPostingLanguage; // If we predict it, we compare it.
            JobPostingDeserializer jobPostingDeserializer 
                = new JobPostingDeserializer(
                        occupationTranslator: new OccupationTranslator(),
                        classificationManager: new ClassificationManager(),
                        translateJobPostingOccupation: translateJobPostingOccupation,
                        predictJobPostingLanguage: predictJobPostingLanguage
                    );

            // Act
            List<JobPosting> actual = jobPostingDeserializer.Do(jobPage);

            // Assert
            Assert.IsTrue(
                    ObjectMother.AreEqual(expected, actual, compareJobPostingLanguage)
                );

        }

        [TestCaseSource(nameof(jobPostingDeserializerExceptionTestCases))]
        public void JobPostingDeserializero_ShouldThrowACertainException_WhenUnproperArguments
            (TestDelegate del, Type expectedType, string expectedMessage)
                => ObjectMother.Method_ShouldThrowACertainException_WhenUnproperArguments(del, expectedType, expectedMessage);

        #endregion

        #region TearDown

        #endregion

    }
}

/*
    Author: numbworks@gmail.com
    Last Update: 15.09.2021
*/
