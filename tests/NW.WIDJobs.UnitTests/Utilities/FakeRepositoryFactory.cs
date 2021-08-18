using NW.WIDJobs.Database;
using System;

namespace NW.WIDJobs.UnitTests
{
    public class FakeRepositoryFactory : IRepositoryFactory
    {

        #region Fields

        #endregion

        #region Properties

        public int AffectedRows { get; }

        #endregion

        #region Constructors

        public FakeRepositoryFactory(int affectedRows) 
        {

            AffectedRows = affectedRows;

        }

        #endregion

        #region Methods_public

        public IRepository Create(string databasePath, string databaseName, bool deleteAndRecreateDatabase)
        {

            string databaseFilePath = $"{databasePath}{databaseName}";

            return new FakeRepository(databaseFilePath, AffectedRows);

        }

        #endregion

        #region Methods_private

        #endregion

    }
}

/*
    Author: numbworks@gmail.com
    Last Update: 18.08.2021
*/