using System;

namespace NW.WIDJobs.JobPages
{
    /// <summary>A deserializer for <see href="http://www.workindenmark.dk">WorkInDenmark</see>'s job page responses.</summary>
    public interface IJobPageDeserializer
    {

        /// <summary>
        /// Extracts the total amount of job postings from a <see href="http://www.workindenmark.dk">WorkInDenmark</see>'s job page response.
        /// </summary>
        /// <exception cref="ArgumentNullException"/>
        ushort GetTotalResultCount(string response);
    
    }
}

/*
    Author: numbworks@gmail.com
    Last Update: 25.06.2021
*/