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
        public static string FormatDate { get; } = "yyyy-MM-dd";
        public static string FormatNull { get; } = "null";

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
            // How to validate bulletpoints?

            Dictionary<string, uint> itemsByWorkAreaWithoutZone
                = GroupItemsByWorkAreaWithoutZone(exploration.PageItems);
            Dictionary<string, uint> itemsByCreateDate
                = GroupItemsByCreateDate(exploration.PageItems);
            Dictionary<string, uint> itemsByApplicationDate
                = GroupItemsByApplicationDate(exploration.PageItems);
            Dictionary<string, uint> itemsByEmployerName
                = GroupItemsByEmployerName(exploration.PageItemsExtended);
            Dictionary<string, uint> itemsByNumberOfOpenings
                = GroupItemsByNumberOfOpenings(exploration.PageItemsExtended);
            Dictionary<string, uint> itemsByAdvertisementPublishDate
                = GroupItemsByAdvertisementPublishDate(exploration.PageItemsExtended);
            Dictionary<string, uint> itemsByApplicationDeadline
                = GroupItemsByApplicationDeadline(exploration.PageItemsExtended);
            Dictionary<string, uint> itemsByStartDateOfEmployment
                = GroupItemsByStartDateOfEmployment(exploration.PageItemsExtended);
            Dictionary<string, uint> itemsByReference
                = GroupItemsByReference(exploration.PageItemsExtended);
            Dictionary<string, uint> itemsByPosition
                = GroupItemsByPosition(exploration.PageItemsExtended);
            Dictionary<string, uint> itemsByTypeOfEmployment
                = GroupItemsByTypeOfEmployment(exploration.PageItemsExtended);



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

            Dictionary<string, uint> grouped
                = results.ToDictionary(
                                result => result.WorkAreaWithoutZone,
                                result => (uint)result.Items);

            return grouped;

        }
        private Dictionary<string, uint> GroupItemsByCreateDate(List<PageItem> pageItems)
        {

            /*
    			- ("2021-05-21", 57)
			    - ("2021-05-10", 23)
			    - ...
            */

            var results =
                    from item in pageItems
                    group item by item.CreateDate into groups
                    select new
                    {
                        CreateDate = groups.Key.ToString(FormatDate), // This is never null, so we don't handle that case.
                        Items = groups.Count()
                    };

            Dictionary<string, uint> grouped
                = results.ToDictionary(
                                result => result.CreateDate,
                                result => (uint)result.Items);

            return grouped;

        }
        private Dictionary<string, uint> GroupItemsByApplicationDate(List<PageItem> pageItems)
        {

            /*
    			- ("2021-05-21", 57)
			    - ("2021-05-10", 23)
                - ("null", 4)
			    - ...
            */

            var results =
                    from item in pageItems
                    group item by item.ApplicationDate into groups
                    select new
                    {
                        ApplicationDate = groups.Key?.ToString(FormatDate) ?? FormatNull, 
                        Items = groups.Count()
                    };

            Dictionary<string, uint> grouped
                = results.ToDictionary(
                                result => result.ApplicationDate,
                                result => (uint)result.Items);

            return grouped;

        }
        private Dictionary<string, uint> GroupItemsByEmployerName(List<PageItemExtended> pageItemsExtended)
        {

            /*
			    - ("MU.ST ApS", 1)
                - ("null", 4)
			    - ...
            */

            var results =
                    from item in pageItemsExtended
                    group item by item.EmployerName into groups
                    select new
                    {
                        EmployerName = groups.Key ?? FormatNull,
                        Items = groups.Count()
                    };

            Dictionary<string, uint> grouped
                = results.ToDictionary(
                                result => result.EmployerName,
                                result => (uint)result.Items);

            return grouped;

        }
        private Dictionary<string, uint> GroupItemsByNumberOfOpenings(List<PageItemExtended> pageItemsExtended)
        {

            /*
			    - ("1", 1)
                - ("null", 4)
			    - ...
            */

            var results =
                    from item in pageItemsExtended
                    group item by item.NumberOfOpenings into groups
                    select new
                    {
                        NumberOfOpenings = groups.Key?.ToString() ?? FormatNull,
                        Items = groups.Count()
                    };

            Dictionary<string, uint> grouped
                = results.ToDictionary(
                                result => result.NumberOfOpenings,
                                result => (uint)result.Items);

            return grouped;

        }
        private Dictionary<string, uint> GroupItemsByAdvertisementPublishDate(List<PageItemExtended> pageItemsExtended)
        {

            /*
    			- ("2021-05-21", 57)
			    - ("2021-05-10", 23)
                - ("null", 4)
			    - ...
            */

            var results =
                    from item in pageItemsExtended
                    group item by item.AdvertisementPublishDate into groups
                    select new
                    {
                        AdvertisementPublishDate = groups.Key?.ToString(FormatDate) ?? FormatNull,
                        Items = groups.Count()
                    };

            Dictionary<string, uint> grouped
                = results.ToDictionary(
                                result => result.AdvertisementPublishDate,
                                result => (uint)result.Items);

            return grouped;

        }
        private Dictionary<string, uint> GroupItemsByApplicationDeadline(List<PageItemExtended> pageItemsExtended)
        {

            /*
    			- ("2021-05-21", 57)
			    - ("2021-05-10", 23)
                - ("null", 4)
			    - ...
            */

            var results =
                    from item in pageItemsExtended
                    group item by item.ApplicationDeadline into groups
                    select new
                    {
                        ApplicationDeadline = groups.Key?.ToString(FormatDate) ?? FormatNull,
                        Items = groups.Count()
                    };

            Dictionary<string, uint> grouped
                = results.ToDictionary(
                                result => result.ApplicationDeadline,
                                result => (uint)result.Items);

            return grouped;

        }
        private Dictionary<string, uint> GroupItemsByStartDateOfEmployment(List<PageItemExtended> pageItemsExtended)
        {

            /*
    			- ("2021-05-21", 57)
			    - ("2021-05-10", 23)
                - ("null", 4)
			    - ...
            */

            var results =
                    from item in pageItemsExtended
                    group item by item.StartDateOfEmployment into groups
                    select new
                    {
                        StartDateOfEmployment = groups.Key ?? FormatNull,
                        Items = groups.Count()
                    };

            Dictionary<string, uint> grouped
                = results.ToDictionary(
                                result => result.StartDateOfEmployment,
                                result => (uint)result.Items);

            return grouped;

        }
        private Dictionary<string, uint> GroupItemsByReference(List<PageItemExtended> pageItemsExtended)
        {

            var results =
                    from item in pageItemsExtended
                    group item by item.Reference into groups
                    select new
                    {
                        Reference = groups.Key ?? FormatNull,
                        Items = groups.Count()
                    };

            Dictionary<string, uint> grouped
                = results.ToDictionary(
                                result => result.Reference,
                                result => (uint)result.Items);

            return grouped;

        }
        private Dictionary<string, uint> GroupItemsByPosition(List<PageItemExtended> pageItemsExtended)
        {

            var results =
                    from item in pageItemsExtended
                    group item by item.Position into groups
                    select new
                    {
                        Position = groups.Key ?? FormatNull,
                        Items = groups.Count()
                    };

            Dictionary<string, uint> grouped
                = results.ToDictionary(
                                result => result.Position,
                                result => (uint)result.Items);

            return grouped;

        }
        private Dictionary<string, uint> GroupItemsByTypeOfEmployment(List<PageItemExtended> pageItemsExtended)
        {

            var results =
                    from item in pageItemsExtended
                    group item by item.TypeOfEmployment into groups
                    select new
                    {
                        TypeOfEmployment = groups.Key ?? FormatNull,
                        Items = groups.Count()
                    };

            Dictionary<string, uint> grouped
                = results.ToDictionary(
                                result => result.TypeOfEmployment,
                                result => (uint)result.Items);

            return grouped;

        }



        #endregion

    }
}

/*
    Author: numbworks@gmail.com
    Last Update: 26.05.2021
*/