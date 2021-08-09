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

            WIDExplorerComponents.DefaultLoggingAction.Invoke("Press a button to close the window.");
            Console.ReadLine();

        }

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
                = explorer.Explore(1, WIDCategories.AllCategories, WIDStages.Stage3_UpToAllJobPostingsExtended);
            WIDMetrics metrics = explorer.ConvertToMetrics(exploration);

            explorer.SaveAsJson(exploration);
            explorer.SaveAsSQLite(exploration.JobPostingsExtended);
            explorer.SaveAsJson(metrics, false);
            explorer.SaveAsJson(metrics, true);

        }
        static void ExploreAllITTech()
        {

            WIDExplorer explorer = CreateExplorer();
            explorer.LogAsciiBanner();

            WIDExploration exploration
                = explorer.ExploreAll(WIDCategories.ItTech, WIDStages.Stage3_UpToAllJobPostingsExtended);
            WIDMetrics metrics = explorer.ConvertToMetrics(exploration);

            explorer.SaveAsJson(exploration);
            explorer.SaveAsSQLite(exploration.JobPostingsExtended);
            explorer.SaveAsJson(metrics, false);
            explorer.SaveAsJson(metrics, true);

        }

    }

}

/*
    Author: numbworks@gmail.com
    Last Update: 12.06.2021
*/