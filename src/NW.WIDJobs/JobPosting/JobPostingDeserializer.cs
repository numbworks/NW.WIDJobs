using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using System.Text.Encodings.Web;
using System.Text.RegularExpressions;
using System.Linq;

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

        private JsonSerializerOptions CreateJsonSerializerOptions()
        {

            JsonSerializerOptions jso = new JsonSerializerOptions();
            jso.Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping;

            return jso;

        }
        private List<JobPosting> Extract(JobPage jobPage)
        {

            JsonSerializerOptions jso = CreateJsonSerializerOptions();
            dynamic dyn = JsonSerializer.Deserialize<dynamic>(jobPage.Response, jso);

            List<JobPosting> jobPostings = new List<JobPosting>();
            List<string> jobPositionPostings = dyn.fields["JobPositionPostings"];
            for (ushort i = 0; i < (ushort)jobPositionPostings.Count; i++)
            {

                string jsonObject = jobPositionPostings[i];
                ushort jobPostingNumber = (ushort)(i + 1);

                JobPosting jobPosting
                    = ExtractJobPosting(jobPage.RunId, jobPage.PageNumber, jsonObject, jobPostingNumber);

                jobPostings.Add(jobPosting);

            }

            return jobPostings;

        }
        
        private JobPosting ExtractJobPosting
            (string runId, ushort pageNumber, string jsonObject, ushort jobPostingNumber)
        {

            JsonSerializerOptions jso = CreateJsonSerializerOptions();
            dynamic dyn = JsonSerializer.Deserialize<dynamic>(jsonObject, jso);

            string title = dyn.fields["Title"];
            string presentation = dyn.fields["Presentation"];
            string hiringOrgName = dyn.fields["HiringOrgName"];
            string workPlaceAddress = dyn.fields["WorkPlaceAddress"];
            ushort workPlacePostalCode = ushort.Parse(dyn.fields["WorkPlacePostalCode"]);
            string workPlaceCity = dyn.fields["WorkPlaceCity"];
            DateTime postingCreated = _jobPostingHelper.ParseDate(dyn.fields["PostingCreated"]);
            DateTime lastDateApplication = _jobPostingHelper.ParseDate(dyn.fields["LastDateApplication"]);
            string url = dyn.fields["Url"];
            string region = dyn.fields["Region"];
            string municipality = dyn.fields["Municipality"];
            string country = dyn.fields["Country"];
            string employmentType = CleanEmploymentType(dyn.fields["EmploymentType"]);
            string workHours = dyn.fields["WorkHours"];
            string occupation = dyn.fields["Occupation"];
            ulong workplaceId = ulong.Parse(dyn.fields["WorkplaceId"]);
            ulong organisationId = ulong.Parse(dyn.fields["OrganisationId"]);
            ulong hiringOrgCVR = ulong.Parse(dyn.fields["HiringOrgCVR"]);
            ulong id = CleanAndParseId(dyn.fields["Id"]);
            string workPlaceCityWithoutZone = CreateWorkPlaceCityWithoutZone(workPlaceCity);
            string jobPostingId = CreateJobPostingId(id, title);

            JobPosting jobPosting
                = new JobPosting(
                        runId: runId,
                        pageNumber: pageNumber,
                        response: jsonObject,
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
        private string CleanEmploymentType(string employmentType)
        {

            if (employmentType == string.Empty)
                return null;

            return employmentType;

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