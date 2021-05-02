using System;
using System.Text.RegularExpressions;

namespace NW.WebsiteExploration
{
    public class RelativeDateManager : IRelativeDateManager
    {

        // Fields
        // Properties
        // Constructors	
        public RelativeDateManager() { }

        // Methods
        public DateTime? ConvertToAbsoluteDate(string strRelativeDate, DateTime dtToday = default(DateTime))
        {

            /*
             * Expected:
             * 
             *      4d ago
             *      21h ago
             *      yesterday
             *      ...
             * 
             */

            if (String.IsNullOrEmpty(strRelativeDate)) return null;

            string strPattern = @"\b([0-9]{1,}[d|h|w]{1}( ago))|(yesterday)";
            if (!Regex.IsMatch(strRelativeDate, strPattern)) return null;

            if (dtToday == default(DateTime))
                dtToday = DateTime.Now;

            DateTime? dtAbsolute = null;
            if (strRelativeDate.Contains("h"))
            {

                int intHours = 0;
                Boolean boolStatus = Int32.TryParse(strRelativeDate.Replace("h ago", String.Empty), out intHours);

                if (intHours != 0)
                    dtAbsolute = dtToday.AddHours(intHours * -1); // "21h ago" => <today/yesterday> with exact time
                else
                    dtAbsolute = dtToday.Date; // "<gibberish>h ago" => <today> at 00:00:00:000

            }

            if (strRelativeDate.Contains("d"))
            {

                int intDays = 0;
                Boolean boolStatus = Int32.TryParse(strRelativeDate.Replace("d ago", String.Empty), out intDays);

                if (intDays != 0)
                    dtAbsolute = dtToday.Date.AddDays(intDays * -1); // 4d ago => <4 days ago>

            }

            if (strRelativeDate.Contains("w"))
            {

                int intWeeks = 0;
                Boolean boolStatus = Int32.TryParse(strRelativeDate.Replace("w ago", String.Empty), out intWeeks);

                if (intWeeks != 0)
                    dtAbsolute = dtToday.Date.AddDays((intWeeks * 7) * -1); // 4w ago => <28 days ago>

            }

            if (strRelativeDate == "yesterday")
                dtAbsolute = dtToday.Date.AddDays(-1); // "yesterday" => <yesterday>

            return dtAbsolute;

        }

    }
}

/*

    Author: numbworks@gmail.com
    Last Update: 13.10.2018

*/