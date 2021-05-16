using System;
using System.IO;
using System.Collections.Generic;
using NW.WIDJobs;
using System.Text.RegularExpressions;
using System.Linq;
using System.Text;

namespace NW.WIDJobsClient
{
    class Program
    {
        static void Main(string[] args)
        {


            WIDExplorer widExplorer = new WIDExplorer();
            ExplorationResult explorationResult 
                = widExplorer.Explore(1, 1, Categories.ItTech, ExplorationStages.Stage1_TotalResults);

            Console.ReadLine();

        }

        static string ReadFile(string uri)
        {

            FileInfo fileInfo = new FileInfo(uri);
            string content = File.ReadAllText(fileInfo.FullName);

            return content;

        }
        static string Serialize(dynamic obj)
        {

            System.Text.Json.JsonSerializerOptions jso = new System.Text.Json.JsonSerializerOptions();
            jso.Encoder = System.Text.Encodings.Web.JavaScriptEncoder.UnsafeRelaxedJsonEscaping;
            
            return System.Text.Json.JsonSerializer.Serialize(obj, jso);

        }

    }
}
