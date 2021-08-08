using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NW.WIDJobs
{
    /// <summary>A database entity for <see cref="JobPostingExtended"/>.</summary>
    [Table(nameof(TableNames.JobPostingsExtended))]
    public class JobPostingExtendedEntity
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
        public string JobPostingId { get; }

        [Required]
        [MaxLength(8000)]
        [DataType("varchar(8000)")]
        public string Response { get; }

        [MaxLength(250)]
        [DataType("varchar(250)")]
        public string HiringOrgDescription { get; }

        [DataType("datetime")]
        public DateTime? PublicationStartDate { get; }

        [DataType("datetime")]
        public DateTime? PublicationEndDate { get; }

        [MaxLength(8000)]
        [DataType("varchar(8000)")]
        public string Purpose { get; }

        [DataType("smallint")]
        public ushort? NumberToFill { get; }

        [MaxLength(250)]
        [DataType("varchar(250)")]
        public string ContactEmail { get; }

        [MaxLength(250)]
        [DataType("varchar(250)")]
        public string ContactPersonName { get; }

        [DataType("datetime")]
        public DateTime? EmploymentDate { get; }

        [DataType("datetime")]
        public DateTime? ApplicationDeadlineDate { get; }

        [MaxLength(250)]
        [DataType("varchar(250)")]
        public string BulletPointScenario { get; }

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

        /// <summary>Initializes a <see cref="JobPostingExtendedEntity"/> instance.</summary>	
        public JobPostingExtendedEntity() { }

        /// <summary>Initializes a <see cref="JobPostingExtendedEntity"/> instance out of <paramref name="jobPostingExtended"/>.</summary>
        /// <exception cref="ArgumentNullException"/>	
        public JobPostingExtendedEntity(JobPostingExtended jobPostingExtended) 
        {

            Validator.ValidateObject(jobPostingExtended, nameof(jobPostingExtended));

            JobPostingId = jobPostingExtended.JobPosting.JobPostingId;
            Response = jobPostingExtended.Response;
            HiringOrgDescription = jobPostingExtended.HiringOrgDescription;
            PublicationStartDate = jobPostingExtended.PublicationStartDate;
            PublicationEndDate = jobPostingExtended.PublicationEndDate;
            Purpose = jobPostingExtended.Purpose;
            NumberToFill = jobPostingExtended.NumberToFill;
            ContactEmail = jobPostingExtended.ContactEmail;
            ContactPersonName = jobPostingExtended.ContactPersonName;
            EmploymentDate = jobPostingExtended.EmploymentDate;
            ApplicationDeadlineDate = jobPostingExtended.ApplicationDeadlineDate;
            BulletPointScenario = jobPostingExtended.BulletPointScenario;

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