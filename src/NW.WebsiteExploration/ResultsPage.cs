using System;
using System.Collections.Generic;

namespace NW.WebsiteExploration
{
    public class ResultsPage
    {

        // Fields
        // Properties
        public string AbsoluteUrl { get; set; }
        public UInt16 PageNumber { get; set; }
        public List<ResultsPageItem> Items { get; set; }
        public Boolean IsLastForCurrentExploration { get; set; } = false;
        public Boolean IsLastOnWebsite { get; set; } = false;

        // Constructors
        // Methods
        public override string ToString()
        {

            // Output: { AbsoluteUrl: '', PageNumber: '0', Items: '0', IsLastForCurrentExploration: 'False', IsLastOnWebsite: 'False' }

            int intItems = 0;
            if (Items != null)
                intItems = Items.Count;

            string strTemplate = "{{ {0}: '{1}', {2}: '{3}', {4}: '{5}', {6}: '{7}', {8}: '{9}' }}";
            return String.Format(strTemplate,
                nameof(AbsoluteUrl),
                AbsoluteUrl,
                nameof(PageNumber),
                PageNumber.ToString(),
                nameof(Items),
                intItems.ToString(),
                nameof(IsLastForCurrentExploration),
                IsLastForCurrentExploration.ToString(),
                nameof(IsLastOnWebsite),
                IsLastOnWebsite.ToString()
                );

        }

    }
}

/*
 *
 *  Author: numbworks@gmail.com
 *  Last Update: 22.09.2018
 * 
 */