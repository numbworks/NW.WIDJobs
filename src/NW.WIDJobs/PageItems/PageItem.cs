using System;

namespace NW.WIDJobs
{
    public class PageItem
    {

        // Fields
        // Properties
        public string RunId { get; }
        public ushort PageNumber { get; }
        public string Url { get; }
        public string Title { get; }
        public DateTime CreateDate { get; }
        public DateTime ApplicationDate { get; }
        public string WorkArea { get; }
        public string WorkingHours { get; }
        public string JobType { get; }
        public ulong JobId { get; }
        public ushort PageItemNumber { get; }
        public string PageItemId { get; }

        // Constructors
        public PageItem(
            string runId,
            ushort pageNumber,
            string url,
            string title,
            DateTime createDate,
            DateTime applicationDate,
            string workArea,
            string workingHours,
            string jobType,
            ulong jobId,
            ushort pageItemNumber,
            string pageItemId
            ) 
        {

            Validator.ValidateStringNullOrWhiteSpace(runId, nameof(runId));
            Validator.ThrowIfLessThanOne(pageNumber, nameof(pageNumber));
            Validator.ValidateStringNullOrWhiteSpace(url, nameof(url));
            Validator.ValidateStringNullOrWhiteSpace(title, nameof(title));
            Validator.ValidateStringNullOrWhiteSpace(workArea, nameof(workArea));
            Validator.ValidateStringNullOrWhiteSpace(workingHours, nameof(workingHours));
            Validator.ValidateStringNullOrWhiteSpace(jobType, nameof(jobType));
            Validator.ThrowIfLessThanOne(pageItemNumber, nameof(pageItemNumber));
            Validator.ValidateStringNullOrWhiteSpace(pageItemId, nameof(pageItemId));

            RunId = runId;
            PageNumber = pageNumber;
            Url = url;
            Title = title;
            CreateDate = createDate;
            ApplicationDate = applicationDate;
            WorkArea = workArea;
            WorkingHours = workingHours;
            JobType = jobType;
            JobId = jobId;
            PageItemNumber = pageItemNumber;

        }

        // Methods

    }
}

/*
    Author: numbworks@gmail.com
    Last Update: 09.05.2021
*/