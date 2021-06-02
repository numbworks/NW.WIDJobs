using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NW.WIDJobs
{
    /// <summary>A database entity for <see cref="PageItemExtended.DescriptionBulletPoints"/>.</summary>
    [Table(nameof(TableNames.PageItemsExtendedBulletPoints))]
    public class BulletPointEntity
    {

        #region Fields
        #endregion

        #region Properties
        [Key]
        [Required]
        [Column("integer")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public uint RowId { get; set; }

        [Required]
        [MaxLength(250)]
        [Column("varchar(250)")]
        public string PageItemId { get; }

        [MaxLength(250)]
        [Column("varchar(250)")]
        public string BulletPoint { get; }

        [Required]
        [Column("datetime")]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime RowCreatedOn { get; set; }

        [Required]
        [Column("datetime")]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime RowModifiedOn { get; set; }

        #endregion

        #region Constructors

        ///<summary>Initializes a <see cref="BulletPointEntity"/> instance.</summary>
        public BulletPointEntity() { }

        ///<summary>Initializes a <see cref="BulletPointEntity"/> instance out of <paramref name="pageItemId"/> and <paramref name="bulletPoint"/>.</summary>
        /// <exception cref="ArgumentNullException"/>
        public BulletPointEntity(string pageItemId, string bulletPoint)
        {

            Validator.ValidateObject(pageItemId, nameof(pageItemId));
            Validator.ValidateObject(bulletPoint, nameof(bulletPoint));

            PageItemId = pageItemId;
            BulletPoint = bulletPoint;

        }

        #endregion

        #region Methods_public
        #endregion

    }
}

/*
    Author: numbworks@gmail.com
    Last Update: 02.06.2021
*/