using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Linq;
using System.Text.Json;

namespace NW.WIDJobs
{
    /// <inheritdoc cref="IJobPostingDeserializer"/>
    public class JobPostingDeserializer : IJobPostingDeserializer
    {

        #region Fields

        private IJobPostingHelper _jobPostingHelper;

        #endregion

        #region Properties
        #endregion

        #region Constructors

        /// <summary>Initializes a <see cref="JobPostingDeserializer"/> instance.</summary>
        /// <exception cref="ArgumentNullException"></exception>
        public JobPostingDeserializer(IJobPostingHelper jobPostingHelper)
        {

            Validator.ValidateObject(jobPostingHelper, nameof(jobPostingHelper));

            _jobPostingHelper = jobPostingHelper;

        }

        /// <summary>Initializes a <see cref="JobPostingDeserializer"/> instance using default parameters.</summary>
        public JobPostingDeserializer()
            : this(new JobPostingHelper()) { }

        #endregion

        #region Methods_public

        public List<JobPosting> Do(JobPage jobPage)
        {

            Validator.ValidateObject(jobPage, nameof(jobPage));

            List<JobPosting> jobPostings = Extract(jobPage);

            return jobPostings;

        }

        #endregion

        #region Methods_private

        private List<JobPosting> Extract(JobPage jobPage)
        {

            using JsonDocument jsonRoot = JsonDocument.Parse(jobPage.Response);
                JsonElement jobPositionPostings = jsonRoot.RootElement.GetProperty("JobPositionPostings");

            List<JobPosting> jobPostings = new List<JobPosting>();
            for (int i = 0; i < jobPositionPostings.GetArrayLength(); i++)
            {

                JsonElement jsonElement = jobPositionPostings[i];
                ushort jobPostingNumber = (ushort)(i + 1);

                JobPosting jobPosting
                    = ExtractJobPosting(jobPage.RunId, jobPage.PageNumber, jsonElement, jobPostingNumber);

                jobPostings.Add(jobPosting);

            };

            return jobPostings;

        }

        private JobPosting ExtractJobPosting
            (string runId, ushort pageNumber, JsonElement jsonElement, ushort jobPostingNumber)
        {

            string title = ExtractTitle(jsonElement);
            string presentation = ExtractPresentation(jsonElement);
            string hiringOrgName = ExtractHiringOrgName(jsonElement);
            string workPlaceAddress = ExtractWorkPlaceAddress(jsonElement);
            ushort? workPlacePostalCode = ExtractWorkPlacePostalCode(jsonElement);
            string workPlaceCity = ExtractWorkPlaceCity(jsonElement);
            DateTime postingCreated = ExtractPostingCreated(jsonElement);
            DateTime lastDateApplication = ExtractLastDateApplication(jsonElement);
            string url = ExtractUrl(jsonElement);
            string region = ExtractRegion(jsonElement);
            string municipality = ExtractMunicipality(jsonElement);
            string country = ExtractCountry(jsonElement);
            string employmentType = ExtractEmploymentType(jsonElement);
            string workHours = ExtractWorkHours(jsonElement);
            string occupation = ExtractOccupation(jsonElement);
            ulong? workplaceId = ExtractWorkplaceID(jsonElement);
            ulong? organisationId = ExtractOrganisationId(jsonElement);
            ulong? hiringOrgCVR = ExtractHiringOrgCVR(jsonElement);
            ulong id = ExtractID(jsonElement);

            string workPlaceCityWithoutZone = CreateWorkPlaceCityWithoutZone(workPlaceCity);
            string jobPostingId = CreateJobPostingId(id, title);

            JobPosting jobPosting
                = new JobPosting(
                        runId: runId,
                        pageNumber: pageNumber,
                        response: jsonElement.GetRawText(),
                        title: title,
                        presentation: presentation,
                        hiringOrgName: hiringOrgName,
                        workPlaceAddress: workPlaceAddress,
                        workPlacePostalCode: workPlacePostalCode,
                        workPlaceCity: workPlaceCity,
                        postingCreated: postingCreated,
                        lastDateApplication: lastDateApplication,
                        url: url,
                        region: region,
                        municipality: municipality,
                        country: country,
                        employmentType: employmentType,
                        workHours: workHours,
                        occupation: occupation,
                        workplaceId: workplaceId,
                        organisationId: organisationId,
                        hiringOrgCVR: hiringOrgCVR,
                        id: id,
                        workPlaceCityWithoutZone: workPlaceCityWithoutZone,
                        jobPostingNumber: jobPostingNumber,
                        jobPostingId: jobPostingId
                );

            return jobPosting;

        }
        private string ExtractTitle(JsonElement jsonElement)
        {

            return jsonElement.GetProperty("Title").GetString();

        }
        private string ExtractPresentation(JsonElement jsonElement)
        {

            return jsonElement.GetProperty("Presentation").GetString();

        }
        private string ExtractHiringOrgName(JsonElement jsonElement)
        {

            return jsonElement.GetProperty("HiringOrgName").GetString();

        }
        private string ExtractWorkPlaceAddress(JsonElement jsonElement)
        {

            return jsonElement.GetProperty("WorkPlaceAddress").GetString();

        }
        private ushort? ExtractWorkPlacePostalCode(JsonElement jsonElement)
        {

            string workPlacePostalCode = jsonElement.GetProperty("WorkPlacePostalCode").GetString();
            
            if (string.IsNullOrWhiteSpace(workPlacePostalCode))
                return null;

            return ushort.Parse(workPlacePostalCode);

        }
        private string ExtractWorkPlaceCity(JsonElement jsonElement)
        {

            return jsonElement.GetProperty("WorkPlaceCity").GetString();

        }
        private DateTime ExtractPostingCreated(JsonElement jsonElement)
        {

            return jsonElement.GetProperty("PostingCreated").GetDateTime();

        }
        private DateTime ExtractLastDateApplication(JsonElement jsonElement)
        {

            return jsonElement.GetProperty("LastDateApplication").GetDateTime();

        }
        private string ExtractUrl(JsonElement jsonElement)
        {

            return jsonElement.GetProperty("Url").GetString();

        }
        private string ExtractRegion(JsonElement jsonElement)
        {

            return jsonElement.GetProperty("Region").GetString();

        }
        private string ExtractMunicipality(JsonElement jsonElement)
        {

            return jsonElement.GetProperty("Municipality").GetString();

        }
        private string ExtractCountry(JsonElement jsonElement)
        {

            return jsonElement.GetProperty("Country").GetString();

        }
        private string ExtractEmploymentType(JsonElement jsonElement)
        {

            return jsonElement.GetProperty("EmploymentType").GetString();

        }
        private string ExtractWorkHours(JsonElement jsonElement)
        {

            return jsonElement.GetProperty("WorkHours").GetString();

        }
        private string ExtractOccupation(JsonElement jsonElement)
        {

            return jsonElement.GetProperty("Occupation").GetString();

        }
        private ulong? ExtractWorkplaceID(JsonElement jsonElement)
        {

            string workplaceID = jsonElement.GetProperty("WorkplaceID").GetString();

            if (string.IsNullOrWhiteSpace(workplaceID))
                return null;

            return ulong.Parse(workplaceID);

        }
        private ulong? ExtractOrganisationId(JsonElement jsonElement)
        {

            string organizationId = jsonElement.GetProperty("OrganisationId").GetString();

            if (string.IsNullOrWhiteSpace(organizationId))
                return null;

            return ulong.Parse(organizationId);

        }
        private ulong? ExtractHiringOrgCVR(JsonElement jsonElement)
        {

            string hiringOrgCVR = jsonElement.GetProperty("HiringOrgCVR").GetString();

            if (string.IsNullOrWhiteSpace(hiringOrgCVR))
                return null;

            return ulong.Parse(hiringOrgCVR);

        }
        private ulong ExtractID(JsonElement jsonElement)
        {

            string id = jsonElement.GetProperty("ID").GetString();

            return CleanAndParseId(id);

        }

