using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

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
        public void AddOrUpdate_ShouldAddOnePageItemEntity_WhenInvoked()
        {

            // Arrange
            DatabaseContext databaseContext = ObjectMother.CreateInMemoryContext();
            int rowsBefore = databaseContext.PageItems.Count();

            // Act
            databaseContext.PageItems.AddOrUpdate(ObjectMother.Shared_Page01_PageItemEntity01);
            databaseContext.SaveChanges();
            int rowsAfter = databaseContext.PageItems.Count();
            databaseContext.Dispose();

            // Assert
            Assert.AreEqual(0, rowsBefore);
            Assert.AreEqual(1, rowsAfter);


        }
        [Test]
        public void AddOrUpdate_ShouldAddPageItemEntities_WhenInvoked()
        {

            // Arrange
            DatabaseContext databaseContext = ObjectMother.CreateInMemoryContext();
            int rowsBefore = databaseContext.PageItems.Count();

            // Act
            databaseContext.PageItems.AddOrUpdate(ObjectMother.Shared_Page01_PageItemEntities);
            databaseContext.SaveChanges();
            int rowsAfter = databaseContext.PageItems.Count();
            databaseContext.Dispose();

            // Assert
            Assert.AreEqual(0, rowsBefore);
            Assert.AreEqual(ObjectMother.Shared_Page01_PageItemEntities.Count, rowsAfter);


        }
        [Test]
        public void AddOrUpdate_ShouldUpdateTwoAndAddTwo_WhenFourPageItemEntities()
        {

            // Arrange
            DatabaseContext databaseContext = ObjectMother.CreateInMemoryContext();

            // Act
            List<PageItemEntity> added = new List<PageItemEntity>();
            databaseContext.PageItems.AddOrUpdate(ObjectMother.Shared_Page01_PageItemEntity01, ref added);
            databaseContext.SaveChanges();
            databaseContext.PageItems.AddOrUpdate(ObjectMother.Shared_Page01_PageItemEntity01, ref added);
            databaseContext.SaveChanges();
            databaseContext.PageItems.AddOrUpdate(ObjectMother.Shared_Page01Alternate_PageItemEntity01, ref added);
            databaseContext.SaveChanges();
            databaseContext.PageItems.AddOrUpdate(ObjectMother.Shared_Page01Alternate_PageItemEntity02, ref added);
            databaseContext.SaveChanges();
            databaseContext.Dispose();

            // Assert
            Assert.AreEqual(2, added.Count);

        }

        [Test]
        public void AddOrUpdate_ShouldAddOnePageItemExtendedEntity_WhenInvoked()
        {

            // Arrange
            DatabaseContext databaseContext = ObjectMother.CreateInMemoryContext();
            int rowsBefore = databaseContext.PageItemsExtended.Count();

            // Act
            databaseContext.PageItemsExtended.AddOrUpdate(ObjectMother.Shared_Page01_PageItemExtendedEntity01);
            databaseContext.SaveChanges();
            int rowsAfter = databaseContext.PageItemsExtended.Count();
            databaseContext.Dispose();

            // Assert
            Assert.AreEqual(0, rowsBefore);
            Assert.AreEqual(1, rowsAfter);

        }
        [Test]
        public void AddOrUpdate_ShouldAddPageItemExtendedEntities_WhenInvoked()
        {

            // Arrange
            DatabaseContext databaseContext = ObjectMother.CreateInMemoryContext();
            int rowsBefore = databaseContext.PageItemsExtended.Count();

            // Act
            databaseContext.PageItemsExtended.AddOrUpdate(ObjectMother.Shared_Page01_PageItemExtendedEntities);
            databaseContext.SaveChanges();
            int rowsAfter = databaseContext.PageItemsExtended.Count();
            databaseContext.Dispose();

            // Assert
            Assert.AreEqual(0, rowsBefore);
            Assert.AreEqual(ObjectMother.Shared_Page01_PageItemExtendedEntities.Count, rowsAfter);

        }

        [Test]
        public void AddOrUpdate_ShouldAddOneBulletPointEntity_WhenInvoked()
        {

            // Arrange
            DatabaseContext databaseContext = ObjectMother.CreateInMemoryContext();
            int rowsBefore = databaseContext.BulletPoints.Count();

            // Act
            databaseContext.BulletPoints.AddOrUpdate(ObjectMother.Shared_Page01_PageItemExtended01BulletPointEntity01);
            databaseContext.SaveChanges();
            int rowsAfter = databaseContext.BulletPoints.Count();
            databaseContext.Dispose();

            // Assert
            Assert.AreEqual(0, rowsBefore);
            Assert.AreEqual(1, rowsAfter);

        }
        [Test]
        public void AddOrUpdate_ShouldAddBulletPointEntities_WhenInvoked()
        {

            // Arrange
            DatabaseContext databaseContext = ObjectMother.CreateInMemoryContext();
            int rowsBefore = databaseContext.BulletPoints.Count();

            // Act
            databaseContext.BulletPoints.AddOrUpdate(ObjectMother.Shared_Page01_PageItemExtended01BulletPointEntities);
            databaseContext.SaveChanges();
            int rowsAfter = databaseContext.BulletPoints.Count();
            databaseContext.Dispose();

            // Assert
            Assert.AreEqual(0, rowsBefore);
            Assert.AreEqual(ObjectMother.Shared_Page01_PageItemExtended01BulletPointEntities.Count, rowsAfter);

        }

        // TearDown		

    }
}

/*
    Author: numbworks@gmail.com
    Last Update: 19.06.2021
*/
