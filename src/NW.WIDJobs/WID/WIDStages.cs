namespace NW.WIDJobs
{
    /// <summary>The depth of a <see cref="WIDExploration"/>.</summary>
    public enum WIDStages
    {

        /// <summary>
        /// Retrieves <see cref="WIDExploration.TotalResultCount"/> and <see cref="WIDExploration.TotalJobPages"/>.
        /// </summary>
        Stage1_OnlyMetrics,

        /// <summary>
        /// Retrieves <see cref="WIDExploration.TotalResultCount"/>, <see cref="WIDExploration.TotalJobPages"/>, <see cref="WIDExploration.JobPages"/> and <see cref="WIDExploration.JobPostings"/>.
        /// </summary>
        Stage2_UpToAllJobPostings,

        /// <summary>
        /// Retrieves <see cref="WIDExploration.TotalResultCount"/>, <see cref="WIDExploration.TotalJobPages"/>, <see cref="WIDExploration.JobPages"/>, <see cref="WIDExploration.JobPostings"/> and <see cref="WIDExploration.JobPostingsExtended"/>.
        /// </summary>
        Stage3_UpToAllJobPostingsExtended

    }
}

/*
    Author: numbworks@gmail.com
    Last Update: 08.08.2021
*/
