using System;
using System.IO;
using Microsoft.EntityFrameworkCore;
using NW.WIDJobs.Validation;

namespace NW.WIDJobs.Database
{
    /// <summary><inheritdoc cref="DbContext"/></summary>
    public class DatabaseContext : DbContext
    {

        #region Fields

        private static string _connectionString;

        #endregion

        #region Properties
        
        public static Func<string, string> ConnectionStringTemplate { get; }
            = (fileName) => $"Data Source={fileName};";

        public string ConnectionString { get; private set; }
        public DbSet<JobPostingEntity> JobPostings { get; set; }
        public DbSet<JobPostingExtendedEntity> JobPostingsExtended { get; set; }
        public DbSet<BulletPointEntity> BulletPoints { get; set; }

        #endregion

        #region Constructors

        ///<summary>Initializes a <see cref="DatabaseContext"/> instance for <paramref name="databasePath"/> and <paramref name="databaseName"/>.</summary>
        /// <exception cref="ArgumentNullException"></exception>
        public DatabaseContext(string databasePath, string databaseName)
            : base(CreateOptions(databasePath, databaseName))
        {

            ConnectionString = _connectionString;

        }

        ///<summary>Initializes a <see cref="DatabaseContext"/> instance for <paramref name="options"/>.</summary>
        public DatabaseContext(DbContextOptions<DatabaseContext> options)
            : base(options) { }

        #endregion

        #region Methods_protected

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            CreateJobPostingsTable(modelBuilder);
            CreateJobPostingsExtendedTable(modelBuilder);
            CreateBulletPointsTable(modelBuilder);

        }

        #endregion

        #region Methods_private

        private static DbContextOptions CreateOptions(string databasePath, string databaseName)
        {

            Validator.ValidateStringNullOrWhiteSpace(databasePath, nameof(databasePath));
            Validator.ValidateStringNullOrWhiteSpace(databaseName, nameof(databaseName));

            _connectionString = CreateConnectionString(databasePath, databaseName);

            return new DbContextOptionsBuilder().UseSqlite(_connectionString).Options;

        }
        private static string CreateConnectionString(string databasePath, string databaseName)
        {

            // "Data Source=c:\mydb.db;"

            if (!databaseName.Contains(".db"))
                databaseName = $"{databaseName}.db";

            string fileName = Path.Combine(databasePath, databaseName);

            return ConnectionStringTemplate.Invoke(fileName);

        }

