using NUnit.Framework;
using System;

namespace NW.WIDJobs.UnitTests
{
    [TestFixture]
    public class PageItemExtededEntityTests
    {

        // Fields
        private static TestCaseData[] pageItemExtendedEntityTestCases =
        {

            new TestCaseData(
                    ObjectMother.Shared_Page01_PageItemExtended14
                ).SetArgDisplayNames($"{nameof(pageItemExtendedEntityTestCases)}_01")

        };
        private static TestCaseData[] pageItemExtendedEntityExceptionTestCases =
        {

            new TestCaseData(
                new TestDelegate(
                    () => new PageItemExtendedEntity(null)
                ),
                typeof(ArgumentNullException),
                new ArgumentNullException("pageItemExtended").Message
            ).SetArgDisplayNames($"{nameof(pageItemExtendedEntityExceptionTestCases)}_01")

        };

        // SetUp
        // Tests
        [TestCaseSource(nameof(pageItemExtendedEntityTestCases))]
        public void PageItemExtendedEntity_ShouldInstantiateANewObject_WhenProperArguments
            (PageItemExtended pageItemExtended)
        {

            // Arrange
            // Act
            PageItemExtendedEntity actual = new PageItemExtendedEntity(pageItemExtended);

            // Assert
            Assert.IsTrue(
                ObjectMother.AreEqual(pageItemExtended, actual)
                );


        }

        [TestCaseSource(nameof(pageItemExtendedEntityExceptionTestCases))]
        public void PageItemExtendedEntity_ShouldThrowACertainException_WhenUnproperArguments
            (TestDelegate del, Type expectedType, string expectedMessage)
                => ObjectMother.Method_ShouldThrowACertainException_WhenUnproperArguments(del, expectedType, expectedMessage);

        [Test]
        public void PageItemExtendedEntity_ShouldCreateAnObjectOfTypePageItemExtendedEntity_WhenInvoked()
        {

            // Arrange
            // Act
            PageItemExtendedEntity actual = new PageItemExtendedEntity();

            // Assert
            Assert.IsInstanceOf<PageItemExtendedEntity>(actual);

        }

        // TearDown		

    }
}

/*
    Author: numbworks@gmail.com
    Last Update: 09.06.2021
*/