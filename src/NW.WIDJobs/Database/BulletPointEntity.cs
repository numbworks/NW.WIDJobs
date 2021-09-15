using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using NW.WIDJobs.Validation;

namespace NW.WIDJobs.Database
{
    /// <summary>A database entity for <see cref="JobPostingExtended.BulletPoints"/>.</summary>
    [Table(nameof(TableNames.JobPostingsExtendedBulletPoints))]
    public class BulletPointEntity : ITrackableEntity
    {

        #region Fields
        #endregion

        #region Properties
        [Key]
        [Required]
        [DataType("integer")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public uint RowId { get; set; }

        [Required]
        [MaxLength(250)]
        [DataType("varchar(250)")]
        public string JobPostingId { get; }

        [Required]
        [MaxLength(250)]
        [DataType("varchar(250)")]
        public string BulletPoint { get; }

        [MaxLength(50)]
        [DataType("varchar(50)")]
        public string Type { get; }

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

        ///<summary>Initializes an empty <see cref="BulletPointEntity"/> instance.</summary>
        public BulletPointEntity() { }

        ///<summary>Initializes a <see cref="BulletPointEntity"/> instance.</summary>
        /// <exception cref="ArgumentNullException"/>
        public BulletPointEntity(string jobPostingId, string bulletPoint)
        {

            Validation.Validator.ValidateObject(jobPostingId, nameof(jobPostingId));
            Validation.Validator.ValidateObject(bulletPoint, nameof(bulletPoint));

            JobPostingId = jobPostingId;
            BulletPoint = bulletPoint;

        }

        #endregion

        #region Methods_public
        #endregion

    }
}

/*
    Author: numbworks@gmail.com
    Last Update: 15.09.2021
*/