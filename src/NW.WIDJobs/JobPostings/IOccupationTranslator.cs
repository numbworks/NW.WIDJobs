namespace NW.WIDJobs.JobPostings
{
    /// <summary>A translator for <see cref="JobPosting.Occupation"/>.</summary>
    public interface IOccupationTranslator
    {

        /// <summary>
        /// Translates known <see cref="JobPosting.Occupation"/>s from Danish to English. 
        /// <para>Returns same string if null, empty or not found.</para>
        /// </summary>
        string Translate(string occupation);
    
    }
}

/*
    Author: numbworks@gmail.com
    Last Update: 08.09.2021
*/