using System;

namespace NW.WIDJobs.JobPages
{
    /// <summary>Collects all the helper methods related to <see cref="JobPage"/>.</summary>
    public interface IJobPageManager
    {

        /// <summary>
        /// Sends a HTTP POST Request for a <see href="http://www.workindenmark.dk">WorkInDenmark</see>'s page and returns a <see cref="JobPage"/> object.
        /// </summary>
        /// <exception cref="ArgumentNullException"/>
        /// <exception cref="ArgumentException"/> 
        JobPage GetJobPage(string runId, ushort pageNumber);

        /// <summary>
        /// Calculates the total amount of pages on <see href="http://www.workindenmark.dk">WorkInDenmark</see> according to the provided <paramref name="totalJobPostings"/>.
        /// </summary>
        ushort GetTotalJobPages(uint totalJobPostings);

        /// <summary>
        /// Creates urls for <see href="http://www.workindenmark.dk">WorkInDenmark</see> pages.
        /// </summary>
        /// <exception cref="ArgumentException"/>
        string CreateUrl(ushort pageNumber);

        /// <summary>
        /// Sends a HTTP POST Request for a <see href="http://www.workindenmark.dk">WorkInDenmark</see>'s page and returns a JSON string.
        /// </summary>
        /// <exception cref="ArgumentNullException"/>
        string SendPostRequest(string url);

    }
}

/*
    Author: numbworks@gmail.com
    Last Update: 25.06.2021
*/