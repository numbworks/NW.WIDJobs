using NUnit.Framework;
using System;

namespace NW.WIDJobs.UnitTests
{
    [TestFixture]
    public class PageItemEntityTests
    {

        // Fields
        private static TestCaseData[] pageItemEntityTestCases =
        {

            new TestCaseData(
                    ObjectMother.Shared_Page01_PageItem01
                ).SetArgDisplayNames($"{nameof(pageItemEntityTestCases)}_01")

        };
        private static TestCaseData[] pageItemEntityExceptionTestCases =
        {

            new TestCaseData(
                new TestDelegate(
                    () => new PageItemEntity(null)
				),
                typeof(ArgumentNullException),
                new ArgumentNullException("pageItem").Message
            ).SetArgDisplayNames($"{nameof(pageItemEntityExceptionTestCases)}_01")

        };

        // SetUp
        // Tests
        [TestCaseSource(nameof(pageItemEntityTestCases))]
        public void PageItemEntity_ShouldInstantiateANewObject_WhenProperArguments(PageItem pageItem)
        {

            // Arrange
            // Act
            PageItemEntity actual = new PageItemEntity(pageItem);

            // Assert
            Assert.IsTrue(
                ObjectMother.AreEqual(pageItem, actual)
                );


        }

        [TestCaseSource(nameof(pageItemEntityExceptionTestCases))]
        public void PageItemEntity_ShouldThrowACertainException_WhenUnproperArguments
            (TestDelegate del, Type expectedType, string expectedMessage)
                => ObjectMother.Method_ShouldThrowACertainException_WhenUnproperArguments(del, expectedType, expectedMessage);

        [Test]
        public void PageItemEntity_ShouldCreateAnObjectOfTypePageItemEntity_WhenInvoked()
        {

            // Arrange
            // Act
            PageItemEntity actual = new PageItemEntity();

            // Assert
            Assert.IsInstanceOf<PageItemEntity>(actual);

        }

        // TearDown		

    }
}

/*
    Author: numbworks@gmail.com
    Last Update: 09.06.2021
*/
