using System;
using System.Collections.Generic;

namespace NW.WIDJobs
{
    /// <summary>Collects all the database-related methods.</summary>
    public interface IRepository
    {

        /// <summary>
        /// Insert <paramref name="pageItemExtended"/> into the database and returns affected rows.
        /// </summary>
        /// <exception cref="ArgumentNullException"></exception>
        int Insert(PageItemExtended pageItemExtended);

        /// <summary>
        /// Insert <paramref name="pageItemsExtended"/> into the database and returns affected rows.
        /// </summary>
        /// <exception cref="ArgumentNullException"></exception>
        int Insert(List<PageItemExtended> pageItemsExtended);

    }
}

/*
    Author: numbworks@gmail.com
    Last Update: 04.06.2021
*/