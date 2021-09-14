using System;
using System.Collections;
using System.Collections.Generic;

namespace NW.WIDJobs.Classification
{
    /// <summary>Collects all the helper methods related to text classification.</summary>
    public interface IClassificationManager
    {

        string EstimateLanguage(string text);
        string EstimateBulletPointLabel(string text);
        Dictionary<string, string> GetLanguageTrainingDataset();

    }
}

/*
    Author: numbworks@gmail.com
    Last Update: 14.09.2021
*/