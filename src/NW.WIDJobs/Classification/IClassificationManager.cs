using System.Collections.Generic;
using NW.WIDJobs.Database;
using NW.NGramTextClassification;

namespace NW.WIDJobs.Classification
{
    /// <summary>Collects all the helper methods related to text classification.</summary>
    public interface IClassificationManager
    {

        /// <summary>Attempts to predict the language of <paramref name="text"/> by learning from the examples provided by <see cref="GetPreLabeledExamplesForLanguage"/>.</summary>
        string PredictLanguage(string text);

        /// <summary>Attempts to predict the type of <paramref name="bulletPoint"/> by learning from the examples provided by <see cref="GetPreLabeledExamplesForBulletPointType"/>.</summary>
        string PredictBulletPointType(string bulletPoint);

        /// <summary>Returns a collection of pre-labeled examples for language prediction.</summary>
        List<LabeledExample> GetPreLabeledExamplesForLanguage();

        /// <summary>Returns a collection of pre-labeled examples for <see cref="BulletPointEntity.Type"/> prediction.</summary>
        List<LabeledExample> GetPreLabeledExamplesForBulletPointType();

    }
}

/*
    Author: numbworks@gmail.com
    Last Update: 14.09.2021
*/