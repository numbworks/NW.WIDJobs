using System;
using System.Collections.Generic;
using System.IO;
using NW.WIDJobs;
using NW.WIDJobs.UnitTests;
using System.Text.Json;
using System.Text.Encodings.Web;

namespace NW.WIDJobsClient
{
    class Program
    {
        static void Main(string[] args)
        {

            DeserializeJobPage01JobPostingExtended01();

            WIDExplorerComponents.DefaultLoggingAction.Invoke("Press a button to close the window.");
            Console.ReadLine();

        }
        static void DeserializeJobPage01()
        {

            IFileInfoAdapter fileInfoAdapter = new FileInfoAdapter(@"C:\Users\Rubèn\Desktop\New WID\JSONs\JobPage01.json");
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
        static void DeserializeJobPage01JobPostingExtended01()
        {

            IFileInfoAdapter fileInfoAdapter = new FileInfoAdapter(@"C:\Users\Rubèn\Desktop\New WID\JSONs\JobPage01_JobPostingExtended01.json");
            IFileManager fileManager = new FileManager();
            string response = fileManager.ReadAllText(fileInfoAdapter);

            JobPosting jobPosting = CreateJobPage01JobPosting01();

            IJobPostingExtendedDeserializer jobPostingExtendedDeserializer = new JobPostingExtendedDeserializer();
            JobPostingExtended jobPostingExtended = jobPostingExtendedDeserializer.Do(jobPosting, response);

        }
        static void DeserializeJobPage02JobPostingExtended10()
        {

            IFileInfoAdapter fileInfoAdapter = new FileInfoAdapter(@"C:\Users\Rubèn\Desktop\New WID\JSONs\JobPage02_JobPostingExtended10.html");
            IFileManager fileManager = new FileManager();
            string response = fileManager.ReadAllText(fileInfoAdapter);

            JobPosting jobPosting = CreateJobPage01JobPosting01();

            IJobPostingExtendedDeserializer jobPostingExtendedDeserializer = new JobPostingExtendedDeserializer();
            JobPostingExtended jobPostingExtended = jobPostingExtendedDeserializer.Do(jobPosting, response);

        }
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