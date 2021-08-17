using System.Collections.Generic;

namespace NW.WIDJobs.BulletPoints
{
    /// <summary>Collects all the helper methods related to <see cref="BulletPoint"/>.</summary>
    public interface IBulletPointManager
    {

        /// <summary>
        /// Returns pre-labeled examples of <see cref="BulletPoint"/> that can be helpful to categorize new bullet point texts.
        /// </summary>
        List<BulletPoint> GetPreLabeledExamples();

    }
}

/*
    Author: numbworks@gmail.com
    Last Update: 09.05.2021
*/