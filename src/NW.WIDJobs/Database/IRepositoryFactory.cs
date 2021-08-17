namespace NW.WIDJobs.Database
{
    /// <summary>A factory for <see cref="IRepository"/>.</summary>
    public interface IRepositoryFactory
    {

        /// <summary>
        /// Creates a <see cref="IRepository"/> instance for <paramref name="databasePath"/> and <paramref name="databaseName"/>.
        /// </summary>
        IRepository Create(string databasePath, string databaseName, bool deleteAndRecreateDatabase);
    
    }
}

/*
    Author: numbworks@gmail.com
    Last Update: 04.06.2021
*/