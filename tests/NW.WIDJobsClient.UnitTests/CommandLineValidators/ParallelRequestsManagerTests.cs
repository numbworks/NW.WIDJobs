using NUnit.Framework;
using NW.WIDJobsClient.CommandLineValidators;

namespace NW.WIDJobsClient.UnitTests
{
    [TestFixture]
    public class ParallelRequestsManagerTests
    {

        #region Fields

        #endregion

        #region SetUp

        #endregion

        #region Tests

        [TestCase("1", true)]
        [TestCase("3", true)]
        [TestCase("65535", true)]
        [TestCase("0", false)]
        [TestCase("100000", false)]
        [TestCase("somegarbage", false)]
        [TestCase(null, false)]
        public void IsWithinRange_ShouldReturnExpectedBoolean_WhenInvoked(string value, bool expected)
        {

            // Arrange
            // Act
            bool actual = new ParallelRequestsManager().IsWithinRange(value);

            // Assert
            Assert.AreEqual(expected, actual);

        }

        #endregion

        #region TearDown

        #endregion

        #region Support_methods

        #endregion

    }
}

/*
    Author: numbworks@gmail.com
    Last Update: 29.08.2021
*/
