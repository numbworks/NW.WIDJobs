using System;
using System.Collections.Generic;

namespace NW.WIDJobs
{
    public class PageItem
    {

        // Fields
        // Properties
        public string AbsoluteUrl { get; set; }
        public string ItemId { get; set; }
        public string WorkArea { get; set; }
        public string Title { get; set; }
        public string Employer { get; set; }
        public short? Openings { get; set; } // 
        public DateTime? AdvertisementPublishDate { get; set; }
        public DateTime? ApplicationDeadline { get; set; }
        public string EmploymentStartDate { get; set; }
        public string Description { get; set; }
        public string Position { get; set; }
        public string EmploymentType { get; set; }
        public string WeeklyWorkingHours { get; set; }
        public string EmployerAddress { get; set; }
        public string Contact { get; set; }
        public string HowToApply { get; set; }
        public string Country { get; set; }
        public uint? SalaryRangeStart { get; set; }
        public uint? SalaryRangeEnd { get; set; }
        public string SalaryRangeCurrency { get; set; }
        public string VisaType { get; set; }
        public string RelocationType { get; set; }
        public string RemoteType { get; set; }
        public string ExperienceLevel { get; set; }
        public string Industry { get; set; }
        public uint? CompanySize { get; set; }
        public string CompanyType { get; set; }
        public string RemoteDetails { get; set; }
        public HashSet<string> Technologies { get; set; }
        public HashSet<string> Benefits { get; set; }
        public HashSet<string> TeamMembers { get; set; }
        public HashSet<string> TeamMembersTechnologies { get; set; }

        // Constructors
        public PageItem() { }
        public PageItem(PageItem objItem)
        {

            if (objItem == null)
                new PageItem();

            if (objItem != null)
            {

                AbsoluteUrl = objItem.AbsoluteUrl;
                ItemId = objItem.ItemId;
                WorkArea = objItem.WorkArea;
                Title = objItem.Title;
                Employer = objItem.Employer;
                Openings = objItem.Openings;
                AdvertisementPublishDate = objItem.AdvertisementPublishDate;
                ApplicationDeadline = objItem.ApplicationDeadline;
                EmploymentStartDate = objItem.EmploymentStartDate;
                Description = objItem.Description;
                Position = objItem.Position;
                EmploymentType = objItem.EmploymentType;
                WeeklyWorkingHours = objItem.WeeklyWorkingHours;
                EmployerAddress = objItem.EmployerAddress;
                Contact = objItem.Contact;
                HowToApply = objItem.HowToApply;
                Country = objItem.Country;
                SalaryRangeStart = objItem.SalaryRangeStart;
                SalaryRangeEnd = objItem.SalaryRangeEnd;
                SalaryRangeCurrency = objItem.SalaryRangeCurrency;
                VisaType = objItem.VisaType;
                RelocationType = objItem.RelocationType;
                RemoteType = objItem.RemoteType;
                ExperienceLevel = objItem.ExperienceLevel;
                Industry = objItem.Industry;
                CompanySize = objItem.CompanySize;
                CompanyType = objItem.CompanyType;
                RemoteDetails = objItem.RemoteDetails;

                if (objItem.Technologies != null)
                    Technologies.UnionWith(objItem.Technologies);

                if (objItem.Benefits != null)
                    Benefits.UnionWith(objItem.Benefits);

                if (objItem.TeamMembers != null)
                    TeamMembers.UnionWith(objItem.TeamMembers);

                if (objItem.TeamMembersTechnologies != null)
                    TeamMembersTechnologies.UnionWith(objItem.TeamMembersTechnologies);

            }

        }

        // Methods

    }
}

/*
    Author: numbworks@gmail.com
    Last Update: 05.05.2021
*/