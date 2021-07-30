using System;
using System.Collections.Generic;
using System.IO;
using NW.WIDJobs;
using NW.WIDJobs.UnitTests;
using System.Text.Json;
using System.Text.Encodings.Web;
using System.Dynamic;

namespace NW.WIDJobsClient
{
    class Program
    {
        static void Main(string[] args)
        {

            DeserializeJobPage01JobPostingExtended08();

            WIDExplorerComponents.DefaultLoggingAction.Invoke("Press a button to close the window.");
            Console.ReadLine();

        }
        static void DeserializeJobPage01()
        {

            IFileInfoAdapter fileInfoAdapter = new FileInfoAdapter(@"C:\Dropbox\Tasks\20210502 - NW.WIDJobs\New WID\JSONs\JobPage01.json");
            IFileManager fileManager = new FileManager();
            string response = fileManager.ReadAllText(fileInfoAdapter);

            JobPage jobPage = new JobPage("temp", 1, response);

            IJobPostingDeserializer jobPostingDeserializer = new JobPostingDeserializer();
            List<JobPosting> jobPostings = jobPostingDeserializer.Do(jobPage);

            /*
             
            JsonSerializerOptions jso = new JsonSerializerOptions
            {
                Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping,
                WriteIndented = true
            };
            string json = JsonSerializer.Serialize(jobPostings, jso);
            fileManager.WriteAllText(
                new FileInfoAdapter(@"C:\Users\Rubèn\Desktop\Serialized_JobPage01.json"),
                json
                );

            */

        }

