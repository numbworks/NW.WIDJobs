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
                                .JobPostings
                                    .AddOrUpdate((IEnumerable<PageItemEntity>)null)
                ),
                typeof(ArgumentNullException),
                new ArgumentNullException("entities").Message
            ).SetArgDisplayNames($"{nameof(addOrUpdateExceptionTestCases)}_01"),

            new TestCaseData(
                new TestDelegate(
                    () => ObjectMother
                            .DbSetExtensionMethods_InMemoryDatabaseContext
                                .JobPostings
                                    .AddOrUpdate((PageItemEntity)null)
                ),
                typeof(ArgumentNullException),
                new ArgumentNullException("entity").Message
            ).SetArgDisplayNames($"{nameof(addOrUpdateExceptionTestCases)}_02"),

            new TestCaseData(
                new TestDelegate(
                    () => ObjectMother
                            .DbSetExtensionMethods_InMemoryDatabaseContext
                                .JobPostings
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
                                .JobPostings
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
            int rowsBefore = databaseContext.JobPostings.Count();

            // Act
            databaseContext.JobPostings.AddOrUpdate(ObjectMother.Shared_Page01_PageItemEntity01);
            databaseContext.SaveChanges();
            int rowsAfter = databaseContext.JobPostings.Count();
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
            int rowsBefore = databaseContext.JobPostings.Count();

            // Act
            databaseContext.JobPostings.AddOrUpdate(ObjectMother.Shared_Page01_PageItemEntities);
            databaseContext.SaveChanges();
            int rowsAfter = databaseContext.JobPostings.Count();
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
            List<PageItemEntity> addedStep1 = new List<PageItemEntity>();
            databaseContext.JobPostings.AddOrUpdate(ObjectMother.Shared_Page01_PageItemEntity01, ref addedStep1);
            databaseContext.SaveChanges(); // Add the first one, database is empty, added = 1

            List<PageItemEntity> addedStep2 = new List<PageItemEntity>();
            databaseContext.JobPostings.AddOrUpdate(ObjectMother.Shared_Page01_PageItemEntity01, ref addedStep2);
            databaseContext.SaveChanges(); // Add the second one, same as the pre-exiting one, added = 0

            List<PageItemEntity> addedStep3 = new List<PageItemEntity>();
            databaseContext.JobPostings.AddOrUpdate(ObjectMother.Shared_Page01Alternate_PageItemEntity01, ref addedStep3);
            databaseContext.SaveChanges(); // Add the third one, update the CreatedDate for the pre-exiting one, added = 0

            List<PageItemEntity> addedStep4 = new List<PageItemEntity>();
            databaseContext.JobPostings.AddOrUpdate(ObjectMother.Shared_Page01Alternate_PageItemEntity02, ref addedStep4);
            databaseContext.SaveChanges(); // Add the fourth one, differs from the pre-existing one, added = 1
            databaseContext.Dispose();

            // Assert
            Assert.AreEqual(1, addedStep1.Count);
            Assert.AreEqual(0, addedStep2.Count);
            Assert.AreEqual(0, addedStep3.Count);
            Assert.AreEqual(1, addedStep4.Count);

        }
        [Test]
        public void AddOrUpdate_ShouldUpdateTwentyPageItemEntities_WhenTwentyPageItemEntities()
        {

            // Arrange
            DatabaseContext databaseContext = ObjectMother.CreateInMemoryContext();

            // Act
            List<PageItemEntity> addedStep1 = new List<PageItemEntity>();
            databaseContext.JobPostings.AddOrUpdate(ObjectMother.Shared_Page01_PageItemEntities, ref addedStep1);
            databaseContext.SaveChanges();

            List<PageItemEntity> addedStep2 = new List<PageItemEntity>();
            databaseContext.JobPostings.AddOrUpdate(ObjectMother.Shared_Page01_PageItemEntities, ref addedStep2);
            databaseContext.SaveChanges();
            databaseContext.Dispose();

            // Assert
            Assert.AreEqual(20, addedStep1.Count);
            Assert.AreEqual(0, addedStep2.Count);

        }

        [Test]
        public void AddOrUpdate_ShouldAddOnePageItemExtendedEntity_WhenInvoked()
        {

            // Arrange
            DatabaseContext databaseContext = ObjectMother.CreateInMemoryContext();
            int rowsBefore = databaseContext.JobPostingsExtended.Count();

            // Act
            databaseContext.JobPostingsExtended.AddOrUpdate(ObjectMother.Shared_Page01_PageItemExtendedEntity01);
            databaseContext.SaveChanges();
            int rowsAfter = databaseContext.JobPostingsExtended.Count();
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
            int rowsBefore = databaseContext.JobPostingsExtended.Count();

            // Act
            databaseContext.JobPostingsExtended.AddOrUpdate(ObjectMother.Shared_Page01_PageItemExtendedEntities);
            databaseContext.SaveChanges();
            int rowsAfter = databaseContext.JobPostingsExtended.Count();
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
