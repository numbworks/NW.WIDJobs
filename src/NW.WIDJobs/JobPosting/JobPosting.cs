using System;

namespace NW.WIDJobs
{
    /// <summary>A <see href="http://www.workindenmark.dk">WorkInDenmark</see>'s job posting.</summary>
    public class JobPosting
    {

        #region Fields
        #endregion

        #region Properties

        public string RunId { get; }
        public ushort PageNumber { get; }
        public string Response { get; }
        public string Title { get; }
        public string Presentation { get; }
        public string HiringOrgName { get; }
        public string WorkPlaceAddress { get; }
        public ushort? WorkPlacePostalCode { get; }
        public string WorkPlaceCity { get; }
        public DateTime PostingCreated { get; }
        public DateTime LastDateApplication { get; }
        public string Url { get; }
        public string Region { get; }
        public string Municipality { get; }
        public string Country { get; }
        public string EmploymentType { get; }
        public string WorkHours { get; }
        public string Occupation { get; }
        public ulong WorkplaceId { get; }
        public ulong OrganisationId { get; }
        public ulong HiringOrgCVR { get; }
        public ulong Id { get; }
        public string WorkPlaceCityWithoutZone { get; }
        public ushort JobPostingNumber { get; }
        public string JobPostingId { get; }

        #endregion

        #region Constructors

        ///<summary>Initializes a <see cref="JobPosting"/> instance.</summary>
        /// <exception cref="ArgumentNullException"/>
        /// <exception cref="ArgumentException"/> 
        public JobPosting(
            string runId,
            ushort pageNumber,
            string response,
            string title,
            string presentation,
            string hiringOrgName,
            string workPlaceAddress,
            ushort? workPlacePostalCode,
            string workPlaceCity,
            DateTime postingCreated,
            DateTime lastDateApplication,
            string url,
            string region,
            string municipality,
            string country,
            string employmentType,
            string workHours,
            string occupation,
            ulong workplaceId,
            ulong organisationId,
            ulong hiringOrgCVR,
            ulong id,
            string workPlaceCityWithoutZone,
            ushort jobPostingNumber,
            string jobPostingId
            )
        {

            Validator.ValidateStringNullOrWhiteSpace(runId, nameof(runId));
            Validator.ThrowIfLessThanOne(pageNumber, nameof(pageNumber));
            Validator.ValidateStringNullOrWhiteSpace(response, nameof(response));
            Validator.ValidateStringNullOrWhiteSpace(title, nameof(title));
            Validator.ValidateStringNullOrWhiteSpace(hiringOrgName, nameof(hiringOrgName));
            Validator.ValidateStringNullOrWhiteSpace(url, nameof(url));
            Validator.ValidateStringNullOrWhiteSpace(country, nameof(country));
            Validator.ValidateStringNullOrWhiteSpace(workHours, nameof(workHours));
            Validator.ValidateStringNullOrWhiteSpace(occupation, nameof(occupation));
            Validator.ValidateStringNullOrWhiteSpace(jobPostingId, nameof(jobPostingId));

            RunId = runId;
            PageNumber = pageNumber;
            Response = response;
            Title = title;
            Presentation = presentation;
            HiringOrgName = hiringOrgName;
            WorkPlaceAddress = workPlaceAddress;
            WorkPlacePostalCode = workPlacePostalCode;
            WorkPlaceCity = workPlaceCity;
            PostingCreated = postingCreated;
            LastDateApplication = lastDateApplication;
            Url = url;
            Region = region;
            Municipality = municipality;
            Country = country;
            EmploymentType = employmentType;
            WorkHours = workHours;
            Occupation = occupation;
            WorkplaceId = workplaceId;
            OrganisationId = organisationId;
            HiringOrgCVR = hiringOrgCVR;
            Id = id;
            WorkPlaceCityWithoutZone = workPlaceCityWithoutZone;
            JobPostingNumber = jobPostingNumber;
            JobPostingId = jobPostingId;

        }

        #endregion

        #region Methods_public
        #endregion

    }
}

/*
    Author: numbworks@gmail.com
    Last Update: 25.06.2021
*/