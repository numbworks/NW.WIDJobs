using System;
using System.IO;
using NW.WIDJobs;

namespace NW.WIDJobsClient
{
    class Program
    {
        static void Main(string[] args)
        {

            WIDExplorerComponents components = new WIDExplorerComponents();
            WIDExplorerSettings settings = new WIDExplorerSettings();
            WIDExplorer explorer = new WIDExplorer();

            FileInfo fileInfo = new FileInfo(@"C:\Users\Rubèn\Desktop\WorkInDenmark Responses\WorkInDenmark_Page1.html");
            string content = File.ReadAllText(fileInfo.FullName);

            IPageManager pageManager = new PageManager();
            uint totalResults = pageManager.GetTotalResults(content);

            Console.WriteLine(totalResults); // 2039

            Console.WriteLine();
        }
    }
}
