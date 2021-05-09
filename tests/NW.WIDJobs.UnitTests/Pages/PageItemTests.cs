using System;
using NUnit.Framework;

namespace NW.WIDJobs.UnitTests
{
    [TestFixture]
    public class PageItemTests
    {

        // Fields
        private static TestCaseData[] arrCopy =
        {

            new TestCaseData(
                new PageItem() {
                            Title = "Country Sales & Product Responsible",
                            Url = "https://www.workindenmark.dk/job/6755865/COUNTRY-SALES-PRODUCT-RESPONSIBLE",
                            JobId = "6755865COUNTRY-SALES-PRODUCT-RESPONSIBLE",
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
                new PageItem() {
                            Title = "Country Sales & Product Responsible",
                            Url = "https://www.workindenmark.dk/job/6755865/COUNTRY-SALES-PRODUCT-RESPONSIBLE",
                            JobId = "6755865COUNTRY-SALES-PRODUCT-RESPONSIBLE",
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
                new PageItem()
                ).SetName(nameof(ResultsPageItem_ShouldCreateACopy_WhenProperObjectIsProvided) + " {02}"),
            new TestCaseData(
                new PageItem(),
                new PageItem()
                ).SetName(nameof(ResultsPageItem_ShouldCreateACopy_WhenProperObjectIsProvided) + " {03}")

        };

        // SetUp
        // Tests
        [TestCaseSource(nameof(arrCopy))]
        public void ResultsPageItem_ShouldCreateACopy_WhenProperObjectIsProvided
            (PageItem objItem, PageItem objExpected)
        {

            // Arrange
            // Act
            PageItem objActual = new PageItem(objItem);

            // Assert
            Assert.AreEqual(objExpected.Url, objActual.Url);
            Assert.AreEqual(objExpected.AdvertisementPublishDate, objActual.AdvertisementPublishDate);
            Assert.AreEqual(objExpected.ApplicationDeadline, objActual.ApplicationDeadline);
            Assert.AreEqual(objExpected.Contact, objActual.Contact);
            Assert.AreEqual(objExpected.Description, objActual.Description);
            Assert.AreEqual(objExpected.Employer, objActual.Employer);
            Assert.AreEqual(objExpected.EmployerAddress, objActual.EmployerAddress);
            Assert.AreEqual(objExpected.EmploymentStartDate, objActual.EmploymentStartDate);
            Assert.AreEqual(objExpected.EmploymentType, objActual.EmploymentType);
            Assert.AreEqual(objExpected.HowToApply, objActual.HowToApply);
            Assert.AreEqual(objExpected.JobId, objActual.JobId);
            Assert.AreEqual(objExpected.Openings, objActual.Openings);
            Assert.AreEqual(objExpected.Position, objActual.Position);
            Assert.AreEqual(objExpected.Title, objActual.Title);
            Assert.AreEqual(objExpected.WorkingHours, objActual.WorkingHours);
            Assert.AreEqual(objExpected.WorkArea, objActual.WorkArea);

        }

        // TearDown

    }
}

/*

    Author: numbworks@gmail.com
    Last Update: 22.09.2018

*/