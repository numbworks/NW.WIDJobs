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

            Do2();

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
                        WIDExplorerSettings.DefaultDatabaseName
                        );

            WIDExplorer explorer = new WIDExplorer(new WIDExplorerComponents(), settings, DateTime.Now);
            WIDExploration exploration
                = explorer.Explore(1, WIDCategories.AllCategories, WIDStages.Stage3_UpToAllPageItemsExtended);

            WIDExplorerComponents.DefaultLoggingAction.Invoke(exploration.ToString());

            string dateToken = DateTime.Now.ToString(RunIdManager.FormatDateTime);

            string json = explorer.ToJson(exploration);
            string filename = string.Concat(@"C:\Users\Rubèn\Desktop\Exploration", dateToken, ".json");
            File.WriteAllText(filename, json);

            WIDMetrics metrics = new WIDMetricsManager().Calculate(exploration);
            json = explorer.ToJson(metrics);
            filename = string.Concat(@"C:\Users\Rubèn\Desktop\Metrics", dateToken, ".json");
            File.WriteAllText(filename, json);

            explorer.ToSQLite(exploration.PageItemsExtended);

            WIDExplorerComponents.DefaultLoggingAction.Invoke(metrics.ToString());

        }
        static void Do2()
        {

            WIDExplorerSettings settings
                = new WIDExplorerSettings(
                        WIDExplorerSettings.DefaultParallelRequests,
                        WIDExplorerSettings.DefaultPauseBetweenRequestsMs,
                        @"C:\Users\Rubèn\Desktop\",
                        WIDExplorerSettings.DefaultDatabaseName
                        );

            WIDExplorer explorer = new WIDExplorer(new WIDExplorerComponents(), settings, DateTime.Now);
        
            explorer.ToSQLite(ObjectMother.Shared_Page03_PageItemsExtended);

        }

    }

}
