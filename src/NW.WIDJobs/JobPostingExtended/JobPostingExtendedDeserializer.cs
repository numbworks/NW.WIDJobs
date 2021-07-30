using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Text.RegularExpressions;
using System.Web;

namespace NW.WIDJobs
{
    /// <inheritdoc cref="IJobPostingExtendedDeserializer"/>
    public class JobPostingExtendedDeserializer : IJobPostingExtendedDeserializer
    {

        #region Fields

        private IXPathManager _xpathManager;

        #endregion

        #region Properties

        public static List<(string scenario, string pattern)> XPathPatterns
            = new List<(string scenario, string pattern)>()
            {
                ("novonordisk.dk", "//ul/li/span/span/span/span"),
                ("jobportal.ku.dk", "//div[@class='vacancy_details_area']/ul/li"),
                ("easycruit.com", "//div[@class='jd-description']/ul/li"),
                ("coloplast.com", "//span[@class='jobdescription']/ul/li"),
                ("keepit.com", "//p[starts-with(., '-')]"),
                ("generic", "//ul/li")
            };

        #endregion

        #region Constructors

        /// <summary>Initializes a <see cref="JobPostingExtendedDeserializer"/> instance.</summary>
        /// <exception cref="ArgumentNullException"></exception>
        public JobPostingExtendedDeserializer(IXPathManager xpathManager)
        {

            Validator.ValidateObject(xpathManager, nameof(xpathManager));

            _xpathManager = xpathManager;

        }

        /// <summary>Initializes a <see cref="JobPostingExtendedDeserializer"/> instance using default parameters.</summary>
        public JobPostingExtendedDeserializer()
            : this(new XPathManager()) { }

        #endregion

        #region Methods_public

        public JobPostingExtended Do(JobPosting jobPosting, string response)
        {

            Validator.ValidateObject(jobPosting, nameof(jobPosting));
            Validator.ValidateStringNullOrWhiteSpace(response, nameof(response));

            JobPostingExtended jobPostingExtended;
            bool status = TryExtractAsJson(jobPosting, response, out jobPostingExtended);
            if (status == false)
                jobPostingExtended = ExtractAsHtml(jobPosting, response);

            return jobPostingExtended;

        }

        #endregion

        #region Methods_private

        private bool TryExtractAsJson
            (JobPosting jobPosting, string response, out JobPostingExtended jobPostingExtended)
        {

            try
            {

                using JsonDocument jsonRoot = JsonDocument.Parse(response);
                    JsonElement jobPositionPosting = jsonRoot.RootElement.GetProperty("JobPositionPosting");

                string hiringOrgDescription = ExtractHiringOrgDescription(jobPositionPosting);
                DateTime publicationStartDate = ExtractPublicationStartDate(jobPositionPosting);
                DateTime publicationEndDate = ExtractPublicationEndDate(jobPositionPosting);
                string purpose = ExtractPurpose(jobPositionPosting);
                ushort numberToFill = ExtractNumberToFill(jobPositionPosting);
                string contactEmail = ExtractContactEmail(jobPositionPosting);
                string contactPersonName = ExtractContactPersonName(jobPositionPosting);
                DateTime? employmentDate = TryExtractEmploymentDate(jobPositionPosting);
                DateTime applicationDeadlineDate = ExtractApplicationDeadlineDate(jobPositionPosting);

                string bulletPointScenario = null;
                HashSet<string> bulletPoints = TryExtractBulletPoints(purpose, out bulletPointScenario);

                jobPostingExtended
                    = new JobPostingExtended(
                            jobPosting: jobPosting,
                            response: response,
                            hiringOrgDescription: hiringOrgDescription,
                            publicationStartDate: publicationStartDate,
                            publicationEndDate: publicationEndDate,
                            purpose: purpose,
                            numberToFill: numberToFill,
                            contactEmail: contactEmail,
                            contactPersonName: contactPersonName,
                            employmentDate: employmentDate,
                            applicationDeadlineDate: applicationDeadlineDate,
                            bulletPoints: bulletPoints,
                            bulletPointScenario: bulletPointScenario
                        );

                return true;

            }
            catch
            {

                jobPostingExtended = null;
                return false;

            };

        }
        private JobPostingExtended ExtractAsHtml
            (JobPosting jobPosting, string response)
        {

            string bulletPointScenario = null;
            HashSet<string> bulletPoints = TryExtractBulletPoints(response, out bulletPointScenario);

            JobPostingExtended jobPostingExtended
                    = new JobPostingExtended(
                            jobPosting: jobPosting,
                            response: response,
                            hiringOrgDescription: null,
                            publicationStartDate: null,
                            publicationEndDate: null,
                            purpose: null,
                            numberToFill: null,
                            contactEmail: null,
                            contactPersonName: null,
                            employmentDate: null,
                            applicationDeadlineDate: null,
                            bulletPoints: bulletPoints,
                            bulletPointScenario: bulletPointScenario
                        );

            return jobPostingExtended;

        }

