using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NW.WIDJobs
{
    /// <summary>A database entity for <see cref="JobPosting"/>.</summary>
    [Table(nameof(TableNames.JobPostings))]
    public class JobPostingEntity
    {

        #region Fields

        #endregion

        #region Properties

        [Key]
        [Required]
        [DataType("bigint")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public uint RowId { get; set; }

        [Required]
        [MaxLength(250)]
        [DataType("varchar(250)")]
        public string RunId { get; }

        [Required]
        [DataType("smallint")]
        public ushort PageNumber { get; }

        [Required]
        [MaxLength(4000)]
        [DataType("varchar(4000)")]
        public string Response { get; }

        [Required]
        [MaxLength(250)]
        [DataType("varchar(250)")]
        public string Title { get; }

        [MaxLength(250)]
        [DataType("varchar(250)")]
        public string Presentation { get; }

        [MaxLength(250)]
        [DataType("varchar(250)")]
        public string HiringOrgName { get; }

        [MaxLength(250)]
        [DataType("varchar(250)")]
        public string WorkPlaceAddress { get; }

        [DataType("smallint")]
        public ushort? WorkPlacePostalCode { get; }

        [MaxLength(250)]
        [DataType("varchar(250)")]
        public string WorkPlaceCity { get; }

        [Required]
        [DataType("datetime")]
        public DateTime PostingCreated { get; }

        [Required]
        [DataType("datetime")]
        public DateTime LastDateApplication { get; }

        [MaxLength(250)]
        [DataType("varchar(250)")]
        public string Url { get; }

        [MaxLength(250)]
        [DataType("varchar(250)")]
        public string Region { get; }

        [MaxLength(250)]
        [DataType("varchar(250)")]
        public string Municipality { get; }

        [MaxLength(250)]
        [DataType("varchar(250)")]
        public string Country { get; }

        [MaxLength(250)]
        [DataType("varchar(250)")]
        public string EmploymentType { get; }

        [Required]
        [MaxLength(250)]
        [DataType("varchar(250)")]
        public string WorkHours { get; }

        [MaxLength(250)]
        [DataType("varchar(250)")]
        public string Occupation { get; }

        [Required]
        [DataType("bigint")]
        public ulong WorkplaceId { get; }

        [DataType("bigint")]
        public ulong? OrganisationId { get; }

        [Required]
        [DataType("bigint")]
        public ulong HiringOrgCVR { get; }

        [Required]
        [DataType("bigint")]
        public ulong Id { get; }

        [MaxLength(250)]
        [DataType("varchar(250)")]
        public string WorkPlaceCityWithoutZone { get; }

        [Required]
        [DataType("smallint")]
        public ushort JobPostingNumber { get; }

        [Required]
        [MaxLength(250)]
        [DataType("varchar(250)")]
        public string JobPostingId { get; }

        [Required]
        [DataType("datetime")]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime RowCreatedOn { get; set; }

        [Required]
        [DataType("datetime")]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime RowModifiedOn { get; set; }

        #endregion

        #region Constructors

        /// <summary>Initializes a <see cref="JobPostingEntity"/> instance.</summary>
        public JobPostingEntity() { }

        /// <summary>Initializes a <see cref="JobPostingEntity"/> instance out of <paramref name="jobPosting"/>.</summary>
        /// <exception cref="ArgumentNullException"/>	
        public JobPostingEntity(JobPosting jobPosting) 
        {

            Validator.ValidateObject(jobPosting, nameof(jobPosting));

            RunId = jobPosting.RunId;
            PageNumber = jobPosting.PageNumber;
            Response = jobPosting.Response;
            Title = jobPosting.Title;
            Presentation = jobPosting.Presentation;
            HiringOrgName = jobPosting.HiringOrgName;
            WorkPlaceAddress = jobPosting.WorkPlaceAddress;
            WorkPlacePostalCode = jobPosting.WorkPlacePostalCode;
            WorkPlaceCity = jobPosting.WorkPlaceCity;
            PostingCreated = jobPosting.PostingCreated;
            LastDateApplication = jobPosting.LastDateApplication;
            Url = jobPosting.Url;
            Region = jobPosting.Region;
            Municipality = jobPosting.Municipality;
            Country = jobPosting.Country;
            EmploymentType = jobPosting.EmploymentType;
            WorkHours = jobPosting.WorkHours;
            Occupation = jobPosting.Occupation;
            WorkplaceId = jobPosting.WorkplaceId;
            OrganisationId = jobPosting.OrganisationId;
            HiringOrgCVR = jobPosting.HiringOrgCVR;
            Id = jobPosting.Id;
            WorkPlaceCityWithoutZone = jobPosting.WorkPlaceCityWithoutZone;
            JobPostingNumber = jobPosting.JobPostingNumber;
            JobPostingId = jobPosting.JobPostingId;

        }

        #endregion

        #region Methods_public

        #endregion

        #region Methods_private

        #endregion

    }
}

/*
    Author: numbworks@gmail.com
    Last Update: 08.08.2021
*/