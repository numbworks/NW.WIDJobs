using System;
using System.Collections.Generic;
using System.Linq;
using NW.WIDJobs.Validation;

namespace NW.WIDJobs.Metrics
{
    /// <summary>The metrics of an <see cref="Exploration"/>.</summary>
    public class MetricCollection
    {

        #region Fields
        #endregion

        #region Properties

        public string RunId { get; }
        public uint TotalJobPages { get; }
        public uint TotalJobPostings { get; }

        public Dictionary<string, uint> JobPostingsByHiringOrgName { get; }
        public Dictionary<string, uint> JobPostingsByWorkPlaceAddress { get; }
        public Dictionary<string, uint> JobPostingsByWorkPlacePostalCode { get; }
        public Dictionary<string, uint> JobPostingsByWorkPlaceCity { get; }
        public Dictionary<string, uint> JobPostingsByPostingCreated { get; }
        public Dictionary<string, uint> JobPostingsByLastDateApplication { get; }
        public Dictionary<string, uint> JobPostingsByRegion { get; }
        public Dictionary<string, uint> JobPostingsByMunicipality { get; }
        public Dictionary<string, uint> JobPostingsByCountry { get; }
        public Dictionary<string, uint> JobPostingsByEmploymentType { get; }
        public Dictionary<string, uint> JobPostingsByWorkHours { get; }
        public Dictionary<string, uint> JobPostingsByOccupation { get; }
        public Dictionary<string, uint> JobPostingsByWorkplaceId { get; }
        public Dictionary<string, uint> JobPostingsByOrganisationId { get; }
        public Dictionary<string, uint> JobPostingsByHiringOrgCVR { get; }
        public Dictionary<string, uint> JobPostingsByWorkPlaceCityWithoutZone { get; }

        public Dictionary<string, uint> JobPostingsByPublicationStartDate { get; }
        public Dictionary<string, uint> JobPostingsByPublicationEndDate { get; }
        public Dictionary<string, uint> JobPostingsByNumberToFill { get; }
        public Dictionary<string, uint> JobPostingsByContactEmail { get; }
        public Dictionary<string, uint> JobPostingsByContactPersonName { get; }
        public Dictionary<string, uint> JobPostingsByEmploymentDate { get; }
        public Dictionary<string, uint> JobPostingsByApplicationDeadlineDate { get; }
        public Dictionary<string, uint> JobPostingsByBulletPointScenario { get; }

        public Dictionary<string, uint> ResponseLengthByJobPostingId { get; }
        public Dictionary<string, uint> PresentationLengthByJobPostingId { get; }
        public Dictionary<string, uint> ExtendedResponseLengthByJobPostingId { get; }
        public Dictionary<string, uint> HiringOrgDescriptionLengthByJobPostingId { get; }
        public Dictionary<string, uint> PurposeLengthByJobPostingId { get; }
        public Dictionary<string, uint> BulletPointsByJobPostingId { get; }

        public uint TotalBulletPoints { get; }

        #endregion

        #region Constructors