        // JobPage01JobPosting01
        static JobPosting CreateJobPage01JobPosting01()
        {

            JobPosting jobPosting
                = new JobPosting(
                        runId: "temp",
                        pageNumber: 1,
                        response: "{\r\n            \"AutomatchType\": 0,\r\n            \"Abroad\": false,\r\n            \"Weight\": 1.0,\r\n            \"Title\": \"Linux Specialist\",\r\n            \"JobHeadline\": \"Linux Specialist\",\r\n            \"Presentation\": \"<p>PARKEN, COPENHAGEN /</p>\\n<p>ENGINEERING – SYSTEM ADMINISTRATION /</p>\\n<p>FULL TIME, PERMANENT CONTRACT</p>\\n\",\r\n            \"HiringOrgName\": \"Keepit A/S\",\r\n            \"WorkPlaceAddress\": \"Per Henrik Lings Allé 4 7\",\r\n            \"WorkPlacePostalCode\": \"2100\",\r\n            \"WorkPlaceCity\": \"København Ø\",\r\n            \"WorkPlaceOtherAddress\": false,\r\n            \"WorkPlaceAbroad\": false,\r\n            \"WorkPlaceNotStatic\": false,\r\n            \"UseWorkPlaceAddressForJoblog\": true,\r\n            \"PostingCreated\": \"2021-07-02T00:00:00\",\r\n            \"LastDateApplication\": \"2021-08-27T00:00:00\",\r\n            \"FormattedLastDateApplication\": \"27. august 2021\",\r\n            \"AssignmentStartDate\": \"0001-01-01T00:00:00\",\r\n            \"IsHotjob\": false,\r\n            \"IsExternal\": false,\r\n            \"Url\": \"https://job.jobnet.dk/CV/FindWork/Details/5332213\",\r\n            \"Region\": \"Hovedstaden og Bornholm\",\r\n            \"Municipality\": \"København\",\r\n            \"Country\": \"Danmark\",\r\n            \"PostalCode\": \"2100\",\r\n            \"PostalCodeName\": null,\r\n            \"JobAnnouncementType\": \"\",\r\n            \"EmploymentType\": \"\",\r\n            \"WorkHours\": \"Fuldtid\",\r\n            \"OccupationArea\": \"\",\r\n            \"OccupationGroup\": \"\",\r\n            \"Occupation\": \"Programmør og systemudvikler\",\r\n            \"Location\": {\r\n                \"Latitude\": 55.7038,\r\n                \"Longitude\": 12.5721\r\n            },\r\n            \"JoblogWorkTime\": {\r\n                \"WorkHour\": null,\r\n                \"DailyWorkTime\": null\r\n            },\r\n            \"WorkplaceID\": 133543,\r\n            \"OrganisationId\": \"117090\",\r\n            \"HiringOrgCVR\": 30806883,\r\n            \"UserLoggedIn\": false,\r\n            \"AnonymousEmployer\": false,\r\n            \"ShareUrl\": \"https://job.jobnet.dk/CV/FindWork/DetailsSocialmedia/5332213\",\r\n            \"DetailsUrl\": \"https://job.jobnet.dk/CV/FindWork/DetailsWidk/5332213\",\r\n            \"JobLogUrl\": \"https://job.jobnet.dk/CV/FindWork/Details/5332213\",\r\n            \"HasLocationValues\": true,\r\n            \"ID\": \"5332213\",\r\n            \"Latitude\": 55.7038,\r\n            \"Longitude\": 12.5721\r\n        }",
                        title: "Linux Specialist",
                        presentation: "<p>PARKEN, COPENHAGEN /</p>\n<p>ENGINEERING – SYSTEM ADMINISTRATION /</p>\n<p>FULL TIME, PERMANENT CONTRACT</p>\n",
                        hiringOrgName: "Keepit A/S",
                        workPlaceAddress: "Per Henrik Lings Allé 4 7",
                        workPlacePostalCode: 1200,
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
                        jobPostingId: "5332213linuxspecialist"
                    );

            return jobPosting;

        }
        static JobPostingExtended CreateJobPage01JobPostingExtended01()
        {

            JobPostingExtended jobPostingExtended
                = new JobPostingExtended(
                        jobPosting: CreateJobPage01JobPosting01(),
                        response: null, // Ignored
                        hiringOrgDescription: null,
                        publicationStartDate: new DateTime(2021, 07, 02),
                        publicationEndDate: new DateTime(2021, 08, 27),
                        purpose: null, // Ignored
                        numberToFill: 1,
                        contactEmail: "edc@keepit.com",
                        contactPersonName: "Emil Daniel Christensen",
                        employmentDate: null,
                        applicationDeadlineDate: new DateTime(2021, 08, 27),
                        bulletPoints: new HashSet<string>()
                            {
                                "-\\u00A0\\u00A0\\u00A0\\u00A0\\u00A0\\u00A0\\u00A0Performance troubleshooting - if a service is not performing as expected, troubleshooting the process interactions on a live server in order to identify the root cause and propose a remedy, possibly in collaboration with the development team.",
                                "-\\u00A0\\u00A0\\u00A0\\u00A0\\u00A0\\u00A0\\u00A0Planning, testing, and executing Postgres database cluster migration from an older version to a newer version with little or no user-visible interruptions.",
                                "-\\u00A0\\u00A0\\u00A0\\u00A0\\u00A0\\u00A0\\u00A0Designing the next iteration of our network infrastructure for high-performance multi-site communication, and planning and executing the transition from the previous iteration with no customer visible downtime.\\u00A0"
                            },
                        bulletPointScenario: "keepit.com"
                    );

            return jobPostingExtended;

        }
        static void DeserializeJobPage01JobPostingExtended01()
        {

            IFileInfoAdapter fileInfoAdapter = new FileInfoAdapter(@"C:\Dropbox\Tasks\20210502 - NW.WIDJobs\New WID\JSONs\JobPage01_JobPostingExtended01.json");
            IFileManager fileManager = new FileManager();
            string response = fileManager.ReadAllText(fileInfoAdapter);

            JobPosting jobPosting = CreateJobPage01JobPosting01();

            IJobPostingExtendedDeserializer jobPostingExtendedDeserializer = new JobPostingExtendedDeserializer();
            JobPostingExtended jobPostingExtended = jobPostingExtendedDeserializer.Do(jobPosting, response);

            string json = Serialize(jobPostingExtended);

        }

