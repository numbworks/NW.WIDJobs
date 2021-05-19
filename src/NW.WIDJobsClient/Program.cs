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


            WIDExplorer widExplorer = new WIDExplorer();
            WIDResult explorationResult 
                = widExplorer.Explore(1, Categories.ItTech, WIDStages.Stage5_PageItemsExtended);

            WIDExplorerComponents.DefaultLoggingAction.Invoke(explorationResult.ToString());

            string json = widExplorer.ToJson(explorationResult);
            string filename = string.Concat(
                    @"C:\Users\Rubèn\Desktop\ExplorationResult",
                    $"{DateTime.Now.ToString(RunIdManager.FormatDateTime)}",
                    ".json"
                );
            File.WriteAllText(filename, json);

            WIDExplorerComponents.DefaultLoggingAction.Invoke("Press a button to close the window.");
            Console.ReadLine();

        }

    }
}
