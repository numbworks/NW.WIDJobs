using System;
using NUnit.Framework;

namespace NW.WebsiteExploration.UnitTests
{
    [TestFixture]
    public class ResultsPageItemTests
    {

        // Fields
        private static TestCaseData[] arrCopy =
        {

            new TestCaseData(
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
                        },
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
                ).SetName(nameof(ResultsPageItem_ShouldCreateACopy_WhenProperObjectIsProvided) + " {01}"),
            new TestCaseData(
                null,
                new ResultsPageItem()
                ).SetName(nameof(ResultsPageItem_ShouldCreateACopy_WhenProperObjectIsProvided) + " {02}"),
            new TestCaseData(
                new ResultsPageItem(),
                new ResultsPageItem()
                ).SetName(nameof(ResultsPageItem_ShouldCreateACopy_WhenProperObjectIsProvided) + " {03}")

        };

        // SetUp
        // Tests
        [TestCaseSource(nameof(arrCopy))]
        public void ResultsPageItem_ShouldCreateACopy_WhenProperObjectIsProvided
            (ResultsPageItem objItem, ResultsPageItem objExpected)
        {

            // Arrange
            // Act
            ResultsPageItem objActual = new ResultsPageItem(objItem);

            // Assert
            Assert.AreEqual(objExpected.AbsoluteUrl, objActual.AbsoluteUrl);
            Assert.AreEqual(objExpected.AdvertisementPublishDate, objActual.AdvertisementPublishDate);
            Assert.AreEqual(objExpected.ApplicationDeadline, objActual.ApplicationDeadline);
            Assert.AreEqual(objExpected.Contact, objActual.Contact);
            Assert.AreEqual(objExpected.Description, objActual.Description);
            Assert.AreEqual(objExpected.Employer, objActual.Employer);
            Assert.AreEqual(objExpected.EmployerAddress, objActual.EmployerAddress);
            Assert.AreEqual(objExpected.EmploymentStartDate, objActual.EmploymentStartDate);
            Assert.AreEqual(objExpected.EmploymentType, objActual.EmploymentType);
            Assert.AreEqual(objExpected.HowToApply, objActual.HowToApply);
            Assert.AreEqual(objExpected.ItemId, objActual.ItemId);
            Assert.AreEqual(objExpected.Openings, objActual.Openings);
            Assert.AreEqual(objExpected.Position, objActual.Position);
            Assert.AreEqual(objExpected.Title, objActual.Title);
            Assert.AreEqual(objExpected.WeeklyWorkingHours, objActual.WeeklyWorkingHours);
            Assert.AreEqual(objExpected.WorkArea, objActual.WorkArea);

        }

        // TearDown

    }
}

/*

    Author: numbworks@gmail.com
    Last Update: 22.09.2018

*/