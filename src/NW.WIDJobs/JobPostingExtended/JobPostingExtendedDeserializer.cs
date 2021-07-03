﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Text.RegularExpressions;

namespace NW.WIDJobs
{
    /// <inheritdoc cref="IJobPostingExtendedDeserializer"/>
    public class JobPostingExtendedDeserializer : IJobPostingExtendedDeserializer
    {

        #region Fields

        private IXPathManager _xpathManager;

        #endregion

        #region Properties

        public static List<(string domain, string pattern)> XPathPatterns
            = new List<(string domain, string pattern)>()
            {
                ("novonordisk.dk", "//ul/li/span/span/span/span"),
                ("jobportal.ku.dk", "//div[@class='vacancy_details_area']/ul/li"),
                ("easycruit.com", "//div[@class='jd-description']/ul/li"),
                ("coloplast.com", "//span[@class='jobdescription']/ul/li"),
                ("all", "//ul/li")
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
                DateTime employmentDate = ExtractEmploymentDate(jobPositionPosting);
                DateTime applicationDeadlineDate = ExtractApplicationDeadlineDate(jobPositionPosting);
                HashSet<string> bulletPoints = TryExtractBulletPoints(purpose);

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
                            bulletPoints: bulletPoints
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

            HashSet<string> bulletPoints = TryExtractBulletPoints(response);

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
                            bulletPoints: bulletPoints
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

            return jsonElement
                      .GetProperty("JobPositionInformation")
                      .GetProperty("Purpose")
                      .GetString();

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
                      .GetProperty("JppContacts")
                      .GetProperty("Email")
                      .GetString();

        }
        private string ExtractContactPersonName(JsonElement jsonElement)
        {

            return jsonElement
                      .GetProperty("JobPositionInformation")
                      .GetProperty("JppContacts")
                      .GetProperty("PersonName")
                      .GetString();

        }
        private DateTime ExtractEmploymentDate(JsonElement jsonElement)
        {

            return jsonElement
                      .GetProperty("JobPositionInformation")
                      .GetProperty("EmploymentDate")
                      .GetDateTime();

        }
        private DateTime ExtractApplicationDeadlineDate(JsonElement jsonElement)
        {

            return jsonElement
                      .GetProperty("ApplicationDetails")
                      .GetProperty("ApplicationDeadlineDate")
                      .GetDateTime();

        }

        private HashSet<string> TryExtractBulletPoints(string content)
        {

            HashSet<string> bulletPoints = TryExtractBulletPointsWithRegex(content);
            if (bulletPoints.Count == 0)
                bulletPoints = TryExtractBulletPointsWithXPath(content);

            return bulletPoints;

        }
        private HashSet<string> TryExtractBulletPointsWithXPath(string content)
        {

            /*
                Engineering degree within acoustics & vibration
                Detailed knowledge of material testing and dynamic vibration testing
                Detailed knowledge within NVH data acquisition systems and electrodynamic test equipment
                ...
             */

            List<string> results = new List<string>();
            List<string> patterns = XPathPatterns.Select(item => item.pattern).ToList();
            foreach (string pattern in patterns)
            {

                List<string> current = _xpathManager.GetInnerTexts(content, pattern);
                results.AddRange(current);

                // Once found the right pattern, we break to avoid similar results obtained using the other ones.
                if (current.Count != 0)
                    break; 

            }

            results = CleanBulletPoints(results);
            HashSet<string> bulletPoints = new HashSet<string>(results);

            return bulletPoints;

        }
        private HashSet<string> TryExtractBulletPointsWithRegex(string content)
        {

            string pattern = "(?<=-\\t)[\\w ]{1,}(?=-\\t)";

            HashSet<string> bulletPoints = new HashSet<string>();

            MatchCollection matchCollection = Regex.Matches(content, pattern);
            if (matchCollection != null)
                matchCollection.Cast<Match>().ToList().ForEach(match => bulletPoints.Add(match.ToString()));

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