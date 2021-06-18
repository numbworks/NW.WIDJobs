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

        public int ConditionallyInsert(PageItemExtended pageItemExtended)
        {

            Validator.ValidateObject(pageItemExtended, nameof(pageItemExtended));

            PageItemEntity pageItemEntity = ExtractPageItemEntity(pageItemExtended);
            PageItemExtendedEntity pageItemExtendedEntity = ExtractPageItemExtendedEntity(pageItemExtended);
            List<BulletPointEntity> bulletPointEntities = ExtractBulletPointEntities(pageItemExtended);

            DatabaseContext.PageItems.AddOrUpdate(pageItemEntity);
            DatabaseContext.PageItemsExtended.AddOrUpdate(pageItemExtendedEntity);
            DatabaseContext.BulletPoints.AddOrUpdate(bulletPointEntities);

            return DatabaseContext.SaveChanges();

        }
        public int ConditionallyInsert(List<PageItemExtended> pageItemsExtended)
        {

            Validator.ValidateList(pageItemsExtended, nameof(pageItemsExtended));

            List<PageItemEntity> pageItemEntities = ExtractPageItemEntities(pageItemsExtended);
            List<PageItemExtendedEntity> pageItemExtendedEntities = ExtractPageItemExtendedEntities(pageItemsExtended);
            List<BulletPointEntity> bulletPointEntities = ExtractBulletPointEntities(pageItemsExtended);

            DatabaseContext.PageItems.AddOrUpdate(pageItemEntities);
            DatabaseContext.PageItemsExtended.AddOrUpdate(pageItemExtendedEntities);
            DatabaseContext.BulletPoints.AddOrUpdate(bulletPointEntities);

            return DatabaseContext.SaveChanges();

        }

        #endregion

        #region Methods_private

        private List<PageItemEntity> ExtractPageItemEntities(List<PageItemExtended> pageItemsExtended)
        {

            List<PageItemEntity> pageItemEntities = new List<PageItemEntity>();
            foreach (PageItemExtended pageItemExtended in pageItemsExtended)
            {

                PageItemEntity current = ExtractPageItemEntity(pageItemExtended);
                pageItemEntities.Add(current);

            }

            return pageItemEntities;

        }
        private PageItemEntity ExtractPageItemEntity(PageItemExtended pageItemExtended)
            => new PageItemEntity(pageItemExtended.PageItem);

        private List<PageItemExtendedEntity> ExtractPageItemExtendedEntities(List<PageItemExtended> pageItemsExtended)
        {

            List<PageItemExtendedEntity> pageItemExtendedEntities = new List<PageItemExtendedEntity>();
            foreach (PageItemExtended pageItemExtended in pageItemsExtended)
            {

                PageItemExtendedEntity current = ExtractPageItemExtendedEntity(pageItemExtended);
                pageItemExtendedEntities.Add(current);

            }

            return pageItemExtendedEntities;

        }
        private PageItemExtendedEntity ExtractPageItemExtendedEntity(PageItemExtended pageItemExtended)
            => new PageItemExtendedEntity(pageItemExtended);

        private List<BulletPointEntity> ExtractBulletPointEntities(PageItemExtended pageItemExtended)
        {

            List<BulletPointEntity> bulletPointEntities
                = pageItemExtended
                    .DescriptionBulletPoints
                    .Select(bulletPoint => new BulletPointEntity(pageItemExtended.PageItem.PageItemId, bulletPoint))
                    .ToList();

            return bulletPointEntities;

        }
        private List<BulletPointEntity> ExtractBulletPointEntities(List<PageItemExtended> pageItemsExtended)
        {

            List<BulletPointEntity> bulletPointEntities = new List<BulletPointEntity>();
            foreach (PageItemExtended pageItemExtended in pageItemsExtended)
            {

                List<BulletPointEntity> current = ExtractBulletPointEntities(pageItemExtended);
                bulletPointEntities.AddRange(current);

            }

            return bulletPointEntities;

        }

        #endregion

    }
}

/*
    Author: numbworks@gmail.com
    Last Update:19.06.2021
*/