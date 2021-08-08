using System;
using System.Collections.Generic;

namespace NW.WIDJobs
{
    /// <summary>Collects all the database-related methods.</summary>
    public interface IRepository
    {

        /// <summary>
        /// Conditionally insert <paramref name="pageItem"/> into the database and returns affected rows.
        /// </summary>
        /// <exception cref="ArgumentNullException"></exception>
        int ConditionallyInsert(PageItem pageItem);

        /// <summary>
        /// Conditionally insert <paramref name="pageItems"/> into the database and returns affected rows.
        /// </summary>
        /// <exception cref="ArgumentNullException"></exception>
        int ConditionallyInsert(List<PageItem> pageItems);

        /// <summary>
        /// Conditionally insert <paramref name="pageItemExtended"/> into the database and returns affected rows.
        /// </summary>
        /// <exception cref="ArgumentNullException"></exception>
        int ConditionallyInsert(PageItemExtended pageItemExtended);

        /// <summary>
        /// Conditionally insert <paramref name="pageItemsExtended"/> into the database and returns affected rows.
        /// </summary>
        /// <exception cref="ArgumentNullException"></exception>
        int ConditionallyInsert(List<PageItemExtended> pageItemsExtended);

    }
}

/*
    Author: numbworks@gmail.com
    Last Update: 19.06.2021
*/