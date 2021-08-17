using NUnit.Framework;
using System;
using NW.WIDJobs.HttpRequests;

namespace NW.WIDJobs.UnitTests
{
    [TestFixture]
    public class GetRequestManagerTests
    {

        // Fields
        private static TestCaseData[] getRequestManagerExceptionTestCases =
        {

            new TestCaseData(
                new TestDelegate(
                    () => new GetRequestManager(null, null, null, null, null, null)
                ),
                typeof(ArgumentNullException),
                new ArgumentNullException("httpWebRequestFactory").Message
            ).SetArgDisplayNames($"{nameof(getRequestManagerExceptionTestCases)}_01")

        };
        private static TestCaseData[] sendExceptionTestCases =
        {

            new TestCaseData(
                new TestDelegate(
                    () => new GetRequestManager().Send(null)
                ),
                typeof(ArgumentNullException),
                new ArgumentNullException("url").Message
            ).SetArgDisplayNames($"{nameof(sendExceptionTestCases)}_01")

        };

        // SetUp
        // Tests
        [TestCaseSource(nameof(getRequestManagerExceptionTestCases))]
        public void GetRequestManager_ShouldThrowACertainException_WhenUnproperArguments
            (TestDelegate del, Type expectedType, string expectedMessage)
                => ObjectMother.Method_ShouldThrowACertainException_WhenUnproperArguments(del, expectedType, expectedMessage);

        [TestCaseSource(nameof(sendExceptionTestCases))]
        public void Send_ShouldThrowACertainException_WhenUnproperArguments
            (TestDelegate del, Type expectedType, string expectedMessage)
                => ObjectMother.Method_ShouldThrowACertainException_WhenUnproperArguments(del, expectedType, expectedMessage);

        // TearDown		

    }
}

/*
    Author: numbworks@gmail.com
    Last Update: 15.05.2021
*/
