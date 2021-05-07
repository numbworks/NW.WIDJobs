using System;
using System.Collections.Generic;

namespace NW.WIDJobs
{
    public class Page
    {

        // Fields
        // Properties
        public string AbsoluteUrl { get; set; }
        public ushort PageNumber { get; set; }
        public List<PageItem> Items { get; set; }
        public bool IsLastForCurrentExploration { get; set; } = false;
        public bool IsLastOnWebsite { get; set; } = false;

        // Constructors
        public Page() { }

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
    Author: numbworks@gmail.com
    Last Update: 05.05.2021
*/