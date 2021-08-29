using NUnit.Framework;
using NW.WIDJobsClient.CommandLineValidators;

namespace NW.WIDJobsClient.UnitTests
{
    [TestFixture]
    public class ThresholdValueManagerTests
    {

        #region Fields

        #endregion

        #region SetUp

        #endregion

        #region Tests

        [TestCase("1", true)]
        [TestCase("2", true)]
        [TestCase("20200722", true)]
        [TestCase("20210523", true)]
        [TestCase("5332213linuxspecialist", true)]
        [TestCase("5365786motivatedforkliftdriversfortemporary", true)]
        [TestCase("5372675selvstndigetruckfreretil", true)]
        [TestCase("5379659erfarenogselvstndigtruckf", true)]
        [TestCase("5376524visgerrengringsassistenter", true)]
        [TestCase("5303321motivatedemployeesforwarehousework", true)]
        [TestCase("5290988motivatedemployeesforwarehousework", true)]
        [TestCase("5383229vicepresidentofproductmarketing", true)]
        [TestCase("5331002friskeogoplagtemedarbejderetil", true)]
        [TestCase("5383212tenuretrackassistantprofessorin", true)]
        [TestCase("5361275committedemployeesforassemblingdisplays", true)]
        [TestCase("5359775wearelookingforforklift", true)]
        [TestCase("5383201laboratorytechnicianforplantanalysis", true)]
        [TestCase("5383195laboratorytechnicianforfoodprocessing", true)]
        [TestCase("5383165lagermedarbejderetilpakkeopgaverpdaghold", true)]
        [TestCase("5346333motivatedemployeeforemptyingcontainers", true)]
        [TestCase("5376709medarbejderetilsommervikariaterp", true)]
        [TestCase("5382809tenuretrackassistantprofessorshipsin", true)]
        [TestCase("5382781warehouseemployee", true)]
        [TestCase("5382486postdocondigitalplatformsand", true)]
        [TestCase("0", false)]
        [TestCase("2020-07-22", false)]
        [TestCase("2021.05.23", false)]
        [TestCase("somegarbage", false)]
        [TestCase(null, false)]
        public void IsValid_ShouldReturnExpectedBoolean_WhenInvoked(string value, bool expected)
        {

            // Arrange
            // Act
            bool actual = new ThresholdValueManager().IsValid(value);

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
