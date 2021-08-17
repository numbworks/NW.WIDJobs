using NUnit.Framework;
using System;
using NW.WIDJobs.JobPages;

namespace NW.WIDJobs.UnitTests
{
    [TestFixture]
    public class JobPageTests
    {

        #region Fields

        private static TestCaseData[] jobPageExceptionTestCases =
        {

            new TestCaseData(
                new TestDelegate(
                    () => new JobPage(null, 1, ObjectMother.Shared_JobPage01_Content)
                ),
                typeof(ArgumentNullException),
                new ArgumentNullException("runId").Message
            ).SetArgDisplayNames($"{nameof(jobPageExceptionTestCases)}_01"),

            new TestCaseData(
                new TestDelegate(
                        () => new JobPage(ObjectMother.Shared_FakeRunId, 0, ObjectMother.Shared_JobPage01_Content)
                    ),
                typeof(ArgumentException),
                MessageCollection.Validator_VariableCantBeLessThanOne.Invoke("pageNumber")
            ).SetArgDisplayNames($"{nameof(jobPageExceptionTestCases)}_02"),

            new TestCaseData(
                new TestDelegate(
                    () => new JobPage(ObjectMother.Shared_FakeRunId, 1, null)
                ),
                typeof(ArgumentNullException),
                new ArgumentNullException("response").Message
            ).SetArgDisplayNames($"{nameof(jobPageExceptionTestCases)}_03"),

        };

        #endregion

        #region SetUp

        #endregion

        #region Tests

        [TestCaseSource(nameof(jobPageExceptionTestCases))]
        public void JobPage_ShouldThrowACertainException_WhenUnproperArguments
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