using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace NW.WIDJobs.Database
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

            Validator.ValidateList((List<T>)entities, nameof(entities));

            foreach (T entity in entities)
                dbSet.AddOrUpdate(entity);

        }

        /// <summary>
        /// Add <paramref name="entity"/> if they don't already exist.
        /// <para>Based on a thread on <see href="https://stackoverflow.com/questions/36208580/what-happened-to-addorupdate-in-ef-7-core">StackOverflow</see>.</para>
        /// </summary>
        public static void AddOrUpdate<T>(this DbSet<T> dbSet, T entity) where T : class, ITrackableEntity
        {

            Validator.ValidateObject(entity, nameof(entity));

            bool doesExist = dbSet.AsNoTracking().Any(x => x.JobPostingId == entity.JobPostingId);
            if (doesExist)
                dbSet.Update(entity);
            else
                dbSet.Add(entity);

        }

        /// <summary>
        /// Add <paramref name="entities"/> if they don't already exist, and returns the entities that have been added.
        /// <para>Based on a thread on <see href="https://stackoverflow.com/questions/36208580/what-happened-to-addorupdate-in-ef-7-core">StackOverflow</see>.</para>
        /// </summary>
        public static void AddOrUpdate<T>(this DbSet<T> dbSet, IEnumerable<T> entities, ref List<T> added) where T : class, ITrackableEntity
        {

            Validator.ValidateList(entities?.ToList(), nameof(entities));

            foreach (T entity in entities)
                dbSet.AddOrUpdate(entity, ref added);

        }

        /// <summary>
        /// Add <paramref name="entity"/> if they don't already exist.
        /// <para>Based on a thread on <see href="https://stackoverflow.com/questions/36208580/what-happened-to-addorupdate-in-ef-7-core">StackOverflow</see>.</para>
        /// </summary>
        public static void AddOrUpdate<T>(this DbSet<T> dbSet, T entity, ref List<T> added) where T : class, ITrackableEntity
        {

            Validator.ValidateObject(entity, nameof(entity));

            bool doesExist = dbSet.AsNoTracking().Any(x => x.JobPostingId == entity.JobPostingId);
            if (doesExist)
                dbSet.Update(entity);
            else
            {

                dbSet.Add(entity);
                added.Add(entity);

            }

        }

        #endregion

    }
}

/*
    Author: numbworks@gmail.com
    Last Update: 08.08.2021
*/