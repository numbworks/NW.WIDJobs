using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace NW.WIDJobs.UnitTests
{
    [TestFixture]
    public class PageTests
    {

        // Fields
        private static TestCaseData[] arrTestCases =
        {

            new TestCaseData(
                    new Page() {
                        Url = "https://www.workindenmark.dk/Search/Job-search?q=",
                        PageNumber = 1,
                        Items = new List<PageItem>() {
                                    new PageItem() {
                                        Title = "Logistics Specialist",
                                        Url = "https://www.workindenmark.dk/job/6765129/Logistics-Specialist",
                                        JobId = "6765129Logistics-Specialist",
                                        WorkArea = "Kolding"
                                    },
                                    new PageItem() {
                                        Title = "Project Manager",
                                        Url = "https://www.workindenmark.dk/job/6765122/Project-Manager",
                                        JobId = "6765122Project-Manager",
                                        WorkArea = "Vejle"
                                    }
                                },
                        IsLastForCurrentExploration = false,
                        IsLastOnWebsite = false
                    },
                    String.Format("{{ {0}: '{1}', {2}: '{3}', {4}: '{5}', {6}: '{7}', {8}: '{9}' }}",
                        "AbsoluteUrl",
                        "https://www.workindenmark.dk/Search/Job-search?q=",
                        "PageNumber",
                        "1",
                        "Items",
                        "2",
                        "IsLastForCurrentExploration",
                        "False",
                        "IsLastOnWebsite",
                        "False"
                    )
                ).SetName(nameof(ToString_ShouldReturnExpectedString_WhenInvoked) + " {01}"),
            new TestCaseData(
                    new Page() {
                        Url = "https://www.workindenmark.dk/Search/Job-search?q=",
                        PageNumber = 1,
                        Items = new List<PageItem>() { },
                        IsLastForCurrentExploration = false,
                        IsLastOnWebsite = false
                    },
                    String.Format("{{ {0}: '{1}', {2}: '{3}', {4}: '{5}', {6}: '{7}', {8}: '{9}' }}",
                        "AbsoluteUrl",
                        "https://www.workindenmark.dk/Search/Job-search?q=",
                        "PageNumber",
                        "1",
                        "Items",
                        "0",
                        "IsLastForCurrentExploration",
                        "False",
                        "IsLastOnWebsite",
                        "False"
                    )
                ).SetName(nameof(ToString_ShouldReturnExpectedString_WhenInvoked) + " {02}"),
            new TestCaseData(
                    new Page() {
                        Url = "https://www.workindenmark.dk/Search/Job-search?q=",
                        PageNumber = 1,
                        Items = null,
                        IsLastForCurrentExploration = false,
                        IsLastOnWebsite = false
                    },
                    String.Format("{{ {0}: '{1}', {2}: '{3}', {4}: '{5}', {6}: '{7}', {8}: '{9}' }}",
                        "AbsoluteUrl",
                        "https://www.workindenmark.dk/Search/Job-search?q=",
                        "PageNumber",
                        "1",
                        "Items",
                        "0",
                        "IsLastForCurrentExploration",
                        "False",
                        "IsLastOnWebsite",
                        "False"
                    )
                ).SetName(nameof(ToString_ShouldReturnExpectedString_WhenInvoked) + " {03}")

        };

        // SetUp
        // Tests
        [TestCaseSource(nameof(arrTestCases))]
        public void ToString_ShouldReturnExpectedString_WhenInvoked
            (Page objPage, string strExpected)
        {

            // Arrange
            // Act
            string strActual = objPage.ToString();

            // Assert
            Assert.AreEqual(strExpected, strActual);

        }

        // TearDown

    }
}

/*

    Author: numbworks@gmail.com
    Last Update: 22.09.2018

*/