using System;
using System.Collections.Generic;

namespace NW.WIDJobs
{
    public class PageItem
    {

        // Fields
        // Properties
        public string ItemId { get; set; }
        public string AbsoluteUrl { get; set; }
        public string Title { get; set; }
        public string WorkArea { get; set; }
        public string WeeklyWorkingHours { get; set; }
        public DateTime? AdvertisementPublishDate { get; set; }
        public DateTime? ApplicationDeadline { get; set; }

        public string Description { get; set; }

        public string Employer { get; set; }
        public short? Openings { get; set; } // 
        public string EmploymentStartDate { get; set; }
        public string Position { get; set; }
        public string EmploymentType { get; set; }
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
        public PageItem(PageItem pageItem)
        {

            if (pageItem == null)
                new PageItem();

            if (pageItem != null)
            {

                AbsoluteUrl = pageItem.AbsoluteUrl;
                ItemId = pageItem.ItemId;
                WorkArea = pageItem.WorkArea;
                Title = pageItem.Title;
                Employer = pageItem.Employer;
                Openings = pageItem.Openings;
                AdvertisementPublishDate = pageItem.AdvertisementPublishDate;
                ApplicationDeadline = pageItem.ApplicationDeadline;
                EmploymentStartDate = pageItem.EmploymentStartDate;
                Description = pageItem.Description;
                Position = pageItem.Position;
                EmploymentType = pageItem.EmploymentType;
                WeeklyWorkingHours = pageItem.WeeklyWorkingHours;
                EmployerAddress = pageItem.EmployerAddress;
                Contact = pageItem.Contact;
                HowToApply = pageItem.HowToApply;
                Country = pageItem.Country;
                SalaryRangeStart = pageItem.SalaryRangeStart;
                SalaryRangeEnd = pageItem.SalaryRangeEnd;
                SalaryRangeCurrency = pageItem.SalaryRangeCurrency;
                VisaType = pageItem.VisaType;
                RelocationType = pageItem.RelocationType;
                RemoteType = pageItem.RemoteType;
                ExperienceLevel = pageItem.ExperienceLevel;
                Industry = pageItem.Industry;
                CompanySize = pageItem.CompanySize;
                CompanyType = pageItem.CompanyType;
                RemoteDetails = pageItem.RemoteDetails;

                if (pageItem.Technologies != null)
                    Technologies.UnionWith(pageItem.Technologies);

                if (pageItem.Benefits != null)
                    Benefits.UnionWith(pageItem.Benefits);

                if (pageItem.TeamMembers != null)
                    TeamMembers.UnionWith(pageItem.TeamMembers);

                if (pageItem.TeamMembersTechnologies != null)
                    TeamMembersTechnologies.UnionWith(pageItem.TeamMembersTechnologies);

            }

        }

        // Methods

    }
}

/*
    Author: numbworks@gmail.com
    Last Update: 05.05.2021
*/