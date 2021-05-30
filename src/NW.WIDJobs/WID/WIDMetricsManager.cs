using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace NW.WIDJobs
{
    /// <inheritdoc cref="IWIDMetricsManager"/>
    public class WIDMetricsManager : IWIDMetricsManager
    {

        #region Fields
        #endregion

        #region Properties
        public static string FormatDate { get; } = "yyyy-MM-dd";
        public static string FormatNull { get; } = "null";
        public static Func<uint, uint, double?> CalculatePercentage =
            (value, totalValue) => {

                if (value == 0)
                    return value;
                if (totalValue == 0)
                    return null;

                return Math.Round(value / (double)totalValue * 100, 2);

            };
        public static Func<double, string> FormatPercentage =
            (value) =>
            {

                CultureInfo culture = CultureInfo.CreateSpecificCulture("en-US");

                return $"{value.ToString(culture)}%";

            };

        #endregion

        #region Constructors

        /// <summary>Initializes a <see cref="WIDMetricsManager"/> instance.</summary>
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
            Dictionary<string, uint> itemsByContact
                = GroupItemsByContact(exploration.PageItemsExtended);
            Dictionary<string, uint> itemsByEmployerAddress
                = GroupItemsByEmployerAddress(exploration.PageItemsExtended);
            Dictionary<string, uint> itemsByHowToApply
                = GroupItemsByHowToApply(exploration.PageItemsExtended);
            Dictionary<string, uint> descriptionLengthByPageItemId
                = SumDescriptionLengthByPageItemId(exploration.PageItemsExtended);
            Dictionary<string, uint> bulletPointsByPageItemId
                = SumBulletPointsByPageItemId(exploration.PageItemsExtended);

            uint totalBulletPoints = SumBulletPoints(exploration.PageItemsExtended);

            WIDMetrics metrics = new WIDMetrics(
                runId: exploration.RunId,
                totalPages: (uint)exploration.Pages.Count,
                totalItems: (uint)exploration.PageItems.Count,
                itemsByWorkAreaWithoutZone: itemsByWorkAreaWithoutZone,
                itemsByCreateDate: itemsByCreateDate,
                itemsByApplicationDate: itemsByApplicationDate,
                itemsByEmployerName: itemsByEmployerName,
                itemsByNumberOfOpenings: itemsByNumberOfOpenings,
                itemsByAdvertisementPublishDate: itemsByAdvertisementPublishDate,
                itemsByApplicationDeadline: itemsByApplicationDeadline,
                itemsByStartDateOfEmployment: itemsByStartDateOfEmployment,
                itemsByReference: itemsByReference,
                itemsByPosition: itemsByPosition,
                itemsByTypeOfEmployment: itemsByTypeOfEmployment,
                itemsByContact: itemsByContact,
                itemsByEmployerAddress: itemsByEmployerAddress,
                itemsByHowToApply: itemsByHowToApply,
                descriptionLengthByPageItemId: descriptionLengthByPageItemId,
                bulletPointsByPageItemId: bulletPointsByPageItemId,
                totalBulletPoints: totalBulletPoints
                );

            return metrics;

        }
        public Dictionary<string, string> ConvertToPercentages(Dictionary<string, uint> dict)
        {

            /*
    			- ("København", 45) => ("København", "73.77%")
	    		- ("Nordborg", 12) => ("Nordborg", "19.67%")
		    	- ("Vejen", 4) => ("Vejen", "6.56%")

                TotalValue: 61
                % = Value / TotalValue * 100             
             */

            Validator.ValidateList(dict?.ToList(), nameof(dict));

            uint totalValue = (uint)dict.Sum(item => item.Value);

            Dictionary<string, string> percentages = new Dictionary<string, string>();
            foreach (KeyValuePair<string, uint> item in dict)
            {

                double value = (double)CalculatePercentage.Invoke(item.Value, totalValue); // Can't be null.
                string percentage = FormatPercentage.Invoke(value);

                percentages.Add(item.Key, percentage);

            }

            return percentages;

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

            results = results.OrderByDescending(result => result.Items);

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

            results = results.OrderByDescending(result => result.CreateDate);

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

            results = results.OrderByDescending(result => result.ApplicationDate);

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

            results = results.OrderByDescending(result => result.Items);

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

            results = results.OrderByDescending(result => result.Items);

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

            results = results.OrderByDescending(result => result.AdvertisementPublishDate);

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

            results = results.OrderByDescending(result => result.ApplicationDeadline);

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

            results = results.OrderByDescending(result => result.StartDateOfEmployment);

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

            results = results.OrderByDescending(result => result.Items);

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

            results = results.OrderByDescending(result => result.Items);

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

            results = results.OrderByDescending(result => result.Items);

            Dictionary<string, uint> grouped
                = results.ToDictionary(
                                result => result.TypeOfEmployment,
                                result => (uint)result.Items);

            return grouped;

        }
        private Dictionary<string, uint> GroupItemsByContact(List<PageItemExtended> pageItemsExtended)
        {

            var results =
                    from item in pageItemsExtended
                    group item by item.Contact into groups
                    select new
                    {
                        Contact = groups.Key ?? FormatNull,
                        Items = groups.Count()
                    };

            results = results.OrderByDescending(result => result.Items);

            Dictionary<string, uint> grouped
                = results.ToDictionary(
                                result => result.Contact,
                                result => (uint)result.Items);

            return grouped;

        }
        private Dictionary<string, uint> GroupItemsByEmployerAddress(List<PageItemExtended> pageItemsExtended)
        {

            var results =
                    from item in pageItemsExtended
                    group item by item.EmployerAddress into groups
                    select new
                    {
                        EmployerAddress = groups.Key ?? FormatNull,
                        Items = groups.Count()
                    };

            results = results.OrderByDescending(result => result.Items);

            Dictionary<string, uint> grouped
                = results.ToDictionary(
                                result => result.EmployerAddress,
                                result => (uint)result.Items);

            return grouped;

        }
        private Dictionary<string, uint> GroupItemsByHowToApply(List<PageItemExtended> pageItemsExtended)
        {

            var results =
                    from item in pageItemsExtended
                    group item by item.HowToApply into groups
                    select new
                    {
                        HowToApply = groups.Key ?? FormatNull,
                        Items = groups.Count()
                    };

            results = results.OrderByDescending(result => result.Items);

            Dictionary<string, uint> grouped
                = results.ToDictionary(
                                result => result.HowToApply,
                                result => (uint)result.Items);

            return grouped;

        }
        private Dictionary<string, uint> SumDescriptionLengthByPageItemId(List<PageItemExtended> pageItemsExtended)
        {

            /*
                - ("8144099sitereliabilityengineer, 985)
                - ("8144114unpaidinternshipsales, 992)
                - ("8144115learningsalesfulltimestudentposition, 1003)
                - ...
            */

            var results =
                    from item in pageItemsExtended
                    group item.Description.Length by item.PageItem.PageItemId into groups
                    select new
                    {
                        PageItemId = groups.Key, // This is never null, so we don't handle that case.
                        DescriptionLength = groups.Sum()
                    };

            results = results.OrderByDescending(result => result.DescriptionLength);

            Dictionary<string, uint> grouped
                = results.ToDictionary(
                                result => result.PageItemId,
                                result => (uint)result.DescriptionLength);

            return grouped;

        }
        private Dictionary<string, uint> SumBulletPointsByPageItemId(List<PageItemExtended> pageItemsExtended)
        {

            /*
                - ("8144099sitereliabilityengineer, 10)
                - ("8144114unpaidinternshipsales, 6)
                - ("8144115learningsalesfulltimestudentposition, 0)
                - ...
            */

            var results =
                    from item in pageItemsExtended
                    group item.DescriptionBulletPoints.Count by item.PageItem.PageItemId into groups
                    select new
                    {
                        PageItemId = groups.Key, // This is never null, so we don't handle that case.
                        BulletPoints = groups.Sum()
                    };

            results = results.OrderByDescending(result => result.BulletPoints);

            Dictionary<string, uint> grouped
                = results.ToDictionary(
                                result => result.PageItemId,
                                result => (uint)result.BulletPoints);

            return grouped;

        }
        private uint SumBulletPoints(List<PageItemExtended> pageItemsExtended)
        {

            uint totalBulletPoints = 0;
            foreach (PageItemExtended pageItemExtended in pageItemsExtended)
                // This is never null, so we don't handle that case.
                totalBulletPoints += (uint)pageItemExtended.DescriptionBulletPoints.Count; 

            return totalBulletPoints;

        }

        #endregion

    }
}

/*
    Author: numbworks@gmail.com
    Last Update: 28.05.2021
*/