        // JobPage01JobPosting02
        static JobPosting CreateJobPage01JobPosting02()
        {

            JobPosting jobPosting
                = new JobPosting(
                        runId: "temp",
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
                        jobPostingId: "5365786motivatedforkliftdriversfortemporary"
                    );

            return jobPosting;

        }
        static JobPostingExtended CreateJobPage01JobPostingExtended02()
        {

            JobPostingExtended jobPostingExtended
                = new JobPostingExtended(
                        jobPosting: CreateJobPage01JobPosting02(),
                        response: null, // Ignored
                        hiringOrgDescription: null,
                        publicationStartDate: new DateTime(2021, 07, 02),
                        publicationEndDate: new DateTime(2021, 08, 04),
                        purpose: null, // Ignored
                        numberToFill: 5,
                        contactEmail: null,
                        contactPersonName: "Majken Lorentzen",
                        employmentDate: null,
                        applicationDeadlineDate: new DateTime(2021, 08, 04),
                        bulletPoints: new HashSet<string>()
                            {
                                "Good work conditions",
                                "A social workplace with good colleagues",
                                "Flexibility regarding shifts",
                                "Possibility for day and evening shifts",
                                "You want to work in warehousing and logistics",
                                "You can work a minimum of 3 weeks in the period week 27 - 36",
                                "You can work either day or evening",
                                "You have experience with forklift driving",
                                "You like working in teams"
                            },
                        bulletPointScenario: "generic"
                    );

            return jobPostingExtended;

        }
        static void DeserializeJobPage01JobPostingExtended02()
        {

            IFileInfoAdapter fileInfoAdapter = new FileInfoAdapter(@"C:\Dropbox\Tasks\20210502 - NW.WIDJobs\New WID\JSONs\JobPage01_JobPostingExtended02.json");
            IFileManager fileManager = new FileManager();
            string response = fileManager.ReadAllText(fileInfoAdapter);

            JobPosting jobPosting = CreateJobPage01JobPosting02();

            IJobPostingExtendedDeserializer jobPostingExtendedDeserializer = new JobPostingExtendedDeserializer();
            JobPostingExtended jobPostingExtended = jobPostingExtendedDeserializer.Do(jobPosting, response);

            string json = Serialize(jobPostingExtended);

        }

        // JobPage01JobPosting03
        static JobPosting CreateJobPage01JobPosting03()
        {

            JobPosting jobPosting
                = new JobPosting(
                        runId: "temp",
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
                        jobPostingId: "5372675selvstndigetruckfreretil"
                    );

            return jobPosting;

        }
        static JobPostingExtended CreateJobPage01JobPostingExtended03()
        {

            JobPostingExtended jobPostingExtended
                = new JobPostingExtended(
                        jobPosting: CreateJobPage01JobPosting03(),
                        response: null, // Ignored
                        hiringOrgDescription: null,
                        publicationStartDate: new DateTime(2021, 07, 02),
                        publicationEndDate: new DateTime(2021, 08, 13),
                        purpose: null, // Ignored
                        numberToFill: 2,
                        contactEmail: null,
                        contactPersonName: "Majken Lorentzen",
                        employmentDate: null,
                        applicationDeadlineDate: new DateTime(2021, 08, 13),
                        bulletPoints: new HashSet<string>()
                            {
                                "Ordnede forhold",
                                "Attraktiv løn",
                                "En social arbejdsplads med gode kollegaer",
                                "Mulighed for vagter på daghold",
                                "Du har lyst til at arbejde inden for lager og logistik",
                                "Du kan arbejde om dagen",
                                "Du har gerne erfaring med truckkørsel – dog ikke et krav",
                                "Du kan lide at arbejde i teams",
                                "Du må ikke være talblind",
                                "Du kan arbejde i ugerne 29 og 30, eller en af ugerne",
                                "Orderly conditions",
                                "Attractive salary",
                                "A social workplace with good colleagues",
                                "Day shifts",
                                "You want to work in warehousing and logistics",
                                "You can work during the day",
                                "You would like to have experience with truck driving - but not a requirement",
                                "You must be able to count",
                                "You can work in weeks 29 and 30, or one of the weeks"
                            },
                        bulletPointScenario: "generic"
                    );

            return jobPostingExtended;

        }
        static void DeserializeJobPage01JobPostingExtended03()
        {

            IFileInfoAdapter fileInfoAdapter = new FileInfoAdapter(@"C:\Dropbox\Tasks\20210502 - NW.WIDJobs\New WID\JSONs\JobPage01_JobPostingExtended03.json");
            IFileManager fileManager = new FileManager();
            string response = fileManager.ReadAllText(fileInfoAdapter);

            JobPosting jobPosting = CreateJobPage01JobPosting03();

            IJobPostingExtendedDeserializer jobPostingExtendedDeserializer = new JobPostingExtendedDeserializer();
            JobPostingExtended jobPostingExtended = jobPostingExtendedDeserializer.Do(jobPosting, response);

            string json = Serialize(jobPostingExtended);

        }

