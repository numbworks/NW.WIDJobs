using NUnit.Framework;
using NW.WIDJobsClient.CommandLineValidators;

namespace NW.WIDJobsClient.UnitTests
{
    [TestFixture]
    public class PauseBetweenRequestsManagerTests
    {

        #region Fields

        #endregion

        #region SetUp

        #endregion

        #region Tests

        [TestCase("1", true)]
        [TestCase("3", true)]
        [TestCase("65535", true)]
        [TestCase("100000", true)]
        [TestCase("0", true)]
        [TestCase("somegarbage", false)]
        [TestCase(null, false)]
        public void IsValid_ShouldReturnExpectedBoolean_WhenInvoked(string value, bool expected)
        {

            // Arrange
            // Act
            bool actual = new PauseBetweenRequestsManager().IsValid(value);

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
