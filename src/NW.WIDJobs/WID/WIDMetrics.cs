using System;
using System.Collections.Generic;
using System.Linq;

namespace NW.WIDJobs
{
    /// <summary>The metrics of an exploration on <see href="http://www.workindenmark.dk">WorkInDenmark</see>.</summary>
    public class WIDMetrics
    {

        #region Fields
        #endregion

        #region Properties

        public string RunId { get; }
        public uint TotalPages { get; }
        public uint TotalItems { get; }
        public Dictionary<string, uint> ItemsByWorkAreaWithoutZone { get; }
        public Dictionary<string, uint> ItemsByCreateDate { get; }
        public Dictionary<string, uint> ItemsByApplicationDate { get; }
        public Dictionary<string, uint> ItemsByEmployerName { get; }
        public Dictionary<string, uint> ItemsByNumberOfOpenings { get; }
        public Dictionary<string, uint> ItemsByAdvertisementPublishDate { get; }
        public Dictionary<string, uint> ItemsByApplicationDeadline { get; }
        public Dictionary<string, uint> ItemsByStartDateOfEmployment { get; }
        public Dictionary<string, uint> ItemsByReference { get; }
        public Dictionary<string, uint> ItemsByPosition { get; }
        public Dictionary<string, uint> ItemsByTypeOfEmployment { get; }
        public Dictionary<string, uint> ItemsByContact { get; }
        public Dictionary<string, uint> ItemsByEmployerAddress { get; }
        public Dictionary<string, uint> ItemsByHowToApply { get; }
        public Dictionary<string, uint> BulletPointsByPageItemId { get; }
        public uint TotalBulletPoints { get; }

        #endregion

        #region Constructors

        ///<summary>Initializes a <see cref="WIDMetrics"/> instance.</summary>
        public WIDMetrics(
            string runId,
            uint totalPages,
            uint totalItems,
            Dictionary<string, uint> itemsByWorkAreaWithoutZone,
            Dictionary<string, uint> itemsByCreateDate,
            Dictionary<string, uint> itemsByApplicationDate,
            Dictionary<string, uint> itemsByEmployerName,
            Dictionary<string, uint> itemsByNumberOfOpenings,
            Dictionary<string, uint> itemsByAdvertisementPublishDate,
            Dictionary<string, uint> itemsByApplicationDeadline,
            Dictionary<string, uint> itemsByStartDateOfEmployment,
            Dictionary<string, uint> itemsByReference,
            Dictionary<string, uint> itemsByPosition,
            Dictionary<string, uint> itemsByTypeOfEmployment,
            Dictionary<string, uint> itemsByContact,
            Dictionary<string, uint> itemsByEmployerAddress,
            Dictionary<string, uint> itemsByHowToApply,
            Dictionary<string, uint> bulletPointsByPageItemId,
            uint totalBulletPoints
            ) 
        {

            Validator.ValidateStringNullOrWhiteSpace(runId, nameof(runId));
            Validator.ThrowIfLessThanOne(totalPages, nameof(totalPages));
            Validator.ThrowIfLessThanOne(totalItems, nameof(totalItems));
            Validator.ValidateList(itemsByWorkAreaWithoutZone.ToList(), nameof(itemsByWorkAreaWithoutZone));
            Validator.ValidateList(itemsByCreateDate.ToList(), nameof(itemsByCreateDate));
            Validator.ValidateList(itemsByApplicationDate.ToList(), nameof(itemsByApplicationDate));
            Validator.ValidateList(itemsByEmployerName.ToList(), nameof(itemsByEmployerName));
            Validator.ValidateList(itemsByNumberOfOpenings.ToList(), nameof(itemsByNumberOfOpenings));
            Validator.ValidateList(itemsByAdvertisementPublishDate.ToList(), nameof(itemsByAdvertisementPublishDate));
            Validator.ValidateList(itemsByApplicationDeadline.ToList(), nameof(itemsByApplicationDeadline));
            Validator.ValidateList(itemsByStartDateOfEmployment.ToList(), nameof(itemsByStartDateOfEmployment));
            Validator.ValidateList(itemsByReference.ToList(), nameof(itemsByReference));
            Validator.ValidateList(itemsByPosition.ToList(), nameof(itemsByPosition));
            Validator.ValidateList(itemsByTypeOfEmployment.ToList(), nameof(itemsByTypeOfEmployment));
            Validator.ValidateList(itemsByContact.ToList(), nameof(itemsByContact));
            Validator.ValidateList(itemsByEmployerAddress.ToList(), nameof(itemsByEmployerAddress));
            Validator.ValidateList(itemsByHowToApply.ToList(), nameof(itemsByHowToApply));
            Validator.ValidateList(bulletPointsByPageItemId.ToList(), nameof(bulletPointsByPageItemId));

            RunId = runId;
            TotalPages = totalPages;
            TotalItems = totalItems;
            ItemsByWorkAreaWithoutZone = itemsByWorkAreaWithoutZone;
            ItemsByCreateDate = itemsByCreateDate;
            ItemsByApplicationDate = itemsByApplicationDate;
            ItemsByEmployerName = itemsByEmployerName;
            ItemsByNumberOfOpenings = itemsByNumberOfOpenings;
            ItemsByAdvertisementPublishDate = itemsByAdvertisementPublishDate;
            ItemsByApplicationDeadline = itemsByApplicationDeadline;
            ItemsByStartDateOfEmployment = itemsByStartDateOfEmployment;
            ItemsByReference = itemsByReference;
            ItemsByPosition = itemsByPosition;
            ItemsByTypeOfEmployment = itemsByTypeOfEmployment;
            ItemsByContact = itemsByContact;
            ItemsByEmployerAddress = itemsByEmployerAddress;
            ItemsByHowToApply = itemsByHowToApply;
            BulletPointsByPageItemId = bulletPointsByPageItemId;
            TotalBulletPoints = totalBulletPoints;

        }

        #endregion

        #region Methods_public
        #endregion

    }
}

/*
    Author: numbworks@gmail.com
    Last Update: 27.05.2021
*/