using System;
using System.IO;
using System.Collections.Generic;
using NW.WIDJobs;

namespace NW.WIDJobsClient
{
    class Program
    {
        static void Main(string[] args)
        {

            FileInfo fileInfo = new FileInfo(@"C:\Users\Rubèn\Desktop\WorkInDenmark Responses\WorkInDenmark_Page1.html");
            string content = File.ReadAllText(fileInfo.FullName);

            Page page = new Page("fake_runid", 1, content);

            PageItemScraper pageItemScraper = new PageItemScraper();
            List<PageItem> pageItems = pageItemScraper.Do(page);

            Console.WriteLine();
        }

        static void Test1_GetTotalResults()
        {

            FileInfo fileInfo = new FileInfo(@"C:\Users\Rubèn\Desktop\WorkInDenmark Responses\WorkInDenmark_Page1.html");
            string content = File.ReadAllText(fileInfo.FullName);

            IPageManager pageManager = new PageManager();
            uint totalResults = pageManager.GetTotalResults(content);

            Console.WriteLine(totalResults); // 2039

        }


    }
}
