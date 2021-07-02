using System;
using System.Collections.Generic;
using System.IO;
using NW.WIDJobs;
using NW.WIDJobs.UnitTests;

namespace NW.WIDJobsClient
{
    class Program
    {
        static void Main(string[] args)
        {


            IFileInfoAdapter fileInfoAdapter = new FileInfoAdapter(@"C:\Users\Rubèn\Desktop\New WID\JSONs\JobPage01.json");
            IFileManager fileManager = new FileManager();
            string response = fileManager.ReadAllText(fileInfoAdapter);

            JobPage jobPage = new JobPage("temp", 1, response);

            IJobPostingDeserializer jobPostingDeserializer = new JobPostingDeserializer();
            List<JobPosting> jobPostings = jobPostingDeserializer.Do(jobPage);


            WIDExplorerComponents.DefaultLoggingAction.Invoke("Press a button to close the window.");
            Console.ReadLine();

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