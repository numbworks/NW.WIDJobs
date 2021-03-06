namespace NW.WIDJobs.Explorations
{
    /// <summary>The depth of a <see cref="Exploration"/>.</summary>
    public enum Stages
    {

        /// <summary>
        /// Retrieves <see cref="Exploration.TotalResultCount"/> and <see cref="Exploration.TotalJobPages"/>.
        /// </summary>
        Stage1_OnlyMetrics = 1,

        /// <summary>
        /// Retrieves <see cref="Exploration.TotalResultCount"/>, <see cref="Exploration.TotalJobPages"/>, <see cref="Exploration.JobPages"/> and <see cref="Exploration.JobPostings"/>.
        /// </summary>
        Stage2_UpToAllJobPostings = 2,

        /// <summary>
        /// Retrieves <see cref="Exploration.TotalResultCount"/>, <see cref="Exploration.TotalJobPages"/>, <see cref="Exploration.JobPages"/>, <see cref="Exploration.JobPostings"/> and <see cref="Exploration.JobPostingsExtended"/>.
        /// </summary>
        Stage3_UpToAllJobPostingsExtended = 3

    }
}

/*
    Author: numbworks@gmail.com
    Last Update: 08.08.2021
*/
