using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace NW.WIDJobs
{
    public class WIDMetricsManager
    {

        #region Fields
        #endregion

        #region Properties
        #endregion

        #region Constructors

        public WIDMetricsManager() { }

        #endregion

        #region Methods_public

        public WIDMetrics Calculate(WIDExploration exploration)
        {

            Validator.ValidateObject(exploration, nameof(exploration));
            Validator.ValidateList(exploration.PageItems, nameof(exploration.PageItems));
            Validator.ValidateList(exploration.PageItemsExtended, nameof(exploration.PageItemsExtended));

            Dictionary<string, uint> itemsByWorkAreaWithoutZone
                = GroupItemsByWorkAreaWithoutZone(exploration.PageItems);


            return null;

        }

        #endregion

        #region Methods_private

        private Dictionary<string, uint> GroupItemsByWorkAreaWithoutZone(List<PageItem> pageItems)
        {

            /*
    			- ("København", 45)
	    		- ("Nordborg", 12)
		    	- ("Vejen", 4)
                - ...
            */

            var results =
                    from item in pageItems
                    group item by item.WorkAreaWithoutZone into groups
                    select new
                    {
                        WorkAreaWithoutZone = groups.Key, // This is never null, so we don't handle that case.
                        Items = groups.Count()
                    };

            Dictionary<string, uint> itemsByWorkAreaWithoutZone
                = results.ToDictionary(
                                t => t.WorkAreaWithoutZone,
                                t => (uint)t.Items);

            return itemsByWorkAreaWithoutZone;

        }


        #endregion

    }
}

/*
    Author: numbworks@gmail.com
    Last Update: 26.05.2021
*/