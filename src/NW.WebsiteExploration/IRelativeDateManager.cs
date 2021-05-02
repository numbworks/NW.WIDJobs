using System;

namespace NW.WebsiteExploration
{
    public interface IRelativeDateManager
    {
        DateTime? ConvertToAbsoluteDate(string strRelativeDate, DateTime dtToday = default(DateTime));
    }
}

/*

    Author: numbworks@gmail.com
    Last Update: 23.09.2018

*/