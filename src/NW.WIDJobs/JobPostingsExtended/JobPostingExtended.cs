using System;
using System.Collections.Generic;

namespace NW.WIDJobs
{
    /// <summary>A <see href="http://www.workindenmark.dk">WorkInDenmark</see>'s job posting extended.</summary>
    public class JobPostingExtended
    {

        #region Fields
        #endregion

        #region Properties

        public JobPosting JobPosting { get; }

        public string Response { get; }
        public string HiringOrgDescription { get; }
        public DateTime? PublicationStartDate { get; }
        public DateTime? PublicationEndDate { get; }
        public string Purpose { get; }
        public ushort? NumberToFill { get; }
        public string ContactEmail { get; }
        public string ContactPersonName { get; }
        public DateTime? EmploymentDate { get; }
        public DateTime? ApplicationDeadlineDate { get; }
        public HashSet<string> BulletPoints { get; }
        public string BulletPointScenario { get; }

        #endregion

        #region Constructors

        ///<summary>Initializes a <see cref="JobPostingExtended"/> instance.</summary>
        /// <exception cref="ArgumentNullException"/>
        public JobPostingExtended(
            JobPosting jobPosting,
            string response,
            string hiringOrgDescription,
            DateTime? publicationStartDate,
            DateTime? publicationEndDate,
            string purpose,
            ushort? numberToFill,
            string contactEmail,
            string contactPersonName,
            DateTime? employmentDate,
            DateTime? applicationDeadlineDate,
            HashSet<string> bulletPoints,
            string bulletPointScenario
            ) 
        {

            Validator.ValidateObject(jobPosting, nameof(jobPosting));
            Validator.ValidateStringNullOrWhiteSpace(response, nameof(response));

            JobPosting = jobPosting;
            Response = response;
            HiringOrgDescription = hiringOrgDescription;
            PublicationStartDate = publicationStartDate;
            PublicationEndDate = publicationEndDate;
            Purpose = purpose;
            NumberToFill = numberToFill;
            ContactEmail = contactEmail;
            ContactPersonName = contactPersonName;
            EmploymentDate = employmentDate;
            ApplicationDeadlineDate = applicationDeadlineDate;
            BulletPoints = bulletPoints;
            BulletPointScenario = bulletPointScenario;

        }

        #endregion

        #region Methods_public
        #endregion

    }
}

/*
    Author: numbworks@gmail.com
    Last Update: 01.07.2021
*/