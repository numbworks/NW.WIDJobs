using System;
using System.IO;
using System.Collections.Generic;
using NW.WIDJobs;
using System.Text.RegularExpressions;
using System.Linq;
using System.Text.Json;
using System.Text.Encodings.Web;

namespace NW.WIDJobsClient
{
    class Program
    {
        static void Main(string[] args)
        {


            WIDExplorer explorer = new WIDExplorer();
            WIDExploration exploration 
                = explorer.Explore(2, WIDCategories.ItTech, WIDStages.Stage3_UpToAllPageItemsExtended);

            WIDExplorerComponents.DefaultLoggingAction.Invoke(exploration.ToString());

            string dateToken = DateTime.Now.ToString(RunIdManager.FormatDateTime);

            string json = explorer.ToJson(exploration);
            string filename = string.Concat(@"C:\Users\Rubèn\Desktop\Exploration", dateToken, ".json");
            File.WriteAllText(filename, json);

            WIDMetrics metrics = new WIDMetricsManager().Calculate(exploration);
            json = explorer.ToJson(metrics);
            filename = string.Concat(@"C:\Users\Rubèn\Desktop\Metrics", dateToken, ".json");
            File.WriteAllText(filename, json);

            WIDExplorerComponents.DefaultLoggingAction.Invoke("Press a button to close the window.");
            Console.ReadLine();

        }

    }
}