        private ulong CleanAndParseId(string id)
        {

            string cleanId = id.Replace("E", string.Empty);

            return ulong.Parse(cleanId);

        }
        private string CreateWorkPlaceCityWithoutZone(string workPlaceCity)
        {

            /*

                København K 	=> København
                Kgs. Lyngby		=> Kgs. Lyngby
                København V 	=> København
                København Ø 	=> København
                København S		=> København
                Aarhus C 		=> Aarhus
                Viby J 			=> Viby
                Odense S 		=> Odense
                Kongens Lyngby 	=> Kongens Lyngby
                Billund 		=> Billund
                København SV 	=> København
                Esbjerg V 		=> Esbjerg
                Odense SØ 		=> Odense
                Lem St 			=> Lem 
                ...				

            */

            string pattern = "^[a-zA-ZÀ-ÖØ-öø-ÿ.]{1,}$|^[a-zA-ZÀ-ÖØ-öø-ÿ.]{1,}[ ]{1}[a-zA-ZÀ-ÖØ-öø-ÿ.]{3,}|^[a-zA-ZÀ-ÖØ-öø-ÿ.]{1,}";

            return Regex.Match(workPlaceCity, pattern).ToString();

        }
        private string CreateJobPostingId(ulong id, string title)
        {

            /*
                8144089, "Business Support & Pricing Manager"            
                    => 8144089businesssupportpricingmanager

                8180759, "Technical Officer, GOARN, Copenhagen, DenmarkOrganization: World Health Organization"
                    => "8180759technicalofficergoarncopenhagendenmarkorganizationworldhealthorganization"
                            => "8180759technicalofficergoarncopenhagendenmarkorganization"
            */

            string pattern = "[a-zA-Z]{1,}";

            string[] words = Regex.Matches(title, pattern).Cast<Match>().Select(m => m.Value.ToLower()).ToArray();

            int threshold = 5;
            if (words.Length > threshold)
                words = words.Take(threshold).ToArray();

            StringBuilder stringBuilder = new StringBuilder();
            words.ToList().ForEach(match => stringBuilder.Append(match));

            string jobPostingId = stringBuilder.ToString();
            jobPostingId = string.Concat(id, jobPostingId);

            return jobPostingId;

        }

        #endregion

    }
}

/*
    Author: numbworks@gmail.com
    Last Update: 01.07.2021
*/