        private void CreateJobPostingsTable(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<JobPostingEntity>()
                .HasKey(entity => entity.RowId);
            modelBuilder.Entity<JobPostingEntity>()
                .Property(entity => entity.RowId)
                .HasColumnType("integer")
                .IsRequired(true)
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<JobPostingEntity>()
                .Property(entity => entity.RunId)
                .HasColumnType("varchar(250)")
                .IsRequired(true);
            modelBuilder.Entity<JobPostingEntity>()
                .Property(entity => entity.PageNumber)
                .HasColumnType("smallint")
                .IsRequired(true);
            modelBuilder.Entity<JobPostingEntity>()
                .Property(entity => entity.Response)
                .HasColumnType("varchar(4000)")
                .IsRequired(true);
            modelBuilder.Entity<JobPostingEntity>()
                .Property(entity => entity.Title)
                .HasColumnType("varchar(250)")
                .IsRequired(true);
            modelBuilder.Entity<JobPostingEntity>()
                .Property(entity => entity.Presentation)
                .HasColumnType("varchar(250)")
                .IsRequired(false);
            modelBuilder.Entity<JobPostingEntity>()
                .Property(entity => entity.HiringOrgName)
                .HasColumnType("varchar(250)")
                .IsRequired(false);
            modelBuilder.Entity<JobPostingEntity>()
                .Property(entity => entity.WorkPlaceAddress)
                .HasColumnType("varchar(250)")
                .IsRequired(false);
            modelBuilder.Entity<JobPostingEntity>()
                .Property(entity => entity.WorkPlacePostalCode)
                .HasColumnType("smallint")
                .IsRequired(false);
            modelBuilder.Entity<JobPostingEntity>()
                .Property(entity => entity.WorkPlaceCity)
                .HasColumnType("varchar(250)")
                .IsRequired(false);
            modelBuilder.Entity<JobPostingEntity>()
                .Property(entity => entity.PostingCreated)
                .HasColumnType("datetime")
                .IsRequired(true);
            modelBuilder.Entity<JobPostingEntity>()
                .Property(entity => entity.LastDateApplication)
                .HasColumnType("datetime")
                .IsRequired(true);
            modelBuilder.Entity<JobPostingEntity>()
                .Property(entity => entity.Url)
                .HasColumnType("varchar(250)")
                .IsRequired(true);
            modelBuilder.Entity<JobPostingEntity>()
                .Property(entity => entity.Region)
                .HasColumnType("varchar(250)")
                .IsRequired(false);
            modelBuilder.Entity<JobPostingEntity>()
                .Property(entity => entity.Municipality)
                .HasColumnType("varchar(250)")
                .IsRequired(false);
            modelBuilder.Entity<JobPostingEntity>()
                .Property(entity => entity.Country)
                .HasColumnType("varchar(250)")
                .IsRequired(false);
            modelBuilder.Entity<JobPostingEntity>()
                .Property(entity => entity.EmploymentType)
                .HasColumnType("varchar(250)")
                .IsRequired(false);
            modelBuilder.Entity<JobPostingEntity>()
                .Property(entity => entity.WorkHours)
                .HasColumnType("varchar(250)")
                .IsRequired(true);
            modelBuilder.Entity<JobPostingEntity>()
                .Property(entity => entity.Occupation)
                .HasColumnType("varchar(250)")
                .IsRequired(false);
            modelBuilder.Entity<JobPostingEntity>()
                .Property(entity => entity.WorkplaceId)
                .HasColumnType("bigint")
                .IsRequired(true);
            modelBuilder.Entity<JobPostingEntity>()
                .Property(entity => entity.OrganisationId)
                .HasColumnType("bigint")
                .IsRequired(false);
            modelBuilder.Entity<JobPostingEntity>()
                .Property(entity => entity.HiringOrgCVR)
                .HasColumnType("bigint")
                .IsRequired(true);
            modelBuilder.Entity<JobPostingEntity>()
                .Property(entity => entity.Id)
                .HasColumnType("bigint")
                .IsRequired(true);
            modelBuilder.Entity<JobPostingEntity>()
                .Property(entity => entity.WorkPlaceCityWithoutZone)
                .HasColumnType("varchar(250)")
                .IsRequired(false);
            modelBuilder.Entity<JobPostingEntity>()
                .Property(entity => entity.JobPostingNumber)
                .HasColumnType("smallint")
                .IsRequired(true);
            modelBuilder.Entity<JobPostingEntity>()
                .Property(entity => entity.JobPostingId)
                .HasColumnType("varchar(250)")
                .IsRequired(true);

            modelBuilder.Entity<JobPostingEntity>()
                .Property(entity => entity.RowCreatedOn)
                .HasColumnType("datetime")
                .IsRequired(true)
                .HasDefaultValueSql("datetime('now')");
            modelBuilder.Entity<JobPostingEntity>()
                .Property(entity => entity.RowModifiedOn)
                .HasColumnType("datetime")
                .IsRequired(true)
                .HasDefaultValueSql("datetime('now')");

        }
        private void CreateJobPostingsExtendedTable(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<JobPostingExtendedEntity>()
                .HasKey(entity => entity.RowId);
            modelBuilder.Entity<JobPostingExtendedEntity>()
                .Property(entity => entity.RowId)
                .HasColumnType("integer")
                .IsRequired(true)
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<JobPostingExtendedEntity>()
                .Property(entity => entity.JobPostingId)
                .HasColumnType("varchar(250)")
                .IsRequired(true);
            modelBuilder.Entity<JobPostingExtendedEntity>()
                .Property(entity => entity.Response)
                .HasColumnType("varchar(8000)")
                .IsRequired(true);
            modelBuilder.Entity<JobPostingExtendedEntity>()
                .Property(entity => entity.HiringOrgDescription)
                .HasColumnType("varchar(250)")
                .IsRequired(false);
            modelBuilder.Entity<JobPostingExtendedEntity>()
                .Property(entity => entity.PublicationStartDate)
                .HasColumnType("datetime")
                .IsRequired(false);
            modelBuilder.Entity<JobPostingExtendedEntity>()
                .Property(entity => entity.PublicationEndDate)
                .HasColumnType("datetime")
                .IsRequired(false);
            modelBuilder.Entity<JobPostingExtendedEntity>()
                .Property(entity => entity.Purpose)
                .HasColumnType("varchar(8000)")
                .IsRequired(false);
            modelBuilder.Entity<JobPostingExtendedEntity>()
                .Property(entity => entity.NumberToFill)
                .HasColumnType("smallint")
                .IsRequired(false);
            modelBuilder.Entity<JobPostingExtendedEntity>()
                .Property(entity => entity.ContactEmail)
                .HasColumnType("varchar(250)")
                .IsRequired(false);
            modelBuilder.Entity<JobPostingExtendedEntity>()
                .Property(entity => entity.ContactPersonName)
                .HasColumnType("varchar(250)")
                .IsRequired(false);
            modelBuilder.Entity<JobPostingExtendedEntity>()
                .Property(entity => entity.EmploymentDate)
                .HasColumnType("datetime")
                .IsRequired(false);
            modelBuilder.Entity<JobPostingExtendedEntity>()
                .Property(entity => entity.ApplicationDeadlineDate)
                .HasColumnType("datetime")
                .IsRequired(false);
            modelBuilder.Entity<JobPostingExtendedEntity>()
                .Property(entity => entity.BulletPointScenario)
                .HasColumnType("varchar(250)")
                .IsRequired(false);

            modelBuilder.Entity<JobPostingExtendedEntity>()
                .Property(entity => entity.RowCreatedOn)
                .HasColumnType("datetime")
                .IsRequired(true)
                .HasDefaultValueSql("datetime('now')");
            modelBuilder.Entity<JobPostingExtendedEntity>()
                .Property(entity => entity.RowModifiedOn)
                .HasColumnType("datetime")
                .IsRequired(true)
                .HasDefaultValueSql("datetime('now')");

        }
        private void CreateBulletPointsTable(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<BulletPointEntity>()
                .HasKey(entity => entity.RowId);
            modelBuilder.Entity<BulletPointEntity>()
                .Property(entity => entity.RowId)
                .HasColumnType("integer")
                .IsRequired(true)
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<BulletPointEntity>()
                .Property(entity => entity.JobPostingId)
                .HasColumnType("varchar(250)")
                .IsRequired(true);
            modelBuilder.Entity<BulletPointEntity>()
                .Property(entity => entity.BulletPoint)
                .HasColumnType("varchar(250)")
                .IsRequired(true);

            modelBuilder.Entity<BulletPointEntity>()
                .Property(entity => entity.RowCreatedOn)
                .HasColumnType("datetime")
                .IsRequired(true)
                .HasDefaultValueSql("datetime('now')");
            modelBuilder.Entity<BulletPointEntity>()
                .Property(entity => entity.RowModifiedOn)
                .HasColumnType("datetime")
                .IsRequired(true)
                .HasDefaultValueSql("datetime('now')");

        }

        #endregion

    }
}

/*
    Author: numbworks@gmail.com
    Last Update: 25.08.2021
*/