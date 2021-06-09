using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace NW.WIDJobs
{
    /// <summary>A collection of extension methods for <see cref="DbSet{TEntity}"/>.</summary>
    public static class DbSetExtensionMethods
    {

        #region Fields
        #endregion

        #region Properties
        #endregion

        #region Methods_public

        /// <summary>
        /// Add <paramref name="entities"/> if they don't already exist.
        /// <para>Based on a thread on <see href="https://stackoverflow.com/questions/36208580/what-happened-to-addorupdate-in-ef-7-core">StackOverflow</see>.</para>
        /// </summary>
        public static void AddOrUpdate<T>(this DbSet<T> dbSet, IEnumerable<T> entities) where T : class, ITrackableEntity
        {

            foreach (T entity in entities)
            {

                bool doesExist = dbSet.AsNoTracking().Any(x => x.PageItemId == entity.PageItemId);
                if (doesExist)
                {
                    dbSet.Update(entity);
                    continue;
                }

                dbSet.Add(entity);

            }

        }

        /// <summary>
        /// Add <paramref name="entities"/> if they don't already exist, and returns the entities that have been added.
        /// <para>Based on a thread on <see href="https://stackoverflow.com/questions/36208580/what-happened-to-addorupdate-in-ef-7-core">StackOverflow</see>.</para>
        /// </summary>
        public static void AddOrUpdate<T>(this DbSet<T> dbSet, IEnumerable<T> entities, ref List<T> notExisting) where T : class, ITrackableEntity
        {

            foreach (T entity in entities)
            {

                bool doesExist = dbSet.AsNoTracking().Any(x => x.PageItemId == entity.PageItemId);
                if (doesExist)
                {
                    dbSet.Update(entity);
                    continue;
                }

                dbSet.Add(entity);
                notExisting.Add(entity);

            }

        }

        #endregion

    }
}

/*
    Author: numbworks@gmail.com
    Last Update: 09.06.2021
*/