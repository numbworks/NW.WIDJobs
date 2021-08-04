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

            DeserializeJobPage02JobPostingExtended20();

            WIDExplorerComponents.DefaultLoggingAction.Invoke("Press a button to close the window.");
            Console.ReadLine();

        }

        #region Shared_JobPage02

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
        static JobPosting CreateJobPage02JobPosting16()
        {

            JobPosting jobPosting
                = new JobPosting(
                        runId: "temp",
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
                        jobPostingId: "8251036phd"
                    );

            return jobPosting;

        }
        static JobPostingExtended CreateJobPage02JobPostingExtended16()
        {

            JobPostingExtended jobPostingExtended
                = new JobPostingExtended(
                        jobPosting: CreateJobPage02JobPosting16(),
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
                            "Nyheder",
                            "Arrangementer",
                            "Kontakt og find rundt",
                            "Campusområder",
                            "For Pressen",
                            "For alumni",
                            "Genveje \\n \\n Nyheder \\n Arrangementer \\n Kontakt og find rundt \\n Campusområder \\n For Pressen \\n For alumni",
                            "aau uddannelse",
                            "aau forskning",
                            "aau samarbejde",
                            "Om AAU",
                            "Ledige stillinger",
                            "Ansatte og studerende",
                            "",
                            "Ledige stillinger på AAU",
                            "/",
                            "Vis stilling",
                            "Alle videnskabelige stillinger",
                            "Alle teknisk-administrative stillinger",
                            "Alle Phd stillinger",
                            "Alle ledige stillinger",
                            "AAU som arbejdsplads",
                            "AAU&#039;s personalepolitik",
                            "Organisation",
                            "Problembaseret læring",
                            "Strategi og udvikling",
                            "Internationalt samarbejde",
                            "Historie, priser og hæder",
                            "Uddannelseskvalitet",
                            "AAU i tal",
                            "Facebook",
                            "LinkedIn",
                            "Instagram",
                            "Snapchat",
                            "YouTube"
                        },
                        bulletPointScenario: "generic"
                    );

            return jobPostingExtended;

        }
        static void DeserializeJobPage02JobPostingExtended16()
        {

            IFileInfoAdapter fileInfoAdapter = new FileInfoAdapter(@"C:\Dropbox\Tasks\20210502 - NW.WIDJobs\New WID\JSONs\JobPage02_JobPostingExtended16.html");
            IFileManager fileManager = new FileManager();
            string response = fileManager.ReadAllText(fileInfoAdapter);

            JobPosting jobPosting = CreateJobPage02JobPosting16();

            IJobPostingExtendedDeserializer jobPostingExtendedDeserializer = new JobPostingExtendedDeserializer();
            JobPostingExtended jobPostingExtended = jobPostingExtendedDeserializer.Do(jobPosting, response);

            string json = Serialize(jobPostingExtended);

        }

        // JobPage02JobPosting17
        static JobPosting CreateJobPage02JobPosting17()
        {

            JobPosting jobPosting
                = new JobPosting(
                        runId: "temp",
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
                        jobPostingId: "8251035leader"
                    );

            return jobPosting;

        }
        static JobPostingExtended CreateJobPage02JobPostingExtended17()
        {

            JobPostingExtended jobPostingExtended
                = new JobPostingExtended(
                        jobPosting: CreateJobPage02JobPosting17(),
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
        static void DeserializeJobPage02JobPostingExtended17()
        {

            IFileInfoAdapter fileInfoAdapter = new FileInfoAdapter(@"C:\Dropbox\Tasks\20210502 - NW.WIDJobs\New WID\JSONs\JobPage02_JobPostingExtended17.html");
            IFileManager fileManager = new FileManager();
            string response = fileManager.ReadAllText(fileInfoAdapter);

            JobPosting jobPosting = CreateJobPage02JobPosting17();

            IJobPostingExtendedDeserializer jobPostingExtendedDeserializer = new JobPostingExtendedDeserializer();
            JobPostingExtended jobPostingExtended = jobPostingExtendedDeserializer.Do(jobPosting, response);

            string json = Serialize(jobPostingExtended);

        }

        // JobPage02JobPosting18
        static JobPosting CreateJobPage02JobPosting18()
        {

            JobPosting jobPosting
                = new JobPosting(
                        runId: "temp",
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
                        jobPostingId: "8251034productowner"
                    );

            return jobPosting;

        }
        static JobPostingExtended CreateJobPage02JobPostingExtended18()
        {

            JobPostingExtended jobPostingExtended
                = new JobPostingExtended(
                        jobPosting: CreateJobPage02JobPosting18(),
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
        static void DeserializeJobPage02JobPostingExtended18()
        {

            IFileInfoAdapter fileInfoAdapter = new FileInfoAdapter(@"C:\Dropbox\Tasks\20210502 - NW.WIDJobs\New WID\JSONs\JobPage02_JobPostingExtended18.html");
            IFileManager fileManager = new FileManager();
            string response = fileManager.ReadAllText(fileInfoAdapter);

            JobPosting jobPosting = CreateJobPage02JobPosting18();

            IJobPostingExtendedDeserializer jobPostingExtendedDeserializer = new JobPostingExtendedDeserializer();
            JobPostingExtended jobPostingExtended = jobPostingExtendedDeserializer.Do(jobPosting, response);

            string json = Serialize(jobPostingExtended);

        }

        // JobPage02JobPosting19
        static JobPosting CreateJobPage02JobPosting19()
        {

            JobPosting jobPosting
                = new JobPosting(
                        runId: "temp",
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
                        jobPostingId: "8251030seniormanager"
                    );

            return jobPosting;

        }
        static JobPostingExtended CreateJobPage02JobPostingExtended19()
        {

            JobPostingExtended jobPostingExtended
                = new JobPostingExtended(
                        jobPosting: CreateJobPage02JobPosting19(),
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
                            "Set a clear direction for sales capabilities within the Consumer channel, ensure that we have the right toolbox in place for in- and outbound calls and that these align with HQ requirements",
                            "Ensure that we locally have the tools necessary to give our customers get the highest level of quality in terms of service and sales",
                            "Work with stakeholders to identify training needs and opportunities and determine what areas should be included in training modules",
                            "Motivate and develop consumer care managers",
                            "Have a couple of years of experience in a commercial role",
                            "Know your way around change management",
                            "Probably have training experience preferably from a sales or service organisation",
                            "Have impactful PowerPoint presentation skills and the ability to conduct meetings and workshops",
                            "Are fluent in English – any other languages are a plus"
                        },
                        bulletPointScenario: "coloplast.com"
                    );

            return jobPostingExtended;

        }
        static void DeserializeJobPage02JobPostingExtended19()
        {

            IFileInfoAdapter fileInfoAdapter = new FileInfoAdapter(@"C:\Dropbox\Tasks\20210502 - NW.WIDJobs\New WID\JSONs\JobPage02_JobPostingExtended19.html");
            IFileManager fileManager = new FileManager();
            string response = fileManager.ReadAllText(fileInfoAdapter);

            JobPosting jobPosting = CreateJobPage02JobPosting19();

            IJobPostingExtendedDeserializer jobPostingExtendedDeserializer = new JobPostingExtendedDeserializer();
            JobPostingExtended jobPostingExtended = jobPostingExtendedDeserializer.Do(jobPosting, response);

            string json = Serialize(jobPostingExtended);

        }

        // JobPage02JobPosting20
        static JobPosting CreateJobPage02JobPosting20()
        {

            JobPosting jobPosting
                = new JobPosting(
                        runId: "temp",
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
                        jobPostingId: "8251029businessintelligenceanalyst"
                    );

            return jobPosting;

        }
        static JobPostingExtended CreateJobPage02JobPostingExtended20()
        {

            JobPostingExtended jobPostingExtended
                = new JobPostingExtended(
                        jobPosting: CreateJobPage02JobPosting20(),
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
        static void DeserializeJobPage02JobPostingExtended20()
        {

            IFileInfoAdapter fileInfoAdapter = new FileInfoAdapter(@"C:\Dropbox\Tasks\20210502 - NW.WIDJobs\New WID\JSONs\JobPage02_JobPostingExtended20.html");
            IFileManager fileManager = new FileManager();
            string response = fileManager.ReadAllText(fileInfoAdapter);

            JobPosting jobPosting = CreateJobPage02JobPosting20();

            IJobPostingExtendedDeserializer jobPostingExtendedDeserializer = new JobPostingExtendedDeserializer();
            JobPostingExtended jobPostingExtended = jobPostingExtendedDeserializer.Do(jobPosting, response);

            string json = Serialize(jobPostingExtended);

        }

        #endregion

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