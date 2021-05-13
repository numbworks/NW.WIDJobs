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

            FileInfo fileInfo = new FileInfo(@"C:\Users\Rubèn\Desktop\WorkInDenmark Responses\WorkInDenmark_Page4PageItemExtended14.html");
            string content = File.ReadAllText(fileInfo.FullName);

            PageItem pageItem = new PageItem(
                 runId: "fake_runid",
                 pageNumber: 4,
                 url: "https://www.workindenmark.dk/job/8144162/Assistant-professor-adjunkt-position-in-span-class-max-ultrafast-span-span-class-max-photoelectron-span-span-class-max-spectroscopy-span",
                 title: "Assistant professor (adjunkt) position in ultrafast photoelectron spectroscopy",
                 createDate: new DateTime(2021, 05, 08),
                 applicationDate: new DateTime(2021, 05, 26),
                 workArea: "Århus C",
                 workAreaWithoutZone: "Århus",
                 workingHours: "Full time (37 hours)",
                 jobType: "Regular position",
                 jobId: 5339196,
                 pageItemNumber: 14,
                 pageItemId: "5339196assistantprofessoradjunktpositioninultrafastphotoelectronspectroscopy"
              );

            PageItemExtendedScraper pageItemExtendedScraper = new PageItemExtendedScraper();
            PageItemExtended pageItemExtended = pageItemExtendedScraper.Do(pageItem, content);

            string json = Serialize(pageItemExtended);

            Console.ReadLine();

        }

        static void PageManager_Test1_GetTotalResults()
        {

            FileInfo fileInfo = new FileInfo(@"C:\Users\Rubèn\Desktop\WorkInDenmark Responses\WorkInDenmark_Page1.html");
            string content = File.ReadAllText(fileInfo.FullName);

            IPageManager pageManager = new PageManager();
            uint totalResults = pageManager.GetTotalResults(content);

            Console.WriteLine(totalResults); // 2039
            Console.Write($"{nameof(PageManager_Test1_GetTotalResults)}: completed.");

        }
        static void PageItemScraper_Test1_Do()
        {

            FileInfo fileInfo = new FileInfo(@"C:\Users\Rubèn\Desktop\WorkInDenmark Responses\WorkInDenmark_Page1.html");
            string content = File.ReadAllText(fileInfo.FullName);

            Page page = new Page("fake_runid", 1, content);

            PageItemScraper pageItemScraper = new PageItemScraper();
            List<PageItem> pageItems = pageItemScraper.Do(page);      
            
            Console.Write($"{nameof(PageItemScraper_Test1_Do)}: completed.");

        }
        static void PageItemScraper_Test2_Do()
        {

            FileInfo fileInfo = new FileInfo(@"C:\Users\Rubèn\Desktop\WorkInDenmark Responses\WorkInDenmark_Page2.html");
            string content = File.ReadAllText(fileInfo.FullName);

            Page page = new Page("fake_runid", 2, content);

            PageItemScraper pageItemScraper = new PageItemScraper();
            List<PageItem> pageItems = pageItemScraper.Do(page);

            Console.Write($"{nameof(PageItemScraper_Test2_Do)}: completed.");

        }
        static void PageItemExtendedScraper_Test1_Do()
        {

            FileInfo fileInfo = new FileInfo(@"C:\Users\Rubèn\Desktop\WorkInDenmark Responses\WorkInDenmark_Page1PageItemExtended1.html");
            string content = File.ReadAllText(fileInfo.FullName);

            PageItem pageItem = new PageItem(
                 runId: "fake_runId",
                 pageNumber: 1,
                 url: "https://www.workindenmark.dk/job/8144115/Learning-sales-Fulltime-Student-Position",
                 title: "Learning sales – Fulltime Student Position",
                 createDate: new DateTime(2021, 05, 07),
                 applicationDate: null,
                 workArea: "Ikast",
                 workAreaWithoutZone: "Ikast",
                 workingHours: "Full time (37 hours)",
                 jobType: "Regular position",
                 jobId: 8144115,
                 pageItemNumber: 1,
                 pageItemId: "8144115learningsalesfulltimestudentposition"
              );

            PageItemExtendedScraper pageItemExtendedScraper = new PageItemExtendedScraper();
            PageItemExtended pageItemExtended = pageItemExtendedScraper.Do(pageItem, content);

        }
        static void PageItemExtendedScraper_Test2_Do()
        {

            FileInfo fileInfo = new FileInfo(@"C:\Users\Rubèn\Desktop\WorkInDenmark Responses\WorkInDenmark_Page1PageItemExtended14.html");
            string content = File.ReadAllText(fileInfo.FullName);

            PageItem pageItem = new PageItem(
                 runId: "fake_runId",
                 pageNumber: 1,
                 url: "https://www.workindenmark.dk/job/8144071/Lean-Professional",
                 title: "Lean Professional",
                 createDate: new DateTime(2021, 05, 07),
                 applicationDate: new DateTime(2021, 06, 03),
                 workArea: "Lem St",
                 workAreaWithoutZone: "Lem",
                 workingHours: "Full time (37 hours)",
                 jobType: "Regular position",
                 jobId: 8144071,
                 pageItemNumber: 14,
                 pageItemId: "8144071leanprofessional"
              );

            PageItemExtendedScraper pageItemExtendedScraper = new PageItemExtendedScraper();
            PageItemExtended pageItemExtended = pageItemExtendedScraper.Do(pageItem, content);

        }
        static void PageItemExtendedScraper_Test3_Do()
        {

            FileInfo fileInfo = new FileInfo(@"C:\Users\Rubèn\Desktop\WorkInDenmark Responses\WorkInDenmark_Page2PageItemExtended18.html");
            string content = File.ReadAllText(fileInfo.FullName);

            PageItem pageItem = new PageItem(
                 runId: "fake_runid",
                 pageNumber: 2,
                 url: "https://www.workindenmark.dk/job/8144107/Dutch-speaking-Salesperson",
                 title: "Dutch speaking Salesperson",
                 createDate: new DateTime(2021, 05, 07),
                 applicationDate: new DateTime(2021, 07, 01),
                 workArea: "Bjert",
                 workAreaWithoutZone: "Bjert",
                 workingHours: "Full time (37 hours)",
                 jobType: "Regular position",
                 jobId: 8144107,
                 pageItemNumber: 18,
                 pageItemId: "8144107dutchspeakingsalesperson"
              );

            PageItemExtendedScraper pageItemExtendedScraper = new PageItemExtendedScraper();
            PageItemExtended pageItemExtended = pageItemExtendedScraper.Do(pageItem, content);

        }

        static string Serialize(dynamic obj)
        {

            System.Text.Json.JsonSerializerOptions jso = new System.Text.Json.JsonSerializerOptions();
            jso.Encoder = System.Text.Encodings.Web.JavaScriptEncoder.UnsafeRelaxedJsonEscaping;
            
            return System.Text.Json.JsonSerializer.Serialize(obj, jso);

        }

    }
}
