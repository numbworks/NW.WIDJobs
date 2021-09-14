﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Linq;
using System.Text.Json;
using NW.WIDJobs.JobPages;
using NW.WIDJobs.Validation;
using NW.WIDJobs.Classification;
using HtmlAgilityPack;
using System.Web;

namespace NW.WIDJobs.JobPostings
{
    /// <inheritdoc cref="IJobPostingDeserializer"/>
    public class JobPostingDeserializer : IJobPostingDeserializer
    {

        #region Fields

        private IOccupationTranslator _occupationTranslator;
        private IClassificationManager _classificationManager;

        #endregion

        #region Properties
        #endregion

        #region Constructors

        /// <summary>Initializes a <see cref="JobPostingDeserializer"/> instance.</summary>
        public JobPostingDeserializer(IOccupationTranslator occupationTranslator, IClassificationManager classificationManager) 
        {

            Validator.ValidateObject(occupationTranslator, nameof(occupationTranslator));
            Validator.ValidateObject(classificationManager, nameof(classificationManager));

            _occupationTranslator = occupationTranslator;
            _classificationManager = classificationManager;

        }

        /// <summary>Initializes a <see cref="JobPostingDeserializer"/> instance using default parameters.</summary>
        public JobPostingDeserializer()
            : this(new OccupationTranslator(), new ClassificationManager()) { }

        #endregion

        #region Methods_public

        public List<JobPosting> Do(JobPage jobPage, bool translateOccupation = true)
        {

            Validator.ValidateObject(jobPage, nameof(jobPage));

            List<JobPosting> jobPostings = Extract(jobPage, translateOccupation);

            return jobPostings;

        }

        #endregion

        #region Methods_private

        private List<JobPosting> Extract(JobPage jobPage, bool translateOccupation)
        {

            using JsonDocument jsonRoot = JsonDocument.Parse(jobPage.Response);
                JsonElement jobPositionPostings = jsonRoot.RootElement.GetProperty("JobPositionPostings");

            List<JobPosting> jobPostings = new List<JobPosting>();
            for (int i = 0; i < jobPositionPostings.GetArrayLength(); i++)
            {

                JsonElement jsonElement = jobPositionPostings[i];
                ushort jobPostingNumber = (ushort)(i + 1);

                JobPosting jobPosting
                    = ExtractJobPosting(jobPage.RunId, jobPage.PageNumber, jsonElement, jobPostingNumber, translateOccupation);

                jobPostings.Add(jobPosting);

            };

            return jobPostings;

        }

        private JobPosting ExtractJobPosting
            (string runId, ushort pageNumber, JsonElement jsonElement, ushort jobPostingNumber, bool translateOccupation)
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
            if (translateOccupation)
                occupation = _occupationTranslator.Translate(occupation);
            
            ulong workplaceId = ExtractWorkplaceID(jsonElement);
            ulong? organisationId = ExtractOrganisationId(jsonElement);
            ulong hiringOrgCVR = ExtractHiringOrgCVR(jsonElement);
            ulong id = ExtractID(jsonElement);

            string workPlaceCityWithoutZone = CreateWorkPlaceCityWithoutZone(workPlaceCity);
            string jobPostingId = CreateJobPostingId(id, title);

            string language = TryPredictLanguage(title, presentation);

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
                        jobPostingId: jobPostingId,
                        language: language
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
        private ulong ExtractWorkplaceID(JsonElement jsonElement)
        {

            ulong workplaceId = jsonElement.GetProperty("WorkplaceID").GetUInt64();

            return workplaceId;

        }
        private ulong? ExtractOrganisationId(JsonElement jsonElement)
        {

            string organizationId = jsonElement.GetProperty("OrganisationId").GetString();

            if (string.IsNullOrWhiteSpace(organizationId))
                return null;

            return ulong.Parse(organizationId);

        }
        private ulong ExtractHiringOrgCVR(JsonElement jsonElement)
        {

            ulong hiringOrgCVR = jsonElement.GetProperty("HiringOrgCVR").GetUInt64();

            return hiringOrgCVR;

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

        private string TryPredictLanguage(string title, string presentation)
        {

            /*
             
                The try...catch is to handle cases such as:

                    "System.Exception : The 'DoForBigrams' rule can't be applied to the provided string: 'carpenter '."

            */

            try
            {

                string text = CreateJobPostingText(title, presentation);
                string language = _classificationManager.PredictLanguage(text);

                return language;

            }
            catch
            {

                return null;

            }

        }
        private string CreateJobPostingText(string title, string presentation)
        {

            string text = string.Format("{0} {1}", title, presentation);

            return text;

        }
        private string RemoveHTMLTags(string presentation)
        {

            /*
                Some JobPosting.Presentation fields contains HTML tags, such as:

                    "<p><strong>German speaking Customer Service Representative for an international company in Copenhagen</strong></p>"
            */

            if (string.IsNullOrWhiteSpace(presentation))
                return presentation;

            HtmlDocument document = new HtmlDocument();
            document.LoadHtml(presentation);
            IEnumerable<string> nodes = document.DocumentNode.SelectNodes("//body//text()").Select(node => node.InnerText);

            StringBuilder stringBuilder = new StringBuilder();
            foreach (string node in nodes)
                stringBuilder.AppendLine(node);

            string clean = HttpUtility.HtmlDecode(stringBuilder.ToString());

            return clean;

        }

        #endregion

    }
}

/*
    Author: numbworks@gmail.com
    Last Update: 14.09.2021
*/