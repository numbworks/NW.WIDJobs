using NUnit.Framework;
using NW.WIDJobs.JobPostings;

namespace NW.WIDJobs.UnitTests
{
    [TestFixture]
    public class OccupationTranslatorTests
    {

        #region Fields

        #endregion

        #region SetUp

        #endregion

        #region Tests

        [TestCase(null, null)]
        [TestCase("Something you can't translate", "Something you can't translate")]
        [TestCase("Kok", "Chef")]
        public void Translate_ShouldReturnExpectedTranslation_WhenInvoked(string occupation, string expected)
        {

            // Arrange
            // Act
            string actual = new OccupationTranslator().Translate(occupation);

            // Assert
            Assert.AreEqual(expected, actual);

        }

        #endregion

        #region TearDown

        #endregion

    }
}

/*
    Author: numbworks@gmail.com
    Last Update: 09.09.2021
*/
