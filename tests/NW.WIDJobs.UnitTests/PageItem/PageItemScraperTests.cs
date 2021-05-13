using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace NW.WIDJobs.UnitTests
{
    [TestFixture]
    public class PageItemScraperTests
    {

        // Fields
        private static TestCaseData[] doTestCases =
        {

            new TestCaseData(
                    ObjectMother.Shared_Page01,
                    ObjectMother.Shared_Page01_PageItems
                ).SetArgDisplayNames($"{nameof(doTestCases)}_01"),


            new TestCaseData(
                    ObjectMother.Shared_Page02,
                    ObjectMother.Shared_Page02_PageItems
                ).SetArgDisplayNames($"{nameof(doTestCases)}_02")

        };
        private static TestCaseData[] doExceptionTestCases =
        {

            new TestCaseData(
                new TestDelegate(
                    () => new PageItemScraper().Do(null)
                ),
                typeof(ArgumentNullException),
                new ArgumentNullException("page").Message
            ).SetArgDisplayNames($"{nameof(doExceptionTestCases)}_01")

        };

        // SetUp
        // Tests
        [TestCaseSource(nameof(doTestCases))]
        public void Do_ShouldReturnExpectedPageItems_WhenProperArguments
            (Page page, List<PageItem> expected)
        {

            // Arrange
            // Act
            List<PageItem> actual = new PageItemScraper().Do(page);

            // Assert
            Assert.IsTrue(
                    ObjectMother.AreEqual(expected, actual)
                );

        }
        [TestCaseSource(nameof(doExceptionTestCases))]
        public void Do_ShouldThrowACertainException_WhenUnproperArguments
            (TestDelegate del, Type expectedType, string expectedMessage)
                => ObjectMother.Method_ShouldThrowACertainException_WhenUnproperArguments(del, expectedType, expectedMessage);

        // TearDown		

    }
}

/*
    Author: numbworks@gmail.com
    Last Update: 13.05.2021
*/
