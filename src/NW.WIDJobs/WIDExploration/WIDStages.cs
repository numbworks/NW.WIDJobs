namespace NW.WIDJobs
{
    /// <summary>The depth of the exploration.</summary>
    public enum WIDStages
    {

        /// <summary>
        /// Retrieves <see cref="WIDExploration.TotalResults"/> and <see cref="WIDExploration.TotalEstimatedPages"/>.
        /// </summary>
        Stage1_OnlyMetrics,

        /// <summary>
        /// Retrieves <see cref="WIDExploration.TotalResults"/>, <see cref="WIDExploration.TotalEstimatedPages"/>, <see cref="WIDExploration.Pages"/> and <see cref="WIDExploration.PageItems"/>.
        /// </summary>
        Stage2_UpToAllPageItems,

        /// <summary>
        /// Retrieves <see cref="WIDExploration.TotalResults"/>, <see cref="WIDExploration.TotalEstimatedPages"/>, <see cref="WIDExploration.Pages"/>, <see cref="WIDExploration.PageItems"/> and <see cref="WIDExploration.PageItemsExtended"/>.
        /// </summary>
        Stage3_UpToAllPageItemsExtended

    }
}

/*
    Author: numbworks@gmail.com
    Last Update: 19.05.2021
*/