using NUnit.Framework;
using System;

namespace NW.WIDJobs.UnitTests
{
    [TestFixture]
    public class JobPageDeserializerTests
    {

        #region Fields

        private static TestCaseData[] getTotalJobPostingsTestCases =
        {

            new TestCaseData(
                    ObjectMother.Shared_JobPage01_Content,
                    ObjectMother.Shared_JobPage01_TotalResultCount
                ).SetArgDisplayNames($"{nameof(getTotalJobPostingsTestCases)}_01"),

            new TestCaseData(
                    ObjectMother.Shared_JobPage02_Content,
                    ObjectMother.Shared_JobPage02_TotalResultCount
                ).SetArgDisplayNames($"{nameof(getTotalJobPostingsTestCases)}_02")

        };
        private static TestCaseData[] getTotalJobPostingsExceptionTestCases =
        {

            new TestCaseData(
                new TestDelegate(
                    () => new JobPageDeserializer().GetTotalResultCount(null)
				),
                typeof(ArgumentNullException),
                new ArgumentNullException("response").Message
            ).SetArgDisplayNames($"{nameof(getTotalJobPostingsExceptionTestCases)}_01")

        };

        #endregion

        #region SetUp

        #endregion

        #region Tests

        [TestCaseSource(nameof(getTotalJobPostingsTestCases))]
        public void GetTotalJobPostings_ShouldReturnTotalResultCount_WhenProperArguments
            (string response, ushort expected)
        {

            // Arrange
            // Act
            ushort actual = new JobPageDeserializer().GetTotalResultCount(response);

            // Assert
            Assert.AreEqual(expected, actual);

        }

        [TestCaseSource(nameof(getTotalJobPostingsExceptionTestCases))]
        public void GetTotalJobPostings_ShouldThrowACertainException_WhenUnproperArguments
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
