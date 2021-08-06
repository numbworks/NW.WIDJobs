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

        private static TestCaseData[] someMethodTestCases =
        {

            new TestCaseData(
                    "Some message",
                    false
                ).SetArgDisplayNames($"{nameof(someMethodTestCases)}_01")

        };
        private static TestCaseData[] someMethodExceptionTestCases =
        {

            new TestCaseData(
                new TestDelegate(
                    () => Console.WriteLine("Some message") // Replace method call.
				),
                typeof(ArgumentNullException),
                new ArgumentNullException("null_argument_name").Message
            ).SetArgDisplayNames($"{nameof(someMethodExceptionTestCases)}_01")

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

        [TestCaseSource(nameof(someMethodTestCases))]
        public void SomeMethod_Should_When
            (string message, bool expected)
        {

            // Arrange
            // Act
            // Assert

        }
        [TestCaseSource(nameof(someMethodExceptionTestCases))]
        public void SomeMethod_ShouldThrowACertainException_WhenUnproperArguments
            (TestDelegate del, Type expectedType, string expectedMessage)
                => ObjectMother.Method_ShouldThrowACertainException_WhenUnproperArguments(del, expectedType, expectedMessage);

        #endregion

        #region TearDown

        #endregion

    }
}

/*
    Author: numbworks@gmail.com
    Last Update: 06.08.2021
*/