        // JobPage01JobPosting04
        static JobPosting CreateJobPage01JobPosting04()
        {

            JobPosting jobPosting
                = new JobPosting(
                        runId: "temp",
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
                        jobPostingId: "5379659erfarenogselvstndigtruckf"
                    );

            return jobPosting;

        }
        static JobPostingExtended CreateJobPage01JobPostingExtended04()
        {

            JobPostingExtended jobPostingExtended
                = new JobPostingExtended(
                        jobPosting: CreateJobPage01JobPosting04(),
                        response: null, // Ignored
                        hiringOrgDescription: null,
                        publicationStartDate: new DateTime(2021, 07, 02),
                        publicationEndDate: new DateTime(2021, 08, 24),
                        purpose: null, // Ignored
                        numberToFill: 1,
                        contactEmail: null,
                        contactPersonName: "Majken Lorentzen",
                        employmentDate: null,
                        applicationDeadlineDate: new DateTime(2021, 08, 24),
                        bulletPoints: new HashSet<string>()
                            {
                                "Du har truckkort",
                                "Du kan lide at arbejde om aftenen",
                                "Du kan tale, skrive og læse dansk eller engelsk",
                                "Du kan arbejde selvstændigt",
                                "Du er grundig i dit arbejde",
                                "You have a forklift licence",
                                "You like working in the evenings",
                                "You can speak, write and read Danish or English",
                                "You can work independently",
                                "You are thorough in your work"
                            },
                        bulletPointScenario: "generic"
                    );

            return jobPostingExtended;

        }
        static void DeserializeJobPage01JobPostingExtended04()
        {

            IFileInfoAdapter fileInfoAdapter = new FileInfoAdapter(@"C:\Dropbox\Tasks\20210502 - NW.WIDJobs\New WID\JSONs\JobPage01_JobPostingExtended04.json");
            IFileManager fileManager = new FileManager();
            string response = fileManager.ReadAllText(fileInfoAdapter);

            JobPosting jobPosting = CreateJobPage01JobPosting04();

            IJobPostingExtendedDeserializer jobPostingExtendedDeserializer = new JobPostingExtendedDeserializer();
            JobPostingExtended jobPostingExtended = jobPostingExtendedDeserializer.Do(jobPosting, response);

            string json = Serialize(jobPostingExtended);

        }

        // JobPage01JobPosting05
        static JobPosting CreateJobPage01JobPosting05()
        {

            JobPosting jobPosting
                = new JobPosting(
                        runId: "temp",
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
                        jobPostingId: "5376524visgerrengringsassistenter"
                    );

            return jobPosting;

        }
        static JobPostingExtended CreateJobPage01JobPostingExtended05()
        {

            JobPostingExtended jobPostingExtended
                = new JobPostingExtended(
                        jobPosting: CreateJobPage01JobPosting05(),
                        response: null, // Ignored
                        hiringOrgDescription: null,
                        publicationStartDate: new DateTime(2021, 07, 02),
                        publicationEndDate: new DateTime(2021, 08, 19),
                        purpose: null, // Ignored
                        numberToFill: 20,
                        contactEmail: null,
                        contactPersonName: "Majken Lorentzen",
                        employmentDate: null,
                        applicationDeadlineDate: new DateTime(2021, 08, 19),
                        bulletPoints: new HashSet<string>()
                            {
                                "Fleksible arbejdstider",
                                "Attraktiv løn (DKK 180,- per time)",
                                "Kørselsgodtgørelse (statens takst)",
                                "Aktivt og alsidigt arbejde",
                                "Du kan arbejde i weekender",
                                "Du har egen bil til rådighed",
                                "Du kan lide aktivt arbejde",
                                "Du har erfaring fra tidligere arbejde – dog ikke et krav",
                                "Du taler, læser og skriver dansk, engelsk eller tysk",
                                "Flexible hours",
                                "Attractive salary (DKK 180 per hour)",
                                "Travel allowance (state tariff)",
                                "Active and versatile work",
                                "You can work on weekends",
                                "You have your own car available",
                                "You like active work",
                                "You have experience from previous work - not a requirement",
                                "You speak, read and write Danish, English or German"
                            },
                        bulletPointScenario: "generic"
                    );

            return jobPostingExtended;

        }
        static void DeserializeJobPage01JobPostingExtended05()
        {

            IFileInfoAdapter fileInfoAdapter = new FileInfoAdapter(@"C:\Dropbox\Tasks\20210502 - NW.WIDJobs\New WID\JSONs\JobPage01_JobPostingExtended05.json");
            IFileManager fileManager = new FileManager();
            string response = fileManager.ReadAllText(fileInfoAdapter);

            JobPosting jobPosting = CreateJobPage01JobPosting05();

            IJobPostingExtendedDeserializer jobPostingExtendedDeserializer = new JobPostingExtendedDeserializer();
            JobPostingExtended jobPostingExtended = jobPostingExtendedDeserializer.Do(jobPosting, response);

            string json = Serialize(jobPostingExtended);

        }

