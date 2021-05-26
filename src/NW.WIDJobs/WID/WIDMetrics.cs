using System;
using System.Collections.Generic;

namespace NW.WIDJobs
{
    /// <summary>The metrics of an exploration on <see href="http://www.workindenmark.dk">WorkInDenmark</see>.</summary>
    public class WIDMetrics
    {

        #region Fields
        #endregion

        #region Properties

        public string RunId { get; }
        public Dictionary<string, uint> ItemsByWorkAreaWithoutZone { get; }
        public Dictionary<DateTime?, uint> ItemsByCreateDate { get; }
        public Dictionary<DateTime?, uint> ItemsByApplicationDate { get; }
        public Dictionary<string, uint> ItemsByEmployerName { get; }
        public Dictionary<uint?, uint> ItemsByNumberOfOpenings { get; }
        public Dictionary<DateTime?, uint> ItemsByAdvertisementPublishDate { get; }
        public Dictionary<DateTime?, uint> ItemsByApplicationDeadline { get; }
        public Dictionary<DateTime?, uint> ItemsByStartDateOfEmployment { get; }
        public Dictionary<string, uint> ItemsByReference { get; }
        public Dictionary<string, uint> ItemsByPosition { get; }
        public Dictionary<string, uint> ItemsByTypeOfEmployment { get; }
        public Dictionary<string, uint> ItemsByContact { get; }
        public Dictionary<string, uint> ItemsByEmployerAddress { get; }
        public Dictionary<string, uint> ItemsByHowToApply { get; }
        public Dictionary<string, uint> BulletPointsByPageItemId { get; }
        public uint BulletPointsTotal { get; }

        #endregion

        #region Constructors

        ///<summary>Initializes a <see cref="WIDMetrics"/> instance.</summary>
        public WIDMetrics(
            Dictionary<string, uint> itemsByWorkAreaWithoutZone,
            Dictionary<DateTime?, uint> itemsByCreateDate,
            Dictionary<DateTime?, uint> itemsByApplicationDate,
            Dictionary<string, uint> itemsByEmployerName,
            Dictionary<uint?, uint> itemsByNumberOfOpenings,
            Dictionary<DateTime?, uint> itemsByAdvertisementPublishDate,
            Dictionary<DateTime?, uint> itemsByApplicationDeadline,
            Dictionary<DateTime?, uint> itemsByStartDateOfEmployment,
            Dictionary<string, uint> itemsByReference,
            Dictionary<string, uint> itemsByPosition,
            Dictionary<string, uint> itemsByTypeOfEmployment,
            Dictionary<string, uint> itemsByContact,
            Dictionary<string, uint> itemsByEmployerAddress,
            Dictionary<string, uint> itemsByHowToApply,
            Dictionary<string, uint> bulletPointsByPageItemId,
            uint bulletPointsTotal
            ) 
        {

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
            BulletPointsTotal = bulletPointsTotal;

        }

        #endregion

        #region Methods_public
        #endregion

    }
}

/*
    Author: numbworks@gmail.com
    Last Update: 26.05.2021
*/