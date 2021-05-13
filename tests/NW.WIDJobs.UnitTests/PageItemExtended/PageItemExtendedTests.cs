using System;
using NUnit.Framework;

namespace NW.WIDJobs.UnitTests
{
    [TestFixture]
    public class PageItemExtendedTests
    {

        // Fields
        private static TestCaseData[] pageItemExtendedExceptionTestCases =
        {

            new TestCaseData(
                new TestDelegate(
                    () => new PageItemExtended(
                                    null,
                                    ObjectMother.Shared_Page01_PageItemExtended01.Description,
                                    ObjectMother.Shared_Page01_PageItemExtended01.DescriptionSeeCompleteTextAt,
                                    ObjectMother.Shared_Page01_PageItemExtended01.DescriptionBulletPoints,
                                    ObjectMother.Shared_Page01_PageItemExtended01.EmployerName,
                                    ObjectMother.Shared_Page01_PageItemExtended01.NumberOfOpenings,
                                    ObjectMother.Shared_Page01_PageItemExtended01.AdvertisementPublishDate,
                                    ObjectMother.Shared_Page01_PageItemExtended01.ApplicationDeadline,
                                    ObjectMother.Shared_Page01_PageItemExtended01.StartDateOfEmployment,
                                    ObjectMother.Shared_Page01_PageItemExtended01.Reference,
                                    ObjectMother.Shared_Page01_PageItemExtended01.Position,
                                    ObjectMother.Shared_Page01_PageItemExtended01.TypeOfEmployment,
                                    ObjectMother.Shared_Page01_PageItemExtended01.Contact,
                                    ObjectMother.Shared_Page01_PageItemExtended01.EmployerAddress,
                                    ObjectMother.Shared_Page01_PageItemExtended01.HowToApply
                        )
				),
                typeof(ArgumentNullException),
                new ArgumentNullException("pageItem").Message
            ).SetArgDisplayNames($"{nameof(pageItemExtendedExceptionTestCases)}_01"),

            new TestCaseData(
                new TestDelegate(
                    () => new PageItemExtended(
                                    ObjectMother.Shared_Page01_PageItemExtended01.PageItem,
                                    null,
                                    ObjectMother.Shared_Page01_PageItemExtended01.DescriptionSeeCompleteTextAt,
                                    ObjectMother.Shared_Page01_PageItemExtended01.DescriptionBulletPoints,
                                    ObjectMother.Shared_Page01_PageItemExtended01.EmployerName,
                                    ObjectMother.Shared_Page01_PageItemExtended01.NumberOfOpenings,
                                    ObjectMother.Shared_Page01_PageItemExtended01.AdvertisementPublishDate,
                                    ObjectMother.Shared_Page01_PageItemExtended01.ApplicationDeadline,
                                    ObjectMother.Shared_Page01_PageItemExtended01.StartDateOfEmployment,
                                    ObjectMother.Shared_Page01_PageItemExtended01.Reference,
                                    ObjectMother.Shared_Page01_PageItemExtended01.Position,
                                    ObjectMother.Shared_Page01_PageItemExtended01.TypeOfEmployment,
                                    ObjectMother.Shared_Page01_PageItemExtended01.Contact,
                                    ObjectMother.Shared_Page01_PageItemExtended01.EmployerAddress,
                                    ObjectMother.Shared_Page01_PageItemExtended01.HowToApply
                        )
                ),
                typeof(ArgumentNullException),
                new ArgumentNullException("description").Message
            ).SetArgDisplayNames($"{nameof(pageItemExtendedExceptionTestCases)}_02"),

        };

        // SetUp
        // Tests
        [TestCaseSource(nameof(pageItemExtendedExceptionTestCases))]
        public void PageItemExtended_ShouldThrowACertainException_WhenUnproperArguments
            (TestDelegate del, Type expectedType, string expectedMessage)
                => ObjectMother.Method_ShouldThrowACertainException_WhenUnproperArguments(del, expectedType, expectedMessage);

        [Test]
        public void PageItemExtended_ShouldInitializeANewPageObject_WhenProperArguments()
        {

            // Arrange
            // Act
            PageItemExtended actual
                    = new PageItemExtended(
                            ObjectMother.Shared_Page01_PageItemExtended01.PageItem,
                            ObjectMother.Shared_Page01_PageItemExtended01.Description,
                            ObjectMother.Shared_Page01_PageItemExtended01.DescriptionSeeCompleteTextAt,
                            ObjectMother.Shared_Page01_PageItemExtended01.DescriptionBulletPoints,
                            ObjectMother.Shared_Page01_PageItemExtended01.EmployerName,
                            ObjectMother.Shared_Page01_PageItemExtended01.NumberOfOpenings,
                            ObjectMother.Shared_Page01_PageItemExtended01.AdvertisementPublishDate,
                            ObjectMother.Shared_Page01_PageItemExtended01.ApplicationDeadline,
                            ObjectMother.Shared_Page01_PageItemExtended01.StartDateOfEmployment,
                            ObjectMother.Shared_Page01_PageItemExtended01.Reference,
                            ObjectMother.Shared_Page01_PageItemExtended01.Position,
                            ObjectMother.Shared_Page01_PageItemExtended01.TypeOfEmployment,
                            ObjectMother.Shared_Page01_PageItemExtended01.Contact,
                            ObjectMother.Shared_Page01_PageItemExtended01.EmployerAddress,
                            ObjectMother.Shared_Page01_PageItemExtended01.HowToApply
                        );

            // Assert
            Assert.IsTrue(
                    ObjectMother.AreEqual(ObjectMother.Shared_Page01_PageItemExtended01, actual)
                );

        }

        // TearDown

    }
}

/*
    Author: numbworks@gmail.com
    Last Update: 13.05.2021
*/