        // JobPage01JobPosting06
        static JobPosting CreateJobPage01JobPosting06()
        {

            JobPosting jobPosting
                = new JobPosting(
                        runId: "temp",
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
                        jobPostingId: "5303321motivatedemployeesforwarehousework"
                    );

            return jobPosting;

        }
        static JobPostingExtended CreateJobPage01JobPostingExtended06()
        {

            JobPostingExtended jobPostingExtended
                = new JobPostingExtended(
                        jobPosting: CreateJobPage01JobPosting06(),
                        response: null, // Ignored
                        hiringOrgDescription: null,
                        publicationStartDate: new DateTime(2021, 07, 02),
                        publicationEndDate: new DateTime(2021, 08, 27),
                        purpose: null, // Ignored
                        numberToFill: 12,
                        contactEmail: null,
                        contactPersonName: "Majken Lorentzen",
                        employmentDate: null,
                        applicationDeadlineDate: new DateTime(2021, 08, 27),
                        bulletPoints: new HashSet<string>()
                            {
                                "A social workplace",
                                "Day shifts",
                                "A healthy working environment",
                                "Good colleagues",
                                "Training in warehouse work such as picking, packing, sorting and much more",
                                "You would like to work in a warehouse",
                                "You like active work",
                                "You can work full time – part time work can also be arranged",
                                "You can work independently"
                            },
                        bulletPointScenario: "generic"
                    );

            return jobPostingExtended;

        }
        static void DeserializeJobPage01JobPostingExtended06()
        {

            IFileInfoAdapter fileInfoAdapter = new FileInfoAdapter(@"C:\Dropbox\Tasks\20210502 - NW.WIDJobs\New WID\JSONs\JobPage01_JobPostingExtended06.json");
            IFileManager fileManager = new FileManager();
            string response = fileManager.ReadAllText(fileInfoAdapter);

            JobPosting jobPosting = CreateJobPage01JobPosting06();

            IJobPostingExtendedDeserializer jobPostingExtendedDeserializer = new JobPostingExtendedDeserializer();
            JobPostingExtended jobPostingExtended = jobPostingExtendedDeserializer.Do(jobPosting, response);

            string json = Serialize(jobPostingExtended);

        }

        // JobPage01JobPosting07
        static JobPosting CreateJobPage01JobPosting07()
        {

            JobPosting jobPosting
                = new JobPosting(
                        runId: "temp",
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
                        jobPostingId: "5290988motivatedemployeesforwarehousework"
                    );

            return jobPosting;

        }
        static JobPostingExtended CreateJobPage01JobPostingExtended07()
        {

            JobPostingExtended jobPostingExtended
                = new JobPostingExtended(
                        jobPosting: CreateJobPage01JobPosting07(),
                        response: null, // Ignored
                        hiringOrgDescription: null,
                        publicationStartDate: new DateTime(2021, 07, 02),
                        publicationEndDate: new DateTime(2021, 08, 27),
                        purpose: null, // Ignored
                        numberToFill: 12,
                        contactEmail: null,
                        contactPersonName: "Majken Lorentzen",
                        employmentDate: null,
                        applicationDeadlineDate: new DateTime(2021, 08, 27),
                        bulletPoints: new HashSet<string>()
                            {
                                "A social workplace",
                                "Day and evening shifts",
                                "Full time work and part time work",
                                "A healthy working environment",
                                "Good colleagues",
                                "Training in warehouse work such as picking, packing, sorting and much more",
                                "You would like to work in a warehouse",
                                "You like active work",
                                "You can work full time or part time",
                                "You can work independently"
                            },
                        bulletPointScenario: "generic"
                    );

            return jobPostingExtended;

        }
        static void DeserializeJobPage01JobPostingExtended07()
        {

            IFileInfoAdapter fileInfoAdapter = new FileInfoAdapter(@"C:\Dropbox\Tasks\20210502 - NW.WIDJobs\New WID\JSONs\JobPage01_JobPostingExtended07.json");
            IFileManager fileManager = new FileManager();
            string response = fileManager.ReadAllText(fileInfoAdapter);

            JobPosting jobPosting = CreateJobPage01JobPosting07();

            IJobPostingExtendedDeserializer jobPostingExtendedDeserializer = new JobPostingExtendedDeserializer();
            JobPostingExtended jobPostingExtended = jobPostingExtendedDeserializer.Do(jobPosting, response);

            string json = Serialize(jobPostingExtended);

        }

