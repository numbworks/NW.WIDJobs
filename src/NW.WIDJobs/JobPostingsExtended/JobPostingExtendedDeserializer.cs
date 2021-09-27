using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Text.RegularExpressions;
using System.Web;
using NW.WIDJobs.Classification;
using NW.WIDJobs.JobPostings;
using NW.WIDJobs.Validation;
using NW.WIDJobs.XPath;

namespace NW.WIDJobs.JobPostingsExtended
{
    /// <inheritdoc cref="IJobPostingExtendedDeserializer"/>
    public class JobPostingExtendedDeserializer : IJobPostingExtendedDeserializer
    {

        #region Fields

        private IXPathManager _xpathManager;
        private IClassificationManager _classificationManager;
        private bool _predictBulletPointType;

        #endregion

        #region Properties

        public static List<(string scenario, string pattern)> XPathPatterns
            = new List<(string scenario, string pattern)>()
            {
                ("novonordisk", "//ul/li/span/span/span/span"),
                ("jobportal", "//div[@class='vacancy_details_area']/ul/li"),
                ("easycruit", "//div[@class='jd-description']/ul/li"),
                ("coloplast", "//span[@class='jobdescription']/ul/li"),
                ("randstad", "//p[starts-with(., '-') and .//br]/text()"),
                ("keepit", "//p[starts-with(., '-')]"),
                ("generic", "//ul/li|//ol/li")
            };
        public static bool DefaultPredictBulletPointType { get; } = WIDExplorerSettings.DefaultPredictBulletPointType;

        #endregion

        #region Constructors

        /// <summary>Initializes a <see cref="JobPostingExtendedDeserializer"/> instance.</summary>
        /// <exception cref="ArgumentNullException"></exception>
        public JobPostingExtendedDeserializer(IXPathManager xpathManager, IClassificationManager classificationManager, bool predictBulletPointType)
        {

            Validator.ValidateObject(xpathManager, nameof(xpathManager));
            Validator.ValidateObject(classificationManager, nameof(classificationManager));

            _xpathManager = xpathManager;
            _classificationManager = classificationManager;
            _predictBulletPointType = predictBulletPointType;

        }

        /// <summary>Initializes a <see cref="JobPostingExtendedDeserializer"/> instance using default parameters.</summary>
        public JobPostingExtendedDeserializer()
            : this(new XPathManager(), new ClassificationManager(), DefaultPredictBulletPointType) { }

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

        private bool TryExtractAsJson(JobPosting jobPosting, string response, out JobPostingExtended jobPostingExtended)
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
                HashSet<string> bulletPointTexts = TryExtractBulletPointTexts(purpose, out bulletPointScenario);
                List<BulletPoint> bulletPoints = CreateBulletPoints(bulletPointTexts, _predictBulletPointType);

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
        private JobPostingExtended ExtractAsHtml(JobPosting jobPosting, string response)
        {

            string bulletPointScenario = null;
            HashSet<string> bulletPointTexts = TryExtractBulletPointTexts(response, out bulletPointScenario);
            List<BulletPoint> bulletPoints = CreateBulletPoints(bulletPointTexts, _predictBulletPointType);

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

            string purpose 
                =  jsonElement
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

        private HashSet<string> TryExtractBulletPointTexts(string content, out string bulletPointScenario)
        {

            HashSet<string> bulletPointTexts = TryExtractBulletPointTextsWithXPath(content, out bulletPointScenario);
            if (bulletPointTexts.Count == 0)
                bulletPointTexts = TryExtractBulletPointTextsWithRegex(content, out bulletPointScenario);

            bulletPointTexts = CleanBulletPointTexts(bulletPointTexts);

            (HashSet<string>, string) bulletPointTuples = FinalizeBulletPointTuples(bulletPointTexts, bulletPointScenario);
            bulletPointTexts = bulletPointTuples.Item1;
            bulletPointScenario = bulletPointTuples.Item2;

            return bulletPointTexts;

        }
        private HashSet<string> TryExtractBulletPointTextsWithXPath(string content, out string bulletPointScenario)
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

            HashSet<string> bulletPointTexts = new HashSet<string>(results);
            bulletPointScenario = scenario;

            return bulletPointTexts;

        }
        private HashSet<string> TryExtractBulletPointTextsWithRegex(string content, out string bulletPointScenario)
        {

            string pattern = "(?<=-\\t)[\\w ]{1,}(?=-\\t)";

            HashSet<string> bulletPointTexts = new HashSet<string>();

            MatchCollection matchCollection = Regex.Matches(content, pattern);
            if (matchCollection != null)
                matchCollection.Cast<Match>().ToList().ForEach(match => bulletPointTexts.Add(match.ToString()));

            bulletPointScenario = "regex";
            return bulletPointTexts;

        }

