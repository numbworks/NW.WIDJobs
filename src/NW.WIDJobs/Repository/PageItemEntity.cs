﻿using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NW.WIDJobs
{
    /// <summary>A database entity for <see cref="PageItem"/>.</summary>
    [Table(nameof(TableNames.PageItems))]
    public class PageItemEntity : ITrackableEntity
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
        public string RunId { get; }

        [Required]
        [DataType("smallint")]
        public ushort PageNumber { get; }

        [Required]
        [MaxLength(250)]
        [DataType("varchar(250)")]
        public string Url { get; }

        [Required]
        [MaxLength(250)]
        [DataType("varchar(250)")]
        public string Title { get; }

        [Required]
        [DataType("datetime")]
        public DateTime CreateDate { get; }

        [DataType("datetime")]
        public DateTime? ApplicationDate { get; }

        [Required]
        [MaxLength(250)]
        [DataType("varchar(250)")]
        public string WorkArea { get; }

        [Required]
        [MaxLength(250)]
        [DataType("varchar(250)")]
        public string WorkAreaWithoutZone { get; }

        [Required]
        [MaxLength(250)]
        [DataType("varchar(250)")]
        public string WorkingHours { get; }

        [Required]
        [MaxLength(250)]
        [DataType("varchar(250)")]
        public string JobType { get; }

        [Required]
        [DataType("bigint")]
        public ulong JobId { get; }

        [Required]
        [DataType("smallint")]
        public ushort PageItemNumber { get; }

        [Required]
        [MaxLength(250)]
        [DataType("varchar(250)")]
        public string PageItemId { get; }

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

        ///<summary>Initializes a <see cref="PageItemEntity"/> instance.</summary>
        public PageItemEntity() { }

        ///<summary>Initializes a <see cref="PageItemEntity"/> instance our of <paramref name="pageItem"/>.</summary>
        /// <exception cref="ArgumentNullException"/>
        public PageItemEntity(PageItem pageItem) 
        {

            Validator.ValidateObject(pageItem, nameof(pageItem));

            RunId = pageItem.RunId;
            PageNumber = pageItem.PageNumber;
            Url = pageItem.Url;
            Title = pageItem.Title;
            CreateDate = pageItem.CreateDate;
            ApplicationDate = pageItem.ApplicationDate;
            WorkArea = pageItem.WorkArea;
            WorkAreaWithoutZone = pageItem.WorkAreaWithoutZone;
            WorkingHours = pageItem.WorkingHours;
            JobType = pageItem.JobType;
            JobId = pageItem.JobId;
            PageItemNumber = pageItem.PageItemNumber;
            PageItemId = pageItem.PageItemId;

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