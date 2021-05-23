namespace NW.WIDJobs
{
    /// <summary>Collects all the helper methods related to <see cref="WIDCategories"/>.</summary>
    public interface IWIDCategoryManager
    {

        /// <summary>
        /// Returns category token for <paramref name="category"/>.
        /// </summary>
        string GetCategoryToken(WIDCategories category); 
    
    }
}

/*
    Author: numbworks@gmail.com
    Last Update: 16.05.2021
*/