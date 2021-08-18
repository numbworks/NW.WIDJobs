using NUnit.Framework;
using System;
using NW.WIDJobs.JobPages;
using NW.WIDJobs.Messages;
using System.Collections.Generic;

namespace NW.WIDJobs.UnitTests
{
    [TestFixture]
    public class JobPageManagerTests
    {

        #region Fields

        private static TestCaseData[] jobPageManagerExceptionTestCases =
        {

            new TestCaseData(
                new TestDelegate(
                    () => new JobPageManager(null)
                ),
                typeof(ArgumentNullException),
                new ArgumentNullException("postRequestManagerFactory").Message
            ).SetArgDisplayNames($"{nameof(jobPageManagerExceptionTestCases)}_01")

        };
        private static TestCaseData[] getJobPageExceptionTestCases =
        {

            new TestCaseData(
                new TestDelegate(
                    () => new JobPageManager().GetJobPage(null, 1)
                ),
                typeof(ArgumentNullException),
                new ArgumentNullException("runId").Message
            ).SetArgDisplayNames($"{nameof(getJobPageExceptionTestCases)}_01"),

            new TestCaseData(
                new TestDelegate(
                        () => new JobPageManager().GetJobPage(ObjectMother.Shared_FakeRunId, 0)
                    ),
                typeof(ArgumentException),
                MessageCollection.Validator_VariableCantBeLessThanOne.Invoke("pageNumber")
            ).SetArgDisplayNames($"{nameof(getJobPageExceptionTestCases)}_02")

        };
        private static TestCaseData[] createUrlExceptionTestCases =
        {

            new TestCaseData(
                new TestDelegate(
                        () => new JobPageManager().CreateUrl(0)
                    ),
                typeof(ArgumentException),
                MessageCollection.Validator_VariableCantBeLessThanOne.Invoke("pageNumber")
            ).SetArgDisplayNames($"{nameof(createUrlExceptionTestCases)}_01")

        };
        private static TestCaseData[] sendPostRequestExceptionTestCases =
        {

            new TestCaseData(
                new TestDelegate(
                    () => new JobPageManager().SendPostRequest(null)
                ),
                typeof(ArgumentNullException),
                new ArgumentNullException("url").Message
            ).SetArgDisplayNames($"{nameof(sendPostRequestExceptionTestCases)}_01"),

            new TestCaseData(
                new TestDelegate(
                    () => new JobPageManager().SendPostRequest("http://www.gooogle.com")
                ),
                typeof(Exception),
                MessageCollection.JobPageManager_NotPossibleExtractOffset.Invoke("http://www.gooogle.com")
            ).SetArgDisplayNames($"{nameof(sendPostRequestExceptionTestCases)}_02")

        };
        private static TestCaseData[] getJobPageTestCases =
        {

            new TestCaseData(
                JobPageManager.UrlTemplate.Invoke((ushort)0),
                    ObjectMother.Shared_JobPage01_Content,
                    ObjectMother.Shared_FakeRunId,
                    (ushort)1,
                    new JobPage(ObjectMother.Shared_FakeRunId, (ushort)1, ObjectMother.Shared_JobPage01_Content)          
                ).SetArgDisplayNames($"{nameof(getJobPageTestCases)}_01"),

            new TestCaseData(
                   JobPageManager.UrlTemplate.Invoke((ushort)20),
                    ObjectMother.Shared_JobPage02_Content,
                    ObjectMother.Shared_FakeRunId,
                    (ushort)2,
                    new JobPage(ObjectMother.Shared_FakeRunId, (ushort)2, ObjectMother.Shared_JobPage02_Content)
                ).SetArgDisplayNames($"{nameof(getJobPageTestCases)}_02")

        };

        #endregion

        #region SetUp

        #endregion

        #region Tests

        [TestCaseSource(nameof(jobPageManagerExceptionTestCases))]
        public void JobPageManager_ShouldThrowACertainException_WhenUnproperArguments
            (TestDelegate del, Type expectedType, string expectedMessage)
                => ObjectMother.Method_ShouldThrowACertainException_WhenUnproperArguments(del, expectedType, expectedMessage);

        [TestCaseSource(nameof(getJobPageExceptionTestCases))]
        public void GetJobPage_ShouldThrowACertainException_WhenUnproperArguments
            (TestDelegate del, Type expectedType, string expectedMessage)
                => ObjectMother.Method_ShouldThrowACertainException_WhenUnproperArguments(del, expectedType, expectedMessage);

        [TestCaseSource(nameof(createUrlExceptionTestCases))]
        public void CreateUrl_ShouldThrowACertainException_WhenUnproperArguments
            (TestDelegate del, Type expectedType, string expectedMessage)
                => ObjectMother.Method_ShouldThrowACertainException_WhenUnproperArguments(del, expectedType, expectedMessage);

        [TestCaseSource(nameof(sendPostRequestExceptionTestCases))]
        public void SendPostRequest_ShouldThrowACertainException_WhenUnproperArguments
            (TestDelegate del, Type expectedType, string expectedMessage)
                => ObjectMother.Method_ShouldThrowACertainException_WhenUnproperArguments(del, expectedType, expectedMessage);

        [TestCaseSource(nameof(getJobPageTestCases))]
        public void GetJobPage_ShouldReturnExpectedJobPage_WhenInvoked
            (string url, string response, string runId, ushort pageNumber, JobPage expectedJobPage)
        {

            // Arrange
            Dictionary<string, string> urlsResponses = new Dictionary<string, string>() 
            { 
                { url, response } 
            };
            FakePostRequestManager fakePostRequestManager = new FakePostRequestManager(urlsResponses);
            FakePostRequestManagerFactory fakePostRequestManagerFactory = new FakePostRequestManagerFactory(fakePostRequestManager);

            // Act
            JobPage actualJobPage = new JobPageManager(fakePostRequestManagerFactory).GetJobPage(runId, pageNumber);

            // Assert
            Assert.IsTrue(
                ObjectMother.AreEqual(expectedJobPage, actualJobPage)
                );

        }

        [TestCase((uint)0, (ushort)0)]
        [TestCase((uint)1, (ushort)1)]
        [TestCase((uint)1243, (ushort)63)]
        public void GetTotalPages_ShouldReturnExpectedTotalPages_WhenInvoked
            (uint totalJobPostings, ushort expected)
        {

            // Arrange
            // Act
            ushort actual = new JobPageManager().GetTotalJobPages(totalJobPostings);

            // Assert
            Assert.AreEqual(expected, actual);

        }

        [Test]
        public void JobPageManager_ShouldReturnExpectedValues_WhenStaticPropertiesAreInvoked()
        {

            // Arrange
            ushort expectedJobPostingsPerPage = 20;
            ushort offset = 20;
            string expectedUrlTemplate = $"https://job.jobnet.dk/CV/FindWork?Offset={offset}&SortValue=CreationDate&widk=true";
            string expectedOffsetPattern = "(?<=Offset=)[0-9]{1,}";

            // Act
            // Assert
            Assert.AreEqual(expectedJobPostingsPerPage, JobPageManager.JobPostingsPerPage);
            Assert.AreEqual(expectedUrlTemplate, JobPageManager.UrlTemplate.Invoke(offset));
            Assert.AreEqual(expectedOffsetPattern, JobPageManager.OffsetPattern);

        }

        #endregion

        #region TearDown

        #endregion

    }
}

/*
    Author: numbworks@gmail.com
    Last Update: 18.08.2021
*/