using System;
using System.IO;
using NW.WIDJobs;

namespace NW.WIDJobsClient
{
    class Program
    {
        static void Main(string[] args)
        {

            Do();

            WIDExplorerComponents.DefaultLoggingAction.Invoke("Press a button to close the window.");
            Console.ReadLine();

        }
        static void Do()
        {

            WIDExplorer explorer = new WIDExplorer();
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

            WIDExplorerComponents.DefaultLoggingAction.Invoke(metrics.ToString());

        }

    }

}
