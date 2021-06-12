using System;
using System.IO;
using NW.WIDJobs;
using NW.WIDJobs.UnitTests;

namespace NW.WIDJobsClient
{
    class Program
    {
        static void Main(string[] args)
        {

            DoForAll();

            WIDExplorerComponents.DefaultLoggingAction.Invoke("Press a button to close the window.");
            Console.ReadLine();

        }
        static void Do()
        {

            WIDExplorerSettings settings
                = new WIDExplorerSettings(
                        WIDExplorerSettings.DefaultParallelRequests,
                        WIDExplorerSettings.DefaultPauseBetweenRequestsMs,
                        @"C:\Users\Rubèn\Desktop\",
                        WIDExplorerSettings.DefaultDatabaseName,
                        WIDExplorerSettings.DefaultDeleteAndRecreateDatabase
                        );

            WIDExplorer explorer = new WIDExplorer(new WIDExplorerComponents(), settings, DateTime.Now);
            WIDExploration exploration
                = explorer.Explore(1, WIDCategories.AllCategories, WIDStages.Stage3_UpToAllPageItemsExtended);

            WIDExplorerComponents.DefaultLoggingAction.Invoke(exploration.ToString());

            string dateToken = DateTime.Now.ToString(RunIdManager.DefaultFormatDateTime);

            string json = explorer.ConvertToJson(exploration);
            string filename = string.Concat(@"C:\Users\Rubèn\Desktop\Exploration", dateToken, ".json");
            File.WriteAllText(filename, json);

            WIDMetrics metrics = new WIDMetricsManager().Calculate(exploration);
            json = explorer.ConvertToJson(metrics);
            filename = string.Concat(@"C:\Users\Rubèn\Desktop\Metrics", dateToken, ".json");
            File.WriteAllText(filename, json);

            explorer.SaveAsSQLite(exploration.PageItemsExtended);

            WIDExplorerComponents.DefaultLoggingAction.Invoke(metrics.ToString());

        }
        static void Do2()
        {

            WIDExplorerSettings settings
                = new WIDExplorerSettings(
                        WIDExplorerSettings.DefaultParallelRequests,
                        WIDExplorerSettings.DefaultPauseBetweenRequestsMs,
                        @"C:\Users\Rubèn\Desktop\",
                        WIDExplorerSettings.DefaultDatabaseName,
                        WIDExplorerSettings.DefaultDeleteAndRecreateDatabase
                        );

            WIDExplorer explorer = new WIDExplorer(new WIDExplorerComponents(), settings, DateTime.Now);
        
            explorer.SaveAsSQLite(ObjectMother.Shared_Page03_PageItemsExtended);

        }
        static void DoForAll()
        {

            string dateToken = DateTime.Now.ToString(RunIdManager.DefaultFormatDateTime);

            WIDExplorerSettings settings
                = new WIDExplorerSettings(
                        WIDExplorerSettings.DefaultParallelRequests,
                        WIDExplorerSettings.DefaultPauseBetweenRequestsMs,
                        @"C:\Users\Rubèn\Desktop\",
                        string.Concat(WIDExplorerSettings.DefaultDatabaseName, "_", dateToken, ".db"),
                        WIDExplorerSettings.DefaultDeleteAndRecreateDatabase
                        );

            WIDExplorer explorer = new WIDExplorer(new WIDExplorerComponents(), settings, DateTime.Now);
            WIDExploration exploration
                = explorer.ExploreAll(WIDCategories.AllCategories, WIDStages.Stage3_UpToAllPageItemsExtended);

            explorer.SaveAsSQLite(exploration.PageItemsExtended);

            string json = explorer.ConvertToJson(exploration);
            string filename = string.Concat(@"C:\Users\Rubèn\Desktop\Exploration", "_", dateToken, ".json");
            File.WriteAllText(filename, json);

            WIDMetrics metrics = explorer.ConvertToMetrics(exploration);
            json = explorer.ConvertToJson(metrics);
            filename = string.Concat(@"C:\Users\Rubèn\Desktop\Metrics", "_", dateToken, ".json");
            File.WriteAllText(filename, json);

        }

    }

}
