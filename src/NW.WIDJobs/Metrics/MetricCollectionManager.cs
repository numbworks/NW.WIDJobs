using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace NW.WIDJobs
{
    /// <inheritdoc cref="IMetricCollectionManager"/>
    public class MetricCollectionManager : IMetricCollectionManager
    {

        #region Fields
        #endregion

        #region Properties

        public static string FormatDate { get; } = "yyyy-MM-dd";
        public static string FormatNull { get; } = "null";
        public static Func<uint, uint, double?> CalculatePercentage { get; } =
            (value, totalValue) => {

                if (value == 0)
                    return value;
                if (totalValue == 0)
                    return null;

                return Math.Round(value / (double)totalValue * 100, 2);

            };
        public static Func<double, string> FormatPercentage { get; } =
            (value) =>
            {

                CultureInfo culture = CultureInfo.CreateSpecificCulture("en-US");

                return $"{value.ToString(culture)}%";

            };

        #endregion

        #region Constructors

        /// <summary>Initializes a <see cref="MetricCollectionManager"/> instance.</summary>
        public MetricCollectionManager() { }

        #endregion

        #region Methods_public

        public MetricCollection Calculate(Exploration exploration)
        {

            Validator.ValidateObject(exploration, nameof(exploration));
            Validator.ValidateList(exploration.JobPostings, nameof(exploration.JobPostings));
            Validator.ValidateList(exploration.JobPostingsExtended, nameof(exploration.JobPostingsExtended));

            Dictionary<string, uint> itemsByWorkAreaWithoutZone
                = GroupItemsByWorkAreaWithoutZone(exploration.JobPostings);
            Dictionary<string, uint> itemsByCreateDate
                = GroupJobPostingsByPostingCreated(exploration.JobPostings);
            Dictionary<string, uint> itemsByApplicationDate
                = GroupItemsByApplicationDate(exploration.JobPostings);
            Dictionary<string, uint> itemsByEmployerName
                = GroupItemsByEmployerName(exploration.JobPostingsExtended);
            Dictionary<string, uint> itemsByNumberOfOpenings
                = GroupItemsByNumberOfOpenings(exploration.JobPostingsExtended);
            Dictionary<string, uint> itemsByAdvertisementPublishDate
                = GroupItemsByAdvertisementPublishDate(exploration.JobPostingsExtended);
            Dictionary<string, uint> itemsByApplicationDeadline
                = GroupItemsByApplicationDeadline(exploration.JobPostingsExtended);
            Dictionary<string, uint> itemsByStartDateOfEmployment
                = GroupItemsByStartDateOfEmployment(exploration.JobPostingsExtended);
            Dictionary<string, uint> itemsByReference
                = GroupItemsByReference(exploration.JobPostingsExtended);
            Dictionary<string, uint> itemsByPosition
                = GroupItemsByPosition(exploration.JobPostingsExtended);
            Dictionary<string, uint> itemsByTypeOfEmployment
                = GroupItemsByTypeOfEmployment(exploration.JobPostingsExtended);
            Dictionary<string, uint> itemsByContact
                = GroupItemsByContact(exploration.JobPostingsExtended);
            Dictionary<string, uint> itemsByEmployerAddress
                = GroupItemsByEmployerAddress(exploration.JobPostingsExtended);
            Dictionary<string, uint> itemsByHowToApply
                = GroupItemsByHowToApply(exploration.JobPostingsExtended);
            Dictionary<string, uint> descriptionLengthByPageItemId
                = SumDescriptionLengthByPageItemId(exploration.JobPostingsExtended);
            Dictionary<string, uint> bulletPointsByPageItemId
                = SumBulletPointsByPageItemId(exploration.JobPostingsExtended);

            uint totalBulletPoints = SumBulletPoints(exploration.JobPostingsExtended);

            MetricCollection metrics = new MetricCollection(
                runId: exploration.RunId,
                totalJobPages: (uint)exploration.JobPages.Count,
                totalJobPostings: (uint)exploration.JobPostings.Count,
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

        private Dictionary<string, uint> GroupJobPostingsByHiringOrgName(List<JobPosting> jobPostings)
        {

            /*
                - ...
            */

            var results =
                    from jobPosting in jobPostings
                    group jobPosting by jobPosting.HiringOrgName into groups
                    select new
                    {
                        HiringOrgName = groups.Key ?? FormatNull, 
                        JobPostings = groups.Count()
                    };

            results = results.OrderByDescending(result => result.JobPostings);

            Dictionary<string, uint> grouped
                = results.ToDictionary(
                                result => result.HiringOrgName,
                                result => (uint)result.JobPostings);

            return grouped;

        }
        private Dictionary<string, uint> GroupJobPostingsByWorkPlaceAddress(List<JobPosting> jobPostings)
        {

            /*
                - ...
            */

            var results =
                    from jobPosting in jobPostings
                    group jobPosting by jobPosting.WorkPlaceAddress into groups
                    select new
                    {
                        WorkPlaceAddress = groups.Key ?? FormatNull,
                        JobPostings = groups.Count()
                    };

            results = results.OrderByDescending(result => result.JobPostings);

            Dictionary<string, uint> grouped
                = results.ToDictionary(
                                result => result.WorkPlaceAddress,
                                result => (uint)result.JobPostings);

            return grouped;

        }
        private Dictionary<string, uint> GroupJobPostingsByWorkPlacePostalCode(List<JobPosting> jobPostings)
        {

            /*
                - ...
            */

            var results =
                    from jobPosting in jobPostings
                    group jobPosting by jobPosting.WorkPlacePostalCode into groups
                    select new
                    {
                        WorkPlacePostalCode = groups.Key?.ToString() ?? FormatNull,
                        JobPostings = groups.Count()
                    };

            results = results.OrderByDescending(result => result.JobPostings);

            Dictionary<string, uint> grouped
                = results.ToDictionary(
                                result => result.WorkPlacePostalCode,
                                result => (uint)result.JobPostings);

            return grouped;

        }
        private Dictionary<string, uint> GroupJobPostingsByWorkPlaceCity(List<JobPosting> jobPostings)
        {

            /*
                - ...
            */

            var results =
                    from jobPosting in jobPostings
                    group jobPosting by jobPosting.WorkPlaceCity into groups
                    select new
                    {
                        WorkPlaceCity = groups.Key ?? FormatNull,
                        JobPostings = groups.Count()
                    };

            results = results.OrderByDescending(result => result.JobPostings);

            Dictionary<string, uint> grouped
                = results.ToDictionary(
                                result => result.WorkPlaceCity,
                                result => (uint)result.JobPostings);

            return grouped;

        }
        private Dictionary<string, uint> GroupJobPostingsByPostingCreated(List<JobPosting> jobPostings)
        {

            /*
    			- ("2021-05-21", 57)
			    - ("2021-05-10", 23)
			    - ...
            */

            var results =
                    from jobPosting in jobPostings
                    group jobPosting by jobPosting.PostingCreated into groups
                    select new
                    {
                        PostingCreated = groups.Key.ToString(FormatDate), // This is never null, so we don't handle that case.
                        JobPostings = groups.Count()
                    };

            results = results.OrderByDescending(result => result.PostingCreated);

            Dictionary<string, uint> grouped
                = results.ToDictionary(
                                result => result.PostingCreated,
                                result => (uint)result.JobPostings);

            return grouped;

        }
        private Dictionary<string, uint> GroupJobPostingsByLastDateApplication(List<JobPosting> jobPostings)
        {

            /*
    			- ("2021-05-21", 57)
			    - ("2021-05-10", 23)
			    - ...
            */

            var results =
                    from jobPosting in jobPostings
                    group jobPosting by jobPosting.LastDateApplication into groups
                    select new
                    {
                        LastDateApplication = groups.Key.ToString(FormatDate), // This is never null, so we don't handle that case.
                        JobPostings = groups.Count()
                    };

            results = results.OrderByDescending(result => result.LastDateApplication);

            Dictionary<string, uint> grouped
                = results.ToDictionary(
                                result => result.LastDateApplication,
                                result => (uint)result.JobPostings);

            return grouped;

        }
        private Dictionary<string, uint> GroupJobPostingsByUrl(List<JobPosting> jobPostings)
        {

            /*
                - ...
            */

            var results =
                    from jobPosting in jobPostings
                    group jobPosting by jobPosting.Url into groups
                    select new
                    {
                        Url = groups.Key, // This is never null, so we don't handle that case.
                        JobPostings = groups.Count()
                    };

            results = results.OrderByDescending(result => result.JobPostings);

            Dictionary<string, uint> grouped
                = results.ToDictionary(
                                result => result.Url,
                                result => (uint)result.JobPostings);

            return grouped;

        }
        private Dictionary<string, uint> GroupJobPostingsByRegion(List<JobPosting> jobPostings)
        {

            /*
                - ...
            */

            var results =
                    from jobPosting in jobPostings
                    group jobPosting by jobPosting.Region into groups
                    select new
                    {
                        Region = groups.Key ?? FormatNull,
                        JobPostings = groups.Count()
                    };

            results = results.OrderByDescending(result => result.JobPostings);

            Dictionary<string, uint> grouped
                = results.ToDictionary(
                                result => result.Region,
                                result => (uint)result.JobPostings);

            return grouped;

        }
        private Dictionary<string, uint> GroupJobPostingsByMunicipality(List<JobPosting> jobPostings)
        {

            /*
                - ...
            */

            var results =
                    from jobPosting in jobPostings
                    group jobPosting by jobPosting.Municipality into groups
                    select new
                    {
                        Municipality = groups.Key ?? FormatNull,
                        JobPostings = groups.Count()
                    };

            results = results.OrderByDescending(result => result.JobPostings);

            Dictionary<string, uint> grouped
                = results.ToDictionary(
                                result => result.Municipality,
                                result => (uint)result.JobPostings);

            return grouped;

        }
        private Dictionary<string, uint> GroupJobPostingsByCountry(List<JobPosting> jobPostings)
        {

            /*
                - ...
            */

            var results =
                    from jobPosting in jobPostings
                    group jobPosting by jobPosting.Country into groups
                    select new
                    {
                        Country = groups.Key ?? FormatNull,
                        JobPostings = groups.Count()
                    };

            results = results.OrderByDescending(result => result.JobPostings);

            Dictionary<string, uint> grouped
                = results.ToDictionary(
                                result => result.Country,
                                result => (uint)result.JobPostings);

            return grouped;

        }
        private Dictionary<string, uint> GroupJobPostingsByEmploymentType(List<JobPosting> jobPostings)
        {

            /*
                - ...
            */

            var results =
                    from jobPosting in jobPostings
                    group jobPosting by jobPosting.EmploymentType into groups
                    select new
                    {
                        EmploymentType = groups.Key ?? FormatNull,
                        JobPostings = groups.Count()
                    };

            results = results.OrderByDescending(result => result.JobPostings);

            Dictionary<string, uint> grouped
                = results.ToDictionary(
                                result => result.EmploymentType,
                                result => (uint)result.JobPostings);

            return grouped;

        }
        private Dictionary<string, uint> GroupJobPostingsByWorkHours(List<JobPosting> jobPostings)
        {

            /*
                - ...
            */

            var results =
                    from jobPosting in jobPostings
                    group jobPosting by jobPosting.WorkHours into groups
                    select new
                    {
                        WorkHours = groups.Key ?? FormatNull,
                        JobPostings = groups.Count()
                    };

            results = results.OrderByDescending(result => result.JobPostings);

            Dictionary<string, uint> grouped
                = results.ToDictionary(
                                result => result.WorkHours,
                                result => (uint)result.JobPostings);

            return grouped;

        }
        private Dictionary<string, uint> GroupJobPostingsByOccupation(List<JobPosting> jobPostings)
        {

            /*
                - ...
            */

            var results =
                    from jobPosting in jobPostings
                    group jobPosting by jobPosting.Occupation into groups
                    select new
                    {
                        Occupation = groups.Key ?? FormatNull,
                        JobPostings = groups.Count()
                    };

            results = results.OrderByDescending(result => result.JobPostings);

            Dictionary<string, uint> grouped
                = results.ToDictionary(
                                result => result.Occupation,
                                result => (uint)result.JobPostings);

            return grouped;

        }
        private Dictionary<string, uint> GroupJobPostingsByWorkplaceId(List<JobPosting> jobPostings)
        {

            /*
                - ...
            */

            var results =
                    from jobPosting in jobPostings
                    group jobPosting by jobPosting.WorkplaceId into groups
                    select new
                    {
                        WorkplaceId = groups.Key.ToString(), // This is never null, so we don't handle that case.
                        JobPostings = groups.Count()
                    };

            results = results.OrderByDescending(result => result.JobPostings);

            Dictionary<string, uint> grouped
                = results.ToDictionary(
                                result => result.WorkplaceId,
                                result => (uint)result.JobPostings);

            return grouped;

        }
        private Dictionary<string, uint> GroupJobPostingsByOrganisationId(List<JobPosting> jobPostings)
        {

            /*
                - ...
            */

            var results =
                    from jobPosting in jobPostings
                    group jobPosting by jobPosting.OrganisationId into groups
                    select new
                    {
                        OrganisationId = groups.Key?.ToString() ?? FormatNull,
                        JobPostings = groups.Count()
                    };

            results = results.OrderByDescending(result => result.JobPostings);

            Dictionary<string, uint> grouped
                = results.ToDictionary(
                                result => result.OrganisationId,
                                result => (uint)result.JobPostings);

            return grouped;

        }
        private Dictionary<string, uint> GroupJobPostingsByHiringOrgCVR(List<JobPosting> jobPostings)
        {

            /*
                - ...
            */

            var results =
                    from jobPosting in jobPostings
                    group jobPosting by jobPosting.HiringOrgCVR into groups
                    select new
                    {
                        HiringOrgCVR = groups.Key.ToString(), // This is never null, so we don't handle that case.
                        JobPostings = groups.Count()
                    };

            results = results.OrderByDescending(result => result.JobPostings);

            Dictionary<string, uint> grouped
                = results.ToDictionary(
                                result => result.HiringOrgCVR,
                                result => (uint)result.JobPostings);

            return grouped;

        }
        private Dictionary<string, uint> GroupJobPostingsByWorkPlaceCityWithoutZone(List<JobPosting> jobPostings)
        {

            /*
                - ...
            */

            var results =
                    from jobPosting in jobPostings
                    group jobPosting by jobPosting.WorkPlaceCityWithoutZone into groups
                    select new
                    {
                        WorkPlaceCityWithoutZone = groups.Key?.ToString() ?? FormatNull,
                        JobPostings = groups.Count()
                    };

            results = results.OrderByDescending(result => result.JobPostings);

            Dictionary<string, uint> grouped
                = results.ToDictionary(
                                result => result.WorkPlaceCityWithoutZone,
                                result => (uint)result.JobPostings);

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