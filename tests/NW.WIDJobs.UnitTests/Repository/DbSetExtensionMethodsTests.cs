using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace NW.WIDJobs.UnitTests
{
    [TestFixture]
    public class DbSetExtensionMethodsTests
    {

        // Fields
        private static TestCaseData[] addOrUpdateExceptionTestCases =
        {

            new TestCaseData(
                new TestDelegate(
                    () => ObjectMother
                            .DbSetExtensionMethods_InMemoryDatabaseContext
                                .PageItems
                                    .AddOrUpdate((IEnumerable<PageItemEntity>)null)
                ),
                typeof(ArgumentNullException),
                new ArgumentNullException("entities").Message
            ).SetArgDisplayNames($"{nameof(addOrUpdateExceptionTestCases)}_01"),

            new TestCaseData(
                new TestDelegate(
                    () => ObjectMother
                            .DbSetExtensionMethods_InMemoryDatabaseContext
                                .PageItems
                                    .AddOrUpdate((PageItemEntity)null)
                ),
                typeof(ArgumentNullException),
                new ArgumentNullException("entity").Message
            ).SetArgDisplayNames($"{nameof(addOrUpdateExceptionTestCases)}_02"),

            new TestCaseData(
                new TestDelegate(
                    () => ObjectMother
                            .DbSetExtensionMethods_InMemoryDatabaseContext
                                .PageItems
                                    .AddOrUpdate(
                                        (IEnumerable<PageItemEntity>)null, 
                                        ref ObjectMother.DbSetExtensionMethods_NotExistingPageItemEntities)
                ),
                typeof(ArgumentNullException),
                new ArgumentNullException("entities").Message
            ).SetArgDisplayNames($"{nameof(addOrUpdateExceptionTestCases)}_03"),

            new TestCaseData(
                new TestDelegate(
                    () => ObjectMother
                            .DbSetExtensionMethods_InMemoryDatabaseContext
                                .PageItems
                                    .AddOrUpdate(
                                        (PageItemEntity)null,
                                        ref ObjectMother.DbSetExtensionMethods_NotExistingPageItemEntities)
                ),
                typeof(ArgumentNullException),
                new ArgumentNullException("entity").Message
            ).SetArgDisplayNames($"{nameof(addOrUpdateExceptionTestCases)}_04")

        };

        // SetUp
        // Tests
        [TestCaseSource(nameof(addOrUpdateExceptionTestCases))]
        public void AddOrUpdate_ShouldThrowACertainException_WhenUnproperArguments
            (TestDelegate del, Type expectedType, string expectedMessage)
                => ObjectMother.Method_ShouldThrowACertainException_WhenUnproperArguments(del, expectedType, expectedMessage);


        [Test]
        public void AddOrUpdate_Should_When()
        {

            // Arrange
            DatabaseContext databaseContext = ObjectMother.CreateInMemoryContext();

            // Act
            databaseContext.PageItems.AddOrUpdate(ObjectMother.Shared_Page01_PageItemEntity01);
            databaseContext.SaveChanges();
            int rows = databaseContext.PageItems.Count();

            // Assert
            Assert.AreEqual(1, rows);


        }

        // TearDown		

    }
}

/*
    Author: numbworks@gmail.com
    Last Update: 19.06.2021
*/
