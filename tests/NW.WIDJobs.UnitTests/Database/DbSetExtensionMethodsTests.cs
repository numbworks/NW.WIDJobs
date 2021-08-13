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
                                    .AddOrUpdate((IEnumerable<JobPostingEntity>)null)
                ),
                typeof(ArgumentNullException),
                new ArgumentNullException("entities").Message
            ).SetArgDisplayNames($"{nameof(addOrUpdateExceptionTestCases)}_01"),

            new TestCaseData(
                new TestDelegate(
                    () => ObjectMother
                            .DbSetExtensionMethods_InMemoryDatabaseContext
                                .JobPostings
                                    .AddOrUpdate((JobPostingEntity)null)
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
                                        (IEnumerable<JobPostingEntity>)null, 
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
                                        (JobPostingEntity)null,
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
        public void AddOrUpdate_ShouldAddOneJobPostingEntity_WhenInvoked()
        {

            // Arrange
            DatabaseContext databaseContext = ObjectMother.CreateInMemoryContext();
            int rowsBefore = databaseContext.JobPostings.Count();

            // Act
            databaseContext.JobPostings.AddOrUpdate(ObjectMother.Shared_JobPage01_JobPostingEntity01);
            databaseContext.SaveChanges();
            int rowsAfter = databaseContext.JobPostings.Count();
            databaseContext.Dispose();

            // Assert
            Assert.AreEqual(0, rowsBefore);
            Assert.AreEqual(1, rowsAfter);


        }
        [Test]
        public void AddOrUpdate_ShouldAddJobPostingEntities_WhenInvoked()
        {

            // Arrange
            DatabaseContext databaseContext = ObjectMother.CreateInMemoryContext();
            int rowsBefore = databaseContext.JobPostings.Count();

            // Act
            databaseContext.JobPostings.AddOrUpdate(ObjectMother.Shared_JobPage01_JobPostingEntities);
            databaseContext.SaveChanges();
            int rowsAfter = databaseContext.JobPostings.Count();
            databaseContext.Dispose();

            // Assert
            Assert.AreEqual(0, rowsBefore);
            Assert.AreEqual(ObjectMother.Shared_JobPage01_JobPostingEntities.Count, rowsAfter);


        }

        [Test]
        public void AddOrUpdate_ShouldUpdateTwentyJobPostingEntities_WhenTwentyJobPostingEntities()
        {

            // Arrange
            DatabaseContext databaseContext = ObjectMother.CreateInMemoryContext();

            // Act
            List<JobPostingEntity> addedStep1 = new List<JobPostingEntity>();
            databaseContext.JobPostings.AddOrUpdate(ObjectMother.Shared_JobPage01_JobPostingEntities, ref addedStep1);
            databaseContext.SaveChanges();

            List<JobPostingEntity> addedStep2 = new List<JobPostingEntity>();
            databaseContext.JobPostings.AddOrUpdate(ObjectMother.Shared_JobPage01_JobPostingEntities, ref addedStep2);
            databaseContext.SaveChanges();
            databaseContext.Dispose();

            // Assert
            Assert.AreEqual(20, addedStep1.Count);
            Assert.AreEqual(0, addedStep2.Count);

        }

        [Test]
        public void AddOrUpdate_ShouldAddOneJobPostingExtendedEntity_WhenInvoked()
        {

            // Arrange
            DatabaseContext databaseContext = ObjectMother.CreateInMemoryContext();
            int rowsBefore = databaseContext.JobPostingsExtended.Count();

            // Act
            databaseContext.JobPostingsExtended.AddOrUpdate(ObjectMother.Shared_JobPage01_JobPostingExtendedEntity01);
            databaseContext.SaveChanges();
            int rowsAfter = databaseContext.JobPostingsExtended.Count();
            databaseContext.Dispose();

            // Assert
            Assert.AreEqual(0, rowsBefore);
            Assert.AreEqual(1, rowsAfter);

        }
        [Test]
        public void AddOrUpdate_ShouldAddJobPostingExtendedEntities_WhenInvoked()
        {

            // Arrange
            DatabaseContext databaseContext = ObjectMother.CreateInMemoryContext();
            int rowsBefore = databaseContext.JobPostingsExtended.Count();

            // Act
            databaseContext.JobPostingsExtended.AddOrUpdate(ObjectMother.Shared_JobPage01_JobPostingExtendedEntities);
            databaseContext.SaveChanges();
            int rowsAfter = databaseContext.JobPostingsExtended.Count();
            databaseContext.Dispose();

            // Assert
            Assert.AreEqual(0, rowsBefore);
            Assert.AreEqual(ObjectMother.Shared_JobPage01_JobPostingExtendedEntities.Count, rowsAfter);

        }

        [Test]
        public void AddOrUpdate_ShouldAddOneBulletPointEntity_WhenInvoked()
        {

            // Arrange
            DatabaseContext databaseContext = ObjectMother.CreateInMemoryContext();
            int rowsBefore = databaseContext.BulletPoints.Count();

            // Act
            databaseContext.BulletPoints.AddOrUpdate(ObjectMother.Shared_JobPage01_JobPostingExtended01BulletPointEntity01);
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
            databaseContext.BulletPoints.AddOrUpdate(ObjectMother.Shared_JobPage01_JobPostingExtended01BulletPointEntities);
            databaseContext.SaveChanges();
            int rowsAfter = databaseContext.BulletPoints.Count();
            databaseContext.Dispose();

            // Assert
            Assert.AreEqual(0, rowsBefore);
            Assert.AreEqual(ObjectMother.Shared_JobPage01_JobPostingExtended01BulletPointEntities.Count, rowsAfter);

        }

        // TearDown		

    }
}

/*
    Author: numbworks@gmail.com
    Last Update: 13.08.2021
*/