        ///<summary>Initializes a <see cref="MetricCollection"/> instance.</summary>
        public MetricCollection(
            string runId,
            uint totalJobPages,
            uint totalJobPostings,
            Dictionary<string, uint> jobPostingsByHiringOrgName,
            Dictionary<string, uint> jobPostingsByWorkPlaceAddress,
            Dictionary<string, uint> jobPostingsByWorkPlacePostalCode,
            Dictionary<string, uint> jobPostingsByWorkPlaceCity,
            Dictionary<string, uint> jobPostingsByPostingCreated,
            Dictionary<string, uint> jobPostingsByLastDateApplication,
            Dictionary<string, uint> jobPostingsByRegion,
            Dictionary<string, uint> jobPostingsByMunicipality,
            Dictionary<string, uint> jobPostingsByCountry,
            Dictionary<string, uint> jobPostingsByEmploymentType,
            Dictionary<string, uint> jobPostingsByWorkHours,
            Dictionary<string, uint> jobPostingsByOccupation,
            Dictionary<string, uint> jobPostingsByWorkplaceId,
            Dictionary<string, uint> jobPostingsByOrganisationId,
            Dictionary<string, uint> jobPostingsByHiringOrgCVR,
            Dictionary<string, uint> jobPostingsByWorkPlaceCityWithoutZone,
            Dictionary<string, uint> jobPostingsByPublicationStartDate,
            Dictionary<string, uint> jobPostingsByPublicationEndDate,
            Dictionary<string, uint> jobPostingsByNumberToFill,
            Dictionary<string, uint> jobPostingsByContactEmail,
            Dictionary<string, uint> jobPostingsByContactPersonName,
            Dictionary<string, uint> jobPostingsByEmploymentDate,
            Dictionary<string, uint> jobPostingsByApplicationDeadlineDate,
            Dictionary<string, uint> jobPostingsByBulletPointScenario,
            Dictionary<string, uint> responseLengthByJobPostingId,
            Dictionary<string, uint> presentationLengthByJobPostingId,
            Dictionary<string, uint> extendedResponseLengthByJobPostingId,
            Dictionary<string, uint> hiringOrgDescriptionLengthByJobPostingId,
            Dictionary<string, uint> purposeLengthByJobPostingId,
            Dictionary<string, uint> bulletPointsByJobPostingId,
            uint totalBulletPoints
            ) 
        {

            Validator.ValidateStringNullOrWhiteSpace(runId, nameof(runId));
            Validator.ThrowIfLessThanOne(totalJobPages, nameof(totalJobPages));
            Validator.ThrowIfLessThanOne(totalJobPostings, nameof(totalJobPostings));

            Validator.ValidateList(jobPostingsByHiringOrgName?.ToList(), nameof(jobPostingsByHiringOrgName));
            Validator.ValidateList(jobPostingsByWorkPlaceAddress?.ToList(), nameof(jobPostingsByWorkPlaceAddress));
            Validator.ValidateList(jobPostingsByWorkPlacePostalCode?.ToList(), nameof(jobPostingsByWorkPlacePostalCode));
            Validator.ValidateList(jobPostingsByWorkPlaceCity?.ToList(), nameof(jobPostingsByWorkPlaceCity));
            Validator.ValidateList(jobPostingsByPostingCreated?.ToList(), nameof(jobPostingsByPostingCreated));
            Validator.ValidateList(jobPostingsByLastDateApplication?.ToList(), nameof(jobPostingsByLastDateApplication));
            Validator.ValidateList(jobPostingsByRegion?.ToList(), nameof(jobPostingsByRegion));
            Validator.ValidateList(jobPostingsByMunicipality?.ToList(), nameof(jobPostingsByMunicipality));
            Validator.ValidateList(jobPostingsByCountry?.ToList(), nameof(jobPostingsByCountry));
            Validator.ValidateList(jobPostingsByEmploymentType?.ToList(), nameof(jobPostingsByEmploymentType));
            Validator.ValidateList(jobPostingsByWorkHours?.ToList(), nameof(jobPostingsByWorkHours));
            Validator.ValidateList(jobPostingsByOccupation?.ToList(), nameof(jobPostingsByOccupation));
            Validator.ValidateList(jobPostingsByWorkplaceId?.ToList(), nameof(jobPostingsByWorkplaceId));
            Validator.ValidateList(jobPostingsByOrganisationId?.ToList(), nameof(jobPostingsByOrganisationId));
            Validator.ValidateList(jobPostingsByHiringOrgCVR?.ToList(), nameof(jobPostingsByHiringOrgCVR));
            Validator.ValidateList(jobPostingsByWorkPlaceCityWithoutZone?.ToList(), nameof(jobPostingsByWorkPlaceCityWithoutZone));

            Validator.ValidateList(jobPostingsByPublicationStartDate?.ToList(), nameof(jobPostingsByPublicationStartDate));
            Validator.ValidateList(jobPostingsByPublicationEndDate?.ToList(), nameof(jobPostingsByPublicationEndDate));
            Validator.ValidateList(jobPostingsByNumberToFill?.ToList(), nameof(jobPostingsByNumberToFill));
            Validator.ValidateList(jobPostingsByContactEmail?.ToList(), nameof(jobPostingsByContactEmail));
            Validator.ValidateList(jobPostingsByContactPersonName?.ToList(), nameof(jobPostingsByContactPersonName));
            Validator.ValidateList(jobPostingsByEmploymentDate?.ToList(), nameof(jobPostingsByEmploymentDate));
            Validator.ValidateList(jobPostingsByApplicationDeadlineDate?.ToList(), nameof(jobPostingsByApplicationDeadlineDate));
            Validator.ValidateList(jobPostingsByBulletPointScenario?.ToList(), nameof(jobPostingsByBulletPointScenario));

            Validator.ValidateList(responseLengthByJobPostingId?.ToList(), nameof(responseLengthByJobPostingId));
            Validator.ValidateList(presentationLengthByJobPostingId?.ToList(), nameof(presentationLengthByJobPostingId));
            Validator.ValidateList(extendedResponseLengthByJobPostingId?.ToList(), nameof(extendedResponseLengthByJobPostingId));
            Validator.ValidateList(hiringOrgDescriptionLengthByJobPostingId?.ToList(), nameof(hiringOrgDescriptionLengthByJobPostingId));
            Validator.ValidateList(purposeLengthByJobPostingId?.ToList(), nameof(purposeLengthByJobPostingId));
            Validator.ValidateList(bulletPointsByJobPostingId?.ToList(), nameof(bulletPointsByJobPostingId));

            RunId = runId;
            TotalJobPages = totalJobPages;
            TotalJobPostings = totalJobPostings;

            JobPostingsByHiringOrgName = jobPostingsByHiringOrgName;
            JobPostingsByWorkPlaceAddress = jobPostingsByWorkPlaceAddress;
            JobPostingsByWorkPlacePostalCode = jobPostingsByWorkPlacePostalCode;
            JobPostingsByWorkPlaceCity = jobPostingsByWorkPlaceCity;
            JobPostingsByPostingCreated = jobPostingsByPostingCreated;
            JobPostingsByLastDateApplication = jobPostingsByLastDateApplication;
            JobPostingsByRegion = jobPostingsByRegion;
            JobPostingsByMunicipality = jobPostingsByMunicipality;
            JobPostingsByCountry = jobPostingsByCountry;
            JobPostingsByEmploymentType = jobPostingsByEmploymentType;
            JobPostingsByWorkHours = jobPostingsByWorkHours;
            JobPostingsByOccupation = jobPostingsByOccupation;
            JobPostingsByWorkplaceId = jobPostingsByWorkplaceId;
            JobPostingsByOrganisationId = jobPostingsByOrganisationId;
            JobPostingsByHiringOrgCVR = jobPostingsByHiringOrgCVR;
            JobPostingsByWorkPlaceCityWithoutZone = jobPostingsByWorkPlaceCityWithoutZone;

            JobPostingsByPublicationStartDate = jobPostingsByPublicationStartDate;
            JobPostingsByPublicationEndDate = jobPostingsByPublicationEndDate;
            JobPostingsByNumberToFill = jobPostingsByNumberToFill;
            JobPostingsByContactEmail = jobPostingsByContactEmail;
            JobPostingsByContactPersonName = jobPostingsByContactPersonName;
            JobPostingsByEmploymentDate = jobPostingsByEmploymentDate;
            JobPostingsByApplicationDeadlineDate = jobPostingsByApplicationDeadlineDate;
            JobPostingsByBulletPointScenario = jobPostingsByBulletPointScenario;

            ResponseLengthByJobPostingId = responseLengthByJobPostingId;
            PresentationLengthByJobPostingId = presentationLengthByJobPostingId;
            ExtendedResponseLengthByJobPostingId = extendedResponseLengthByJobPostingId;
            HiringOrgDescriptionLengthByJobPostingId = hiringOrgDescriptionLengthByJobPostingId;
            PurposeLengthByJobPostingId = purposeLengthByJobPostingId;
            BulletPointsByJobPostingId = bulletPointsByJobPostingId;

            TotalBulletPoints = totalBulletPoints;

        }

        #endregion

        #region Methods_public
        #endregion

    }
}

/*
    Author: numbworks@gmail.com
    Last Update: 08.08.2021
*/