        // JobPage01JobPosting08
        static JobPosting CreateJobPage01JobPosting08()
        {

            JobPosting jobPosting
                = new JobPosting(
                        runId: "temp",
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
                        jobPostingId: "5383229vicepresidentofproductmarketing"
                    );

            return jobPosting;

        }
        static JobPostingExtended CreateJobPage01JobPostingExtended08()
        {

            JobPostingExtended jobPostingExtended
                = new JobPostingExtended(
                        jobPosting: CreateJobPage01JobPosting08(),
                        response: null, // Ignored
                        hiringOrgDescription: null,
                        publicationStartDate: new DateTime(2021, 07, 02),
                        publicationEndDate: new DateTime(2021, 08, 27),
                        purpose: null, // Ignored
                        numberToFill: 1,
                        contactEmail: "edc@keepit.com",
                        contactPersonName: "Emil Daniel Christensen",
                        employmentDate: null,
                        applicationDeadlineDate: new DateTime(2021, 08, 27),
                        bulletPoints: new HashSet<string>()
                            {
                                "As a Vice President, we expect a truly transparent and inclusive leadership style, empowering your team to perform at their maximum abilities.\\u00A0\\u00A0",
                                "Facilitate outstanding collaborations between the product marketing team and the full brand & marketing team as well as\\u00A0internal core stakeholders such as product\\u00A0management\\u00A0and sales\\u00A0",
                                "Help us\\u00A0articulate\\u00A0and implement\\u00A0a\\u00A0global product marketing\\u00A0strategy\\u00A0·Serve as an evangelist for our products through thought leadership\\u00A0\\u00A0",
                                "Keep the company up-to-date with market trends and competition\\u00A0\\u00A0",
                                "Product Marketing Strategy:\\u00A0We are looking for a profile that can help us define the right strategies that will\\u00A0fuel our continued growth.\\u00A0Having experience with making product marketing strategies for SaaS products\\u00A0is a requirement.\\u00A0",
                                "Product Marketing:\\u00A0The right candidate has\\u00A0a\\u00A0solid\\u00A0product marketing skill-set\\u00A0with an entrepreneurial spirit.\\u00A0You\\u00A0know how to\\u00A0deliver\\u00A0sales\\u00A0enablement content\\u00A0and can execute marketing initiatives, including aligning and getting buy-in from stakeholders across the organization (including marketing, product, and sales).\\u00A0",
                                "Leadership Style:\\u00A0We believe that the right candidate\\u00A0has the ability to\\u00A0inspire\\u00A0the\\u00A0team\\u00A0with an including and transparent leadership style.\\u00A0",
                                "Language:\\u00A0We use English as our preferred language, and being fluent in English, both written and spoken, is essential for this role.\\u00A0",
                                "Entrepreneurial spirit:\\u00A0We are passionate about winning in the market. However, we are also passionate about our workplace, and we know that a good work environment and great collaboration across our organization are crucial to achieving our ambitious goals. Therefore, we are searching for team leaders who, like us, are being motivated by building a fair and fun work environment at Keepit."
                            },
                        bulletPointScenario: "generic"
                    );

            return jobPostingExtended;

        }
        static void DeserializeJobPage01JobPostingExtended08()
        {

            IFileInfoAdapter fileInfoAdapter = new FileInfoAdapter(@"C:\Dropbox\Tasks\20210502 - NW.WIDJobs\New WID\JSONs\JobPage01_JobPostingExtended08.json");
            IFileManager fileManager = new FileManager();
            string response = fileManager.ReadAllText(fileInfoAdapter);

            JobPosting jobPosting = CreateJobPage01JobPosting08();

            IJobPostingExtendedDeserializer jobPostingExtendedDeserializer = new JobPostingExtendedDeserializer();
            JobPostingExtended jobPostingExtended = jobPostingExtendedDeserializer.Do(jobPosting, response);

            string json = Serialize(jobPostingExtended);

        }

