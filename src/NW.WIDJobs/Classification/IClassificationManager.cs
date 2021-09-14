using System;
using System.Collections.Generic;
using NW.NGramTextClassification;

namespace NW.WIDJobs.Classification
{
    /// <summary>Collects all the helper methods related to text classification.</summary>
    public interface IClassificationManager
    {

        string EstimateLanguage(string text);
        string EstimateBulletPointLabel(string text);

        List<LabeledExample> GetPreLabeledExamplesForLanguage();

    }
}

/*
    Author: numbworks@gmail.com
    Last Update: 14.09.2021
*/