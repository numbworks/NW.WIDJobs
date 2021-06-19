using System;
using System.IO;
using Microsoft.EntityFrameworkCore;

namespace NW.WIDJobs
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
        public DbSet<PageItemEntity> PageItems { get; set; }
        public DbSet<PageItemExtendedEntity> PageItemsExtended { get; set; }
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

            CreatePageItemsTable(modelBuilder);
            CreatePageItemsExtendedTable(modelBuilder);
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

        private void CreatePageItemsTable(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<PageItemEntity>()
                .HasKey(entity => entity.RowId);
            modelBuilder.Entity<PageItemEntity>()
                .Property(entity => entity.RowId)
                .HasColumnType("integer")
                .IsRequired(true)
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<PageItemEntity>()
                .Property(entity => entity.RunId)
                .HasColumnType("varchar(250)")
                .IsRequired(true);
            modelBuilder.Entity<PageItemEntity>()
                .Property(entity => entity.PageNumber)
                .HasColumnType("smallint")
                .IsRequired(true);
            modelBuilder.Entity<PageItemEntity>()
                .Property(entity => entity.Url)
                .HasColumnType("varchar(250)")
                .IsRequired(true);
            modelBuilder.Entity<PageItemEntity>()
                .Property(entity => entity.Title)
                .HasColumnType("varchar(250)")
                .IsRequired(true);
            modelBuilder.Entity<PageItemEntity>()
                .Property(entity => entity.CreateDate)
                .HasColumnType("datetime")
                .IsRequired(true);
            modelBuilder.Entity<PageItemEntity>()
                .Property(entity => entity.ApplicationDate)
                .HasColumnType("datetime")
                .IsRequired(false);
            modelBuilder.Entity<PageItemEntity>()
                .Property(entity => entity.WorkArea)
                .HasColumnType("varchar(250)")
                .IsRequired(true);
            modelBuilder.Entity<PageItemEntity>()
                .Property(entity => entity.WorkAreaWithoutZone)
                .HasColumnType("varchar(250)")
                .IsRequired(true);
            modelBuilder.Entity<PageItemEntity>()
                .Property(entity => entity.WorkingHours)
                .HasColumnType("varchar(250)")
                .IsRequired(true);
            modelBuilder.Entity<PageItemEntity>()
                .Property(entity => entity.JobType)
                .HasColumnType("varchar(250)")
                .IsRequired(true);
            modelBuilder.Entity<PageItemEntity>()
                .Property(entity => entity.JobId)
                .HasColumnType("bigint")
                .IsRequired(true);
            modelBuilder.Entity<PageItemEntity>()
                .Property(entity => entity.PageItemNumber)
                .HasColumnType("smallint")
                .IsRequired(true);
            modelBuilder.Entity<PageItemEntity>()
                .Property(entity => entity.PageItemId)
                .HasColumnType("varchar(250)")
                .IsRequired(true);

            modelBuilder.Entity<PageItemEntity>()
                .Property(entity => entity.RowCreatedOn)
                .HasColumnType("datetime")
                .IsRequired(true)
                .HasDefaultValueSql("datetime('now')");
            modelBuilder.Entity<PageItemEntity>()
                .Property(entity => entity.RowModifiedOn)
                .HasColumnType("datetime")
                .IsRequired(true)
                .HasDefaultValueSql("datetime('now')");

        }
        private void CreatePageItemsExtendedTable(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<PageItemExtendedEntity>()
                .HasKey(entity => entity.RowId);
            modelBuilder.Entity<PageItemExtendedEntity>()
                .Property(entity => entity.RowId)
                .HasColumnType("integer")
                .IsRequired(true)
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<PageItemExtendedEntity>()
                .Property(entity => entity.PageItemId)
                .HasColumnType("varchar(250)")
                .IsRequired(true);
            modelBuilder.Entity<PageItemExtendedEntity>()
                .Property(entity => entity.Description)
                .HasColumnType("text")
                .IsRequired(true);
            modelBuilder.Entity<PageItemExtendedEntity>()
                .Property(entity => entity.SeeCompleteTextAt)
                .HasColumnType("varchar(250)")
                .IsRequired(false);
            modelBuilder.Entity<PageItemExtendedEntity>()
                .Property(entity => entity.EmployerName)
                .HasColumnType("varchar(250)")
                .IsRequired(false);
            modelBuilder.Entity<PageItemExtendedEntity>()
                .Property(entity => entity.NumberOfOpenings)
                .HasColumnType("smallint")
                .IsRequired(false);
            modelBuilder.Entity<PageItemExtendedEntity>()
                .Property(entity => entity.AdvertisementPublishDate)
                .HasColumnType("datetime")
                .IsRequired(false);
            modelBuilder.Entity<PageItemExtendedEntity>()
                .Property(entity => entity.ApplicationDeadline)
                .HasColumnType("datetime")
                .IsRequired(false);
            modelBuilder.Entity<PageItemExtendedEntity>()
                .Property(entity => entity.StartDateOfEmployment)
                .HasColumnType("varchar(250)")
                .IsRequired(false);
            modelBuilder.Entity<PageItemExtendedEntity>()
                .Property(entity => entity.Reference)
                .HasColumnType("varchar(250)")
                .IsRequired(false);
            modelBuilder.Entity<PageItemExtendedEntity>()
                .Property(entity => entity.Position)
                .HasColumnType("varchar(250)")
                .IsRequired(false);
            modelBuilder.Entity<PageItemExtendedEntity>()
                .Property(entity => entity.TypeOfEmployment)
                .HasColumnType("varchar(250)")
                .IsRequired(false);
            modelBuilder.Entity<PageItemExtendedEntity>()
                .Property(entity => entity.Contact)
                .HasColumnType("varchar(250)")
                .IsRequired(false);
            modelBuilder.Entity<PageItemExtendedEntity>()
                .Property(entity => entity.EmployerAddress)
                .HasColumnType("varchar(250)")
                .IsRequired(false);
            modelBuilder.Entity<PageItemExtendedEntity>()
                .Property(entity => entity.HowToApply)
                .HasColumnType("varchar(250)")
                .IsRequired(false);

            modelBuilder.Entity<PageItemExtendedEntity>()
                .Property(entity => entity.RowCreatedOn)
                .HasColumnType("datetime")
                .IsRequired(true)
                .HasDefaultValueSql("datetime('now')");
            modelBuilder.Entity<PageItemExtendedEntity>()
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
                .Property(entity => entity.PageItemId)
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
    Last Update: 19.06.2021
*/