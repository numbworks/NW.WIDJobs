using System;
using System.Linq;
using System.Collections.Generic;

namespace NW.WIDJobs
{
    /// <summary><inheritdoc cref="IRepository"/></summary>
    public class Repository : IRepository
    {

        #region Fields
        #endregion

        #region Properties

        public DatabaseContext DatabaseContext { get; }

        #endregion

        #region Constructors

        ///<summary>Initializes a <see cref="Repository"/> instance for <paramref name="databaseContext"/>.</summary>
        /// <exception cref="ArgumentNullException"></exception>
        public Repository(DatabaseContext databaseContext, bool deleteAndRecreateDatabase)
        {

            Validator.ValidateObject(databaseContext, nameof(databaseContext));

            DatabaseContext = databaseContext;

            if (deleteAndRecreateDatabase)
            {
                DatabaseContext.Database.EnsureDeleted();
                DatabaseContext.Database.EnsureCreated();
            }

        }

        ///<summary>Initializes a <see cref="Repository"/> instance for <paramref name="databasePath"/> and <paramref name="databaseName"/>.</summary>
        /// <exception cref="ArgumentNullException"></exception>
        public Repository(string databasePath, string databaseName, bool deleteAndRecreateDatabase)
            : this(
                new DatabaseContext(databasePath, databaseName), 
                deleteAndRecreateDatabase
                )
        {

            Validator.ValidateStringNullOrWhiteSpace(databasePath, nameof(databasePath));
            Validator.ValidateStringNullOrWhiteSpace(databaseName, nameof(databaseName));

        }

        #endregion

        #region Methods_public

        public int ConditionallyInsert(JobPosting jobPosting)
        {

            Validator.ValidateObject(jobPosting, nameof(jobPosting));

            JobPostingEntity jobPostingEntity = new JobPostingEntity(jobPosting);
            DatabaseContext.JobPostings.AddOrUpdate(jobPostingEntity);

            return DatabaseContext.SaveChanges();

        }
        public int ConditionallyInsert(List<JobPosting> jobPostings)
        {

            Validator.ValidateList(jobPostings, nameof(jobPostings));

            List<JobPostingEntity> jobPostingEntities = ExtractJobPostingEntities(jobPostings);
            DatabaseContext.JobPostings.AddOrUpdate(jobPostingEntities);

            return DatabaseContext.SaveChanges();

        }

        public int ConditionallyInsert(JobPostingExtended jobPostingExtended)
        {

            Validator.ValidateObject(jobPostingExtended, nameof(jobPostingExtended));

            JobPostingEntity jobPostingEntity = ExtractJobPostingEntity(jobPostingExtended);
            JobPostingExtendedEntity jobPostingExtendedEntity = ExtractJobPostingExtendedEntity(jobPostingExtended);
            List<BulletPointEntity> bulletPointEntities = ExtractBulletPointEntities(jobPostingExtended);

            DatabaseContext.JobPostings.AddOrUpdate(jobPostingEntity);
            DatabaseContext.JobPostingsExtended.AddOrUpdate(jobPostingExtendedEntity);
            DatabaseContext.BulletPoints.AddOrUpdate(bulletPointEntities);

            return DatabaseContext.SaveChanges();

        }
        public int ConditionallyInsert(List<JobPostingExtended> jobPostingsExtended)
        {

            Validator.ValidateList(jobPostingsExtended, nameof(jobPostingsExtended));

            List<JobPostingEntity> jobPostingEntities = ExtractJobPostingEntities(jobPostingsExtended);
            List<JobPostingExtendedEntity> jobPostingExtendedEntities = ExtractJobPostingExtendedEntities(jobPostingsExtended);
            List<BulletPointEntity> bulletPointEntities = ExtractBulletPointEntities(jobPostingsExtended);

            DatabaseContext.JobPostings.AddOrUpdate(jobPostingEntities);
            DatabaseContext.JobPostingsExtended.AddOrUpdate(jobPostingExtendedEntities);
            DatabaseContext.BulletPoints.AddOrUpdate(bulletPointEntities);

            return DatabaseContext.SaveChanges();

        }

        #endregion

        #region Methods_private

        private List<JobPostingEntity> ExtractJobPostingEntities(List<JobPosting> jobPostings)
        {

            List<JobPostingEntity> jobPostingEntities = new List<JobPostingEntity>();
            foreach (JobPosting jobPosting in jobPostings)
            {

                JobPostingEntity current = new JobPostingEntity(jobPosting);
                jobPostingEntities.Add(current);

            }

            return jobPostingEntities;

        }
        private List<JobPostingEntity> ExtractJobPostingEntities(List<JobPostingExtended> jobPostingsExtended)
        {

            List<JobPostingEntity> jobPostingEntities = new List<JobPostingEntity>();
            foreach (JobPostingExtended jobPostingExtended in jobPostingsExtended)
            {

                JobPostingEntity current = ExtractJobPostingEntity(jobPostingExtended);
                jobPostingEntities.Add(current);

            }

            return jobPostingEntities;

        }
        private JobPostingEntity ExtractJobPostingEntity(JobPostingExtended jobPostingExtended)
            => new JobPostingEntity(jobPostingExtended.JobPosting);

        private List<JobPostingExtendedEntity> ExtractJobPostingExtendedEntities(List<JobPostingExtended> jobPostingsExtended)
        {

            List<JobPostingExtendedEntity> jobPostingExtendedEntities = new List<JobPostingExtendedEntity>();
            foreach (JobPostingExtended jobPostingExtended in jobPostingsExtended)
            {

                JobPostingExtendedEntity current = ExtractJobPostingExtendedEntity(jobPostingExtended);
                jobPostingExtendedEntities.Add(current);

            }

            return jobPostingExtendedEntities;

        }
        private JobPostingExtendedEntity ExtractJobPostingExtendedEntity(JobPostingExtended jobPostingExtended)
            => new JobPostingExtendedEntity(jobPostingExtended);

        private List<BulletPointEntity> ExtractBulletPointEntities(JobPostingExtended jobPostingExtended)
        {

            if (jobPostingExtended.BulletPoints == null)
                return null;

            List<BulletPointEntity> bulletPointEntities
                = jobPostingExtended
                    .BulletPoints
                    .Select(bulletPoint => new BulletPointEntity(jobPostingExtended.JobPosting.JobPostingId, bulletPoint))
                    .ToList();

            return bulletPointEntities;

        }
        private List<BulletPointEntity> ExtractBulletPointEntities(List<JobPostingExtended> jobPostingsExtended)
        {

            List<BulletPointEntity> bulletPointEntities = new List<BulletPointEntity>();
            foreach (JobPostingExtended jobPostingExtended in jobPostingsExtended)
                if (jobPostingExtended.BulletPoints != null)
                {

                    List<BulletPointEntity> current = ExtractBulletPointEntities(jobPostingExtended);
                    bulletPointEntities.AddRange(current);

                }

            return bulletPointEntities;

        }

        #endregion

    }
}

/*
    Author: numbworks@gmail.com
    Last Update: 08.08.2021
*/