        private string ExtractHiringOrgDescription(JsonElement jsonElement)
        {

            return jsonElement
                        .GetProperty("HiringOrg")
                        .GetProperty("Description")
                        .GetString();

        }
        private DateTime ExtractPublicationStartDate(JsonElement jsonElement)
        {

            return jsonElement
                        .GetProperty("PublicationStartDate")
                        .GetDateTime();

        }
        private DateTime ExtractPublicationEndDate(JsonElement jsonElement)
        {

            return jsonElement
                        .GetProperty("PublicationEndDate")
                        .GetDateTime();

        }
        private string ExtractPurpose(JsonElement jsonElement)
        {

            string purpose =  jsonElement
                            .GetProperty("JobPositionInformation")
                            .GetProperty("Purpose")
                            .GetString();

            purpose = TryHtmlDecode(purpose);

            return purpose;

        }
        private ushort ExtractNumberToFill(JsonElement jsonElement)
        {

            return jsonElement
                        .GetProperty("JobPositionInformation")
                        .GetProperty("NumberToFill")
                        .GetUInt16();

        }
        private string ExtractContactEmail(JsonElement jsonElement)
        {

            return jsonElement
                      .GetProperty("JobPositionInformation")
                      .GetProperty("JppContacts")[0]
                      .GetProperty("Email")
                      .GetString();

        }
        private string ExtractContactPersonName(JsonElement jsonElement)
        {

            return jsonElement
                      .GetProperty("JobPositionInformation")
                      .GetProperty("JppContacts")[0]
                      .GetProperty("PersonName")
                      .GetString();

        }
        private DateTime? TryExtractEmploymentDate(JsonElement jsonElement)
        {

            JsonElement temp
                = jsonElement
                      .GetProperty("JobPositionInformation")
                      .GetProperty("EmploymentDate");
            if (string.IsNullOrWhiteSpace(temp.ToString()))
                return null;

            return jsonElement.GetDateTime();

        }
        private DateTime ExtractApplicationDeadlineDate(JsonElement jsonElement)
        {

            return jsonElement
                      .GetProperty("ApplicationDetails")
                      .GetProperty("ApplicationDeadlineDate")
                      .GetDateTime();

        }

        private string TryHtmlDecode(string str)
        {

            if (str != null)
                return HttpUtility.HtmlDecode(str);

            return str;

        }

        private HashSet<string> TryExtractBulletPoints(string content, out string bulletPointScenario)
        {

            HashSet<string> bulletPoints = TryExtractBulletPointsWithXPath(content, out bulletPointScenario);
            if (bulletPoints.Count == 0)
                bulletPoints = TryExtractBulletPointsWithRegex(content, out bulletPointScenario);

            return bulletPoints;

        }
        private HashSet<string> TryExtractBulletPointsWithXPath(string content, out string bulletPointScenario)
        {

            /*
                Engineering degree within acoustics & vibration
                Detailed knowledge of material testing and dynamic vibration testing
                Detailed knowledge within NVH data acquisition systems and electrodynamic test equipment
                ...
             */

            List<string> results = new List<string>();
            string scenario = null;

            List<string> patterns = XPathPatterns.Select(item => item.pattern).ToList();
            foreach (string pattern in patterns)
            {

                List<string> current = _xpathManager.GetInnerTexts(content, pattern);
                results.AddRange(current);

                // Once found the right pattern, we break to avoid similar results obtained using the other ones.
                if (current.Count != 0)
                {
                    scenario = XPathPatterns.Where(item => item.pattern == pattern).First().scenario;
                    break;
                }             

            }

            results = CleanBulletPoints(results);
            HashSet<string> bulletPoints = new HashSet<string>(results);

            bulletPointScenario = scenario;
            return bulletPoints;

        }
        private HashSet<string> TryExtractBulletPointsWithRegex(string content, out string bulletPointScenario)
        {

            string pattern = "(?<=-\\t)[\\w ]{1,}(?=-\\t)";

            HashSet<string> bulletPoints = new HashSet<string>();

            MatchCollection matchCollection = Regex.Matches(content, pattern);
            if (matchCollection != null)
                matchCollection.Cast<Match>().ToList().ForEach(match => bulletPoints.Add(match.ToString()));

            bulletPointScenario = "regex";
            return bulletPoints;

        }

        private List<string> CleanBulletPoints(List<string> bulletPoints)
        {

            /*
                ...
                "Have the\n            ability to work very thorough with your tasks."
                ...
            */

            if (bulletPoints.Count == 0)
                return bulletPoints;

            List<string> results
                = bulletPoints
                    .Select(bulletPoint => RemoveNewLines(bulletPoint))
                    .Select(bulletPoint => RemoveExtraWhiteSpaces(bulletPoint))
                    .ToList();

            return results;

        }
        private string RemoveNewLines(string str)
            => str?.Replace(Environment.NewLine, string.Empty);
        private string RemoveExtraWhiteSpaces(string str)
        {

            if (str != null)
                return string.Join(" ", str.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries));

            return str;
        }

        #endregion

    }
}

/*
    Author: numbworks@gmail.com
    Last Update: 02.07.2021
*/