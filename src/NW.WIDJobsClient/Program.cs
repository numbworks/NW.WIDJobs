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

            DeserializeJobPage02JobPostingExtended15();

            WIDExplorerComponents.DefaultLoggingAction.Invoke("Press a button to close the window.");
            Console.ReadLine();

        }
        static void DeserializeJobPage02()
        {

            IFileInfoAdapter fileInfoAdapter = new FileInfoAdapter(@"C:\Dropbox\Tasks\20210502 - NW.WIDJobs\New WID\JSONs\JobPage02.json");
            IFileManager fileManager = new FileManager();
            string response = fileManager.ReadAllText(fileInfoAdapter);

            JobPage jobPage = new JobPage("temp", 2, response);

            IJobPostingDeserializer jobPostingDeserializer = new JobPostingDeserializer();
            List<JobPosting> jobPostings = jobPostingDeserializer.Do(jobPage);

            JsonSerializerOptions jso = new JsonSerializerOptions
            {
                Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping,
                WriteIndented = true
            };

            string json = JsonSerializer.Serialize(jobPostings, jso);
        
            fileManager.WriteAllText(
                new FileInfoAdapter(@"C:\Users\Rubèn\Desktop\Serialized_JobPage02.json"),
                json
                );

        }

        #region Shared_JobPage01

        static void DeserializeJobPage01()
        {

            IFileInfoAdapter fileInfoAdapter = new FileInfoAdapter(@"C:\Dropbox\Tasks\20210502 - NW.WIDJobs\New WID\JSONs\JobPage01.json");
            IFileManager fileManager = new FileManager();
            string response = fileManager.ReadAllText(fileInfoAdapter);

            JobPage jobPage = new JobPage("temp", 1, response);

            IJobPostingDeserializer jobPostingDeserializer = new JobPostingDeserializer();
            List<JobPosting> jobPostings = jobPostingDeserializer.Do(jobPage);

            JsonSerializerOptions jso = new JsonSerializerOptions
            {
                Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping,
                WriteIndented = true
            };

            string json = JsonSerializer.Serialize(jobPostings, jso);

            /*            
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
            static JobPosting CreateJobPage01JobPosting09()
            {

                JobPosting jobPosting
                    = new JobPosting(
                            runId: "temp",
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
                            jobPostingId: "5331002friskeogoplagtemedarbejderetil"
                        );

                return jobPosting;

            }
            static JobPostingExtended CreateJobPage01JobPostingExtended09()
            {

                JobPostingExtended jobPostingExtended
                    = new JobPostingExtended(
                            jobPosting: CreateJobPage01JobPosting09(),
                            response: null, // Ignored
                            hiringOrgDescription: null,
                            publicationStartDate: new DateTime(2021, 07, 02),
                            publicationEndDate: new DateTime(2021, 07, 15),
                            purpose: null, // Ignored
                            numberToFill: 5,
                            contactEmail: null,
                            contactPersonName: "Majken Lorentzen",
                            employmentDate: null,
                            applicationDeadlineDate: new DateTime(2021, 07, 15),
                            bulletPoints: new HashSet<string>()
                                {
                                    "Ordnede forhold",
                                    "En social arbejdsplads med gode kollegaer",
                                    "Fleksibilitet vedr. vagter",
                                    "Mulighed for vagter både på hverdage og i weekender",
                                    "Du har lyst til at arbejde inden for lager og logistik",
                                    "Du er fleksibel",
                                    "Du kan arbejde minimum 2 dage om ugen",
                                    "Du kan arbejde om eftermiddagen og aftenen",
                                    "Du har en god fysik",
                                    "Du kan lide at arbejde i teams",
                                    "Orderly conditions",
                                    "A social workplace with good colleagues",
                                    "Flexibility regarding shifts",
                                    "Possibility of shifts both on weekdays and on weekends",
                                    "You want to work in warehousing and logistics",
                                    "You are flexible",
                                    "You can work a minimum of 2 days a week",
                                    "You can work in the afternoon and evening time",
                                    "You have a good physique",
                                    "You like working in teams"
                                },
                            bulletPointScenario: "generic"
                        );

                return jobPostingExtended;

            }
            static void DeserializeJobPage01JobPostingExtended09()
            {

                IFileInfoAdapter fileInfoAdapter = new FileInfoAdapter(@"C:\Dropbox\Tasks\20210502 - NW.WIDJobs\New WID\JSONs\JobPage01_JobPostingExtended09.json");
                IFileManager fileManager = new FileManager();
                string response = fileManager.ReadAllText(fileInfoAdapter);

                JobPosting jobPosting = CreateJobPage01JobPosting09();

                IJobPostingExtendedDeserializer jobPostingExtendedDeserializer = new JobPostingExtendedDeserializer();
                JobPostingExtended jobPostingExtended = jobPostingExtendedDeserializer.Do(jobPosting, response);

                string json = Serialize(jobPostingExtended);

            }

            // JobPage01JobPosting10
            static JobPosting CreateJobPage01JobPosting10()
            {

                JobPosting jobPosting
                    = new JobPosting(
                            runId: "temp",
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
                            jobPostingId: "5383212tenuretrackassistantprofessorin"
                        );

                return jobPosting;

            }
            static JobPostingExtended CreateJobPage01JobPostingExtended10()
            {

                JobPostingExtended jobPostingExtended
                    = new JobPostingExtended(
                            jobPosting: CreateJobPage01JobPosting10(),
                            response: null, // Ignored
                            hiringOrgDescription: null,
                            publicationStartDate: null,
                            publicationEndDate: null,
                            purpose: null, // Ignored
                            numberToFill: null,
                            contactEmail: null,
                            contactPersonName: null,
                            employmentDate: null,
                            applicationDeadlineDate: null,
                            bulletPoints: new HashSet<string>()
                                {
                                    "PhD degree and post doc research experience within applied statistics or similar aspects",
                                    "Proven publication record in international peer-reviewed ISI journals",
                                    "Strong expertise in classical statistical methods (analysis of variance, regression analysis, mixed model analysis, generalized linear models, categorical data analysis, non-parametric analysis, multivariate data analysis) and in areas such as spatial statistics, image analysis, time series analysis and machine learning. We are aware that candidates may not have strong expertise in all areas, but we expect the applicant to have at least some knowledge in the areas mentioned.",
                                    "The ability to manage, participate, collaborate and communicate in interdisciplinary research, and to participate in joint projects with other scientists.",
                                    "Skills in clearly communicating statistical methods and results to persons with non-statistical background.",
                                    "attract outstanding talented individuals that are competitive at an international level",
                                    "to promote the early development of independent research success early in the career of scientists",
                                    "to create transparency in the academic career path",
                                    "access to research infrastructure",
                                    "capability development, including postgraduate teacher training",
                                    "a mentoring programme",
                                    "support to develop scientific networks and to secure interdisciplinary research at the highest level"
                                },
                            bulletPointScenario: "generic"
                        );

                return jobPostingExtended;

            }
            static void DeserializeJobPage01JobPostingExtended10()
            {

                IFileInfoAdapter fileInfoAdapter = new FileInfoAdapter(@"C:\Dropbox\Tasks\20210502 - NW.WIDJobs\New WID\JSONs\JobPage01_JobPostingExtended10.json");
                IFileManager fileManager = new FileManager();
                string response = fileManager.ReadAllText(fileInfoAdapter);

                JobPosting jobPosting = CreateJobPage01JobPosting10();

                IJobPostingExtendedDeserializer jobPostingExtendedDeserializer = new JobPostingExtendedDeserializer();
                JobPostingExtended jobPostingExtended = jobPostingExtendedDeserializer.Do(jobPosting, response);

                string json = Serialize(jobPostingExtended);

            }

            // JobPage01JobPosting11
            static JobPosting CreateJobPage01JobPosting11()
            {

                JobPosting jobPosting
                    = new JobPosting(
                            runId: "temp",
                            pageNumber: 1,
                            response: "{\r\n            \"AutomatchType\": 0,\r\n            \"Abroad\": false,\r\n            \"Weight\": 1.0,\r\n            \"Title\": \"Committed employees for assembling displays in a large warehouse in Hedensted.\",\r\n            \"JobHeadline\": \"Committed employees for assembling displays in a large warehouse in Hedensted.\",\r\n            \"Presentation\": \" Our costumer is busy and they need employees to help in their warehouse. \\n  We offer  \\n \\n Work in a large international company \\n Possibility of day shifts\",\r\n            \"HiringOrgName\": \"TeamVikaren.dk, Århus ApS, Horsens Afdeling\",\r\n            \"WorkPlaceAddress\": \"\",\r\n            \"WorkPlacePostalCode\": \"8722\",\r\n            \"WorkPlaceCity\": \"Hedensted\",\r\n            \"WorkPlaceOtherAddress\": true,\r\n            \"WorkPlaceAbroad\": false,\r\n            \"WorkPlaceNotStatic\": false,\r\n            \"UseWorkPlaceAddressForJoblog\": false,\r\n            \"PostingCreated\": \"2021-07-02T00:00:00\",\r\n            \"LastDateApplication\": \"2021-07-29T00:00:00\",\r\n            \"FormattedLastDateApplication\": \"29. juli 2021\",\r\n            \"AssignmentStartDate\": \"0001-01-01T00:00:00\",\r\n            \"IsHotjob\": false,\r\n            \"IsExternal\": false,\r\n            \"Url\": \"https://job.jobnet.dk/CV/FindWork/Details/5361275\",\r\n            \"Region\": \"Midtjylland\",\r\n            \"Municipality\": \"Hedensted\",\r\n            \"Country\": \"Danmark\",\r\n            \"PostalCode\": \"8722\",\r\n            \"PostalCodeName\": null,\r\n            \"JobAnnouncementType\": \"\",\r\n            \"EmploymentType\": \"\",\r\n            \"WorkHours\": \"Fuldtid\",\r\n            \"OccupationArea\": \"\",\r\n            \"OccupationGroup\": \"\",\r\n            \"Occupation\": \"Lager- og logistikmedarbejder\",\r\n            \"Location\": {\r\n                \"Latitude\": 55.7651,\r\n                \"Longitude\": 9.7113\r\n            },\r\n            \"JoblogWorkTime\": {\r\n                \"WorkHour\": null,\r\n                \"DailyWorkTime\": \"Dag\"\r\n            },\r\n            \"WorkplaceID\": 126565,\r\n            \"OrganisationId\": \"71174\",\r\n            \"HiringOrgCVR\": 30899695,\r\n            \"UserLoggedIn\": false,\r\n            \"AnonymousEmployer\": false,\r\n            \"ShareUrl\": \"https://job.jobnet.dk/CV/FindWork/DetailsSocialmedia/5361275\",\r\n            \"DetailsUrl\": \"https://job.jobnet.dk/CV/FindWork/DetailsWidk/5361275\",\r\n            \"JobLogUrl\": \"https://job.jobnet.dk/CV/FindWork/Details/5361275\",\r\n            \"HasLocationValues\": true,\r\n            \"ID\": \"5361275\",\r\n            \"Latitude\": 55.7651,\r\n            \"Longitude\": 9.7113\r\n        }",
                            title: "Committed employees for assembling displays in a large warehouse in Hedensted.",
                            presentation: " Our costumer is busy and they need employees to help in their warehouse. \n  We offer  \n \n Work in a large international company \n Possibility of day shifts",
                            hiringOrgName: "TeamVikaren.dk, Århus ApS, Horsens Afdeling",
                            workPlaceAddress: "",
                            workPlacePostalCode: 8722,
                            workPlaceCity: "Hedensted",
                            postingCreated: new DateTime(2021, 07, 20),
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
                            jobPostingId: "5361275committedemployeesforassemblingdisplays"
                        );

                return jobPosting;

            }
            static JobPostingExtended CreateJobPage01JobPostingExtended11()
            {

                JobPostingExtended jobPostingExtended
                    = new JobPostingExtended(
                            jobPosting: CreateJobPage01JobPosting11(),
                            response: null, // Ignored
                            hiringOrgDescription: null,
                            publicationStartDate: new DateTime(2021, 07, 02),
                            publicationEndDate: new DateTime(2021, 07, 29),
                            purpose: null, // Ignored
                            numberToFill: 1,
                            contactEmail: null,
                            contactPersonName: "Majken Lorentzen",
                            employmentDate: null,
                            applicationDeadlineDate: new DateTime(2021, 07, 29),
                            bulletPoints: new HashSet<string>()
                                {
                                    "Work in a large international company",
                                    "Possibility of day shifts",
                                    "A social workplace with good colleagues",
                                    "Thorough training",
                                    "You are flexible during busy periods",
                                    "You have an eye for detail",
                                    "You can work full time",
                                    "You can work independently",
                                    "You are thorough and take pride in your work"
                                },
                            bulletPointScenario: "generic"
                        );

                return jobPostingExtended;

            }
            static void DeserializeJobPage01JobPostingExtended11()
            {

                IFileInfoAdapter fileInfoAdapter = new FileInfoAdapter(@"C:\Dropbox\Tasks\20210502 - NW.WIDJobs\New WID\JSONs\JobPage01_JobPostingExtended11.json");
                IFileManager fileManager = new FileManager();
                string response = fileManager.ReadAllText(fileInfoAdapter);

                JobPosting jobPosting = CreateJobPage01JobPosting11();

                IJobPostingExtendedDeserializer jobPostingExtendedDeserializer = new JobPostingExtendedDeserializer();
                JobPostingExtended jobPostingExtended = jobPostingExtendedDeserializer.Do(jobPosting, response);

                string json = Serialize(jobPostingExtended);

            }

            // JobPage01JobPosting12
            static JobPosting CreateJobPage01JobPosting12()
            {

                JobPosting jobPosting
                    = new JobPosting(
                            runId: "temp",
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
                            id: 5361275,
                            workPlaceCityWithoutZone: "Horsens",
                            jobPostingNumber: 12,
                            jobPostingId: "5359775wearelookingforforklift"
                        );

                return jobPosting;

            }
            static JobPostingExtended CreateJobPage01JobPostingExtended12()
            {

                JobPostingExtended jobPostingExtended
                    = new JobPostingExtended(
                            jobPosting: CreateJobPage01JobPosting12(),
                            response: null, // Ignored
                            hiringOrgDescription: null,
                            publicationStartDate: new DateTime(2021, 07, 02),
                            publicationEndDate: new DateTime(2021, 07, 28),
                            purpose: null, // Ignored
                            numberToFill: 6,
                            contactEmail: null,
                            contactPersonName: "Majken Lorentzen",
                            employmentDate: null,
                            applicationDeadlineDate: new DateTime(2021, 07, 28),
                            bulletPoints: new HashSet<string>()
                                {
                                    "Good work conditions",
                                    "A social workplace with good colleagues",
                                    "Flexibility regarding shifts",
                                    "Possibility for day shifts, evening shifts and night shifts.",
                                    "You want to work in warehousing and logistics",
                                    "You are flexible",
                                    "You can work a minimum of 3 weeks in the period week 24 - 34",
                                    "You can work either day, evening or night shift",
                                    "You have experience with forklift driving",
                                    "You like working in teams",
                                    "in Horsens from 06.00–14.00 or 07.00-15.00",
                                    "in Skanderborg from 08.00-16.00",
                                    "in Fredericia from 06.00-14.00",
                                    "in Horsens from00-22.00 / 15.00-23.00",
                                    "in Skanderborg from 15.00-23.00",
                                    "in Horsens from 22.00-06.00",
                                    "in Skanderborg from 22.00-06.00",
                                    "in Fredericia from 23.00-06.30",
                                    "Uporządkowane warunki",
                                    "Socjalne miejsce pracy z dobrymi kolegami",
                                    "Elastyczność w zakresie zmian pracy",
                                    "Możliwość pracy na zmianach dziennych, wieczornych i nocnych.",
                                    "Masz ochotę pracować w magazynach i logistyce",
                                    "Jesteś elastyczny",
                                    "Możesz pracować minimum 3 tygodnie w okresie od 24 do 34 tygodnia",
                                    "Możesz pracować na dziennej, wieczornej lub nocnej zmianie",
                                    "Masz doświadczenie w prowadzeniu wózka widłowego",
                                    "Lubisz prace w grupach",
                                    "Potrafisz mówić ,czytać i rozumieć duński lub angielski",
                                    "w Horsens w 06.00-14.00 / 07.00-15.00",
                                    "w Skanderborgu w 08.00-16.00",
                                    "w Fredericii w 06.00-14.00",
                                    "w Horsens w 14.00-22.00 / 15.00-23.00",
                                    "w Skanderborgu w 15.00-23.00",
                                    "w Horsens w 22.00-06.00",
                                    "w Skanderborgu w 22.00-06.00",
                                    "w Fredericii w 23.00-06.30"
                                },
                            bulletPointScenario: "generic"
                        );

                return jobPostingExtended;

            }
            static void DeserializeJobPage01JobPostingExtended12()
            {

                IFileInfoAdapter fileInfoAdapter = new FileInfoAdapter(@"C:\Dropbox\Tasks\20210502 - NW.WIDJobs\New WID\JSONs\JobPage01_JobPostingExtended12.json");
                IFileManager fileManager = new FileManager();
                string response = fileManager.ReadAllText(fileInfoAdapter);

                JobPosting jobPosting = CreateJobPage01JobPosting12();

                IJobPostingExtendedDeserializer jobPostingExtendedDeserializer = new JobPostingExtendedDeserializer();
                JobPostingExtended jobPostingExtended = jobPostingExtendedDeserializer.Do(jobPosting, response);

                string json = Serialize(jobPostingExtended);

            }

            // JobPage01JobPosting13
            static JobPosting CreateJobPage01JobPosting13()
            {

                JobPosting jobPosting
                    = new JobPosting(
                            runId: "temp",
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
                            jobPostingId: "5383201laboratorytechnicianforplantanalysis"
                        );

                return jobPosting;

            }
            static JobPostingExtended CreateJobPage01JobPostingExtended13()
            {

                JobPostingExtended jobPostingExtended
                    = new JobPostingExtended(
                            jobPosting: CreateJobPage01JobPosting13(),
                            response: null, // Ignored
                            hiringOrgDescription: null,
                            publicationStartDate: null,
                            publicationEndDate: null,
                            purpose: null, // Ignored
                            numberToFill: null,
                            contactEmail: null,
                            contactPersonName: null,
                            employmentDate: null,
                            applicationDeadlineDate: null,
                            bulletPoints: new HashSet<string>()
                                {
                                    "Analysis of plant ingredients e.g. phenols, carbohydrates, polyacetylenes, glucosinolates, etc. using HPLC, GC-MS, and IC",
                                    "Microbiology",
                                    "Laboratory guidance of students and researchers",
                                    "Method development",
                                    "Sample collection, sample preparation and data processing",
                                    "Maintenance of various analysis equipment and laboratory management",
                                    "Photography in studios and ‘on the spot’ plants, plant products and experimental setup as documentation of the experimental work."
                                },
                            bulletPointScenario: "generic"
                        );

                return jobPostingExtended;

            }
            static void DeserializeJobPage01JobPostingExtended13()
            {

                IFileInfoAdapter fileInfoAdapter = new FileInfoAdapter(@"C:\Dropbox\Tasks\20210502 - NW.WIDJobs\New WID\JSONs\JobPage01_JobPostingExtended13.json");
                IFileManager fileManager = new FileManager();
                string response = fileManager.ReadAllText(fileInfoAdapter);

                JobPosting jobPosting = CreateJobPage01JobPosting13();

                IJobPostingExtendedDeserializer jobPostingExtendedDeserializer = new JobPostingExtendedDeserializer();
                JobPostingExtended jobPostingExtended = jobPostingExtendedDeserializer.Do(jobPosting, response);

                string json = Serialize(jobPostingExtended);

            }

            // JobPage01JobPosting14
            static JobPosting CreateJobPage01JobPosting14()
            {

                JobPosting jobPosting
                    = new JobPosting(
                            runId: "temp",
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
                            jobPostingId: "5383195laboratorytechnicianforfoodprocessing"
                        );

                return jobPosting;

            }
            static JobPostingExtended CreateJobPage01JobPostingExtended14()
            {

                JobPostingExtended jobPostingExtended
                    = new JobPostingExtended(
                            jobPosting: CreateJobPage01JobPosting14(),
                            response: null, // Ignored
                            hiringOrgDescription: null,
                            publicationStartDate: null,
                            publicationEndDate: null,
                            purpose: null, // Ignored
                            numberToFill: null,
                            contactEmail: null,
                            contactPersonName: null,
                            employmentDate: null,
                            applicationDeadlineDate: null,
                            bulletPoints: new HashSet<string>()
                                {
                                    "Analysis with ICP-MS and HPLC",
                                    "Working with food processing in laboratory / pilot scale",
                                    "Laboratory guidance of students and researchers",
                                    "Method development",
                                    "Sample collection, sample preparation and data processing",
                                    "Maintenance of various analysis equipment and laboratory management",
                                    "Purchase of consumables and minor equipment for the laboratory."
                                },
                            bulletPointScenario: "generic"
                        );

                return jobPostingExtended;

            }
            static void DeserializeJobPage01JobPostingExtended14()
            {

                IFileInfoAdapter fileInfoAdapter = new FileInfoAdapter(@"C:\Dropbox\Tasks\20210502 - NW.WIDJobs\New WID\JSONs\JobPage01_JobPostingExtended14.json");
                IFileManager fileManager = new FileManager();
                string response = fileManager.ReadAllText(fileInfoAdapter);

                JobPosting jobPosting = CreateJobPage01JobPosting14();

                IJobPostingExtendedDeserializer jobPostingExtendedDeserializer = new JobPostingExtendedDeserializer();
                JobPostingExtended jobPostingExtended = jobPostingExtendedDeserializer.Do(jobPosting, response);

                string json = Serialize(jobPostingExtended);

            }

            // JobPage01JobPosting15
            static JobPosting CreateJobPage01JobPosting15()
            {

                JobPosting jobPosting
                    = new JobPosting(
                            runId: "temp",
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
                            jobPostingId: "5383165lagermedarbejderetilpakkeopgaverpdaghold"
                        );

                return jobPosting;

            }
            static JobPostingExtended CreateJobPage01JobPostingExtended15()
            {

                JobPostingExtended jobPostingExtended
                    = new JobPostingExtended(
                            jobPosting: CreateJobPage01JobPosting15(),
                            response: null, // Ignored
                            hiringOrgDescription: null,
                            publicationStartDate: new DateTime(2021, 07, 02),
                            publicationEndDate: new DateTime(2021, 08, 27),
                            purpose: null, // Ignored
                            numberToFill: null,
                            contactEmail: null,
                            contactPersonName: "Majken Lorentzen",
                            employmentDate: null,
                            applicationDeadlineDate: new DateTime(2021, 08, 27),
                            bulletPoints: new HashSet<string>() { },
                            bulletPointScenario: "regex"
                        );

                return jobPostingExtended;

            }
            static void DeserializeJobPage01JobPostingExtended15()
            {

                IFileInfoAdapter fileInfoAdapter = new FileInfoAdapter(@"C:\Dropbox\Tasks\20210502 - NW.WIDJobs\New WID\JSONs\JobPage01_JobPostingExtended15.json");
                IFileManager fileManager = new FileManager();
                string response = fileManager.ReadAllText(fileInfoAdapter);

                JobPosting jobPosting = CreateJobPage01JobPosting15();

                IJobPostingExtendedDeserializer jobPostingExtendedDeserializer = new JobPostingExtendedDeserializer();
                JobPostingExtended jobPostingExtended = jobPostingExtendedDeserializer.Do(jobPosting, response);

                string json = Serialize(jobPostingExtended);

            }

            // JobPage01JobPosting16
            static JobPosting CreateJobPage01JobPosting16()
            {

                JobPosting jobPosting
                    = new JobPosting(
                            runId: "temp",
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
                            jobPostingId: "5346333motivatedemployeeforemptyingcontainers"
                        );

                return jobPosting;

            }
            static JobPostingExtended CreateJobPage01JobPostingExtended16()
            {

                JobPostingExtended jobPostingExtended
                    = new JobPostingExtended(
                            jobPosting: CreateJobPage01JobPosting16(),
                            response: null, // Ignored
                            hiringOrgDescription: null,
                            publicationStartDate: new DateTime(2021, 07, 02),
                            publicationEndDate: new DateTime(2021, 07, 12),
                            purpose: null, // Ignored
                            numberToFill: 5,
                            contactEmail: null,
                            contactPersonName: "Majken Lorentzen",
                            employmentDate: null,
                            applicationDeadlineDate: new DateTime(2021, 07, 12),
                            bulletPoints: new HashSet<string>()
                            {
                                "A social workplace",
                                "Active work",
                                "Day and evening shifts",
                                "A healthy working environment",
                                "Good colleagues",
                                "You would like to work in a warehouse",
                                "You like active and physical work",
                                "You can work full time or part time",
                                "You can work independently"
                            },
                            bulletPointScenario: "generic"
                        );

                return jobPostingExtended;

            }
            static void DeserializeJobPage01JobPostingExtended16()
            {

                IFileInfoAdapter fileInfoAdapter = new FileInfoAdapter(@"C:\Dropbox\Tasks\20210502 - NW.WIDJobs\New WID\JSONs\JobPage01_JobPostingExtended16.json");
                IFileManager fileManager = new FileManager();
                string response = fileManager.ReadAllText(fileInfoAdapter);

                JobPosting jobPosting = CreateJobPage01JobPosting16();

                IJobPostingExtendedDeserializer jobPostingExtendedDeserializer = new JobPostingExtendedDeserializer();
                JobPostingExtended jobPostingExtended = jobPostingExtendedDeserializer.Do(jobPosting, response);

                string json = Serialize(jobPostingExtended);

            }

            // JobPage01JobPosting17
            static JobPosting CreateJobPage01JobPosting17()
            {

                JobPosting jobPosting
                    = new JobPosting(
                            runId: "temp",
                            pageNumber: 1,
                            response: "{\r\n            \"AutomatchType\": 0,\r\n            \"Abroad\": false,\r\n            \"Weight\": 1.0,\r\n            \"Title\": \"Medarbejdere til sommer vikariater på lager i Kolding/Employees for temporary summer positions in a warehouse in Kolding\",\r\n            \"JobHeadline\": \"Medarbejdere til sommer vikariater på lager i Kolding/Employees for temporary summer positions in a warehouse in Kolding\",\r\n            \"Presentation\": \" \u00A0 \\n  English version below the Danish  \\n Har du lyst til at arbejde på lager, og kan du arbejde i perioden 12/7 til 30/9 på daghold, så har vi arbejde til dig. \\n \",\r\n            \"HiringOrgName\": \"TeamVikaren.dk, Århus ApS, Horsens Afdeling\",\r\n            \"WorkPlaceAddress\": \"\",\r\n            \"WorkPlacePostalCode\": \"6000\",\r\n            \"WorkPlaceCity\": \"Kolding\",\r\n            \"WorkPlaceOtherAddress\": true,\r\n            \"WorkPlaceAbroad\": false,\r\n            \"WorkPlaceNotStatic\": false,\r\n            \"UseWorkPlaceAddressForJoblog\": false,\r\n            \"PostingCreated\": \"2021-07-02T00:00:00\",\r\n            \"LastDateApplication\": \"2021-08-19T00:00:00\",\r\n            \"FormattedLastDateApplication\": \"19. august 2021\",\r\n            \"AssignmentStartDate\": \"0001-01-01T00:00:00\",\r\n            \"IsHotjob\": false,\r\n            \"IsExternal\": false,\r\n            \"Url\": \"https://job.jobnet.dk/CV/FindWork/Details/5376709\",\r\n            \"Region\": \"Syddanmark\",\r\n            \"Municipality\": \"Kolding\",\r\n            \"Country\": \"Danmark\",\r\n            \"PostalCode\": \"6000\",\r\n            \"PostalCodeName\": null,\r\n            \"JobAnnouncementType\": \"\",\r\n            \"EmploymentType\": \"\",\r\n            \"WorkHours\": \"Fuldtid\",\r\n            \"OccupationArea\": \"\",\r\n            \"OccupationGroup\": \"\",\r\n            \"Occupation\": \"Lager- og logistikmedarbejder\",\r\n            \"Location\": {\r\n                \"Latitude\": 55.5022,\r\n                \"Longitude\": 9.4685\r\n            },\r\n            \"JoblogWorkTime\": {\r\n                \"WorkHour\": null,\r\n                \"DailyWorkTime\": \"Dag\"\r\n            },\r\n            \"WorkplaceID\": 126565,\r\n            \"OrganisationId\": \"71174\",\r\n            \"HiringOrgCVR\": 30899695,\r\n            \"UserLoggedIn\": false,\r\n            \"AnonymousEmployer\": false,\r\n            \"ShareUrl\": \"https://job.jobnet.dk/CV/FindWork/DetailsSocialmedia/5376709\",\r\n            \"DetailsUrl\": \"https://job.jobnet.dk/CV/FindWork/DetailsWidk/5376709\",\r\n            \"JobLogUrl\": \"https://job.jobnet.dk/CV/FindWork/Details/5376709\",\r\n            \"HasLocationValues\": true,\r\n            \"ID\": \"5376709\",\r\n            \"Latitude\": 55.5022,\r\n            \"Longitude\": 9.4685\r\n        }",
                            title: "Medarbejdere til sommer vikariater på lager i Kolding/Employees for temporary summer positions in a warehouse in Kolding",
                            presentation: " \u00A0 \n  English version below the Danish  \n Har du lyst til at arbejde på lager, og kan du arbejde i perioden 12/7 til 30/9 på daghold, så har vi arbejde til dig. \n ",
                            hiringOrgName: "TeamVikaren.dk, Århus ApS, Horsens Afdeling",
                            workPlaceAddress: "",
                            workPlacePostalCode: 6000,
                            workPlaceCity: "Horsens",
                            postingCreated: new DateTime(2021, 07, 02),
                            lastDateApplication: new DateTime(2021, 08, 19),
                            url: "https://job.jobnet.dk/CV/FindWork/Details/5376709",
                            region: "Midtjylland",
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
                            jobPostingId: "5376709medarbejderetilsommervikariaterp"
                        );

                return jobPosting;

            }
            static JobPostingExtended CreateJobPage01JobPostingExtended17()
            {

                JobPostingExtended jobPostingExtended
                    = new JobPostingExtended(
                            jobPosting: CreateJobPage01JobPosting17(),
                            response: null, // Ignored
                            hiringOrgDescription: null,
                            publicationStartDate: new DateTime(2021, 07, 02),
                            publicationEndDate: new DateTime(2021, 08, 19),
                            purpose: null, // Ignored
                            numberToFill: 10,
                            contactEmail: null,
                            contactPersonName: "Majken Lorentzen",
                            employmentDate: null,
                            applicationDeadlineDate: new DateTime(2021, 08, 19),
                            bulletPoints: new HashSet<string>()
                            {
                                "Arbejde på daghold",
                                "Gode kollegaer",
                                "Grundig oplæring",
                                "Mulighed for aktivt arbejde",
                                "Du kan lide aktivt arbejde",
                                "Du kan lide at veksle mellem forskellige arbejdsopgaver",
                                "Du har en god fysik",
                                "Du kan arbejde daghold på fuldtid – deltid kan også arrangeres",
                                "Du er grundig i dit arbejde og har en positiv tilgang til dine arbejdsopgaver",
                                "Du er fleksibel i travle perioder",
                                "Work on day shifts",
                                "Good colleagues",
                                "Thorough training",
                                "Opportunity for active work",
                                "You like active work",
                                "You like to have different work tasks",
                                "You have a good physique",
                                "You can work day shifts full time - part time can also be arranged",
                                "You are thorough in your work and have a positive approach to your work tasks",
                                "You are flexible during busy periods"
                            },
                            bulletPointScenario: "generic"
                        );

                return jobPostingExtended;

            }
            static void DeserializeJobPage01JobPostingExtended17()
            {

                IFileInfoAdapter fileInfoAdapter = new FileInfoAdapter(@"C:\Dropbox\Tasks\20210502 - NW.WIDJobs\New WID\JSONs\JobPage01_JobPostingExtended17.json");
                IFileManager fileManager = new FileManager();
                string response = fileManager.ReadAllText(fileInfoAdapter);

                JobPosting jobPosting = CreateJobPage01JobPosting17();

                IJobPostingExtendedDeserializer jobPostingExtendedDeserializer = new JobPostingExtendedDeserializer();
                JobPostingExtended jobPostingExtended = jobPostingExtendedDeserializer.Do(jobPosting, response);

                string json = Serialize(jobPostingExtended);

            }

            // JobPage01JobPosting18
            static JobPosting CreateJobPage01JobPosting18()
            {

                JobPosting jobPosting
                    = new JobPosting(
                            runId: "temp",
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
                            jobPostingId: "5382809tenuretrackassistantprofessorshipsin"
                        );

                return jobPosting;

            }
            static JobPostingExtended CreateJobPage01JobPostingExtended18()
            {

                JobPostingExtended jobPostingExtended
                    = new JobPostingExtended(
                            jobPosting: CreateJobPage01JobPosting18(),
                            response: null, // Ignored
                            hiringOrgDescription: null,
                            publicationStartDate: null,
                            publicationEndDate: null,
                            purpose: null, // Ignored
                            numberToFill: null,
                            contactEmail: null,
                            contactPersonName: null,
                            employmentDate: null,
                            applicationDeadlineDate: null,
                            bulletPoints: new HashSet<string>()
                            {
                                "Teaching and examination in various study programs",
                                "Development of existing and or new study programs",
                                "Individual and group based research activities of high international standard",
                                "Promotion of CBS’s academic reputation",
                                "Communicating findings to the public in general and to CBS’s stakeholders in particular",
                                "Responsibility for publishing, scientific communication and research-based teaching",
                                "Attracting external funding opportunities",
                                "A cover letter",
                                "Proof of qualifications and a full CV",
                                "Documentation of relevant, significant, original research at an international level, including publications in the field’s internationally recognized journals and citations in the Social Science Citation Index and/or Google Scholar",
                                "Documentation of pedagogical qualifications or other material for the evaluation of his/her pedagogical level * Information indicating experience in research management, industry co-operation and international co-operation",
                                "A complete, numbered list of publications (indicating titles, co-authors, page numbers and year) with an * marking of the academic productions to be considered during the review. A maximum of 10 publications for review are allowed. Applicants are requested to prioritize their publications in relation to the field of this job advertisement.",
                                "Copies of the publications marked with an *."
                            },
                            bulletPointScenario: "generic"
                        );

                return jobPostingExtended;

            }
            static void DeserializeJobPage01JobPostingExtended18()
            {

                IFileInfoAdapter fileInfoAdapter = new FileInfoAdapter(@"C:\Dropbox\Tasks\20210502 - NW.WIDJobs\New WID\JSONs\JobPage01_JobPostingExtended18.json");
                IFileManager fileManager = new FileManager();
                string response = fileManager.ReadAllText(fileInfoAdapter);

                JobPosting jobPosting = CreateJobPage01JobPosting18();

                IJobPostingExtendedDeserializer jobPostingExtendedDeserializer = new JobPostingExtendedDeserializer();
                JobPostingExtended jobPostingExtended = jobPostingExtendedDeserializer.Do(jobPosting, response);

                string json = Serialize(jobPostingExtended);

            }

            // JobPage01JobPosting19
            static JobPosting CreateJobPage01JobPosting19()
            {

                JobPosting jobPosting
                    = new JobPosting(
                            runId: "temp",
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
                            jobPostingId: "5382781warehouseemployee"
                        );

                return jobPosting;

            }
            static JobPostingExtended CreateJobPage01JobPostingExtended19()
            {

                JobPostingExtended jobPostingExtended
                    = new JobPostingExtended(
                            jobPosting: CreateJobPage01JobPosting19(),
                            response: null, // Ignored
                            hiringOrgDescription: "Randstad er en del af den internationale Randstad Group, der er verdens andenstørste udbyder af HR-løsninger. Hver dag formidler Randstad arbejde til mere end 500.000 mennesker i hele verden. I Danmark er vi blandt de førende vikar- og rekrutteringsbureauer med fire afdelinger fordelt over hele landet. En position vi har opnået, fordi vi som eksperter på arbejdsmarkedet formår at matche kvalificerede kandidater med de rette jobmuligheder.",
                            publicationStartDate: new DateTime(2021, 07, 02),
                            publicationEndDate: new DateTime(2021, 08, 27),
                            purpose: null, // Ignored
                            numberToFill: 1,
                            contactEmail: "charlotte.meck@randstad.dk",
                            contactPersonName: "Charlotte Meck",
                            employmentDate: null,
                            applicationDeadlineDate: new DateTime(2021, 08, 27),
                            bulletPoints: new HashSet<string>()
                            {
                                "- Picking/packing tasks",
                                "- Loading/unloading tasks",
                                "- Receipt of goods",
                                "- Truck driving, most often reach truck",
                                "- Scanner operation",
                                "- Various warehouse tasks",
                                "You will of course receive a thorough training in the work tasks, so you will have the best conditions for success.",
                                "The company generally has an informal work environment with the opportunity to take responsibility for work tasks and planning.",
                                "- Are ready to take on evening work",
                                "- Have experience from working at a warehouse",
                                "- Have a truck certificate",
                                "- Are ready to taking up the challenge when it comes to new tasks and flexible working days",
                                "- Are able to perform a good job",
                                "- Can represent Randstad as an external employee in a positive way at the customer’s premises",
                                "- Danish- and English-speaking at a reasonable level",
                                "- Basic salary according to qualifications and in addition to this, cf. collective agreement, pension scheme and holiday",
                                "- A generally informal work environment with the opportunity to take responsibility for work tasks and planning",
                                "Start-up: As soon as possible, please send your CV",
                                "All inquiries are treated confidentially. Interviews will take place on an ongoing basis."
                            },
                            bulletPointScenario: "keepit.com"
                        );

                return jobPostingExtended;

            }
            static void DeserializeJobPage01JobPostingExtended19()
            {

                IFileInfoAdapter fileInfoAdapter = new FileInfoAdapter(@"C:\Dropbox\Tasks\20210502 - NW.WIDJobs\New WID\JSONs\JobPage01_JobPostingExtended19.json");
                IFileManager fileManager = new FileManager();
                string response = fileManager.ReadAllText(fileInfoAdapter);

                JobPosting jobPosting = CreateJobPage01JobPosting19();

                IJobPostingExtendedDeserializer jobPostingExtendedDeserializer = new JobPostingExtendedDeserializer();
                JobPostingExtended jobPostingExtended = jobPostingExtendedDeserializer.Do(jobPosting, response);

                string json = Serialize(jobPostingExtended);

            }

            // JobPage01JobPosting20
            static JobPosting CreateJobPage01JobPosting20()
            {

                JobPosting jobPosting
                    = new JobPosting(
                            runId: "temp",
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
                            jobPostingId: "5382486postdocondigitalplatformsand"
                        );

                return jobPosting;

            }
            static JobPostingExtended CreateJobPage01JobPostingExtended20()
            {

                JobPostingExtended jobPostingExtended
                    = new JobPostingExtended(
                            jobPosting: CreateJobPage01JobPosting20(),
                            response: null, // Ignored
                            hiringOrgDescription: null,
                            publicationStartDate: null,
                            publicationEndDate: null,
                            purpose: null, // Ignored
                            numberToFill: null,
                            contactEmail: null,
                            contactPersonName: null,
                            employmentDate: null,
                            applicationDeadlineDate: null,
                            bulletPoints: new HashSet<string>()
                            {
                                "How does digital platform design affect user behaviors and outcomes?",
                                "How do complementors compete within and across digital ecosystems?",
                                "How do ecosystems compete?",
                                "What is the role of data and algorithms in steering interactions and value in platform markets and ecosystems (exploiting or correcting consumer behavioral biases)?",
                                "Are data exclusionary or non-rivalry? How do they affect a firm’s competitive advantage in (platform) digital markets?",
                                "How does data enable value creation (for organizations and their stakeholder)?",
                                "How to organize the effective and efficient creation, sharing and usage of data in digital ecosystems?",
                                "Applicants must have completed a PhD in Management, Economics, or other related social science discipline before the beginning the fellowship. Prior work (including but not limited to dissertation) should involve working with large datasets.",
                                "Excellent academic record and work ethic required.",
                                "Excellent organizational and oral/written communication skills required.",
                                "Enthusiasm for research required. The ideal candidate will be thinking of this position as a platform to build skills towards taking on a research professorship in the future.",
                                "Willingness to move to and live in Denmark.",
                                "Cover letter.",
                                "Proof of qualifications and a full CV.",
                                "Any relevant information indicating experience in research management, industry co-operation and international cooperation.",
                                "A complete, numbered list of publications (indicating titles, co-authors, page numbers and year) with an * marking of the academic productions to be considered during the review. A maximum of 10 publications for review are allowed. Applicants are requested to prioritize their publications in relation to the field of this job advertisement.",
                                "Copies of the publications marked with an *. Only publications written in English (or another specified principal language, according to research tradition) or one of the Scandinavian languages will be taken into consideration."
                            },
                            bulletPointScenario: "generic"
                        );

                return jobPostingExtended;

            }
            static void DeserializeJobPage01JobPostingExtended20()
            {

                IFileInfoAdapter fileInfoAdapter = new FileInfoAdapter(@"C:\Dropbox\Tasks\20210502 - NW.WIDJobs\New WID\JSONs\JobPage01_JobPostingExtended20.json");
                IFileManager fileManager = new FileManager();
                string response = fileManager.ReadAllText(fileInfoAdapter);

                JobPosting jobPosting = CreateJobPage01JobPosting20();

                IJobPostingExtendedDeserializer jobPostingExtendedDeserializer = new JobPostingExtendedDeserializer();
                JobPostingExtended jobPostingExtended = jobPostingExtendedDeserializer.Do(jobPosting, response);

                string json = Serialize(jobPostingExtended);

            }

        #endregion

        // JobPage02JobPosting01
        static JobPosting CreateJobPage02JobPosting01()
        {

            JobPosting jobPosting
                = new JobPosting(
                        runId: "temp",
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
                        jobPostingId: "5382440assistantorassociateprofessorshipin"
                    );

            return jobPosting;

        }
        static JobPostingExtended CreateJobPage02JobPostingExtended01()
        {

            JobPostingExtended jobPostingExtended
                = new JobPostingExtended(
                        jobPosting: CreateJobPage02JobPosting01(),
                        response: null, // Ignored
                        hiringOrgDescription: null,
                        publicationStartDate: null,
                        publicationEndDate: null,
                        purpose: null, // Ignored
                        numberToFill: null,
                        contactEmail: null,
                        contactPersonName: null,
                        employmentDate: null,
                        applicationDeadlineDate: null,
                        bulletPoints: new HashSet<string>()
                        {
                            "Has specific research experience in the field of empirically informed teaching, learning outcome and/or student motivation",
                            "Has specific research experience connected to the role of digital technologies in shaping teaching and subject areas",
                            "Can demonstrate skills in collaborative and cross-disciplinary research",
                            "Can demonstrate skills in handling various qualitative and quantitative scientific methods.",
                            "Substantial research experience in general didactics in relation to empirical school research",
                            "An internationally oriented research profile",
                            "A relevant and internationally oriented publication profile",
                            "Experience of or interest in participation in national and international research networks",
                            "Experience of or interest in communication and knowledge exchange",
                            "Experience of or interest in interdisciplinary collaboration as well as interdisciplinary research",
                            "Experience of or the potential for obtaining external research funding",
                            "Teaching experience at university level within the field of general didactics and educational research methods",
                            "Experience of or interest in interdisciplinary teaching including innovative teaching methods",
                            "Experience of or interest in supervising student projects, and interest in researcher talent development.",
                            "Substantial research experience in the field of general didactics and empirical school research",
                            "Substantial experience of empirical research related to didactics, learning outcomes and student motivation",
                            "Skills in collaborative and cross-disciplinary school research",
                            "Skills in empirical school research and empirically informed teaching, including mixed methods",
                            "A strong, relevant international publication profile",
                            "Participation in national and international research networks",
                            "Experience of participation in collective research projects",
                            "Teaching experience at university level within the field general didactics and educational research methods, including innovative teaching methods, and mastery of academic English in the classroom",
                            "Proficiency in languages relevant to the area of research",
                            "Experience of interdisciplinary cooperation outreach activities",
                            "Experience of attracting external research funding",
                            "Experience of supervising student projects and an interest in researcher talent development.",
                            "Faculty of Arts refers to the Ministerial Order on the Appointment of Academic Staff at Danish Universities (the Appointment Order).",
                            "Appointment shall be in accordance with the collective labour agreement between the Danish Ministry of Finance and the Danish Confederation of Professional Associations.",
                            "Further information on qualification requirements and job content may be found in the Memorandum on Job Structure for Academic Staff at Danish Universities .",
                            "Further information on the application and supplementary materials may be found in Application Guidelines.",
                            "The application must outline the your motivation for applying for the position, attaching a curriculum vitae, copies of relevant degree certificates, and (if relevant for the position) a teaching portfolio. Please upload this material electronically along with your application.",
                            "If you submit your application for the assistant professorship, please upload a maximum of five samples of your scholarly output (mandatory).",
                            "If you submit your application for the associate professorship, please upload a maximum of eight samples of your scholarly output (mandatory).",
                            "Faculty of Arts refers to the Ministerial Order on the Appointment of Academic Staff at Danish Universities(the Appointment Order).",
                            "Further information on qualification requirements and job content may be found in theMemorandum on Job Structure for Academic Staff at Danish Universities."
                        },
                        bulletPointScenario: "generic"
                    );

            return jobPostingExtended;

        }
        static void DeserializeJobPage02JobPostingExtended01()
        {

            IFileInfoAdapter fileInfoAdapter = new FileInfoAdapter(@"C:\Dropbox\Tasks\20210502 - NW.WIDJobs\New WID\JSONs\JobPage02_JobPostingExtended01.json");
            IFileManager fileManager = new FileManager();
            string response = fileManager.ReadAllText(fileInfoAdapter);

            JobPosting jobPosting = CreateJobPage02JobPosting01();

            IJobPostingExtendedDeserializer jobPostingExtendedDeserializer = new JobPostingExtendedDeserializer();
            JobPostingExtended jobPostingExtended = jobPostingExtendedDeserializer.Do(jobPosting, response);

            string json = Serialize(jobPostingExtended);

        }

        // JobPage02JobPosting02
        static JobPosting CreateJobPage02JobPosting02()
        {

            JobPosting jobPosting
                = new JobPosting(
                        runId: "temp",
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
                        jobPostingId: "5316797carpenter"
                    );

            return jobPosting;

        }
        static JobPostingExtended CreateJobPage02JobPostingExtended02()
        {

            JobPostingExtended jobPostingExtended
                = new JobPostingExtended(
                        jobPosting: CreateJobPage02JobPosting02(),
                        response: null, // Ignored
                        hiringOrgDescription: null,
                        publicationStartDate: new DateTime(2021, 07, 02),
                        publicationEndDate: new DateTime(2021, 08, 27),
                        purpose: null, // Ignored
                        numberToFill: 1,
                        contactEmail: "kontakt@lokalboligservice.dk",
                        contactPersonName: "Emil Bertelsen",
                        employmentDate: null,
                        applicationDeadlineDate: new DateTime(2021, 08, 27),
                        bulletPoints: new HashSet<string>() { },
                        bulletPointScenario: "regex"
                    );

            return jobPostingExtended;

        }
        static void DeserializeJobPage02JobPostingExtended02()
        {

            IFileInfoAdapter fileInfoAdapter = new FileInfoAdapter(@"C:\Dropbox\Tasks\20210502 - NW.WIDJobs\New WID\JSONs\JobPage02_JobPostingExtended02.json");
            IFileManager fileManager = new FileManager();
            string response = fileManager.ReadAllText(fileInfoAdapter);

            JobPosting jobPosting = CreateJobPage02JobPosting02();

            IJobPostingExtendedDeserializer jobPostingExtendedDeserializer = new JobPostingExtendedDeserializer();
            JobPostingExtended jobPostingExtended = jobPostingExtendedDeserializer.Do(jobPosting, response);

            string json = Serialize(jobPostingExtended);

        }

        // JobPage02JobPosting03
        static JobPosting CreateJobPage02JobPosting03()
        {

            JobPosting jobPosting
                = new JobPosting(
                        runId: "temp",
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
                        jobPostingId: "5382367solutionarchitect"
                    );

            return jobPosting;

        }
        static JobPostingExtended CreateJobPage02JobPostingExtended03()
        {

            JobPostingExtended jobPostingExtended
                = new JobPostingExtended(
                        jobPosting: CreateJobPage02JobPosting03(),
                        response: null, // Ignored
                        hiringOrgDescription: null,
                        publicationStartDate: new DateTime(2021, 07, 02),
                        publicationEndDate: new DateTime(2021, 08, 27),
                        purpose: null, // Ignored
                        numberToFill: 1,
                        contactEmail: "justyna@plecto.com",
                        contactPersonName: "Justyna Płaczkiewicz",
                        employmentDate: null,
                        applicationDeadlineDate: new DateTime(2021, 08, 27),
                        bulletPoints: new HashSet<string>() 
                        {
                            "Join and hold meetings with prospects and customers to assist with any questions related to SQL, API or Plecto in general",
                            "Handle complex support cases and customer queries  in a timely and efficient manner",
                            "Guide customers and prospects on best practices in using Plecto",
                            "Assist customers in setting up their Plecto account",
                            "Assist in initial integration research",
                            "Reading technical API documentation - JSON, REST and OAuth",
                            "Solve customer problems under complex constraints and come up with solutions without any additional development of Plecto",
                            "Maintaining and creating internal knowledge base articles",
                            "Experience in delivering outstanding technical support",
                            "Experience in database operations including reading and writing basic to intermediate database SQL queries and troubleshooting connection issues",
                            "Experience and knowledge in API and SQL Server Databases",
                            "Interest and knowledge in other programming languages is a plus, but not a requirement",
                            "Ability to effectively communicate technical concepts to a variety of audiences with different levels of technical expertise",
                            "Multi-tasking and time-management to prioritize and switch between varied tasks",
                            "Technical writing skills to create and maintain Knowledge Base articles",
                            "Technical skills and an eye for detail used in troubleshooting and implementing fixes",
                            "You are fluent in English, both spoken and written + another additional language. Danish is a plus, but not a requirement"
                        },
                        bulletPointScenario: "generic"
                    );

            return jobPostingExtended;

        }
        static void DeserializeJobPage02JobPostingExtended03()
        {

            IFileInfoAdapter fileInfoAdapter = new FileInfoAdapter(@"C:\Dropbox\Tasks\20210502 - NW.WIDJobs\New WID\JSONs\JobPage02_JobPostingExtended03.json");
            IFileManager fileManager = new FileManager();
            string response = fileManager.ReadAllText(fileInfoAdapter);

            JobPosting jobPosting = CreateJobPage02JobPosting03();

            IJobPostingExtendedDeserializer jobPostingExtendedDeserializer = new JobPostingExtendedDeserializer();
            JobPostingExtended jobPostingExtended = jobPostingExtendedDeserializer.Do(jobPosting, response);

            string json = Serialize(jobPostingExtended);

        }

        // JobPage02JobPosting04
        static JobPosting CreateJobPage02JobPosting04()
        {

            JobPosting jobPosting
                = new JobPosting(
                        runId: "temp",
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
                        jobPostingId: "5382358projectofficerimpactassessmentand"
                    );

            return jobPosting;

        }
        static JobPostingExtended CreateJobPage02JobPostingExtended04()
        {

            JobPostingExtended jobPostingExtended
                = new JobPostingExtended(
                        jobPosting: CreateJobPage02JobPosting04(),
                        response: null, // Ignored
                        hiringOrgDescription: null,
                        publicationStartDate: new DateTime(2021, 07, 02),
                        publicationEndDate: new DateTime(2021, 07, 16),
                        purpose: null, // Ignored
                        numberToFill: 1,
                        contactEmail: null,
                        contactPersonName: "Henry Neufeldt",
                        employmentDate: null,
                        applicationDeadlineDate: new DateTime(2021, 07, 16),
                        bulletPoints: new HashSet<string>()
                        {
                            "Lead the development of tools and guidance materials within adaptation assessment, tracking and transparency.",
                            "Support the production of UNEP's Adaptation Gap Report;",
                            "Contribute to the section's work on private sector adaptation, and adaptation business models.",
                            "Contribute to the section's work on impact assessments of mitigation and adaptation actions and their contribution to sustainable development;",
                            "Contribute to the section's work on adaptation finance tracking;",
                            "Contribute to the development of scientific papers, briefs, and reports;",
                            "Other tasks as assigned by the head of section.",
                            "M.Sc. degree in environmental science, environmental engineering, sustainability studies, environmental economics, or other relevant field;",
                            "Understanding of the Paris Agreement, in particular of the Enhanced Transparency Framework;",
                            "Good knowledge of methods and approaches for adaptation assessment and tracking at aggregated levels (i.e. national and global-levels)",
                            "Good knowledge of the adaptation finance landscape, and methods and approaches for tracking adaptation finance",
                            "Good knowledge of the Sustainable Development Goal framework, including of the SDG targets and indicators, particularly in the context of impact assessment;",
                            "Good knowledge of private sector adaptation is an asset;",
                            "Strong analytical skills, an innovative mindset, and the ability to adapt to different tasks and workloads quickly and effectively;",
                            "Demonstrated excellent writing, communication, and presentation skills in English; proficiency in other languages, in particular Spanish and/or French is an asset",
                            "Ability to work effectively both individually as well as in teams, with people from different academic and cultural backgrounds;",
                            "Experience in preparing technical and/or policy-relevant reports and papers is considered a strong asset;",
                            "Experience in working with developing countries is an asset;",
                            "Application letter;",
                            "CV with full personal data and contact details;",
                            "Indication of three references; and,",
                            "A copy of your diploma(s)"
                        },
                        bulletPointScenario: "generic"
                    );

            return jobPostingExtended;

        }
        static void DeserializeJobPage02JobPostingExtended04()
        {

            IFileInfoAdapter fileInfoAdapter = new FileInfoAdapter(@"C:\Dropbox\Tasks\20210502 - NW.WIDJobs\New WID\JSONs\JobPage02_JobPostingExtended04.json");
            IFileManager fileManager = new FileManager();
            string response = fileManager.ReadAllText(fileInfoAdapter);

            JobPosting jobPosting = CreateJobPage02JobPosting04();

            IJobPostingExtendedDeserializer jobPostingExtendedDeserializer = new JobPostingExtendedDeserializer();
            JobPostingExtended jobPostingExtended = jobPostingExtendedDeserializer.Do(jobPosting, response);

            string json = Serialize(jobPostingExtended);

        }

        // JobPage02JobPosting05
        static JobPosting CreateJobPage02JobPosting05()
        {

            JobPosting jobPosting
                = new JobPosting(
                        runId: "temp",
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
                        jobPostingId: "5382226warehouseworkers"
                    );

            return jobPosting;

        }
        static JobPostingExtended CreateJobPage02JobPostingExtended05()
        {

            JobPostingExtended jobPostingExtended
                = new JobPostingExtended(
                        jobPosting: CreateJobPage02JobPosting05(),
                        response: null, // Ignored
                        hiringOrgDescription: "Randstad er en del af den internationale Randstad Group, der er verdens andenstørste udbyder af HR-løsninger. Hver dag formidler Randstad arbejde til mere end 500.000 mennesker i hele verden. I Danmark er vi blandt de førende vikar- og rekrutteringsbureauer med fire afdelinger fordelt over hele landet. En position vi har opnået, fordi vi som eksperter på arbejdsmarkedet formår at matche kvalificerede kandidater med de rette jobmuligheder.",
                        publicationStartDate: new DateTime(2021, 07, 02),
                        publicationEndDate: new DateTime(2021, 08, 27),
                        purpose: null, // Ignored
                        numberToFill: 2,
                        contactEmail: "claus.kjaerbo@randstad.dk",
                        contactPersonName: "Claus Kjærbo",
                        employmentDate: null,
                        applicationDeadlineDate: new DateTime(2021, 08, 27),
                        bulletPoints: new HashSet<string>()
                        {
                            "You speak English or Danish",
                            "You are interested in working in a warehouse",
                            "You have a pair of safety shoes"
                        },
                        bulletPointScenario: "generic"
                    );

            return jobPostingExtended;

        }
        static void DeserializeJobPage02JobPostingExtended05()
        {

            IFileInfoAdapter fileInfoAdapter = new FileInfoAdapter(@"C:\Dropbox\Tasks\20210502 - NW.WIDJobs\New WID\JSONs\JobPage02_JobPostingExtended05.json");
            IFileManager fileManager = new FileManager();
            string response = fileManager.ReadAllText(fileInfoAdapter);

            JobPosting jobPosting = CreateJobPage02JobPosting05();

            IJobPostingExtendedDeserializer jobPostingExtendedDeserializer = new JobPostingExtendedDeserializer();
            JobPostingExtended jobPostingExtended = jobPostingExtendedDeserializer.Do(jobPosting, response);

            string json = Serialize(jobPostingExtended);

        }

        // JobPage02JobPosting06
        static JobPosting CreateJobPage02JobPosting06()
        {

            JobPosting jobPosting
                = new JobPosting(
                        runId: "temp",
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
                        jobPostingId: "5339477cleaninghousekeeping"
                    );

            return jobPosting;

        }
        static JobPostingExtended CreateJobPage02JobPostingExtended06()
        {

            JobPostingExtended jobPostingExtended
                = new JobPostingExtended(
                        jobPosting: CreateJobPage02JobPosting06(),
                        response: null, // Ignored
                        hiringOrgDescription: null,
                        publicationStartDate: new DateTime(2021, 07, 02),
                        publicationEndDate: new DateTime(2021, 07, 30),
                        purpose: null, // Ignored
                        numberToFill: 20,
                        contactEmail: "anja@bh-hotelservice.dk",
                        contactPersonName: "Anja Løvhøj",
                        employmentDate: null,
                        applicationDeadlineDate: new DateTime(2021, 07, 30),
                        bulletPoints: new HashSet<string>()
                        {
                            "you get to clean the finest hotel rooms in Copenhagen",
                            "you are guaranteed a minimum of 80-130 hours per month with the possibility to work more (depending on your situation)",
                            "we offer career opportunities through promotions and/or management classes",
                            "we offer health insurance after 6 months of employment",
                            "Salary according to the collective bargaining agreement",
                            "Speaking English",
                            "Service minded",
                            "Ready to work primarily in the daytime on weekdays and/or weekends",
                            "Able to work in weekends as well",
                            "Ready to work in a fast and exiting environment",
                            "Definitely the one we are looking for!"
                        },
                        bulletPointScenario: "generic"
                    );

            return jobPostingExtended;

        }
        static void DeserializeJobPage02JobPostingExtended06()
        {

            IFileInfoAdapter fileInfoAdapter = new FileInfoAdapter(@"C:\Dropbox\Tasks\20210502 - NW.WIDJobs\New WID\JSONs\JobPage02_JobPostingExtended06.json");
            IFileManager fileManager = new FileManager();
            string response = fileManager.ReadAllText(fileInfoAdapter);

            JobPosting jobPosting = CreateJobPage02JobPosting06();

            IJobPostingExtendedDeserializer jobPostingExtendedDeserializer = new JobPostingExtendedDeserializer();
            JobPostingExtended jobPostingExtended = jobPostingExtendedDeserializer.Do(jobPosting, response);

            string json = Serialize(jobPostingExtended);

        }

        // JobPage02JobPosting07
        static JobPosting CreateJobPage02JobPosting07()
        {

            JobPosting jobPosting
                = new JobPosting(
                        runId: "temp",
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
                        workHours: "Deltid",
                        occupation: "Salgskonsulent",
                        workplaceId: 107348,
                        organisationId: 96927,
                        hiringOrgCVR: 34737460,
                        id: 5345782,
                        workPlaceCityWithoutZone: "Viby",
                        jobPostingNumber: 7,
                        jobPostingId: "5345782bbsalesspecialist"
                    );

            return jobPosting;

        }
        static JobPostingExtended CreateJobPage02JobPostingExtended07()
        {

            JobPostingExtended jobPostingExtended
                = new JobPostingExtended(
                        jobPosting: CreateJobPage02JobPosting07(),
                        response: null, // Ignored
                        hiringOrgDescription: null,
                        publicationStartDate: new DateTime(2021, 07, 02),
                        publicationEndDate: new DateTime(2021, 07, 30),
                        purpose: null, // Ignored
                        numberToFill: 1,
                        contactEmail: "justyna@plecto.com",
                        contactPersonName: "Justyna Płaczkiewicz",
                        employmentDate: null,
                        applicationDeadlineDate: new DateTime(2021, 07, 30),
                        bulletPoints: new HashSet<string>()
                        {
                            "Develop a strong base of customers",
                            "Find leads and potential customers through for example networks and social platforms",
                            "Identify areas where you can expand business with your existing customers",
                            "Negotiate contracts and close deals while clearly predicting your pipeline",
                            "You have excellent skills in both written and oral English",
                            "You have a good business understanding and a structured work approach",
                            "You are a team player with the ability to collaborate across teams",
                            "You are able to identify needs and identify where Plecto can create value for potential customers",
                            "It is an advantage if you have previous experience in the insurance-, telecommunications-, energy- or media industry",
                            "It is an advantage if you have previous experience from B2B and/or sales",
                            "You have a bubbly positive personality that we will love to get to know and work with"
                        },
                        bulletPointScenario: "generic"
                    );

            return jobPostingExtended;

        }
        static void DeserializeJobPage02JobPostingExtended07()
        {

            IFileInfoAdapter fileInfoAdapter = new FileInfoAdapter(@"C:\Dropbox\Tasks\20210502 - NW.WIDJobs\New WID\JSONs\JobPage02_JobPostingExtended07.json");
            IFileManager fileManager = new FileManager();
            string response = fileManager.ReadAllText(fileInfoAdapter);

            JobPosting jobPosting = CreateJobPage02JobPosting07();

            IJobPostingExtendedDeserializer jobPostingExtendedDeserializer = new JobPostingExtendedDeserializer();
            JobPostingExtended jobPostingExtended = jobPostingExtendedDeserializer.Do(jobPosting, response);

            string json = Serialize(jobPostingExtended);

        }

        // JobPage02JobPosting08
        static JobPosting CreateJobPage02JobPosting08()
        {

            JobPosting jobPosting
                = new JobPosting(
                        runId: "temp",
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
                        jobPostingId: "5366564warwhoseworkerwithinexperince"
                    );

            return jobPosting;

        }
        static JobPostingExtended CreateJobPage02JobPostingExtended08()
        {

            JobPostingExtended jobPostingExtended
                = new JobPostingExtended(
                        jobPosting: CreateJobPage02JobPosting08(),
                        response: null, // Ignored
                        hiringOrgDescription: null,
                        publicationStartDate: new DateTime(2021, 07, 02),
                        publicationEndDate: new DateTime(2021, 08, 05),
                        purpose: null, // Ignored
                        numberToFill: 10,
                        contactEmail: "bbo@vikardk.dk",
                        contactPersonName: "Bettina Bonde Thygesen",
                        employmentDate: null,
                        applicationDeadlineDate: new DateTime(2021, 08, 05),
                        bulletPoints: new HashSet<string>() { },
                        bulletPointScenario: "regex"
                    );

            return jobPostingExtended;

        }
        static void DeserializeJobPage02JobPostingExtended08()
        {

            IFileInfoAdapter fileInfoAdapter = new FileInfoAdapter(@"C:\Dropbox\Tasks\20210502 - NW.WIDJobs\New WID\JSONs\JobPage02_JobPostingExtended08.json");
            IFileManager fileManager = new FileManager();
            string response = fileManager.ReadAllText(fileInfoAdapter);

            JobPosting jobPosting = CreateJobPage02JobPosting08();

            IJobPostingExtendedDeserializer jobPostingExtendedDeserializer = new JobPostingExtendedDeserializer();
            JobPostingExtended jobPostingExtended = jobPostingExtendedDeserializer.Do(jobPosting, response);

            string json = Serialize(jobPostingExtended);

        }

        // JobPage02JobPosting09
        static JobPosting CreateJobPage02JobPosting09()
        {

            JobPosting jobPosting
                = new JobPosting(
                        runId: "temp",
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
                        jobPostingId: "5363343tenuretrackassistantprofessorin"
                    );

            return jobPosting;

        }
        static JobPostingExtended CreateJobPage02JobPostingExtended09()
        {

            JobPostingExtended jobPostingExtended
                = new JobPostingExtended(
                        jobPosting: CreateJobPage02JobPosting09(),
                        response: null, // Ignored
                        hiringOrgDescription: null,
                        publicationStartDate: null,
                        publicationEndDate: null,
                        purpose: null, // Ignored
                        numberToFill: null,
                        contactEmail: null,
                        contactPersonName: null,
                        employmentDate: null,
                        applicationDeadlineDate: null,
                        bulletPoints: new HashSet<string>() 
                        {
                            "research, including publication/academic dissemination",
                            "research-based teaching",
                            "sharing knowledge with society",
                            "participation in formal pedagogical training programme for assistant professors",
                            "a PhD degree or similar qualifications within the subject area",
                            "research experience within the field of the position",
                            "Application, including motivation for applying for this position (Maximum 2 pages)",
                            "Curriculum vitae, including information about funding",
                            "Diplomas (Master’s, PhD and other relevant diplomas)",
                            "A complete list of publications",
                            "Research plan (2-4 pages)",
                            "Teaching plan",
                            "Uploads of maximum 5 publications to be considered in the assessment",
                            "Teaching portfolio, if applicable (Guidelines: https://employment.ku.dk/faculty/recruitment-process/job-application-portfolio)"
                        },
                        bulletPointScenario: "generic"
                    );

            return jobPostingExtended;

        }
        static void DeserializeJobPage02JobPostingExtended09()
        {

            IFileInfoAdapter fileInfoAdapter = new FileInfoAdapter(@"C:\Dropbox\Tasks\20210502 - NW.WIDJobs\New WID\JSONs\JobPage02_JobPostingExtended09.json");
            IFileManager fileManager = new FileManager();
            string response = fileManager.ReadAllText(fileInfoAdapter);

            JobPosting jobPosting = CreateJobPage02JobPosting09();

            IJobPostingExtendedDeserializer jobPostingExtendedDeserializer = new JobPostingExtendedDeserializer();
            JobPostingExtended jobPostingExtended = jobPostingExtendedDeserializer.Do(jobPosting, response);

            string json = Serialize(jobPostingExtended);

        }

        // JobPage02JobPosting10
        static JobPosting CreateJobPage02JobPosting10()
        {

            JobPosting jobPosting
                = new JobPosting(
                        runId: "temp",
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
                        country: "Danmark",
                        employmentType: "Tidsbegrænset ansættelse",
                        workHours: "Fuldtid",
                        occupation: "",
                        workplaceId: 0,
                        organisationId: null,
                        hiringOrgCVR: 0,
                        id: 8251052,
                        workPlaceCityWithoutZone: "Bagsværd",
                        jobPostingNumber: 10,
                        jobPostingId: "8251052receptionist"
                    );

            return jobPosting;

        }
        static JobPostingExtended CreateJobPage02JobPostingExtended10()
        {

            JobPostingExtended jobPostingExtended
                = new JobPostingExtended(
                        jobPosting: CreateJobPage02JobPosting10(),
                        response: null, // Ignored
                        hiringOrgDescription: null,
                        publicationStartDate: null,
                        publicationEndDate: null,
                        purpose: null, // Ignored
                        numberToFill: null,
                        contactEmail: null,
                        contactPersonName: null,
                        employmentDate: null,
                        applicationDeadlineDate: null,
                        bulletPoints: new HashSet<string>()
                        {
                            "The most important in this job is your personality. We\\n weigh discretion highly and the importance of our customers\\n getting a professional service when they are welcomed by you\\n at our receptions.",
                            "We are an active part of the security setup and it will\\n be an advantage if you have worked as an Security\\n Receptionist before.",
                            "As you will have colleagues from very different\\n backgrounds, it will require tolerance and understanding to\\n positively gain from the differences.",
                            "You will need a good deal of curiosity and have the\\n ability to work very thorough with your tasks.",
                            "You have a solid language background, speak and write\\n Danish and English at a high level. It will be an advantage\\n if you master another foreign language. You have the ability\\n to absorb and handle large amounts of information and in\\n depth organisational knowledge.",
                            "You are used to working in a large company and handling\\n many different stakeholders. You are a super user in regards\\n to the Office-package, are used to working with data and Key\\n Performance Indicators (KPIs) and you have technical insight\\n into SAP and IT systems including maintenance hereof."
                        },
                        bulletPointScenario: "novonordisk.dk"
                    );

            return jobPostingExtended;

        }
        static void DeserializeJobPage02JobPostingExtended10()
        {

            IFileInfoAdapter fileInfoAdapter = new FileInfoAdapter(@"C:\Dropbox\Tasks\20210502 - NW.WIDJobs\New WID\JSONs\JobPage02_JobPostingExtended10.html");
            IFileManager fileManager = new FileManager();
            string response = fileManager.ReadAllText(fileInfoAdapter);

            JobPosting jobPosting = CreateJobPage02JobPosting10();

            IJobPostingExtendedDeserializer jobPostingExtendedDeserializer = new JobPostingExtendedDeserializer();
            JobPostingExtended jobPostingExtended = jobPostingExtendedDeserializer.Do(jobPosting, response);

            string json = Serialize(jobPostingExtended);

        }

        // JobPage02JobPosting11
        static JobPosting CreateJobPage02JobPosting11()
        {

            JobPosting jobPosting
                = new JobPosting(
                        runId: "temp",
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
                        country: "Danmark",
                        employmentType: "Fastansættelse",
                        workHours: "Fuldtid",
                        occupation: "",
                        workplaceId: 0,
                        organisationId: null,
                        hiringOrgCVR: 0,
                        id: 8251051,
                        workPlaceCityWithoutZone: "Bagsværd",
                        jobPostingNumber: 11,
                        jobPostingId: "8251051securityofficer"
                    );

            return jobPosting;

        }
        static JobPostingExtended CreateJobPage02JobPostingExtended11()
        {

            JobPostingExtended jobPostingExtended
                = new JobPostingExtended(
                        jobPosting: CreateJobPage02JobPosting11(),
                        response: null, // Ignored
                        hiringOrgDescription: null,
                        publicationStartDate: null,
                        publicationEndDate: null,
                        purpose: null, // Ignored
                        numberToFill: null,
                        contactEmail: null,
                        contactPersonName: null,
                        employmentDate: null,
                        applicationDeadlineDate: null,
                        bulletPoints: new HashSet<string>()
                        {
                            "Behandlings-områder",
                            "Sundheds-personale",
                            "Videnskab &amp; teknologi",
                            "Bæredygtig forretning",
                            "Karriere",
                            "Om Novo Nordisk",
                            "",
                            "Få mere viden",
                            "Nyheder og presse",
                            "Kontakt os"
                        },
                        bulletPointScenario: "novonordisk.dk"
                    );

            return jobPostingExtended;

        }
        static void DeserializeJobPage02JobPostingExtended11()
        {

            IFileInfoAdapter fileInfoAdapter = new FileInfoAdapter(@"C:\Dropbox\Tasks\20210502 - NW.WIDJobs\New WID\JSONs\JobPage02_JobPostingExtended11.html");
            IFileManager fileManager = new FileManager();
            string response = fileManager.ReadAllText(fileInfoAdapter);

            JobPosting jobPosting = CreateJobPage02JobPosting11();

            IJobPostingExtendedDeserializer jobPostingExtendedDeserializer = new JobPostingExtendedDeserializer();
            JobPostingExtended jobPostingExtended = jobPostingExtendedDeserializer.Do(jobPosting, response);

            string json = Serialize(jobPostingExtended);

        }

        // JobPage02JobPosting12
        static JobPosting CreateJobPage02JobPosting12()
        {

            JobPosting jobPosting
                = new JobPosting(
                        runId: "temp",
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
                        jobPostingId: "8251042phd"
                    );

            return jobPosting;

        }
        static JobPostingExtended CreateJobPage02JobPostingExtended12()
        {

            JobPostingExtended jobPostingExtended
                = new JobPostingExtended(
                        jobPosting: CreateJobPage02JobPosting12(),
                        response: null, // Ignored
                        hiringOrgDescription: null,
                        publicationStartDate: null,
                        publicationEndDate: null,
                        purpose: null, // Ignored
                        numberToFill: null,
                        contactEmail: null,
                        contactPersonName: null,
                        employmentDate: null,
                        applicationDeadlineDate: null,
                        bulletPoints: new HashSet<string>()
                        {
                            "Field-based ecosystem manipulations experiments and monitoring of greenhouse gas production",
                            "Measurements of subsurface and snow gas concentrations, diffusion and greenhouse gas fluxes",
                            "Process-based models to simulate changes in climate-soil-plant-microbial characteristics",
                            "Structural equation modelling",
                            "Letter of application",
                            "Curriculum vita, incl. education, experience, previous employments, language skills and other relevant skills (max 5 pages).",
                            "Detailed outline of proposed research, including research questions and methods (max 5 pages)",
                            "Diplomas (Master and PhD degree or equivalent)",
                            "Complete publication list, highlighting the 3 most important ones",
                            "Separate reprints of 3 particularly relevant papers",
                            "Two letters of recommendation."
                        },
                        bulletPointScenario: "jobportal.ku.dk"
                    );

            return jobPostingExtended;

        }
        static void DeserializeJobPage02JobPostingExtended12()
        {

            IFileInfoAdapter fileInfoAdapter = new FileInfoAdapter(@"C:\Dropbox\Tasks\20210502 - NW.WIDJobs\New WID\JSONs\JobPage02_JobPostingExtended12.html");
            IFileManager fileManager = new FileManager();
            string response = fileManager.ReadAllText(fileInfoAdapter);

            JobPosting jobPosting = CreateJobPage02JobPosting12();

            IJobPostingExtendedDeserializer jobPostingExtendedDeserializer = new JobPostingExtendedDeserializer();
            JobPostingExtended jobPostingExtended = jobPostingExtendedDeserializer.Do(jobPosting, response);

            string json = Serialize(jobPostingExtended);

        }

        // JobPage02JobPosting13
        static JobPosting CreateJobPage02JobPosting13()
        {

            JobPosting jobPosting
                = new JobPosting(
                        runId: "temp",
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
                        jobPostingId: "8251041specialist"
                    );

            return jobPosting;

        }
        static JobPostingExtended CreateJobPage02JobPostingExtended13()
        {

            JobPostingExtended jobPostingExtended
                = new JobPostingExtended(
                        jobPosting: CreateJobPage02JobPosting13(),
                        response: null, // Ignored
                        hiringOrgDescription: null,
                        publicationStartDate: null,
                        publicationEndDate: null,
                        purpose: null, // Ignored
                        numberToFill: null,
                        contactEmail: null,
                        contactPersonName: null,
                        employmentDate: null,
                        applicationDeadlineDate: null,
                        bulletPoints: new HashSet<string>()
                        {
                            "Subject matter expert with responsibility for planning, advising on, coordinating, and handling public disclosure of clinical trial information.",
                            "Monitor and evaluate the clinical trial disclosure landscape, including regulatory requirements and industry trends.",
                            "Develop, pilot, implement, update, and maintain procedures to ensure compliance with regulations and other commitments for clinical data transparency.",
                            "University degree in health or biological science (MD, MSc, MSc Pharm or equivalent).",
                            "Thorough knowledge of clinical development, GCP, scientific research methods, and applicable regulatory guidelines. Understanding of clinical statistics.",
                            "Strong IT flair – documented through previous experience, either professional or private.",
                            "Prior experience with clinical disclosure will be an advantage."
                        },
                        bulletPointScenario: "easycruit.com"
                    );

            return jobPostingExtended;

        }
        static void DeserializeJobPage02JobPostingExtended13()
        {

            IFileInfoAdapter fileInfoAdapter = new FileInfoAdapter(@"C:\Dropbox\Tasks\20210502 - NW.WIDJobs\New WID\JSONs\JobPage02_JobPostingExtended13.html");
            IFileManager fileManager = new FileManager();
            string response = fileManager.ReadAllText(fileInfoAdapter);

            JobPosting jobPosting = CreateJobPage02JobPosting13();

            IJobPostingExtendedDeserializer jobPostingExtendedDeserializer = new JobPostingExtendedDeserializer();
            JobPostingExtended jobPostingExtended = jobPostingExtendedDeserializer.Do(jobPosting, response);

            string json = Serialize(jobPostingExtended);

        }

        // JobPage02JobPosting14
        static JobPosting CreateJobPage02JobPosting14()
        {

            JobPosting jobPosting
                = new JobPosting(
                        runId: "temp",
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
                        jobPostingId: "8251039supportengineer"
                    );

            return jobPosting;

        }
        static JobPostingExtended CreateJobPage02JobPostingExtended14()
        {

            JobPostingExtended jobPostingExtended
                = new JobPostingExtended(
                        jobPosting: CreateJobPage02JobPosting14(),
                        response: null, // Ignored
                        hiringOrgDescription: null,
                        publicationStartDate: null,
                        publicationEndDate: null,
                        purpose: null, // Ignored
                        numberToFill: null,
                        contactEmail: null,
                        contactPersonName: null,
                        employmentDate: null,
                        applicationDeadlineDate: null,
                        bulletPoints: new HashSet<string>() { },
                        bulletPointScenario: "regex"
                    );

            return jobPostingExtended;

        }
        static void DeserializeJobPage02JobPostingExtended14()
        {

            IFileInfoAdapter fileInfoAdapter = new FileInfoAdapter(@"C:\Dropbox\Tasks\20210502 - NW.WIDJobs\New WID\JSONs\JobPage02_JobPostingExtended14.html");
            IFileManager fileManager = new FileManager();
            string response = fileManager.ReadAllText(fileInfoAdapter);

            JobPosting jobPosting = CreateJobPage02JobPosting14();

            IJobPostingExtendedDeserializer jobPostingExtendedDeserializer = new JobPostingExtendedDeserializer();
            JobPostingExtended jobPostingExtended = jobPostingExtendedDeserializer.Do(jobPosting, response);

            string json = Serialize(jobPostingExtended);

        }

        // JobPage02JobPosting15
        static JobPosting CreateJobPage02JobPosting15()
        {

            JobPosting jobPosting
                = new JobPosting(
                        runId: "temp",
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
                        jobPostingId: "8251038softwaredeveloper"
                    );

            return jobPosting;

        }
        static JobPostingExtended CreateJobPage02JobPostingExtended15()
        {

            JobPostingExtended jobPostingExtended
                = new JobPostingExtended(
                        jobPosting: CreateJobPage02JobPosting15(),
                        response: null, // Ignored
                        hiringOrgDescription: null,
                        publicationStartDate: null,
                        publicationEndDate: null,
                        purpose: null, // Ignored
                        numberToFill: null,
                        contactEmail: null,
                        contactPersonName: null,
                        employmentDate: null,
                        applicationDeadlineDate: null,
                        bulletPoints: new HashSet<string>() 
                        {
                            "",
                            "Facebook",
                            "Linkedin",
                            "Google+",
                            "Twitter",
                            "Email",
                            "Print"
                        },
                        bulletPointScenario: "generic"
                    );

            return jobPostingExtended;

        }
        static void DeserializeJobPage02JobPostingExtended15()
        {

            IFileInfoAdapter fileInfoAdapter = new FileInfoAdapter(@"C:\Dropbox\Tasks\20210502 - NW.WIDJobs\New WID\JSONs\JobPage02_JobPostingExtended15.html");
            IFileManager fileManager = new FileManager();
            string response = fileManager.ReadAllText(fileInfoAdapter);

            JobPosting jobPosting = CreateJobPage02JobPosting15();

            IJobPostingExtendedDeserializer jobPostingExtendedDeserializer = new JobPostingExtendedDeserializer();
            JobPostingExtended jobPostingExtended = jobPostingExtendedDeserializer.Do(jobPosting, response);

            string json = Serialize(jobPostingExtended);

        }

        // JobPage02JobPosting16
        // JobPage02JobPosting17
        // JobPage02JobPosting18
        // JobPage02JobPosting19
        // JobPage02JobPosting20

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