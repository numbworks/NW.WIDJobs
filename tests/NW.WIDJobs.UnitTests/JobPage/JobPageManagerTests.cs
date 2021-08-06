using NUnit.Framework;
using System;

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
            ).SetArgDisplayNames($"{nameof(sendPostRequestExceptionTestCases)}_01")

        };
        private static TestCaseData[] getJobPageTestCases =
        {

            new TestCaseData(
                    ObjectMother.Shared_JobPage01_Content,
                    ObjectMother.Shared_FakeRunId,
                    (ushort)1,
                    new JobPage(ObjectMother.Shared_FakeRunId, (ushort)1, ObjectMother.Shared_JobPage01_Content),
                    JobPageManager.UrlTemplate.Invoke((ushort)0)
                ).SetArgDisplayNames($"{nameof(getJobPageTestCases)}_01"),

            new TestCaseData(
                    ObjectMother.Shared_JobPage02_Content,
                    ObjectMother.Shared_FakeRunId,
                    (ushort)2,
                    new JobPage(ObjectMother.Shared_FakeRunId, (ushort)2, ObjectMother.Shared_JobPage02_Content),
                    JobPageManager.UrlTemplate.Invoke((ushort)20)
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
            (string fakeResponse, string runId, ushort pageNumber, JobPage expectedJobPage, string expectedUrl)
        {

            // Arrange
            FakePostRequestManager fakePostRequestManager = new FakePostRequestManager(fakeResponse);
            FakePostRequestManagerFactory fakePostRequestManagerFactory = new FakePostRequestManagerFactory(fakePostRequestManager);

            // Act
            JobPage actualJobPage = new JobPageManager(fakePostRequestManagerFactory).GetJobPage(runId, pageNumber);

            // Assert
            Assert.IsTrue(
                ObjectMother.AreEqual(expectedJobPage, actualJobPage)
                );
            Assert.AreEqual(expectedUrl, fakePostRequestManager.Url);

        }

        #endregion

        #region TearDown

        #endregion

    }
}

/*
    Author: numbworks@gmail.com
    Last Update: 06.08.2021
*/