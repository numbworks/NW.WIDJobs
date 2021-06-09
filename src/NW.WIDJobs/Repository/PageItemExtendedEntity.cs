using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NW.WIDJobs
{
    /// <summary>A database entity for <see cref="PageItemExtended"/>.</summary>
    [Table(nameof(TableNames.PageItemsExtended))]
    public class PageItemExtendedEntity : ITrackableEntity
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
        public string PageItemId { get; }

        [Required]
        [MaxLength(4000)]
        [DataType("text")]
        public string Description { get; }

        [MaxLength(250)]
        [DataType("varchar(250)")]
        public string SeeCompleteTextAt { get; }

        [MaxLength(250)]
        [DataType("varchar(250)")]
        public string EmployerName { get; }

        [DataType("smallint")]
        public ushort? NumberOfOpenings { get; }

        [DataType("datetime")]
        public DateTime? AdvertisementPublishDate { get; }

        [DataType("datetime")]
        public DateTime? ApplicationDeadline { get; }

        [MaxLength(250)]
        [DataType("varchar(250)")]
        public string StartDateOfEmployment { get; }

        [MaxLength(250)]
        [DataType("varchar(250)")]
        public string Reference { get; }

        [MaxLength(250)]
        [DataType("varchar(250)")]
        public string Position { get; }

        [MaxLength(250)]
        [DataType("varchar(250)")]
        public string TypeOfEmployment { get; }

        [MaxLength(250)]
        [DataType("varchar(250)")]
        public string Contact { get; }

        [MaxLength(250)]
        [DataType("varchar(250)")]
        public string EmployerAddress { get; }

        [MaxLength(250)]
        [DataType("varchar(250)")]
        public string HowToApply { get; }

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

        ///<summary>Initializes a <see cref="PageItemExtendedEntity"/> instance.</summary>
        public PageItemExtendedEntity() { }

        ///<summary>Initializes a <see cref="PageItemExtendedEntity"/> instance our of <paramref name="pageItemExtended"/>.</summary>
        /// <exception cref="ArgumentNullException"/>
        public PageItemExtendedEntity(PageItemExtended pageItemExtended)
        {

            Validator.ValidateObject(pageItemExtended, nameof(pageItemExtended));

            PageItemId = pageItemExtended.PageItem.PageItemId;
            Description = pageItemExtended.Description;
            SeeCompleteTextAt = pageItemExtended.DescriptionSeeCompleteTextAt;
            EmployerName = pageItemExtended.EmployerName;
            NumberOfOpenings = pageItemExtended.NumberOfOpenings;
            AdvertisementPublishDate = pageItemExtended.AdvertisementPublishDate;
            ApplicationDeadline = pageItemExtended.ApplicationDeadline;
            StartDateOfEmployment = pageItemExtended.StartDateOfEmployment;
            Reference = pageItemExtended.Reference;
            Position = pageItemExtended.Position;
            TypeOfEmployment = pageItemExtended.TypeOfEmployment;
            Contact = pageItemExtended.Contact;
            EmployerAddress = pageItemExtended.EmployerAddress;
            HowToApply = pageItemExtended.HowToApply;

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