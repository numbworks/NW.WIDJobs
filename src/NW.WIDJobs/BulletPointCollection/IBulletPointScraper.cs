using System.Collections.Generic;

namespace NW.WIDJobs
{
    public interface IBulletPointScraper
    {
        HashSet<string> TryExtract(string description);
    }
}

/*
    Author: numbworks@gmail.com
    Last Update: 09.05.2021
*/