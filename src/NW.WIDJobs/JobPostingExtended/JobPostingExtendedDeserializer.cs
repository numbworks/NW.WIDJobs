using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.RegularExpressions;

namespace NW.WIDJobs
{
    /// <inheritdoc cref="IJobPostingExtendedDeserializer"/>
    public class JobPostingExtendedDeserializer : IJobPostingExtendedDeserializer
    {

        #region Fields

        private IJobPostingHelper _jobPostingHelper;
        private IXPathManager _xpathManager;

        #endregion

        #region Properties
        #endregion

        #region Constructors

        /// <summary>Initializes a <see cref="JobPostingExtendedDeserializer"/> instance.</summary>
        /// <exception cref="ArgumentNullException"></exception>
        public JobPostingExtendedDeserializer
            (IJobPostingHelper jobPostingHelper, IXPathManager xpathManager)
        {

            Validator.ValidateObject(jobPostingHelper, nameof(jobPostingHelper));
            Validator.ValidateObject(xpathManager, nameof(xpathManager));

            _jobPostingHelper = jobPostingHelper;
            _xpathManager = xpathManager;

        }

        /// <summary>Initializes a <see cref="JobPostingExtendedDeserializer"/> instance using default parameters.</summary>
        public JobPostingExtendedDeserializer()
            : this(new JobPostingHelper(), new XPathManager()) { }

        #endregion

        #region Methods_public

        public JobPostingExtended Do(JobPosting jobPosting, string response)
        {

            Validator.ValidateObject(jobPosting, nameof(jobPosting));
            Validator.ValidateStringNullOrWhiteSpace(response, nameof(response));

            JobPostingExtended jobPostingExtended = Extract(jobPosting, response);

            return jobPostingExtended;

        }

        #endregion

        #region Methods_private

        private JsonSerializerOptions CreateJsonSerializerOptions()
        {

            JsonSerializerOptions jso = new JsonSerializerOptions();
            jso.Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping;

            return jso;

        }
        private JobPostingExtended Extract(JobPosting jobPosting, string response)
        {

            JsonSerializerOptions jso = CreateJsonSerializerOptions();
            dynamic dyn = JsonSerializer.Deserialize<dynamic>(response, jso);

            string hiringOrgDescription = TryExtractHiringOrgDescription(dyn);
            DateTime? publicationStartDate = TryExtractPublicationStartDate(dyn);
            DateTime? publicationEndDate = TryExtractPublicationEndDate(dyn);
            string purpose = TryExtractPurpose(dyn);
            ushort numberToFill = TryExtractNumberToFill(dyn);
            string contactEmail = TryExtractContactEmail(dyn);
            string contactPersonName = TryExtractContactPersonName(dyn);
            DateTime? employmentDate = TryExtractEmploymentDate(dyn);
            DateTime? applicationDeadlineDate = TryExtractApplicationDeadlineDate(dyn);
            HashSet<string> bulletPoints = TryExtractBulletPoints(purpose ?? response);

            JobPostingExtended jobPostingExtended
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

            return jobPostingExtended;

        }

        private string TryExtractHiringOrgDescription(dynamic dyn)
        {

            string value = dyn.fields["JobPositionPosting"].fields["HiringOrg"].fields["Description"];

            return value;

        }
        private DateTime? TryExtractPublicationStartDate(dynamic dyn)
        {

            string value = dyn.fields["JobPositionPosting"].fields["PublicationStartDate"];

            return _jobPostingHelper.TryParseDate(value);

        }
        private DateTime? TryExtractPublicationEndDate(dynamic dyn)
        {

            string value = dyn.fields["JobPositionPosting"].fields["PublicationEndDate"];

            return _jobPostingHelper.TryParseDate(value);

        }
        private string TryExtractPurpose(dynamic dyn)
        {

            string value = dyn.fields["JobPositionPosting"].fields["JobPositionInformation"].fields["Purpose"];

            return value;

        }
        private ushort? TryExtractNumberToFill(dynamic dyn)
        {

            string value = dyn.fields["JobPositionPosting"].fields["JobPositionInformation"].fields["NumberToFill"];
            if (value == null)
                return null;

            return ushort.Parse(value);

        }
        private string TryExtractContactEmail(dynamic dyn)
        {

            string value
                = dyn.fields["JobPositionPosting"]
                     .fields["JobPositionInformation"]
                     .fields["JppContacts"]
                     .fields["Email"];

            return value;

        }
        private string TryExtractContactPersonName(dynamic dyn)
        {

            string value
                = dyn.fields["JobPositionPosting"]
                     .fields["JobPositionInformation"]
                     .fields["JppContacts"]
                     .fields["PersonName"];

            return value;

        }
        private DateTime? TryExtractEmploymentDate(dynamic dyn)
        {

            string value
                = dyn.fields["JobPositionPosting"]
                     .fields["JobPositionInformation"]
                     .fields["EmploymentDate"];

            return _jobPostingHelper.TryParseDate(value);

        }
        private DateTime? TryExtractApplicationDeadlineDate(dynamic dyn)
        {

            string value
                = dyn.fields["JobPositionPosting"]
                     .fields["ApplicationDetails"]
                     .fields["ApplicationDeadlineDate"];

            return _jobPostingHelper.TryParseDate(value);

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

            string xpath = "//div[@class='row']/div[@class='col-sm-11']/div[@class='JobPresentation job-description' or @class='job-description']/ul/li";

            List<string> results = _xpathManager.GetInnerTexts(content, xpath);
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

        #endregion

    }
}

/*
    Author: numbworks@gmail.com
    Last Update: 02.07.2021
*/