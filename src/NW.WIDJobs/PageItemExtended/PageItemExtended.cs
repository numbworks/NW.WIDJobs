﻿using System;
using System.Collections.Generic;

namespace NW.WIDJobs
{
    public class PageItemExtended
    {

        // Fields
        // Properties
        public PageItem PageItem { get; }
        public string Description { get; }

        public string DescriptionSeeCompleteTextAt { get; }
        public HashSet<string> DescriptionBulletPoints { get; }
        public string EmployerName { get; }
        public ushort? NumberOfOpenings { get; }
        public DateTime? AdvertisementPublishDate { get; }
        public DateTime? ApplicationDeadline { get; }
        public string StartDateOfEmployment { get; }
        public string Reference { get; }
        public string Position { get; }
        public string TypeOfEmployment { get; }
        public string Contact { get; }
        public string EmployerAddress { get; }
        public string HowToApply { get; }

        // Constructors
        public PageItemExtended(
                PageItem pageItem,
                string description,
                string seeCompleteTextAt = null,
                HashSet<string> bulletPoints = null,
                string employerName = null,
                ushort? numberOfOpenings = null,
                DateTime? advertisementPublishDate = null,
                DateTime? applicationDeadline = null,
                string startDateOfEmployment = null,
                string reference = null,
                string position = null,
                string typeOfEmployment = null,
                string contact = null,
                string employerAddress = null,
                string howToApply = null
            ) 
        {

            Validator.ValidateObject(pageItem, nameof(pageItem));
            Validator.ValidateStringNullOrWhiteSpace(description, nameof(description));

            PageItem = pageItem;
            Description = description;

            DescriptionSeeCompleteTextAt = seeCompleteTextAt;
            DescriptionBulletPoints = bulletPoints;
            EmployerName = employerName;
            NumberOfOpenings = numberOfOpenings;
            AdvertisementPublishDate = advertisementPublishDate;
            ApplicationDeadline = applicationDeadline;
            StartDateOfEmployment = startDateOfEmployment;
            Reference = reference;
            Position = position;
            TypeOfEmployment = typeOfEmployment;
            Contact = contact;
            EmployerAddress = employerAddress;
            HowToApply = howToApply;

        }

        // Methods

    }
}

/*
    Author: numbworks@gmail.com
    Last Update: 09.05.2021
*/