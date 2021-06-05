﻿using System;

namespace NW.WIDJobs
{
    /// <summary><inheritdoc cref="IRepositoryFactory"/></summary>
    public class RepositoryFactory : IRepositoryFactory
    {

        #region Fields
        #endregion

        #region Properties
        #endregion

        #region Constructors

        /// <summary>Initializes a <see cref="RepositoryFactory"/> instance.</summary>
        /// <exception cref="ArgumentNullException"/>
        public RepositoryFactory() { }

        #endregion

        #region Methods_public

        public IRepository Create(string databasePath, string databaseName)
            => new Repository(databasePath, databaseName);

        #endregion

    }
}

/*
    Author: numbworks@gmail.com
    Last Update: 04.06.2021
*/