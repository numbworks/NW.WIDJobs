using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using NW.WIDJobs.Database;
using NW.WIDJobs.Explorations;
using NW.WIDJobs.Filenames;
using NW.WIDJobs.Files;
using NW.WIDJobs.HttpRequests;
using NW.WIDJobs.JobPages;
using NW.WIDJobs.JobPostings;
using NW.WIDJobs.JobPostingsExtended;
using NW.WIDJobs.Metrics;
using NW.WIDJobs.Runs;
using NW.NGramTextClassification.LabeledExamples;
using NW.NGramTextClassification.NGrams;
using NW.NGramTextClassification.NGramTokenization;

namespace NW.WIDJobs.UnitTests
{
    public static class ObjectMother
    {

        #region Shared

        public static string Shared_FakeRunId = "FakeRunId";
        public static string Shared_UnexistantJobPostingId = "0000000fakeid";

        #endregion

        #region Shared_JobPage01

        public static string Shared_FakeResponse = "Fake response";
        public static string Shared_FakePurpose = "Fake purpose";
        public static string Shared_JobPage01_BodyUrl = "/CV/FindWork?Offset=0&SortValue=CreationDate&widk=true";

        public static string Shared_JobPage01_Content 
            = Properties.Resources.JobPage01_json;
        public static string Shared_JobPage01_JobPostingExtended01_Content
            = Properties.Resources.JobPage01_JobPostingExtended01_json;
        public static string Shared_JobPage01_JobPostingExtended02_Content
            = Properties.Resources.JobPage01_JobPostingExtended02_json;
        public static string Shared_JobPage01_JobPostingExtended03_Content
            = Properties.Resources.JobPage01_JobPostingExtended03_json;
        public static string Shared_JobPage01_JobPostingExtended04_Content
            = Properties.Resources.JobPage01_JobPostingExtended04_json;
        public static string Shared_JobPage01_JobPostingExtended05_Content
            = Properties.Resources.JobPage01_JobPostingExtended05_json;
        public static string Shared_JobPage01_JobPostingExtended06_Content
            = Properties.Resources.JobPage01_JobPostingExtended06_json;
        public static string Shared_JobPage01_JobPostingExtended07_Content
            = Properties.Resources.JobPage01_JobPostingExtended07_json;
        public static string Shared_JobPage01_JobPostingExtended08_Content
            = Properties.Resources.JobPage01_JobPostingExtended08_json;
        public static string Shared_JobPage01_JobPostingExtended09_Content
            = Properties.Resources.JobPage01_JobPostingExtended09_json;
        public static string Shared_JobPage01_JobPostingExtended10_Content
            = Properties.Resources.JobPage01_JobPostingExtended10_json;
        public static string Shared_JobPage01_JobPostingExtended11_Content
            = Properties.Resources.JobPage01_JobPostingExtended11_json;
        public static string Shared_JobPage01_JobPostingExtended12_Content
            = Properties.Resources.JobPage01_JobPostingExtended12_json;
        public static string Shared_JobPage01_JobPostingExtended13_Content
            = Properties.Resources.JobPage01_JobPostingExtended13_json;
        public static string Shared_JobPage01_JobPostingExtended14_Content
            = Properties.Resources.JobPage01_JobPostingExtended14_json;
        public static string Shared_JobPage01_JobPostingExtended15_Content
            = Properties.Resources.JobPage01_JobPostingExtended15_json;
        public static string Shared_JobPage01_JobPostingExtended16_Content
            = Properties.Resources.JobPage01_JobPostingExtended16_json;
        public static string Shared_JobPage01_JobPostingExtended17_Content
            = Properties.Resources.JobPage01_JobPostingExtended17_json;
        public static string Shared_JobPage01_JobPostingExtended18_Content
            = Properties.Resources.JobPage01_JobPostingExtended18_json;
        public static string Shared_JobPage01_JobPostingExtended19_Content
            = Properties.Resources.JobPage01_JobPostingExtended19_json;
        public static string Shared_JobPage01_JobPostingExtended20_Content
            = Properties.Resources.JobPage01_JobPostingExtended20_json;

        public static JobPosting Shared_JobPage01_JobPosting01
            = new JobPosting(
                    runId: Shared_FakeRunId,
                    pageNumber: 1,
                    response: "{\r\n            \"AutomatchType\": 0,\r\n            \"Abroad\": false,\r\n            \"Weight\": 1.0,\r\n            \"Title\": \"Linux Specialist\",\r\n            \"JobHeadline\": \"Linux Specialist\",\r\n            \"Presentation\": \"<p>PARKEN, COPENHAGEN /</p>\\n<p>ENGINEERING – SYSTEM ADMINISTRATION /</p>\\n<p>FULL TIME, PERMANENT CONTRACT</p>\\n\",\r\n            \"HiringOrgName\": \"Keepit A/S\",\r\n            \"WorkPlaceAddress\": \"Per Henrik Lings Allé 4 7\",\r\n            \"WorkPlacePostalCode\": \"2100\",\r\n            \"WorkPlaceCity\": \"København Ø\",\r\n            \"WorkPlaceOtherAddress\": false,\r\n            \"WorkPlaceAbroad\": false,\r\n            \"WorkPlaceNotStatic\": false,\r\n            \"UseWorkPlaceAddressForJoblog\": true,\r\n            \"PostingCreated\": \"2021-07-02T00:00:00\",\r\n            \"LastDateApplication\": \"2021-08-27T00:00:00\",\r\n            \"FormattedLastDateApplication\": \"27. august 2021\",\r\n            \"AssignmentStartDate\": \"0001-01-01T00:00:00\",\r\n            \"IsHotjob\": false,\r\n            \"IsExternal\": false,\r\n            \"Url\": \"https://job.jobnet.dk/CV/FindWork/Details/5332213\",\r\n            \"Region\": \"Hovedstaden og Bornholm\",\r\n            \"Municipality\": \"København\",\r\n            \"Country\": \"Danmark\",\r\n            \"PostalCode\": \"2100\",\r\n            \"PostalCodeName\": null,\r\n            \"JobAnnouncementType\": \"\",\r\n            \"EmploymentType\": \"\",\r\n            \"WorkHours\": \"Fuldtid\",\r\n            \"OccupationArea\": \"\",\r\n            \"OccupationGroup\": \"\",\r\n            \"Occupation\": \"Programmør og systemudvikler\",\r\n            \"Location\": {\r\n                \"Latitude\": 55.7038,\r\n                \"Longitude\": 12.5721\r\n            },\r\n            \"JoblogWorkTime\": {\r\n                \"WorkHour\": null,\r\n                \"DailyWorkTime\": null\r\n            },\r\n            \"WorkplaceID\": 133543,\r\n            \"OrganisationId\": \"117090\",\r\n            \"HiringOrgCVR\": 30806883,\r\n            \"UserLoggedIn\": false,\r\n            \"AnonymousEmployer\": false,\r\n            \"ShareUrl\": \"https://job.jobnet.dk/CV/FindWork/DetailsSocialmedia/5332213\",\r\n            \"DetailsUrl\": \"https://job.jobnet.dk/CV/FindWork/DetailsWidk/5332213\",\r\n            \"JobLogUrl\": \"https://job.jobnet.dk/CV/FindWork/Details/5332213\",\r\n            \"HasLocationValues\": true,\r\n            \"ID\": \"5332213\",\r\n            \"Latitude\": 55.7038,\r\n            \"Longitude\": 12.5721\r\n        }",
                    title: "Linux Specialist",
                    presentation: "<p>PARKEN, COPENHAGEN /</p>\n<p>ENGINEERING – SYSTEM ADMINISTRATION /</p>\n<p>FULL TIME, PERMANENT CONTRACT</p>\n",
                    hiringOrgName: "Keepit A/S",
                    workPlaceAddress: "Per Henrik Lings Allé 4 7",
                    workPlacePostalCode: 2100,
                    workPlaceCity: "København Ø",
                    postingCreated: new DateTime(2021, 07, 02),
                    lastDateApplication: new DateTime(2021, 08, 27),
                    url: "https://job.jobnet.dk/CV/FindWork/Details/5332213",
                    region: "Hovedstaden og Bornholm",
                    municipality: "København",
                    country: "Danmark",
                    employmentType: "",
                    workHours: "Fuldtid",
                    occupation: "Programmør og systemudvikler",
                    workplaceId: 133543,
                    organisationId: 117090,
                    hiringOrgCVR: 30806883,
                    id: 5332213,
                    workPlaceCityWithoutZone: "København",
                    jobPostingNumber: 1,
                    jobPostingId: "5332213linuxspecialist",
                    language: "en"
                );
        public static JobPostingExtended Shared_JobPage01_JobPostingExtended01
            = new JobPostingExtended(
                    jobPosting: Shared_JobPage01_JobPosting01,
                    response: Shared_FakeResponse,                      // Ignored
                    hiringOrgDescription: null,
                    publicationStartDate: new DateTime(2021, 07, 02),
                    publicationEndDate: new DateTime(2021, 08, 27),
                    purpose: Shared_FakePurpose,                        // Ignored
                    numberToFill: 1,
                    contactEmail: "edc@keepit.com",
                    contactPersonName: "Emil Daniel Christensen",
                    employmentDate: null,
                    applicationDeadlineDate: new DateTime(2021, 08, 27),
                    bulletPoints: new List<BulletPoint>()
                    {
                        new BulletPoint(
                            text: "Performance troubleshooting - if a service is not performing as expected, troubleshooting the process interactions on a live server in order to identify the root cause and propose a remedy, possibly in collaboration with the development team.",
                            type: null
                            ),
                        new BulletPoint(
                            text: "Planning, testing, and executing Postgres database cluster migration from an older version to a newer version with little or no user-visible interruptions.",
                            type: null
                            ),
                        new BulletPoint(
                            text: "Designing the next iteration of our network infrastructure for high-performance multi-site communication, and planning and executing the transition from the previous iteration with no customer visible downtime.",
                            type: null
                            )
                    },
                    bulletPointScenario: "keepit"
                );

        public static JobPosting Shared_JobPage01_JobPosting02
            = new JobPosting(
                    runId: Shared_FakeRunId,
                    pageNumber: 1,
                    response: "{\r\n            \"AutomatchType\": 0,\r\n            \"Abroad\": false,\r\n            \"Weight\": 1.0,\r\n            \"Title\": \"Motivated forklift drivers for temporary positions during the summer in Skanderborg\",\r\n            \"JobHeadline\": \"Motivated forklift drivers for temporary positions during the summer in Skanderborg\",\r\n            \"Presentation\": \" Are you looking to work during the Summer in the weeks between 27 to 36, then we have the job for you. \\n  We offer  \\n \\n Good work conditions \\n\",\r\n            \"HiringOrgName\": \"TeamVikaren.dk, Århus ApS, Horsens Afdeling\",\r\n            \"WorkPlaceAddress\": \"\",\r\n            \"WorkPlacePostalCode\": \"8660\",\r\n            \"WorkPlaceCity\": \"Skanderborg\",\r\n            \"WorkPlaceOtherAddress\": true,\r\n            \"WorkPlaceAbroad\": false,\r\n            \"WorkPlaceNotStatic\": false,\r\n            \"UseWorkPlaceAddressForJoblog\": false,\r\n            \"PostingCreated\": \"2021-07-02T00:00:00\",\r\n            \"LastDateApplication\": \"2021-08-04T00:00:00\",\r\n            \"FormattedLastDateApplication\": \"4. august 2021\",\r\n            \"AssignmentStartDate\": \"0001-01-01T00:00:00\",\r\n            \"IsHotjob\": false,\r\n            \"IsExternal\": false,\r\n            \"Url\": \"https://job.jobnet.dk/CV/FindWork/Details/5365786\",\r\n            \"Region\": \"Midtjylland\",\r\n            \"Municipality\": \"Skanderborg\",\r\n            \"Country\": \"Danmark\",\r\n            \"PostalCode\": \"8660\",\r\n            \"PostalCodeName\": null,\r\n            \"JobAnnouncementType\": \"\",\r\n            \"EmploymentType\": \"\",\r\n            \"WorkHours\": \"Fuldtid\",\r\n            \"OccupationArea\": \"\",\r\n            \"OccupationGroup\": \"\",\r\n            \"Occupation\": \"Truckfører\",\r\n            \"Location\": {\r\n                \"Latitude\": 56.0239,\r\n                \"Longitude\": 9.8924\r\n            },\r\n            \"JoblogWorkTime\": {\r\n                \"WorkHour\": null,\r\n                \"DailyWorkTime\": \"Dag, aften\"\r\n            },\r\n            \"WorkplaceID\": 126565,\r\n            \"OrganisationId\": \"71174\",\r\n            \"HiringOrgCVR\": 30899695,\r\n            \"UserLoggedIn\": false,\r\n            \"AnonymousEmployer\": false,\r\n            \"ShareUrl\": \"https://job.jobnet.dk/CV/FindWork/DetailsSocialmedia/5365786\",\r\n            \"DetailsUrl\": \"https://job.jobnet.dk/CV/FindWork/DetailsWidk/5365786\",\r\n            \"JobLogUrl\": \"https://job.jobnet.dk/CV/FindWork/Details/5365786\",\r\n            \"HasLocationValues\": true,\r\n            \"ID\": \"5365786\",\r\n            \"Latitude\": 56.0239,\r\n            \"Longitude\": 9.8924\r\n        }",
                    title: "Motivated forklift drivers for temporary positions during the summer in Skanderborg",
                    presentation: " Are you looking to work during the Summer in the weeks between 27 to 36, then we have the job for you. \n  We offer  \n \n Good work conditions \n",
                    hiringOrgName: "TeamVikaren.dk, Århus ApS, Horsens Afdeling",
                    workPlaceAddress: "",
                    workPlacePostalCode: 8660,
                    workPlaceCity: "Skanderborg",
                    postingCreated: new DateTime(2021, 07, 02),
                    lastDateApplication: new DateTime(2021, 08, 04),
                    url: "https://job.jobnet.dk/CV/FindWork/Details/5365786",
                    region: "Midtjylland",
                    municipality: "Skanderborg",
                    country: "Danmark",
                    employmentType: "",
                    workHours: "Fuldtid",
                    occupation: "Truckfører",
                    workplaceId: 126565,
                    organisationId: 71174,
                    hiringOrgCVR: 30899695,
                    id: 5365786,
                    workPlaceCityWithoutZone: "Skanderborg",
                    jobPostingNumber: 2,
                    jobPostingId: "5365786motivatedforkliftdriversfortemporary",
                    language: "dk/en" // To-do: this prediction must be improved (ClassificationManager).
                );
        public static JobPostingExtended Shared_JobPage01_JobPostingExtended02
            = new JobPostingExtended(
                    jobPosting: Shared_JobPage01_JobPosting02,
                    response: Shared_FakeResponse,                      // Ignored
                    hiringOrgDescription: null,
                    publicationStartDate: new DateTime(2021, 07, 02),
                    publicationEndDate: new DateTime(2021, 08, 04),
                    purpose: Shared_FakePurpose,                        // Ignored
                    numberToFill: 5,
                    contactEmail: null,
                    contactPersonName: "Majken Lorentzen",
                    employmentDate: null,
                    applicationDeadlineDate: new DateTime(2021, 08, 04),
                    bulletPoints: new List<BulletPoint>()
                    {
                        new BulletPoint(
                            text: "Good work conditions",
                            type: null
                            ),
                        new BulletPoint(
                            text: "A social workplace with good colleagues",
                            type: null
                            ),
                        new BulletPoint(
                            text: "Flexibility regarding shifts",
                            type: null
                            ),
                        new BulletPoint(
                            text: "Possibility for day and evening shifts",
                            type: null
                            ),
                        new BulletPoint(
                            text: "You want to work in warehousing and logistics",
                            type: null
                            ),
                        new BulletPoint(
                            text: "You can work a minimum of 3 weeks in the period week 27 - 36",
                            type: null
                            ),
                        new BulletPoint(
                            text: "You can work either day or evening",
                            type: null
                            ),
                        new BulletPoint(
                            text: "You have experience with forklift driving",
                            type: null
                            ),
                        new BulletPoint(
                            text: "You like working in teams",
                            type: null
                            )
                    },
                    bulletPointScenario: "generic"
                );

        public static JobPosting Shared_JobPage01_JobPosting03
            = new JobPosting(
                    runId: Shared_FakeRunId,
                    pageNumber: 1,
                    response: "{\r\n            \"AutomatchType\": 0,\r\n            \"Abroad\": false,\r\n            \"Weight\": 1.0,\r\n            \"Title\": \"Selvstændige truckførere til status og tælleopgave i Kolding/Forklift drivers for inventory assignment in Kolding\",\r\n            \"JobHeadline\": \"Selvstændige truckførere til status og tælleopgave i Kolding/Forklift drivers for inventory assignment in Kolding\",\r\n            \"Presentation\": \"<p><strong>English version below the Danish</strong></p>\\n\",\r\n            \"HiringOrgName\": \"TeamVikaren.dk, Århus ApS, Horsens Afdeling\",\r\n            \"WorkPlaceAddress\": \"\",\r\n            \"WorkPlacePostalCode\": \"6000\",\r\n            \"WorkPlaceCity\": \"Kolding\",\r\n            \"WorkPlaceOtherAddress\": true,\r\n            \"WorkPlaceAbroad\": false,\r\n            \"WorkPlaceNotStatic\": false,\r\n            \"UseWorkPlaceAddressForJoblog\": false,\r\n            \"PostingCreated\": \"2021-07-02T00:00:00\",\r\n            \"LastDateApplication\": \"2021-08-13T00:00:00\",\r\n            \"FormattedLastDateApplication\": \"13. august 2021\",\r\n            \"AssignmentStartDate\": \"0001-01-01T00:00:00\",\r\n            \"IsHotjob\": false,\r\n            \"IsExternal\": false,\r\n            \"Url\": \"https://job.jobnet.dk/CV/FindWork/Details/5372675\",\r\n            \"Region\": \"Syddanmark\",\r\n            \"Municipality\": \"Kolding\",\r\n            \"Country\": \"Danmark\",\r\n            \"PostalCode\": \"6000\",\r\n            \"PostalCodeName\": null,\r\n            \"JobAnnouncementType\": \"\",\r\n            \"EmploymentType\": \"\",\r\n            \"WorkHours\": \"Fuldtid\",\r\n            \"OccupationArea\": \"\",\r\n            \"OccupationGroup\": \"\",\r\n            \"Occupation\": \"Truckfører\",\r\n            \"Location\": {\r\n                \"Latitude\": 55.5022,\r\n                \"Longitude\": 9.4685\r\n            },\r\n            \"JoblogWorkTime\": {\r\n                \"WorkHour\": null,\r\n                \"DailyWorkTime\": \"Dag\"\r\n            },\r\n            \"WorkplaceID\": 126565,\r\n            \"OrganisationId\": \"71174\",\r\n            \"HiringOrgCVR\": 30899695,\r\n            \"UserLoggedIn\": false,\r\n            \"AnonymousEmployer\": false,\r\n            \"ShareUrl\": \"https://job.jobnet.dk/CV/FindWork/DetailsSocialmedia/5372675\",\r\n            \"DetailsUrl\": \"https://job.jobnet.dk/CV/FindWork/DetailsWidk/5372675\",\r\n            \"JobLogUrl\": \"https://job.jobnet.dk/CV/FindWork/Details/5372675\",\r\n            \"HasLocationValues\": true,\r\n            \"ID\": \"5372675\",\r\n            \"Latitude\": 55.5022,\r\n            \"Longitude\": 9.4685\r\n        }",
                    title: "Selvstændige truckførere til status og tælleopgave i Kolding/Forklift drivers for inventory assignment in Kolding",
                    presentation: "<p><strong>English version below the Danish</strong></p>\n",
                    hiringOrgName: "TeamVikaren.dk, Århus ApS, Horsens Afdeling",
                    workPlaceAddress: "",
                    workPlacePostalCode: 6000,
                    workPlaceCity: "Kolding",
                    postingCreated: new DateTime(2021, 07, 02),
                    lastDateApplication: new DateTime(2021, 08, 13),
                    url: "https://job.jobnet.dk/CV/FindWork/Details/5372675",
                    region: "Syddanmark",
                    municipality: "Kolding",
                    country: "Danmark",
                    employmentType: "",
                    workHours: "Fuldtid",
                    occupation: "Truckfører",
                    workplaceId: 126565,
                    organisationId: 71174,
                    hiringOrgCVR: 30899695,
                    id: 5372675,
                    workPlaceCityWithoutZone: "Kolding",
                    jobPostingNumber: 3,
                    jobPostingId: "5372675selvstndigetruckfreretil",
                    language: "dk/en"
                );
        public static JobPostingExtended Shared_JobPage01_JobPostingExtended03
            = new JobPostingExtended(
                    jobPosting: Shared_JobPage01_JobPosting03,
                    response: Shared_FakeResponse,                      // Ignored
                    hiringOrgDescription: null,
                    publicationStartDate: new DateTime(2021, 07, 02),
                    publicationEndDate: new DateTime(2021, 08, 13),
                    purpose: Shared_FakePurpose,                        // Ignored
                    numberToFill: 2,
                    contactEmail: null,
                    contactPersonName: "Majken Lorentzen",
                    employmentDate: null,
                    applicationDeadlineDate: new DateTime(2021, 08, 13),
                    bulletPoints: new List<BulletPoint>()
                    {
                        new BulletPoint(
                            text: "Ordnede forhold",
                            type: null
                            ),
                        new BulletPoint(
                            text: "Attraktiv løn",
                            type: null
                            ),
                        new BulletPoint(
                            text: "En social arbejdsplads med gode kollegaer",
                            type: null
                            ),
                        new BulletPoint(
                            text: "Mulighed for vagter på daghold",
                            type: null
                            ),
                        new BulletPoint(
                            text: "Du har lyst til at arbejde inden for lager og logistik",
                            type: null
                            ),
                        new BulletPoint(
                            text: "Du kan arbejde om dagen",
                            type: null
                            ),
                        new BulletPoint(
                            text: "Du har gerne erfaring med truckkørsel – dog ikke et krav",
                            type: null
                            ),
                        new BulletPoint(
                            text: "Du kan lide at arbejde i teams",
                            type: null
                            ),
                        new BulletPoint(
                            text: "Du må ikke være talblind",
                            type: null
                            ),
                        new BulletPoint(
                            text: "Du kan arbejde i ugerne 29 og 30, eller en af ugerne",
                            type: null
                            ),
                        new BulletPoint(
                            text: "Orderly conditions",
                            type: null
                            ),
                        new BulletPoint(
                            text: "Attractive salary",
                            type: null
                            ),
                        new BulletPoint(
                            text: "A social workplace with good colleagues",
                            type: null
                            ),
                        new BulletPoint(
                            text: "Day shifts",
                            type: null
                            ),
                        new BulletPoint(
                            text: "You want to work in warehousing and logistics",
                            type: null
                            ),
                        new BulletPoint(
                            text: "You can work during the day",
                            type: null
                            ),
                        new BulletPoint(
                            text: "You would like to have experience with truck driving - but not a requirement",
                            type: null
                            ),
                        new BulletPoint(
                            text: "You must be able to count",
                            type: null
                            ),
                        new BulletPoint(
                            text: "You can work in weeks 29 and 30, or one of the weeks",
                            type: null
                            )                        
                    },
                    bulletPointScenario: "generic"
                );

        public static JobPosting Shared_JobPage01_JobPosting04
            = new JobPosting(
                    runId: Shared_FakeRunId,
                    pageNumber: 1,
                    response: "{\r\n            \"AutomatchType\": 0,\r\n            \"Abroad\": false,\r\n            \"Weight\": 1.0,\r\n            \"Title\": \"Erfaren og selvstændig truckfører til virksomhed i Skanderborg/Experienced forklift driver for a company in Skanderborg\",\r\n            \"JobHeadline\": \"Erfaren og selvstændig truckfører til virksomhed i Skanderborg/Experienced forklift driver for a company in Skanderborg\",\r\n            \"Presentation\": \"<p><strong>English version below the Danish</strong></p>\\n<p>Har du erfaring med lager og truckkørsel og kan du lide af arbejde aftener, så har vi jobbet til dig.</p>\\n<p><strong>Jobbet</strong></p>\\n\",\r\n            \"HiringOrgName\": \"TeamVikaren.dk, Århus ApS, Horsens Afdeling\",\r\n            \"WorkPlaceAddress\": \"\",\r\n            \"WorkPlacePostalCode\": \"8660\",\r\n            \"WorkPlaceCity\": \"Skanderborg\",\r\n            \"WorkPlaceOtherAddress\": true,\r\n            \"WorkPlaceAbroad\": false,\r\n            \"WorkPlaceNotStatic\": false,\r\n            \"UseWorkPlaceAddressForJoblog\": false,\r\n            \"PostingCreated\": \"2021-07-02T00:00:00\",\r\n            \"LastDateApplication\": \"2021-08-24T00:00:00\",\r\n            \"FormattedLastDateApplication\": \"24. august 2021\",\r\n            \"AssignmentStartDate\": \"0001-01-01T00:00:00\",\r\n            \"IsHotjob\": false,\r\n            \"IsExternal\": false,\r\n            \"Url\": \"https://job.jobnet.dk/CV/FindWork/Details/5379659\",\r\n            \"Region\": \"Midtjylland\",\r\n            \"Municipality\": \"Skanderborg\",\r\n            \"Country\": \"Danmark\",\r\n            \"PostalCode\": \"8660\",\r\n            \"PostalCodeName\": null,\r\n            \"JobAnnouncementType\": \"\",\r\n            \"EmploymentType\": \"\",\r\n            \"WorkHours\": \"Fuldtid\",\r\n            \"OccupationArea\": \"\",\r\n            \"OccupationGroup\": \"\",\r\n            \"Occupation\": \"Truckfører\",\r\n            \"Location\": {\r\n                \"Latitude\": 56.0239,\r\n                \"Longitude\": 9.8924\r\n            },\r\n            \"JoblogWorkTime\": {\r\n                \"WorkHour\": null,\r\n                \"DailyWorkTime\": \"Aften\"\r\n            },\r\n            \"WorkplaceID\": 126565,\r\n            \"OrganisationId\": \"71174\",\r\n            \"HiringOrgCVR\": 30899695,\r\n            \"UserLoggedIn\": false,\r\n            \"AnonymousEmployer\": false,\r\n            \"ShareUrl\": \"https://job.jobnet.dk/CV/FindWork/DetailsSocialmedia/5379659\",\r\n            \"DetailsUrl\": \"https://job.jobnet.dk/CV/FindWork/DetailsWidk/5379659\",\r\n            \"JobLogUrl\": \"https://job.jobnet.dk/CV/FindWork/Details/5379659\",\r\n            \"HasLocationValues\": true,\r\n            \"ID\": \"5379659\",\r\n            \"Latitude\": 56.0239,\r\n            \"Longitude\": 9.8924\r\n        }",
                    title: "Erfaren og selvstændig truckfører til virksomhed i Skanderborg/Experienced forklift driver for a company in Skanderborg",
                    presentation: "<p><strong>English version below the Danish</strong></p>\n<p>Har du erfaring med lager og truckkørsel og kan du lide af arbejde aftener, så har vi jobbet til dig.</p>\n<p><strong>Jobbet</strong></p>\n",
                    hiringOrgName: "TeamVikaren.dk, Århus ApS, Horsens Afdeling",
                    workPlaceAddress: "",
                    workPlacePostalCode: 8660,
                    workPlaceCity: "Skanderborg",
                    postingCreated: new DateTime(2021, 07, 02),
                    lastDateApplication: new DateTime(2021, 08, 24),
                    url: "https://job.jobnet.dk/CV/FindWork/Details/5379659",
                    region: "Midtjylland",
                    municipality: "Skanderborg",
                    country: "Danmark",
                    employmentType: "",
                    workHours: "Fuldtid",
                    occupation: "Truckfører",
                    workplaceId: 126565,
                    organisationId: 71174,
                    hiringOrgCVR: 30899695,
                    id: 5379659,
                    workPlaceCityWithoutZone: "Skanderborg",
                    jobPostingNumber: 4,
                    jobPostingId: "5379659erfarenogselvstndigtruckf",
                    language: "dk/en"
                );
        public static JobPostingExtended Shared_JobPage01_JobPostingExtended04
            = new JobPostingExtended(
                    jobPosting: Shared_JobPage01_JobPosting04,
                    response: Shared_FakeResponse,                      // Ignored
                    hiringOrgDescription: null,
                    publicationStartDate: new DateTime(2021, 07, 02),
                    publicationEndDate: new DateTime(2021, 08, 24),
                    purpose: Shared_FakePurpose,                        // Ignored
                    numberToFill: 1,
                    contactEmail: null,
                    contactPersonName: "Majken Lorentzen",
                    employmentDate: null,
                    applicationDeadlineDate: new DateTime(2021, 08, 24),
                    bulletPoints: new List<BulletPoint>()
                    {

                        new BulletPoint(
                            text: "Du har truckkort",
                            type: null
                            ),
                        new BulletPoint(
                            text: "Du kan lide at arbejde om aftenen",
                            type: null
                            ),
                        new BulletPoint(
                            text: "Du kan tale, skrive og læse dansk eller engelsk",
                            type: null
                            ),
                        new BulletPoint(
                            text: "Du kan arbejde selvstændigt",
                            type: null
                            ),
                        new BulletPoint(
                            text: "Du er grundig i dit arbejde",
                            type: null
                            ),
                        new BulletPoint(
                            text: "You have a forklift licence",
                            type: null
                            ),
                        new BulletPoint(
                            text: "You like working in the evenings",
                            type: null
                            ),
                        new BulletPoint(
                            text: "You can speak, write and read Danish or English",
                            type: null
                            ),
                        new BulletPoint(
                            text: "You can work independently",
                            type: null
                            ),
                        new BulletPoint(
                            text: "You are thorough in your work",
                            type: null
                            )
                        
                    },
                    bulletPointScenario: "generic"
                );

        public static JobPosting Shared_JobPage01_JobPosting05
            = new JobPosting(
                    runId: Shared_FakeRunId,
                    pageNumber: 1,
                    response: "{\r\n            \"AutomatchType\": 0,\r\n            \"Abroad\": false,\r\n            \"Weight\": 1.0,\r\n            \"Title\": \"Vi søger rengøringsassistenter til weekendarbejde i Vejers Strand/We are looking for cleaning assistants for weekend work in Vejers Strand\",\r\n            \"JobHeadline\": \"Vi søger rengøringsassistenter til weekendarbejde i Vejers Strand/We are looking for cleaning assistants for weekend work in Vejers Strand\",\r\n            \"Presentation\": \"<p><strong>English version below the Danish</strong></p>\\n<p>Vi søger rengøringsassistenter til weekendarbejde i Vejers Strand.</p>\\n\",\r\n            \"HiringOrgName\": \"TeamVikaren.dk, Århus ApS, Horsens Afdeling\",\r\n            \"WorkPlaceAddress\": \"\",\r\n            \"WorkPlacePostalCode\": \"6853\",\r\n            \"WorkPlaceCity\": \"Vejers Strand\",\r\n            \"WorkPlaceOtherAddress\": true,\r\n            \"WorkPlaceAbroad\": false,\r\n            \"WorkPlaceNotStatic\": false,\r\n            \"UseWorkPlaceAddressForJoblog\": false,\r\n            \"PostingCreated\": \"2021-07-02T00:00:00\",\r\n            \"LastDateApplication\": \"2021-08-19T00:00:00\",\r\n            \"FormattedLastDateApplication\": \"19. august 2021\",\r\n            \"AssignmentStartDate\": \"0001-01-01T00:00:00\",\r\n            \"IsHotjob\": false,\r\n            \"IsExternal\": false,\r\n            \"Url\": \"https://job.jobnet.dk/CV/FindWork/Details/5376524\",\r\n            \"Region\": \"Syddanmark\",\r\n            \"Municipality\": \"Varde\",\r\n            \"Country\": \"Danmark\",\r\n            \"PostalCode\": \"6853\",\r\n            \"PostalCodeName\": null,\r\n            \"JobAnnouncementType\": \"\",\r\n            \"EmploymentType\": \"\",\r\n            \"WorkHours\": \"Deltid\",\r\n            \"OccupationArea\": \"\",\r\n            \"OccupationGroup\": \"\",\r\n            \"Occupation\": \"Rengøringsassistent\",\r\n            \"Location\": {\r\n                \"Latitude\": 55.4329,\r\n                \"Longitude\": 5.2422\r\n            },\r\n            \"JoblogWorkTime\": {\r\n                \"WorkHour\": \"(0 - 12 timer ugentligt)\",\r\n                \"DailyWorkTime\": \"Weekend\"\r\n            },\r\n            \"WorkplaceID\": 126565,\r\n            \"OrganisationId\": \"71174\",\r\n            \"HiringOrgCVR\": 30899695,\r\n            \"UserLoggedIn\": false,\r\n            \"AnonymousEmployer\": false,\r\n            \"ShareUrl\": \"https://job.jobnet.dk/CV/FindWork/DetailsSocialmedia/5376524\",\r\n            \"DetailsUrl\": \"https://job.jobnet.dk/CV/FindWork/DetailsWidk/5376524\",\r\n            \"JobLogUrl\": \"https://job.jobnet.dk/CV/FindWork/Details/5376524\",\r\n            \"HasLocationValues\": true,\r\n            \"ID\": \"5376524\",\r\n            \"Latitude\": 55.4329,\r\n            \"Longitude\": 5.2422\r\n        }",
                    title: "Vi søger rengøringsassistenter til weekendarbejde i Vejers Strand/We are looking for cleaning assistants for weekend work in Vejers Strand",
                    presentation: "<p><strong>English version below the Danish</strong></p>\n<p>Vi søger rengøringsassistenter til weekendarbejde i Vejers Strand.</p>\n",
                    hiringOrgName: "TeamVikaren.dk, Århus ApS, Horsens Afdeling",
                    workPlaceAddress: "",
                    workPlacePostalCode: 6853,
                    workPlaceCity: "Vejers Strand",
                    postingCreated: new DateTime(2021, 07, 02),
                    lastDateApplication: new DateTime(2021, 08, 19),
                    url: "https://job.jobnet.dk/CV/FindWork/Details/5376524",
                    region: "Syddanmark",
                    municipality: "Varde",
                    country: "Danmark",
                    employmentType: "",
                    workHours: "Deltid",
                    occupation: "Rengøringsassistent",
                    workplaceId: 126565,
                    organisationId: 71174,
                    hiringOrgCVR: 30899695,
                    id: 5376524,
                    workPlaceCityWithoutZone: "Vejers Strand",
                    jobPostingNumber: 5,
                    jobPostingId: "5376524visgerrengringsassistenter",
                    language: "dk/en"
                );
        public static JobPostingExtended Shared_JobPage01_JobPostingExtended05
            = new JobPostingExtended(
                    jobPosting: Shared_JobPage01_JobPosting05,
                    response: Shared_FakeResponse,                      // Ignored
                    hiringOrgDescription: null,
                    publicationStartDate: new DateTime(2021, 07, 02),
                    publicationEndDate: new DateTime(2021, 08, 19),
                    purpose: Shared_FakePurpose,                        // Ignored
                    numberToFill: 20,
                    contactEmail: null,
                    contactPersonName: "Majken Lorentzen",
                    employmentDate: null,
                    applicationDeadlineDate: new DateTime(2021, 08, 19),
                    bulletPoints: new List<BulletPoint>()
                    {

                        new BulletPoint(
                            text: "Fleksible arbejdstider",
                            type: null
                            ),
                        new BulletPoint(
                            text: "Attraktiv løn (DKK 180,- per time)",
                            type: null
                            ),
                        new BulletPoint(
                            text: "Kørselsgodtgørelse (statens takst)",
                            type: null
                            ),
                        new BulletPoint(
                            text: "Aktivt og alsidigt arbejde",
                            type: null
                            ),
                        new BulletPoint(
                            text: "Du kan arbejde i weekender",
                            type: null
                            ),
                        new BulletPoint(
                            text: "Du har egen bil til rådighed",
                            type: null
                            ),
                        new BulletPoint(
                            text: "Du kan lide aktivt arbejde",
                            type: null
                            ),
                        new BulletPoint(
                            text: "Du har erfaring fra tidligere arbejde – dog ikke et krav",
                            type: null
                            ),
                        new BulletPoint(
                            text: "Du taler, læser og skriver dansk, engelsk eller tysk",
                            type: null
                            ),
                        new BulletPoint(
                            text: "Flexible hours",
                            type: null
                            ),
                        new BulletPoint(
                            text: "Attractive salary (DKK 180 per hour)",
                            type: null
                            ),
                        new BulletPoint(
                            text: "Travel allowance (state tariff)",
                            type: null
                            ),
                        new BulletPoint(
                            text: "Active and versatile work",
                            type: null
                            ),
                        new BulletPoint(
                            text: "You can work on weekends",
                            type: null
                            ),
                        new BulletPoint(
                            text: "You have your own car available",
                            type: null
                            ),
                        new BulletPoint(
                            text: "You like active work",
                            type: null
                            ),
                        new BulletPoint(
                            text: "You have experience from previous work - not a requirement",
                            type: null
                            ),
                        new BulletPoint(
                            text: "You speak, read and write Danish, English or German",
                            type: null
                            )
                        
                    },
                    bulletPointScenario: "generic"
                );

        public static JobPosting Shared_JobPage01_JobPosting06
            = new JobPosting(
                    runId: Shared_FakeRunId,
                    pageNumber: 1,
                    response: "{\r\n            \"AutomatchType\": 0,\r\n            \"Abroad\": false,\r\n            \"Weight\": 1.0,\r\n            \"Title\": \"Motivated employees for warehouse work in Vejen, start-up as soon as possible\",\r\n            \"JobHeadline\": \"Motivated employees for warehouse work in Vejen, start-up as soon as possible\",\r\n            \"Presentation\": \" Do you want to help make a difference at our customer in Vejen, and can you start with short notice? Then we have the job for you. \\n  We offer  \\n \\n A social workplace\",\r\n            \"HiringOrgName\": \"TeamVikaren.dk, Århus ApS, Horsens Afdeling\",\r\n            \"WorkPlaceAddress\": \"\",\r\n            \"WorkPlacePostalCode\": \"6600\",\r\n            \"WorkPlaceCity\": \"Vejen\",\r\n            \"WorkPlaceOtherAddress\": true,\r\n            \"WorkPlaceAbroad\": false,\r\n            \"WorkPlaceNotStatic\": false,\r\n            \"UseWorkPlaceAddressForJoblog\": false,\r\n            \"PostingCreated\": \"2021-07-02T00:00:00\",\r\n            \"LastDateApplication\": \"2021-08-27T00:00:00\",\r\n            \"FormattedLastDateApplication\": \"27. august 2021\",\r\n            \"AssignmentStartDate\": \"0001-01-01T00:00:00\",\r\n            \"IsHotjob\": false,\r\n            \"IsExternal\": false,\r\n            \"Url\": \"https://job.jobnet.dk/CV/FindWork/Details/5303321\",\r\n            \"Region\": \"Syddanmark\",\r\n            \"Municipality\": \"Vejen\",\r\n            \"Country\": \"Danmark\",\r\n            \"PostalCode\": \"6600\",\r\n            \"PostalCodeName\": null,\r\n            \"JobAnnouncementType\": \"\",\r\n            \"EmploymentType\": \"\",\r\n            \"WorkHours\": \"Fuldtid\",\r\n            \"OccupationArea\": \"\",\r\n            \"OccupationGroup\": \"\",\r\n            \"Occupation\": \"Lager- og logistikmedarbejder\",\r\n            \"Location\": {\r\n                \"Latitude\": 55.4784,\r\n                \"Longitude\": 9.112\r\n            },\r\n            \"JoblogWorkTime\": {\r\n                \"WorkHour\": null,\r\n                \"DailyWorkTime\": \"Dag\"\r\n            },\r\n            \"WorkplaceID\": 126565,\r\n            \"OrganisationId\": \"71174\",\r\n            \"HiringOrgCVR\": 30899695,\r\n            \"UserLoggedIn\": false,\r\n            \"AnonymousEmployer\": false,\r\n            \"ShareUrl\": \"https://job.jobnet.dk/CV/FindWork/DetailsSocialmedia/5303321\",\r\n            \"DetailsUrl\": \"https://job.jobnet.dk/CV/FindWork/DetailsWidk/5303321\",\r\n            \"JobLogUrl\": \"https://job.jobnet.dk/CV/FindWork/Details/5303321\",\r\n            \"HasLocationValues\": true,\r\n            \"ID\": \"5303321\",\r\n            \"Latitude\": 55.4784,\r\n            \"Longitude\": 9.112\r\n        }",
                    title: "Motivated employees for warehouse work in Vejen, start-up as soon as possible",
                    presentation: " Do you want to help make a difference at our customer in Vejen, and can you start with short notice? Then we have the job for you. \n  We offer  \n \n A social workplace",
                    hiringOrgName: "TeamVikaren.dk, Århus ApS, Horsens Afdeling",
                    workPlaceAddress: "",
                    workPlacePostalCode: 6600,
                    workPlaceCity: "Vejen",
                    postingCreated: new DateTime(2021, 07, 02),
                    lastDateApplication: new DateTime(2021, 08, 27),
                    url: "https://job.jobnet.dk/CV/FindWork/Details/5303321",
                    region: "Syddanmark",
                    municipality: "Vejen",
                    country: "Danmark",
                    employmentType: "",
                    workHours: "Fuldtid",
                    occupation: "Lager- og logistikmedarbejder",
                    workplaceId: 126565,
                    organisationId: 71174,
                    hiringOrgCVR: 30899695,
                    id: 5303321,
                    workPlaceCityWithoutZone: "Vejen",
                    jobPostingNumber: 6,
                    jobPostingId: "5303321motivatedemployeesforwarehousework",
                    language: "en"
                );
        public static JobPostingExtended Shared_JobPage01_JobPostingExtended06
            = new JobPostingExtended(
                    jobPosting: Shared_JobPage01_JobPosting06,
                    response: Shared_FakeResponse,                      // Ignored
                    hiringOrgDescription: null,
                    publicationStartDate: new DateTime(2021, 07, 02),
                    publicationEndDate: new DateTime(2021, 08, 27),
                    purpose: Shared_FakePurpose,                        // Ignored
                    numberToFill: 12,
                    contactEmail: null,
                    contactPersonName: "Majken Lorentzen",
                    employmentDate: null,
                    applicationDeadlineDate: new DateTime(2021, 08, 27),
                    bulletPoints: new List<BulletPoint>()
                    {

                        new BulletPoint(
                            text: "A social workplace",
                            type: null
                            ),
                        new BulletPoint(
                            text: "Day shifts",
                            type: null
                            ),
                        new BulletPoint(
                            text: "A healthy working environment",
                            type: null
                            ),
                        new BulletPoint(
                            text: "Good colleagues",
                            type: null
                            ),
                        new BulletPoint(
                            text: "Training in warehouse work such as picking, packing, sorting and much more",
                            type: null
                            ),
                        new BulletPoint(
                            text: "You would like to work in a warehouse",
                            type: null
                            ),
                        new BulletPoint(
                            text: "You like active work",
                            type: null
                            ),
                        new BulletPoint(
                            text: "You can work full time – part time work can also be arranged",
                            type: null
                            ),
                        new BulletPoint(
                            text: "You can work independently",
                            type: null
                            )
                        
                    },
                    bulletPointScenario: "generic"
                );

        public static JobPosting Shared_JobPage01_JobPosting07
            = new JobPosting(
                    runId: Shared_FakeRunId,
                    pageNumber: 1,
                    response: "{\r\n            \"AutomatchType\": 0,\r\n            \"Abroad\": false,\r\n            \"Weight\": 1.0,\r\n            \"Title\": \"Motivated employees for warehouse work in Kolding - full time and part time work , start-up as soon as possible\",\r\n            \"JobHeadline\": \"Motivated employees for warehouse work in Kolding - full time and part time work , start-up as soon as possible\",\r\n            \"Presentation\": \" Do you want to help make a difference at our customer in Kolding, and can you start with short notice? Then we have the job for you. \\n  We offer  \\n \\n\",\r\n            \"HiringOrgName\": \"TeamVikaren.dk, Århus ApS, Horsens Afdeling\",\r\n            \"WorkPlaceAddress\": \"\",\r\n            \"WorkPlacePostalCode\": \"6000\",\r\n            \"WorkPlaceCity\": \"Kolding\",\r\n            \"WorkPlaceOtherAddress\": true,\r\n            \"WorkPlaceAbroad\": false,\r\n            \"WorkPlaceNotStatic\": false,\r\n            \"UseWorkPlaceAddressForJoblog\": false,\r\n            \"PostingCreated\": \"2021-07-02T00:00:00\",\r\n            \"LastDateApplication\": \"2021-08-27T00:00:00\",\r\n            \"FormattedLastDateApplication\": \"27. august 2021\",\r\n            \"AssignmentStartDate\": \"0001-01-01T00:00:00\",\r\n            \"IsHotjob\": false,\r\n            \"IsExternal\": false,\r\n            \"Url\": \"https://job.jobnet.dk/CV/FindWork/Details/5290988\",\r\n            \"Region\": \"Syddanmark\",\r\n            \"Municipality\": \"Kolding\",\r\n            \"Country\": \"Danmark\",\r\n            \"PostalCode\": \"6000\",\r\n            \"PostalCodeName\": null,\r\n            \"JobAnnouncementType\": \"\",\r\n            \"EmploymentType\": \"\",\r\n            \"WorkHours\": \"Deltid\",\r\n            \"OccupationArea\": \"\",\r\n            \"OccupationGroup\": \"\",\r\n            \"Occupation\": \"Lager- og logistikmedarbejder\",\r\n            \"Location\": {\r\n                \"Latitude\": 55.5022,\r\n                \"Longitude\": 9.4685\r\n            },\r\n            \"JoblogWorkTime\": {\r\n                \"WorkHour\": \"(1 - 36 timer ugentligt)\",\r\n                \"DailyWorkTime\": \"Dag, aften\"\r\n            },\r\n            \"WorkplaceID\": 126565,\r\n            \"OrganisationId\": \"71174\",\r\n            \"HiringOrgCVR\": 30899695,\r\n            \"UserLoggedIn\": false,\r\n            \"AnonymousEmployer\": false,\r\n            \"ShareUrl\": \"https://job.jobnet.dk/CV/FindWork/DetailsSocialmedia/5290988\",\r\n            \"DetailsUrl\": \"https://job.jobnet.dk/CV/FindWork/DetailsWidk/5290988\",\r\n            \"JobLogUrl\": \"https://job.jobnet.dk/CV/FindWork/Details/5290988\",\r\n            \"HasLocationValues\": true,\r\n            \"ID\": \"5290988\",\r\n            \"Latitude\": 55.5022,\r\n            \"Longitude\": 9.4685\r\n        }",
                    title: "Motivated employees for warehouse work in Kolding - full time and part time work , start-up as soon as possible",
                    presentation: " Do you want to help make a difference at our customer in Kolding, and can you start with short notice? Then we have the job for you. \n  We offer  \n \n",
                    hiringOrgName: "TeamVikaren.dk, Århus ApS, Horsens Afdeling",
                    workPlaceAddress: "",
                    workPlacePostalCode: 6000,
                    workPlaceCity: "Kolding",
                    postingCreated: new DateTime(2021, 07, 02),
                    lastDateApplication: new DateTime(2021, 08, 27),
                    url: "https://job.jobnet.dk/CV/FindWork/Details/5290988",
                    region: "Syddanmark",
                    municipality: "Kolding",
                    country: "Danmark",
                    employmentType: "",
                    workHours: "Deltid",
                    occupation: "Lager- og logistikmedarbejder",
                    workplaceId: 126565,
                    organisationId: 71174,
                    hiringOrgCVR: 30899695,
                    id: 5290988,
                    workPlaceCityWithoutZone: "Kolding",
                    jobPostingNumber: 7,
                    jobPostingId: "5290988motivatedemployeesforwarehousework",
                    language: "en"
                );
        public static JobPostingExtended Shared_JobPage01_JobPostingExtended07
            = new JobPostingExtended(
                    jobPosting: Shared_JobPage01_JobPosting07,
                    response: Shared_FakeResponse,                      // Ignored
                    hiringOrgDescription: null,
                    publicationStartDate: new DateTime(2021, 07, 02),
                    publicationEndDate: new DateTime(2021, 08, 27),
                    purpose: Shared_FakePurpose,                        // Ignored
                    numberToFill: 12,
                    contactEmail: null,
                    contactPersonName: "Majken Lorentzen",
                    employmentDate: null,
                    applicationDeadlineDate: new DateTime(2021, 08, 27),
                    bulletPoints: new List<BulletPoint>()
                    {

                        new BulletPoint(
                            text: "A social workplace",
                            type: null
                            ),
                        new BulletPoint(
                            text: "Day and evening shifts",
                            type: null
                            ),
                        new BulletPoint(
                            text: "Full time work and part time work",
                            type: null
                            ),
                        new BulletPoint(
                            text: "A healthy working environment",
                            type: null
                            ),
                        new BulletPoint(
                            text: "Good colleagues",
                            type: null
                            ),
                        new BulletPoint(
                            text: "Training in warehouse work such as picking, packing, sorting and much more",
                            type: null
                            ),
                        new BulletPoint(
                            text: "You would like to work in a warehouse",
                            type: null
                            ),
                        new BulletPoint(
                            text: "You like active work",
                            type: null
                            ),
                        new BulletPoint(
                            text: "You can work full time or part time",
                            type: null
                            ),
                        new BulletPoint(
                            text: "You can work independently",
                            type: null
                            )
                        
                    },
                    bulletPointScenario: "generic"
                );

        public static JobPosting Shared_JobPage01_JobPosting08
            = new JobPosting(
                    runId: Shared_FakeRunId,
                    pageNumber: 1,
                    response: "{\r\n            \"AutomatchType\": 0,\r\n            \"Abroad\": false,\r\n            \"Weight\": 1.0,\r\n            \"Title\": \"Vice President of Product Marketing\",\r\n            \"JobHeadline\": \"Vice President of Product Marketing\",\r\n            \"Presentation\": \"<p><strong>PARKEN, COPENHAGEN /</strong></p>\\n<p><strong>BRAND AND MARKETING – PRODUCT MARKETING /</strong></p>\\n<p><strong>FULL TIME, PERMANENT CONTRACT</strong></p>\\n\",\r\n            \"HiringOrgName\": \"Keepit A/S\",\r\n            \"WorkPlaceAddress\": \"Per Henrik Lings Allé 4 7\",\r\n            \"WorkPlacePostalCode\": \"2100\",\r\n            \"WorkPlaceCity\": \"København Ø\",\r\n            \"WorkPlaceOtherAddress\": false,\r\n            \"WorkPlaceAbroad\": false,\r\n            \"WorkPlaceNotStatic\": false,\r\n            \"UseWorkPlaceAddressForJoblog\": true,\r\n            \"PostingCreated\": \"2021-07-02T00:00:00\",\r\n            \"LastDateApplication\": \"2021-08-27T00:00:00\",\r\n            \"FormattedLastDateApplication\": \"27. august 2021\",\r\n            \"AssignmentStartDate\": \"0001-01-01T00:00:00\",\r\n            \"IsHotjob\": false,\r\n            \"IsExternal\": false,\r\n            \"Url\": \"https://job.jobnet.dk/CV/FindWork/Details/5383229\",\r\n            \"Region\": \"Hovedstaden og Bornholm\",\r\n            \"Municipality\": \"København\",\r\n            \"Country\": \"Danmark\",\r\n            \"PostalCode\": \"2100\",\r\n            \"PostalCodeName\": null,\r\n            \"JobAnnouncementType\": \"\",\r\n            \"EmploymentType\": \"\",\r\n            \"WorkHours\": \"Fuldtid\",\r\n            \"OccupationArea\": \"\",\r\n            \"OccupationGroup\": \"\",\r\n            \"Occupation\": \"Marketingchef\",\r\n            \"Location\": {\r\n                \"Latitude\": 55.7038,\r\n                \"Longitude\": 12.5721\r\n            },\r\n            \"JoblogWorkTime\": {\r\n                \"WorkHour\": null,\r\n                \"DailyWorkTime\": null\r\n            },\r\n            \"WorkplaceID\": 133543,\r\n            \"OrganisationId\": \"117090\",\r\n            \"HiringOrgCVR\": 30806883,\r\n            \"UserLoggedIn\": false,\r\n            \"AnonymousEmployer\": false,\r\n            \"ShareUrl\": \"https://job.jobnet.dk/CV/FindWork/DetailsSocialmedia/5383229\",\r\n            \"DetailsUrl\": \"https://job.jobnet.dk/CV/FindWork/DetailsWidk/5383229\",\r\n            \"JobLogUrl\": \"https://job.jobnet.dk/CV/FindWork/Details/5383229\",\r\n            \"HasLocationValues\": true,\r\n            \"ID\": \"5383229\",\r\n            \"Latitude\": 55.7038,\r\n            \"Longitude\": 12.5721\r\n        }",
                    title: "Vice President of Product Marketing",
                    presentation: "<p><strong>PARKEN, COPENHAGEN /</strong></p>\n<p><strong>BRAND AND MARKETING – PRODUCT MARKETING /</strong></p>\n<p><strong>FULL TIME, PERMANENT CONTRACT</strong></p>\n",
                    hiringOrgName: "Keepit A/S",
                    workPlaceAddress: "Per Henrik Lings Allé 4 7",
                    workPlacePostalCode: 2100,
                    workPlaceCity: "København Ø",
                    postingCreated: new DateTime(2021, 07, 02),
                    lastDateApplication: new DateTime(2021, 08, 27),
                    url: "https://job.jobnet.dk/CV/FindWork/Details/5383229",
                    region: "Hovedstaden og Bornholm",
                    municipality: "København",
                    country: "Danmark",
                    employmentType: "",
                    workHours: "Fuldtid",
                    occupation: "Marketingchef",
                    workplaceId: 133543,
                    organisationId: 117090,
                    hiringOrgCVR: 30806883,
                    id: 5383229,
                    workPlaceCityWithoutZone: "København",
                    jobPostingNumber: 8,
                    jobPostingId: "5383229vicepresidentofproductmarketing",
                    language: "en"
                );
        public static JobPostingExtended Shared_JobPage01_JobPostingExtended08
                = new JobPostingExtended(
                        jobPosting: Shared_JobPage01_JobPosting08,
                        response: Shared_FakeResponse,                      // Ignored
                        hiringOrgDescription: null,
                        publicationStartDate: new DateTime(2021, 07, 02),
                        publicationEndDate: new DateTime(2021, 08, 27),
                        purpose: Shared_FakePurpose,                        // Ignored
                        numberToFill: 1,
                        contactEmail: "edc@keepit.com",
                        contactPersonName: "Emil Daniel Christensen",
                        employmentDate: null,
                        applicationDeadlineDate: new DateTime(2021, 08, 27),
                        bulletPoints: new List<BulletPoint>()
                        {

                              new BulletPoint(
                                    text: "As a Vice President, we expect a truly transparent and inclusive leadership style, empowering your team to perform at their maximum abilities.",
                                    type: null
                                    ),
                              new BulletPoint(
                                    text: "Facilitate outstanding collaborations between the product marketing team and the full brand & marketing team as well as internal core stakeholders such as product management and sales",
                                    type: null
                                    ),
                              new BulletPoint(
                                    text: "Help us articulate and implement a global product marketing strategy ·Serve as an evangelist for our products through thought leadership",
                                    type: null
                                    ),
                              new BulletPoint(
                                    text: "Keep the company up-to-date with market trends and competition",
                                    type: null
                                    ),
                              new BulletPoint(
                                    text: "Product Marketing Strategy: We are looking for a profile that can help us define the right strategies that will fuel our continued growth. Having experience with making product marketing strategies for SaaS products is a requirement.",
                                    type: null
                                    ),
                              new BulletPoint(
                                    text: "Product Marketing: The right candidate has a solid product marketing skill-set with an entrepreneurial spirit. You know how to deliver sales enablement content and can execute marketing initiatives, including aligning and getting buy-in from stakeholders across the organization (including marketing, product, and sales).",
                                    type: null
                                    ),
                              new BulletPoint(
                                    text: "Leadership Style: We believe that the right candidate has the ability to inspire the team with an including and transparent leadership style.",
                                    type: null
                                    ),
                              new BulletPoint(
                                    text: "Language: We use English as our preferred language, and being fluent in English, both written and spoken, is essential for this role.",
                                    type: null
                                    ),
                              new BulletPoint(
                                    text: "Entrepreneurial spirit: We are passionate about winning in the market. However, we are also passionate about our workplace, and we know that a good work environment and great collaboration across our organization are crucial to achieving our ambitious goals. Therefore, we are searching for team leaders who, like us, are being motivated by building a fair and fun work environment at Keepit.",
                                    type: null
                                    )
                            
                        },
                        bulletPointScenario: "generic"
                    );

        public static JobPosting Shared_JobPage01_JobPosting09
            = new JobPosting(
                    runId: Shared_FakeRunId,
                    pageNumber: 1,
                    response: "{\r\n            \"AutomatchType\": 0,\r\n            \"Abroad\": false,\r\n            \"Weight\": 1.0,\r\n            \"Title\": \"Friske og oplagte medarbejdere til sortering af pakker på stort lager i Horsens/Motivated employees for sorting packages in a large warehouse in Horsens\",\r\n            \"JobHeadline\": \"Friske og oplagte medarbejdere til sortering af pakker på stort lager i Horsens/Motivated employees for sorting packages in a large warehouse in Horsens\",\r\n            \"Presentation\": \"<p><strong>English version below the Danish</strong></p>\\n\",\r\n            \"HiringOrgName\": \"TeamVikaren.dk, Århus ApS, Horsens Afdeling\",\r\n            \"WorkPlaceAddress\": \"Strandpromenaden 6\",\r\n            \"WorkPlacePostalCode\": \"8700\",\r\n            \"WorkPlaceCity\": \"Horsens\",\r\n            \"WorkPlaceOtherAddress\": false,\r\n            \"WorkPlaceAbroad\": false,\r\n            \"WorkPlaceNotStatic\": false,\r\n            \"UseWorkPlaceAddressForJoblog\": true,\r\n            \"PostingCreated\": \"2021-07-02T00:00:00\",\r\n            \"LastDateApplication\": \"2021-07-15T00:00:00\",\r\n            \"FormattedLastDateApplication\": \"15. juli 2021\",\r\n            \"AssignmentStartDate\": \"0001-01-01T00:00:00\",\r\n            \"IsHotjob\": false,\r\n            \"IsExternal\": false,\r\n            \"Url\": \"https://job.jobnet.dk/CV/FindWork/Details/5331002\",\r\n            \"Region\": \"Midtjylland\",\r\n            \"Municipality\": \"Horsens\",\r\n            \"Country\": \"Danmark\",\r\n            \"PostalCode\": \"8700\",\r\n            \"PostalCodeName\": null,\r\n            \"JobAnnouncementType\": \"\",\r\n            \"EmploymentType\": \"\",\r\n            \"WorkHours\": \"Deltid\",\r\n            \"OccupationArea\": \"\",\r\n            \"OccupationGroup\": \"\",\r\n            \"Occupation\": \"Lager- og logistikmedarbejder\",\r\n            \"Location\": {\r\n                \"Latitude\": 55.861,\r\n                \"Longitude\": 9.8732\r\n            },\r\n            \"JoblogWorkTime\": {\r\n                \"WorkHour\": \"(8 - 20 timer ugentligt)\",\r\n                \"DailyWorkTime\": \"Aften\"\r\n            },\r\n            \"WorkplaceID\": 126565,\r\n            \"OrganisationId\": \"71174\",\r\n            \"HiringOrgCVR\": 30899695,\r\n            \"UserLoggedIn\": false,\r\n            \"AnonymousEmployer\": false,\r\n            \"ShareUrl\": \"https://job.jobnet.dk/CV/FindWork/DetailsSocialmedia/5331002\",\r\n            \"DetailsUrl\": \"https://job.jobnet.dk/CV/FindWork/DetailsWidk/5331002\",\r\n            \"JobLogUrl\": \"https://job.jobnet.dk/CV/FindWork/Details/5331002\",\r\n            \"HasLocationValues\": true,\r\n            \"ID\": \"5331002\",\r\n            \"Latitude\": 55.861,\r\n            \"Longitude\": 9.8732\r\n        }",
                    title: "Friske og oplagte medarbejdere til sortering af pakker på stort lager i Horsens/Motivated employees for sorting packages in a large warehouse in Horsens",
                    presentation: "<p><strong>English version below the Danish</strong></p>\n",
                    hiringOrgName: "TeamVikaren.dk, Århus ApS, Horsens Afdeling",
                    workPlaceAddress: "Strandpromenaden 6",
                    workPlacePostalCode: 8700,
                    workPlaceCity: "Horsens",
                    postingCreated: new DateTime(2021, 07, 02),
                    lastDateApplication: new DateTime(2021, 07, 15),
                    url: "https://job.jobnet.dk/CV/FindWork/Details/5331002",
                    region: "Midtjylland",
                    municipality: "Horsens",
                    country: "Danmark",
                    employmentType: "",
                    workHours: "Deltid",
                    occupation: "Lager- og logistikmedarbejder",
                    workplaceId: 126565,
                    organisationId: 71174,
                    hiringOrgCVR: 30899695,
                    id: 5331002,
                    workPlaceCityWithoutZone: "Horsens",
                    jobPostingNumber: 9,
                    jobPostingId: "5331002friskeogoplagtemedarbejderetil",
                    language: "dk/en"
                );
        public static JobPostingExtended Shared_JobPage01_JobPostingExtended09
            = new JobPostingExtended(
                    jobPosting: Shared_JobPage01_JobPosting09,
                    response: Shared_FakeResponse,                      // Ignored
                    hiringOrgDescription: null,
                    publicationStartDate: new DateTime(2021, 07, 02),
                    publicationEndDate: new DateTime(2021, 07, 15),
                    purpose: Shared_FakePurpose,                        // Ignored
                    numberToFill: 5,
                    contactEmail: null,
                    contactPersonName: "Majken Lorentzen",
                    employmentDate: null,
                    applicationDeadlineDate: new DateTime(2021, 07, 15),
                    bulletPoints: new List<BulletPoint>()
                    {

                        new BulletPoint(
                            text: "Ordnede forhold",
                            type: null
                            ),
                        new BulletPoint(
                            text: "En social arbejdsplads med gode kollegaer",
                            type: null
                            ),
                        new BulletPoint(
                            text: "Fleksibilitet vedr. vagter",
                            type: null
                            ),
                        new BulletPoint(
                            text: "Mulighed for vagter både på hverdage og i weekender",
                            type: null
                            ),
                        new BulletPoint(
                            text: "Du har lyst til at arbejde inden for lager og logistik",
                            type: null
                            ),
                        new BulletPoint(
                            text: "Du er fleksibel",
                            type: null
                            ),
                        new BulletPoint(
                            text: "Du kan arbejde minimum 2 dage om ugen",
                            type: null
                            ),
                        new BulletPoint(
                            text: "Du kan arbejde om eftermiddagen og aftenen",
                            type: null
                            ),
                        new BulletPoint(
                            text: "Du har en god fysik",
                            type: null
                            ),
                        new BulletPoint(
                            text: "Du kan lide at arbejde i teams",
                            type: null
                            ),
                        new BulletPoint(
                            text: "Orderly conditions",
                            type: null
                            ),
                        new BulletPoint(
                            text: "A social workplace with good colleagues",
                            type: null
                            ),
                        new BulletPoint(
                            text: "Flexibility regarding shifts",
                            type: null
                            ),
                        new BulletPoint(
                            text: "Possibility of shifts both on weekdays and on weekends",
                            type: null
                            ),
                        new BulletPoint(
                            text: "You want to work in warehousing and logistics",
                            type: null
                            ),
                        new BulletPoint(
                            text: "You are flexible",
                            type: null
                            ),
                        new BulletPoint(
                            text: "You can work a minimum of 2 days a week",
                            type: null
                            ),
                        new BulletPoint(
                            text: "You can work in the afternoon and evening time",
                            type: null
                            ),
                        new BulletPoint(
                            text: "You have a good physique",
                            type: null
                            ),
                        new BulletPoint(
                            text: "You like working in teams",
                            type: null
                            )
                        
                    },
                    bulletPointScenario: "generic"
                );

        public static JobPosting Shared_JobPage01_JobPosting10
            = new JobPosting(
                    runId: Shared_FakeRunId,
                    pageNumber: 1,
                    response: "{\r\n            \"AutomatchType\": 0,\r\n            \"Abroad\": false,\r\n            \"Weight\": 1.0,\r\n            \"Title\": \"Tenure track assistant professor in applied statistics\",\r\n            \"JobHeadline\": \"Tenure track assistant professor in applied statistics\",\r\n            \"Presentation\": \"Department of Agroecology, Aarhus University, invites applications for a tenure track position in applied statistics.<br><br>The main activity will be research and support in statistical methods and\",\r\n            \"HiringOrgName\": \"Aarhus Universitet\",\r\n            \"WorkPlaceAddress\": \"Blichers Alle 20\",\r\n            \"WorkPlacePostalCode\": \"8830\",\r\n            \"WorkPlaceCity\": \"Tjele\",\r\n            \"WorkPlaceOtherAddress\": false,\r\n            \"WorkPlaceAbroad\": false,\r\n            \"WorkPlaceNotStatic\": false,\r\n            \"UseWorkPlaceAddressForJoblog\": true,\r\n            \"PostingCreated\": \"2021-07-02T00:00:00\",\r\n            \"LastDateApplication\": \"2021-08-13T00:00:00\",\r\n            \"FormattedLastDateApplication\": \"13. august 2021\",\r\n            \"AssignmentStartDate\": \"0001-01-01T00:00:00\",\r\n            \"IsHotjob\": false,\r\n            \"IsExternal\": false,\r\n            \"Url\": \"https://job.jobnet.dk/CV/FindWork/Details/5383212\",\r\n            \"Region\": \"Midtjylland\",\r\n            \"Municipality\": \"Viborg\",\r\n            \"Country\": \"Danmark\",\r\n            \"PostalCode\": \"8830\",\r\n            \"PostalCodeName\": null,\r\n            \"JobAnnouncementType\": \"\",\r\n            \"EmploymentType\": \"\",\r\n            \"WorkHours\": \"Fuldtid\",\r\n            \"OccupationArea\": \"\",\r\n            \"OccupationGroup\": \"\",\r\n            \"Occupation\": \"Adjunkt, naturvidenskab og teknik\",\r\n            \"Location\": {\r\n                \"Latitude\": 56.4883,\r\n                \"Longitude\": 9.5833\r\n            },\r\n            \"JoblogWorkTime\": {\r\n                \"WorkHour\": null,\r\n                \"DailyWorkTime\": null\r\n            },\r\n            \"WorkplaceID\": 100437,\r\n            \"OrganisationId\": \"90880\",\r\n            \"HiringOrgCVR\": 31119103,\r\n            \"UserLoggedIn\": false,\r\n            \"AnonymousEmployer\": false,\r\n            \"ShareUrl\": \"https://job.jobnet.dk/CV/FindWork/DetailsSocialmedia/5383212\",\r\n            \"DetailsUrl\": \"https://job.jobnet.dk/CV/FindWork/DetailsWidk/5383212\",\r\n            \"JobLogUrl\": \"https://job.jobnet.dk/CV/FindWork/Details/5383212\",\r\n            \"HasLocationValues\": true,\r\n            \"ID\": \"5383212\",\r\n            \"Latitude\": 56.4883,\r\n            \"Longitude\": 9.5833\r\n        }",
                    title: "Tenure track assistant professor in applied statistics",
                    presentation: "Department of Agroecology, Aarhus University, invites applications for a tenure track position in applied statistics.<br><br>The main activity will be research and support in statistical methods and",
                    hiringOrgName: "Aarhus Universitet",
                    workPlaceAddress: "Blichers Alle 20",
                    workPlacePostalCode: 8830,
                    workPlaceCity: "Tjele",
                    postingCreated: new DateTime(2021, 07, 02),
                    lastDateApplication: new DateTime(2021, 08, 13),
                    url: "https://job.jobnet.dk/CV/FindWork/Details/5383212",
                    region: "Midtjylland",
                    municipality: "Viborg",
                    country: "Danmark",
                    employmentType: "",
                    workHours: "Fuldtid",
                    occupation: "Adjunkt, naturvidenskab og teknik",
                    workplaceId: 100437,
                    organisationId: 90880,
                    hiringOrgCVR: 31119103,
                    id: 5383212,
                    workPlaceCityWithoutZone: "Tjele",
                    jobPostingNumber: 10,
                    jobPostingId: "5383212tenuretrackassistantprofessorin",
                    language: "en"
                );
        public static JobPostingExtended Shared_JobPage01_JobPostingExtended10
            = new JobPostingExtended(
                    jobPosting: Shared_JobPage01_JobPosting10,
                    response: Shared_FakeResponse,                      // Ignored
                    hiringOrgDescription: null,
                    publicationStartDate: null,
                    publicationEndDate: null,
                    purpose: Shared_FakePurpose,                        // Ignored
                    numberToFill: null,
                    contactEmail: null,
                    contactPersonName: null,
                    employmentDate: null,
                    applicationDeadlineDate: null,
                    bulletPoints: new List<BulletPoint>()
                    {

                          new BulletPoint(
                                text: "PhD degree and post doc research experience within applied statistics or similar aspects",
                                type: null
                                ),
                          new BulletPoint(
                                text: "Proven publication record in international peer-reviewed ISI journals",
                                type: null
                                ),
                          new BulletPoint(
                                text: "Strong expertise in classical statistical methods (analysis of variance, regression analysis, mixed model analysis, generalized linear models, categorical data analysis, non-parametric analysis, multivariate data analysis) and in areas such as spatial statistics, image analysis, time series analysis and machine learning. We are aware that candidates may not have strong expertise in all areas, but we expect the applicant to have at least some knowledge in the areas mentioned.",
                                type: null
                                ),
                          new BulletPoint(
                                text: "The ability to manage, participate, collaborate and communicate in interdisciplinary research, and to participate in joint projects with other scientists.",
                                type: null
                                ),
                          new BulletPoint(
                                text: "Skills in clearly communicating statistical methods and results to persons with non-statistical background.",
                                type: null
                                ),
                          new BulletPoint(
                                text: "attract outstanding talented individuals that are competitive at an international level",
                                type: null
                                ),
                          new BulletPoint(
                                text: "to promote the early development of independent research success early in the career of scientists",
                                type: null
                                ),
                          new BulletPoint(
                                text: "to create transparency in the academic career path",
                                type: null
                                ),
                          new BulletPoint(
                                text: "access to research infrastructure",
                                type: null
                                ),
                          new BulletPoint(
                                text: "capability development, including postgraduate teacher training",
                                type: null
                                ),
                          new BulletPoint(
                                text: "a mentoring programme",
                                type: null
                                ),
                          new BulletPoint(
                                text: "support to develop scientific networks and to secure interdisciplinary research at the highest level",
                                type: null
                                )
                        
                    },
                    bulletPointScenario: "generic"
                );

        public static JobPosting Shared_JobPage01_JobPosting11
            = new JobPosting(
                    runId: Shared_FakeRunId,
                    pageNumber: 1,
                    response: "{\r\n            \"AutomatchType\": 0,\r\n            \"Abroad\": false,\r\n            \"Weight\": 1.0,\r\n            \"Title\": \"Committed employees for assembling displays in a large warehouse in Hedensted.\",\r\n            \"JobHeadline\": \"Committed employees for assembling displays in a large warehouse in Hedensted.\",\r\n            \"Presentation\": \" Our costumer is busy and they need employees to help in their warehouse. \\n  We offer  \\n \\n Work in a large international company \\n Possibility of day shifts\",\r\n            \"HiringOrgName\": \"TeamVikaren.dk, Århus ApS, Horsens Afdeling\",\r\n            \"WorkPlaceAddress\": \"\",\r\n            \"WorkPlacePostalCode\": \"8722\",\r\n            \"WorkPlaceCity\": \"Hedensted\",\r\n            \"WorkPlaceOtherAddress\": true,\r\n            \"WorkPlaceAbroad\": false,\r\n            \"WorkPlaceNotStatic\": false,\r\n            \"UseWorkPlaceAddressForJoblog\": false,\r\n            \"PostingCreated\": \"2021-07-02T00:00:00\",\r\n            \"LastDateApplication\": \"2021-07-29T00:00:00\",\r\n            \"FormattedLastDateApplication\": \"29. juli 2021\",\r\n            \"AssignmentStartDate\": \"0001-01-01T00:00:00\",\r\n            \"IsHotjob\": false,\r\n            \"IsExternal\": false,\r\n            \"Url\": \"https://job.jobnet.dk/CV/FindWork/Details/5361275\",\r\n            \"Region\": \"Midtjylland\",\r\n            \"Municipality\": \"Hedensted\",\r\n            \"Country\": \"Danmark\",\r\n            \"PostalCode\": \"8722\",\r\n            \"PostalCodeName\": null,\r\n            \"JobAnnouncementType\": \"\",\r\n            \"EmploymentType\": \"\",\r\n            \"WorkHours\": \"Fuldtid\",\r\n            \"OccupationArea\": \"\",\r\n            \"OccupationGroup\": \"\",\r\n            \"Occupation\": \"Lager- og logistikmedarbejder\",\r\n            \"Location\": {\r\n                \"Latitude\": 55.7651,\r\n                \"Longitude\": 9.7113\r\n            },\r\n            \"JoblogWorkTime\": {\r\n                \"WorkHour\": null,\r\n                \"DailyWorkTime\": \"Dag\"\r\n            },\r\n            \"WorkplaceID\": 126565,\r\n            \"OrganisationId\": \"71174\",\r\n            \"HiringOrgCVR\": 30899695,\r\n            \"UserLoggedIn\": false,\r\n            \"AnonymousEmployer\": false,\r\n            \"ShareUrl\": \"https://job.jobnet.dk/CV/FindWork/DetailsSocialmedia/5361275\",\r\n            \"DetailsUrl\": \"https://job.jobnet.dk/CV/FindWork/DetailsWidk/5361275\",\r\n            \"JobLogUrl\": \"https://job.jobnet.dk/CV/FindWork/Details/5361275\",\r\n            \"HasLocationValues\": true,\r\n            \"ID\": \"5361275\",\r\n            \"Latitude\": 55.7651,\r\n            \"Longitude\": 9.7113\r\n        }",
                    title: "Committed employees for assembling displays in a large warehouse in Hedensted.",
                    presentation: " Our costumer is busy and they need employees to help in their warehouse. \n  We offer  \n \n Work in a large international company \n Possibility of day shifts",
                    hiringOrgName: "TeamVikaren.dk, Århus ApS, Horsens Afdeling",
                    workPlaceAddress: "",
                    workPlacePostalCode: 8722,
                    workPlaceCity: "Hedensted",
                    postingCreated: new DateTime(2021, 07, 02),
                    lastDateApplication: new DateTime(2021, 07, 29),
                    url: "https://job.jobnet.dk/CV/FindWork/Details/5361275",
                    region: "Midtjylland",
                    municipality: "Hedensted",
                    country: "Danmark",
                    employmentType: "",
                    workHours: "Fuldtid",
                    occupation: "Lager- og logistikmedarbejder",
                    workplaceId: 126565,
                    organisationId: 71174,
                    hiringOrgCVR: 30899695,
                    id: 5361275,
                    workPlaceCityWithoutZone: "Hedensted",
                    jobPostingNumber: 11,
                    jobPostingId: "5361275committedemployeesforassemblingdisplays",
                    language: "dk/en" // To-do: this prediction must be improved (ClassificationManager).
                );
        public static JobPostingExtended Shared_JobPage01_JobPostingExtended11
            = new JobPostingExtended(
                    jobPosting: Shared_JobPage01_JobPosting11,
                    response: Shared_FakeResponse,                      // Ignored
                    hiringOrgDescription: null,
                    publicationStartDate: new DateTime(2021, 07, 02),
                    publicationEndDate: new DateTime(2021, 07, 29),
                    purpose: Shared_FakePurpose,                        // Ignored
                    numberToFill: 1,
                    contactEmail: null,
                    contactPersonName: "Majken Lorentzen",
                    employmentDate: null,
                    applicationDeadlineDate: new DateTime(2021, 07, 29),
                    bulletPoints: new List<BulletPoint>()
                    {

                        new BulletPoint(
                            text: "Work in a large international company",
                            type: null
                            ),
                        new BulletPoint(
                            text: "Possibility of day shifts",
                            type: null
                            ),
                        new BulletPoint(
                            text: "A social workplace with good colleagues",
                            type: null
                            ),
                        new BulletPoint(
                            text: "Thorough training",
                            type: null
                            ),
                        new BulletPoint(
                            text: "You are flexible during busy periods",
                            type: null
                            ),
                        new BulletPoint(
                            text: "You have an eye for detail",
                            type: null
                            ),
                        new BulletPoint(
                            text: "You can work full time",
                            type: null
                            ),
                        new BulletPoint(
                            text: "You can work independently",
                            type: null
                            ),
                        new BulletPoint(
                            text: "You are thorough and take pride in your work",
                            type: null
                            )
                        
                    },
                    bulletPointScenario: "generic"
                );

        public static JobPosting Shared_JobPage01_JobPosting12
            = new JobPosting(
                    runId: Shared_FakeRunId,
                    pageNumber: 1,
                    response: "{\r\n            \"AutomatchType\": 0,\r\n            \"Abroad\": false,\r\n            \"Weight\": 1.0,\r\n            \"Title\": \"We are looking for forklift drivers for temporary positions during the summer in Skanderborg, Horsens and Fredericia\",\r\n            \"JobHeadline\": \"We are looking for forklift drivers for temporary positions during the summer in Skanderborg, Horsens and Fredericia\",\r\n            \"Presentation\": \"<p>We are looking for forklift drivers for temporary positions during the summer in Skanderborg, Horsens and Fredericia</p>\\n\",\r\n            \"HiringOrgName\": \"TeamVikaren.dk, Århus ApS, Horsens Afdeling\",\r\n            \"WorkPlaceAddress\": \"\",\r\n            \"WorkPlacePostalCode\": \"8700\",\r\n            \"WorkPlaceCity\": \"Horsens\",\r\n            \"WorkPlaceOtherAddress\": false,\r\n            \"WorkPlaceAbroad\": false,\r\n            \"WorkPlaceNotStatic\": false,\r\n            \"UseWorkPlaceAddressForJoblog\": true,\r\n            \"PostingCreated\": \"2021-07-02T00:00:00\",\r\n            \"LastDateApplication\": \"2021-07-28T00:00:00\",\r\n            \"FormattedLastDateApplication\": \"28. juli 2021\",\r\n            \"AssignmentStartDate\": \"0001-01-01T00:00:00\",\r\n            \"IsHotjob\": false,\r\n            \"IsExternal\": false,\r\n            \"Url\": \"https://job.jobnet.dk/CV/FindWork/Details/5359775\",\r\n            \"Region\": \"Midtjylland\",\r\n            \"Municipality\": \"Horsens\",\r\n            \"Country\": \"Danmark\",\r\n            \"PostalCode\": \"8700\",\r\n            \"PostalCodeName\": null,\r\n            \"JobAnnouncementType\": \"\",\r\n            \"EmploymentType\": \"\",\r\n            \"WorkHours\": \"Fuldtid\",\r\n            \"OccupationArea\": \"\",\r\n            \"OccupationGroup\": \"\",\r\n            \"Occupation\": \"Truckfører\",\r\n            \"Location\": {\r\n                \"Latitude\": 55.866,\r\n                \"Longitude\": 9.893\r\n            },\r\n            \"JoblogWorkTime\": {\r\n                \"WorkHour\": null,\r\n                \"DailyWorkTime\": \"Dag, aften, nat\"\r\n            },\r\n            \"WorkplaceID\": 126565,\r\n            \"OrganisationId\": \"71174\",\r\n            \"HiringOrgCVR\": 30899695,\r\n            \"UserLoggedIn\": false,\r\n            \"AnonymousEmployer\": false,\r\n            \"ShareUrl\": \"https://job.jobnet.dk/CV/FindWork/DetailsSocialmedia/5359775\",\r\n            \"DetailsUrl\": \"https://job.jobnet.dk/CV/FindWork/DetailsWidk/5359775\",\r\n            \"JobLogUrl\": \"https://job.jobnet.dk/CV/FindWork/Details/5359775\",\r\n            \"HasLocationValues\": true,\r\n            \"ID\": \"5359775\",\r\n            \"Latitude\": 55.866,\r\n            \"Longitude\": 9.893\r\n        }",
                    title: "We are looking for forklift drivers for temporary positions during the summer in Skanderborg, Horsens and Fredericia",
                    presentation: "<p>We are looking for forklift drivers for temporary positions during the summer in Skanderborg, Horsens and Fredericia</p>\n",
                    hiringOrgName: "TeamVikaren.dk, Århus ApS, Horsens Afdeling",
                    workPlaceAddress: "",
                    workPlacePostalCode: 8700,
                    workPlaceCity: "Horsens",
                    postingCreated: new DateTime(2021, 07, 02),
                    lastDateApplication: new DateTime(2021, 07, 28),
                    url: "https://job.jobnet.dk/CV/FindWork/Details/5359775",
                    region: "Midtjylland",
                    municipality: "Horsens",
                    country: "Danmark",
                    employmentType: "",
                    workHours: "Fuldtid",
                    occupation: "Truckfører",
                    workplaceId: 126565,
                    organisationId: 71174,
                    hiringOrgCVR: 30899695,
                    id: 5359775,
                    workPlaceCityWithoutZone: "Horsens",
                    jobPostingNumber: 12,
                    jobPostingId: "5359775wearelookingforforklift",
                    language: "dk/en" // To-do: this prediction must be improved (ClassificationManager).
                );
        public static JobPostingExtended Shared_JobPage01_JobPostingExtended12
            = new JobPostingExtended(
                    jobPosting: Shared_JobPage01_JobPosting12,
                    response: Shared_FakeResponse,                      // Ignored
                    hiringOrgDescription: null,
                    publicationStartDate: new DateTime(2021, 07, 02),
                    publicationEndDate: new DateTime(2021, 07, 28),
                    purpose: Shared_FakePurpose,                        // Ignored
                    numberToFill: 6,
                    contactEmail: null,
                    contactPersonName: "Majken Lorentzen",
                    employmentDate: null,
                    applicationDeadlineDate: new DateTime(2021, 07, 28),
                    bulletPoints: new List<BulletPoint>()
                    {

                        new BulletPoint(
                            text: "Good work conditions",
                            type: null
                            ),
                        new BulletPoint(
                            text: "A social workplace with good colleagues",
                            type: null
                            ),
                        new BulletPoint(
                            text: "Flexibility regarding shifts",
                            type: null
                            ),
                        new BulletPoint(
                            text: "Possibility for day shifts, evening shifts and night shifts.",
                            type: null
                            ),
                        new BulletPoint(
                            text: "You want to work in warehousing and logistics",
                            type: null
                            ),
                        new BulletPoint(
                            text: "You are flexible",
                            type: null
                            ),
                        new BulletPoint(
                            text: "You can work a minimum of 3 weeks in the period week 24 - 34",
                            type: null
                            ),
                        new BulletPoint(
                            text: "You can work either day, evening or night shift",
                            type: null
                            ),
                        new BulletPoint(
                            text: "You have experience with forklift driving",
                            type: null
                            ),
                        new BulletPoint(
                            text: "You like working in teams",
                            type: null
                            ),
                        new BulletPoint(
                            text: "in Horsens from 06.00–14.00 or 07.00-15.00",
                            type: null
                            ),
                        new BulletPoint(
                            text: "in Skanderborg from 08.00-16.00",
                            type: null
                            ),
                        new BulletPoint(
                            text: "in Fredericia from 06.00-14.00",
                            type: null
                            ),
                        new BulletPoint(
                            text: "in Horsens from00-22.00 / 15.00-23.00",
                            type: null
                            ),
                        new BulletPoint(
                            text: "in Skanderborg from 15.00-23.00",
                            type: null
                            ),
                        new BulletPoint(
                            text: "in Horsens from 22.00-06.00",
                            type: null
                            ),
                        new BulletPoint(
                            text: "in Skanderborg from 22.00-06.00",
                            type: null
                            ),
                        new BulletPoint(
                            text: "in Fredericia from 23.00-06.30",
                            type: null
                            ),
                        new BulletPoint(
                            text: "Uporządkowane warunki",
                            type: null
                            ),
                        new BulletPoint(
                            text: "Socjalne miejsce pracy z dobrymi kolegami",
                            type: null
                            ),
                        new BulletPoint(
                            text: "Elastyczność w zakresie zmian pracy",
                            type: null
                            ),
                        new BulletPoint(
                            text: "Możliwość pracy na zmianach dziennych, wieczornych i nocnych.",
                            type: null
                            ),
                        new BulletPoint(
                            text: "Masz ochotę pracować w magazynach i logistyce",
                            type: null
                            ),
                        new BulletPoint(
                            text: "Jesteś elastyczny",
                            type: null
                            ),
                        new BulletPoint(
                            text: "Możesz pracować minimum 3 tygodnie w okresie od 24 do 34 tygodnia",
                            type: null
                            ),
                        new BulletPoint(
                            text: "Możesz pracować na dziennej, wieczornej lub nocnej zmianie",
                            type: null
                            ),
                        new BulletPoint(
                            text: "Masz doświadczenie w prowadzeniu wózka widłowego",
                            type: null
                            ),
                        new BulletPoint(
                            text: "Lubisz prace w grupach",
                            type: null
                            ),
                        new BulletPoint(
                            text: "Potrafisz mówić ,czytać i rozumieć duński lub angielski",
                            type: null
                            ),
                        new BulletPoint(
                            text: "w Horsens w 06.00-14.00 / 07.00-15.00",
                            type: null
                            ),
                        new BulletPoint(
                            text: "w Skanderborgu w 08.00-16.00",
                            type: null
                            ),
                        new BulletPoint(
                            text: "w Fredericii w 06.00-14.00",
                            type: null
                            ),
                        new BulletPoint(
                            text: "w Horsens w 14.00-22.00 / 15.00-23.00",
                            type: null
                            ),
                        new BulletPoint(
                            text: "w Skanderborgu w 15.00-23.00",
                            type: null
                            ),
                        new BulletPoint(
                            text: "w Horsens w 22.00-06.00",
                            type: null
                            ),
                        new BulletPoint(
                            text: "w Skanderborgu w 22.00-06.00",
                            type: null
                            ),
                        new BulletPoint(
                            text: "w Fredericii w 23.00-06.30",
                            type: null
                            )

                    },
                    bulletPointScenario: "generic"
                );

        public static JobPosting Shared_JobPage01_JobPosting13
            = new JobPosting(
                    runId: Shared_FakeRunId,
                    pageNumber: 1,
                    response: "{\r\n            \"AutomatchType\": 0,\r\n            \"Abroad\": false,\r\n            \"Weight\": 1.0,\r\n            \"Title\": \"Laboratory technician for plant analysis and microbiology, Department of Food Science, Aarhus University\",\r\n            \"JobHeadline\": \"Laboratory technician for plant analysis and microbiology, Department of Food Science, Aarhus University\",\r\n            \"Presentation\": \"At the Department of Food Science, the Science Team for Food Technology (FT), a full-time position as a laboratory technician is available for appointment as from 15 September 2021 or soon thereafter.\",\r\n            \"HiringOrgName\": \"Aarhus Universitet\",\r\n            \"WorkPlaceAddress\": \"Ag\",\r\n            \"WorkPlacePostalCode\": \"8200\",\r\n            \"WorkPlaceCity\": \"Aarhus N\",\r\n            \"WorkPlaceOtherAddress\": false,\r\n            \"WorkPlaceAbroad\": false,\r\n            \"WorkPlaceNotStatic\": false,\r\n            \"UseWorkPlaceAddressForJoblog\": true,\r\n            \"PostingCreated\": \"2021-07-02T00:00:00\",\r\n            \"LastDateApplication\": \"2021-08-02T00:00:00\",\r\n            \"FormattedLastDateApplication\": \"2. august 2021\",\r\n            \"AssignmentStartDate\": \"0001-01-01T00:00:00\",\r\n            \"IsHotjob\": false,\r\n            \"IsExternal\": false,\r\n            \"Url\": \"https://job.jobnet.dk/CV/FindWork/Details/5383201\",\r\n            \"Region\": \"Midtjylland\",\r\n            \"Municipality\": \"Aarhus\",\r\n            \"Country\": \"Danmark\",\r\n            \"PostalCode\": \"8200\",\r\n            \"PostalCodeName\": null,\r\n            \"JobAnnouncementType\": \"\",\r\n            \"EmploymentType\": \"\",\r\n            \"WorkHours\": \"Fuldtid\",\r\n            \"OccupationArea\": \"\",\r\n            \"OccupationGroup\": \"\",\r\n            \"Occupation\": \"Laboratorietekniker\",\r\n            \"Location\": {\r\n                \"Latitude\": 56.2017,\r\n                \"Longitude\": 10.1592\r\n            },\r\n            \"JoblogWorkTime\": {\r\n                \"WorkHour\": null,\r\n                \"DailyWorkTime\": null\r\n            },\r\n            \"WorkplaceID\": 0,\r\n            \"OrganisationId\": \"90880\",\r\n            \"HiringOrgCVR\": 31119103,\r\n            \"UserLoggedIn\": false,\r\n            \"AnonymousEmployer\": false,\r\n            \"ShareUrl\": \"https://job.jobnet.dk/CV/FindWork/DetailsSocialmedia/5383201\",\r\n            \"DetailsUrl\": \"https://job.jobnet.dk/CV/FindWork/DetailsWidk/5383201\",\r\n            \"JobLogUrl\": \"https://job.jobnet.dk/CV/FindWork/Details/5383201\",\r\n            \"HasLocationValues\": true,\r\n            \"ID\": \"5383201\",\r\n            \"Latitude\": 56.2017,\r\n            \"Longitude\": 10.1592\r\n        }",
                    title: "Laboratory technician for plant analysis and microbiology, Department of Food Science, Aarhus University",
                    presentation: "At the Department of Food Science, the Science Team for Food Technology (FT), a full-time position as a laboratory technician is available for appointment as from 15 September 2021 or soon thereafter.",
                    hiringOrgName: "Aarhus Universitet",
                    workPlaceAddress: "Ag",
                    workPlacePostalCode: 8200,
                    workPlaceCity: "Aarhus N",
                    postingCreated: new DateTime(2021, 07, 02),
                    lastDateApplication: new DateTime(2021, 08, 02),
                    url: "https://job.jobnet.dk/CV/FindWork/Details/5383201",
                    region: "Midtjylland",
                    municipality: "Aarhus",
                    country: "Danmark",
                    employmentType: "",
                    workHours: "Fuldtid",
                    occupation: "Laboratorietekniker",
                    workplaceId: 0,
                    organisationId: 90880,
                    hiringOrgCVR: 31119103,
                    id: 5383201,
                    workPlaceCityWithoutZone: "Aarhus",
                    jobPostingNumber: 13,
                    jobPostingId: "5383201laboratorytechnicianforplantanalysis",
                    language: "en"
                );
        public static JobPostingExtended Shared_JobPage01_JobPostingExtended13
            = new JobPostingExtended(
                    jobPosting: Shared_JobPage01_JobPosting13,
                    response: Shared_FakeResponse,                      // Ignored
                    hiringOrgDescription: null,
                    publicationStartDate: null,
                    publicationEndDate: null,
                    purpose: Shared_FakePurpose,                        // Ignored
                    numberToFill: null,
                    contactEmail: null,
                    contactPersonName: null,
                    employmentDate: null,
                    applicationDeadlineDate: null,
                    bulletPoints: new List<BulletPoint>()
                    {

                        new BulletPoint(
                            text: "Analysis of plant ingredients e.g. phenols, carbohydrates, polyacetylenes, glucosinolates, etc. using HPLC, GC-MS, and IC",
                            type: null
                            ),
                        new BulletPoint(
                            text: "Microbiology",
                            type: null
                            ),
                        new BulletPoint(
                            text: "Laboratory guidance of students and researchers",
                            type: null
                            ),
                        new BulletPoint(
                            text: "Method development",
                            type: null
                            ),
                        new BulletPoint(
                            text: "Sample collection, sample preparation and data processing",
                            type: null
                            ),
                        new BulletPoint(
                            text: "Maintenance of various analysis equipment and laboratory management",
                            type: null
                            ),
                        new BulletPoint(
                            text: "Photography in studios and ‘on the spot’ plants, plant products and experimental setup as documentation of the experimental work.",
                            type: null
                            )
                        
                    },
                    bulletPointScenario: "generic"
                );

        public static JobPosting Shared_JobPage01_JobPosting14
            = new JobPosting(
                    runId: Shared_FakeRunId,
                    pageNumber: 1,
                    response: "{\r\n            \"AutomatchType\": 0,\r\n            \"Abroad\": false,\r\n            \"Weight\": 1.0,\r\n            \"Title\": \"Laboratory technician for food processing and ingredients analysis, Department of Food Science, Aarhus University\",\r\n            \"JobHeadline\": \"Laboratory technician for food processing and ingredients analysis, Department of Food Science, Aarhus University\",\r\n            \"Presentation\": \"At the Department of Food Science, the Science Team for Food Technology (FT), a full-time position as a laboratory technician is available for appointment as from 15 September 2021 or soon thereafter.\",\r\n            \"HiringOrgName\": \"Aarhus Universitet\",\r\n            \"WorkPlaceAddress\": \"Agro Food Park 48\",\r\n            \"WorkPlacePostalCode\": \"8200\",\r\n            \"WorkPlaceCity\": \"Aarhus N\",\r\n            \"WorkPlaceOtherAddress\": false,\r\n            \"WorkPlaceAbroad\": false,\r\n            \"WorkPlaceNotStatic\": false,\r\n            \"UseWorkPlaceAddressForJoblog\": true,\r\n            \"PostingCreated\": \"2021-07-02T00:00:00\",\r\n            \"LastDateApplication\": \"2021-08-02T00:00:00\",\r\n            \"FormattedLastDateApplication\": \"2. august 2021\",\r\n            \"AssignmentStartDate\": \"0001-01-01T00:00:00\",\r\n            \"IsHotjob\": false,\r\n            \"IsExternal\": false,\r\n            \"Url\": \"https://job.jobnet.dk/CV/FindWork/Details/5383195\",\r\n            \"Region\": \"Midtjylland\",\r\n            \"Municipality\": \"Aarhus\",\r\n            \"Country\": \"Danmark\",\r\n            \"PostalCode\": \"8200\",\r\n            \"PostalCodeName\": null,\r\n            \"JobAnnouncementType\": \"\",\r\n            \"EmploymentType\": \"\",\r\n            \"WorkHours\": \"Fuldtid\",\r\n            \"OccupationArea\": \"\",\r\n            \"OccupationGroup\": \"\",\r\n            \"Occupation\": \"Laboratorietekniker\",\r\n            \"Location\": {\r\n                \"Latitude\": 56.1985,\r\n                \"Longitude\": 10.1558\r\n            },\r\n            \"JoblogWorkTime\": {\r\n                \"WorkHour\": null,\r\n                \"DailyWorkTime\": null\r\n            },\r\n            \"WorkplaceID\": 0,\r\n            \"OrganisationId\": \"90880\",\r\n            \"HiringOrgCVR\": 31119103,\r\n            \"UserLoggedIn\": false,\r\n            \"AnonymousEmployer\": false,\r\n            \"ShareUrl\": \"https://job.jobnet.dk/CV/FindWork/DetailsSocialmedia/5383195\",\r\n            \"DetailsUrl\": \"https://job.jobnet.dk/CV/FindWork/DetailsWidk/5383195\",\r\n            \"JobLogUrl\": \"https://job.jobnet.dk/CV/FindWork/Details/5383195\",\r\n            \"HasLocationValues\": true,\r\n            \"ID\": \"5383195\",\r\n            \"Latitude\": 56.1985,\r\n            \"Longitude\": 10.1558\r\n        }",
                    title: "Laboratory technician for food processing and ingredients analysis, Department of Food Science, Aarhus University",
                    presentation: "At the Department of Food Science, the Science Team for Food Technology (FT), a full-time position as a laboratory technician is available for appointment as from 15 September 2021 or soon thereafter.",
                    hiringOrgName: "Aarhus Universitet",
                    workPlaceAddress: "Agro Food Park 48",
                    workPlacePostalCode: 8200,
                    workPlaceCity: "Aarhus N",
                    postingCreated: new DateTime(2021, 07, 02),
                    lastDateApplication: new DateTime(2021, 08, 02),
                    url: "https://job.jobnet.dk/CV/FindWork/Details/5383195",
                    region: "Midtjylland",
                    municipality: "Aarhus",
                    country: "Danmark",
                    employmentType: "",
                    workHours: "Fuldtid",
                    occupation: "Laboratorietekniker",
                    workplaceId: 0,
                    organisationId: 90880,
                    hiringOrgCVR: 31119103,
                    id: 5383195,
                    workPlaceCityWithoutZone: "Aarhus",
                    jobPostingNumber: 14,
                    jobPostingId: "5383195laboratorytechnicianforfoodprocessing",
                    language: "en"
                );
        public static JobPostingExtended Shared_JobPage01_JobPostingExtended14
            = new JobPostingExtended(
                    jobPosting: Shared_JobPage01_JobPosting14,
                    response: Shared_FakeResponse,                      // Ignored
                    hiringOrgDescription: null,
                    publicationStartDate: null,
                    publicationEndDate: null,
                    purpose: Shared_FakePurpose,                        // Ignored
                    numberToFill: null,
                    contactEmail: null,
                    contactPersonName: null,
                    employmentDate: null,
                    applicationDeadlineDate: null,
                    bulletPoints: new List<BulletPoint>()
                    {

                        new BulletPoint(
                            text: "Analysis with ICP-MS and HPLC",
                            type: null
                            ),
                        new BulletPoint(
                            text: "Working with food processing in laboratory / pilot scale",
                            type: null
                            ),
                        new BulletPoint(
                            text: "Laboratory guidance of students and researchers",
                            type: null
                            ),
                        new BulletPoint(
                            text: "Method development",
                            type: null
                            ),
                        new BulletPoint(
                            text: "Sample collection, sample preparation and data processing",
                            type: null
                            ),
                        new BulletPoint(
                            text: "Maintenance of various analysis equipment and laboratory management",
                            type: null
                            ),
                        new BulletPoint(
                            text: "Purchase of consumables and minor equipment for the laboratory.",
                            type: null
                            )

                    },
                    bulletPointScenario: "generic"
                );

        public static JobPosting Shared_JobPage01_JobPosting15
            = new JobPosting(
                    runId: Shared_FakeRunId,
                    pageNumber: 1,
                    response: "{\r\n            \"AutomatchType\": 0,\r\n            \"Abroad\": false,\r\n            \"Weight\": 1.0,\r\n            \"Title\": \"Lagermedarbejdere til pakkeopgaver på daghold i Horsens / Warehouse worker for packing line on day shifts in Horsens\",\r\n            \"JobHeadline\": \"Lagermedarbejdere til pakkeopgaver på daghold i Horsens / Warehouse worker for packing line on day shifts in Horsens\",\r\n            \"Presentation\": \"<p><strong>English version below the Danish</strong>\u00A0 \u00A0 \u00A0 \u00A0 \u00A0 \u00A0 \u00A0 \u00A0 \u00A0 \u00A0 \u00A0 \u00A0 \u00A0 \u00A0 \u00A0 \u00A0 \u00A0 \u00A0 \u00A0 \u00A0 \u00A0 \u00A0 \u00A0 \u00A0 \u00A0 \u00A0</p>\\n<p>Har du lyst til at arbejde inden for lager, og kan du lige aktivt arbejde, så se her.</p>\",\r\n            \"HiringOrgName\": \"TeamVikaren.dk, Århus ApS, Horsens Afdeling\",\r\n            \"WorkPlaceAddress\": \"\",\r\n            \"WorkPlacePostalCode\": \"8700\",\r\n            \"WorkPlaceCity\": \"Horsens\",\r\n            \"WorkPlaceOtherAddress\": false,\r\n            \"WorkPlaceAbroad\": false,\r\n            \"WorkPlaceNotStatic\": false,\r\n            \"UseWorkPlaceAddressForJoblog\": true,\r\n            \"PostingCreated\": \"2021-07-02T00:00:00\",\r\n            \"LastDateApplication\": \"2021-08-27T00:00:00\",\r\n            \"FormattedLastDateApplication\": \"27. august 2021\",\r\n            \"AssignmentStartDate\": \"0001-01-01T00:00:00\",\r\n            \"IsHotjob\": false,\r\n            \"IsExternal\": false,\r\n            \"Url\": \"https://job.jobnet.dk/CV/FindWork/Details/5383165\",\r\n            \"Region\": \"Midtjylland\",\r\n            \"Municipality\": \"Horsens\",\r\n            \"Country\": \"Danmark\",\r\n            \"PostalCode\": \"8700\",\r\n            \"PostalCodeName\": null,\r\n            \"JobAnnouncementType\": \"\",\r\n            \"EmploymentType\": \"\",\r\n            \"WorkHours\": \"Fuldtid\",\r\n            \"OccupationArea\": \"\",\r\n            \"OccupationGroup\": \"\",\r\n            \"Occupation\": \"Lager- og logistikmedarbejder\",\r\n            \"Location\": {\r\n                \"Latitude\": 55.866,\r\n                \"Longitude\": 9.893\r\n            },\r\n            \"JoblogWorkTime\": {\r\n                \"WorkHour\": null,\r\n                \"DailyWorkTime\": \"Dag\"\r\n            },\r\n            \"WorkplaceID\": 126565,\r\n            \"OrganisationId\": \"71174\",\r\n            \"HiringOrgCVR\": 30899695,\r\n            \"UserLoggedIn\": false,\r\n            \"AnonymousEmployer\": false,\r\n            \"ShareUrl\": \"https://job.jobnet.dk/CV/FindWork/DetailsSocialmedia/5383165\",\r\n            \"DetailsUrl\": \"https://job.jobnet.dk/CV/FindWork/DetailsWidk/5383165\",\r\n            \"JobLogUrl\": \"https://job.jobnet.dk/CV/FindWork/Details/5383165\",\r\n            \"HasLocationValues\": true,\r\n            \"ID\": \"5383165\",\r\n            \"Latitude\": 55.866,\r\n            \"Longitude\": 9.893\r\n        }",
                    title: "Lagermedarbejdere til pakkeopgaver på daghold i Horsens / Warehouse worker for packing line on day shifts in Horsens",
                    presentation: "<p><strong>English version below the Danish</strong>\u00A0 \u00A0 \u00A0 \u00A0 \u00A0 \u00A0 \u00A0 \u00A0 \u00A0 \u00A0 \u00A0 \u00A0 \u00A0 \u00A0 \u00A0 \u00A0 \u00A0 \u00A0 \u00A0 \u00A0 \u00A0 \u00A0 \u00A0 \u00A0 \u00A0 \u00A0</p>\n<p>Har du lyst til at arbejde inden for lager, og kan du lige aktivt arbejde, så se her.</p>",
                    hiringOrgName: "TeamVikaren.dk, Århus ApS, Horsens Afdeling",
                    workPlaceAddress: "",
                    workPlacePostalCode: 8700,
                    workPlaceCity: "Horsens",
                    postingCreated: new DateTime(2021, 07, 02),
                    lastDateApplication: new DateTime(2021, 08, 27),
                    url: "https://job.jobnet.dk/CV/FindWork/Details/5383165",
                    region: "Midtjylland",
                    municipality: "Horsens",
                    country: "Danmark",
                    employmentType: "",
                    workHours: "Fuldtid",
                    occupation: "Lager- og logistikmedarbejder",
                    workplaceId: 126565,
                    organisationId: 71174,
                    hiringOrgCVR: 30899695,
                    id: 5383165,
                    workPlaceCityWithoutZone: "Horsens",
                    jobPostingNumber: 15,
                    jobPostingId: "5383165lagermedarbejderetilpakkeopgaverpdaghold",
                    language: "dk/en"
                );
        public static JobPostingExtended Shared_JobPage01_JobPostingExtended15
            = new JobPostingExtended(
                    jobPosting: Shared_JobPage01_JobPosting15,
                    response: Shared_FakeResponse,                      // Ignored
                    hiringOrgDescription: null,
                    publicationStartDate: new DateTime(2021, 07, 02),
                    publicationEndDate: new DateTime(2021, 08, 27),
                    purpose: Shared_FakePurpose,                        // Ignored
                    numberToFill: 1,
                    contactEmail: null,
                    contactPersonName: "Majken Lorentzen",
                    employmentDate: null,
                    applicationDeadlineDate: new DateTime(2021, 08, 27),
                    bulletPoints: null,
                    bulletPointScenario: null
                );

        public static JobPosting Shared_JobPage01_JobPosting16
            = new JobPosting(
                    runId: Shared_FakeRunId,
                    pageNumber: 1,
                    response: "{\r\n            \"AutomatchType\": 0,\r\n            \"Abroad\": false,\r\n            \"Weight\": 1.0,\r\n            \"Title\": \"Motivated employee for emptying containers in a warehouse in Horsens, start-up as soon as possible\",\r\n            \"JobHeadline\": \"Motivated employee for emptying containers in a warehouse in Horsens, start-up as soon as possible\",\r\n            \"Presentation\": \" Do you like active work, do you prefer to work morning shifts? Then we have the job for you. \\n  We offer  \\n \\n A social workplace \\n Active work \\n\",\r\n            \"HiringOrgName\": \"TeamVikaren.dk, Århus ApS, Horsens Afdeling\",\r\n            \"WorkPlaceAddress\": \"\",\r\n            \"WorkPlacePostalCode\": \"8700\",\r\n            \"WorkPlaceCity\": \"Horsens\",\r\n            \"WorkPlaceOtherAddress\": false,\r\n            \"WorkPlaceAbroad\": false,\r\n            \"WorkPlaceNotStatic\": false,\r\n            \"UseWorkPlaceAddressForJoblog\": true,\r\n            \"PostingCreated\": \"2021-07-02T00:00:00\",\r\n            \"LastDateApplication\": \"2021-07-12T00:00:00\",\r\n            \"FormattedLastDateApplication\": \"12. juli 2021\",\r\n            \"AssignmentStartDate\": \"0001-01-01T00:00:00\",\r\n            \"IsHotjob\": false,\r\n            \"IsExternal\": false,\r\n            \"Url\": \"https://job.jobnet.dk/CV/FindWork/Details/5346333\",\r\n            \"Region\": \"Midtjylland\",\r\n            \"Municipality\": \"Horsens\",\r\n            \"Country\": \"Danmark\",\r\n            \"PostalCode\": \"8700\",\r\n            \"PostalCodeName\": null,\r\n            \"JobAnnouncementType\": \"\",\r\n            \"EmploymentType\": \"\",\r\n            \"WorkHours\": \"Fuldtid\",\r\n            \"OccupationArea\": \"\",\r\n            \"OccupationGroup\": \"\",\r\n            \"Occupation\": \"Lager- og logistikmedarbejder\",\r\n            \"Location\": {\r\n                \"Latitude\": 55.866,\r\n                \"Longitude\": 9.893\r\n            },\r\n            \"JoblogWorkTime\": {\r\n                \"WorkHour\": null,\r\n                \"DailyWorkTime\": \"Dag\"\r\n            },\r\n            \"WorkplaceID\": 126565,\r\n            \"OrganisationId\": \"71174\",\r\n            \"HiringOrgCVR\": 30899695,\r\n            \"UserLoggedIn\": false,\r\n            \"AnonymousEmployer\": false,\r\n            \"ShareUrl\": \"https://job.jobnet.dk/CV/FindWork/DetailsSocialmedia/5346333\",\r\n            \"DetailsUrl\": \"https://job.jobnet.dk/CV/FindWork/DetailsWidk/5346333\",\r\n            \"JobLogUrl\": \"https://job.jobnet.dk/CV/FindWork/Details/5346333\",\r\n            \"HasLocationValues\": true,\r\n            \"ID\": \"5346333\",\r\n            \"Latitude\": 55.866,\r\n            \"Longitude\": 9.893\r\n        }",
                    title: "Motivated employee for emptying containers in a warehouse in Horsens, start-up as soon as possible",
                    presentation: " Do you like active work, do you prefer to work morning shifts? Then we have the job for you. \n  We offer  \n \n A social workplace \n Active work \n",
                    hiringOrgName: "TeamVikaren.dk, Århus ApS, Horsens Afdeling",
                    workPlaceAddress: "",
                    workPlacePostalCode: 8700,
                    workPlaceCity: "Horsens",
                    postingCreated: new DateTime(2021, 07, 02),
                    lastDateApplication: new DateTime(2021, 07, 12),
                    url: "https://job.jobnet.dk/CV/FindWork/Details/5346333",
                    region: "Midtjylland",
                    municipality: "Horsens",
                    country: "Danmark",
                    employmentType: "",
                    workHours: "Fuldtid",
                    occupation: "Lager- og logistikmedarbejder",
                    workplaceId: 126565,
                    organisationId: 71174,
                    hiringOrgCVR: 30899695,
                    id: 5346333,
                    workPlaceCityWithoutZone: "Horsens",
                    jobPostingNumber: 16,
                    jobPostingId: "5346333motivatedemployeeforemptyingcontainers",
                    language: "dk/en" // To-do: this prediction must be improved (ClassificationManager).
                );
        public static JobPostingExtended Shared_JobPage01_JobPostingExtended16
            = new JobPostingExtended(
                    jobPosting: Shared_JobPage01_JobPosting16,
                    response: Shared_FakeResponse,                      // Ignored
                    hiringOrgDescription: null,
                    publicationStartDate: new DateTime(2021, 07, 02),
                    publicationEndDate: new DateTime(2021, 07, 12),
                    purpose: Shared_FakePurpose,                        // Ignored
                    numberToFill: 5,
                    contactEmail: null,
                    contactPersonName: "Majken Lorentzen",
                    employmentDate: null,
                    applicationDeadlineDate: new DateTime(2021, 07, 12),
                    bulletPoints: new List<BulletPoint>()
                    {

                        new BulletPoint(
                            text: "A social workplace",
                            type: null
                            ),
                        new BulletPoint(
                            text: "Active work",
                            type: null
                            ),
                        new BulletPoint(
                            text: "Day and evening shifts",
                            type: null
                            ),
                        new BulletPoint(
                            text: "A healthy working environment",
                            type: null
                            ),
                        new BulletPoint(
                            text: "Good colleagues",
                            type: null
                            ),
                        new BulletPoint(
                            text: "You would like to work in a warehouse",
                            type: null
                            ),
                        new BulletPoint(
                            text: "You like active and physical work",
                            type: null
                            ),
                        new BulletPoint(
                            text: "You can work full time or part time",
                            type: null
                            ),
                        new BulletPoint(
                            text: "You can work independently",
                            type: null
                            )
                        
                    },
                    bulletPointScenario: "generic"
                );

        public static JobPosting Shared_JobPage01_JobPosting17
            = new JobPosting(
                    runId: Shared_FakeRunId,
                    pageNumber: 1,
                    response: "{\r\n            \"AutomatchType\": 0,\r\n            \"Abroad\": false,\r\n            \"Weight\": 1.0,\r\n            \"Title\": \"Medarbejdere til sommer vikariater på lager i Kolding/Employees for temporary summer positions in a warehouse in Kolding\",\r\n            \"JobHeadline\": \"Medarbejdere til sommer vikariater på lager i Kolding/Employees for temporary summer positions in a warehouse in Kolding\",\r\n            \"Presentation\": \" \u00A0 \\n  English version below the Danish  \\n Har du lyst til at arbejde på lager, og kan du arbejde i perioden 12/7 til 30/9 på daghold, så har vi arbejde til dig. \\n \",\r\n            \"HiringOrgName\": \"TeamVikaren.dk, Århus ApS, Horsens Afdeling\",\r\n            \"WorkPlaceAddress\": \"\",\r\n            \"WorkPlacePostalCode\": \"6000\",\r\n            \"WorkPlaceCity\": \"Kolding\",\r\n            \"WorkPlaceOtherAddress\": true,\r\n            \"WorkPlaceAbroad\": false,\r\n            \"WorkPlaceNotStatic\": false,\r\n            \"UseWorkPlaceAddressForJoblog\": false,\r\n            \"PostingCreated\": \"2021-07-02T00:00:00\",\r\n            \"LastDateApplication\": \"2021-08-19T00:00:00\",\r\n            \"FormattedLastDateApplication\": \"19. august 2021\",\r\n            \"AssignmentStartDate\": \"0001-01-01T00:00:00\",\r\n            \"IsHotjob\": false,\r\n            \"IsExternal\": false,\r\n            \"Url\": \"https://job.jobnet.dk/CV/FindWork/Details/5376709\",\r\n            \"Region\": \"Syddanmark\",\r\n            \"Municipality\": \"Kolding\",\r\n            \"Country\": \"Danmark\",\r\n            \"PostalCode\": \"6000\",\r\n            \"PostalCodeName\": null,\r\n            \"JobAnnouncementType\": \"\",\r\n            \"EmploymentType\": \"\",\r\n            \"WorkHours\": \"Fuldtid\",\r\n            \"OccupationArea\": \"\",\r\n            \"OccupationGroup\": \"\",\r\n            \"Occupation\": \"Lager- og logistikmedarbejder\",\r\n            \"Location\": {\r\n                \"Latitude\": 55.5022,\r\n                \"Longitude\": 9.4685\r\n            },\r\n            \"JoblogWorkTime\": {\r\n                \"WorkHour\": null,\r\n                \"DailyWorkTime\": \"Dag\"\r\n            },\r\n            \"WorkplaceID\": 126565,\r\n            \"OrganisationId\": \"71174\",\r\n            \"HiringOrgCVR\": 30899695,\r\n            \"UserLoggedIn\": false,\r\n            \"AnonymousEmployer\": false,\r\n            \"ShareUrl\": \"https://job.jobnet.dk/CV/FindWork/DetailsSocialmedia/5376709\",\r\n            \"DetailsUrl\": \"https://job.jobnet.dk/CV/FindWork/DetailsWidk/5376709\",\r\n            \"JobLogUrl\": \"https://job.jobnet.dk/CV/FindWork/Details/5376709\",\r\n            \"HasLocationValues\": true,\r\n            \"ID\": \"5376709\",\r\n            \"Latitude\": 55.5022,\r\n            \"Longitude\": 9.4685\r\n        }",
                    title: "Medarbejdere til sommer vikariater på lager i Kolding/Employees for temporary summer positions in a warehouse in Kolding",
                    presentation: " \u00A0 \n  English version below the Danish  \n Har du lyst til at arbejde på lager, og kan du arbejde i perioden 12/7 til 30/9 på daghold, så har vi arbejde til dig. \n ",
                    hiringOrgName: "TeamVikaren.dk, Århus ApS, Horsens Afdeling",
                    workPlaceAddress: "",
                    workPlacePostalCode: 6000,
                    workPlaceCity: "Kolding",
                    postingCreated: new DateTime(2021, 07, 02),
                    lastDateApplication: new DateTime(2021, 08, 19),
                    url: "https://job.jobnet.dk/CV/FindWork/Details/5376709",
                    region: "Syddanmark",
                    municipality: "Kolding",
                    country: "Danmark",
                    employmentType: "",
                    workHours: "Fuldtid",
                    occupation: "Lager- og logistikmedarbejder",
                    workplaceId: 126565,
                    organisationId: 71174,
                    hiringOrgCVR: 30899695,
                    id: 5376709,
                    workPlaceCityWithoutZone: "Kolding",
                    jobPostingNumber: 17,
                    jobPostingId: "5376709medarbejderetilsommervikariaterp",
                    language: "dk/en"
                );
        public static JobPostingExtended Shared_JobPage01_JobPostingExtended17
            = new JobPostingExtended(
                    jobPosting: Shared_JobPage01_JobPosting17,
                    response: Shared_FakeResponse,                      // Ignored
                    hiringOrgDescription: null,
                    publicationStartDate: new DateTime(2021, 07, 02),
                    publicationEndDate: new DateTime(2021, 08, 19),
                    purpose: Shared_FakePurpose,                        // Ignored
                    numberToFill: 10,
                    contactEmail: null,
                    contactPersonName: "Majken Lorentzen",
                    employmentDate: null,
                    applicationDeadlineDate: new DateTime(2021, 08, 19),
                    bulletPoints: new List<BulletPoint>()
                    {

                        new BulletPoint(
                            text: "Arbejde på daghold",
                            type: null
                            ),
                        new BulletPoint(
                            text: "Gode kollegaer",
                            type: null
                            ),
                        new BulletPoint(
                            text: "Grundig oplæring",
                            type: null
                            ),
                        new BulletPoint(
                            text: "Mulighed for aktivt arbejde",
                            type: null
                            ),
                        new BulletPoint(
                            text: "Du kan lide aktivt arbejde",
                            type: null
                            ),
                        new BulletPoint(
                            text: "Du kan lide at veksle mellem forskellige arbejdsopgaver",
                            type: null
                            ),
                        new BulletPoint(
                            text: "Du har en god fysik",
                            type: null
                            ),
                        new BulletPoint(
                            text: "Du kan arbejde daghold på fuldtid – deltid kan også arrangeres",
                            type: null
                            ),
                        new BulletPoint(
                            text: "Du er grundig i dit arbejde og har en positiv tilgang til dine arbejdsopgaver",
                            type: null
                            ),
                        new BulletPoint(
                            text: "Du er fleksibel i travle perioder",
                            type: null
                            ),
                        new BulletPoint(
                            text: "Work on day shifts",
                            type: null
                            ),
                        new BulletPoint(
                            text: "Good colleagues",
                            type: null
                            ),
                        new BulletPoint(
                            text: "Thorough training",
                            type: null
                            ),
                        new BulletPoint(
                            text: "Opportunity for active work",
                            type: null
                            ),
                        new BulletPoint(
                            text: "You like active work",
                            type: null
                            ),
                        new BulletPoint(
                            text: "You like to have different work tasks",
                            type: null
                            ),
                        new BulletPoint(
                            text: "You have a good physique",
                            type: null
                            ),
                        new BulletPoint(
                            text: "You can work day shifts full time - part time can also be arranged",
                            type: null
                            ),
                        new BulletPoint(
                            text: "You are thorough in your work and have a positive approach to your work tasks",
                            type: null
                            ),
                        new BulletPoint(
                            text: "You are flexible during busy periods",
                            type: null
                            )
                        
                    },
                    bulletPointScenario: "generic"
                );

        public static JobPosting Shared_JobPage01_JobPosting18
            = new JobPosting(
                    runId: Shared_FakeRunId,
                    pageNumber: 1,
                    response: "{\r\n            \"AutomatchType\": 0,\r\n            \"Abroad\": false,\r\n            \"Weight\": 1.0,\r\n            \"Title\": \"Tenure Track Assistant Professorships in Strategy and Innovation\",\r\n            \"JobHeadline\": \"Tenure Track Assistant Professorships in Strategy and Innovation\",\r\n            \"Presentation\": \"Copenhagen Business School invites applications for a number of Tenure Track Assistant Professorships at the Department of Strategy and Innovation. Expected starting date is 1 September 2022.<br>\",\r\n            \"HiringOrgName\": \"Copenhagen Business School\",\r\n            \"WorkPlaceAddress\": \"Solbjerg Plads 3\",\r\n            \"WorkPlacePostalCode\": \"2000\",\r\n            \"WorkPlaceCity\": \"Frederiksberg\",\r\n            \"WorkPlaceOtherAddress\": false,\r\n            \"WorkPlaceAbroad\": false,\r\n            \"WorkPlaceNotStatic\": false,\r\n            \"UseWorkPlaceAddressForJoblog\": true,\r\n            \"PostingCreated\": \"2021-07-02T00:00:00\",\r\n            \"LastDateApplication\": \"2021-08-23T00:00:00\",\r\n            \"FormattedLastDateApplication\": \"23. august 2021\",\r\n            \"AssignmentStartDate\": \"0001-01-01T00:00:00\",\r\n            \"IsHotjob\": false,\r\n            \"IsExternal\": false,\r\n            \"Url\": \"https://job.jobnet.dk/CV/FindWork/Details/5382809\",\r\n            \"Region\": \"Hovedstaden og Bornholm\",\r\n            \"Municipality\": \"Frederiksberg\",\r\n            \"Country\": \"Danmark\",\r\n            \"PostalCode\": \"2000\",\r\n            \"PostalCodeName\": null,\r\n            \"JobAnnouncementType\": \"\",\r\n            \"EmploymentType\": \"\",\r\n            \"WorkHours\": \"Fuldtid\",\r\n            \"OccupationArea\": \"\",\r\n            \"OccupationGroup\": \"\",\r\n            \"Occupation\": \"Adjunkt, samfundsvidenskab\",\r\n            \"Location\": {\r\n                \"Latitude\": 55.6815,\r\n                \"Longitude\": 12.5304\r\n            },\r\n            \"JoblogWorkTime\": {\r\n                \"WorkHour\": null,\r\n                \"DailyWorkTime\": null\r\n            },\r\n            \"WorkplaceID\": 79401,\r\n            \"OrganisationId\": \"26360\",\r\n            \"HiringOrgCVR\": 19596915,\r\n            \"UserLoggedIn\": false,\r\n            \"AnonymousEmployer\": false,\r\n            \"ShareUrl\": \"https://job.jobnet.dk/CV/FindWork/DetailsSocialmedia/5382809\",\r\n            \"DetailsUrl\": \"https://job.jobnet.dk/CV/FindWork/DetailsWidk/5382809\",\r\n            \"JobLogUrl\": \"https://job.jobnet.dk/CV/FindWork/Details/5382809\",\r\n            \"HasLocationValues\": true,\r\n            \"ID\": \"5382809\",\r\n            \"Latitude\": 55.6815,\r\n            \"Longitude\": 12.5304\r\n        }",
                    title: "Tenure Track Assistant Professorships in Strategy and Innovation",
                    presentation: "Copenhagen Business School invites applications for a number of Tenure Track Assistant Professorships at the Department of Strategy and Innovation. Expected starting date is 1 September 2022.<br>",
                    hiringOrgName: "Copenhagen Business School",
                    workPlaceAddress: "Solbjerg Plads 3",
                    workPlacePostalCode: 2000,
                    workPlaceCity: "Frederiksberg",
                    postingCreated: new DateTime(2021, 07, 02),
                    lastDateApplication: new DateTime(2021, 08, 23),
                    url: "https://job.jobnet.dk/CV/FindWork/Details/5382809",
                    region: "Hovedstaden og Bornholm",
                    municipality: "Frederiksberg",
                    country: "Danmark",
                    employmentType: "",
                    workHours: "Fuldtid",
                    occupation: "Adjunkt, samfundsvidenskab",
                    workplaceId: 79401,
                    organisationId: 26360,
                    hiringOrgCVR: 19596915,
                    id: 5382809,
                    workPlaceCityWithoutZone: "Frederiksberg",
                    jobPostingNumber: 18,
                    jobPostingId: "5382809tenuretrackassistantprofessorshipsin",
                    language: "en"
                );
        public static JobPostingExtended Shared_JobPage01_JobPostingExtended18
            = new JobPostingExtended(
                    jobPosting: Shared_JobPage01_JobPosting18,
                    response: Shared_FakeResponse,                      // Ignored
                    hiringOrgDescription: null,
                    publicationStartDate: null,
                    publicationEndDate: null,
                    purpose: Shared_FakePurpose,                        // Ignored
                    numberToFill: null,
                    contactEmail: null,
                    contactPersonName: null,
                    employmentDate: null,
                    applicationDeadlineDate: null,
                    bulletPoints: new List<BulletPoint>()
                    {

                        new BulletPoint(
                            text: "Teaching and examination in various study programs",
                            type: null
                            ),
                        new BulletPoint(
                            text: "Development of existing and or new study programs",
                            type: null
                            ),
                        new BulletPoint(
                            text: "Individual and group based research activities of high international standard",
                            type: null
                            ),
                        new BulletPoint(
                            text: "Promotion of CBS’s academic reputation",
                            type: null
                            ),
                        new BulletPoint(
                            text: "Communicating findings to the public in general and to CBS’s stakeholders in particular",
                            type: null
                            ),
                        new BulletPoint(
                            text: "Responsibility for publishing, scientific communication and research-based teaching",
                            type: null
                            ),
                        new BulletPoint(
                            text: "Attracting external funding opportunities",
                            type: null
                            ),
                        new BulletPoint(
                            text: "A cover letter",
                            type: null
                            ),
                        new BulletPoint(
                            text: "Proof of qualifications and a full CV",
                            type: null
                            ),
                        new BulletPoint(
                            text: "Documentation of relevant, significant, original research at an international level, including publications in the field’s internationally recognized journals and citations in the Social Science Citation Index and/or Google Scholar",
                            type: null
                            ),
                        new BulletPoint(
                            text: "Documentation of pedagogical qualifications or other material for the evaluation of his/her pedagogical level * Information indicating experience in research management, industry co-operation and international co-operation",
                            type: null
                            ),
                        new BulletPoint(
                            text: "A complete, numbered list of publications (indicating titles, co-authors, page numbers and year) with an * marking of the academic productions to be considered during the review. A maximum of 10 publications for review are allowed. Applicants are requested to prioritize their publications in relation to the field of this job advertisement.",
                            type: null
                            ),
                        new BulletPoint(
                            text: "Copies of the publications marked with an *.",
                            type: null
                            )
                        
                    },
                    bulletPointScenario: "generic"
                );

        public static JobPosting Shared_JobPage01_JobPosting19
            = new JobPosting(
                    runId: Shared_FakeRunId,
                    pageNumber: 1,
                    response: "{\r\n            \"AutomatchType\": 0,\r\n            \"Abroad\": false,\r\n            \"Weight\": 1.0,\r\n            \"Title\": \"warehouse employee\",\r\n            \"JobHeadline\": \"warehouse employee\",\r\n            \"Presentation\": \"  Warehouse employee  \\n Do you want to join the evening team at DSV in Horsens? It is a permanent day shift, and for the right person it will be a permanent employment. \",\r\n            \"HiringOrgName\": \"RANDSTAD A/S\",\r\n            \"WorkPlaceAddress\": \"\",\r\n            \"WorkPlacePostalCode\": \"8700\",\r\n            \"WorkPlaceCity\": \"Horsens\",\r\n            \"WorkPlaceOtherAddress\": true,\r\n            \"WorkPlaceAbroad\": false,\r\n            \"WorkPlaceNotStatic\": false,\r\n            \"UseWorkPlaceAddressForJoblog\": false,\r\n            \"PostingCreated\": \"2021-07-02T00:00:00\",\r\n            \"LastDateApplication\": \"2021-08-27T00:00:00\",\r\n            \"FormattedLastDateApplication\": \"27. august 2021\",\r\n            \"AssignmentStartDate\": \"0001-01-01T00:00:00\",\r\n            \"IsHotjob\": false,\r\n            \"IsExternal\": false,\r\n            \"Url\": \"https://job.jobnet.dk/CV/FindWork/Details/5382781\",\r\n            \"Region\": \"Midtjylland\",\r\n            \"Municipality\": \"Horsens\",\r\n            \"Country\": \"Danmark\",\r\n            \"PostalCode\": \"8700\",\r\n            \"PostalCodeName\": null,\r\n            \"JobAnnouncementType\": \"\",\r\n            \"EmploymentType\": \"\",\r\n            \"WorkHours\": \"Fuldtid\",\r\n            \"OccupationArea\": \"\",\r\n            \"OccupationGroup\": \"\",\r\n            \"Occupation\": \"Lager- og logistikmedarbejder\",\r\n            \"Location\": {\r\n                \"Latitude\": 55.866,\r\n                \"Longitude\": 9.893\r\n            },\r\n            \"JoblogWorkTime\": {\r\n                \"WorkHour\": null,\r\n                \"DailyWorkTime\": \"Dag\"\r\n            },\r\n            \"WorkplaceID\": 120191,\r\n            \"OrganisationId\": \"106608\",\r\n            \"HiringOrgCVR\": 25050541,\r\n            \"UserLoggedIn\": false,\r\n            \"AnonymousEmployer\": false,\r\n            \"ShareUrl\": \"https://job.jobnet.dk/CV/FindWork/DetailsSocialmedia/5382781\",\r\n            \"DetailsUrl\": \"https://job.jobnet.dk/CV/FindWork/DetailsWidk/5382781\",\r\n            \"JobLogUrl\": \"https://job.jobnet.dk/CV/FindWork/Details/5382781\",\r\n            \"HasLocationValues\": true,\r\n            \"ID\": \"5382781\",\r\n            \"Latitude\": 55.866,\r\n            \"Longitude\": 9.893\r\n        }",
                    title: "warehouse employee",
                    presentation: "  Warehouse employee  \n Do you want to join the evening team at DSV in Horsens? It is a permanent day shift, and for the right person it will be a permanent employment. ",
                    hiringOrgName: "RANDSTAD A/S",
                    workPlaceAddress: "",
                    workPlacePostalCode: 8700,
                    workPlaceCity: "Horsens",
                    postingCreated: new DateTime(2021, 07, 02),
                    lastDateApplication: new DateTime(2021, 08, 27),
                    url: "https://job.jobnet.dk/CV/FindWork/Details/5382781",
                    region: "Midtjylland",
                    municipality: "Horsens",
                    country: "Danmark",
                    employmentType: "",
                    workHours: "Fuldtid",
                    occupation: "Lager- og logistikmedarbejder",
                    workplaceId: 120191,
                    organisationId: 106608,
                    hiringOrgCVR: 25050541,
                    id: 5382781,
                    workPlaceCityWithoutZone: "Horsens",
                    jobPostingNumber: 19,
                    jobPostingId: "5382781warehouseemployee",
                    language: "en"
                );
        public static JobPostingExtended Shared_JobPage01_JobPostingExtended19
            = new JobPostingExtended(
                    jobPosting: Shared_JobPage01_JobPosting19,
                    response: Shared_FakeResponse,                      // Ignored
                    hiringOrgDescription: "Randstad er en del af den internationale Randstad Group, der er verdens andenstørste udbyder af HR-løsninger. Hver dag formidler Randstad arbejde til mere end 500.000 mennesker i hele verden. I Danmark er vi blandt de førende vikar- og rekrutteringsbureauer med fire afdelinger fordelt over hele landet. En position vi har opnået, fordi vi som eksperter på arbejdsmarkedet formår at matche kvalificerede kandidater med de rette jobmuligheder.",
                    publicationStartDate: new DateTime(2021, 07, 02),
                    publicationEndDate: new DateTime(2021, 08, 27),
                    purpose: Shared_FakePurpose,                        // Ignored
                    numberToFill: 1,
                    contactEmail: "charlotte.meck@randstad.dk",
                    contactPersonName: "Charlotte Meck",
                    employmentDate: null,
                    applicationDeadlineDate: new DateTime(2021, 08, 27),
                    bulletPoints: new List<BulletPoint>()
                    {

                        new BulletPoint(
                            text: "Picking/packing tasks",
                            type: null
                            ),
                        new BulletPoint(
                            text: "Loading/unloading tasks",
                            type: null
                            ),
                        new BulletPoint(
                            text: "Receipt of goods",
                            type: null
                            ),
                        new BulletPoint(
                            text: "Truck driving, most often reach truck",
                            type: null
                            ),
                        new BulletPoint(
                            text: "Scanner operation",
                            type: null
                            ),
                        new BulletPoint(
                            text: "Various warehouse tasks",
                            type: null
                            ),
                        new BulletPoint(
                            text: "You will of course receive a thorough training in the work tasks, so you will have the best conditions for success.",
                            type: null
                            ),
                        new BulletPoint(
                            text: "The company generally has an informal work environment with the opportunity to take responsibility for work tasks and planning.",
                            type: null
                            ),
                        new BulletPoint(
                            text: "Are ready to take on evening work",
                            type: null
                            ),
                        new BulletPoint(
                            text: "Have experience from working at a warehouse",
                            type: null
                            ),
                        new BulletPoint(
                            text: "Have a truck certificate",
                            type: null
                            ),
                        new BulletPoint(
                            text: "Are ready to taking up the challenge when it comes to new tasks and flexible working days",
                            type: null
                            ),
                        new BulletPoint(
                            text: "Are able to perform a good job",
                            type: null
                            ),
                        new BulletPoint(
                            text: "Can represent Randstad as an external employee in a positive way at the customer’s premises",
                            type: null
                            ),
                        new BulletPoint(
                            text: "Danish- and English-speaking at a reasonable level",
                            type: null
                            ),
                        new BulletPoint(
                            text: "Basic salary according to qualifications and in addition to this, cf. collective agreement, pension scheme and holiday",
                            type: null
                            ),
                        new BulletPoint(
                            text: "A generally informal work environment with the opportunity to take responsibility for work tasks and planning",
                            type: null
                            ),
                        new BulletPoint(
                            text: "Start-up: As soon as possible, please send your CV",
                            type: null
                            ),
                        new BulletPoint(
                            text: "All inquiries are treated confidentially. Interviews will take place on an ongoing basis.",
                            type: null
                            )

                    },
                    bulletPointScenario: "randstad"
                );

        public static JobPosting Shared_JobPage01_JobPosting20
            = new JobPosting(
                    runId: Shared_FakeRunId,
                    pageNumber: 1,
                    response: "{\r\n            \"AutomatchType\": 0,\r\n            \"Abroad\": false,\r\n            \"Weight\": 1.0,\r\n            \"Title\": \"Postdoc on Digital Platforms and Ecosystems Innovation Dynamics\",\r\n            \"JobHeadline\": \"Postdoc on Digital Platforms and Ecosystems Innovation Dynamics\",\r\n            \"Presentation\": \"Copenhagen Business School, as part of a new initiative to launch a European research network to foster multidisciplinary research on the digital economy, invites applications for a postdoc position a\",\r\n            \"HiringOrgName\": \"Copenhagen Business School\",\r\n            \"WorkPlaceAddress\": \"Solbjerg Plads 3\",\r\n            \"WorkPlacePostalCode\": \"2000\",\r\n            \"WorkPlaceCity\": \"Frederiksberg\",\r\n            \"WorkPlaceOtherAddress\": false,\r\n            \"WorkPlaceAbroad\": false,\r\n            \"WorkPlaceNotStatic\": false,\r\n            \"UseWorkPlaceAddressForJoblog\": true,\r\n            \"PostingCreated\": \"2021-07-02T00:00:00\",\r\n            \"LastDateApplication\": \"2021-08-26T00:00:00\",\r\n            \"FormattedLastDateApplication\": \"26. august 2021\",\r\n            \"AssignmentStartDate\": \"0001-01-01T00:00:00\",\r\n            \"IsHotjob\": false,\r\n            \"IsExternal\": false,\r\n            \"Url\": \"https://job.jobnet.dk/CV/FindWork/Details/5382486\",\r\n            \"Region\": \"Hovedstaden og Bornholm\",\r\n            \"Municipality\": \"Frederiksberg\",\r\n            \"Country\": \"Danmark\",\r\n            \"PostalCode\": \"2000\",\r\n            \"PostalCodeName\": null,\r\n            \"JobAnnouncementType\": \"\",\r\n            \"EmploymentType\": \"\",\r\n            \"WorkHours\": \"Fuldtid\",\r\n            \"OccupationArea\": \"\",\r\n            \"OccupationGroup\": \"\",\r\n            \"Occupation\": \"Forsker, samfundsvidenskab\",\r\n            \"Location\": {\r\n                \"Latitude\": 55.6815,\r\n                \"Longitude\": 12.5304\r\n            },\r\n            \"JoblogWorkTime\": {\r\n                \"WorkHour\": null,\r\n                \"DailyWorkTime\": null\r\n            },\r\n            \"WorkplaceID\": 79401,\r\n            \"OrganisationId\": \"26360\",\r\n            \"HiringOrgCVR\": 19596915,\r\n            \"UserLoggedIn\": false,\r\n            \"AnonymousEmployer\": false,\r\n            \"ShareUrl\": \"https://job.jobnet.dk/CV/FindWork/DetailsSocialmedia/5382486\",\r\n            \"DetailsUrl\": \"https://job.jobnet.dk/CV/FindWork/DetailsWidk/5382486\",\r\n            \"JobLogUrl\": \"https://job.jobnet.dk/CV/FindWork/Details/5382486\",\r\n            \"HasLocationValues\": true,\r\n            \"ID\": \"5382486\",\r\n            \"Latitude\": 55.6815,\r\n            \"Longitude\": 12.5304\r\n        }",
                    title: "Postdoc on Digital Platforms and Ecosystems Innovation Dynamics",
                    presentation: "Copenhagen Business School, as part of a new initiative to launch a European research network to foster multidisciplinary research on the digital economy, invites applications for a postdoc position a",
                    hiringOrgName: "Copenhagen Business School",
                    workPlaceAddress: "Solbjerg Plads 3",
                    workPlacePostalCode: 2000,
                    workPlaceCity: "Frederiksberg",
                    postingCreated: new DateTime(2021, 07, 02),
                    lastDateApplication: new DateTime(2021, 08, 26),
                    url: "https://job.jobnet.dk/CV/FindWork/Details/5382486",
                    region: "Hovedstaden og Bornholm",
                    municipality: "Frederiksberg",
                    country: "Danmark",
                    employmentType: "",
                    workHours: "Fuldtid",
                    occupation: "Forsker, samfundsvidenskab",
                    workplaceId: 79401,
                    organisationId: 26360,
                    hiringOrgCVR: 19596915,
                    id: 5382486,
                    workPlaceCityWithoutZone: "Frederiksberg",
                    jobPostingNumber: 20,
                    jobPostingId: "5382486postdocondigitalplatformsand",
                    language: "en"
                );
        public static JobPostingExtended Shared_JobPage01_JobPostingExtended20
            = new JobPostingExtended(
                    jobPosting: Shared_JobPage01_JobPosting20,
                    response: Shared_FakeResponse,                      // Ignored
                    hiringOrgDescription: null,
                    publicationStartDate: null,
                    publicationEndDate: null,
                    purpose: Shared_FakePurpose,                        // Ignored
                    numberToFill: null,
                    contactEmail: null,
                    contactPersonName: null,
                    employmentDate: null,
                    applicationDeadlineDate: null,
                    bulletPoints: new List<BulletPoint>()
                    {

                        new BulletPoint(
                            text: "How does digital platform design affect user behaviors and outcomes?",
                            type: null
                            ),
                        new BulletPoint(
                            text: "How do complementors compete within and across digital ecosystems?",
                            type: null
                            ),
                        new BulletPoint(
                            text: "How do ecosystems compete?",
                            type: null
                            ),
                        new BulletPoint(
                            text: "What is the role of data and algorithms in steering interactions and value in platform markets and ecosystems (exploiting or correcting consumer behavioral biases)?",
                            type: null
                            ),
                        new BulletPoint(
                            text: "Are data exclusionary or non-rivalry? How do they affect a firm’s competitive advantage in (platform) digital markets?",
                            type: null
                            ),
                        new BulletPoint(
                            text: "How does data enable value creation (for organizations and their stakeholder)?",
                            type: null
                            ),
                        new BulletPoint(
                            text: "How to organize the effective and efficient creation, sharing and usage of data in digital ecosystems?",
                            type: null
                            ),
                        new BulletPoint(
                            text: "Applicants must have completed a PhD in Management, Economics, or other related social science discipline before the beginning the fellowship. Prior work (including but not limited to dissertation) should involve working with large datasets.",
                            type: null
                            ),
                        new BulletPoint(
                            text: "Excellent academic record and work ethic required.",
                            type: null
                            ),
                        new BulletPoint(
                            text: "Excellent organizational and oral/written communication skills required.",
                            type: null
                            ),
                        new BulletPoint(
                            text: "Enthusiasm for research required. The ideal candidate will be thinking of this position as a platform to build skills towards taking on a research professorship in the future.",
                            type: null
                            ),
                        new BulletPoint(
                            text: "Willingness to move to and live in Denmark.",
                            type: null
                            ),
                        new BulletPoint(
                            text: "Cover letter.",
                            type: null
                            ),
                        new BulletPoint(
                            text: "Proof of qualifications and a full CV.",
                            type: null
                            ),
                        new BulletPoint(
                            text: "Any relevant information indicating experience in research management, industry co-operation and international cooperation.",
                            type: null
                            ),
                        new BulletPoint(
                            text: "A complete, numbered list of publications (indicating titles, co-authors, page numbers and year) with an * marking of the academic productions to be considered during the review. A maximum of 10 publications for review are allowed. Applicants are requested to prioritize their publications in relation to the field of this job advertisement.",
                            type: null
                            ),
                        new BulletPoint(
                            text: "Copies of the publications marked with an *. Only publications written in English (or another specified principal language, according to research tradition) or one of the Scandinavian languages will be taken into consideration.",
                            type: null
                            )
                        
                    },
                    bulletPointScenario: "generic"
                );

        public static List<JobPosting> Shared_JobPage01_JobPostings
            = new List<JobPosting>()
            {
                Shared_JobPage01_JobPosting01,
                Shared_JobPage01_JobPosting02,
                Shared_JobPage01_JobPosting03,
                Shared_JobPage01_JobPosting04,
                Shared_JobPage01_JobPosting05,
                Shared_JobPage01_JobPosting06,
                Shared_JobPage01_JobPosting07,
                Shared_JobPage01_JobPosting08,
                Shared_JobPage01_JobPosting09,
                Shared_JobPage01_JobPosting10,
                Shared_JobPage01_JobPosting11,
                Shared_JobPage01_JobPosting12,
                Shared_JobPage01_JobPosting13,
                Shared_JobPage01_JobPosting14,
                Shared_JobPage01_JobPosting15,
                Shared_JobPage01_JobPosting16,
                Shared_JobPage01_JobPosting17,
                Shared_JobPage01_JobPosting18,
                Shared_JobPage01_JobPosting19,
                Shared_JobPage01_JobPosting20
            };
        public static List<JobPostingExtended> Shared_JobPage01_JobPostingsExtended
            = new List<JobPostingExtended>()
            {
                Shared_JobPage01_JobPostingExtended01,
                Shared_JobPage01_JobPostingExtended02,
                Shared_JobPage01_JobPostingExtended03,
                Shared_JobPage01_JobPostingExtended04,
                Shared_JobPage01_JobPostingExtended05,
                Shared_JobPage01_JobPostingExtended06,
                Shared_JobPage01_JobPostingExtended07,
                Shared_JobPage01_JobPostingExtended08,
                Shared_JobPage01_JobPostingExtended09,
                Shared_JobPage01_JobPostingExtended10,
                Shared_JobPage01_JobPostingExtended11,
                Shared_JobPage01_JobPostingExtended12,
                Shared_JobPage01_JobPostingExtended13,
                Shared_JobPage01_JobPostingExtended14,
                Shared_JobPage01_JobPostingExtended15,
                Shared_JobPage01_JobPostingExtended16,
                Shared_JobPage01_JobPostingExtended17,
                Shared_JobPage01_JobPostingExtended18,
                Shared_JobPage01_JobPostingExtended19,
                Shared_JobPage01_JobPostingExtended20
            };

        public static JobPage Shared_JobPage01_Object
            = new JobPage(Shared_FakeRunId, 1, Shared_JobPage01_Content);
        public static JobPage Shared_JobPage01WithEmptyResponse_Object
            = new JobPage(Shared_FakeRunId, 1, "{ }");

        public static ushort Shared_JobPage01_TotalResultCount = 2177;
        public static ushort Shared_JobPage01_TotalJobPages = 109;

        public static string Shared_JobPage01_JobPostingId01
            = Shared_JobPage01_JobPostings[10].JobPostingId;                        // "5361275committedemployeesforassemblingdisplays"
        public static List<JobPosting> Shared_JobPage01_RangeForJobPostingId01
            = Shared_JobPage01_JobPostings.GetRange(0, 10);                          // ("5361275committedemployeesforassemblingdisplays") ...

        #endregion

        #region Shared_JobPage02

        public static string Shared_JobPage02_BodyUrl = "/CV/FindWork?Offset=20&SortValue=CreationDate&widk=true";

        public static string Shared_JobPage02_Content
            = Properties.Resources.JobPage02_json;
        public static string Shared_JobPage02_JobPostingExtended01_Content
            = Properties.Resources.JobPage02_JobPostingExtended01_json;
        public static string Shared_JobPage02_JobPostingExtended02_Content
            = Properties.Resources.JobPage02_JobPostingExtended02_json;
        public static string Shared_JobPage02_JobPostingExtended03_Content
            = Properties.Resources.JobPage02_JobPostingExtended03_json;
        public static string Shared_JobPage02_JobPostingExtended04_Content
            = Properties.Resources.JobPage02_JobPostingExtended04_json;
        public static string Shared_JobPage02_JobPostingExtended05_Content
            = Properties.Resources.JobPage02_JobPostingExtended05_json;
        public static string Shared_JobPage02_JobPostingExtended06_Content
            = Properties.Resources.JobPage02_JobPostingExtended06_json;
        public static string Shared_JobPage02_JobPostingExtended07_Content
            = Properties.Resources.JobPage02_JobPostingExtended07_json;
        public static string Shared_JobPage02_JobPostingExtended08_Content
            = Properties.Resources.JobPage02_JobPostingExtended08_json;
        public static string Shared_JobPage02_JobPostingExtended09_Content
            = Properties.Resources.JobPage02_JobPostingExtended09_json;
        public static string Shared_JobPage02_JobPostingExtended10_Content
            = Properties.Resources.JobPage02_JobPostingExtended10;
        public static string Shared_JobPage02_JobPostingExtended11_Content
            = Properties.Resources.JobPage02_JobPostingExtended11;
        public static string Shared_JobPage02_JobPostingExtended12_Content
            = Properties.Resources.JobPage02_JobPostingExtended12;
        public static string Shared_JobPage02_JobPostingExtended13_Content
            = Properties.Resources.JobPage02_JobPostingExtended13;
        public static string Shared_JobPage02_JobPostingExtended14_Content
            = Properties.Resources.JobPage02_JobPostingExtended14;
        public static string Shared_JobPage02_JobPostingExtended15_Content
            = Properties.Resources.JobPage02_JobPostingExtended15;
        public static string Shared_JobPage02_JobPostingExtended16_Content
            = Properties.Resources.JobPage02_JobPostingExtended16;
        public static string Shared_JobPage02_JobPostingExtended17_Content
            = Properties.Resources.JobPage02_JobPostingExtended17;
        public static string Shared_JobPage02_JobPostingExtended18_Content
            = Properties.Resources.JobPage02_JobPostingExtended18;
        public static string Shared_JobPage02_JobPostingExtended19_Content
            = Properties.Resources.JobPage02_JobPostingExtended19;
        public static string Shared_JobPage02_JobPostingExtended20_Content
            = Properties.Resources.JobPage02_JobPostingExtended20;

        public static JobPosting Shared_JobPage02_JobPosting01
            = new JobPosting(
                    runId: Shared_FakeRunId,
                    pageNumber: 2,
                    response: "{\r\n            \"AutomatchType\": 0,\r\n            \"Abroad\": false,\r\n            \"Weight\": 1.0,\r\n            \"Title\": \"Assistant or associate professorship in general didactics and empirical school research\",\r\n            \"JobHeadline\": \"Assistant or associate professorship in general didactics and empirical school research\",\r\n            \"Presentation\": \"The Department of Educational Theory and Curriculum Studies at the Danish School of Education, Aarhus University invites applications for an assistant/associate professorship in the field of general d\",\r\n            \"HiringOrgName\": \"Aarhus Universitet\",\r\n            \"WorkPlaceAddress\": \"Tuborgvej 164\",\r\n            \"WorkPlacePostalCode\": \"2400\",\r\n            \"WorkPlaceCity\": \"København NV\",\r\n            \"WorkPlaceOtherAddress\": false,\r\n            \"WorkPlaceAbroad\": false,\r\n            \"WorkPlaceNotStatic\": false,\r\n            \"UseWorkPlaceAddressForJoblog\": true,\r\n            \"PostingCreated\": \"2021-07-02T00:00:00\",\r\n            \"LastDateApplication\": \"2021-08-09T00:00:00\",\r\n            \"FormattedLastDateApplication\": \"9. august 2021\",\r\n            \"AssignmentStartDate\": \"0001-01-01T00:00:00\",\r\n            \"IsHotjob\": false,\r\n            \"IsExternal\": false,\r\n            \"Url\": \"https://job.jobnet.dk/CV/FindWork/Details/5382440\",\r\n            \"Region\": \"Hovedstaden og Bornholm\",\r\n            \"Municipality\": \"København\",\r\n            \"Country\": \"Danmark\",\r\n            \"PostalCode\": \"2400\",\r\n            \"PostalCodeName\": null,\r\n            \"JobAnnouncementType\": \"\",\r\n            \"EmploymentType\": \"\",\r\n            \"WorkHours\": \"Fuldtid\",\r\n            \"OccupationArea\": \"\",\r\n            \"OccupationGroup\": \"\",\r\n            \"Occupation\": \"Adjunkt, samfundsvidenskab\",\r\n            \"Location\": {\r\n                \"Latitude\": 55.7217,\r\n                \"Longitude\": 12.5432\r\n            },\r\n            \"JoblogWorkTime\": {\r\n                \"WorkHour\": null,\r\n                \"DailyWorkTime\": null\r\n            },\r\n            \"WorkplaceID\": 106637,\r\n            \"OrganisationId\": \"90880\",\r\n            \"HiringOrgCVR\": 31119103,\r\n            \"UserLoggedIn\": false,\r\n            \"AnonymousEmployer\": false,\r\n            \"ShareUrl\": \"https://job.jobnet.dk/CV/FindWork/DetailsSocialmedia/5382440\",\r\n            \"DetailsUrl\": \"https://job.jobnet.dk/CV/FindWork/DetailsWidk/5382440\",\r\n            \"JobLogUrl\": \"https://job.jobnet.dk/CV/FindWork/Details/5382440\",\r\n            \"HasLocationValues\": true,\r\n            \"ID\": \"5382440\",\r\n            \"Latitude\": 55.7217,\r\n            \"Longitude\": 12.5432\r\n        }",
                    title: "Assistant or associate professorship in general didactics and empirical school research",
                    presentation: "The Department of Educational Theory and Curriculum Studies at the Danish School of Education, Aarhus University invites applications for an assistant/associate professorship in the field of general d",
                    hiringOrgName: "Aarhus Universitet",
                    workPlaceAddress: "Tuborgvej 164",
                    workPlacePostalCode: 2400,
                    workPlaceCity: "København NV",
                    postingCreated: new DateTime(2021, 07, 02),
                    lastDateApplication: new DateTime(2021, 08, 09),
                    url: "https://job.jobnet.dk/CV/FindWork/Details/5382440",
                    region: "Hovedstaden og Bornholm",
                    municipality: "København",
                    country: "Danmark",
                    employmentType: "",
                    workHours: "Fuldtid",
                    occupation: "Adjunkt, samfundsvidenskab",
                    workplaceId: 106637,
                    organisationId: 90880,
                    hiringOrgCVR: 31119103,
                    id: 5382440,
                    workPlaceCityWithoutZone: "København",
                    jobPostingNumber: 1,
                    jobPostingId: "5382440assistantorassociateprofessorshipin",
                    language: "en"
                );
        public static JobPostingExtended Shared_JobPage02_JobPostingExtended01
            = new JobPostingExtended(
                    jobPosting: Shared_JobPage02_JobPosting01,
                    response: Shared_FakeResponse,                      // Ignored
                    hiringOrgDescription: null,
                    publicationStartDate: null,
                    publicationEndDate: null,
                    purpose: Shared_FakePurpose,                        // Ignored
                    numberToFill: null,
                    contactEmail: null,
                    contactPersonName: null,
                    employmentDate: null,
                    applicationDeadlineDate: null,
                    bulletPoints: new List<BulletPoint>()
                    {

                        new BulletPoint(
                            text: "Has specific research experience in the field of empirically informed teaching, learning outcome and/or student motivation",
                            type: null
                            ),
                        new BulletPoint(
                            text: "Has specific research experience connected to the role of digital technologies in shaping teaching and subject areas",
                            type: null
                            ),
                        new BulletPoint(
                            text: "Can demonstrate skills in collaborative and cross-disciplinary research",
                            type: null
                            ),
                        new BulletPoint(
                            text: "Can demonstrate skills in handling various qualitative and quantitative scientific methods.",
                            type: null
                            ),
                        new BulletPoint(
                            text: "Substantial research experience in general didactics in relation to empirical school research",
                            type: null
                            ),
                        new BulletPoint(
                            text: "An internationally oriented research profile",
                            type: null
                            ),
                        new BulletPoint(
                            text: "A relevant and internationally oriented publication profile",
                            type: null
                            ),
                        new BulletPoint(
                            text: "Experience of or interest in participation in national and international research networks",
                            type: null
                            ),
                        new BulletPoint(
                            text: "Experience of or interest in communication and knowledge exchange",
                            type: null
                            ),
                        new BulletPoint(
                            text: "Experience of or interest in interdisciplinary collaboration as well as interdisciplinary research",
                            type: null
                            ),
                        new BulletPoint(
                            text: "Experience of or the potential for obtaining external research funding",
                            type: null
                            ),
                        new BulletPoint(
                            text: "Teaching experience at university level within the field of general didactics and educational research methods",
                            type: null
                            ),
                        new BulletPoint(
                            text: "Experience of or interest in interdisciplinary teaching including innovative teaching methods",
                            type: null
                            ),
                        new BulletPoint(
                            text: "Experience of or interest in supervising student projects, and interest in researcher talent development.",
                            type: null
                            ),
                        new BulletPoint(
                            text: "Substantial research experience in the field of general didactics and empirical school research",
                            type: null
                            ),
                        new BulletPoint(
                            text: "Substantial experience of empirical research related to didactics, learning outcomes and student motivation",
                            type: null
                            ),
                        new BulletPoint(
                            text: "Skills in collaborative and cross-disciplinary school research",
                            type: null
                            ),
                        new BulletPoint(
                            text: "Skills in empirical school research and empirically informed teaching, including mixed methods",
                            type: null
                            ),
                        new BulletPoint(
                            text: "A strong, relevant international publication profile",
                            type: null
                            ),
                        new BulletPoint(
                            text: "Participation in national and international research networks",
                            type: null
                            ),
                        new BulletPoint(
                            text: "Experience of participation in collective research projects",
                            type: null
                            ),
                        new BulletPoint(
                            text: "Teaching experience at university level within the field general didactics and educational research methods, including innovative teaching methods, and mastery of academic English in the classroom",
                            type: null
                            ),
                        new BulletPoint(
                            text: "Proficiency in languages relevant to the area of research",
                            type: null
                            ),
                        new BulletPoint(
                            text: "Experience of interdisciplinary cooperation outreach activities",
                            type: null
                            ),
                        new BulletPoint(
                            text: "Experience of attracting external research funding",
                            type: null
                            ),
                        new BulletPoint(
                            text: "Experience of supervising student projects and an interest in researcher talent development.",
                            type: null
                            ),
                        new BulletPoint(
                            text: "Faculty of Arts refers to the Ministerial Order on the Appointment of Academic Staff at Danish Universities (the Appointment Order).",
                            type: null
                            ),
                        new BulletPoint(
                            text: "Appointment shall be in accordance with the collective labour agreement between the Danish Ministry of Finance and the Danish Confederation of Professional Associations.",
                            type: null
                            ),
                        new BulletPoint(
                            text: "Further information on qualification requirements and job content may be found in the Memorandum on Job Structure for Academic Staff at Danish Universities .",
                            type: null
                            ),
                        new BulletPoint(
                            text: "Further information on the application and supplementary materials may be found in Application Guidelines.",    
                            type: null
                            ),
                        new BulletPoint(
                            text: "The application must outline the your motivation for applying for the position, attaching a curriculum vitae, copies of relevant degree certificates, and (if relevant for the position) a teaching portfolio. Please upload this material electronically along with your application.",
                            type: null
                            ),
                        new BulletPoint(
                            text: "If you submit your application for the assistant professorship, please upload a maximum of five samples of your scholarly output (mandatory).",
                            type: null
                            ),
                        new BulletPoint(
                            text: "If you submit your application for the associate professorship, please upload a maximum of eight samples of your scholarly output (mandatory).",
                            type: null
                            ),
                        new BulletPoint(
                            text: "Faculty of Arts refers to the Ministerial Order on the Appointment of Academic Staff at Danish Universities(the Appointment Order).",
                            type: null
                            ),
                        new BulletPoint(
                            text: "Further information on qualification requirements and job content may be found in theMemorandum on Job Structure for Academic Staff at Danish Universities.",
                            type: null
                            )

                    },
                    bulletPointScenario: "generic"
                );

        public static JobPosting Shared_JobPage02_JobPosting02
            = new JobPosting(
                    runId: Shared_FakeRunId,
                    pageNumber: 2,
                    response: "{\r\n            \"AutomatchType\": 0,\r\n            \"Abroad\": false,\r\n            \"Weight\": 1.0,\r\n            \"Title\": \"carpenter\",\r\n            \"JobHeadline\": \"carpenter\",\r\n            \"Presentation\": \"\",\r\n            \"HiringOrgName\": \"Lokal Boligservice ApS\",\r\n            \"WorkPlaceAddress\": \"\",\r\n            \"WorkPlacePostalCode\": \"\",\r\n            \"WorkPlaceCity\": \"\",\r\n            \"WorkPlaceOtherAddress\": false,\r\n            \"WorkPlaceAbroad\": false,\r\n            \"WorkPlaceNotStatic\": true,\r\n            \"UseWorkPlaceAddressForJoblog\": false,\r\n            \"PostingCreated\": \"2021-07-02T00:00:00\",\r\n            \"LastDateApplication\": \"2021-08-27T00:00:00\",\r\n            \"FormattedLastDateApplication\": \"27. august 2021\",\r\n            \"AssignmentStartDate\": \"0001-01-01T00:00:00\",\r\n            \"IsHotjob\": false,\r\n            \"IsExternal\": false,\r\n            \"Url\": \"https://job.jobnet.dk/CV/FindWork/Details/5316797\",\r\n            \"Region\": \"\",\r\n            \"Municipality\": \"\",\r\n            \"Country\": \"Danmark\",\r\n            \"PostalCode\": \"2800\",\r\n            \"PostalCodeName\": null,\r\n            \"JobAnnouncementType\": \"\",\r\n            \"EmploymentType\": \"\",\r\n            \"WorkHours\": \"Fuldtid\",\r\n            \"OccupationArea\": \"\",\r\n            \"OccupationGroup\": \"\",\r\n            \"Occupation\": \"Tømrer\",\r\n            \"Location\": {\r\n                \"Latitude\": 55.7857,\r\n                \"Longitude\": 12.5208\r\n            },\r\n            \"JoblogWorkTime\": {\r\n                \"WorkHour\": null,\r\n                \"DailyWorkTime\": \"Dag\"\r\n            },\r\n            \"WorkplaceID\": 138690,\r\n            \"OrganisationId\": \"121402\",\r\n            \"HiringOrgCVR\": 41075899,\r\n            \"UserLoggedIn\": false,\r\n            \"AnonymousEmployer\": false,\r\n            \"ShareUrl\": \"https://job.jobnet.dk/CV/FindWork/DetailsSocialmedia/5316797\",\r\n            \"DetailsUrl\": \"https://job.jobnet.dk/CV/FindWork/DetailsWidk/5316797\",\r\n            \"JobLogUrl\": \"https://job.jobnet.dk/CV/FindWork/Details/5316797\",\r\n            \"HasLocationValues\": true,\r\n            \"ID\": \"5316797\",\r\n            \"Latitude\": 55.7857,\r\n            \"Longitude\": 12.5208\r\n        }",
                    title: "carpenter",
                    presentation: "",
                    hiringOrgName: "Lokal Boligservice ApS",
                    workPlaceAddress: "",
                    workPlacePostalCode: null,
                    workPlaceCity: "",
                    postingCreated: new DateTime(2021, 07, 02),
                    lastDateApplication: new DateTime(2021, 08, 27),
                    url: "https://job.jobnet.dk/CV/FindWork/Details/5316797",
                    region: "",
                    municipality: "",
                    country: "Danmark",
                    employmentType: "",
                    workHours: "Fuldtid",
                    occupation: "Tømrer",
                    workplaceId: 138690,
                    organisationId: 121402,
                    hiringOrgCVR: 41075899,
                    id: 5316797,
                    workPlaceCityWithoutZone: "",
                    jobPostingNumber: 2,
                    jobPostingId: "5316797carpenter",
                    language: null
                );
        public static JobPostingExtended Shared_JobPage02_JobPostingExtended02
            = new JobPostingExtended(
                    jobPosting: Shared_JobPage02_JobPosting02,
                    response: Shared_FakeResponse,                      // Ignored
                    hiringOrgDescription: null,
                    publicationStartDate: new DateTime(2021, 07, 02),
                    publicationEndDate: new DateTime(2021, 08, 27),
                    purpose: Shared_FakePurpose,                        // Ignored
                    numberToFill: 1,
                    contactEmail: "kontakt@lokalboligservice.dk",
                    contactPersonName: "Emil Bertelsen",
                    employmentDate: null,
                    applicationDeadlineDate: new DateTime(2021, 08, 27),
                    bulletPoints: null,
                    bulletPointScenario: null
                );

        public static JobPosting Shared_JobPage02_JobPosting03
            = new JobPosting(
                    runId: Shared_FakeRunId,
                    pageNumber: 2,
                    response: "{\r\n            \"AutomatchType\": 0,\r\n            \"Abroad\": false,\r\n            \"Weight\": 1.0,\r\n            \"Title\": \"Solution Architect\",\r\n            \"JobHeadline\": \"Solution Architect\",\r\n            \"Presentation\": \" \",\r\n            \"HiringOrgName\": \"Plecto ApS\",\r\n            \"WorkPlaceAddress\": \"Viby Ringvej 11\",\r\n            \"WorkPlacePostalCode\": \"8260\",\r\n            \"WorkPlaceCity\": \"Viby J\",\r\n            \"WorkPlaceOtherAddress\": false,\r\n            \"WorkPlaceAbroad\": false,\r\n            \"WorkPlaceNotStatic\": false,\r\n            \"UseWorkPlaceAddressForJoblog\": true,\r\n            \"PostingCreated\": \"2021-07-02T00:00:00\",\r\n            \"LastDateApplication\": \"2021-08-27T00:00:00\",\r\n            \"FormattedLastDateApplication\": \"27. august 2021\",\r\n            \"AssignmentStartDate\": \"0001-01-01T00:00:00\",\r\n            \"IsHotjob\": false,\r\n            \"IsExternal\": false,\r\n            \"Url\": \"https://job.jobnet.dk/CV/FindWork/Details/5382367\",\r\n            \"Region\": \"Midtjylland\",\r\n            \"Municipality\": \"Aarhus\",\r\n            \"Country\": \"Danmark\",\r\n            \"PostalCode\": \"8260\",\r\n            \"PostalCodeName\": null,\r\n            \"JobAnnouncementType\": \"\",\r\n            \"EmploymentType\": \"\",\r\n            \"WorkHours\": \"Fuldtid\",\r\n            \"OccupationArea\": \"\",\r\n            \"OccupationGroup\": \"\",\r\n            \"Occupation\": \"Kundeservicemedarbejder\",\r\n            \"Location\": {\r\n                \"Latitude\": 56.1288,\r\n                \"Longitude\": 10.161\r\n            },\r\n            \"JoblogWorkTime\": {\r\n                \"WorkHour\": null,\r\n                \"DailyWorkTime\": null\r\n            },\r\n            \"WorkplaceID\": 107348,\r\n            \"OrganisationId\": \"96927\",\r\n            \"HiringOrgCVR\": 34737460,\r\n            \"UserLoggedIn\": false,\r\n            \"AnonymousEmployer\": false,\r\n            \"ShareUrl\": \"https://job.jobnet.dk/CV/FindWork/DetailsSocialmedia/5382367\",\r\n            \"DetailsUrl\": \"https://job.jobnet.dk/CV/FindWork/DetailsWidk/5382367\",\r\n            \"JobLogUrl\": \"https://job.jobnet.dk/CV/FindWork/Details/5382367\",\r\n            \"HasLocationValues\": true,\r\n            \"ID\": \"5382367\",\r\n            \"Latitude\": 56.1288,\r\n            \"Longitude\": 10.161\r\n        }",
                    title: "Solution Architect",
                    presentation: " ",
                    hiringOrgName: "Plecto ApS",
                    workPlaceAddress: "Viby Ringvej 11",
                    workPlacePostalCode: 8260,
                    workPlaceCity: "Viby J",
                    postingCreated: new DateTime(2021, 07, 02),
                    lastDateApplication: new DateTime(2021, 08, 27),
                    url: "https://job.jobnet.dk/CV/FindWork/Details/5382367",
                    region: "Midtjylland",
                    municipality: "Aarhus",
                    country: "Danmark",
                    employmentType: "",
                    workHours: "Fuldtid",
                    occupation: "Kundeservicemedarbejder",
                    workplaceId: 107348,
                    organisationId: 96927,
                    hiringOrgCVR: 34737460,
                    id: 5382367,
                    workPlaceCityWithoutZone: "Viby",
                    jobPostingNumber: 3,
                    jobPostingId: "5382367solutionarchitect",
                    language: null
                );
        public static JobPostingExtended Shared_JobPage02_JobPostingExtended03
            = new JobPostingExtended(
                    jobPosting: Shared_JobPage02_JobPosting03,
                    response: Shared_FakeResponse,                      // Ignored
                    hiringOrgDescription: null,
                    publicationStartDate: new DateTime(2021, 07, 02),
                    publicationEndDate: new DateTime(2021, 08, 27),
                    purpose: Shared_FakePurpose,                        // Ignored
                    numberToFill: 1,
                    contactEmail: "justyna@plecto.com",
                    contactPersonName: "Justyna Płaczkiewicz",
                    employmentDate: null,
                    applicationDeadlineDate: new DateTime(2021, 08, 27),
                    bulletPoints: new List<BulletPoint>()
                    {

                        new BulletPoint(
                            text: "Join and hold meetings with prospects and customers to assist with any questions related to SQL, API or Plecto in general",
                            type: null
                            ),
                        new BulletPoint(
                            text: "Handle complex support cases and customer queries  in a timely and efficient manner",
                            type: null
                            ),
                        new BulletPoint(
                            text: "Guide customers and prospects on best practices in using Plecto",
                            type: null
                            ),
                        new BulletPoint(
                            text: "Assist customers in setting up their Plecto account",
                            type: null
                            ),
                        new BulletPoint(
                            text: "Assist in initial integration research",
                            type: null
                            ),
                        new BulletPoint(
                            text: "Reading technical API documentation - JSON, REST and OAuth",
                            type: null
                            ),
                        new BulletPoint(
                            text: "Solve customer problems under complex constraints and come up with solutions without any additional development of Plecto",
                            type: null
                            ),
                        new BulletPoint(
                            text: "Maintaining and creating internal knowledge base articles",
                            type: null
                            ),
                        new BulletPoint(
                            text: "Experience in delivering outstanding technical support",
                            type: null
                            ),
                        new BulletPoint(
                            text: "Experience in database operations including reading and writing basic to intermediate database SQL queries and troubleshooting connection issues",
                            type: null
                            ),
                        new BulletPoint(
                            text: "Experience and knowledge in API and SQL Server Databases",
                            type: null
                            ),
                        new BulletPoint(
                            text: "Interest and knowledge in other programming languages is a plus, but not a requirement",
                            type: null
                            ),
                        new BulletPoint(
                            text: "Ability to effectively communicate technical concepts to a variety of audiences with different levels of technical expertise",
                            type: null
                            ),
                        new BulletPoint(
                            text: "Multi-tasking and time-management to prioritize and switch between varied tasks",
                            type: null
                            ),
                        new BulletPoint(
                            text: "Technical writing skills to create and maintain Knowledge Base articles",
                            type: null
                            ),
                        new BulletPoint(
                            text: "Technical skills and an eye for detail used in troubleshooting and implementing fixes",
                            type: null
                            ),
                        new BulletPoint(
                            text: "You are fluent in English, both spoken and written + another additional language. Danish is a plus, but not a requirement",
                            type: null
                            )

                    },
                    bulletPointScenario: "generic"
                );

        public static JobPosting Shared_JobPage02_JobPosting04
            = new JobPosting(
                    runId: Shared_FakeRunId,
                    pageNumber: 2,
                    response: "{\r\n            \"AutomatchType\": 0,\r\n            \"Abroad\": false,\r\n            \"Weight\": 1.0,\r\n            \"Title\": \"Project Officer - Impact Assessment and Adaptation Analysis\",\r\n            \"JobHeadline\": \"Project Officer - Impact Assessment and Adaptation Analysis\",\r\n            \"Presentation\": \"<br>\\n UNEP DTU Partnership (UDP) is a leading international research and advisory institution on energy, climate and sustainable development. UDP is part of the Department for Technology, Management \",\r\n            \"HiringOrgName\": \"Danmarks Tekniske Universitet\",\r\n            \"WorkPlaceAddress\": \"Anker Engelunds Vej 101\",\r\n            \"WorkPlacePostalCode\": \"2800\",\r\n            \"WorkPlaceCity\": \"Kongens Lyngby\",\r\n            \"WorkPlaceOtherAddress\": false,\r\n            \"WorkPlaceAbroad\": false,\r\n            \"WorkPlaceNotStatic\": false,\r\n            \"UseWorkPlaceAddressForJoblog\": true,\r\n            \"PostingCreated\": \"2021-07-02T00:00:00\",\r\n            \"LastDateApplication\": \"2021-07-16T00:00:00\",\r\n            \"FormattedLastDateApplication\": \"16. juli 2021\",\r\n            \"AssignmentStartDate\": \"0001-01-01T00:00:00\",\r\n            \"IsHotjob\": false,\r\n            \"IsExternal\": false,\r\n            \"Url\": \"https://job.jobnet.dk/CV/FindWork/Details/5382358\",\r\n            \"Region\": \"Hovedstaden og Bornholm\",\r\n            \"Municipality\": \"Gladsaxe\",\r\n            \"Country\": \"Danmark\",\r\n            \"PostalCode\": \"2800\",\r\n            \"PostalCodeName\": null,\r\n            \"JobAnnouncementType\": \"\",\r\n            \"EmploymentType\": \"\",\r\n            \"WorkHours\": \"Fuldtid\",\r\n            \"OccupationArea\": \"\",\r\n            \"OccupationGroup\": \"\",\r\n            \"Occupation\": \"Miljøingeniør\",\r\n            \"Location\": {\r\n                \"Latitude\": 55.7859,\r\n                \"Longitude\": 12.5241\r\n            },\r\n            \"JoblogWorkTime\": {\r\n                \"WorkHour\": null,\r\n                \"DailyWorkTime\": null\r\n            },\r\n            \"WorkplaceID\": 83955,\r\n            \"OrganisationId\": \"66175\",\r\n            \"HiringOrgCVR\": 30060946,\r\n            \"UserLoggedIn\": false,\r\n            \"AnonymousEmployer\": false,\r\n            \"ShareUrl\": \"https://job.jobnet.dk/CV/FindWork/DetailsSocialmedia/5382358\",\r\n            \"DetailsUrl\": \"https://job.jobnet.dk/CV/FindWork/DetailsWidk/5382358\",\r\n            \"JobLogUrl\": \"https://job.jobnet.dk/CV/FindWork/Details/5382358\",\r\n            \"HasLocationValues\": true,\r\n            \"ID\": \"5382358\",\r\n            \"Latitude\": 55.7859,\r\n            \"Longitude\": 12.5241\r\n        }",
                    title: "Project Officer - Impact Assessment and Adaptation Analysis",
                    presentation: "<br>\n UNEP DTU Partnership (UDP) is a leading international research and advisory institution on energy, climate and sustainable development. UDP is part of the Department for Technology, Management ",
                    hiringOrgName: "Danmarks Tekniske Universitet",
                    workPlaceAddress: "Anker Engelunds Vej 101",
                    workPlacePostalCode: 2800,
                    workPlaceCity: "Kongens Lyngby",
                    postingCreated: new DateTime(2021, 07, 02),
                    lastDateApplication: new DateTime(2021, 07, 16),
                    url: "https://job.jobnet.dk/CV/FindWork/Details/5382358",
                    region: "Hovedstaden og Bornholm",
                    municipality: "Gladsaxe",
                    country: "Danmark",
                    employmentType: "",
                    workHours: "Fuldtid",
                    occupation: "Miljøingeniør",
                    workplaceId: 83955,
                    organisationId: 66175,
                    hiringOrgCVR: 30060946,
                    id: 5382358,
                    workPlaceCityWithoutZone: "Kongens Lyngby",
                    jobPostingNumber: 4,
                    jobPostingId: "5382358projectofficerimpactassessmentand",
                    language: "en"
                );
        public static JobPostingExtended Shared_JobPage02_JobPostingExtended04
            = new JobPostingExtended(
                    jobPosting: Shared_JobPage02_JobPosting04,
                    response: Shared_FakeResponse,                      // Ignored
                    hiringOrgDescription: null,
                    publicationStartDate: new DateTime(2021, 07, 02),
                    publicationEndDate: new DateTime(2021, 07, 16),
                    purpose: Shared_FakePurpose,                        // Ignored
                    numberToFill: 1,
                    contactEmail: null,
                    contactPersonName: "Henry Neufeldt",
                    employmentDate: null,
                    applicationDeadlineDate: new DateTime(2021, 07, 16),
                    bulletPoints: new List<BulletPoint>()
                    {

                        new BulletPoint(
                            text: "Lead the development of tools and guidance materials within adaptation assessment, tracking and transparency.",
                            type: null
                            ),
                        new BulletPoint(
                            text: "Support the production of UNEP's Adaptation Gap Report;",
                            type: null
                            ),
                        new BulletPoint(
                            text: "Contribute to the section's work on private sector adaptation, and adaptation business models.",
                            type: null
                            ),
                        new BulletPoint(
                            text: "Contribute to the section's work on impact assessments of mitigation and adaptation actions and their contribution to sustainable development;",
                            type: null
                            ),
                        new BulletPoint(
                            text: "Contribute to the section's work on adaptation finance tracking;",
                            type: null
                            ),
                        new BulletPoint(
                            text: "Contribute to the development of scientific papers, briefs, and reports;",
                            type: null
                            ),
                        new BulletPoint(
                            text: "Other tasks as assigned by the head of section.",
                            type: null
                            ),
                        new BulletPoint(
                            text: "M.Sc. degree in environmental science, environmental engineering, sustainability studies, environmental economics, or other relevant field;",
                            type: null
                            ),
                        new BulletPoint(
                            text: "Understanding of the Paris Agreement, in particular of the Enhanced Transparency Framework;",
                            type: null
                            ),
                        new BulletPoint(
                            text: "Good knowledge of methods and approaches for adaptation assessment and tracking at aggregated levels (i.e. national and global-levels)",
                            type: null
                            ),
                        new BulletPoint(
                            text: "Good knowledge of the adaptation finance landscape, and methods and approaches for tracking adaptation finance",
                            type: null
                            ),
                        new BulletPoint(
                            text: "Good knowledge of the Sustainable Development Goal framework, including of the SDG targets and indicators, particularly in the context of impact assessment;",
                            type: null
                            ),
                        new BulletPoint(
                            text: "Good knowledge of private sector adaptation is an asset;",
                            type: null
                            ),
                        new BulletPoint(
                            text: "Strong analytical skills, an innovative mindset, and the ability to adapt to different tasks and workloads quickly and effectively;",
                            type: null
                            ),
                        new BulletPoint(
                            text: "Demonstrated excellent writing, communication, and presentation skills in English; proficiency in other languages, in particular Spanish and/or French is an asset",
                            type: null
                            ),
                        new BulletPoint(
                            text: "Ability to work effectively both individually as well as in teams, with people from different academic and cultural backgrounds;",
                            type: null
                            ),
                        new BulletPoint(
                            text: "Experience in preparing technical and/or policy-relevant reports and papers is considered a strong asset;",
                            type: null
                            ),
                        new BulletPoint(
                            text: "Experience in working with developing countries is an asset;",
                            type: null
                            ),
                        new BulletPoint(
                            text: "Application letter;",
                            type: null
                            ),
                        new BulletPoint(
                            text: "CV with full personal data and contact details;",
                            type: null
                            ),
                        new BulletPoint(
                            text: "Indication of three references; and,",
                            type: null
                            ),
                        new BulletPoint(
                            text: "A copy of your diploma(s)",
                            type: null
                            )

                    },
                    bulletPointScenario: "generic"
                );

        public static JobPosting Shared_JobPage02_JobPosting05
            = new JobPosting(
                    runId: Shared_FakeRunId,
                    pageNumber: 2,
                    response: "{\r\n            \"AutomatchType\": 0,\r\n            \"Abroad\": false,\r\n            \"Weight\": 1.0,\r\n            \"Title\": \"Warehouse workers\",\r\n            \"JobHeadline\": \"Warehouse workers\",\r\n            \"Presentation\": \"<p>For our client in Middelfart, we are looking for warehouse workers to empty containers daily - Monday to Friday from 8 AM to 4 PM.</p>\\n\",\r\n            \"HiringOrgName\": \"RANDSTAD A/S\",\r\n            \"WorkPlaceAddress\": \"\",\r\n            \"WorkPlacePostalCode\": \"5500\",\r\n            \"WorkPlaceCity\": \"Middelfart\",\r\n            \"WorkPlaceOtherAddress\": true,\r\n            \"WorkPlaceAbroad\": false,\r\n            \"WorkPlaceNotStatic\": false,\r\n            \"UseWorkPlaceAddressForJoblog\": false,\r\n            \"PostingCreated\": \"2021-07-02T00:00:00\",\r\n            \"LastDateApplication\": \"2021-08-27T00:00:00\",\r\n            \"FormattedLastDateApplication\": \"27. august 2021\",\r\n            \"AssignmentStartDate\": \"0001-01-01T00:00:00\",\r\n            \"IsHotjob\": false,\r\n            \"IsExternal\": false,\r\n            \"Url\": \"https://job.jobnet.dk/CV/FindWork/Details/5382226\",\r\n            \"Region\": \"Syddanmark\",\r\n            \"Municipality\": \"Middelfart\",\r\n            \"Country\": \"Danmark\",\r\n            \"PostalCode\": \"5500\",\r\n            \"PostalCodeName\": null,\r\n            \"JobAnnouncementType\": \"\",\r\n            \"EmploymentType\": \"\",\r\n            \"WorkHours\": \"Fuldtid\",\r\n            \"OccupationArea\": \"\",\r\n            \"OccupationGroup\": \"\",\r\n            \"Occupation\": \"Lager- og logistikmedarbejder\",\r\n            \"Location\": {\r\n                \"Latitude\": 55.4893,\r\n                \"Longitude\": 9.7849\r\n            },\r\n            \"JoblogWorkTime\": {\r\n                \"WorkHour\": null,\r\n                \"DailyWorkTime\": \"Dag\"\r\n            },\r\n            \"WorkplaceID\": 120191,\r\n            \"OrganisationId\": \"106608\",\r\n            \"HiringOrgCVR\": 25050541,\r\n            \"UserLoggedIn\": false,\r\n            \"AnonymousEmployer\": false,\r\n            \"ShareUrl\": \"https://job.jobnet.dk/CV/FindWork/DetailsSocialmedia/5382226\",\r\n            \"DetailsUrl\": \"https://job.jobnet.dk/CV/FindWork/DetailsWidk/5382226\",\r\n            \"JobLogUrl\": \"https://job.jobnet.dk/CV/FindWork/Details/5382226\",\r\n            \"HasLocationValues\": true,\r\n            \"ID\": \"5382226\",\r\n            \"Latitude\": 55.4893,\r\n            \"Longitude\": 9.7849\r\n        }",
                    title: "Warehouse workers",
                    presentation: "<p>For our client in Middelfart, we are looking for warehouse workers to empty containers daily - Monday to Friday from 8 AM to 4 PM.</p>\n",
                    hiringOrgName: "RANDSTAD A/S",
                    workPlaceAddress: "",
                    workPlacePostalCode: 5500,
                    workPlaceCity: "Middelfart",
                    postingCreated: new DateTime(2021, 07, 02),
                    lastDateApplication: new DateTime(2021, 08, 27),
                    url: "https://job.jobnet.dk/CV/FindWork/Details/5382226",
                    region: "Syddanmark",
                    municipality: "Middelfart",
                    country: "Danmark",
                    employmentType: "",
                    workHours: "Fuldtid",
                    occupation: "Lager- og logistikmedarbejder",
                    workplaceId: 120191,
                    organisationId: 106608,
                    hiringOrgCVR: 25050541,
                    id: 5382226,
                    workPlaceCityWithoutZone: "Middelfart",
                    jobPostingNumber: 5,
                    jobPostingId: "5382226warehouseworkers",
                    language: "dk/en" // To-do: this prediction must be improved (ClassificationManager).
                );
        public static JobPostingExtended Shared_JobPage02_JobPostingExtended05
            = new JobPostingExtended(
                    jobPosting: Shared_JobPage02_JobPosting05,
                    response: Shared_FakeResponse,                      // Ignored
                    hiringOrgDescription: "Randstad er en del af den internationale Randstad Group, der er verdens andenstørste udbyder af HR-løsninger. Hver dag formidler Randstad arbejde til mere end 500.000 mennesker i hele verden. I Danmark er vi blandt de førende vikar- og rekrutteringsbureauer med fire afdelinger fordelt over hele landet. En position vi har opnået, fordi vi som eksperter på arbejdsmarkedet formår at matche kvalificerede kandidater med de rette jobmuligheder.",
                    publicationStartDate: new DateTime(2021, 07, 02),
                    publicationEndDate: new DateTime(2021, 08, 27),
                    purpose: Shared_FakePurpose,                        // Ignored
                    numberToFill: 2,
                    contactEmail: "claus.kjaerbo@randstad.dk",
                    contactPersonName: "Claus Kjærbo",
                    employmentDate: null,
                    applicationDeadlineDate: new DateTime(2021, 08, 27),
                    bulletPoints: new List<BulletPoint>()
                    {

                        new BulletPoint(
                            text: "You speak English or Danish",
                            type: null
                            ),
                        new BulletPoint(
                            text: "You are interested in working in a warehouse",
                            type: null
                            ),
                        new BulletPoint(
                            text: "You have a pair of safety shoes",
                            type: null
                            )

                    },
                    bulletPointScenario: "generic"
                );

        public static JobPosting Shared_JobPage02_JobPosting06
            = new JobPosting(
                    runId: Shared_FakeRunId,
                    pageNumber: 2,
                    response: "{\r\n            \"AutomatchType\": 0,\r\n            \"Abroad\": false,\r\n            \"Weight\": 1.0,\r\n            \"Title\": \"Cleaning / Housekeeping\",\r\n            \"JobHeadline\": \"Cleaning / Housekeeping\",\r\n            \"Presentation\": \"   Are you the new fantastic employee at BH HotelService?    \u00A0\u00A0\u00A0\u00A0\u00A0\u00A0\u00A0\u00A0\u00A0\u00A0\u00A0\u00A0\u00A0\u00A0\u00A0\u00A0\u00A0\u00A0\u00A0\u00A0\u00A0\u00A0\u00A0\u00A0\u00A0\u00A0\u00A0\u00A0\u00A0\u00A0\u00A0\u00A0\u00A0     \u00A0\u00A0\u00A0\u00A0\u00A0\u00A0\u00A0\u00A0\u00A0\u00A0\u00A0\u00A0\u00A0\u00A0\u00A0\u00A0\u00A0\u00A0\u00A0\u00A0\u00A0\u00A0\u00A0\u00A0\u00A0\u00A0\u00A0\u00A0\u00A0\u00A0\u00A0\u00A0\u00A0\u00A0\u00A0\u00A0\u00A0\u00A0\u00A0\u00A0\u00A0\u00A0 \",\r\n            \"HiringOrgName\": \"BH HotelService ApS\",\r\n            \"WorkPlaceAddress\": \"Amagerbrogade 44, 1. tv.\",\r\n            \"WorkPlacePostalCode\": \"2300\",\r\n            \"WorkPlaceCity\": \"København S\",\r\n            \"WorkPlaceOtherAddress\": false,\r\n            \"WorkPlaceAbroad\": false,\r\n            \"WorkPlaceNotStatic\": false,\r\n            \"UseWorkPlaceAddressForJoblog\": true,\r\n            \"PostingCreated\": \"2021-07-02T00:00:00\",\r\n            \"LastDateApplication\": \"2021-07-30T00:00:00\",\r\n            \"FormattedLastDateApplication\": \"30. juli 2021\",\r\n            \"AssignmentStartDate\": \"0001-01-01T00:00:00\",\r\n            \"IsHotjob\": false,\r\n            \"IsExternal\": false,\r\n            \"Url\": \"https://job.jobnet.dk/CV/FindWork/Details/5339477\",\r\n            \"Region\": \"Hovedstaden og Bornholm\",\r\n            \"Municipality\": \"København\",\r\n            \"Country\": \"Danmark\",\r\n            \"PostalCode\": \"2300\",\r\n            \"PostalCodeName\": null,\r\n            \"JobAnnouncementType\": \"\",\r\n            \"EmploymentType\": \"\",\r\n            \"WorkHours\": \"Deltid\",\r\n            \"OccupationArea\": \"\",\r\n            \"OccupationGroup\": \"\",\r\n            \"Occupation\": \"Rengøringsassistent, hotel\",\r\n            \"Location\": {\r\n                \"Latitude\": 55.6636,\r\n                \"Longitude\": 12.601\r\n            },\r\n            \"JoblogWorkTime\": {\r\n                \"WorkHour\": \"(20 - 30 timer ugentligt)\",\r\n                \"DailyWorkTime\": \"Dag, weekend\"\r\n            },\r\n            \"WorkplaceID\": 84451,\r\n            \"OrganisationId\": \"78371\",\r\n            \"HiringOrgCVR\": 32286550,\r\n            \"UserLoggedIn\": false,\r\n            \"AnonymousEmployer\": false,\r\n            \"ShareUrl\": \"https://job.jobnet.dk/CV/FindWork/DetailsSocialmedia/5339477\",\r\n            \"DetailsUrl\": \"https://job.jobnet.dk/CV/FindWork/DetailsWidk/5339477\",\r\n            \"JobLogUrl\": \"https://job.jobnet.dk/CV/FindWork/Details/5339477\",\r\n            \"HasLocationValues\": true,\r\n            \"ID\": \"5339477\",\r\n            \"Latitude\": 55.6636,\r\n            \"Longitude\": 12.601\r\n        }",
                    title: "Cleaning / Housekeeping",
                    presentation: "   Are you the new fantastic employee at BH HotelService?    \u00A0\u00A0\u00A0\u00A0\u00A0\u00A0\u00A0\u00A0\u00A0\u00A0\u00A0\u00A0\u00A0\u00A0\u00A0\u00A0\u00A0\u00A0\u00A0\u00A0\u00A0\u00A0\u00A0\u00A0\u00A0\u00A0\u00A0\u00A0\u00A0\u00A0\u00A0\u00A0\u00A0     \u00A0\u00A0\u00A0\u00A0\u00A0\u00A0\u00A0\u00A0\u00A0\u00A0\u00A0\u00A0\u00A0\u00A0\u00A0\u00A0\u00A0\u00A0\u00A0\u00A0\u00A0\u00A0\u00A0\u00A0\u00A0\u00A0\u00A0\u00A0\u00A0\u00A0\u00A0\u00A0\u00A0\u00A0\u00A0\u00A0\u00A0\u00A0\u00A0\u00A0\u00A0\u00A0 ",
                    hiringOrgName: "BH HotelService ApS",
                    workPlaceAddress: "Amagerbrogade 44, 1. tv.",
                    workPlacePostalCode: 2300,
                    workPlaceCity: "København S",
                    postingCreated: new DateTime(2021, 07, 02),
                    lastDateApplication: new DateTime(2021, 07, 30),
                    url: "https://job.jobnet.dk/CV/FindWork/Details/5339477",
                    region: "Hovedstaden og Bornholm",
                    municipality: "København",
                    country: "Danmark",
                    employmentType: "",
                    workHours: "Deltid",
                    occupation: "Rengøringsassistent, hotel",
                    workplaceId: 84451,
                    organisationId: 78371,
                    hiringOrgCVR: 32286550,
                    id: 5339477,
                    workPlaceCityWithoutZone: "København",
                    jobPostingNumber: 6,
                    jobPostingId: "5339477cleaninghousekeeping",
                    language: "en"
                );
        public static JobPostingExtended Shared_JobPage02_JobPostingExtended06
            = new JobPostingExtended(
                    jobPosting: Shared_JobPage02_JobPosting06,
                    response: Shared_FakeResponse,                      // Ignored
                    hiringOrgDescription: null,
                    publicationStartDate: new DateTime(2021, 07, 02),
                    publicationEndDate: new DateTime(2021, 07, 30),
                    purpose: Shared_FakePurpose,                        // Ignored
                    numberToFill: 20,
                    contactEmail: "anja@bh-hotelservice.dk",
                    contactPersonName: "Anja Løvhøj",
                    employmentDate: null,
                    applicationDeadlineDate: new DateTime(2021, 07, 30),
                    bulletPoints: new List<BulletPoint>()
                    {

                        new BulletPoint(
                            text: "you get to clean the finest hotel rooms in Copenhagen",
                            type: null
                            ),
                        new BulletPoint(
                            text: "you are guaranteed a minimum of 80-130 hours per month with the possibility to work more (depending on your situation)",
                            type: null
                            ),
                        new BulletPoint(
                            text: "we offer career opportunities through promotions and/or management classes",
                            type: null
                            ),
                        new BulletPoint(
                            text: "we offer health insurance after 6 months of employment",
                            type: null
                            ),
                        new BulletPoint(
                            text: "Salary according to the collective bargaining agreement",
                            type: null
                            ),
                        new BulletPoint(
                            text: "Speaking English",
                            type: null
                            ),
                        new BulletPoint(
                            text: "Service minded",
                            type: null
                            ),
                        new BulletPoint(
                            text: "Ready to work primarily in the daytime on weekdays and/or weekends",
                            type: null
                            ),
                        new BulletPoint(
                            text: "Able to work in weekends as well",
                            type: null
                            ),
                        new BulletPoint(
                            text: "Ready to work in a fast and exiting environment",
                            type: null
                            ),
                        new BulletPoint(
                            text: "Definitely the one we are looking for!",
                            type: null
                            )

                    },
                    bulletPointScenario: "generic"
                );

        public static JobPosting Shared_JobPage02_JobPosting07
            = new JobPosting(
                    runId: Shared_FakeRunId,
                    pageNumber: 2,
                    response: "{\r\n            \"AutomatchType\": 0,\r\n            \"Abroad\": false,\r\n            \"Weight\": 1.0,\r\n            \"Title\": \"B2B Sales Specialist\",\r\n            \"JobHeadline\": \"B2B Sales Specialist\",\r\n            \"Presentation\": \" \",\r\n            \"HiringOrgName\": \"Plecto ApS\",\r\n            \"WorkPlaceAddress\": \"Viby Ringvej 11\",\r\n            \"WorkPlacePostalCode\": \"8260\",\r\n            \"WorkPlaceCity\": \"Viby J\",\r\n            \"WorkPlaceOtherAddress\": false,\r\n            \"WorkPlaceAbroad\": false,\r\n            \"WorkPlaceNotStatic\": false,\r\n            \"UseWorkPlaceAddressForJoblog\": true,\r\n            \"PostingCreated\": \"2021-07-02T00:00:00\",\r\n            \"LastDateApplication\": \"2021-07-30T00:00:00\",\r\n            \"FormattedLastDateApplication\": \"30. juli 2021\",\r\n            \"AssignmentStartDate\": \"0001-01-01T00:00:00\",\r\n            \"IsHotjob\": false,\r\n            \"IsExternal\": false,\r\n            \"Url\": \"https://job.jobnet.dk/CV/FindWork/Details/5345782\",\r\n            \"Region\": \"Midtjylland\",\r\n            \"Municipality\": \"Aarhus\",\r\n            \"Country\": \"Danmark\",\r\n            \"PostalCode\": \"8260\",\r\n            \"PostalCodeName\": null,\r\n            \"JobAnnouncementType\": \"\",\r\n            \"EmploymentType\": \"\",\r\n            \"WorkHours\": \"Fuldtid\",\r\n            \"OccupationArea\": \"\",\r\n            \"OccupationGroup\": \"\",\r\n            \"Occupation\": \"Salgskonsulent\",\r\n            \"Location\": {\r\n                \"Latitude\": 56.1288,\r\n                \"Longitude\": 10.161\r\n            },\r\n            \"JoblogWorkTime\": {\r\n                \"WorkHour\": null,\r\n                \"DailyWorkTime\": null\r\n            },\r\n            \"WorkplaceID\": 107348,\r\n            \"OrganisationId\": \"96927\",\r\n            \"HiringOrgCVR\": 34737460,\r\n            \"UserLoggedIn\": false,\r\n            \"AnonymousEmployer\": false,\r\n            \"ShareUrl\": \"https://job.jobnet.dk/CV/FindWork/DetailsSocialmedia/5345782\",\r\n            \"DetailsUrl\": \"https://job.jobnet.dk/CV/FindWork/DetailsWidk/5345782\",\r\n            \"JobLogUrl\": \"https://job.jobnet.dk/CV/FindWork/Details/5345782\",\r\n            \"HasLocationValues\": true,\r\n            \"ID\": \"5345782\",\r\n            \"Latitude\": 56.1288,\r\n            \"Longitude\": 10.161\r\n        }",
                    title: "B2B Sales Specialist",
                    presentation: " ",
                    hiringOrgName: "Plecto ApS",
                    workPlaceAddress: "Viby Ringvej 11",
                    workPlacePostalCode: 8260,
                    workPlaceCity: "Viby J",
                    postingCreated: new DateTime(2021, 07, 02),
                    lastDateApplication: new DateTime(2021, 07, 30),
                    url: "https://job.jobnet.dk/CV/FindWork/Details/5345782",
                    region: "Midtjylland",
                    municipality: "Aarhus",
                    country: "Danmark",
                    employmentType: "",
                    workHours: "Fuldtid",
                    occupation: "Salgskonsulent",
                    workplaceId: 107348,
                    organisationId: 96927,
                    hiringOrgCVR: 34737460,
                    id: 5345782,
                    workPlaceCityWithoutZone: "Viby",
                    jobPostingNumber: 7,
                    jobPostingId: "5345782bbsalesspecialist",
                    language: "en"
                );
        public static JobPostingExtended Shared_JobPage02_JobPostingExtended07
            = new JobPostingExtended(
                    jobPosting: Shared_JobPage02_JobPosting07,
                    response: Shared_FakeResponse,                      // Ignored
                    hiringOrgDescription: null,
                    publicationStartDate: new DateTime(2021, 07, 02),
                    publicationEndDate: new DateTime(2021, 07, 30),
                    purpose: Shared_FakePurpose,                        // Ignored
                    numberToFill: 1,
                    contactEmail: "justyna@plecto.com",
                    contactPersonName: "Justyna Płaczkiewicz",
                    employmentDate: null,
                    applicationDeadlineDate: new DateTime(2021, 07, 30),
                    bulletPoints: new List<BulletPoint>()
                    {

                        new BulletPoint(
                            text: "Develop a strong base of customers",
                            type: null
                            ),
                        new BulletPoint(
                            text: "Find leads and potential customers through for example networks and social platforms",
                            type: null
                            ),
                        new BulletPoint(
                            text: "Identify areas where you can expand business with your existing customers",
                            type: null
                            ),
                        new BulletPoint(
                            text: "Negotiate contracts and close deals while clearly predicting your pipeline",
                            type: null
                            ),
                        new BulletPoint(
                            text: "You have excellent skills in both written and oral English",
                            type: null
                            ),
                        new BulletPoint(
                            text: "You have a good business understanding and a structured work approach",
                            type: null
                            ),
                        new BulletPoint(
                            text: "You are a team player with the ability to collaborate across teams",
                            type: null
                            ),
                        new BulletPoint(
                            text: "You are able to identify needs and identify where Plecto can create value for potential customers",
                            type: null
                            ),
                        new BulletPoint(
                            text: "It is an advantage if you have previous experience in the insurance-, telecommunications-, energy- or media industry",
                            type: null
                            ),
                        new BulletPoint(
                            text: "It is an advantage if you have previous experience from B2B and/or sales",
                            type: null
                            ),
                        new BulletPoint(
                            text: "You have a bubbly positive personality that we will love to get to know and work with",
                            type: null
                            )

                    },
                    bulletPointScenario: "generic"
                );

        public static JobPosting Shared_JobPage02_JobPosting08
            = new JobPosting(
                    runId: Shared_FakeRunId,
                    pageNumber: 2,
                    response: "{\r\n            \"AutomatchType\": 0,\r\n            \"Abroad\": false,\r\n            \"Weight\": 1.0,\r\n            \"Title\": \"warwhose worker with in experince using a runner\",\r\n            \"JobHeadline\": \"warwhose worker with in experince using a runner\",\r\n            \"Presentation\": \"<p>10 persons needed for warehouse work in Horsens on both day and evening shift starting as soon as possible until the end of August.</p>\\n<p>\u00A0</p>\\n\",\r\n            \"HiringOrgName\": \"Vikar DK A/S\",\r\n            \"WorkPlaceAddress\": \"Egeskovvej 17\",\r\n            \"WorkPlacePostalCode\": \"8700\",\r\n            \"WorkPlaceCity\": \"Horsens\",\r\n            \"WorkPlaceOtherAddress\": false,\r\n            \"WorkPlaceAbroad\": false,\r\n            \"WorkPlaceNotStatic\": false,\r\n            \"UseWorkPlaceAddressForJoblog\": true,\r\n            \"PostingCreated\": \"2021-07-02T00:00:00\",\r\n            \"LastDateApplication\": \"2021-08-05T00:00:00\",\r\n            \"FormattedLastDateApplication\": \"5. august 2021\",\r\n            \"AssignmentStartDate\": \"0001-01-01T00:00:00\",\r\n            \"IsHotjob\": false,\r\n            \"IsExternal\": false,\r\n            \"Url\": \"https://job.jobnet.dk/CV/FindWork/Details/5366564\",\r\n            \"Region\": \"Midtjylland\",\r\n            \"Municipality\": \"Horsens\",\r\n            \"Country\": \"Danmark\",\r\n            \"PostalCode\": \"8700\",\r\n            \"PostalCodeName\": null,\r\n            \"JobAnnouncementType\": \"\",\r\n            \"EmploymentType\": \"\",\r\n            \"WorkHours\": \"Fuldtid\",\r\n            \"OccupationArea\": \"\",\r\n            \"OccupationGroup\": \"\",\r\n            \"Occupation\": \"Lager- og logistikmedarbejder\",\r\n            \"Location\": {\r\n                \"Latitude\": 55.923,\r\n                \"Longitude\": 9.8219\r\n            },\r\n            \"JoblogWorkTime\": {\r\n                \"WorkHour\": null,\r\n                \"DailyWorkTime\": \"Dag, aften\"\r\n            },\r\n            \"WorkplaceID\": 99015,\r\n            \"OrganisationId\": \"90677\",\r\n            \"HiringOrgCVR\": 34046956,\r\n            \"UserLoggedIn\": false,\r\n            \"AnonymousEmployer\": false,\r\n            \"ShareUrl\": \"https://job.jobnet.dk/CV/FindWork/DetailsSocialmedia/5366564\",\r\n            \"DetailsUrl\": \"https://job.jobnet.dk/CV/FindWork/DetailsWidk/5366564\",\r\n            \"JobLogUrl\": \"https://job.jobnet.dk/CV/FindWork/Details/5366564\",\r\n            \"HasLocationValues\": true,\r\n            \"ID\": \"5366564\",\r\n            \"Latitude\": 55.923,\r\n            \"Longitude\": 9.8219\r\n        }",
                    title: "warwhose worker with in experince using a runner",
                    presentation: "<p>10 persons needed for warehouse work in Horsens on both day and evening shift starting as soon as possible until the end of August.</p>\n<p>\u00A0</p>\n",
                    hiringOrgName: "Vikar DK A/S",
                    workPlaceAddress: "Egeskovvej 17",
                    workPlacePostalCode: 8700,
                    workPlaceCity: "Horsens",
                    postingCreated: new DateTime(2021, 07, 02),
                    lastDateApplication: new DateTime(2021, 08, 05),
                    url: "https://job.jobnet.dk/CV/FindWork/Details/5366564",
                    region: "Midtjylland",
                    municipality: "Horsens",
                    country: "Danmark",
                    employmentType: "",
                    workHours: "Fuldtid",
                    occupation: "Lager- og logistikmedarbejder",
                    workplaceId: 99015,
                    organisationId: 90677,
                    hiringOrgCVR: 34046956,
                    id: 5366564,
                    workPlaceCityWithoutZone: "Horsens",
                    jobPostingNumber: 8,
                    jobPostingId: "5366564warwhoseworkerwithinexperince",
                    language: "dk/en" // To-do: this prediction must be improved (ClassificationManager).
                );
        public static JobPostingExtended Shared_JobPage02_JobPostingExtended08
            = new JobPostingExtended(
                    jobPosting: Shared_JobPage02_JobPosting08,
                    response: Shared_FakeResponse,                      // Ignored
                    hiringOrgDescription: null,
                    publicationStartDate: new DateTime(2021, 07, 02),
                    publicationEndDate: new DateTime(2021, 08, 05),
                    purpose: Shared_FakePurpose,                        // Ignored
                    numberToFill: 10,
                    contactEmail: "bbo@vikardk.dk",
                    contactPersonName: "Bettina Bonde Thygesen",
                    employmentDate: null,
                    applicationDeadlineDate: new DateTime(2021, 08, 05),
                    bulletPoints: null,
                    bulletPointScenario: null
                );

        public static JobPosting Shared_JobPage02_JobPosting09
            = new JobPosting(
                    runId: Shared_FakeRunId,
                    pageNumber: 2,
                    response: "{\r\n            \"AutomatchType\": 0,\r\n            \"Abroad\": false,\r\n            \"Weight\": 1.0,\r\n            \"Title\": \"Tenure Track Assistant Professor in paleoecology, ancient genomics and conservation biology\",\r\n            \"JobHeadline\": \"Tenure Track Assistant Professor in paleoecology, ancient genomics and conservation biology\",\r\n            \"Presentation\": \"The GLOBE Institute at the Faculty of Health and Medical Sciences, University of Copenhagen seeks to appoint a tenure track assistant professor in paleoecology, ancient genomics and conservation biolo\",\r\n            \"HiringOrgName\": \"KU - SCIENCE - SNM\",\r\n            \"WorkPlaceAddress\": \"Øster Voldgade 5-7\",\r\n            \"WorkPlacePostalCode\": \"1350\",\r\n            \"WorkPlaceCity\": \"København K\",\r\n            \"WorkPlaceOtherAddress\": false,\r\n            \"WorkPlaceAbroad\": false,\r\n            \"WorkPlaceNotStatic\": false,\r\n            \"UseWorkPlaceAddressForJoblog\": true,\r\n            \"PostingCreated\": \"2021-07-02T00:00:00\",\r\n            \"LastDateApplication\": \"2021-07-21T00:00:00\",\r\n            \"FormattedLastDateApplication\": \"21. juli 2021\",\r\n            \"AssignmentStartDate\": \"0001-01-01T00:00:00\",\r\n            \"IsHotjob\": false,\r\n            \"IsExternal\": false,\r\n            \"Url\": \"https://job.jobnet.dk/CV/FindWork/Details/5363343\",\r\n            \"Region\": \"Hovedstaden og Bornholm\",\r\n            \"Municipality\": \"København\",\r\n            \"Country\": \"Danmark\",\r\n            \"PostalCode\": \"1350\",\r\n            \"PostalCodeName\": null,\r\n            \"JobAnnouncementType\": \"\",\r\n            \"EmploymentType\": \"\",\r\n            \"WorkHours\": \"Fuldtid\",\r\n            \"OccupationArea\": \"\",\r\n            \"OccupationGroup\": \"\",\r\n            \"Occupation\": \"Adjunkt, sundhedsvidenskab\",\r\n            \"Location\": {\r\n                \"Latitude\": 55.6872,\r\n                \"Longitude\": 12.5772\r\n            },\r\n            \"JoblogWorkTime\": {\r\n                \"WorkHour\": null,\r\n                \"DailyWorkTime\": null\r\n            },\r\n            \"WorkplaceID\": 105129,\r\n            \"OrganisationId\": \"57758\",\r\n            \"HiringOrgCVR\": 29979812,\r\n            \"UserLoggedIn\": false,\r\n            \"AnonymousEmployer\": false,\r\n            \"ShareUrl\": \"https://job.jobnet.dk/CV/FindWork/DetailsSocialmedia/5363343\",\r\n            \"DetailsUrl\": \"https://job.jobnet.dk/CV/FindWork/DetailsWidk/5363343\",\r\n            \"JobLogUrl\": \"https://job.jobnet.dk/CV/FindWork/Details/5363343\",\r\n            \"HasLocationValues\": true,\r\n            \"ID\": \"5363343\",\r\n            \"Latitude\": 55.6872,\r\n            \"Longitude\": 12.5772\r\n        }",
                    title: "Tenure Track Assistant Professor in paleoecology, ancient genomics and conservation biology",
                    presentation: "The GLOBE Institute at the Faculty of Health and Medical Sciences, University of Copenhagen seeks to appoint a tenure track assistant professor in paleoecology, ancient genomics and conservation biolo",
                    hiringOrgName: "KU - SCIENCE - SNM",
                    workPlaceAddress: "Øster Voldgade 5-7",
                    workPlacePostalCode: 1350,
                    workPlaceCity: "København K",
                    postingCreated: new DateTime(2021, 07, 02),
                    lastDateApplication: new DateTime(2021, 07, 21),
                    url: "https://job.jobnet.dk/CV/FindWork/Details/5363343",
                    region: "Hovedstaden og Bornholm",
                    municipality: "København",
                    country: "Danmark",
                    employmentType: "",
                    workHours: "Fuldtid",
                    occupation: "Adjunkt, sundhedsvidenskab",
                    workplaceId: 105129,
                    organisationId: 57758,
                    hiringOrgCVR: 29979812,
                    id: 5363343,
                    workPlaceCityWithoutZone: "København",
                    jobPostingNumber: 9,
                    jobPostingId: "5363343tenuretrackassistantprofessorin",
                    language: "en"
                );
        public static JobPostingExtended Shared_JobPage02_JobPostingExtended09
            = new JobPostingExtended(
                    jobPosting: Shared_JobPage02_JobPosting09,
                    response: Shared_FakeResponse,                      // Ignored
                    hiringOrgDescription: null,
                    publicationStartDate: null,
                    publicationEndDate: null,
                    purpose: Shared_FakePurpose,                        // Ignored
                    numberToFill: null,
                    contactEmail: null,
                    contactPersonName: null,
                    employmentDate: null,
                    applicationDeadlineDate: null,
                    bulletPoints: new List<BulletPoint>()
                    {

                        new BulletPoint(
                            text: "research, including publication/academic dissemination",
                            type: null
                            ),
                        new BulletPoint(
                            text: "research-based teaching",
                            type: null
                            ),
                        new BulletPoint(
                            text: "sharing knowledge with society",
                            type: null
                            ),
                        new BulletPoint(
                            text: "participation in formal pedagogical training programme for assistant professors",
                            type: null
                            ),
                        new BulletPoint(
                            text: "a PhD degree or similar qualifications within the subject area",
                            type: null
                            ),
                        new BulletPoint(
                            text: "research experience within the field of the position",
                            type: null
                            ),
                        new BulletPoint(
                            text: "Application, including motivation for applying for this position (Maximum 2 pages)",
                            type: null
                            ),
                        new BulletPoint(
                            text: "Curriculum vitae, including information about funding",
                            type: null
                            ),
                        new BulletPoint(
                            text: "Diplomas (Master’s, PhD and other relevant diplomas)",
                            type: null
                            ),
                        new BulletPoint(
                            text: "A complete list of publications",
                            type: null
                            ),
                        new BulletPoint(
                            text: "Research plan (2-4 pages)",
                            type: null
                            ),
                        new BulletPoint(
                            text: "Teaching plan",
                            type: null
                            ),
                        new BulletPoint(
                            text: "Uploads of maximum 5 publications to be considered in the assessment",
                            type: null
                            ),
                        new BulletPoint(
                            text: "Teaching portfolio, if applicable (Guidelines: https://employment.ku.dk/faculty/recruitment-process/job-application-portfolio)",
                            type: null
                            )

                    },
                    bulletPointScenario: "generic"
                );

        public static JobPosting Shared_JobPage02_JobPosting10
            = new JobPosting(
                    runId: Shared_FakeRunId,
                    pageNumber: 2,
                    response: "{\r\n            \"AutomatchType\": 0,\r\n            \"Abroad\": true,\r\n            \"Weight\": 1.0,\r\n            \"Title\": \"Receptionist\",\r\n            \"JobHeadline\": \"Security Receptionist\",\r\n            \"Presentation\": \"Stilling\\n\\nSecurity Receptionist\\nJobbeskrivelse\\nJobbeskrivelse\\n\\nPlacering\\n\\nBagsværd, Denmark\\n\\nJobkategori\\n\\nGeneral Management and Administration\\n\\nAnsøg nu\\n\\n\u00A0 \u00A0\\n\\nSecurity receptionist in Novo Nordisk – \",\r\n            \"HiringOrgName\": \"Novo Nordisk A/S\",\r\n            \"WorkPlaceAddress\": \"Novo alle 1\",\r\n            \"WorkPlacePostalCode\": \"2880\",\r\n            \"WorkPlaceCity\": \"Bagsværd\",\r\n            \"WorkPlaceOtherAddress\": false,\r\n            \"WorkPlaceAbroad\": false,\r\n            \"WorkPlaceNotStatic\": false,\r\n            \"UseWorkPlaceAddressForJoblog\": true,\r\n            \"PostingCreated\": \"2021-07-02T00:00:00\",\r\n            \"LastDateApplication\": \"2021-07-06T00:00:00\",\r\n            \"FormattedLastDateApplication\": \"6. juli 2021\",\r\n            \"AssignmentStartDate\": \"2021-07-07T00:00:00\",\r\n            \"IsHotjob\": false,\r\n            \"IsExternal\": true,\r\n            \"Url\": \"https://www.novonordisk.dk/content/nncorp/dk/da/careers/find-a-job/job-ad.199941.en_GB.html\",\r\n            \"Region\": \"Hovedstaden og Bornholm\",\r\n            \"Municipality\": \"Lyngby-Taarbæk\",\r\n            \"Country\": \"\",\r\n            \"PostalCode\": \"2880\",\r\n            \"PostalCodeName\": null,\r\n            \"JobAnnouncementType\": \"Almindelige vilkår\",\r\n            \"EmploymentType\": \"Tidsbegrænset ansættelse\",\r\n            \"WorkHours\": \"Fuldtid\",\r\n            \"OccupationArea\": \"\",\r\n            \"OccupationGroup\": \"\",\r\n            \"Occupation\": \"\",\r\n            \"Location\": {\r\n                \"Latitude\": 55.7546,\r\n                \"Longitude\": 12.4552\r\n            },\r\n            \"JoblogWorkTime\": {\r\n                \"WorkHour\": null,\r\n                \"DailyWorkTime\": null\r\n            },\r\n            \"WorkplaceID\": 0,\r\n            \"OrganisationId\": \"\",\r\n            \"HiringOrgCVR\": 0,\r\n            \"UserLoggedIn\": false,\r\n            \"AnonymousEmployer\": false,\r\n            \"ShareUrl\": \"https://www.novonordisk.dk/content/nncorp/dk/da/careers/find-a-job/job-ad.199941.en_GB.html\",\r\n            \"DetailsUrl\": null,\r\n            \"JobLogUrl\": \"https://www.novonordisk.dk/content/nncorp/dk/da/careers/find-a-job/job-ad.199941.en_GB.html\",\r\n            \"HasLocationValues\": true,\r\n            \"ID\": \"E8251052\",\r\n            \"Latitude\": 55.7546,\r\n            \"Longitude\": 12.4552\r\n        }",
                    title: "Receptionist",
                    presentation: "Stilling\n\nSecurity Receptionist\nJobbeskrivelse\nJobbeskrivelse\n\nPlacering\n\nBagsværd, Denmark\n\nJobkategori\n\nGeneral Management and Administration\n\nAnsøg nu\n\n\u00A0 \u00A0\n\nSecurity receptionist in Novo Nordisk – ",
                    hiringOrgName: "Novo Nordisk A/S",
                    workPlaceAddress: "Novo alle 1",
                    workPlacePostalCode: 2880,
                    workPlaceCity: "Bagsværd",
                    postingCreated: new DateTime(2021, 07, 02),
                    lastDateApplication: new DateTime(2021, 07, 06),
                    url: "https://www.novonordisk.dk/content/nncorp/dk/da/careers/find-a-job/job-ad.199941.en_GB.html",
                    region: "Hovedstaden og Bornholm",
                    municipality: "Lyngby-Taarbæk",
                    country: "",
                    employmentType: "Tidsbegrænset ansættelse",
                    workHours: "Fuldtid",
                    occupation: "",
                    workplaceId: 0,
                    organisationId: null,
                    hiringOrgCVR: 0,
                    id: 8251052,
                    workPlaceCityWithoutZone: "Bagsværd",
                    jobPostingNumber: 10,
                    jobPostingId: "8251052receptionist",
                    language: "dk/en"
                );
        public static JobPostingExtended Shared_JobPage02_JobPostingExtended10
            = new JobPostingExtended(
                    jobPosting: Shared_JobPage02_JobPosting10,
                    response: Shared_FakeResponse,                      // Ignored
                    hiringOrgDescription: null,
                    publicationStartDate: null,
                    publicationEndDate: null,
                    purpose: Shared_FakePurpose,                        // Ignored
                    numberToFill: null,
                    contactEmail: null,
                    contactPersonName: null,
                    employmentDate: null,
                    applicationDeadlineDate: null,
                    bulletPoints: new List<BulletPoint>()
                    {

                        new BulletPoint(
                            text: "The most important in this job is your personality. We weigh discretion highly and the importance of our customers getting a professional service when they are welcomed by you at our receptions.",
                            type: null
                            ),
                        new BulletPoint(
                            text: "We are an active part of the security setup and it will be an advantage if you have worked as an Security Receptionist before.",
                            type: null
                            ),
                        new BulletPoint(
                            text: "As you will have colleagues from very different backgrounds, it will require tolerance and understanding to positively gain from the differences.",
                            type: null
                            ),
                        new BulletPoint(
                            text: "You will need a good deal of curiosity and have the ability to work very thorough with your tasks.",
                            type: null
                            ),
                        new BulletPoint(
                            text: "You have a solid language background, speak and write Danish and English at a high level. It will be an advantage if you master another foreign language. You have the ability to absorb and handle large amounts of information and in depth organisational knowledge.",
                            type: null
                            ),
                        new BulletPoint(
                            text: "You are used to working in a large company and handling many different stakeholders. You are a super user in regards to the Office-package, are used to working with data and Key Performance Indicators (KPIs) and you have technical insight into SAP and IT systems including maintenance hereof.",
                            type: null
                            )

                    },
                    bulletPointScenario: "novonordisk"
                );

        public static JobPosting Shared_JobPage02_JobPosting11
            = new JobPosting(
                    runId: Shared_FakeRunId,
                    pageNumber: 2,
                    response: "{\r\n            \"AutomatchType\": 0,\r\n            \"Abroad\": true,\r\n            \"Weight\": 1.0,\r\n            \"Title\": \"Security Officer\",\r\n            \"JobHeadline\": \"Security officer\",\r\n            \"Presentation\": \"Stilling\\n\\nSecurity officer\\nJobbeskrivelse\\nJobbeskrivelse\\n\\nPlacering\\n\\nBagsværd, Denmark\\n\\nJobkategori\\n\\nQuality\\n\\nAnsøg nu\\n\\n\u00A0 \u00A0\\n\\nSecurity Officer, Novo Nordisk Alarm Response centre\\n\\nDo you wish to be par\",\r\n            \"HiringOrgName\": \"Novo Nordisk A/S\",\r\n            \"WorkPlaceAddress\": \"Novo alle 1\",\r\n            \"WorkPlacePostalCode\": \"2880\",\r\n            \"WorkPlaceCity\": \"Bagsværd\",\r\n            \"WorkPlaceOtherAddress\": false,\r\n            \"WorkPlaceAbroad\": false,\r\n            \"WorkPlaceNotStatic\": false,\r\n            \"UseWorkPlaceAddressForJoblog\": true,\r\n            \"PostingCreated\": \"2021-07-02T00:00:00\",\r\n            \"LastDateApplication\": \"2021-07-06T00:00:00\",\r\n            \"FormattedLastDateApplication\": \"6. juli 2021\",\r\n            \"AssignmentStartDate\": \"2021-07-07T00:00:00\",\r\n            \"IsHotjob\": false,\r\n            \"IsExternal\": true,\r\n            \"Url\": \"https://www.novonordisk.dk/content/nncorp/dk/da/careers/find-a-job/job-ad.199961.en_GB.html\",\r\n            \"Region\": \"Hovedstaden og Bornholm\",\r\n            \"Municipality\": \"Lyngby-Taarbæk\",\r\n            \"Country\": \"\",\r\n            \"PostalCode\": \"2880\",\r\n            \"PostalCodeName\": null,\r\n            \"JobAnnouncementType\": \"Almindelige vilkår\",\r\n            \"EmploymentType\": \"Fastansættelse\",\r\n            \"WorkHours\": \"Fuldtid\",\r\n            \"OccupationArea\": \"\",\r\n            \"OccupationGroup\": \"\",\r\n            \"Occupation\": \"\",\r\n            \"Location\": {\r\n                \"Latitude\": 55.7546,\r\n                \"Longitude\": 12.4552\r\n            },\r\n            \"JoblogWorkTime\": {\r\n                \"WorkHour\": null,\r\n                \"DailyWorkTime\": null\r\n            },\r\n            \"WorkplaceID\": 0,\r\n            \"OrganisationId\": \"\",\r\n            \"HiringOrgCVR\": 0,\r\n            \"UserLoggedIn\": false,\r\n            \"AnonymousEmployer\": false,\r\n            \"ShareUrl\": \"https://www.novonordisk.dk/content/nncorp/dk/da/careers/find-a-job/job-ad.199961.en_GB.html\",\r\n            \"DetailsUrl\": null,\r\n            \"JobLogUrl\": \"https://www.novonordisk.dk/content/nncorp/dk/da/careers/find-a-job/job-ad.199961.en_GB.html\",\r\n            \"HasLocationValues\": true,\r\n            \"ID\": \"E8251051\",\r\n            \"Latitude\": 55.7546,\r\n            \"Longitude\": 12.4552\r\n        }",
                    title: "Security Officer",
                    presentation: "Stilling\n\nSecurity officer\nJobbeskrivelse\nJobbeskrivelse\n\nPlacering\n\nBagsværd, Denmark\n\nJobkategori\n\nQuality\n\nAnsøg nu\n\n\u00A0 \u00A0\n\nSecurity Officer, Novo Nordisk Alarm Response centre\n\nDo you wish to be par",
                    hiringOrgName: "Novo Nordisk A/S",
                    workPlaceAddress: "Novo alle 1",
                    workPlacePostalCode: 2880,
                    workPlaceCity: "Bagsværd",
                    postingCreated: new DateTime(2021, 07, 02),
                    lastDateApplication: new DateTime(2021, 07, 06),
                    url: "https://www.novonordisk.dk/content/nncorp/dk/da/careers/find-a-job/job-ad.199961.en_GB.html",
                    region: "Hovedstaden og Bornholm",
                    municipality: "Lyngby-Taarbæk",
                    country: "",
                    employmentType: "Fastansættelse",
                    workHours: "Fuldtid",
                    occupation: "",
                    workplaceId: 0,
                    organisationId: null,
                    hiringOrgCVR: 0,
                    id: 8251051,
                    workPlaceCityWithoutZone: "Bagsværd",
                    jobPostingNumber: 11,
                    jobPostingId: "8251051securityofficer",
                    language: "en" // To-do: this prediction must be improved (ClassificationManager).
                );
        public static JobPostingExtended Shared_JobPage02_JobPostingExtended11
            = new JobPostingExtended(
                    jobPosting: Shared_JobPage02_JobPosting11,
                    response: Shared_FakeResponse,                      // Ignored
                    hiringOrgDescription: null,
                    publicationStartDate: null,
                    publicationEndDate: null,
                    purpose: Shared_FakePurpose,                        // Ignored
                    numberToFill: null,
                    contactEmail: null,
                    contactPersonName: null,
                    employmentDate: null,
                    applicationDeadlineDate: null,
                    bulletPoints: new List<BulletPoint>()
                    {

                        new BulletPoint(
                            text: "Behandlings-områder",
                            type: null
                            ),
                        new BulletPoint(
                            text: "Sundheds-personale",
                            type: null
                            ),
                        new BulletPoint(
                            text: "Videnskab &amp; teknologi",
                            type: null
                            ),
                        new BulletPoint(
                            text: "Bæredygtig forretning",
                            type: null
                            ),
                        new BulletPoint(
                            text: "Karriere",
                            type: null
                            ),
                        new BulletPoint(
                            text: "Om Novo Nordisk",
                            type: null
                            ),
                        new BulletPoint(
                            text: "Få mere viden",
                            type: null
                            ),
                        new BulletPoint(
                            text: "Nyheder og presse",
                            type: null
                            ),
                        new BulletPoint(
                            text: "Kontakt os",
                            type: null
                            )

                    },
                    bulletPointScenario: "generic"
                );

        public static JobPosting Shared_JobPage02_JobPosting12
            = new JobPosting(
                    runId: Shared_FakeRunId,
                    pageNumber: 2,
                    response: "{\r\n            \"AutomatchType\": 0,\r\n            \"Abroad\": true,\r\n            \"Weight\": 1.0,\r\n            \"Title\": \"PhD\",\r\n            \"JobHeadline\": \"PhD\",\r\n            \"Presentation\": \"Center for Permafrost (CENPERM) at University of Copenhagen is recruiting two postdoctoral associates to work with field-based ecosystem manipulations and process-based ecosystem modelling with a focu\",\r\n            \"HiringOrgName\": \"Københavns Universitet\",\r\n            \"WorkPlaceAddress\": \"\",\r\n            \"WorkPlacePostalCode\": \"\",\r\n            \"WorkPlaceCity\": \"\",\r\n            \"WorkPlaceOtherAddress\": false,\r\n            \"WorkPlaceAbroad\": false,\r\n            \"WorkPlaceNotStatic\": false,\r\n            \"UseWorkPlaceAddressForJoblog\": false,\r\n            \"PostingCreated\": \"2021-07-02T00:00:00\",\r\n            \"LastDateApplication\": \"2021-09-01T00:00:00\",\r\n            \"FormattedLastDateApplication\": \"1. september 2021\",\r\n            \"AssignmentStartDate\": \"2021-11-01T00:00:00\",\r\n            \"IsHotjob\": false,\r\n            \"IsExternal\": true,\r\n            \"Url\": \"https://jobportal.ku.dk/videnskabelige-stillinger/?show=154356\",\r\n            \"Region\": \"Hovedstaden og Bornholm\",\r\n            \"Municipality\": \"København\",\r\n            \"Country\": \"\",\r\n            \"PostalCode\": \"1000\",\r\n            \"PostalCodeName\": null,\r\n            \"JobAnnouncementType\": \"Almindelige vilkår\",\r\n            \"EmploymentType\": \"Tidsbegrænset ansættelse\",\r\n            \"WorkHours\": \"Fuldtid\",\r\n            \"OccupationArea\": \"\",\r\n            \"OccupationGroup\": \"\",\r\n            \"Occupation\": \"\",\r\n            \"Location\": null,\r\n            \"JoblogWorkTime\": {\r\n                \"WorkHour\": null,\r\n                \"DailyWorkTime\": null\r\n            },\r\n            \"WorkplaceID\": 0,\r\n            \"OrganisationId\": \"\",\r\n            \"HiringOrgCVR\": 0,\r\n            \"UserLoggedIn\": false,\r\n            \"AnonymousEmployer\": false,\r\n            \"ShareUrl\": \"https://jobportal.ku.dk/videnskabelige-stillinger/?show=154356\",\r\n            \"DetailsUrl\": null,\r\n            \"JobLogUrl\": \"https://jobportal.ku.dk/videnskabelige-stillinger/?show=154356\",\r\n            \"HasLocationValues\": false,\r\n            \"ID\": \"E8251042\",\r\n            \"Latitude\": 0.0,\r\n            \"Longitude\": 0.0\r\n        }",
                    title: "PhD",
                    presentation: "Center for Permafrost (CENPERM) at University of Copenhagen is recruiting two postdoctoral associates to work with field-based ecosystem manipulations and process-based ecosystem modelling with a focu",
                    hiringOrgName: "Københavns Universitet",
                    workPlaceAddress: "",
                    workPlacePostalCode: null,
                    workPlaceCity: "",
                    postingCreated: new DateTime(2021, 07, 02),
                    lastDateApplication: new DateTime(2021, 09, 01),
                    url: "https://jobportal.ku.dk/videnskabelige-stillinger/?show=154356",
                    region: "Hovedstaden og Bornholm",
                    municipality: "København",
                    country: "",
                    employmentType: "Tidsbegrænset ansættelse",
                    workHours: "Fuldtid",
                    occupation: "",
                    workplaceId: 0,
                    organisationId: null,
                    hiringOrgCVR: 0,
                    id: 8251042,
                    workPlaceCityWithoutZone: "",
                    jobPostingNumber: 12,
                    jobPostingId: "8251042phd",
                    language: "en"
                );
        public static JobPostingExtended Shared_JobPage02_JobPostingExtended12
            = new JobPostingExtended(
                    jobPosting: Shared_JobPage02_JobPosting12,
                    response: Shared_FakeResponse,                      // Ignored
                    hiringOrgDescription: null,
                    publicationStartDate: null,
                    publicationEndDate: null,
                    purpose: Shared_FakePurpose,                        // Ignored
                    numberToFill: null,
                    contactEmail: null,
                    contactPersonName: null,
                    employmentDate: null,
                    applicationDeadlineDate: null,
                    bulletPoints: new List<BulletPoint>()
                    {

                        new BulletPoint(
                            text: "Field-based ecosystem manipulations experiments and monitoring of greenhouse gas production",
                            type: null
                            ),
                        new BulletPoint(
                            text: "Measurements of subsurface and snow gas concentrations, diffusion and greenhouse gas fluxes",
                            type: null
                            ),
                        new BulletPoint(
                            text: "Process-based models to simulate changes in climate-soil-plant-microbial characteristics",
                            type: null
                            ),
                        new BulletPoint(
                            text: "Structural equation modelling",
                            type: null
                            ),
                        new BulletPoint(
                            text: "Letter of application",
                            type: null
                            ),
                        new BulletPoint(
                            text: "Curriculum vita, incl. education, experience, previous employments, language skills and other relevant skills (max 5 pages).",
                            type: null
                            ),
                        new BulletPoint(
                            text: "Detailed outline of proposed research, including research questions and methods (max 5 pages)",
                            type: null
                            ),
                        new BulletPoint(
                            text: "Diplomas (Master and PhD degree or equivalent)",
                            type: null
                            ),
                        new BulletPoint(
                            text: "Complete publication list, highlighting the 3 most important ones",
                            type: null
                            ),
                        new BulletPoint(
                            text: "Separate reprints of 3 particularly relevant papers",
                            type: null
                            ),
                        new BulletPoint(
                            text: "Two letters of recommendation.",
                            type: null
                            )

                    },
                    bulletPointScenario: "jobportal"
                );

        public static JobPosting Shared_JobPage02_JobPosting13
            = new JobPosting(
                    runId: Shared_FakeRunId,
                    pageNumber: 2,
                    response: "{\r\n            \"AutomatchType\": 0,\r\n            \"Abroad\": true,\r\n            \"Weight\": 1.0,\r\n            \"Title\": \"Specialist\",\r\n            \"JobHeadline\": \"Clinical disclosure specialist\",\r\n            \"Presentation\": \"Are you an expert in clinical disclosure regulations and can you drive the implementation and ensure compliance? Then continue reading!\\n\u00A0\\n\\nLEO Pharma has embarked on a very ambitious journey to become\",\r\n            \"HiringOrgName\": \"LEO Pharma A/S\",\r\n            \"WorkPlaceAddress\": \"Industriparken 55\",\r\n            \"WorkPlacePostalCode\": \"2750\",\r\n            \"WorkPlaceCity\": \"Ballerup\",\r\n            \"WorkPlaceOtherAddress\": false,\r\n            \"WorkPlaceAbroad\": false,\r\n            \"WorkPlaceNotStatic\": false,\r\n            \"UseWorkPlaceAddressForJoblog\": true,\r\n            \"PostingCreated\": \"2021-07-02T00:00:00\",\r\n            \"LastDateApplication\": \"2021-08-01T00:00:00\",\r\n            \"FormattedLastDateApplication\": \"1. august 2021\",\r\n            \"AssignmentStartDate\": \"2021-08-02T00:00:00\",\r\n            \"IsHotjob\": false,\r\n            \"IsExternal\": true,\r\n            \"Url\": \"https://leopharma.easycruit.com/vacancy/2738279/127513?iso=dk\",\r\n            \"Region\": \"Hovedstaden og Bornholm\",\r\n            \"Municipality\": \"Ballerup\",\r\n            \"Country\": \"\",\r\n            \"PostalCode\": \"2750\",\r\n            \"PostalCodeName\": null,\r\n            \"JobAnnouncementType\": \"Almindelige vilkår\",\r\n            \"EmploymentType\": \"Fastansættelse\",\r\n            \"WorkHours\": \"Fuldtid\",\r\n            \"OccupationArea\": \"\",\r\n            \"OccupationGroup\": \"\",\r\n            \"Occupation\": \"\",\r\n            \"Location\": {\r\n                \"Latitude\": 55.7268,\r\n                \"Longitude\": 12.3937\r\n            },\r\n            \"JoblogWorkTime\": {\r\n                \"WorkHour\": null,\r\n                \"DailyWorkTime\": null\r\n            },\r\n            \"WorkplaceID\": 0,\r\n            \"OrganisationId\": \"\",\r\n            \"HiringOrgCVR\": 0,\r\n            \"UserLoggedIn\": false,\r\n            \"AnonymousEmployer\": false,\r\n            \"ShareUrl\": \"https://leopharma.easycruit.com/vacancy/2738279/127513?iso=dk\",\r\n            \"DetailsUrl\": null,\r\n            \"JobLogUrl\": \"https://leopharma.easycruit.com/vacancy/2738279/127513?iso=dk\",\r\n            \"HasLocationValues\": true,\r\n            \"ID\": \"E8251041\",\r\n            \"Latitude\": 55.7268,\r\n            \"Longitude\": 12.3937\r\n        }",
                    title: "Specialist",
                    presentation: "Are you an expert in clinical disclosure regulations and can you drive the implementation and ensure compliance? Then continue reading!\n\u00A0\n\nLEO Pharma has embarked on a very ambitious journey to become",
                    hiringOrgName: "LEO Pharma A/S",
                    workPlaceAddress: "Industriparken 55",
                    workPlacePostalCode: 2750,
                    workPlaceCity: "Ballerup",
                    postingCreated: new DateTime(2021, 07, 02),
                    lastDateApplication: new DateTime(2021, 08, 01),
                    url: "https://leopharma.easycruit.com/vacancy/2738279/127513?iso=dk",
                    region: "Hovedstaden og Bornholm",
                    municipality: "Ballerup",
                    country: "",
                    employmentType: "Fastansættelse",
                    workHours: "Fuldtid",
                    occupation: "",
                    workplaceId: 0,
                    organisationId: null,
                    hiringOrgCVR: 0,
                    id: 8251041,
                    workPlaceCityWithoutZone: "Ballerup",
                    jobPostingNumber: 13,
                    jobPostingId: "8251041specialist",
                    language: "en"
                );
        public static JobPostingExtended Shared_JobPage02_JobPostingExtended13
            = new JobPostingExtended(
                    jobPosting: Shared_JobPage02_JobPosting13,
                    response: Shared_FakeResponse,                      // Ignored
                    hiringOrgDescription: null,
                    publicationStartDate: null,
                    publicationEndDate: null,
                    purpose: Shared_FakePurpose,                        // Ignored
                    numberToFill: null,
                    contactEmail: null,
                    contactPersonName: null,
                    employmentDate: null,
                    applicationDeadlineDate: null,
                    bulletPoints: new List<BulletPoint>()
                    {

                        new BulletPoint(
                            text: "Subject matter expert with responsibility for planning, advising on, coordinating, and handling public disclosure of clinical trial information.",
                            type: null
                            ),
                        new BulletPoint(
                            text: "Monitor and evaluate the clinical trial disclosure landscape, including regulatory requirements and industry trends.",
                            type: null
                            ),
                        new BulletPoint(
                            text: "Develop, pilot, implement, update, and maintain procedures to ensure compliance with regulations and other commitments for clinical data transparency.",
                            type: null
                            ),
                        new BulletPoint(
                            text: "University degree in health or biological science (MD, MSc, MSc Pharm or equivalent).",
                            type: null
                            ),
                        new BulletPoint(
                            text: "Thorough knowledge of clinical development, GCP, scientific research methods, and applicable regulatory guidelines. Understanding of clinical statistics.",
                            type: null
                            ),
                        new BulletPoint(
                            text: "Strong IT flair – documented through previous experience, either professional or private.",
                            type: null
                            ),
                        new BulletPoint(
                            text: "Prior experience with clinical disclosure will be an advantage.",
                            type: null
                            )

                    },
                    bulletPointScenario: "easycruit"
                );

        public static JobPosting Shared_JobPage02_JobPosting14
            = new JobPosting(
                    runId: Shared_FakeRunId,
                    pageNumber: 2,
                    response: "{\r\n            \"AutomatchType\": 0,\r\n            \"Abroad\": true,\r\n            \"Weight\": 1.0,\r\n            \"Title\": \"Support Engineer\",\r\n            \"JobHeadline\": \"Customer Support Engineer for Alfa Laval Aalborg\",\r\n            \"Presentation\": \"Customer Support Engineer for Alfa Laval Aalborg\\nAalborg\\nApply\\n\\nAt Alfa Laval, we always go that extra mile to overcome the toughest challenges. Our driving force is to accelerate success for our cust\",\r\n            \"HiringOrgName\": \"Alfa Laval Aalborg A/S\",\r\n            \"WorkPlaceAddress\": \"Gasværksvej 21\",\r\n            \"WorkPlacePostalCode\": \"9000\",\r\n            \"WorkPlaceCity\": \"Aalborg\",\r\n            \"WorkPlaceOtherAddress\": false,\r\n            \"WorkPlaceAbroad\": false,\r\n            \"WorkPlaceNotStatic\": false,\r\n            \"UseWorkPlaceAddressForJoblog\": true,\r\n            \"PostingCreated\": \"2021-07-02T00:00:00\",\r\n            \"LastDateApplication\": \"2021-07-20T00:00:00\",\r\n            \"FormattedLastDateApplication\": \"20. juli 2021\",\r\n            \"AssignmentStartDate\": \"2021-07-21T00:00:00\",\r\n            \"IsHotjob\": false,\r\n            \"IsExternal\": true,\r\n            \"Url\": \"https://alfalaval.wd3.myworkdayjobs.com/en-US/Alfa_Laval_jobs/job/Aalborg/Customer-Support-Engineer-for-Alfa-Laval-Aalborg_JR0007198\",\r\n            \"Region\": \"Nordjylland\",\r\n            \"Municipality\": \"Aalborg\",\r\n            \"Country\": \"\",\r\n            \"PostalCode\": \"9000\",\r\n            \"PostalCodeName\": null,\r\n            \"JobAnnouncementType\": \"Almindelige vilkår\",\r\n            \"EmploymentType\": \"Fastansættelse\",\r\n            \"WorkHours\": \"Fuldtid\",\r\n            \"OccupationArea\": \"\",\r\n            \"OccupationGroup\": \"\",\r\n            \"Occupation\": \"\",\r\n            \"Location\": {\r\n                \"Latitude\": 57.0493,\r\n                \"Longitude\": 9.9485\r\n            },\r\n            \"JoblogWorkTime\": {\r\n                \"WorkHour\": null,\r\n                \"DailyWorkTime\": null\r\n            },\r\n            \"WorkplaceID\": 0,\r\n            \"OrganisationId\": \"\",\r\n            \"HiringOrgCVR\": 0,\r\n            \"UserLoggedIn\": false,\r\n            \"AnonymousEmployer\": false,\r\n            \"ShareUrl\": \"https://alfalaval.wd3.myworkdayjobs.com/en-US/Alfa_Laval_jobs/job/Aalborg/Customer-Support-Engineer-for-Alfa-Laval-Aalborg_JR0007198\",\r\n            \"DetailsUrl\": null,\r\n            \"JobLogUrl\": \"https://alfalaval.wd3.myworkdayjobs.com/en-US/Alfa_Laval_jobs/job/Aalborg/Customer-Support-Engineer-for-Alfa-Laval-Aalborg_JR0007198\",\r\n            \"HasLocationValues\": true,\r\n            \"ID\": \"E8251039\",\r\n            \"Latitude\": 57.0493,\r\n            \"Longitude\": 9.9485\r\n        }",
                    title: "Support Engineer",
                    presentation: "Customer Support Engineer for Alfa Laval Aalborg\nAalborg\nApply\n\nAt Alfa Laval, we always go that extra mile to overcome the toughest challenges. Our driving force is to accelerate success for our cust",
                    hiringOrgName: "Alfa Laval Aalborg A/S",
                    workPlaceAddress: "Gasværksvej 21",
                    workPlacePostalCode: 9000,
                    workPlaceCity: "Aalborg",
                    postingCreated: new DateTime(2021, 07, 02),
                    lastDateApplication: new DateTime(2021, 07, 20),
                    url: "https://alfalaval.wd3.myworkdayjobs.com/en-US/Alfa_Laval_jobs/job/Aalborg/Customer-Support-Engineer-for-Alfa-Laval-Aalborg_JR0007198",
                    region: "Nordjylland",
                    municipality: "Aalborg",
                    country: "",
                    employmentType: "Fastansættelse",
                    workHours: "Fuldtid",
                    occupation: "",
                    workplaceId: 0,
                    organisationId: null,
                    hiringOrgCVR: 0,
                    id: 8251039,
                    workPlaceCityWithoutZone: "Aalborg",
                    jobPostingNumber: 14,
                    jobPostingId: "8251039supportengineer",
                    language: "en"
                );
        public static JobPostingExtended Shared_JobPage02_JobPostingExtended14
            = new JobPostingExtended(
                    jobPosting: Shared_JobPage02_JobPosting14,
                    response: Shared_FakeResponse,                      // Ignored
                    hiringOrgDescription: null,
                    publicationStartDate: null,
                    publicationEndDate: null,
                    purpose: Shared_FakePurpose,                        // Ignored
                    numberToFill: null,
                    contactEmail: null,
                    contactPersonName: null,
                    employmentDate: null,
                    applicationDeadlineDate: null,
                    bulletPoints: null,
                    bulletPointScenario: null
                );

        public static JobPosting Shared_JobPage02_JobPosting15
            = new JobPosting(
                    runId: Shared_FakeRunId,
                    pageNumber: 2,
                    response: "{\r\n            \"AutomatchType\": 0,\r\n            \"Abroad\": true,\r\n            \"Weight\": 1.0,\r\n            \"Title\": \"Software Developer\",\r\n            \"JobHeadline\": \"Software Developers (Back End & Full Stack)\",\r\n            \"Presentation\": \" \\nSoftware Developers (Back End & Full Stack)\\nDenmark Copenhagen Local IT Last application date: 17/7/2021\\nMaersk is going through times of unprecedented change. We are rethinking the way we engage wi\",\r\n            \"HiringOrgName\": \"A.P. Møller - Mærsk A/S\",\r\n            \"WorkPlaceAddress\": \"\",\r\n            \"WorkPlacePostalCode\": \"\",\r\n            \"WorkPlaceCity\": \"\",\r\n            \"WorkPlaceOtherAddress\": false,\r\n            \"WorkPlaceAbroad\": false,\r\n            \"WorkPlaceNotStatic\": false,\r\n            \"UseWorkPlaceAddressForJoblog\": false,\r\n            \"PostingCreated\": \"2021-07-02T00:00:00\",\r\n            \"LastDateApplication\": \"2021-07-17T00:00:00\",\r\n            \"FormattedLastDateApplication\": \"17. juli 2021\",\r\n            \"AssignmentStartDate\": \"2021-07-18T00:00:00\",\r\n            \"IsHotjob\": false,\r\n            \"IsExternal\": true,\r\n            \"Url\": \"https://jobsearch.maersk.com/jobposting/index.html?id=MA-275828\",\r\n            \"Region\": \"Hovedstaden og Bornholm\",\r\n            \"Municipality\": \"København\",\r\n            \"Country\": \"\",\r\n            \"PostalCode\": \"1000\",\r\n            \"PostalCodeName\": null,\r\n            \"JobAnnouncementType\": \"Almindelige vilkår\",\r\n            \"EmploymentType\": \"Fastansættelse\",\r\n            \"WorkHours\": \"Fuldtid\",\r\n            \"OccupationArea\": \"\",\r\n            \"OccupationGroup\": \"\",\r\n            \"Occupation\": \"\",\r\n            \"Location\": null,\r\n            \"JoblogWorkTime\": {\r\n                \"WorkHour\": null,\r\n                \"DailyWorkTime\": null\r\n            },\r\n            \"WorkplaceID\": 0,\r\n            \"OrganisationId\": \"\",\r\n            \"HiringOrgCVR\": 0,\r\n            \"UserLoggedIn\": false,\r\n            \"AnonymousEmployer\": false,\r\n            \"ShareUrl\": \"https://jobsearch.maersk.com/jobposting/index.html?id=MA-275828\",\r\n            \"DetailsUrl\": null,\r\n            \"JobLogUrl\": \"https://jobsearch.maersk.com/jobposting/index.html?id=MA-275828\",\r\n            \"HasLocationValues\": false,\r\n            \"ID\": \"E8251038\",\r\n            \"Latitude\": 0.0,\r\n            \"Longitude\": 0.0\r\n        }",
                    title: "Software Developer",
                    presentation: " \nSoftware Developers (Back End & Full Stack)\nDenmark Copenhagen Local IT Last application date: 17/7/2021\nMaersk is going through times of unprecedented change. We are rethinking the way we engage wi",
                    hiringOrgName: "A.P. Møller - Mærsk A/S",
                    workPlaceAddress: "",
                    workPlacePostalCode: null,
                    workPlaceCity: "",
                    postingCreated: new DateTime(2021, 07, 02),
                    lastDateApplication: new DateTime(2021, 07, 17),
                    url: "https://jobsearch.maersk.com/jobposting/index.html?id=MA-275828",
                    region: "Hovedstaden og Bornholm",
                    municipality: "København",
                    country: "",
                    employmentType: "Fastansættelse",
                    workHours: "Fuldtid",
                    occupation: "",
                    workplaceId: 0,
                    organisationId: null,
                    hiringOrgCVR: 0,
                    id: 8251038,
                    workPlaceCityWithoutZone: "",
                    jobPostingNumber: 15,
                    jobPostingId: "8251038softwaredeveloper",
                    language: "en"
                );
        public static JobPostingExtended Shared_JobPage02_JobPostingExtended15
            = new JobPostingExtended(
                    jobPosting: Shared_JobPage02_JobPosting15,
                    response: Shared_FakeResponse,                      // Ignored
                    hiringOrgDescription: null,
                    publicationStartDate: null,
                    publicationEndDate: null,
                    purpose: Shared_FakePurpose,                        // Ignored
                    numberToFill: null,
                    contactEmail: null,
                    contactPersonName: null,
                    employmentDate: null,
                    applicationDeadlineDate: null,
                    bulletPoints: new List<BulletPoint>()
                    {

                        new BulletPoint(
                            text: "Facebook",
                            type: null
                            ),
                        new BulletPoint(
                            text: "Linkedin",
                            type: null
                            ),
                        new BulletPoint(
                            text: "Google+",
                            type: null
                            ),
                        new BulletPoint(
                            text: "Twitter",
                            type: null
                            ),
                        new BulletPoint(
                            text: "Email",
                            type: null
                            ),
                        new BulletPoint(
                            text: "Print",
                            type: null
                            )

                    },
                    bulletPointScenario: "generic"
                );

        public static JobPosting Shared_JobPage02_JobPosting16
            = new JobPosting(
                    runId: Shared_FakeRunId,
                    pageNumber: 2,
                    response: "{\r\n            \"AutomatchType\": 0,\r\n            \"Abroad\": true,\r\n            \"Weight\": 1.0,\r\n            \"Title\": \"PhD\",\r\n            \"JobHeadline\": \"PhD\",\r\n            \"Presentation\": \"PhD Stipend in State of Temperature Estimation in Smart Batteries using Artificial Intelligence (14-21065) At the Faculty of Engineering and Science, Department of Energy Technology a PhD stipend is a\",\r\n            \"HiringOrgName\": \"Aalborg Universitet\",\r\n            \"WorkPlaceAddress\": \"\",\r\n            \"WorkPlacePostalCode\": \"9000\",\r\n            \"WorkPlaceCity\": \"Aalborg\",\r\n            \"WorkPlaceOtherAddress\": false,\r\n            \"WorkPlaceAbroad\": false,\r\n            \"WorkPlaceNotStatic\": false,\r\n            \"UseWorkPlaceAddressForJoblog\": true,\r\n            \"PostingCreated\": \"2021-07-02T00:00:00\",\r\n            \"LastDateApplication\": \"2021-07-28T00:00:00\",\r\n            \"FormattedLastDateApplication\": \"28. juli 2021\",\r\n            \"AssignmentStartDate\": \"2021-11-01T00:00:00\",\r\n            \"IsHotjob\": false,\r\n            \"IsExternal\": true,\r\n            \"Url\": \"https://www.stillinger.aau.dk/vis-stilling/?vacancy=1159620\",\r\n            \"Region\": \"Nordjylland\",\r\n            \"Municipality\": \"Aalborg\",\r\n            \"Country\": \"\",\r\n            \"PostalCode\": \"9000\",\r\n            \"PostalCodeName\": null,\r\n            \"JobAnnouncementType\": \"Almindelige vilkår\",\r\n            \"EmploymentType\": \"Tidsbegrænset ansættelse\",\r\n            \"WorkHours\": \"Fuldtid\",\r\n            \"OccupationArea\": \"\",\r\n            \"OccupationGroup\": \"\",\r\n            \"Occupation\": \"\",\r\n            \"Location\": {\r\n                \"Latitude\": 57.0517,\r\n                \"Longitude\": 9.835\r\n            },\r\n            \"JoblogWorkTime\": {\r\n                \"WorkHour\": null,\r\n                \"DailyWorkTime\": null\r\n            },\r\n            \"WorkplaceID\": 0,\r\n            \"OrganisationId\": \"\",\r\n            \"HiringOrgCVR\": 0,\r\n            \"UserLoggedIn\": false,\r\n            \"AnonymousEmployer\": false,\r\n            \"ShareUrl\": \"https://www.stillinger.aau.dk/vis-stilling/?vacancy=1159620\",\r\n            \"DetailsUrl\": null,\r\n            \"JobLogUrl\": \"https://www.stillinger.aau.dk/vis-stilling/?vacancy=1159620\",\r\n            \"HasLocationValues\": true,\r\n            \"ID\": \"E8251036\",\r\n            \"Latitude\": 57.0517,\r\n            \"Longitude\": 9.835\r\n        }",
                    title: "PhD",
                    presentation: "PhD Stipend in State of Temperature Estimation in Smart Batteries using Artificial Intelligence (14-21065) At the Faculty of Engineering and Science, Department of Energy Technology a PhD stipend is a",
                    hiringOrgName: "Aalborg Universitet",
                    workPlaceAddress: "",
                    workPlacePostalCode: 9000,
                    workPlaceCity: "Aalborg",
                    postingCreated: new DateTime(2021, 07, 02),
                    lastDateApplication: new DateTime(2021, 07, 28),
                    url: "https://www.stillinger.aau.dk/vis-stilling/?vacancy=1159620",
                    region: "Nordjylland",
                    municipality: "Aalborg",
                    country: "",
                    employmentType: "Tidsbegrænset ansættelse",
                    workHours: "Fuldtid",
                    occupation: "",
                    workplaceId: 0,
                    organisationId: null,
                    hiringOrgCVR: 0,
                    id: 8251036,
                    workPlaceCityWithoutZone: "Aalborg",
                    jobPostingNumber: 16,
                    jobPostingId: "8251036phd",
                    language: "en"
                );
        public static JobPostingExtended Shared_JobPage02_JobPostingExtended16
            = new JobPostingExtended(
                    jobPosting: Shared_JobPage02_JobPosting16,
                    response: Shared_FakeResponse,                      // Ignored
                    hiringOrgDescription: null,
                    publicationStartDate: null,
                    publicationEndDate: null,
                    purpose: Shared_FakePurpose,                        // Ignored
                    numberToFill: null,
                    contactEmail: null,
                    contactPersonName: null,
                    employmentDate: null,
                    applicationDeadlineDate: null,
                    bulletPoints: new List<BulletPoint>()
                    {

                        new BulletPoint(
                            text: "Nyheder",
                            type: null
                            ),
                        new BulletPoint(
                            text: "Arrangementer",
                            type: null
                            ),
                        new BulletPoint(
                            text: "Kontakt og find rundt",
                            type: null
                            ),
                        new BulletPoint(
                            text: "Campusområder",
                            type: null
                            ),
                        new BulletPoint(
                            text: "For Pressen",
                            type: null
                            ),
                        new BulletPoint(
                            text: "For alumni",
                            type: null
                            ),
                        new BulletPoint(
                            text: "Genveje Nyheder Arrangementer Kontakt og find rundt Campusområder For Pressen For alumni",
                            type: null
                            ),
                        new BulletPoint(
                            text: "aau uddannelse",
                            type: null
                            ),
                        new BulletPoint(
                            text: "aau forskning",
                            type: null
                            ),
                        new BulletPoint(
                            text: "aau samarbejde",
                            type: null
                            ),
                        new BulletPoint(
                            text: "Om AAU",
                            type: null
                            ),
                        new BulletPoint(
                            text: "Ledige stillinger",
                            type: null
                            ),
                        new BulletPoint(
                            text: "Ansatte og studerende",
                            type: null
                            ),
                        new BulletPoint(
                            text: "Ledige stillinger på AAU",
                            type: null
                            ),
                        new BulletPoint(
                            text: "/",
                            type: null
                            ),
                        new BulletPoint(
                            text: "Vis stilling",
                            type: null
                            ),
                        new BulletPoint(
                            text: "Alle videnskabelige stillinger",
                            type: null
                            ),
                        new BulletPoint(
                            text: "Alle teknisk-administrative stillinger",
                            type: null
                            ),
                        new BulletPoint(
                            text: "Alle Phd stillinger",
                            type: null
                            ),
                        new BulletPoint(
                            text: "Alle ledige stillinger",
                            type: null
                            ),
                        new BulletPoint(
                            text: "AAU som arbejdsplads",
                            type: null
                            ),
                        new BulletPoint(
                            text: "AAU&#039;s personalepolitik",
                            type: null
                            ),
                        new BulletPoint(
                            text: "Organisation",
                            type: null
                            ),
                        new BulletPoint(
                            text: "Problembaseret læring",
                            type: null
                            ),
                        new BulletPoint(
                            text: "Strategi og udvikling",
                            type: null
                            ),
                        new BulletPoint(
                            text: "Internationalt samarbejde",
                            type: null
                            ),
                        new BulletPoint(
                            text: "Historie, priser og hæder",
                            type: null
                            ),
                        new BulletPoint(
                            text: "Uddannelseskvalitet",
                            type: null
                            ),
                        new BulletPoint(
                            text: "AAU i tal",
                            type: null
                            ),
                        new BulletPoint(
                            text: "Facebook",
                            type: null
                            ),
                        new BulletPoint(
                            text: "LinkedIn",
                            type: null
                            ),
                        new BulletPoint(
                            text: "Instagram",
                            type: null
                            ),
                        new BulletPoint(
                            text: "Snapchat",
                            type: null
                            ),
                        new BulletPoint(
                            text: "YouTube",
                            type: null
                            )

                    },
                    bulletPointScenario: "generic"
                );

        public static JobPosting Shared_JobPage02_JobPosting17
            = new JobPosting(
                    runId: Shared_FakeRunId,
                    pageNumber: 2,
                    response: "{\r\n            \"AutomatchType\": 0,\r\n            \"Abroad\": true,\r\n            \"Weight\": 1.0,\r\n            \"Title\": \"Leader\",\r\n            \"JobHeadline\": \"Commercial Excellence Manager\",\r\n            \"Presentation\": \" \\nCommercial Excellence Manager\\nDenmark Nordhavn, Copenhagen Local Commercial/Sales/Business Development Last application date: 5/8/2021\\nHello, this is Elijah, Betha, and Suraj and we are looking for \",\r\n            \"HiringOrgName\": \"Rederiet A.P. Møller A/S\",\r\n            \"WorkPlaceAddress\": \"\",\r\n            \"WorkPlacePostalCode\": \"\",\r\n            \"WorkPlaceCity\": \"\",\r\n            \"WorkPlaceOtherAddress\": false,\r\n            \"WorkPlaceAbroad\": false,\r\n            \"WorkPlaceNotStatic\": false,\r\n            \"UseWorkPlaceAddressForJoblog\": false,\r\n            \"PostingCreated\": \"2021-07-02T00:00:00\",\r\n            \"LastDateApplication\": \"2021-08-05T00:00:00\",\r\n            \"FormattedLastDateApplication\": \"5. august 2021\",\r\n            \"AssignmentStartDate\": \"2021-08-06T00:00:00\",\r\n            \"IsHotjob\": false,\r\n            \"IsExternal\": true,\r\n            \"Url\": \"https://jobsearch.maersk.com/jobposting/index.html?id=SV-275846\",\r\n            \"Region\": \"Hovedstaden og Bornholm\",\r\n            \"Municipality\": \"København\",\r\n            \"Country\": \"\",\r\n            \"PostalCode\": \"1000\",\r\n            \"PostalCodeName\": null,\r\n            \"JobAnnouncementType\": \"Almindelige vilkår\",\r\n            \"EmploymentType\": \"Fastansættelse\",\r\n            \"WorkHours\": \"Fuldtid\",\r\n            \"OccupationArea\": \"\",\r\n            \"OccupationGroup\": \"\",\r\n            \"Occupation\": \"\",\r\n            \"Location\": null,\r\n            \"JoblogWorkTime\": {\r\n                \"WorkHour\": null,\r\n                \"DailyWorkTime\": null\r\n            },\r\n            \"WorkplaceID\": 0,\r\n            \"OrganisationId\": \"\",\r\n            \"HiringOrgCVR\": 0,\r\n            \"UserLoggedIn\": false,\r\n            \"AnonymousEmployer\": false,\r\n            \"ShareUrl\": \"https://jobsearch.maersk.com/jobposting/index.html?id=SV-275846\",\r\n            \"DetailsUrl\": null,\r\n            \"JobLogUrl\": \"https://jobsearch.maersk.com/jobposting/index.html?id=SV-275846\",\r\n            \"HasLocationValues\": false,\r\n            \"ID\": \"E8251035\",\r\n            \"Latitude\": 0.0,\r\n            \"Longitude\": 0.0\r\n        }",
                    title: "Leader",
                    presentation: " \nCommercial Excellence Manager\nDenmark Nordhavn, Copenhagen Local Commercial/Sales/Business Development Last application date: 5/8/2021\nHello, this is Elijah, Betha, and Suraj and we are looking for ",
                    hiringOrgName: "Rederiet A.P. Møller A/S",
                    workPlaceAddress: "",
                    workPlacePostalCode: null,
                    workPlaceCity: "",
                    postingCreated: new DateTime(2021, 07, 02),
                    lastDateApplication: new DateTime(2021, 08, 05),
                    url: "https://jobsearch.maersk.com/jobposting/index.html?id=SV-275846",
                    region: "Hovedstaden og Bornholm",
                    municipality: "København",
                    country: "",
                    employmentType: "Fastansættelse",
                    workHours: "Fuldtid",
                    occupation: "",
                    workplaceId: 0,
                    organisationId: null,
                    hiringOrgCVR: 0,
                    id: 8251035,
                    workPlaceCityWithoutZone: "",
                    jobPostingNumber: 17,
                    jobPostingId: "8251035leader",
                    language: "en"
                );
        public static JobPostingExtended Shared_JobPage02_JobPostingExtended17
            = new JobPostingExtended(
                    jobPosting: Shared_JobPage02_JobPosting17,
                    response: Shared_FakeResponse,                      // Ignored
                    hiringOrgDescription: null,
                    publicationStartDate: null,
                    publicationEndDate: null,
                    purpose: Shared_FakePurpose,                        // Ignored
                    numberToFill: null,
                    contactEmail: null,
                    contactPersonName: null,
                    employmentDate: null,
                    applicationDeadlineDate: null,
                    bulletPoints: new List<BulletPoint>()
                    {

                        new BulletPoint(
                            text: "Facebook",
                            type: null
                            ),
                        new BulletPoint(
                            text: "Linkedin",
                            type: null
                            ),
                        new BulletPoint(
                            text: "Google+",
                            type: null
                            ),
                        new BulletPoint(
                            text: "Twitter",
                            type: null
                            ),
                        new BulletPoint(
                            text: "Email",
                            type: null
                            ),
                        new BulletPoint(
                            text: "Print",
                            type: null
                            )

                    },
                    bulletPointScenario: "generic"
                );

        public static JobPosting Shared_JobPage02_JobPosting18
            = new JobPosting(
                    runId: Shared_FakeRunId,
                    pageNumber: 2,
                    response: "{\r\n            \"AutomatchType\": 0,\r\n            \"Abroad\": true,\r\n            \"Weight\": 1.0,\r\n            \"Title\": \"Product Owner\",\r\n            \"JobHeadline\": \"Lead Logistics Orchestration Product Owner\",\r\n            \"Presentation\": \" \\nLead Logistics Orchestration Product Owner\\nDenmark Copenhagen Local Supply Chain/Logistics Operations Last application date: 16/7/2021\\nAs part of the core product team, the Senior Business Product M\",\r\n            \"HiringOrgName\": \"A.P. Møller - Mærsk A/S\",\r\n            \"WorkPlaceAddress\": \"\",\r\n            \"WorkPlacePostalCode\": \"\",\r\n            \"WorkPlaceCity\": \"\",\r\n            \"WorkPlaceOtherAddress\": false,\r\n            \"WorkPlaceAbroad\": false,\r\n            \"WorkPlaceNotStatic\": false,\r\n            \"UseWorkPlaceAddressForJoblog\": false,\r\n            \"PostingCreated\": \"2021-07-02T00:00:00\",\r\n            \"LastDateApplication\": \"2021-07-16T00:00:00\",\r\n            \"FormattedLastDateApplication\": \"16. juli 2021\",\r\n            \"AssignmentStartDate\": \"2021-07-17T00:00:00\",\r\n            \"IsHotjob\": false,\r\n            \"IsExternal\": true,\r\n            \"Url\": \"https://jobsearch.maersk.com/jobposting/index.html?id=MA-275792\",\r\n            \"Region\": \"Hovedstaden og Bornholm\",\r\n            \"Municipality\": \"København\",\r\n            \"Country\": \"\",\r\n            \"PostalCode\": \"1000\",\r\n            \"PostalCodeName\": null,\r\n            \"JobAnnouncementType\": \"Almindelige vilkår\",\r\n            \"EmploymentType\": \"Fastansættelse\",\r\n            \"WorkHours\": \"Fuldtid\",\r\n            \"OccupationArea\": \"\",\r\n            \"OccupationGroup\": \"\",\r\n            \"Occupation\": \"\",\r\n            \"Location\": null,\r\n            \"JoblogWorkTime\": {\r\n                \"WorkHour\": null,\r\n                \"DailyWorkTime\": null\r\n            },\r\n            \"WorkplaceID\": 0,\r\n            \"OrganisationId\": \"\",\r\n            \"HiringOrgCVR\": 0,\r\n            \"UserLoggedIn\": false,\r\n            \"AnonymousEmployer\": false,\r\n            \"ShareUrl\": \"https://jobsearch.maersk.com/jobposting/index.html?id=MA-275792\",\r\n            \"DetailsUrl\": null,\r\n            \"JobLogUrl\": \"https://jobsearch.maersk.com/jobposting/index.html?id=MA-275792\",\r\n            \"HasLocationValues\": false,\r\n            \"ID\": \"E8251034\",\r\n            \"Latitude\": 0.0,\r\n            \"Longitude\": 0.0\r\n        }",
                    title: "Product Owner",
                    presentation: " \nLead Logistics Orchestration Product Owner\nDenmark Copenhagen Local Supply Chain/Logistics Operations Last application date: 16/7/2021\nAs part of the core product team, the Senior Business Product M",
                    hiringOrgName: "A.P. Møller - Mærsk A/S",
                    workPlaceAddress: "",
                    workPlacePostalCode: null,
                    workPlaceCity: "",
                    postingCreated: new DateTime(2021, 07, 02),
                    lastDateApplication: new DateTime(2021, 07, 16),
                    url: "https://jobsearch.maersk.com/jobposting/index.html?id=MA-275792",
                    region: "Hovedstaden og Bornholm",
                    municipality: "København",
                    country: "",
                    employmentType: "Fastansættelse",
                    workHours: "Fuldtid",
                    occupation: "",
                    workplaceId: 0,
                    organisationId: null,
                    hiringOrgCVR: 0,
                    id: 8251034,
                    workPlaceCityWithoutZone: "",
                    jobPostingNumber: 18,
                    jobPostingId: "8251034productowner",
                    language: "en"
                );
        public static JobPostingExtended Shared_JobPage02_JobPostingExtended18
            = new JobPostingExtended(
                    jobPosting: Shared_JobPage02_JobPosting18,
                    response: Shared_FakeResponse,                      // Ignored
                    hiringOrgDescription: null,
                    publicationStartDate: null,
                    publicationEndDate: null,
                    purpose: Shared_FakePurpose,                        // Ignored
                    numberToFill: null,
                    contactEmail: null,
                    contactPersonName: null,
                    employmentDate: null,
                    applicationDeadlineDate: null,
                    bulletPoints: new List<BulletPoint>()
                    {

                        new BulletPoint(
                            text: "Facebook",
                            type: null
                            ),
                        new BulletPoint(
                            text: "Linkedin",
                            type: null
                            ),
                        new BulletPoint(
                            text: "Google+",
                            type: null
                            ),
                        new BulletPoint(
                            text: "Twitter",
                            type: null
                            ),
                        new BulletPoint(
                            text: "Email",
                            type: null
                            ),
                        new BulletPoint(
                            text: "Print",
                            type: null
                            )

                    },
                    bulletPointScenario: "generic"
                );

        public static JobPosting Shared_JobPage02_JobPosting19
            = new JobPosting(
                    runId: Shared_FakeRunId,
                    pageNumber: 2,
                    response: "{\r\n            \"AutomatchType\": 0,\r\n            \"Abroad\": true,\r\n            \"Weight\": 1.0,\r\n            \"Title\": \"Senior Manager\",\r\n            \"JobHeadline\": \"Senior Manager, Sales Excellence\",\r\n            \"Presentation\": \"Senior Manager, Sales Excellence\\n\\nLocation:\u00A0 Humlebæk, DK\\nJob Family:\u00A0 Marketing\\nCountry/Region:\u00A0 Denmark\\n \\nSenior Manager, Sales Excellence\u00A0\\nSales Force Excellence (Senior) Manager for our Consumer s\",\r\n            \"HiringOrgName\": \"Coloplast Danmark A/S\",\r\n            \"WorkPlaceAddress\": \"Holtedam 1\",\r\n            \"WorkPlacePostalCode\": \"3050\",\r\n            \"WorkPlaceCity\": \"Humlebæk\",\r\n            \"WorkPlaceOtherAddress\": false,\r\n            \"WorkPlaceAbroad\": false,\r\n            \"WorkPlaceNotStatic\": false,\r\n            \"UseWorkPlaceAddressForJoblog\": true,\r\n            \"PostingCreated\": \"2021-07-02T00:00:00\",\r\n            \"LastDateApplication\": \"1900-01-01T00:00:00\",\r\n            \"FormattedLastDateApplication\": \"Ikke oplyst\",\r\n            \"AssignmentStartDate\": \"2021-08-01T15:48:43.9414636+02:00\",\r\n            \"IsHotjob\": false,\r\n            \"IsExternal\": true,\r\n            \"Url\": \"https://careers.coloplast.com/job/Humlebæk-Senior-Manager,-Sales-Excellence/689406301/\",\r\n            \"Region\": \"Hovedstaden og Bornholm\",\r\n            \"Municipality\": \"Fredensborg\",\r\n            \"Country\": \"\",\r\n            \"PostalCode\": \"3050\",\r\n            \"PostalCodeName\": null,\r\n            \"JobAnnouncementType\": \"Almindelige vilkår\",\r\n            \"EmploymentType\": \"Fastansættelse\",\r\n            \"WorkHours\": \"Fuldtid\",\r\n            \"OccupationArea\": \"\",\r\n            \"OccupationGroup\": \"\",\r\n            \"Occupation\": \"\",\r\n            \"Location\": {\r\n                \"Latitude\": 55.9651,\r\n                \"Longitude\": 12.4947\r\n            },\r\n            \"JoblogWorkTime\": {\r\n                \"WorkHour\": null,\r\n                \"DailyWorkTime\": null\r\n            },\r\n            \"WorkplaceID\": 0,\r\n            \"OrganisationId\": \"\",\r\n            \"HiringOrgCVR\": 0,\r\n            \"UserLoggedIn\": false,\r\n            \"AnonymousEmployer\": false,\r\n            \"ShareUrl\": \"https://careers.coloplast.com/job/Humlebæk-Senior-Manager,-Sales-Excellence/689406301/\",\r\n            \"DetailsUrl\": null,\r\n            \"JobLogUrl\": \"https://careers.coloplast.com/job/Humlebæk-Senior-Manager,-Sales-Excellence/689406301/\",\r\n            \"HasLocationValues\": true,\r\n            \"ID\": \"E8251030\",\r\n            \"Latitude\": 55.9651,\r\n            \"Longitude\": 12.4947\r\n        }",
                    title: "Senior Manager",
                    presentation: "Senior Manager, Sales Excellence\n\nLocation:\u00A0 Humlebæk, DK\nJob Family:\u00A0 Marketing\nCountry/Region:\u00A0 Denmark\n \nSenior Manager, Sales Excellence\u00A0\nSales Force Excellence (Senior) Manager for our Consumer s",
                    hiringOrgName: "Coloplast Danmark A/S",
                    workPlaceAddress: "Holtedam 1",
                    workPlacePostalCode: 3050,
                    workPlaceCity: "Humlebæk",
                    postingCreated: new DateTime(2021, 07, 02),
                    lastDateApplication: new DateTime(1900, 01, 01),
                    url: "https://careers.coloplast.com/job/Humlebæk-Senior-Manager,-Sales-Excellence/689406301/",
                    region: "Hovedstaden og Bornholm",
                    municipality: "Fredensborg",
                    country: "",
                    employmentType: "Fastansættelse",
                    workHours: "Fuldtid",
                    occupation: "",
                    workplaceId: 0,
                    organisationId: null,
                    hiringOrgCVR: 0,
                    id: 8251030,
                    workPlaceCityWithoutZone: "Humlebæk",
                    jobPostingNumber: 19,
                    jobPostingId: "8251030seniormanager",
                    language: "en"
                );
        public static JobPostingExtended Shared_JobPage02_JobPostingExtended19
            = new JobPostingExtended(
                    jobPosting: Shared_JobPage02_JobPosting19,
                    response: Shared_FakeResponse,                      // Ignored
                    hiringOrgDescription: null,
                    publicationStartDate: null,
                    publicationEndDate: null,
                    purpose: Shared_FakePurpose,                        // Ignored
                    numberToFill: null,
                    contactEmail: null,
                    contactPersonName: null,
                    employmentDate: null,
                    applicationDeadlineDate: null,
                    bulletPoints: new List<BulletPoint>()
                    {

                        new BulletPoint(
                            text: "Set a clear direction for sales capabilities within the Consumer channel, ensure that we have the right toolbox in place for in- and outbound calls and that these align with HQ requirements",
                            type: null
                            ),
                        new BulletPoint(
                            text: "Ensure that we locally have the tools necessary to give our customers get the highest level of quality in terms of service and sales",
                            type: null
                            ),
                        new BulletPoint(
                            text: "Work with stakeholders to identify training needs and opportunities and determine what areas should be included in training modules",
                            type: null
                            ),
                        new BulletPoint(
                            text: "Motivate and develop consumer care managers",
                            type: null
                            ),
                        new BulletPoint(
                            text: "Have a couple of years of experience in a commercial role",
                            type: null
                            ),
                        new BulletPoint(
                            text: "Know your way around change management",
                            type: null
                            ),
                        new BulletPoint(
                            text: "Probably have training experience preferably from a sales or service organisation",
                            type: null
                            ),
                        new BulletPoint(
                            text: "Have impactful PowerPoint presentation skills and the ability to conduct meetings and workshops",
                            type: null
                            ),
                        new BulletPoint(
                            text: "Are fluent in English – any other languages are a plus",
                            type: null
                            )

                    },
                    bulletPointScenario: "coloplast"
                );

        public static JobPosting Shared_JobPage02_JobPosting20
            = new JobPosting(
                    runId: Shared_FakeRunId,
                    pageNumber: 2,
                    response: "{\r\n            \"AutomatchType\": 0,\r\n            \"Abroad\": true,\r\n            \"Weight\": 1.0,\r\n            \"Title\": \"Business Intelligence Analyst\",\r\n            \"JobHeadline\": \"International Business Intelligence Consultant\",\r\n            \"Presentation\": \"GN Careers\\nInternational Business Intelligence Consultant\\nBallerup\\nApply\\n\\nJabra\u00A0\u00A0Any EMEA location\\nAbout the job\\nWould you like to grow your career in a truly global role? Are you passionate about bus\",\r\n            \"HiringOrgName\": \"GN Store Nord A/S\",\r\n            \"WorkPlaceAddress\": \"Lautrupbjerg 7\",\r\n            \"WorkPlacePostalCode\": \"2750\",\r\n            \"WorkPlaceCity\": \"Ballerup\",\r\n            \"WorkPlaceOtherAddress\": false,\r\n            \"WorkPlaceAbroad\": false,\r\n            \"WorkPlaceNotStatic\": false,\r\n            \"UseWorkPlaceAddressForJoblog\": true,\r\n            \"PostingCreated\": \"2021-07-02T00:00:00\",\r\n            \"LastDateApplication\": \"2021-07-20T00:00:00\",\r\n            \"FormattedLastDateApplication\": \"20. juli 2021\",\r\n            \"AssignmentStartDate\": \"2021-07-21T00:00:00\",\r\n            \"IsHotjob\": false,\r\n            \"IsExternal\": true,\r\n            \"Url\": \"https://gn.wd3.myworkdayjobs.com/en-US/GN-Careers/job/Ballerup/International-Business-Intelligence-Consultant_R9793-1\",\r\n            \"Region\": \"Hovedstaden og Bornholm\",\r\n            \"Municipality\": \"Ballerup\",\r\n            \"Country\": \"\",\r\n            \"PostalCode\": \"2750\",\r\n            \"PostalCodeName\": null,\r\n            \"JobAnnouncementType\": \"Almindelige vilkår\",\r\n            \"EmploymentType\": \"Fastansættelse\",\r\n            \"WorkHours\": \"Fuldtid\",\r\n            \"OccupationArea\": \"\",\r\n            \"OccupationGroup\": \"\",\r\n            \"Occupation\": \"\",\r\n            \"Location\": {\r\n                \"Latitude\": 55.7387,\r\n                \"Longitude\": 12.3871\r\n            },\r\n            \"JoblogWorkTime\": {\r\n                \"WorkHour\": null,\r\n                \"DailyWorkTime\": null\r\n            },\r\n            \"WorkplaceID\": 0,\r\n            \"OrganisationId\": \"\",\r\n            \"HiringOrgCVR\": 0,\r\n            \"UserLoggedIn\": false,\r\n            \"AnonymousEmployer\": false,\r\n            \"ShareUrl\": \"https://gn.wd3.myworkdayjobs.com/en-US/GN-Careers/job/Ballerup/International-Business-Intelligence-Consultant_R9793-1\",\r\n            \"DetailsUrl\": null,\r\n            \"JobLogUrl\": \"https://gn.wd3.myworkdayjobs.com/en-US/GN-Careers/job/Ballerup/International-Business-Intelligence-Consultant_R9793-1\",\r\n            \"HasLocationValues\": true,\r\n            \"ID\": \"E8251029\",\r\n            \"Latitude\": 55.7387,\r\n            \"Longitude\": 12.3871\r\n        }",
                    title: "Business Intelligence Analyst",
                    presentation: "GN Careers\nInternational Business Intelligence Consultant\nBallerup\nApply\n\nJabra\u00A0\u00A0Any EMEA location\nAbout the job\nWould you like to grow your career in a truly global role? Are you passionate about bus",
                    hiringOrgName: "GN Store Nord A/S",
                    workPlaceAddress: "Lautrupbjerg 7",
                    workPlacePostalCode: 2750,
                    workPlaceCity: "Ballerup",
                    postingCreated: new DateTime(2021, 07, 02),
                    lastDateApplication: new DateTime(2021, 07, 20),
                    url: "https://gn.wd3.myworkdayjobs.com/en-US/GN-Careers/job/Ballerup/International-Business-Intelligence-Consultant_R9793-1",
                    region: "Hovedstaden og Bornholm",
                    municipality: "Ballerup",
                    country: "",
                    employmentType: "Fastansættelse",
                    workHours: "Fuldtid",
                    occupation: "",
                    workplaceId: 0,
                    organisationId: null,
                    hiringOrgCVR: 0,
                    id: 8251029,
                    workPlaceCityWithoutZone: "Ballerup",
                    jobPostingNumber: 20,
                    jobPostingId: "8251029businessintelligenceanalyst",
                    language: "en"
                );
        public static JobPostingExtended Shared_JobPage02_JobPostingExtended20
            = new JobPostingExtended(
                    jobPosting: Shared_JobPage02_JobPosting20,
                    response: Shared_FakeResponse,                      // Ignored
                    hiringOrgDescription: null,
                    publicationStartDate: null,
                    publicationEndDate: null,
                    purpose: Shared_FakePurpose,                        // Ignored
                    numberToFill: null,
                    contactEmail: null,
                    contactPersonName: null,
                    employmentDate: null,
                    applicationDeadlineDate: null,
                    bulletPoints: null,
                    bulletPointScenario: null
                );

        public static List<JobPosting> Shared_JobPage02_JobPostings
            = new List<JobPosting>()
            {
                Shared_JobPage02_JobPosting01,
                Shared_JobPage02_JobPosting02,
                Shared_JobPage02_JobPosting03,
                Shared_JobPage02_JobPosting04,
                Shared_JobPage02_JobPosting05,
                Shared_JobPage02_JobPosting06,
                Shared_JobPage02_JobPosting07,
                Shared_JobPage02_JobPosting08,
                Shared_JobPage02_JobPosting09,
                Shared_JobPage02_JobPosting10,
                Shared_JobPage02_JobPosting11,
                Shared_JobPage02_JobPosting12,
                Shared_JobPage02_JobPosting13,
                Shared_JobPage02_JobPosting14,
                Shared_JobPage02_JobPosting15,
                Shared_JobPage02_JobPosting16,
                Shared_JobPage02_JobPosting17,
                Shared_JobPage02_JobPosting18,
                Shared_JobPage02_JobPosting19,
                Shared_JobPage02_JobPosting20
            };
        public static List<JobPostingExtended> Shared_JobPage02_JobPostingsExtended
            = new List<JobPostingExtended>()
            {
                Shared_JobPage02_JobPostingExtended01,
                Shared_JobPage02_JobPostingExtended02,
                Shared_JobPage02_JobPostingExtended03,
                Shared_JobPage02_JobPostingExtended04,
                Shared_JobPage02_JobPostingExtended05,
                Shared_JobPage02_JobPostingExtended06,
                Shared_JobPage02_JobPostingExtended07,
                Shared_JobPage02_JobPostingExtended08,
                Shared_JobPage02_JobPostingExtended09,
                Shared_JobPage02_JobPostingExtended10,
                Shared_JobPage02_JobPostingExtended11,
                Shared_JobPage02_JobPostingExtended12,
                Shared_JobPage02_JobPostingExtended13,
                Shared_JobPage02_JobPostingExtended14,
                Shared_JobPage02_JobPostingExtended15,
                Shared_JobPage02_JobPostingExtended16,
                Shared_JobPage02_JobPostingExtended17,
                Shared_JobPage02_JobPostingExtended18,
                Shared_JobPage02_JobPostingExtended19,
                Shared_JobPage02_JobPostingExtended20
            };

        public static JobPage Shared_JobPage02_Object
            = new JobPage(Shared_FakeRunId, 2, Shared_JobPage02_Content);

        public static ushort Shared_JobPage02_TotalResultCount = 2177;

        #endregion

        #region Shared_JobPage01Alt

        public static string Shared_JobPage01Alt_Url = Shared_JobPage01_BodyUrl;
        public static string Shared_JobPage01Alt_Content = Properties.Resources.JobPage01Alt_json;

        public static JobPosting Shared_JobPage01Alt_JobPosting01 = Shared_JobPage01_JobPosting01; // 2021-07-02
        public static JobPosting Shared_JobPage01Alt_JobPosting02 = Shared_JobPage01_JobPosting02; // 2021-07-02
        public static JobPosting Shared_JobPage01Alt_JobPosting03 = Shared_JobPage01_JobPosting03; // 2021-07-02
        public static JobPosting Shared_JobPage01Alt_JobPosting04 = Shared_JobPage01_JobPosting04; // 2021-07-02
        public static JobPosting Shared_JobPage01Alt_JobPosting05 = Shared_JobPage01_JobPosting05; // 2021-07-02
        public static JobPosting Shared_JobPage01Alt_JobPosting06 = Shared_JobPage01_JobPosting06; // 2021-07-02

        public static JobPosting Shared_JobPage01Alt_JobPosting07 
            = UpdatePostingCreatedResponse(Shared_JobPage01_JobPosting07, Shared_JobPage01_JobPosting01.PostingCreated.AddDays(-1));    // 2021-07-01
        public static JobPosting Shared_JobPage01Alt_JobPosting08 
            = UpdatePostingCreatedResponse(Shared_JobPage01_JobPosting08, Shared_JobPage01_JobPosting01.PostingCreated.AddDays(-1));    // 2021-07-01
        public static JobPosting Shared_JobPage01Alt_JobPosting09 
            = UpdatePostingCreatedResponse(Shared_JobPage01_JobPosting09, Shared_JobPage01_JobPosting01.PostingCreated.AddDays(-1));    // 2021-07-01
        public static JobPosting Shared_JobPage01Alt_JobPosting10 
            = UpdatePostingCreatedResponse(Shared_JobPage01_JobPosting10, Shared_JobPage01_JobPosting01.PostingCreated.AddDays(-1));    // 2021-07-01
        public static JobPosting Shared_JobPage01Alt_JobPosting11 
            = UpdatePostingCreatedResponse(Shared_JobPage01_JobPosting11, Shared_JobPage01_JobPosting01.PostingCreated.AddDays(-1));    // 2021-07-01

        public static JobPosting Shared_JobPage01Alt_JobPosting12 
            = UpdatePostingCreatedResponse(Shared_JobPage01_JobPosting12, Shared_JobPage01_JobPosting01.PostingCreated.AddDays(-2));    // 2021-06-30
        public static JobPosting Shared_JobPage01Alt_JobPosting13 
            = UpdatePostingCreatedResponse(Shared_JobPage01_JobPosting13, Shared_JobPage01_JobPosting01.PostingCreated.AddDays(-2));    // 2021-06-30
        public static JobPosting Shared_JobPage01Alt_JobPosting14 
            = UpdatePostingCreatedResponse(Shared_JobPage01_JobPosting14, Shared_JobPage01_JobPosting01.PostingCreated.AddDays(-2));    // 2021-06-30
        public static JobPosting Shared_JobPage01Alt_JobPosting15 
            = UpdatePostingCreatedResponse(Shared_JobPage01_JobPosting15, Shared_JobPage01_JobPosting01.PostingCreated.AddDays(-2));    // 2021-06-30

        public static JobPosting Shared_JobPage01Alt_JobPosting16 
            = UpdatePostingCreatedResponse(Shared_JobPage01_JobPosting16, Shared_JobPage01_JobPosting01.PostingCreated.AddDays(-3));    // 2021-06-29
        public static JobPosting Shared_JobPage01Alt_JobPosting17 
            = UpdatePostingCreatedResponse(Shared_JobPage01_JobPosting17, Shared_JobPage01_JobPosting01.PostingCreated.AddDays(-3));    // 2021-06-29
        public static JobPosting Shared_JobPage01Alt_JobPosting18 
            = UpdatePostingCreatedResponse(Shared_JobPage01_JobPosting18, Shared_JobPage01_JobPosting01.PostingCreated.AddDays(-3));    // 2021-06-29

        public static JobPosting Shared_JobPage01Alt_JobPosting19 
            = UpdatePostingCreatedResponse(Shared_JobPage01_JobPosting19, Shared_JobPage01_JobPosting01.PostingCreated.AddDays(-4));    // 2021-06-28
        public static JobPosting Shared_JobPage01Alt_JobPosting20 
            = UpdatePostingCreatedResponse(Shared_JobPage01_JobPosting20, Shared_JobPage01_JobPosting01.PostingCreated.AddDays(-4));    // 2021-06-28

        public static List<JobPosting> Shared_JobPage01Alt_JobPostings
            = new List<JobPosting>()
            {
                Shared_JobPage01Alt_JobPosting01,  // 2021-07-02
                Shared_JobPage01Alt_JobPosting02,  // 2021-07-02
                Shared_JobPage01Alt_JobPosting03,  // 2021-07-02
                Shared_JobPage01Alt_JobPosting04,  // 2021-07-02
                Shared_JobPage01Alt_JobPosting05,  // 2021-07-02
                Shared_JobPage01Alt_JobPosting06,  // 2021-07-02

                Shared_JobPage01Alt_JobPosting07,  // 2021-07-01
                Shared_JobPage01Alt_JobPosting08,  // 2021-07-01
                Shared_JobPage01Alt_JobPosting09,  // 2021-07-01
                Shared_JobPage01Alt_JobPosting10,  // 2021-07-01
                Shared_JobPage01Alt_JobPosting11,  // 2021-07-01

                Shared_JobPage01Alt_JobPosting12,  // 2021-06-30
                Shared_JobPage01Alt_JobPosting13,  // 2021-06-30
                Shared_JobPage01Alt_JobPosting14,  // 2021-06-30
                Shared_JobPage01Alt_JobPosting15,  // 2021-06-30

                Shared_JobPage01Alt_JobPosting16,  // 2021-06-29
                Shared_JobPage01Alt_JobPosting17,  // 2021-06-29
                Shared_JobPage01Alt_JobPosting18,  // 2021-06-29

                Shared_JobPage01Alt_JobPosting19,  // 2021-06-28
                Shared_JobPage01Alt_JobPosting20   // 2021-06-28
            };

        public static JobPage Shared_JobPage01Alt_Object
            = new JobPage(Shared_FakeRunId, 1, Shared_JobPage01Alt_Content);

        public static DateTime Shared_JobPage01Alt_ThresholdDate01
            = Shared_JobPage01Alt_JobPostings[6].PostingCreated;                     // 2021-07-01
        public static List<JobPosting> Shared_JobPage01Alt_RangeForThresholdDate01
            = Shared_JobPage01Alt_JobPostings.GetRange(0, 11);                       // 2021-07-02 ... (2021-06-30)

        #endregion

        #region Shared_JobPage01_Entities

        public static List<JobPostingEntity> Shared_JobPage01_JobPostingEntities = new List<JobPostingEntity>()
        {

            new JobPostingEntity(Shared_JobPage01_JobPosting01),
            new JobPostingEntity(Shared_JobPage01_JobPosting02),
            new JobPostingEntity(Shared_JobPage01_JobPosting03),
            new JobPostingEntity(Shared_JobPage01_JobPosting04),
            new JobPostingEntity(Shared_JobPage01_JobPosting05),
            new JobPostingEntity(Shared_JobPage01_JobPosting06),
            new JobPostingEntity(Shared_JobPage01_JobPosting07),
            new JobPostingEntity(Shared_JobPage01_JobPosting08),
            new JobPostingEntity(Shared_JobPage01_JobPosting09),
            new JobPostingEntity(Shared_JobPage01_JobPosting10),
            new JobPostingEntity(Shared_JobPage01_JobPosting11),
            new JobPostingEntity(Shared_JobPage01_JobPosting12),
            new JobPostingEntity(Shared_JobPage01_JobPosting13),
            new JobPostingEntity(Shared_JobPage01_JobPosting14),
            new JobPostingEntity(Shared_JobPage01_JobPosting15),
            new JobPostingEntity(Shared_JobPage01_JobPosting16),
            new JobPostingEntity(Shared_JobPage01_JobPosting17),
            new JobPostingEntity(Shared_JobPage01_JobPosting18),
            new JobPostingEntity(Shared_JobPage01_JobPosting19),
            new JobPostingEntity(Shared_JobPage01_JobPosting20)

        };
        public static JobPostingEntity Shared_JobPage01_JobPostingEntity01
            = Shared_JobPage01_JobPostingEntities[0];
        public static JobPostingEntity Shared_JobPage01_JobPostingEntity02
            = Shared_JobPage01_JobPostingEntities[1];
        public static JobPostingEntity Shared_JobPage01_JobPostingEntity01WithUpdatedPostingCreated
            = new JobPostingEntity(
                    UpdatePostingCreatedResponse(
                        Shared_JobPage01_JobPostings[0],
                        Shared_JobPage01_JobPostingEntities[0].PostingCreated.AddDays(1)));

        public static JobPostingExtendedEntity Shared_JobPage01_JobPostingExtendedEntity01
            = new JobPostingExtendedEntity(Shared_JobPage01_JobPostingExtended01);
        public static List<JobPostingExtendedEntity> Shared_JobPage01_JobPostingExtendedEntities
            = new List<JobPostingExtendedEntity>()
            {
                new JobPostingExtendedEntity(Shared_JobPage01_JobPostingExtended01),
                new JobPostingExtendedEntity(Shared_JobPage01_JobPostingExtended02),
                new JobPostingExtendedEntity(Shared_JobPage01_JobPostingExtended03),
                new JobPostingExtendedEntity(Shared_JobPage01_JobPostingExtended04),
                new JobPostingExtendedEntity(Shared_JobPage01_JobPostingExtended05),
                new JobPostingExtendedEntity(Shared_JobPage01_JobPostingExtended06),
                new JobPostingExtendedEntity(Shared_JobPage01_JobPostingExtended07),
                new JobPostingExtendedEntity(Shared_JobPage01_JobPostingExtended08),
                new JobPostingExtendedEntity(Shared_JobPage01_JobPostingExtended09),
                new JobPostingExtendedEntity(Shared_JobPage01_JobPostingExtended10),
                new JobPostingExtendedEntity(Shared_JobPage01_JobPostingExtended11),
                new JobPostingExtendedEntity(Shared_JobPage01_JobPostingExtended12),
                new JobPostingExtendedEntity(Shared_JobPage01_JobPostingExtended13),
                new JobPostingExtendedEntity(Shared_JobPage01_JobPostingExtended14),
                new JobPostingExtendedEntity(Shared_JobPage01_JobPostingExtended15),
                new JobPostingExtendedEntity(Shared_JobPage01_JobPostingExtended16),
                new JobPostingExtendedEntity(Shared_JobPage01_JobPostingExtended17),
                new JobPostingExtendedEntity(Shared_JobPage01_JobPostingExtended18),
                new JobPostingExtendedEntity(Shared_JobPage01_JobPostingExtended19),
                new JobPostingExtendedEntity(Shared_JobPage01_JobPostingExtended20)
            };

        public static BulletPointEntity Shared_JobPage01_JobPostingExtended01BulletPointEntity01
            = new BulletPointEntity(
                    Shared_JobPage01_JobPostingExtended01.JobPosting.JobPostingId,
                    Shared_JobPage01_JobPostingExtended01.BulletPoints.ToList()[0]);
        public static List<BulletPointEntity> Shared_JobPage01_JobPostingExtended01BulletPointEntities
            = Shared_JobPage01_JobPostingExtended01
                .BulletPoints
                .Select(bulletPoint => new BulletPointEntity(Shared_JobPage01_JobPostingExtended01.JobPosting.JobPostingId, bulletPoint))
                .ToList();

        #endregion

        #region Shared_JobPage02_Entities

        #endregion

        #region Shared_ExplorationTests

        public static string Shared_ExplorationStage1_RunId = Shared_FakeRunId;
        public static ushort Shared_ExplorationStage1_TotalResultCount = Shared_JobPage01_TotalResultCount;
        public static ushort Shared_ExplorationStage1_TotalJobPages = Shared_JobPage01_TotalJobPages;
        public static Stages Shared_ExplorationStage1_Stage = Stages.Stage1_OnlyMetrics;
        public static bool Shared_ExplorationStage1_IsCompleted = true;
        public static List<JobPage> Shared_ExplorationStage1_JobPages 
            = new List<JobPage>()
            { 
                Shared_JobPage01_Object
            };
        public static List<JobPosting> Shared_ExplorationStage1_JobPostings = null;
        public static List<JobPostingExtended> Shared_ExplorationStage1_JobPostingsExtended = null;
        public static Exploration Shared_ExplorationStage1
            = new Exploration(
                    Shared_ExplorationStage1_RunId,
                    Shared_ExplorationStage1_TotalResultCount,
                    Shared_ExplorationStage1_TotalJobPages,
                    Stages.Stage1_OnlyMetrics,
                    Shared_ExplorationStage1_IsCompleted,
                    Shared_ExplorationStage1_JobPages,
                    Shared_ExplorationStage1_JobPostings,
                    Shared_ExplorationStage1_JobPostingsExtended
                    );
        public static string Shared_ExplorationStage1_AsString
            = string.Concat(
                "{ ",
                $"'{nameof(Exploration.RunId)}':'{Shared_ExplorationStage1_RunId}', ",
                $"'{nameof(Exploration.TotalResultCount)}':'{Shared_ExplorationStage1_TotalResultCount}', ",
                $"'{nameof(Exploration.TotalJobPages)}':'{Shared_ExplorationStage1_TotalJobPages}', ",
                $"'{nameof(Exploration.Stage)}':'{Shared_ExplorationStage1_Stage}', ",
                $"'{nameof(Exploration.IsCompleted)}':'{Shared_ExplorationStage1_IsCompleted}', ",
                $"'{nameof(Exploration.JobPages)}':'1', ",
                $"'{nameof(Exploration.JobPostings)}':'null', ",
                $"'{nameof(Exploration.JobPostingsExtended)}':'null'",
                " }"
                );

        public static string Shared_ExplorationStage2_RunId = Shared_FakeRunId;
        public static ushort Shared_ExplorationStage2_TotalResultCount = Shared_JobPage01_TotalResultCount;
        public static ushort Shared_ExplorationStage2_TotalJobPages = Shared_JobPage01_TotalJobPages;
        public static Stages Shared_ExplorationStage2_Stage = Stages.Stage2_UpToAllJobPostings;
        public static bool Shared_ExplorationStage2_IsCompleted = true;
        public static List<JobPage> Shared_ExplorationStage2_JobPages
            = new List<JobPage>()
            {
                Shared_JobPage01_Object,
                Shared_JobPage02_Object
            };
        public static List<JobPosting> Shared_ExplorationStage2_JobPostings
            = new List<JobPosting>()
            {
                Shared_JobPage01_JobPosting01,
                Shared_JobPage01_JobPosting02,
                Shared_JobPage01_JobPosting03,
                Shared_JobPage01_JobPosting04,
                Shared_JobPage01_JobPosting05,
                Shared_JobPage01_JobPosting06,
                Shared_JobPage01_JobPosting07,
                Shared_JobPage01_JobPosting08,
                Shared_JobPage01_JobPosting09,
                Shared_JobPage01_JobPosting10,
                Shared_JobPage01_JobPosting11,
                Shared_JobPage01_JobPosting12,
                Shared_JobPage01_JobPosting13,
                Shared_JobPage01_JobPosting14,
                Shared_JobPage01_JobPosting15,
                Shared_JobPage01_JobPosting16,
                Shared_JobPage01_JobPosting17,
                Shared_JobPage01_JobPosting18,
                Shared_JobPage01_JobPosting19,
                Shared_JobPage01_JobPosting20,
                Shared_JobPage02_JobPosting01,
                Shared_JobPage02_JobPosting02,
                Shared_JobPage02_JobPosting03,
                Shared_JobPage02_JobPosting04,
                Shared_JobPage02_JobPosting05,
                Shared_JobPage02_JobPosting06,
                Shared_JobPage02_JobPosting07,
                Shared_JobPage02_JobPosting08,
                Shared_JobPage02_JobPosting09,
                Shared_JobPage02_JobPosting10,
                Shared_JobPage02_JobPosting11,
                Shared_JobPage02_JobPosting12,
                Shared_JobPage02_JobPosting13,
                Shared_JobPage02_JobPosting14,
                Shared_JobPage02_JobPosting15,
                Shared_JobPage02_JobPosting16,
                Shared_JobPage02_JobPosting17,
                Shared_JobPage02_JobPosting18,
                Shared_JobPage02_JobPosting19,
                Shared_JobPage02_JobPosting20
            };
        public static List<JobPostingExtended> Shared_ExplorationStage2_JobPostingsExtended = null;
        public static Exploration Shared_ExplorationStage2
            = new Exploration(
                    Shared_ExplorationStage2_RunId,
                    Shared_ExplorationStage2_TotalResultCount,
                    Shared_ExplorationStage2_TotalJobPages,
                    Stages.Stage2_UpToAllJobPostings,
                    Shared_ExplorationStage2_IsCompleted,
                    Shared_ExplorationStage2_JobPages,
                    Shared_ExplorationStage2_JobPostings,
                    Shared_ExplorationStage2_JobPostingsExtended
                    );
        public static string Shared_ExplorationStage2_AsString
            = string.Concat(
                "{ ",
                $"'{nameof(Exploration.RunId)}':'{Shared_ExplorationStage2_RunId}', ",
                $"'{nameof(Exploration.TotalResultCount)}':'{Shared_ExplorationStage2_TotalResultCount}', ",
                $"'{nameof(Exploration.TotalJobPages)}':'{Shared_ExplorationStage2_TotalJobPages}', ",
                $"'{nameof(Exploration.Stage)}':'{Shared_ExplorationStage2_Stage}', ",
                $"'{nameof(Exploration.IsCompleted)}':'{Shared_ExplorationStage2_IsCompleted}', ",
                $"'{nameof(Exploration.JobPages)}':'2', ",
                $"'{nameof(Exploration.JobPostings)}':'40', ",
                $"'{nameof(Exploration.JobPostingsExtended)}':'null'",
                " }"
                );

        public static string Shared_ExplorationStage3_RunId = Shared_FakeRunId;
        public static ushort Shared_ExplorationStage3_TotalResultCount = Shared_JobPage01_TotalResultCount;
        public static ushort Shared_ExplorationStage3_TotalJobPages = Shared_JobPage01_TotalJobPages;
        public static Stages Shared_ExplorationStage3_Stage = Stages.Stage3_UpToAllJobPostingsExtended;
        public static bool Shared_ExplorationStage3_IsCompleted = true;
        public static List<JobPage> Shared_ExplorationStage3_JobPages
            = new List<JobPage>()
            {
                Shared_JobPage01_Object,
                Shared_JobPage02_Object
            };
        public static List<JobPosting> Shared_ExplorationStage3_JobPostings
            = new List<JobPosting>()
            {
                Shared_JobPage01_JobPosting01,
                Shared_JobPage01_JobPosting02,
                Shared_JobPage01_JobPosting03,
                Shared_JobPage01_JobPosting04,
                Shared_JobPage01_JobPosting05,
                Shared_JobPage01_JobPosting06,
                Shared_JobPage01_JobPosting07,
                Shared_JobPage01_JobPosting08,
                Shared_JobPage01_JobPosting09,
                Shared_JobPage01_JobPosting10,
                Shared_JobPage01_JobPosting11,
                Shared_JobPage01_JobPosting12,
                Shared_JobPage01_JobPosting13,
                Shared_JobPage01_JobPosting14,
                Shared_JobPage01_JobPosting15,
                Shared_JobPage01_JobPosting16,
                Shared_JobPage01_JobPosting17,
                Shared_JobPage01_JobPosting18,
                Shared_JobPage01_JobPosting19,
                Shared_JobPage01_JobPosting20,
                Shared_JobPage02_JobPosting01,
                Shared_JobPage02_JobPosting02,
                Shared_JobPage02_JobPosting03,
                Shared_JobPage02_JobPosting04,
                Shared_JobPage02_JobPosting05,
                Shared_JobPage02_JobPosting06,
                Shared_JobPage02_JobPosting07,
                Shared_JobPage02_JobPosting08,
                Shared_JobPage02_JobPosting09,
                Shared_JobPage02_JobPosting10,
                Shared_JobPage02_JobPosting11,
                Shared_JobPage02_JobPosting12,
                Shared_JobPage02_JobPosting13,
                Shared_JobPage02_JobPosting14,
                Shared_JobPage02_JobPosting15,
                Shared_JobPage02_JobPosting16,
                Shared_JobPage02_JobPosting17,
                Shared_JobPage02_JobPosting18,
                Shared_JobPage02_JobPosting19,
                Shared_JobPage02_JobPosting20
            };
        public static List<JobPostingExtended> Shared_ExplorationStage3_JobPostingsExtended
            = new List<JobPostingExtended>()
            {
                Shared_JobPage01_JobPostingExtended01,
                Shared_JobPage01_JobPostingExtended02,
                Shared_JobPage01_JobPostingExtended03,
                Shared_JobPage01_JobPostingExtended04,
                Shared_JobPage01_JobPostingExtended05,
                Shared_JobPage01_JobPostingExtended06,
                Shared_JobPage01_JobPostingExtended07,
                Shared_JobPage01_JobPostingExtended08,
                Shared_JobPage01_JobPostingExtended09,
                Shared_JobPage01_JobPostingExtended10,
                Shared_JobPage01_JobPostingExtended11,
                Shared_JobPage01_JobPostingExtended12,
                Shared_JobPage01_JobPostingExtended13,
                Shared_JobPage01_JobPostingExtended14,
                Shared_JobPage01_JobPostingExtended15,
                Shared_JobPage01_JobPostingExtended16,
                Shared_JobPage01_JobPostingExtended17,
                Shared_JobPage01_JobPostingExtended18,
                Shared_JobPage01_JobPostingExtended19,
                Shared_JobPage01_JobPostingExtended20,
                Shared_JobPage02_JobPostingExtended01,
                Shared_JobPage02_JobPostingExtended02,
                Shared_JobPage02_JobPostingExtended03,
                Shared_JobPage02_JobPostingExtended04,
                Shared_JobPage02_JobPostingExtended05,
                Shared_JobPage02_JobPostingExtended06,
                Shared_JobPage02_JobPostingExtended07,
                Shared_JobPage02_JobPostingExtended08,
                Shared_JobPage02_JobPostingExtended09,
                Shared_JobPage02_JobPostingExtended10,
                Shared_JobPage02_JobPostingExtended11,
                Shared_JobPage02_JobPostingExtended12,
                Shared_JobPage02_JobPostingExtended13,
                Shared_JobPage02_JobPostingExtended14,
                Shared_JobPage02_JobPostingExtended15,
                Shared_JobPage02_JobPostingExtended16,
                Shared_JobPage02_JobPostingExtended17,
                Shared_JobPage02_JobPostingExtended18,
                Shared_JobPage02_JobPostingExtended19,
                Shared_JobPage02_JobPostingExtended20
            };
        public static Exploration Shared_ExplorationStage3
            = new Exploration(
                    Shared_ExplorationStage3_RunId,
                    Shared_ExplorationStage3_TotalResultCount,
                    Shared_ExplorationStage3_TotalJobPages,
                    Shared_ExplorationStage3_Stage,
                    Shared_ExplorationStage3_IsCompleted,
                    Shared_ExplorationStage3_JobPages,
                    Shared_ExplorationStage3_JobPostings,
                    Shared_ExplorationStage3_JobPostingsExtended
                    );
        public static string Shared_ExplorationStage3_AsString
            = string.Concat(
                "{ ",
                $"'{nameof(Exploration.RunId)}':'{Shared_ExplorationStage3_RunId}', ",
                $"'{nameof(Exploration.TotalResultCount)}':'{Shared_ExplorationStage3_TotalResultCount}', ",
                $"'{nameof(Exploration.TotalJobPages)}':'{Shared_ExplorationStage3_TotalJobPages}', ",
                $"'{nameof(Exploration.Stage)}':'{Shared_ExplorationStage3_Stage}', ",
                $"'{nameof(Exploration.IsCompleted)}':'{Shared_ExplorationStage3_IsCompleted}', ",
                $"'{nameof(Exploration.JobPages)}':'{Shared_ExplorationStage3_JobPages.Count}', ",
                $"'{nameof(Exploration.JobPostings)}':'{Shared_ExplorationStage3_JobPostings.Count}', ",
                $"'{nameof(Exploration.JobPostingsExtended)}':'{Shared_ExplorationStage3_JobPostingsExtended.Count}'",
                " }"
                );
        public static uint Shared_ExplorationStage3_TotalBulletPoints
            = (uint)Shared_ExplorationStage3_JobPostingsExtended.Select( jobPostingExtended => jobPostingExtended.BulletPoints?.Count ?? 0).Sum();

        #endregion

        #region DatabaseContextTests

        public static string DatabaseContext_DatabasePath = @"c:\";
        public static string DatabaseContext_DatabaseName01 = "widjobs.db";
        public static string DatabaseContext_DatabaseName02 = "widjobs";
        public static string DatabaseContext_ConnectionString
            = DatabaseContext.ConnectionStringTemplate.Invoke(@"c:\widjobs.db");

        #endregion

        #region DbSetExtensionMethodsTests

        public static DatabaseContext DbSetExtensionMethods_InMemoryDatabaseContext
            = CreateInMemoryContext();
        public static List<JobPostingEntity> DbSetExtensionMethods_NotExistingPageItemEntities;

        #endregion

        #region FileManagerTests

        public static string FileManager_ContentSingleLine = "First line";
        public static IEnumerable<string> FileManager_ContentMultipleLines =
            new List<string>() {
                "First line",
                "Second line"
            };
        public static string FileManager_FileInfoAdapterFullName = @"C:\somefile.txt";
        public static IFileInfoAdapter FileManager_FileInfoAdapterDoesntExist
            => new FakeFileInfoAdapter(false, FileManager_FileInfoAdapterFullName);
        public static IFileInfoAdapter FileManager_FileInfoAdapterExists
            => new FakeFileInfoAdapter(true, FileManager_FileInfoAdapterFullName);
        public static IOException FileManager_FileAdapterIOException = new IOException("Impossible to access the file.");
        public static IFileAdapter FileManager_FileAdapterReadAllMethodsThrowIOException
            => new FakeFileAdapter(
                    fakeReadAllLines: () => throw FileManager_FileAdapterIOException,
                    fakeReadAllText: () => throw FileManager_FileAdapterIOException
                );
        public static IFileAdapter FileManager_FileAdapterWriteAllMethodsThrowIOException
            => new FakeFileAdapter(
                    fakeWriteAllLines: () => throw FileManager_FileAdapterIOException,
                    fakeWriteAllText: () => throw FileManager_FileAdapterIOException
                );
        public static IFileAdapter FileManager_FileAdapterAllMethodsWork
            => new FakeFileAdapter(
                    fakeReadAllLines: () => FileManager_ContentMultipleLines.ToArray(),
                    fakeReadAllText: () => FileManager_ContentSingleLine,
                    fakeWriteAllLines: () => { },
                    fakeWriteAllText: () => { }
                );

        #endregion

        #region FileNameFactoryTests

        public static string FileNameFactory_FakeFilePath = @"C:\";
        public static string FileNameFactory_FakeToken = "fake";
        public static DateTime FileNameFactory_FakeNow = new DateTime(2021, 05, 01);
        public static string FileNameFactory_FakeNowString
            = FileNameFactory_FakeNow.ToString(FilenameFactory.DefaultFormatNow);

        public static string FileNameFactory_FakeDatabaseFileName = "fakedb.db";

        public static string FileNameFactory_DatabaseNameIfFilePath
            = string.Concat(
                        FileNameFactory_FakeFilePath,
                        FilenameFactory.DefaultDatabaseToken,
                        ".",
                        FilenameFactory.DefaultDatabaseExtension
                        );
        public static string FileNameFactory_DatabaseNameIfFilePathFileName
            = string.Concat(
                        FileNameFactory_FakeFilePath,
                        FileNameFactory_FakeDatabaseFileName
                        );
        public static string FileNameFactory_DatabaseNameIfFilePathTokenNow
            = string.Concat(
                        FileNameFactory_FakeFilePath,
                        FileNameFactory_FakeToken,
                        "_",
                        FileNameFactory_FakeNowString,
                        ".",
                        FilenameFactory.DefaultDatabaseExtension
                        );
        public static string FileNameFactory_DatabaseNameIfFilePathNow
            = string.Concat(
                        FileNameFactory_FakeFilePath,
                        FilenameFactory.DefaultDatabaseToken,
                        "_",
                        FileNameFactory_FakeNowString,
                        ".",
                        FilenameFactory.DefaultDatabaseExtension
                        );

        public static string FileNameFactory_MetricCollectionJsonIfTrue
            = string.Concat(
                        FileNameFactory_FakeFilePath,
                        FilenameFactory.DefaultMetricCollectionPctJsonToken,
                        "_",
                        FileNameFactory_FakeNowString,
                        ".",
                        FilenameFactory.DefaultJsonExtension
                        );
        public static string FileNameFactory_MetricCollectionJsonIfFalse
            = string.Concat(
                        FileNameFactory_FakeFilePath,
                        FilenameFactory.DefaultMetricCollectionJsonToken,
                        "_",
                        FileNameFactory_FakeNowString,
                        ".",
                        FilenameFactory.DefaultJsonExtension
                        );

        public static string FileNameFactory_ExplorationJsonIfFilePathNow
            = string.Concat(
                        FileNameFactory_FakeFilePath,
                        FilenameFactory.DefaultExplorationJsonToken,
                        "_",
                        FileNameFactory_FakeNowString,
                        ".",
                        FilenameFactory.DefaultJsonExtension
                        );
        public static string FileNameFactory_BulletPointsJsonIfFilePathNow
            = string.Concat(
                        FileNameFactory_FakeFilePath,
                        FilenameFactory.DefaultBulletPointTypesToken,
                        "_",
                        FileNameFactory_FakeNowString,
                        ".",
                        FilenameFactory.DefaultJsonExtension
                        );


        #endregion

        #region JobPostingManagerTests

        public static List<DateTime> JobPostingManager_JobPage01Alt_PostingCreatedCollection
            = Shared_JobPage01Alt_JobPostings.Select(jobPosting => jobPosting.PostingCreated).ToList();
        public static DateTime JobPostingManager_JobPage01Alt_ThresholdDateMostRecentPostingCreated
            = JobPostingManager_JobPage01Alt_PostingCreatedCollection.First();
        public static DateTime JobPostingManager_JobPage01Alt_ThresholdDateMostRecentPostingCreatedPlusOneDay
            = JobPostingManager_JobPage01Alt_ThresholdDateMostRecentPostingCreated.AddDays(1);
        public static DateTime JobPostingManager_JobPage01Alt_ThresholdDateMostRecentPostingCreatedMinusOneDay
            = JobPostingManager_JobPage01Alt_ThresholdDateMostRecentPostingCreated.AddDays(-1);
        public static DateTime JobPostingManager_JobPage01Alt_ThresholdDateLeastRecentPostingCreated
            = Shared_JobPage01Alt_JobPostings.OrderByDescending(jobPosting => jobPosting.PostingCreated).Reverse().First().PostingCreated;
        public static DateTime JobPostingManager_JobPage01Alt_ThresholdDateLeastRecentPostingCreatedMinusOneDay
            = JobPostingManager_JobPage01Alt_ThresholdDateLeastRecentPostingCreated.AddDays(-1);

        #endregion

        #region MetricCollectionTests

        public static string MetricCollection_ExplorationStage3_RunId 
            = Shared_ExplorationStage3.RunId;
        public static uint MetricCollection_ExplorationStage3_TotalJobPages 
            = (uint)Shared_ExplorationStage3.JobPages.Count;
        public static uint MetricCollection_ExplorationStage3_TotalJobPostings 
            = (uint)Shared_ExplorationStage3.JobPostings.Count;

        public static Dictionary<string, uint> MetricCollection_ExplorationStage3_JobPostingsByHiringOrgName
            = new Dictionary<string, uint>() 
            {
                { "TeamVikaren.dk, Århus ApS, Horsens Afdeling", 12 },
                { "Aarhus Universitet", 4 },
                { "Keepit A/S", 2 },
                { "Copenhagen Business School", 2 },
                { "RANDSTAD A/S", 2 },
                { "Plecto ApS", 2 },
                { "Novo Nordisk A/S", 2 },
                { "A.P. Møller - Mærsk A/S", 2 },
                { "Lokal Boligservice ApS", 1 },
                { "Danmarks Tekniske Universitet", 1 },
                { "BH HotelService ApS", 1 },
                { "Vikar DK A/S", 1 },
                { "KU - SCIENCE - SNM", 1 },
                { "Københavns Universitet", 1 },
                { "LEO Pharma A/S", 1 },
                { "Alfa Laval Aalborg A/S", 1 },
                { "Aalborg Universitet", 1 },
                { "Rederiet A.P. Møller A/S", 1 },
                { "Coloplast Danmark A/S", 1 },
                { "GN Store Nord A/S", 1 }
            }; 
        public static Dictionary<string, uint> MetricCollection_ExplorationStage3_JobPostingsByWorkPlaceAddress
            = new Dictionary<string, uint>()
            {
                { "", 19 },
                { "Per Henrik Lings Allé 4 7", 2 },
                { "Solbjerg Plads 3", 2 },
                { "Viby Ringvej 11", 2 },
                { "Novo alle 1", 2 },
                { "Strandpromenaden 6", 1 },
                { "Blichers Alle 20", 1 },
                { "Ag", 1 },
                { "Agro Food Park 48", 1 },
                { "Tuborgvej 164", 1 },
                { "Anker Engelunds Vej 101", 1 },
                { "Amagerbrogade 44, 1. tv.", 1 },
                { "Egeskovvej 17", 1 },
                { "Øster Voldgade 5-7", 1 },
                { "Industriparken 55", 1 },
                { "Gasværksvej 21", 1 },
                { "Holtedam 1", 1 },
                { "Lautrupbjerg 7", 1 }
            };
        public static Dictionary<string, uint> MetricCollection_ExplorationStage3_JobPostingsByWorkPlacePostalCode
            = new Dictionary<string, uint>()
            {
                { "8700", 6 },
                { "null", 5 },
                { "6000", 3 },
                { "2100", 2 },
                { "8660", 2 },
                { "8200", 2 },
                { "2000", 2 },
                { "8260", 2 },
                { "2880", 2 },
                { "2750", 2 },
                { "9000", 2 },
                { "6853", 1 },
                { "6600", 1 },
                { "8830", 1 },
                { "8722", 1 },
                { "2400", 1 },
                { "2800", 1 },
                { "5500", 1 },
                { "2300", 1 },
                { "1350", 1 },
                { "3050", 1 }
            };
        public static Dictionary<string, uint> MetricCollection_ExplorationStage3_JobPostingsByWorkPlaceCity
            = new Dictionary<string, uint>()
            {
                { "Horsens", 6 },
                { "", 5 },
                { "Kolding", 3 },
                { "København Ø", 2 },
                { "Skanderborg", 2 },
                { "Aarhus N", 2 },
                { "Frederiksberg", 2 },
                { "Viby J", 2 },
                { "Bagsværd", 2 },
                { "Ballerup", 2 },
                { "Aalborg", 2 },
                { "Vejers Strand", 1 },
                { "Vejen", 1 },
                { "Tjele", 1 },
                { "Hedensted", 1 },
                { "København NV", 1 },
                { "Kongens Lyngby", 1 },
                { "Middelfart", 1 },
                { "København S", 1 },
                { "København K", 1 },
                { "Humlebæk", 1 }
            };
        public static Dictionary<string, uint> MetricCollection_ExplorationStage3_JobPostingsByPostingCreated
            = new Dictionary<string, uint>()
            {
               { "2021-07-02", 40 }
            };
        public static Dictionary<string, uint> MetricCollection_ExplorationStage3_JobPostingsByLastDateApplication
            = new Dictionary<string, uint>()
            {
                { "2021-08-27", 9 },
                { "2021-08-13", 2 },
                { "2021-08-19", 2 },
                { "2021-07-28", 2 },
                { "2021-08-02", 2 },
                { "2021-07-16", 2 },
                { "2021-07-30", 2 },
                { "2021-08-05", 2 },
                { "2021-07-06", 2 },
                { "2021-07-20", 2 },
                { "2021-08-04", 1 },
                { "2021-08-24", 1 },
                { "2021-07-15", 1 },
                { "2021-07-29", 1 },
                { "2021-07-12", 1 },
                { "2021-08-23", 1 },
                { "2021-08-26", 1 },
                { "2021-08-09", 1 },
                { "2021-07-21", 1 },
                { "2021-09-01", 1 },
                { "2021-08-01", 1 },
                { "2021-07-17", 1 },
                { "1900-01-01", 1 }
            };
        public static Dictionary<string, uint> MetricCollection_ExplorationStage3_JobPostingsByRegion
            = new Dictionary<string, uint>()
            {
                { "Hovedstaden og Bornholm", 17 },
                { "Midtjylland", 14 },
                { "Syddanmark", 6 },
                { "Nordjylland", 2 },
                { "", 1 }
            };
        public static Dictionary<string, uint> MetricCollection_ExplorationStage3_JobPostingsByMunicipality
            = new Dictionary<string, uint>()
            {
                { "København", 9 },
                { "Horsens", 6 },
                { "Aarhus", 4 },
                { "Kolding", 3 },
                { "Skanderborg", 2 },
                { "Frederiksberg", 2 },
                { "Lyngby-Taarbæk", 2 },
                { "Ballerup", 2 },
                { "Aalborg", 2 },
                { "Varde", 1 },
                { "Vejen", 1 },
                { "Viborg", 1 },
                { "Hedensted", 1 },
                { "", 1 },
                { "Gladsaxe", 1 },
                { "Middelfart", 1 },
                { "Fredensborg", 1 }
            };
        public static Dictionary<string, uint> MetricCollection_ExplorationStage3_JobPostingsByCountry
            = new Dictionary<string, uint>()
            {
                { "Danmark", 29 },
                { "", 11 }
            };
        public static Dictionary<string, uint> MetricCollection_ExplorationStage3_JobPostingsByEmploymentType
            = new Dictionary<string, uint>()
            {
                { "", 29 },
                { "Fastansættelse", 8 },
                { "Tidsbegrænset ansættelse", 3 }
            };
        public static Dictionary<string, uint> MetricCollection_ExplorationStage3_JobPostingsByWorkHours
            = new Dictionary<string, uint>()
            {
                { "Fuldtid", 36 },
                { "Deltid", 4 }
            };
        public static Dictionary<string, uint> MetricCollection_ExplorationStage3_JobPostingsByOccupation
            = new Dictionary<string, uint>()
            {
                { "", 11 },
                { "Lager- og logistikmedarbejder", 10 },
                { "Truckfører", 4 },
                { "Laboratorietekniker", 2 },
                { "Adjunkt, samfundsvidenskab", 2 },
                { "Programmør og systemudvikler", 1 },
                { "Rengøringsassistent", 1 },
                { "Marketingchef", 1 },
                { "Adjunkt, naturvidenskab og teknik", 1 },
                { "Forsker, samfundsvidenskab", 1 },
                { "Tømrer", 1 },
                { "Kundeservicemedarbejder", 1 },
                { "Miljøingeniør", 1 },
                { "Rengøringsassistent, hotel", 1 },
                { "Salgskonsulent", 1 },
                { "Adjunkt, sundhedsvidenskab", 1 }
            };
        public static Dictionary<string, uint> MetricCollection_ExplorationStage3_JobPostingsByWorkplaceId
            = new Dictionary<string, uint>()
            {
                { "0", 13 },
                { "126565", 12 },
                { "133543", 2 },
                { "79401", 2 },
                { "120191", 2 },
                { "107348", 2 },
                { "100437", 1 },
                { "106637", 1 },
                { "138690", 1 },
                { "83955", 1 },
                { "84451", 1 },
                { "99015", 1 },
                { "105129", 1 }
            };
        public static Dictionary<string, uint> MetricCollection_ExplorationStage3_JobPostingsByOrganisationId
            = new Dictionary<string, uint>()
            {
                { "71174", 12 },
                { "null", 11 },
                { "90880", 4 },
                { "117090", 2 },
                { "26360", 2 },
                { "106608", 2 },
                { "96927", 2 },
                { "121402", 1 },
                { "66175", 1 },
                { "78371", 1 },
                { "90677", 1 },
                { "57758", 1 }
            };
        public static Dictionary<string, uint> MetricCollection_ExplorationStage3_JobPostingsByHiringOrgCVR
            = new Dictionary<string, uint>()
            {
                { "30899695", 12 },
                { "0", 11 },
                { "31119103", 4 },
                { "30806883", 2 },
                { "19596915", 2 },
                { "25050541", 2 },
                { "34737460", 2 },
                { "41075899", 1 },
                { "30060946", 1 },
                { "32286550", 1 },
                { "34046956", 1 },
                { "29979812", 1 }
            };
        public static Dictionary<string, uint> MetricCollection_ExplorationStage3_JobPostingsByWorkPlaceCityWithoutZone
            = new Dictionary<string, uint>()
            {
                { "Horsens", 6 },
                { "København", 5 },
                { "", 5 },
                { "Kolding", 3 },
                { "Skanderborg", 2 },
                { "Aarhus", 2 },
                { "Frederiksberg", 2 },
                { "Viby", 2 },
                { "Bagsværd", 2 },
                { "Ballerup", 2 },
                { "Aalborg", 2 },
                { "Vejers Strand", 1 },
                { "Vejen", 1 },
                { "Tjele", 1 },
                { "Hedensted", 1 },
                { "Kongens Lyngby", 1 },
                { "Middelfart", 1 },
                { "Humlebæk", 1 }
            };

        public static Dictionary<string, uint> MetricCollection_ExplorationStage3_JobPostingsByPublicationStartDate
            = new Dictionary<string, uint>()
            {
                { "2021-07-02", 22 },
                { "null", 18}
            };
        public static Dictionary<string, uint> MetricCollection_ExplorationStage3_JobPostingsByPublicationEndDate
            = new Dictionary<string, uint>()
            {
                { "null", 18 },
                { "2021-08-27", 9 },
                { "2021-08-19", 2 },
                { "2021-07-30", 2 },
                { "2021-08-04", 1 },
                { "2021-08-13", 1 },
                { "2021-08-24", 1 },
                { "2021-07-15", 1 },
                { "2021-07-29", 1 },
                { "2021-07-28", 1 },
                { "2021-07-12", 1 },
                { "2021-07-16", 1 },
                { "2021-08-05", 1 }
            };
        public static Dictionary<string, uint> MetricCollection_ExplorationStage3_JobPostingsByNumberToFill
            = new Dictionary<string, uint>()
            {
                { "null", 18 },
                { "1", 10 },
                { "5", 3 },
                { "2", 2 },
                { "20", 2 },
                { "12", 2 },
                { "10", 2 },
                { "6", 1 }
            };
        public static Dictionary<string, uint> MetricCollection_ExplorationStage3_JobPostingsByContactEmail
            = new Dictionary<string, uint>()
            {
                { "null", 31 },
                { "edc@keepit.com", 2 },
                { "justyna@plecto.com", 2 },
                { "charlotte.meck@randstad.dk", 1 },
                { "kontakt@lokalboligservice.dk", 1 },
                { "claus.kjaerbo@randstad.dk", 1 },
                { "anja@bh-hotelservice.dk", 1 },
                { "bbo@vikardk.dk", 1 }
            };
        public static Dictionary<string, uint> MetricCollection_ExplorationStage3_JobPostingsByContactPersonName
            = new Dictionary<string, uint>()
            {
                { "null", 18 },
                { "Majken Lorentzen", 12 },
                { "Emil Daniel Christensen", 2 },
                { "Justyna Płaczkiewicz", 2 },
                { "Charlotte Meck", 1 },
                { "Emil Bertelsen", 1 },
                { "Henry Neufeldt", 1 },
                { "Claus Kjærbo", 1 },
                { "Anja Løvhøj", 1 },
                { "Bettina Bonde Thygesen", 1 }
            };
        public static Dictionary<string, uint> MetricCollection_ExplorationStage3_JobPostingsByEmploymentDate
            = new Dictionary<string, uint>()
            {
                { "null", 40 }
            };
        public static Dictionary<string, uint> MetricCollection_ExplorationStage3_JobPostingsByApplicationDeadlineDate
            = new Dictionary<string, uint>()
            {
                { "null", 18 },
                { "2021-08-27", 9 },
                { "2021-08-19", 2 },
                { "2021-07-30", 2 },
                { "2021-08-04", 1 },
                { "2021-08-13", 1 },
                { "2021-08-24", 1 },
                { "2021-07-15", 1 },
                { "2021-07-29", 1 },
                { "2021-07-28", 1 },
                { "2021-07-12", 1 },
                { "2021-07-16", 1 },
                { "2021-08-05", 1 }
            };
        public static Dictionary<string, uint> MetricCollection_ExplorationStage3_JobPostingsByBulletPointScenario
            = new Dictionary<string, uint>()
            {
                { "generic", 29 },
                { "null", 5 },
                { "keepit", 1 },
                { "randstad", 1 },
                { "novonordisk", 1 },
                { "jobportal", 1 },
                { "easycruit", 1 },
                { "coloplast", 1 }
            };

        public static Dictionary<string, uint> MetricCollection_ExplorationStage3_ResponseLengthByJobPostingId
            = new Dictionary<string, uint>()
            {
                { "5379659erfarenogselvstndigtruckf", 2625 },
                { "5383165lagermedarbejderetilpakkeopgaverpdaghold", 2625 },
                { "5376524visgerrengringsassistenter", 2623 },
                { "8251039supportengineer", 2619 },
                { "5376709medarbejderetilsommervikariaterp", 2601 },
                { "5383195laboratorytechnicianforfoodprocessing", 2599 },
                { "8251029businessintelligenceanalyst", 2599 },
                { "5290988motivatedemployeesforwarehousework", 2598 },
                { "5331002friskeogoplagtemedarbejderetil", 2595 },
                { "5363343tenuretrackassistantprofessorin", 2585 },
                { "5382440assistantorassociateprofessorshipin", 2574 },
                { "5383201laboratorytechnicianforplantanalysis", 2566 },
                { "5382486postdocondigitalplatformsand", 2542 },
                { "5359775wearelookingforforklift", 2540 },
                { "5382809tenuretrackassistantprofessorshipsin", 2539 },
                { "5346333motivatedemployeeforemptyingcontainers", 2536 },
                { "5382358projectofficerimpactassessmentand", 2525 },
                { "5361275committedemployeesforassemblingdisplays", 2514 },
                { "5303321motivatedemployeesforwarehousework", 2513 },
                { "5365786motivatedforkliftdriversfortemporary", 2504 },
                { "8251052receptionist", 2501 },
                { "5383212tenuretrackassistantprofessorin", 2493 },
                { "8251051securityofficer", 2492 },
                { "8251030seniormanager", 2492 },
                { "5372675selvstndigetruckfreretil", 2460 },
                { "5383229vicepresidentofproductmarketing", 2430 },
                { "5339477cleaninghousekeeping", 2427 },
                { "5366564warwhoseworkerwithinexperince", 2427 },
                { "8251041specialist", 2393 },
                { "5382781warehouseemployee", 2368 },
                { "5332213linuxspecialist", 2352 },
                { "5382226warehouseworkers", 2344 },
                { "8251036phd", 2329 },
                { "8251038softwaredeveloper", 2306 },
                { "8251034productowner", 2300 },
                { "8251035leader", 2282 },
                { "8251042phd", 2258 },
                { "5382367solutionarchitect", 2206 },
                { "5345782bbsalesspecialist", 2199 },
                { "5316797carpenter", 2144 }
            };
        public static Dictionary<string, uint> MetricCollection_ExplorationStage3_PresentationLengthByJobPostingId
            = new Dictionary<string, uint>()
            {
                { "5383201laboratorytechnicianforplantanalysis", 200 },
                { "5383195laboratorytechnicianforfoodprocessing", 200 },
                { "5383165lagermedarbejderetilpakkeopgaverpdaghold", 200 },
                { "5382486postdocondigitalplatformsand", 200 },
                { "5382440assistantorassociateprofessorshipin", 200 },
                { "5363343tenuretrackassistantprofessorin", 200 },
                { "8251052receptionist", 200 },
                { "8251051securityofficer", 200 },
                { "8251042phd", 200 },
                { "8251041specialist", 200 },
                { "8251039supportengineer", 200 },
                { "8251038softwaredeveloper", 200 },
                { "8251036phd", 200 },
                { "8251035leader", 200 },
                { "8251034productowner", 200 },
                { "8251030seniormanager", 200 },
                { "8251029businessintelligenceanalyst", 200 },
                { "5382358projectofficerimpactassessmentand", 199 },
                { "5383212tenuretrackassistantprofessorin", 198 },
                { "5379659erfarenogselvstndigtruckf", 197 },
                { "5382809tenuretrackassistantprofessorshipsin", 195 },
                { "5382781warehouseemployee", 169 },
                { "5303321motivatedemployeesforwarehousework", 167 },
                { "5383229vicepresidentofproductmarketing", 165 },
                { "5376709medarbejderetilsommervikariaterp", 163 },
                { "5361275committedemployeesforassemblingdisplays", 156 },
                { "5290988motivatedemployeesforwarehousework", 150 },
                { "5366564warwhoseworkerwithinexperince", 148 },
                { "5346333motivatedemployeeforemptyingcontainers", 145 },
                { "5365786motivatedforkliftdriversfortemporary", 143 },
                { "5339477cleaninghousekeeping", 142 },
                { "5382226warehouseworkers", 138 },
                { "5376524visgerrengringsassistenter", 131 },
                { "5359775wearelookingforforklift", 124 },
                { "5332213linuxspecialist", 110 },
                { "5372675selvstndigetruckfreretil", 57 },
                { "5331002friskeogoplagtemedarbejderetil", 57 },
                { "5382367solutionarchitect", 1 },
                { "5345782bbsalesspecialist", 1 },
                { "5316797carpenter", 0 }
            };
        public static Dictionary<string, uint> MetricCollection_ExplorationStage3_ExtendedResponseLengthByJobPostingId
            = new Dictionary<string, uint>()
            {
                { "5332213linuxspecialist", 13 },
                { "5365786motivatedforkliftdriversfortemporary", 13 },
                { "5372675selvstndigetruckfreretil", 13 },
                { "5379659erfarenogselvstndigtruckf", 13 },
                { "5376524visgerrengringsassistenter", 13 },
                { "5303321motivatedemployeesforwarehousework", 13 },
                { "5290988motivatedemployeesforwarehousework", 13 },
                { "5383229vicepresidentofproductmarketing", 13 },
                { "5331002friskeogoplagtemedarbejderetil", 13 },
                { "5383212tenuretrackassistantprofessorin", 13 },
                { "5361275committedemployeesforassemblingdisplays", 13 },
                { "5359775wearelookingforforklift", 13 },
                { "5383201laboratorytechnicianforplantanalysis", 13 },
                { "5383195laboratorytechnicianforfoodprocessing", 13 },
                { "5383165lagermedarbejderetilpakkeopgaverpdaghold", 13 },
                { "5346333motivatedemployeeforemptyingcontainers", 13 },
                { "5376709medarbejderetilsommervikariaterp", 13 },
                { "5382809tenuretrackassistantprofessorshipsin", 13 },
                { "5382781warehouseemployee", 13 },
                { "5382486postdocondigitalplatformsand", 13 },
                { "5382440assistantorassociateprofessorshipin", 13 },
                { "5316797carpenter", 13 },
                { "5382367solutionarchitect", 13 },
                { "5382358projectofficerimpactassessmentand", 13 },
                { "5382226warehouseworkers", 13 },
                { "5339477cleaninghousekeeping", 13 },
                { "5345782bbsalesspecialist", 13 },
                { "5366564warwhoseworkerwithinexperince", 13 },
                { "5363343tenuretrackassistantprofessorin", 13 },
                { "8251052receptionist", 13 },
                { "8251051securityofficer", 13 },
                { "8251042phd", 13 },
                { "8251041specialist", 13 },
                { "8251039supportengineer", 13 },
                { "8251038softwaredeveloper", 13 },
                { "8251036phd", 13 },
                { "8251035leader", 13 },
                { "8251034productowner", 13 },
                { "8251030seniormanager", 13 },
                { "8251029businessintelligenceanalyst", 13 }
            };
        public static Dictionary<string, uint> MetricCollection_ExplorationStage3_HiringOrgDescriptionLengthByJobPostingId
            = new Dictionary<string, uint>()
            {
                { "5382781warehouseemployee", 442 },
                { "5382226warehouseworkers", 442 },
                { "5332213linuxspecialist", 0 },
                { "5365786motivatedforkliftdriversfortemporary", 0 },
                { "5372675selvstndigetruckfreretil", 0 },
                { "5379659erfarenogselvstndigtruckf", 0 },
                { "5376524visgerrengringsassistenter", 0 },
                { "5303321motivatedemployeesforwarehousework", 0 },
                { "5290988motivatedemployeesforwarehousework", 0 },
                { "5383229vicepresidentofproductmarketing", 0 },
                { "5331002friskeogoplagtemedarbejderetil", 0 },
                { "5383212tenuretrackassistantprofessorin", 0 },
                { "5361275committedemployeesforassemblingdisplays", 0 },
                { "5359775wearelookingforforklift", 0 },
                { "5383201laboratorytechnicianforplantanalysis", 0 },
                { "5383195laboratorytechnicianforfoodprocessing", 0 },
                { "5383165lagermedarbejderetilpakkeopgaverpdaghold", 0 },
                { "5346333motivatedemployeeforemptyingcontainers", 0 },
                { "5376709medarbejderetilsommervikariaterp", 0 },
                { "5382809tenuretrackassistantprofessorshipsin", 0 },
                { "5382486postdocondigitalplatformsand", 0 },
                { "5382440assistantorassociateprofessorshipin", 0 },
                { "5316797carpenter", 0 },
                { "5382367solutionarchitect", 0 },
                { "5382358projectofficerimpactassessmentand", 0 },
                { "5339477cleaninghousekeeping", 0 },
                { "5345782bbsalesspecialist", 0 },
                { "5366564warwhoseworkerwithinexperince", 0 },
                { "5363343tenuretrackassistantprofessorin", 0 },
                { "8251052receptionist", 0 },
                { "8251051securityofficer", 0 },
                { "8251042phd", 0 },
                { "8251041specialist", 0 },
                { "8251039supportengineer", 0 },
                { "8251038softwaredeveloper", 0 },
                { "8251036phd", 0 },
                { "8251035leader", 0 },
                { "8251034productowner", 0 },
                { "8251030seniormanager", 0 },
                { "8251029businessintelligenceanalyst", 0 }
            };
        public static Dictionary<string, uint> MetricCollection_ExplorationStage3_PurposeLengthByJobPostingId
            = new Dictionary<string, uint>()
            {
                { "5332213linuxspecialist", 12 },
                { "5365786motivatedforkliftdriversfortemporary", 12 },
                { "5372675selvstndigetruckfreretil", 12 },
                { "5379659erfarenogselvstndigtruckf", 12 },
                { "5376524visgerrengringsassistenter", 12 },
                { "5303321motivatedemployeesforwarehousework", 12 },
                { "5290988motivatedemployeesforwarehousework", 12 },
                { "5383229vicepresidentofproductmarketing", 12 },
                { "5331002friskeogoplagtemedarbejderetil", 12 },
                { "5383212tenuretrackassistantprofessorin", 12 },
                { "5361275committedemployeesforassemblingdisplays", 12 },
                { "5359775wearelookingforforklift", 12 },
                { "5383201laboratorytechnicianforplantanalysis", 12 },
                { "5383195laboratorytechnicianforfoodprocessing", 12 },
                { "5383165lagermedarbejderetilpakkeopgaverpdaghold", 12 },
                { "5346333motivatedemployeeforemptyingcontainers", 12 },
                { "5376709medarbejderetilsommervikariaterp", 12 },
                { "5382809tenuretrackassistantprofessorshipsin", 12 },
                { "5382781warehouseemployee", 12 },
                { "5382486postdocondigitalplatformsand", 12 },
                { "5382440assistantorassociateprofessorshipin", 12 },
                { "5316797carpenter", 12 },
                { "5382367solutionarchitect", 12 },
                { "5382358projectofficerimpactassessmentand", 12 },
                { "5382226warehouseworkers", 12 },
                { "5339477cleaninghousekeeping", 12 },
                { "5345782bbsalesspecialist", 12 },
                { "5366564warwhoseworkerwithinexperince", 12 },
                { "5363343tenuretrackassistantprofessorin", 12 },
                { "8251052receptionist", 12 },
                { "8251051securityofficer", 12 },
                { "8251042phd", 12 },
                { "8251041specialist", 12 },
                { "8251039supportengineer", 12 },
                { "8251038softwaredeveloper", 12 },
                { "8251036phd", 12 },
                { "8251035leader", 12 },
                { "8251034productowner", 12 },
                { "8251030seniormanager", 12 },
                { "8251029businessintelligenceanalyst", 12 }
            };
        public static Dictionary<string, uint> MetricCollection_ExplorationStage3_BulletPointsByJobPostingId
            = new Dictionary<string, uint>()
            {
                { "5359775wearelookingforforklift", 37 },
                { "5382440assistantorassociateprofessorshipin", 35 },
                { "8251036phd", 34 },
                { "5382358projectofficerimpactassessmentand", 22 },
                { "5331002friskeogoplagtemedarbejderetil", 20 },
                { "5376709medarbejderetilsommervikariaterp", 20 },
                { "5372675selvstndigetruckfreretil", 19 },
                { "5382781warehouseemployee", 19 },
                { "5376524visgerrengringsassistenter", 18 },
                { "5382486postdocondigitalplatformsand", 17 },
                { "5382367solutionarchitect", 17 },
                { "5363343tenuretrackassistantprofessorin", 14 },
                { "5382809tenuretrackassistantprofessorshipsin", 13 },
                { "5383212tenuretrackassistantprofessorin", 12 },
                { "5339477cleaninghousekeeping", 11 },
                { "5345782bbsalesspecialist", 11 },
                { "8251042phd", 11 },
                { "5379659erfarenogselvstndigtruckf", 10 },
                { "5290988motivatedemployeesforwarehousework", 10 },
                { "5365786motivatedforkliftdriversfortemporary", 9 },
                { "5303321motivatedemployeesforwarehousework", 9 },
                { "5383229vicepresidentofproductmarketing", 9 },
                { "5361275committedemployeesforassemblingdisplays", 9 },
                { "5346333motivatedemployeeforemptyingcontainers", 9 },
                { "8251051securityofficer", 9 },
                { "8251030seniormanager", 9 },
                { "5383201laboratorytechnicianforplantanalysis", 7 },
                { "5383195laboratorytechnicianforfoodprocessing", 7 },
                { "8251041specialist", 7 },
                { "8251052receptionist", 6 },
                { "8251038softwaredeveloper", 6 },
                { "8251035leader", 6 },
                { "8251034productowner", 6 },
                { "5332213linuxspecialist", 3 },
                { "5382226warehouseworkers", 3 },
                { "5383165lagermedarbejderetilpakkeopgaverpdaghold", 0 },
                { "5316797carpenter", 0 },
                { "5366564warwhoseworkerwithinexperince", 0 },
                { "8251039supportengineer", 0 },
                { "8251029businessintelligenceanalyst", 0 }
            };

        public static MetricCollection MetricCollection_ExplorationStage3 =
            new MetricCollection(
                    runId: MetricCollection_ExplorationStage3_RunId,
                    totalJobPages: MetricCollection_ExplorationStage3_TotalJobPages,
                    totalJobPostings: MetricCollection_ExplorationStage3_TotalJobPostings,
                    jobPostingsByHiringOrgName: MetricCollection_ExplorationStage3_JobPostingsByHiringOrgName,
                    jobPostingsByWorkPlaceAddress: MetricCollection_ExplorationStage3_JobPostingsByWorkPlaceAddress,
                    jobPostingsByWorkPlacePostalCode: MetricCollection_ExplorationStage3_JobPostingsByWorkPlacePostalCode,
                    jobPostingsByWorkPlaceCity: MetricCollection_ExplorationStage3_JobPostingsByWorkPlaceCity,
                    jobPostingsByPostingCreated: MetricCollection_ExplorationStage3_JobPostingsByPostingCreated,
                    jobPostingsByLastDateApplication: MetricCollection_ExplorationStage3_JobPostingsByLastDateApplication,
                    jobPostingsByRegion: MetricCollection_ExplorationStage3_JobPostingsByRegion,
                    jobPostingsByMunicipality: MetricCollection_ExplorationStage3_JobPostingsByMunicipality,
                    jobPostingsByCountry: MetricCollection_ExplorationStage3_JobPostingsByCountry,
                    jobPostingsByEmploymentType: MetricCollection_ExplorationStage3_JobPostingsByEmploymentType,
                    jobPostingsByWorkHours: MetricCollection_ExplorationStage3_JobPostingsByWorkHours,
                    jobPostingsByOccupation: MetricCollection_ExplorationStage3_JobPostingsByOccupation,
                    jobPostingsByWorkplaceId: MetricCollection_ExplorationStage3_JobPostingsByWorkplaceId,
                    jobPostingsByOrganisationId: MetricCollection_ExplorationStage3_JobPostingsByOrganisationId,
                    jobPostingsByHiringOrgCVR: MetricCollection_ExplorationStage3_JobPostingsByHiringOrgCVR,
                    jobPostingsByWorkPlaceCityWithoutZone: MetricCollection_ExplorationStage3_JobPostingsByWorkPlaceCityWithoutZone,
                    responseLengthByJobPostingId: MetricCollection_ExplorationStage3_ResponseLengthByJobPostingId,
                    presentationLengthByJobPostingId: MetricCollection_ExplorationStage3_PresentationLengthByJobPostingId,
                    jobPostingsByPublicationStartDate: MetricCollection_ExplorationStage3_JobPostingsByPublicationStartDate,
                    jobPostingsByPublicationEndDate: MetricCollection_ExplorationStage3_JobPostingsByPublicationEndDate,
                    jobPostingsByNumberToFill: MetricCollection_ExplorationStage3_JobPostingsByNumberToFill,
                    jobPostingsByContactEmail: MetricCollection_ExplorationStage3_JobPostingsByContactEmail,
                    jobPostingsByContactPersonName: MetricCollection_ExplorationStage3_JobPostingsByContactPersonName,
                    jobPostingsByEmploymentDate: MetricCollection_ExplorationStage3_JobPostingsByEmploymentDate,
                    jobPostingsByApplicationDeadlineDate: MetricCollection_ExplorationStage3_JobPostingsByApplicationDeadlineDate,
                    jobPostingsByBulletPointScenario: MetricCollection_ExplorationStage3_JobPostingsByBulletPointScenario,
                    extendedResponseLengthByJobPostingId: MetricCollection_ExplorationStage3_ExtendedResponseLengthByJobPostingId,
                    hiringOrgDescriptionLengthByJobPostingId: MetricCollection_ExplorationStage3_HiringOrgDescriptionLengthByJobPostingId,
                    purposeLengthByJobPostingId: MetricCollection_ExplorationStage3_PurposeLengthByJobPostingId,
                    bulletPointsByJobPostingId: MetricCollection_ExplorationStage3_BulletPointsByJobPostingId,
                    totalBulletPoints: Shared_ExplorationStage3_TotalBulletPoints
                );

        public static MetricCollection MetricCollection_ExplorationStage2 =
            new MetricCollection(
                    runId: MetricCollection_ExplorationStage3_RunId,
                    totalJobPages: MetricCollection_ExplorationStage3_TotalJobPages,
                    totalJobPostings: MetricCollection_ExplorationStage3_TotalJobPostings,
                    jobPostingsByHiringOrgName: MetricCollection_ExplorationStage3_JobPostingsByHiringOrgName,
                    jobPostingsByWorkPlaceAddress: MetricCollection_ExplorationStage3_JobPostingsByWorkPlaceAddress,
                    jobPostingsByWorkPlacePostalCode: MetricCollection_ExplorationStage3_JobPostingsByWorkPlacePostalCode,
                    jobPostingsByWorkPlaceCity: MetricCollection_ExplorationStage3_JobPostingsByWorkPlaceCity,
                    jobPostingsByPostingCreated: MetricCollection_ExplorationStage3_JobPostingsByPostingCreated,
                    jobPostingsByLastDateApplication: MetricCollection_ExplorationStage3_JobPostingsByLastDateApplication,
                    jobPostingsByRegion: MetricCollection_ExplorationStage3_JobPostingsByRegion,
                    jobPostingsByMunicipality: MetricCollection_ExplorationStage3_JobPostingsByMunicipality,
                    jobPostingsByCountry: MetricCollection_ExplorationStage3_JobPostingsByCountry,
                    jobPostingsByEmploymentType: MetricCollection_ExplorationStage3_JobPostingsByEmploymentType,
                    jobPostingsByWorkHours: MetricCollection_ExplorationStage3_JobPostingsByWorkHours,
                    jobPostingsByOccupation: MetricCollection_ExplorationStage3_JobPostingsByOccupation,
                    jobPostingsByWorkplaceId: MetricCollection_ExplorationStage3_JobPostingsByWorkplaceId,
                    jobPostingsByOrganisationId: MetricCollection_ExplorationStage3_JobPostingsByOrganisationId,
                    jobPostingsByHiringOrgCVR: MetricCollection_ExplorationStage3_JobPostingsByHiringOrgCVR,
                    jobPostingsByWorkPlaceCityWithoutZone: MetricCollection_ExplorationStage3_JobPostingsByWorkPlaceCityWithoutZone,
                    responseLengthByJobPostingId: MetricCollection_ExplorationStage3_ResponseLengthByJobPostingId,
                    presentationLengthByJobPostingId: MetricCollection_ExplorationStage3_PresentationLengthByJobPostingId
                );

        #endregion

        #region MetricCollectionManagerTests

        public static Exploration Shared_ExplorationStage3WithNullJobPostings
            = new Exploration(
                    Shared_ExplorationStage3_RunId,
                    Shared_ExplorationStage3_TotalResultCount,
                    Shared_ExplorationStage3_TotalJobPages,
                    Shared_ExplorationStage3_Stage,
                    Shared_ExplorationStage3_IsCompleted,
                    Shared_ExplorationStage3_JobPages,
                    null,
                    Shared_ExplorationStage3_JobPostingsExtended
                );
        public static Exploration Shared_ExplorationStage3WithNullJobPostingsExtended
            = new Exploration(
                    Shared_ExplorationStage3_RunId,
                    Shared_ExplorationStage3_TotalResultCount,
                    Shared_ExplorationStage3_TotalJobPages,
                    Shared_ExplorationStage3_Stage,
                    Shared_ExplorationStage3_IsCompleted,
                    Shared_ExplorationStage3_JobPages,
                    Shared_ExplorationStage3_JobPostings,
                    null
                );

        public static Dictionary<string, uint> MetricCollectionManager_WorkPlaceCityWithoutZones = new Dictionary<string, uint>()
            {

                { "København", 45 },
                { "Nordborg", 12 },
                { "Vejen", 4 }

            };
        public static Dictionary<string, string> MetricCollectionManager_WorkPlaceCityWithoutZonesAsPercentages = new Dictionary<string, string>()
            {

                { "København", $"{MetricCollectionManager.FormatPercentage(73.77)}" },
                { "Nordborg", $"{MetricCollectionManager.FormatPercentage(19.67)}" },
                { "Vejen", $"{MetricCollectionManager.FormatPercentage(6.56)}" }

            };

        #endregion

        #region RunIdManagerTests

        public static DateTime RunIdManager_Now = new DateTime(2020, 01, 01, 19, 25, 40, 980);
        public static DateTime RunIdManager_StartDate = new DateTime(2019, 09, 01, 00, 00, 00, 000);
        public static DateTime RunIdManager_EndDate = new DateTime(2019, 12, 31, 23, 59, 59, 999);
        public static DateTime RunIdManager_Threshold = new DateTime(2020, 03, 31, 00, 00, 00, 000);
        public static ushort RunIdManager_InitialPageNumber = 1;
        public static ushort RunIdManager_FinalPageNumber = 3;
        public static string RunIdManager_RunId_Now
            = string.Format(
                RunIdManager.DefaultTemplateId,
                RunIdManager_Now.ToString(RunIdManager.DefaultFormatDateTime)
            );
        public static string RunIdManager_RunId_Threshold
            = string.Format(
                RunIdManager.DefaultTemplateThreshold,
                RunIdManager_RunId_Now,
                RunIdManager_Threshold.ToString(RunIdManager.DefaultFormatDate)
            );
        public static string RunIdManager_RunId_FromTo
            = string.Format(
                RunIdManager.DefaultTemplateFromTo,
                RunIdManager_RunId_Now,
                RunIdManager_InitialPageNumber,
                RunIdManager_FinalPageNumber
            );
        public static string RunIdManager_RunId_JobPostingId
            = string.Format(
                RunIdManager.DefaultTemplateJobPostingId,
                RunIdManager_RunId_Now,
                Shared_JobPage01_JobPosting01.JobPostingId
            );

        #endregion

        #region ValidatorTests

        public static string[] Validator_Array1 = new[] { "Dodge", "Datsun", "Jaguar", "DeLorean" };
        public static Car Validator_Object1 = new Car()
        {
            Brand = "Dodge",
            Model = "Charger",
            Year = 1966,
            Price = 13500,
            Currency = "USD"
        };
        public static uint Validator_Length1 = 3;
        public static string Validator_VariableName_Variable = "variable";
        public static string Validator_VariableName_Length = "length";
        public static string Validator_VariableName_N1 = "n1";
        public static string Validator_VariableName_N2 = "n2";
        public static List<string> List1 = Validator_Array1.ToList();
        public static uint Validator_Value = Validator_Length1;
        public static string Validator_String1 = "Dodge";
        public static string Validator_StringOnlyWhiteSpaces = "   ";
        public static Dictionary<string, int> Validator_SubScrapers_Proper = new Dictionary<string, int>()
        {

            { "urls", 20 },
            { "titles", 20 },
            { "createDates", 20 },
            { "applicationDates", 20 },
            { "workAreas", 20 },
            { "workAreasWithoutZones", 20 },
            { "workingHours", 20 },
            { "jobTypes", 20 },
            { "jobIds", 20 }

        };
        public static Dictionary<string, int> Validator_SubScrapers_Wrong = new Dictionary<string, int>()
        {

            { "urls", 19 },
            { "titles", 20 },
            { "createDates", 20 },
            { "applicationDates", 20 },
            { "workAreas", 20 },
            { "workAreasWithoutZones", 20 },
            { "workingHours", 20 },
            { "jobTypes", 20 },
            { "jobIds", 20 }

        };
        public static DateTime Validator_DateTimeOlder = new DateTime(2019, 09, 01, 00, 00, 00, 000);
        public static DateTime Validator_DateTimeNewer = new DateTime(2019, 12, 31, 23, 59, 59, 999);

        #endregion

        #region XPathManagerTests

        public static string XPathManager_HTML =
            string.Concat(
                "<html>",
                "<body>",
                "<h1>This is the title.</h1>",
                "<p>This is a paragraph.</p>",
                "<ul>",
                "<li><a href=\"https://github.com/numbworks\">This is a link</a></li>",
                "<li><a href=\"https://www.nuget.org/profiles/numbworks\">This is another link</a></li>",
                "</ul>",
                "</html>"
                );
        public static string XPathManager_GetInnerTexts_XPath = "//ul/li";
        public static List<string> XPathManager_GetInnerTexts_Results
            = new List<string>()
            {
                "This is a link",
                "This is another link"
            };
        public static string XPathManager_GetAttributeValues_XPath = "//ul/li/a/@href";
        public static List<string> XPathManager_GetAttributeValues_Results
            = new List<string>()
            {
                "https://github.com/numbworks",
                "https://www.nuget.org/profiles/numbworks"
            };
        public static string XPathManager_TryGetInnerText_XPath = "//div";
        public static string XPathManager_TryGetFirstAttributeValue_XPath = "//div/@class";

        #endregion

        #region WIDExplorerTests

        public static string WIDExplorer_ExplorationStage1AsJson_Content
            = Properties.Resources.ExplorationStage1AsJson;

        public static string WIDExplorer_ExplorationStage2AsJson_Content
            = Properties.Resources.ExplorationStage2AsJson;
        public static string WIDExplorer_ExplorationStage2MetricCollectionNumbersAsJson_Content
            = Properties.Resources.ExplorationStage2MCNumbersAsJson;
        public static string WIDExplorer_ExplorationStage2MetricCollectionPercentagesAsJson_Content
            = Properties.Resources.ExplorationStage2MCPercentagesAsJson;

        public static string WIDExplorer_ExplorationStage3AsJson_Content
            = Properties.Resources.ExplorationStage3AsJson;
        public static string WIDExplorer_ExplorationStage3MetricCollectionNumbersAsJson_Content
            = Properties.Resources.ExplorationStage3MCNumbersAsJson;
        public static string WIDExplorer_ExplorationStage3MetricCollectionPercentagesAsJson_Content
            = Properties.Resources.ExplorationStage3MCPercentagesAsJson;
        public static string WIDExplorer_PreLabeledExamplesForBulletPointTypeAsJson_Content
            = Properties.Resources.PreLabeledExamplesForBulletPointTypeAsJson;

        public static string WIDExplorer_JobPage01_FakeFilePath = @"C:\JobPage01.json";
        public static string WIDExplorer_FakeFolderPath = @"C:\";
        public static string WIDExplorer_FakeJsonFilePath = @"C:\export.json";
        public static string WIDExplorer_FakeSQLiteDatabaseFilePath = @"C:\export.db";
        public static string WIDExplorer_FakeSQLiteDatabaseName = @"export.db";

        public static DateTime WIDExplorer_FakeNow = new DateTime(2021, 05, 01);
        public static Func<DateTime> WIDExplorer_FakeNowFunction = () => WIDExplorer_FakeNow;

        public static List<(string bodyUrl, string response)> WIDExplorer_JobPage0102_BodyUrlResponses
            = new List<(string bodyUrl, string response)>()
            {

                ( Shared_JobPage01_BodyUrl, Shared_JobPage01_Content ),
                ( Shared_JobPage02_BodyUrl, Shared_JobPage02_Content )

            };
        public static IPostRequestManagerFactory WIDExplorer_JobPage0102_FakePostRequestManagerFactory
            = new FakePostRequestManagerFactory(WIDExplorer_JobPage0102_BodyUrlResponses);

        public static Dictionary<string, string> WIDExplorer_JobPage0102_GetUrlsResponses
            = new Dictionary<string, string>()
            {

                    {Shared_JobPage01_JobPostingExtended01.JobPosting.Url, Shared_JobPage01_JobPostingExtended01_Content},
                    {Shared_JobPage01_JobPostingExtended02.JobPosting.Url, Shared_JobPage01_JobPostingExtended02_Content},
                    {Shared_JobPage01_JobPostingExtended03.JobPosting.Url, Shared_JobPage01_JobPostingExtended03_Content},
                    {Shared_JobPage01_JobPostingExtended04.JobPosting.Url, Shared_JobPage01_JobPostingExtended04_Content},
                    {Shared_JobPage01_JobPostingExtended05.JobPosting.Url, Shared_JobPage01_JobPostingExtended05_Content},
                    {Shared_JobPage01_JobPostingExtended06.JobPosting.Url, Shared_JobPage01_JobPostingExtended06_Content},
                    {Shared_JobPage01_JobPostingExtended07.JobPosting.Url, Shared_JobPage01_JobPostingExtended07_Content},
                    {Shared_JobPage01_JobPostingExtended08.JobPosting.Url, Shared_JobPage01_JobPostingExtended08_Content},
                    {Shared_JobPage01_JobPostingExtended09.JobPosting.Url, Shared_JobPage01_JobPostingExtended09_Content},
                    {Shared_JobPage01_JobPostingExtended10.JobPosting.Url, Shared_JobPage01_JobPostingExtended10_Content},
                    {Shared_JobPage01_JobPostingExtended11.JobPosting.Url, Shared_JobPage01_JobPostingExtended11_Content},
                    {Shared_JobPage01_JobPostingExtended12.JobPosting.Url, Shared_JobPage01_JobPostingExtended12_Content},
                    {Shared_JobPage01_JobPostingExtended13.JobPosting.Url, Shared_JobPage01_JobPostingExtended13_Content},
                    {Shared_JobPage01_JobPostingExtended14.JobPosting.Url, Shared_JobPage01_JobPostingExtended14_Content},
                    {Shared_JobPage01_JobPostingExtended15.JobPosting.Url, Shared_JobPage01_JobPostingExtended15_Content},
                    {Shared_JobPage01_JobPostingExtended16.JobPosting.Url, Shared_JobPage01_JobPostingExtended16_Content},
                    {Shared_JobPage01_JobPostingExtended17.JobPosting.Url, Shared_JobPage01_JobPostingExtended17_Content},
                    {Shared_JobPage01_JobPostingExtended18.JobPosting.Url, Shared_JobPage01_JobPostingExtended18_Content},
                    {Shared_JobPage01_JobPostingExtended19.JobPosting.Url, Shared_JobPage01_JobPostingExtended19_Content},
                    {Shared_JobPage01_JobPostingExtended20.JobPosting.Url, Shared_JobPage01_JobPostingExtended20_Content},

                    {Shared_JobPage02_JobPostingExtended01.JobPosting.Url, Shared_JobPage02_JobPostingExtended01_Content},
                    {Shared_JobPage02_JobPostingExtended02.JobPosting.Url, Shared_JobPage02_JobPostingExtended02_Content},
                    {Shared_JobPage02_JobPostingExtended03.JobPosting.Url, Shared_JobPage02_JobPostingExtended03_Content},
                    {Shared_JobPage02_JobPostingExtended04.JobPosting.Url, Shared_JobPage02_JobPostingExtended04_Content},
                    {Shared_JobPage02_JobPostingExtended05.JobPosting.Url, Shared_JobPage02_JobPostingExtended05_Content},
                    {Shared_JobPage02_JobPostingExtended06.JobPosting.Url, Shared_JobPage02_JobPostingExtended06_Content},
                    {Shared_JobPage02_JobPostingExtended07.JobPosting.Url, Shared_JobPage02_JobPostingExtended07_Content},
                    {Shared_JobPage02_JobPostingExtended08.JobPosting.Url, Shared_JobPage02_JobPostingExtended08_Content},
                    {Shared_JobPage02_JobPostingExtended09.JobPosting.Url, Shared_JobPage02_JobPostingExtended09_Content},
                    {Shared_JobPage02_JobPostingExtended10.JobPosting.Url, Shared_JobPage02_JobPostingExtended10_Content},
                    {Shared_JobPage02_JobPostingExtended11.JobPosting.Url, Shared_JobPage02_JobPostingExtended11_Content},
                    {Shared_JobPage02_JobPostingExtended12.JobPosting.Url, Shared_JobPage02_JobPostingExtended12_Content},
                    {Shared_JobPage02_JobPostingExtended13.JobPosting.Url, Shared_JobPage02_JobPostingExtended13_Content},
                    {Shared_JobPage02_JobPostingExtended14.JobPosting.Url, Shared_JobPage02_JobPostingExtended14_Content},
                    {Shared_JobPage02_JobPostingExtended15.JobPosting.Url, Shared_JobPage02_JobPostingExtended15_Content},
                    {Shared_JobPage02_JobPostingExtended16.JobPosting.Url, Shared_JobPage02_JobPostingExtended16_Content},
                    {Shared_JobPage02_JobPostingExtended17.JobPosting.Url, Shared_JobPage02_JobPostingExtended17_Content},
                    {Shared_JobPage02_JobPostingExtended18.JobPosting.Url, Shared_JobPage02_JobPostingExtended18_Content},
                    {Shared_JobPage02_JobPostingExtended19.JobPosting.Url, Shared_JobPage02_JobPostingExtended19_Content},
                    {Shared_JobPage02_JobPostingExtended20.JobPosting.Url, Shared_JobPage02_JobPostingExtended20_Content},

                    {new JobPostingExtendedManager().CreateRequesttUrl(Shared_JobPage01_JobPostingExtended01.JobPosting.Id), Shared_JobPage01_JobPostingExtended01_Content},
                    {new JobPostingExtendedManager().CreateRequesttUrl(Shared_JobPage01_JobPostingExtended02.JobPosting.Id), Shared_JobPage01_JobPostingExtended02_Content},
                    {new JobPostingExtendedManager().CreateRequesttUrl(Shared_JobPage01_JobPostingExtended03.JobPosting.Id), Shared_JobPage01_JobPostingExtended03_Content},
                    {new JobPostingExtendedManager().CreateRequesttUrl(Shared_JobPage01_JobPostingExtended04.JobPosting.Id), Shared_JobPage01_JobPostingExtended04_Content},
                    {new JobPostingExtendedManager().CreateRequesttUrl(Shared_JobPage01_JobPostingExtended05.JobPosting.Id), Shared_JobPage01_JobPostingExtended05_Content},
                    {new JobPostingExtendedManager().CreateRequesttUrl(Shared_JobPage01_JobPostingExtended06.JobPosting.Id), Shared_JobPage01_JobPostingExtended06_Content},
                    {new JobPostingExtendedManager().CreateRequesttUrl(Shared_JobPage01_JobPostingExtended07.JobPosting.Id), Shared_JobPage01_JobPostingExtended07_Content},
                    {new JobPostingExtendedManager().CreateRequesttUrl(Shared_JobPage01_JobPostingExtended08.JobPosting.Id), Shared_JobPage01_JobPostingExtended08_Content},
                    {new JobPostingExtendedManager().CreateRequesttUrl(Shared_JobPage01_JobPostingExtended09.JobPosting.Id), Shared_JobPage01_JobPostingExtended09_Content},
                    {new JobPostingExtendedManager().CreateRequesttUrl(Shared_JobPage01_JobPostingExtended10.JobPosting.Id), Shared_JobPage01_JobPostingExtended10_Content},
                    {new JobPostingExtendedManager().CreateRequesttUrl(Shared_JobPage01_JobPostingExtended11.JobPosting.Id), Shared_JobPage01_JobPostingExtended11_Content},
                    {new JobPostingExtendedManager().CreateRequesttUrl(Shared_JobPage01_JobPostingExtended12.JobPosting.Id), Shared_JobPage01_JobPostingExtended12_Content},
                    {new JobPostingExtendedManager().CreateRequesttUrl(Shared_JobPage01_JobPostingExtended13.JobPosting.Id), Shared_JobPage01_JobPostingExtended13_Content},
                    {new JobPostingExtendedManager().CreateRequesttUrl(Shared_JobPage01_JobPostingExtended14.JobPosting.Id), Shared_JobPage01_JobPostingExtended14_Content},
                    {new JobPostingExtendedManager().CreateRequesttUrl(Shared_JobPage01_JobPostingExtended15.JobPosting.Id), Shared_JobPage01_JobPostingExtended15_Content},
                    {new JobPostingExtendedManager().CreateRequesttUrl(Shared_JobPage01_JobPostingExtended16.JobPosting.Id), Shared_JobPage01_JobPostingExtended16_Content},
                    {new JobPostingExtendedManager().CreateRequesttUrl(Shared_JobPage01_JobPostingExtended17.JobPosting.Id), Shared_JobPage01_JobPostingExtended17_Content},
                    {new JobPostingExtendedManager().CreateRequesttUrl(Shared_JobPage01_JobPostingExtended18.JobPosting.Id), Shared_JobPage01_JobPostingExtended18_Content},
                    {new JobPostingExtendedManager().CreateRequesttUrl(Shared_JobPage01_JobPostingExtended19.JobPosting.Id), Shared_JobPage01_JobPostingExtended19_Content},
                    {new JobPostingExtendedManager().CreateRequesttUrl(Shared_JobPage01_JobPostingExtended20.JobPosting.Id), Shared_JobPage01_JobPostingExtended20_Content},

                    {new JobPostingExtendedManager().CreateRequesttUrl(Shared_JobPage02_JobPostingExtended01.JobPosting.Id), Shared_JobPage02_JobPostingExtended01_Content},
                    {new JobPostingExtendedManager().CreateRequesttUrl(Shared_JobPage02_JobPostingExtended02.JobPosting.Id), Shared_JobPage02_JobPostingExtended02_Content},
                    {new JobPostingExtendedManager().CreateRequesttUrl(Shared_JobPage02_JobPostingExtended03.JobPosting.Id), Shared_JobPage02_JobPostingExtended03_Content},
                    {new JobPostingExtendedManager().CreateRequesttUrl(Shared_JobPage02_JobPostingExtended04.JobPosting.Id), Shared_JobPage02_JobPostingExtended04_Content},
                    {new JobPostingExtendedManager().CreateRequesttUrl(Shared_JobPage02_JobPostingExtended05.JobPosting.Id), Shared_JobPage02_JobPostingExtended05_Content},
                    {new JobPostingExtendedManager().CreateRequesttUrl(Shared_JobPage02_JobPostingExtended06.JobPosting.Id), Shared_JobPage02_JobPostingExtended06_Content},
                    {new JobPostingExtendedManager().CreateRequesttUrl(Shared_JobPage02_JobPostingExtended07.JobPosting.Id), Shared_JobPage02_JobPostingExtended07_Content},
                    {new JobPostingExtendedManager().CreateRequesttUrl(Shared_JobPage02_JobPostingExtended08.JobPosting.Id), Shared_JobPage02_JobPostingExtended08_Content},
                    {new JobPostingExtendedManager().CreateRequesttUrl(Shared_JobPage02_JobPostingExtended09.JobPosting.Id), Shared_JobPage02_JobPostingExtended09_Content},
                    {new JobPostingExtendedManager().CreateRequesttUrl(Shared_JobPage02_JobPostingExtended10.JobPosting.Id), Shared_JobPage02_JobPostingExtended10_Content},
                    {new JobPostingExtendedManager().CreateRequesttUrl(Shared_JobPage02_JobPostingExtended11.JobPosting.Id), Shared_JobPage02_JobPostingExtended11_Content},
                    {new JobPostingExtendedManager().CreateRequesttUrl(Shared_JobPage02_JobPostingExtended12.JobPosting.Id), Shared_JobPage02_JobPostingExtended12_Content},
                    {new JobPostingExtendedManager().CreateRequesttUrl(Shared_JobPage02_JobPostingExtended13.JobPosting.Id), Shared_JobPage02_JobPostingExtended13_Content},
                    {new JobPostingExtendedManager().CreateRequesttUrl(Shared_JobPage02_JobPostingExtended14.JobPosting.Id), Shared_JobPage02_JobPostingExtended14_Content},
                    {new JobPostingExtendedManager().CreateRequesttUrl(Shared_JobPage02_JobPostingExtended15.JobPosting.Id), Shared_JobPage02_JobPostingExtended15_Content},
                    {new JobPostingExtendedManager().CreateRequesttUrl(Shared_JobPage02_JobPostingExtended16.JobPosting.Id), Shared_JobPage02_JobPostingExtended16_Content},
                    {new JobPostingExtendedManager().CreateRequesttUrl(Shared_JobPage02_JobPostingExtended17.JobPosting.Id), Shared_JobPage02_JobPostingExtended17_Content},
                    {new JobPostingExtendedManager().CreateRequesttUrl(Shared_JobPage02_JobPostingExtended18.JobPosting.Id), Shared_JobPage02_JobPostingExtended18_Content},
                    {new JobPostingExtendedManager().CreateRequesttUrl(Shared_JobPage02_JobPostingExtended19.JobPosting.Id), Shared_JobPage02_JobPostingExtended19_Content},
                    {new JobPostingExtendedManager().CreateRequesttUrl(Shared_JobPage02_JobPostingExtended20.JobPosting.Id), Shared_JobPage02_JobPostingExtended20_Content}

            };
        public static IGetRequestManager WIDExplorer_JobPage0102_FakeGetRequestManager
            = new FakeGetRequestManager(WIDExplorer_JobPage0102_GetUrlsResponses);
        public static IGetRequestManagerFactory WIDExplorer_JobPage0102_FakeGetRequestManagerFactory
            = new FakeGetRequestManagerFactory(WIDExplorer_JobPage0102_FakeGetRequestManager);

        public static List<(string bodyUrl, string response)> WIDExplorer_JobPage01Alt_BodyUrlResponses
            = new List<(string bodyUrl, string response)>()
            {

                ( Shared_JobPage01_BodyUrl, Shared_JobPage01Alt_Content )

            };
        public static IPostRequestManagerFactory WIDExplorer_JobPage01Alt_FakePostRequestManagerFactory
            = new FakePostRequestManagerFactory(WIDExplorer_JobPage01Alt_BodyUrlResponses);

        #endregion

        #region Methods

        public static void Method_ShouldThrowACertainException_WhenUnproperArguments
            (TestDelegate del, Type expectedType, string expectedMessage)
        {

            // Arrange
            // Act
            Exception actual = Assert.Throws(expectedType, del);

            // Assert
            Assert.AreEqual(expectedMessage, actual.Message);

        }
        public static DatabaseContext CreateInMemoryContext()
        {

            string databaseName = Guid.NewGuid().ToString();
            DbContextOptions<DatabaseContext> options
                = new DbContextOptionsBuilder<DatabaseContext>().UseInMemoryDatabase(databaseName).Options;

            return new DatabaseContext(options);

        }
        public static Repository CreateInMemoryRepository()
            => new Repository(CreateInMemoryContext(), false);
        public static TReturn CallPrivateMethod<TClass, TReturn>
            (TClass obj, string methodName, object[] args)
        {

            Type type = typeof(TClass);

            return (TReturn)type.GetTypeInfo().GetDeclaredMethod(methodName).Invoke(obj, args);

        }

        public static bool AreEqual(List<string> list1, List<string> list2)
        {

            if (list1 == null && list2 == null)
                return true;

            if (list1 == null || list2 == null)
                return false;

            if (list1.Count != list2.Count)
                return false;

            for (int i = 0; i < list1.Count; i++)
                if (string.Equals(list1[i], list2[i], StringComparison.InvariantCulture) == false)
                    return false;

            return true;

        }
        public static bool AreEqual(HashSet<string> hashset1, HashSet<string> hashset2)
        {

            if (hashset1 == null && hashset2 == null)
                return true;

            if (hashset1 == null || hashset2 == null)
                return false;

            return AreEqual(new List<string>(hashset1), new List<string>(hashset2));

        }
        public static bool AreEqual<TKey, TValue>(Dictionary<TKey, TValue> dict1, Dictionary<TKey, TValue> dict2)
        {

            if (dict1 == null && dict2 == null)
                return true;

            IEqualityComparer<TValue> valueComparer = EqualityComparer<TValue>.Default;

            return dict1.Count == dict2.Count
                    && dict1.Keys.All(key => dict2.ContainsKey(key)
                    && valueComparer.Equals(dict1[key], dict2[key]));

        }

        public static bool AreEqual(BulletPoint bulletPoint1, BulletPoint bulletPoint2)
        {

            return string.Equals(bulletPoint1.Text, bulletPoint2.Text, StringComparison.InvariantCulture)
                    && string.Equals(bulletPoint1.Type, bulletPoint2.Type, StringComparison.InvariantCulture);

        }
        public static bool AreEqual(List<BulletPoint> list1, List<BulletPoint> list2)
        {

            if (list1 == null && list2 == null)
                return true;

            if (list1 == null || list2 == null)
                return false;

            if (list1.Count != list2.Count)
                return false;

            for (int i = 0; i < list1.Count; i++)
                if (AreEqual(list1[i], list2[i]) == false)
                    return false;

            return true;

        }
        public static bool AreEqual(JobPage jobPage1, JobPage jobPage2)
        {

            return (jobPage1.PageNumber == jobPage2.PageNumber)
                    && string.Equals(jobPage1.Response, jobPage2.Response, StringComparison.InvariantCulture)
                    && string.Equals(jobPage1.RunId, jobPage2.RunId, StringComparison.InvariantCulture);

        }
        public static bool AreEqual(List<JobPage> list1, List<JobPage> list2)
        {

            if (list1 == null && list2 == null)
                return true;

            if (list1 == null || list2 == null)
                return false;

            if (list1.Count != list2.Count)
                return false;

            for (int i = 0; i < list1.Count; i++)
                if (AreEqual(list1[i], list2[i]) == false)
                    return false;

            return true;

        }
        public static bool AreEqual(JobPosting jobPosting1, JobPosting jobPosting2, bool compareJobPostingLanguage)
        {

            if (compareJobPostingLanguage)
                return string.Equals(jobPosting1.Country, jobPosting2.Country, StringComparison.InvariantCulture)
                            && string.Equals(jobPosting1.EmploymentType, jobPosting2.EmploymentType, StringComparison.InvariantCulture)
                            && (jobPosting1.HiringOrgCVR == jobPosting2.HiringOrgCVR)
                            && string.Equals(jobPosting1.HiringOrgName, jobPosting2.HiringOrgName, StringComparison.InvariantCulture)
                            && (jobPosting1.Id == jobPosting2.Id)
                            && string.Equals(jobPosting1.JobPostingId, jobPosting2.JobPostingId, StringComparison.InvariantCulture)
                            && (jobPosting1.JobPostingNumber == jobPosting2.JobPostingNumber)
                            && (jobPosting1.LastDateApplication == jobPosting2.LastDateApplication)
                            && string.Equals(jobPosting1.Municipality, jobPosting2.Municipality, StringComparison.InvariantCulture)
                            && string.Equals(jobPosting1.Occupation, jobPosting2.Occupation, StringComparison.InvariantCulture)
                            && (jobPosting1.OrganisationId == jobPosting2.OrganisationId)
                            && (jobPosting1.PageNumber == jobPosting2.PageNumber)
                            && (jobPosting1.PostingCreated == jobPosting2.PostingCreated)
                            && string.Equals(jobPosting1.Presentation, jobPosting2.Presentation, StringComparison.InvariantCulture)
                            && string.Equals(jobPosting1.Region, jobPosting2.Region, StringComparison.InvariantCulture)
                            && string.Equals(jobPosting1.Response, jobPosting2.Response, StringComparison.InvariantCulture)
                            && string.Equals(jobPosting1.RunId, jobPosting2.RunId, StringComparison.InvariantCulture)
                            && string.Equals(jobPosting1.Title, jobPosting2.Title, StringComparison.InvariantCulture)
                            && string.Equals(jobPosting1.Url, jobPosting2.Url, StringComparison.InvariantCulture)
                            && string.Equals(jobPosting1.WorkHours, jobPosting2.WorkHours, StringComparison.InvariantCulture)
                            && string.Equals(jobPosting1.WorkPlaceAddress, jobPosting2.WorkPlaceAddress, StringComparison.InvariantCulture)
                            && string.Equals(jobPosting1.WorkPlaceCity, jobPosting2.WorkPlaceCity, StringComparison.InvariantCulture)
                            && string.Equals(jobPosting1.WorkPlaceCityWithoutZone, jobPosting2.WorkPlaceCityWithoutZone, StringComparison.InvariantCulture)
                            && (jobPosting1.WorkplaceId == jobPosting2.WorkplaceId)
                            && (jobPosting1.WorkPlacePostalCode == jobPosting2.WorkPlacePostalCode)
                            && string.Equals(jobPosting1.Language, jobPosting2.Language, StringComparison.InvariantCulture);

            return string.Equals(jobPosting1.Country, jobPosting2.Country, StringComparison.InvariantCulture)
                        && string.Equals(jobPosting1.EmploymentType, jobPosting2.EmploymentType, StringComparison.InvariantCulture)
                        && (jobPosting1.HiringOrgCVR == jobPosting2.HiringOrgCVR)
                        && string.Equals(jobPosting1.HiringOrgName, jobPosting2.HiringOrgName, StringComparison.InvariantCulture)
                        && (jobPosting1.Id == jobPosting2.Id)
                        && string.Equals(jobPosting1.JobPostingId, jobPosting2.JobPostingId, StringComparison.InvariantCulture)
                        && (jobPosting1.JobPostingNumber == jobPosting2.JobPostingNumber)
                        && (jobPosting1.LastDateApplication == jobPosting2.LastDateApplication)
                        && string.Equals(jobPosting1.Municipality, jobPosting2.Municipality, StringComparison.InvariantCulture)
                        && string.Equals(jobPosting1.Occupation, jobPosting2.Occupation, StringComparison.InvariantCulture)
                        && (jobPosting1.OrganisationId == jobPosting2.OrganisationId)
                        && (jobPosting1.PageNumber == jobPosting2.PageNumber)
                        && (jobPosting1.PostingCreated == jobPosting2.PostingCreated)
                        && string.Equals(jobPosting1.Presentation, jobPosting2.Presentation, StringComparison.InvariantCulture)
                        && string.Equals(jobPosting1.Region, jobPosting2.Region, StringComparison.InvariantCulture)
                        && string.Equals(jobPosting1.Response, jobPosting2.Response, StringComparison.InvariantCulture)
                        && string.Equals(jobPosting1.RunId, jobPosting2.RunId, StringComparison.InvariantCulture)
                        && string.Equals(jobPosting1.Title, jobPosting2.Title, StringComparison.InvariantCulture)
                        && string.Equals(jobPosting1.Url, jobPosting2.Url, StringComparison.InvariantCulture)
                        && string.Equals(jobPosting1.WorkHours, jobPosting2.WorkHours, StringComparison.InvariantCulture)
                        && string.Equals(jobPosting1.WorkPlaceAddress, jobPosting2.WorkPlaceAddress, StringComparison.InvariantCulture)
                        && string.Equals(jobPosting1.WorkPlaceCity, jobPosting2.WorkPlaceCity, StringComparison.InvariantCulture)
                        && string.Equals(jobPosting1.WorkPlaceCityWithoutZone, jobPosting2.WorkPlaceCityWithoutZone, StringComparison.InvariantCulture)
                        && (jobPosting1.WorkplaceId == jobPosting2.WorkplaceId)
                        && (jobPosting1.WorkPlacePostalCode == jobPosting2.WorkPlacePostalCode);

        }
        public static bool AreEqual(List<JobPosting> list1, List<JobPosting> list2, bool compareJobPostingLanguage)
        {

            if (list1 == null && list2 == null)
                return true;

            if (list1 == null || list2 == null)
                return false;

            if (list1.Count != list2.Count)
                return false;

            for (int i = 0; i < list1.Count; i++)
                if (AreEqual(list1[i], list2[i], compareJobPostingLanguage) == false)
                    return false;

            return true;

        }
        public static bool AreEqual(JobPostingExtended jobPostingExtended1, JobPostingExtended jobPostingExtended2, bool compareJobPostingLanguage, bool ignorePurposeResponse)
        {

            if (ignorePurposeResponse)
                return (jobPostingExtended1.ApplicationDeadlineDate == jobPostingExtended2.ApplicationDeadlineDate)
                            && AreEqual(jobPostingExtended1.BulletPoints, jobPostingExtended2.BulletPoints)
                            && string.Equals(jobPostingExtended1.BulletPointScenario, jobPostingExtended2.BulletPointScenario, StringComparison.InvariantCulture)
                            && string.Equals(jobPostingExtended1.ContactEmail, jobPostingExtended2.ContactEmail, StringComparison.InvariantCulture)
                            && string.Equals(jobPostingExtended1.ContactPersonName, jobPostingExtended2.ContactPersonName, StringComparison.InvariantCulture)
                            && (jobPostingExtended1.EmploymentDate == jobPostingExtended2.EmploymentDate)
                            && string.Equals(jobPostingExtended1.HiringOrgDescription, jobPostingExtended2.HiringOrgDescription, StringComparison.InvariantCulture)
                            && AreEqual(jobPostingExtended1.JobPosting, jobPostingExtended2.JobPosting, compareJobPostingLanguage)
                            && (jobPostingExtended1.NumberToFill == jobPostingExtended2.NumberToFill)
                            && (jobPostingExtended1.PublicationStartDate == jobPostingExtended2.PublicationStartDate)
                            && (jobPostingExtended1.PublicationEndDate == jobPostingExtended2.PublicationEndDate);

            return (jobPostingExtended1.ApplicationDeadlineDate == jobPostingExtended2.ApplicationDeadlineDate)
                        && AreEqual(jobPostingExtended1.BulletPoints, jobPostingExtended2.BulletPoints)
                        && string.Equals(jobPostingExtended1.BulletPointScenario, jobPostingExtended2.BulletPointScenario, StringComparison.InvariantCulture)
                        && string.Equals(jobPostingExtended1.ContactEmail, jobPostingExtended2.ContactEmail, StringComparison.InvariantCulture)
                        && string.Equals(jobPostingExtended1.ContactPersonName, jobPostingExtended2.ContactPersonName, StringComparison.InvariantCulture)
                        && (jobPostingExtended1.EmploymentDate == jobPostingExtended2.EmploymentDate)
                        && string.Equals(jobPostingExtended1.HiringOrgDescription, jobPostingExtended2.HiringOrgDescription, StringComparison.InvariantCulture)
                        && AreEqual(jobPostingExtended1.JobPosting, jobPostingExtended2.JobPosting, compareJobPostingLanguage)
                        && (jobPostingExtended1.NumberToFill == jobPostingExtended2.NumberToFill)
                        && (jobPostingExtended1.PublicationStartDate == jobPostingExtended2.PublicationStartDate)
                        && (jobPostingExtended1.PublicationEndDate == jobPostingExtended2.PublicationEndDate)
                        && string.Equals(jobPostingExtended1.Purpose, jobPostingExtended2.Purpose, StringComparison.InvariantCulture)
                        && string.Equals(jobPostingExtended1.Response, jobPostingExtended2.Response, StringComparison.InvariantCulture);

        }
        public static bool AreEqual(List<JobPostingExtended> list1, List<JobPostingExtended> list2, bool compareJobPostingLanguage, bool ignorePurposeResponse)
        {

            if (list1 == null && list2 == null)
                return true;

            if (list1 == null || list2 == null)
                return false;

            if (list1.Count != list2.Count)
                return false;

            for (int i = 0; i < list1.Count; i++)
                if (AreEqual(list1[i], list2[i], compareJobPostingLanguage, ignorePurposeResponse) == false)
                    return false;

            return true;

        }

        public static bool AreEqual(JobPosting jobPosting, JobPostingEntity jobPostingEntity)
        {

            return string.Equals(jobPosting.Country, jobPostingEntity.Country, StringComparison.InvariantCulture)
                        && string.Equals(jobPosting.EmploymentType, jobPostingEntity.EmploymentType, StringComparison.InvariantCulture)
                        && (jobPosting.HiringOrgCVR == jobPostingEntity.HiringOrgCVR)
                        && string.Equals(jobPosting.HiringOrgName, jobPostingEntity.HiringOrgName, StringComparison.InvariantCulture)
                        && (jobPosting.Id == jobPostingEntity.Id)
                        && string.Equals(jobPosting.JobPostingId, jobPostingEntity.JobPostingId, StringComparison.InvariantCulture)
                        && (jobPosting.JobPostingNumber == jobPostingEntity.JobPostingNumber)
                        && (jobPosting.LastDateApplication == jobPostingEntity.LastDateApplication)
                        && string.Equals(jobPosting.Municipality, jobPostingEntity.Municipality, StringComparison.InvariantCulture)
                        && string.Equals(jobPosting.Occupation, jobPostingEntity.Occupation, StringComparison.InvariantCulture)
                        && (jobPosting.OrganisationId == jobPostingEntity.OrganisationId)
                        && (jobPosting.PageNumber == jobPostingEntity.PageNumber)
                        && (jobPosting.PostingCreated == jobPostingEntity.PostingCreated)
                        && string.Equals(jobPosting.Presentation, jobPostingEntity.Presentation, StringComparison.InvariantCulture)
                        && string.Equals(jobPosting.Region, jobPostingEntity.Region, StringComparison.InvariantCulture)
                        && string.Equals(jobPosting.Response, jobPostingEntity.Response, StringComparison.InvariantCulture)
                        && string.Equals(jobPosting.RunId, jobPostingEntity.RunId, StringComparison.InvariantCulture)
                        && string.Equals(jobPosting.Title, jobPostingEntity.Title, StringComparison.InvariantCulture)
                        && string.Equals(jobPosting.Url, jobPostingEntity.Url, StringComparison.InvariantCulture)
                        && string.Equals(jobPosting.WorkHours, jobPostingEntity.WorkHours, StringComparison.InvariantCulture)
                        && string.Equals(jobPosting.WorkPlaceAddress, jobPostingEntity.WorkPlaceAddress, StringComparison.InvariantCulture)
                        && string.Equals(jobPosting.WorkPlaceCity, jobPostingEntity.WorkPlaceCity, StringComparison.InvariantCulture)
                        && string.Equals(jobPosting.WorkPlaceCityWithoutZone, jobPostingEntity.WorkPlaceCityWithoutZone, StringComparison.InvariantCulture)
                        && (jobPosting.WorkplaceId == jobPostingEntity.WorkplaceId)
                        && (jobPosting.WorkPlacePostalCode == jobPostingEntity.WorkPlacePostalCode)
                        && (jobPosting.Language == jobPostingEntity.Language)
                        && (jobPostingEntity.RowId == default(uint))
                        && (jobPostingEntity.RowCreatedOn == default(DateTime))
                        && (jobPostingEntity.RowModifiedOn == default(DateTime));

        }
        public static bool AreEqual(JobPostingExtended jobPostingExtended, JobPostingExtendedEntity jobPostingExtendedEntity, bool ignorePurposeResponse)
        {

            if (ignorePurposeResponse)
                return (jobPostingExtended.ApplicationDeadlineDate == jobPostingExtendedEntity.ApplicationDeadlineDate)
                            && string.Equals(jobPostingExtended.BulletPointScenario, jobPostingExtendedEntity.BulletPointScenario, StringComparison.InvariantCulture)
                            && string.Equals(jobPostingExtended.ContactEmail, jobPostingExtendedEntity.ContactEmail, StringComparison.InvariantCulture)
                            && string.Equals(jobPostingExtended.ContactPersonName, jobPostingExtendedEntity.ContactPersonName, StringComparison.InvariantCulture)
                            && (jobPostingExtended.EmploymentDate == jobPostingExtendedEntity.EmploymentDate)
                            && string.Equals(jobPostingExtended.HiringOrgDescription, jobPostingExtendedEntity.HiringOrgDescription, StringComparison.InvariantCulture)
                            && string.Equals(jobPostingExtended.JobPosting.JobPostingId, jobPostingExtendedEntity.JobPostingId, StringComparison.InvariantCulture)
                            && (jobPostingExtended.NumberToFill == jobPostingExtendedEntity.NumberToFill)
                            && (jobPostingExtended.PublicationStartDate == jobPostingExtendedEntity.PublicationStartDate)
                            && (jobPostingExtended.PublicationEndDate == jobPostingExtendedEntity.PublicationEndDate)
                            && (jobPostingExtendedEntity.RowId == default(uint))
                            && (jobPostingExtendedEntity.RowCreatedOn == default(DateTime))
                            && (jobPostingExtendedEntity.RowModifiedOn == default(DateTime));

            return (jobPostingExtended.ApplicationDeadlineDate == jobPostingExtendedEntity.ApplicationDeadlineDate)
                        && string.Equals(jobPostingExtended.BulletPointScenario, jobPostingExtendedEntity.BulletPointScenario, StringComparison.InvariantCulture)
                        && string.Equals(jobPostingExtended.ContactEmail, jobPostingExtendedEntity.ContactEmail, StringComparison.InvariantCulture)
                        && string.Equals(jobPostingExtended.ContactPersonName, jobPostingExtendedEntity.ContactPersonName, StringComparison.InvariantCulture)
                        && (jobPostingExtended.EmploymentDate == jobPostingExtendedEntity.EmploymentDate)
                        && string.Equals(jobPostingExtended.HiringOrgDescription, jobPostingExtendedEntity.HiringOrgDescription, StringComparison.InvariantCulture)
                        && string.Equals(jobPostingExtended.JobPosting.JobPostingId, jobPostingExtendedEntity.JobPostingId, StringComparison.InvariantCulture)
                        && (jobPostingExtended.NumberToFill == jobPostingExtendedEntity.NumberToFill)
                        && (jobPostingExtended.PublicationStartDate == jobPostingExtendedEntity.PublicationStartDate)
                        && (jobPostingExtended.PublicationEndDate == jobPostingExtendedEntity.PublicationEndDate)
                        && string.Equals(jobPostingExtended.Purpose, jobPostingExtendedEntity.Purpose, StringComparison.InvariantCulture)
                        && string.Equals(jobPostingExtended.Response, jobPostingExtendedEntity.Response, StringComparison.InvariantCulture)
                        && (jobPostingExtendedEntity.RowId == default(uint))
                        && (jobPostingExtendedEntity.RowCreatedOn == default(DateTime))
                        && (jobPostingExtendedEntity.RowModifiedOn == default(DateTime));

        }
        public static bool AreEqual(BulletPointEntity bulletPointEntity1, BulletPointEntity bulletPointEntity2)
        {

            return (bulletPointEntity1.RowId == bulletPointEntity2.RowId)
                    && string.Equals(bulletPointEntity1.JobPostingId, bulletPointEntity2.JobPostingId, StringComparison.InvariantCulture)
                    && string.Equals(bulletPointEntity1.Text, bulletPointEntity2.Text, StringComparison.InvariantCulture)
                    && string.Equals(bulletPointEntity1.Type, bulletPointEntity2.Type, StringComparison.InvariantCulture)
                    && (bulletPointEntity1.RowCreatedOn == bulletPointEntity2.RowCreatedOn)
                    && (bulletPointEntity1.RowModifiedOn == bulletPointEntity2.RowModifiedOn);

        }

        public static bool AreEqual(Exploration exploration1, Exploration exploration2, bool compareJobPostingLanguage, bool ignorePurposeResponse)
        {

            return string.Equals(exploration1.RunId, exploration2.RunId, StringComparison.InvariantCulture)
                        && (exploration1.TotalResultCount == exploration2.TotalResultCount)
                        && (exploration1.TotalJobPages == exploration2.TotalJobPages)
                        && (exploration1.Stage == exploration2.Stage)
                        && (exploration1.IsCompleted == exploration2.IsCompleted)
                        && AreEqual(exploration1.JobPages, exploration2.JobPages)
                        && AreEqual(exploration1.JobPostings, exploration2.JobPostings, compareJobPostingLanguage)
                        && AreEqual(exploration1.JobPostingsExtended, exploration2.JobPostingsExtended, compareJobPostingLanguage, ignorePurposeResponse);

        }
        public static bool AreEqual(MetricCollection metricCollection1, MetricCollection metricCollection2)
        {

            return string.Equals(metricCollection1.RunId, metricCollection2.RunId, StringComparison.InvariantCulture)
                        && (metricCollection1.TotalJobPages == metricCollection2.TotalJobPages)
                        && (metricCollection1.TotalJobPostings == metricCollection2.TotalJobPostings)
                        && AreEqual(metricCollection1.JobPostingsByHiringOrgName, metricCollection2.JobPostingsByHiringOrgName)
                        && AreEqual(metricCollection1.JobPostingsByWorkPlaceAddress, metricCollection2.JobPostingsByWorkPlaceAddress)
                        && AreEqual(metricCollection1.JobPostingsByWorkPlacePostalCode, metricCollection2.JobPostingsByWorkPlacePostalCode)
                        && AreEqual(metricCollection1.JobPostingsByWorkPlaceCity, metricCollection2.JobPostingsByWorkPlaceCity)
                        && AreEqual(metricCollection1.JobPostingsByPostingCreated, metricCollection2.JobPostingsByPostingCreated)
                        && AreEqual(metricCollection1.JobPostingsByLastDateApplication, metricCollection2.JobPostingsByLastDateApplication)
                        && AreEqual(metricCollection1.JobPostingsByRegion, metricCollection2.JobPostingsByRegion)
                        && AreEqual(metricCollection1.JobPostingsByMunicipality, metricCollection2.JobPostingsByMunicipality)
                        && AreEqual(metricCollection1.JobPostingsByCountry, metricCollection2.JobPostingsByCountry)
                        && AreEqual(metricCollection1.JobPostingsByEmploymentType, metricCollection2.JobPostingsByEmploymentType)
                        && AreEqual(metricCollection1.JobPostingsByWorkHours, metricCollection2.JobPostingsByWorkHours)
                        && AreEqual(metricCollection1.JobPostingsByOccupation, metricCollection2.JobPostingsByOccupation)
                        && AreEqual(metricCollection1.JobPostingsByWorkplaceId, metricCollection2.JobPostingsByWorkplaceId)
                        && AreEqual(metricCollection1.JobPostingsByOrganisationId, metricCollection2.JobPostingsByOrganisationId)
                        && AreEqual(metricCollection1.JobPostingsByHiringOrgCVR, metricCollection2.JobPostingsByHiringOrgCVR)
                        && AreEqual(metricCollection1.JobPostingsByWorkPlaceCityWithoutZone, metricCollection2.JobPostingsByWorkPlaceCityWithoutZone)
                        && AreEqual(metricCollection1.ResponseLengthByJobPostingId, metricCollection2.ResponseLengthByJobPostingId)
                        && AreEqual(metricCollection1.PresentationLengthByJobPostingId, metricCollection2.PresentationLengthByJobPostingId)
                        && AreEqual(metricCollection1.JobPostingsByPublicationStartDate, metricCollection2.JobPostingsByPublicationStartDate)
                        && AreEqual(metricCollection1.JobPostingsByPublicationEndDate, metricCollection2.JobPostingsByPublicationEndDate)
                        && AreEqual(metricCollection1.JobPostingsByNumberToFill, metricCollection2.JobPostingsByNumberToFill)
                        && AreEqual(metricCollection1.JobPostingsByContactEmail, metricCollection2.JobPostingsByContactEmail)
                        && AreEqual(metricCollection1.JobPostingsByContactPersonName, metricCollection2.JobPostingsByContactPersonName)
                        && AreEqual(metricCollection1.JobPostingsByEmploymentDate, metricCollection2.JobPostingsByEmploymentDate)
                        && AreEqual(metricCollection1.JobPostingsByApplicationDeadlineDate, metricCollection2.JobPostingsByApplicationDeadlineDate)
                        && AreEqual(metricCollection1.JobPostingsByBulletPointScenario, metricCollection2.JobPostingsByBulletPointScenario)
                        && AreEqual(metricCollection1.ExtendedResponseLengthByJobPostingId, metricCollection2.ExtendedResponseLengthByJobPostingId)
                        && AreEqual(metricCollection1.HiringOrgDescriptionLengthByJobPostingId, metricCollection2.HiringOrgDescriptionLengthByJobPostingId)
                        && AreEqual(metricCollection1.PurposeLengthByJobPostingId, metricCollection2.PurposeLengthByJobPostingId)
                        && AreEqual(metricCollection1.BulletPointsByJobPostingId, metricCollection2.BulletPointsByJobPostingId)
                        && (metricCollection1.TotalBulletPoints == metricCollection2.TotalBulletPoints);

        }

        public static bool AreEqual(ITokenizationStrategy tokenizationStrategy1, ITokenizationStrategy tokenizationStrategy2)
        {

            return string.Equals(tokenizationStrategy1.Delimiter, tokenizationStrategy2.Delimiter, StringComparison.InvariantCulture)
                    && string.Equals(tokenizationStrategy1.Pattern, tokenizationStrategy2.Pattern, StringComparison.InvariantCulture)
                    && (tokenizationStrategy1.ToLowercase == tokenizationStrategy2.ToLowercase);

        }
        public static bool AreEqual(INGram ngram1, INGram ngram2)
        {

            return (ngram1.N == ngram2.N)
                    && AreEqual(ngram1.Strategy, ngram2.Strategy)
                    && string.Equals(ngram1.Value, ngram2.Value, StringComparison.InvariantCulture);

        }
        public static bool AreEqual(List<INGram> list1, List<INGram> list2)
        {

            if (list1 == null && list2 == null)
                return true;

            if (list1 == null || list2 == null)
                return false;

            if (list1.Count != list2.Count)
                return false;

            for (int i = 0; i < list1.Count; i++)
                if (AreEqual(list1[i], list2[i]) == false)
                    return false;

            return true;

        }
        public static bool AreEqual(LabeledExample labeledExample1, LabeledExample labeledExample2)
        {

            return (labeledExample1.Id == labeledExample2.Id)
                    && string.Equals(labeledExample1.Label, labeledExample2.Label, StringComparison.InvariantCulture)
                    && string.Equals(labeledExample1.Text, labeledExample2.Text, StringComparison.InvariantCulture)
                    && AreEqual(labeledExample1.TextAsNGrams, labeledExample2.TextAsNGrams);

        }
        public static bool AreEqual(List<LabeledExample> list1, List<LabeledExample> list2)
        {

            if (list1 == null && list2 == null)
                return true;

            if (list1 == null || list2 == null)
                return false;

            if (list1.Count != list2.Count)
                return false;

            for (int i = 0; i < list1.Count; i++)
                if (AreEqual(list1[i], list2[i]) == false)
                    return false;

            return true;

        }

        public static JobPage UpdateRunId(JobPage jobPage, string runId)
        {

            return new JobPage(
                        runId: runId,
                        pageNumber: jobPage.PageNumber,
                        response: jobPage.Response
                    );

        }
        public static List<JobPage> UpdateRunIds(List<JobPage> jobPages, string runId)
        {

            if (jobPages == null)
                return jobPages;

            List<JobPage> updated = new List<JobPage>();
            foreach (JobPage jobPage in jobPages)
                updated.Add(UpdateRunId(jobPage, runId));

            return updated;

        }
        public static JobPosting UpdatePostingCreatedResponse(JobPosting jobPosting, DateTime postingCreated)
        {

            string oldString = "\"PostingCreated\": \"2021-07-02T00:00:00\"";   // To-Do: add a regex pattern instead of this.
            string newString = $"\"PostingCreated\": \"{postingCreated.ToString("yyyy-MM-dd")}T00:00:00\"";
            string newResponse = jobPosting.Response.Replace(oldString, newString);

            return new JobPosting(
                runId: jobPosting.RunId,
                pageNumber: jobPosting.PageNumber,
                response: newResponse,
                title: jobPosting.Title,
                presentation: jobPosting.Presentation,
                hiringOrgName: jobPosting.HiringOrgName,
                workPlaceAddress: jobPosting.WorkPlaceAddress,
                workPlacePostalCode: jobPosting.WorkPlacePostalCode,
                workPlaceCity: jobPosting.WorkPlaceCity,
                postingCreated: postingCreated,
                lastDateApplication: jobPosting.LastDateApplication,
                url: jobPosting.Url,
                region: jobPosting.Region,
                municipality: jobPosting.Municipality,
                country: jobPosting.Country,
                employmentType: jobPosting.EmploymentType,
                workHours: jobPosting.WorkHours,
                occupation: jobPosting.Occupation,
                workplaceId: jobPosting.WorkplaceId,
                organisationId: jobPosting.OrganisationId,
                hiringOrgCVR: jobPosting.HiringOrgCVR,
                id: jobPosting.Id,
                workPlaceCityWithoutZone: jobPosting.WorkPlaceCityWithoutZone,
                jobPostingNumber: jobPosting.JobPostingNumber,
                jobPostingId: jobPosting.JobPostingId,
                language: jobPosting.Language
            );

        }
        public static JobPosting UpdateRunIdPageNumber(JobPosting jobPosting, string runId, ushort pageNumber)
        {

            return new JobPosting(
                runId: runId,
                pageNumber: pageNumber,
                response: jobPosting.Response,
                title: jobPosting.Title,
                presentation: jobPosting.Presentation,
                hiringOrgName: jobPosting.HiringOrgName,
                workPlaceAddress: jobPosting.WorkPlaceAddress,
                workPlacePostalCode: jobPosting.WorkPlacePostalCode,
                workPlaceCity: jobPosting.WorkPlaceCity,
                postingCreated: jobPosting.PostingCreated,
                lastDateApplication: jobPosting.LastDateApplication,
                url: jobPosting.Url,
                region: jobPosting.Region,
                municipality: jobPosting.Municipality,
                country: jobPosting.Country,
                employmentType: jobPosting.EmploymentType,
                workHours: jobPosting.WorkHours,
                occupation: jobPosting.Occupation,
                workplaceId: jobPosting.WorkplaceId,
                organisationId: jobPosting.OrganisationId,
                hiringOrgCVR: jobPosting.HiringOrgCVR,
                id: jobPosting.Id,
                workPlaceCityWithoutZone: jobPosting.WorkPlaceCityWithoutZone,
                jobPostingNumber: jobPosting.JobPostingNumber,
                jobPostingId: jobPosting.JobPostingId,
                language: jobPosting.Language
            );

        }
        public static JobPosting UpdateRunId(JobPosting jobPosting, string runId)
        {

            return new JobPosting(
                runId: runId,
                pageNumber: jobPosting.PageNumber,
                response: jobPosting.Response,
                title: jobPosting.Title,
                presentation: jobPosting.Presentation,
                hiringOrgName: jobPosting.HiringOrgName,
                workPlaceAddress: jobPosting.WorkPlaceAddress,
                workPlacePostalCode: jobPosting.WorkPlacePostalCode,
                workPlaceCity: jobPosting.WorkPlaceCity,
                postingCreated: jobPosting.PostingCreated,
                lastDateApplication: jobPosting.LastDateApplication,
                url: jobPosting.Url,
                region: jobPosting.Region,
                municipality: jobPosting.Municipality,
                country: jobPosting.Country,
                employmentType: jobPosting.EmploymentType,
                workHours: jobPosting.WorkHours,
                occupation: jobPosting.Occupation,
                workplaceId: jobPosting.WorkplaceId,
                organisationId: jobPosting.OrganisationId,
                hiringOrgCVR: jobPosting.HiringOrgCVR,
                id: jobPosting.Id,
                workPlaceCityWithoutZone: jobPosting.WorkPlaceCityWithoutZone,
                jobPostingNumber: jobPosting.JobPostingNumber,
                jobPostingId: jobPosting.JobPostingId,
                language: jobPosting.Language
            );

        }
        public static List<JobPosting> UpdateRunIds(List<JobPosting> jobPostings, string runId)
        {

            if (jobPostings == null)
                return jobPostings;

            List<JobPosting> updated = new List<JobPosting>();
            foreach (JobPosting jobPosting in jobPostings)
                updated.Add(UpdateRunId(jobPosting, runId));

            return updated;

        }
        public static JobPostingExtended UpdateRunId(JobPostingExtended jobPostingExtended, string runId)
        {

            return new JobPostingExtended(
                jobPosting: UpdateRunId(jobPostingExtended.JobPosting, runId),
                response: jobPostingExtended.Response,
                hiringOrgDescription: jobPostingExtended.HiringOrgDescription,
                publicationStartDate: jobPostingExtended.PublicationStartDate,
                publicationEndDate: jobPostingExtended.PublicationEndDate,
                purpose: jobPostingExtended.Purpose,
                numberToFill: jobPostingExtended.NumberToFill,
                contactEmail: jobPostingExtended.ContactEmail,
                contactPersonName: jobPostingExtended.ContactPersonName,
                employmentDate: jobPostingExtended.EmploymentDate,
                applicationDeadlineDate: jobPostingExtended.ApplicationDeadlineDate,
                bulletPoints: jobPostingExtended.BulletPoints,
                bulletPointScenario: jobPostingExtended.BulletPointScenario
            );

        }
        public static List<JobPostingExtended> UpdateRunIds(List<JobPostingExtended> jobPostingsExtended, string runId)
        {

            if (jobPostingsExtended == null)
                return jobPostingsExtended;

            List<JobPostingExtended> updated = new List<JobPostingExtended>();
            foreach (JobPostingExtended jobPostingExtended in jobPostingsExtended)
                updated.Add(UpdateRunId(jobPostingExtended, runId));

            return updated;

        }
        public static Exploration UpdateRunIds(Exploration exploration, string runId)
        {

            return new Exploration(
                        runId: runId,
                        totalResultCount: exploration.TotalResultCount,
                        totalJobPages: exploration.TotalJobPages,
                        stage: exploration.Stage,
                        isCompleted: exploration.IsCompleted,
                        jobPages: UpdateRunIds(exploration.JobPages, runId),
                        jobPostings: UpdateRunIds(exploration.JobPostings, runId),
                        jobPostingsExtended: UpdateRunIds(exploration.JobPostingsExtended, runId)
                    );

        }
        
        public static JobPosting TranslateOccupation(JobPosting jobPosting)
        {

            IOccupationTranslator occupationTranslator = new OccupationTranslator();

            return new JobPosting(
                runId: jobPosting.RunId,
                pageNumber: jobPosting.PageNumber,
                response: jobPosting.Response,
                title: jobPosting.Title,
                presentation: jobPosting.Presentation,
                hiringOrgName: jobPosting.HiringOrgName,
                workPlaceAddress: jobPosting.WorkPlaceAddress,
                workPlacePostalCode: jobPosting.WorkPlacePostalCode,
                workPlaceCity: jobPosting.WorkPlaceCity,
                postingCreated: jobPosting.PostingCreated,
                lastDateApplication: jobPosting.LastDateApplication,
                url: jobPosting.Url,
                region: jobPosting.Region,
                municipality: jobPosting.Municipality,
                country: jobPosting.Country,
                employmentType: jobPosting.EmploymentType,
                workHours: jobPosting.WorkHours,
                occupation: occupationTranslator.Translate(jobPosting.Occupation),
                workplaceId: jobPosting.WorkplaceId,
                organisationId: jobPosting.OrganisationId,
                hiringOrgCVR: jobPosting.HiringOrgCVR,
                id: jobPosting.Id,
                workPlaceCityWithoutZone: jobPosting.WorkPlaceCityWithoutZone,
                jobPostingNumber: jobPosting.JobPostingNumber,
                jobPostingId: jobPosting.JobPostingId,
                language: jobPosting.Language
            );

        }
        public static List<JobPosting> TranslateOccupations(List<JobPosting> jobPostings)
        {

            if (jobPostings == null)
                return jobPostings;

            List<JobPosting> updated = new List<JobPosting>();
            foreach (JobPosting jobPosting in jobPostings)
                updated.Add(TranslateOccupation(jobPosting));

            return updated;

        }
        public static JobPostingExtended TranslateOccupation(JobPostingExtended jobPostingExtended)
        {

            return new JobPostingExtended(
                jobPosting: TranslateOccupation(jobPostingExtended.JobPosting),
                response: jobPostingExtended.Response,
                hiringOrgDescription: jobPostingExtended.HiringOrgDescription,
                publicationStartDate: jobPostingExtended.PublicationStartDate,
                publicationEndDate: jobPostingExtended.PublicationEndDate,
                purpose: jobPostingExtended.Purpose,
                numberToFill: jobPostingExtended.NumberToFill,
                contactEmail: jobPostingExtended.ContactEmail,
                contactPersonName: jobPostingExtended.ContactPersonName,
                employmentDate: jobPostingExtended.EmploymentDate,
                applicationDeadlineDate: jobPostingExtended.ApplicationDeadlineDate,
                bulletPoints: jobPostingExtended.BulletPoints,
                bulletPointScenario: jobPostingExtended.BulletPointScenario
            );

        }
        public static List<JobPostingExtended> TranslateOccupations(List<JobPostingExtended> jobPostingsExtended)
        {

            if (jobPostingsExtended == null)
                return jobPostingsExtended;

            List<JobPostingExtended> updated = new List<JobPostingExtended>();
            foreach (JobPostingExtended jobPostingExtended in jobPostingsExtended)
                updated.Add(TranslateOccupation(jobPostingExtended));

            return updated;

        }
        public static Exploration TranslateOccupations(Exploration exploration)
        {

            return new Exploration(
                        runId: exploration.RunId,
                        totalResultCount: exploration.TotalResultCount,
                        totalJobPages: exploration.TotalJobPages,
                        stage: exploration.Stage,
                        isCompleted: exploration.IsCompleted,
                        jobPages: exploration.JobPages,
                        jobPostings: TranslateOccupations(exploration.JobPostings),
                        jobPostingsExtended: TranslateOccupations(exploration.JobPostingsExtended)
                    );

        }

        public static Exploration ConvertToDeserializedExploration(Exploration exploration)
        {

            List<JobPage> jobPages = null;
            if (exploration.JobPages != null)
                jobPages = CallPrivateMethod<WIDExplorer, List<JobPage>>(new WIDExplorer(), "OptimizeJobPagesForSerialization", new object[1] { exploration.JobPages });

            List<JobPosting> jobPostings = null;
            if (exploration.JobPostings != null)
                jobPostings = CallPrivateMethod<WIDExplorer, List<JobPosting>>(new WIDExplorer(), "OptimizeJobPostingsForSerialization", new object[1] { exploration.JobPostings });

            List<JobPostingExtended> jobPostingsExtended = null;
            if (exploration.JobPostingsExtended != null)
                jobPostingsExtended = CallPrivateMethod<WIDExplorer, List<JobPostingExtended>>(new WIDExplorer(), "OptimizeJobPostingsExtendedForSerialization", new object[1] { exploration.JobPostingsExtended });

            Exploration result 
                = new Exploration(
                        runId: exploration.RunId,
                        totalResultCount: exploration.TotalResultCount,
                        totalJobPages: exploration.TotalJobPages,
                        stage: exploration.Stage,
                        isCompleted: exploration.IsCompleted,
                        jobPages: jobPages,
                        jobPostings: jobPostings,
                        jobPostingsExtended: jobPostingsExtended
                );

            return result;

        }

        #endregion

    }
}

/*
    Author: numbworks@gmail.com
    Last Update: 16.09.2021
*/