        // JobPage01JobPosting09


        // ...
        static string Serialize(JobPostingExtended jobPostingExtended)
        {

            dynamic dyn = new ExpandoObject();
            dyn.HiringOrgDescription = jobPostingExtended.HiringOrgDescription;
            dyn.PublicationStartDate = jobPostingExtended.PublicationStartDate;
            dyn.PublicationEndDate = jobPostingExtended.PublicationEndDate;
            dyn.NumberToFill = jobPostingExtended.NumberToFill;
            dyn.ContactEmail = jobPostingExtended.ContactEmail;
            dyn.ContactPersonName = jobPostingExtended.ContactPersonName;
            dyn.EmploymentDate = jobPostingExtended.EmploymentDate;
            dyn.ApplicationDeadlineDate = jobPostingExtended.ApplicationDeadlineDate;
            dyn.BulletPoints = jobPostingExtended.BulletPoints;
            dyn.BulletPointScenario = jobPostingExtended.BulletPointScenario;
            // dyn.JobPosting = jobPostingExtended.JobPosting;
            // dyn.Response = jobPostingExtended.Response;
            // dyn.Purpose = jobPostingExtended.Purpose;

            JsonSerializerOptions jso = new JsonSerializerOptions
            {
                Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping,
                WriteIndented = true
            };

            string json = JsonSerializer.Serialize(dyn, jso);
            json = json.Replace("\r\n", string.Empty);

            return json;

        }
        static void DeserializeJobPage02JobPostingExtended10()
        {

            IFileInfoAdapter fileInfoAdapter = new FileInfoAdapter(@"C:\Dropbox\Tasks\20210502 - NW.WIDJobs\New WID\JSONs\JobPage02_JobPostingExtended10.html");
            IFileManager fileManager = new FileManager();
            string response = fileManager.ReadAllText(fileInfoAdapter);

            JobPosting jobPosting = CreateJobPage01JobPosting01();

            IJobPostingExtendedDeserializer jobPostingExtendedDeserializer = new JobPostingExtendedDeserializer();
            JobPostingExtended jobPostingExtended = jobPostingExtendedDeserializer.Do(jobPosting, response);

        }
        static WIDExplorer CreateExplorer()
        {

            WIDExplorerSettings settings
                = new WIDExplorerSettings(
                        WIDExplorerSettings.DefaultParallelRequests,
                        WIDExplorerSettings.DefaultPauseBetweenRequestsMs,
                        @"C:\Users\Rubèn\Desktop\",
                        WIDExplorerSettings.DefaultDeleteAndRecreateDatabase
                        );
            WIDExplorer explorer
                = new WIDExplorer(new WIDExplorerComponents(), settings, WIDExplorer.DefaultNowFunction);

            return explorer;

        }
        static void ExploreFirstPageAllCategories()
        {

            WIDExplorer explorer = CreateExplorer();
            explorer.LogAsciiBanner();

            WIDExploration exploration
                = explorer.Explore(1, WIDCategories.AllCategories, WIDStages.Stage3_UpToAllPageItemsExtended);
            WIDMetrics metrics = explorer.ConvertToMetrics(exploration);

            explorer.SaveAsJson(exploration);
            explorer.SaveAsSQLite(exploration.PageItemsExtended);
            explorer.SaveAsJson(metrics, false);
            explorer.SaveAsJson(metrics, true);

        }
        static void ExploreAllITTech()
        {

            WIDExplorer explorer = CreateExplorer();
            explorer.LogAsciiBanner();

            WIDExploration exploration
                = explorer.ExploreAll(WIDCategories.ItTech, WIDStages.Stage3_UpToAllPageItemsExtended);
            WIDMetrics metrics = explorer.ConvertToMetrics(exploration);

            explorer.SaveAsJson(exploration);
            explorer.SaveAsSQLite(exploration.PageItemsExtended);
            explorer.SaveAsJson(metrics, false);
            explorer.SaveAsJson(metrics, true);

        }

    }

}

/*
    Author: numbworks@gmail.com
    Last Update: 12.06.2021
*/