        private HashSet<string> CleanBulletPointTexts(HashSet<string> bulletPointTexts)
        {

            if (bulletPointTexts.Count == 0)
                return bulletPointTexts;

            HashSet<string> results
                = bulletPointTexts
                    .Select(bulletPoint => RemoveNewLines(bulletPoint))
                    .Select(bulletPoint => RemoveExtraWhiteSpaces(bulletPoint))
                    .Select(bulletPoint => RemoveInitialHyphen(bulletPoint))
                    .Select(bulletPoint => FixNonBreakingSpaceCharacters(bulletPoint))
                    .ToHashSet();

            return results;

        }
        private string RemoveNewLines(string str)
        {

            /*
                ...
                "Have the\n            ability to work very thorough with your tasks."
                ...
            */

            return str?.Replace(Environment.NewLine, string.Empty);

        }
        private string RemoveExtraWhiteSpaces(string str)
        {

            if (str != null)
                return string.Join(" ", str.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries));

            return str;

        }
        private string RemoveInitialHyphen(string str)
        {

            /*            
                "- Picking/packing tasks" => "Picking/packing tasks"
             */

            if (str != null)
                if (str.StartsWith("-"))
                {

                    str = str.Substring(1, str.Length - 1);
                    str = str.TrimStart();

                }
                
            return str;

        }
        private string FixNonBreakingSpaceCharacters(string str)
        {

            /*
                "\\u00A0Keep the company\\u00A0up-to-date with market trends and competition\\u00A0\\u00A0"
                    => "Keep the company up-to-date with market trends and competition"
            */

            if (str != null)
            {

                str = str.Replace("\u00A0", " ");
                str = str.TrimStart();
                str = str.TrimEnd();

            }

            return str;

        }

        private (HashSet<string>, string) FinalizeBulletPointTuples(HashSet<string> bulletPointTexts, string bulletPointScenario)
        {

            /*
                By default, if any of the available methods will be able to extract the bullet points, 
                the two bulletPoint* values will look as following:

                    ...
                    bulletPoints: new HashSet<string>() { },
                    bulletPointScenario: "regex"
                    ...

                This may obviously be confusing, therefore in these cases we set both equal to null:

                    ...
                    bulletPoints: null,
                    bulletPointScenario: null
                    ...	
            */

            if (bulletPointTexts.Count == 0)
                return (null, null);

            return (bulletPointTexts, bulletPointScenario);

        }
        private List<BulletPoint> CreateBulletPoints(HashSet<string> bulletPointTexts, bool predictBulletPointType)
        {

            if (bulletPointTexts == null)
                return null;

            List<BulletPoint> bulletPoints = new List<BulletPoint>();
            foreach (string bulletPointText in bulletPointTexts)
                if (IsSuitable(bulletPointText))
                {

                    string type = null;
                    if (predictBulletPointType)
                        type = _classificationManager.TryPredictBulletPointType(bulletPointText);

                    BulletPoint bulletPoint = new BulletPoint(bulletPointText, type);
                    bulletPoints.Add(bulletPoint);
                }

            return bulletPoints;

        }
        private bool IsSuitable(string bulletPointText)
        {

            if (string.IsNullOrWhiteSpace(bulletPointText))
                return false; // An empty text would make new BulletPoint() to throw an exception

            return true;

        }


        #endregion

    }
}

/*
    Author: numbworks@gmail.com
    Last Update: 16.09.2021
*/