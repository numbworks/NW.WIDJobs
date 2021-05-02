using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace NW.WebsiteExploration.UnitTests
{
    [TestFixture]
    public class ResultsExplorationTests
    {

        // Fields
        private static TestCaseData[] arrTestCases =
        {

            new TestCaseData(
                new ResultsExploration() {
                    TotalResults = 1200,
                    TotalPagesExpected = 60,
                    Pages = new List<ResultsPage>() {
                                new ResultsPage() {
                                    AbsoluteUrl = "https://www.workindenmark.dk/Search/Job-search?q=",
                                    PageNumber = 1,
                                    Items = new List<ResultsPageItem>() {
                                                new ResultsPageItem() {
                                                        Title = "Country Sales & Product Responsible",
                                                        AbsoluteUrl = "https://www.workindenmark.dk/job/6755865/COUNTRY-SALES-PRODUCT-RESPONSIBLE",
                                                        ItemId = "6755865COUNTRY-SALES-PRODUCT-RESPONSIBLE",
                                                        WorkArea = "Brande",
                                                        Employer = "Bestseller A/S",
                                                        Openings = 1,
                                                        AdvertisementPublishDate = new DateTime(2018, 08, 08),
                                                        ApplicationDeadline = new DateTime(2018, 08, 29),
                                                        EmploymentStartDate = "As soon as possible",
                                                        Description = "some description",
                                                        Position = "Management / Sales and marketing managers",
                                                        EmploymentType = "Regular position",
                                                        WeeklyWorkingHours = "Full time (37 hours)",
                                                        Contact = "Apply online",
                                                        HowToApply = "Online:\nApplication form<http://about.bestseller.com/jobs/job-search/country-sales-product-responsible-153696>",
                                                        EmployerAddress = "BESTSELLER A/S\nFredskovvej 5\nDK 7330 Brande\nDenmark"
                                                        }
                                            },
                                    IsLastForCurrentExploration = true,
                                    IsLastOnWebsite = true
                                }
                            }
                },
                new ResultsExploration() {
                    TotalResults = 1200,
                    TotalPagesExpected = 60,
                    Pages = new List<ResultsPage>() {
                                new ResultsPage() {
                                    AbsoluteUrl = "https://www.workindenmark.dk/Search/Job-search?q=",
                                    PageNumber = 1,
                                    Items = new List<ResultsPageItem>() {
                                                new ResultsPageItem() {
                                                        Title = "Country Sales & Product Responsible",
                                                        AbsoluteUrl = "https://www.workindenmark.dk/job/6755865/COUNTRY-SALES-PRODUCT-RESPONSIBLE",
                                                        ItemId = "6755865COUNTRY-SALES-PRODUCT-RESPONSIBLE",
                                                        WorkArea = "Brande",
                                                        Employer = "Bestseller A/S",
                                                        Openings = 1,
                                                        AdvertisementPublishDate = new DateTime(2018, 08, 08),
                                                        ApplicationDeadline = new DateTime(2018, 08, 29),
                                                        EmploymentStartDate = "As soon as possible",
                                                        Description = "some description",
                                                        Position = "Management / Sales and marketing managers",
                                                        EmploymentType = "Regular position",
                                                        WeeklyWorkingHours = "Full time (37 hours)",
                                                        Contact = "Apply online",
                                                        HowToApply = "Online:\nApplication form<http://about.bestseller.com/jobs/job-search/country-sales-product-responsible-153696>",
                                                        EmployerAddress = "BESTSELLER A/S\nFredskovvej 5\nDK 7330 Brande\nDenmark"
                                                        }
                                            },
                                    IsLastForCurrentExploration = true,
                                    IsLastOnWebsite = true
                                }
                            }
                }
           ).SetName(nameof(ResultsExploration_ShouldCreateACopy_WhenProperObjectIsProvided) + " {01}"),
            new TestCaseData(
                new ResultsExploration(),
                new ResultsExploration()
           ).SetName(nameof(ResultsExploration_ShouldCreateACopy_WhenProperObjectIsProvided) + " {02}"),
            new TestCaseData(
                null,
                new ResultsExploration()
           ).SetName(nameof(ResultsExploration_ShouldCreateACopy_WhenProperObjectIsProvided) + " {03}"),

        };

        // SetUp
        // Tests
        [TestCaseSource(nameof(arrTestCases))]
        public void ResultsExploration_ShouldCreateACopy_WhenProperObjectIsProvided
            (ResultsExploration objExploration, ResultsExploration objExpected)
        {

            // Arrange
            // Act
            ResultsExploration objActual = new ResultsExploration(objExploration);

            // Assert
            Assert.AreEqual(objExpected.TotalResults, objActual.TotalResults);
            Assert.AreEqual(objExpected.TotalPagesExpected, objActual.TotalPagesExpected);

            if (objExpected.Pages != null)
                for (int i = 0; i < objExpected.Pages.Count; i++)
                {

                    Assert.AreEqual(objExpected.Pages[i].AbsoluteUrl, objActual.Pages[i].AbsoluteUrl);
                    Assert.AreEqual(objExpected.Pages[i].PageNumber, objActual.Pages[i].PageNumber);
                    Assert.AreEqual(objExpected.Pages[i].IsLastForCurrentExploration, objActual.Pages[i].IsLastForCurrentExploration);
                    Assert.AreEqual(objExpected.Pages[i].IsLastOnWebsite, objActual.Pages[i].IsLastOnWebsite);

                    if (objExpected.Pages[i].Items != null)
                        for (int j = 0; j < objExpected.Pages[i].Items.Count; j++)
                        {

                            Assert.AreEqual(objExpected.Pages[i].Items[j].AbsoluteUrl, objActual.Pages[i].Items[j].AbsoluteUrl);
                            Assert.AreEqual(objExpected.Pages[i].Items[j].AdvertisementPublishDate, objActual.Pages[i].Items[j].AdvertisementPublishDate);
                            Assert.AreEqual(objExpected.Pages[i].Items[j].ApplicationDeadline, objActual.Pages[i].Items[j].ApplicationDeadline);
                            Assert.AreEqual(objExpected.Pages[i].Items[j].Contact, objActual.Pages[i].Items[j].Contact);
                            Assert.AreEqual(objExpected.Pages[i].Items[j].Description, objActual.Pages[i].Items[j].Description);
                            Assert.AreEqual(objExpected.Pages[i].Items[j].Employer, objActual.Pages[i].Items[j].Employer);
                            Assert.AreEqual(objExpected.Pages[i].Items[j].EmployerAddress, objActual.Pages[i].Items[j].EmployerAddress);
                            Assert.AreEqual(objExpected.Pages[i].Items[j].EmploymentStartDate, objActual.Pages[i].Items[j].EmploymentStartDate);
                            Assert.AreEqual(objExpected.Pages[i].Items[j].EmploymentType, objActual.Pages[i].Items[j].EmploymentType);
                            Assert.AreEqual(objExpected.Pages[i].Items[j].HowToApply, objActual.Pages[i].Items[j].HowToApply);
                            Assert.AreEqual(objExpected.Pages[i].Items[j].ItemId, objActual.Pages[i].Items[j].ItemId);
                            Assert.AreEqual(objExpected.Pages[i].Items[j].Openings, objActual.Pages[i].Items[j].Openings);
                            Assert.AreEqual(objExpected.Pages[i].Items[j].Position, objActual.Pages[i].Items[j].Position);
                            Assert.AreEqual(objExpected.Pages[i].Items[j].Title, objActual.Pages[i].Items[j].Title);
                            Assert.AreEqual(objExpected.Pages[i].Items[j].WeeklyWorkingHours, objActual.Pages[i].Items[j].WeeklyWorkingHours);
                            Assert.AreEqual(objExpected.Pages[i].Items[j].WorkArea, objActual.Pages[i].Items[j].WorkArea);

                        }

                }

        }

        // TearDown

    }
}

/*

    Author: numbworks@gmail.com
    Last Update: 22.09.2018

*/