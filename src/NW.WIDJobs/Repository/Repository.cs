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
        public bool HasBeenDatabaseCreated { get; }

        #endregion

        #region Constructors

        ///<summary>Initializes a <see cref="Repository"/> instance.</summary>
        /// <exception cref="ArgumentNullException"></exception>
        public Repository(string databasePath, string databaseName)
        {

            Validator.ValidateStringNullOrWhiteSpace(databasePath, nameof(databasePath));
            Validator.ValidateStringNullOrWhiteSpace(databaseName, nameof(databaseName));

            DatabaseContext = new DatabaseContext(databasePath, databaseName);
            HasBeenDatabaseCreated = DatabaseContext.Database.EnsureCreated();

        }

        #endregion

        #region Methods_public

        public int Insert(PageItemExtended pageItemExtended)
        {

            Validator.ValidateObject(pageItemExtended, nameof(pageItemExtended));

            PageItemEntity pageItemEntity = ExtractPageItemEntity(pageItemExtended);
            PageItemExtendedEntity pageItemExtendedEntity = ExtractPageItemExtendedEntity(pageItemExtended);
            List<BulletPointEntity> bulletPointEntities = ExtractBulletPointEntities(pageItemExtended);

            DatabaseContext.PageItems.Add(pageItemEntity);
            DatabaseContext.PageItemsExtended.Add(pageItemExtendedEntity);
            DatabaseContext.BulletPoints.AddRange(bulletPointEntities);

            return DatabaseContext.SaveChanges();

        }
        public int Insert(List<PageItemExtended> pageItemsExtended)
        {

            Validator.ValidateList(pageItemsExtended, nameof(pageItemsExtended));

            List<PageItemEntity> pageItemEntities = ExtractPageItemEntities(pageItemsExtended);
            List<PageItemExtendedEntity> pageItemExtendedEntities = ExtractPageItemExtendedEntities(pageItemsExtended);
            List<BulletPointEntity> bulletPointEntities = ExtractBulletPointEntities(pageItemsExtended);

            DatabaseContext.PageItems.AddRange(pageItemEntities);
            DatabaseContext.PageItemsExtended.AddRange(pageItemExtendedEntities);
            DatabaseContext.BulletPoints.AddRange(bulletPointEntities);

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
    Last Update: 04.06.2021
*/