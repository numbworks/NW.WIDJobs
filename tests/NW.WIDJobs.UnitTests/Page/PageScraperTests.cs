using System;
using NUnit.Framework;

namespace NW.WIDJobs.UnitTests
{
    [TestFixture]
    public class PageScraperTests
    {

        // Fields
        private static TestCaseData[] pageScraperExceptionTestCases =
        {

            new TestCaseData(
                new TestDelegate(
                    () => new PageScraper().GetTotalResults(null)
                ),
                typeof(ArgumentNullException),
                new ArgumentNullException("content").Message
            ).SetArgDisplayNames($"{nameof(pageScraperExceptionTestCases)}_01")

        };

        // SetUp
        // Tests
        [TestCaseSource(nameof(pageScraperExceptionTestCases))]
        public void PageScraper_ShouldThrowACertainException_WhenUnproperArguments
            (TestDelegate del, Type expectedType, string expectedMessage)
                => ObjectMother.Method_ShouldThrowACertainException_WhenUnproperArguments(del, expectedType, expectedMessage);

        [Test]
        public void PageScraper_ShouldReturnExpectedTotalResults_WhenProperArguments()
        {

            // Arrange
            // Act
            uint actual = new PageScraper().GetTotalResults(ObjectMother.Shared_Page01_Content);

            // Assert
            Assert.AreEqual(
                    ObjectMother.Shared_Page01_TotalResults,
                    actual
                );

        }

        // TearDown		

    }
}

/*
    Author: numbworks@gmail.com
    Last Update: 13.05.2021
*/