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
            ExplorationResult explorationResult 
                = widExplorer.Explore(1, 1, Categories.ItTech, ExplorationStages.Stage5_PageItemsExtended);

            WIDExplorerComponents.DefaultLoggingAction.Invoke(explorationResult.ToString());

            string json = widExplorer.Serialize(explorationResult);
            File.WriteAllText(@"C:\Users\Rubèn\Desktop\ExplorationResult.json", json);

            WIDExplorerComponents.DefaultLoggingAction.Invoke("Press a button to close the window.");
            Console.ReadLine();

        }

    }
}
