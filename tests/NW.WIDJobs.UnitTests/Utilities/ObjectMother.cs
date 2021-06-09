using NSubstitute;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;

namespace NW.WIDJobs.UnitTests
{
    public static class ObjectMother
    {

        #region Shared

        internal static string Shared_FakeRunId = "FakeRunId";
        internal static Func<string, IGetRequestManager> Shared_FakeGetRequestManager
            = (url) =>
            {

                List<(string url, string content)> tuples = new List<(string url, string content)>()
                {

                    (Shared_Page01_Url, Shared_Page01_Content),
                    (Shared_Page02_Url, Shared_Page02_Content),

                    (Shared_Page01_PageItemExtended01.PageItem.Url, Shared_Page01_PageItemExtended01_Content),
                    (Shared_Page01_PageItemExtended14.PageItem.Url, Shared_Page01_PageItemExtended14_Content),
                    (Shared_Page02_PageItemExtended18.PageItem.Url, Shared_Page02_PageItemExtended18_Content),
                    (Shared_Page03_PageItemExtended01.PageItem.Url, Shared_Page03_PageItemExtended01_Content),
                    (Shared_Page03_PageItemExtended02.PageItem.Url, Shared_Page03_PageItemExtended02_Content),
                    (Shared_Page03_PageItemExtended03.PageItem.Url, Shared_Page03_PageItemExtended03_Content),
                    (Shared_Page03_PageItemExtended04.PageItem.Url, Shared_Page03_PageItemExtended04_Content),

                };

                IGetRequestManager fakeGetRequestManager = Substitute.For<IGetRequestManager>();

                foreach ((string url, string content) tuple in tuples)
                    if (string.Equals(url, tuple.url, StringComparison.InvariantCulture))
                    {
                        fakeGetRequestManager.Send(tuple.url, Arg.Any<Encoding>()).Returns(tuple.content);
                        break;
                    };
                // We don't consider the case in which we do provide an url that it's not among the ones in the list. 

                return fakeGetRequestManager;

            };

        #endregion

        #region Shared_Page01

        internal static uint Shared_Page01_TotalResults = 2039;
        internal static ushort Shared_Page01_TotalEstimatedPages = 102;
        internal static string Shared_Page01_Content = Properties.Resources.Page01;
        internal static Page Shared_Page01 = new Page(Shared_FakeRunId, 1, Shared_Page01_Content);

        internal static PageItem Shared_Page01_PageItem01 = new PageItem(
                 runId: Shared_FakeRunId,
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
        internal static PageItem Shared_Page01_PageItem02 = new PageItem(
                 runId: Shared_FakeRunId,
                 pageNumber: 1,
                 url: "https://www.workindenmark.dk/job/8144114/Unpaid-Internship-Sales",
                 title: "Unpaid Internship Sales",
                 createDate: new DateTime(2021, 05, 07),
                 applicationDate: null,
                 workArea: "Ikast",
                 workAreaWithoutZone: "Ikast",
                 workingHours: "Full time (37 hours)",
                 jobType: "Limited period",
                 jobId: 8144114,
                 pageItemNumber: 2,
                 pageItemId: "8144114unpaidinternshipsales"
              );
        internal static PageItem Shared_Page01_PageItem03 = new PageItem(
                 runId: Shared_FakeRunId,
                 pageNumber: 1,
                 url: "https://www.workindenmark.dk/job/8144099/Site-Reliability-Engineer",
                 title: "Site Reliability Engineer",
                 createDate: new DateTime(2021, 05, 07),
                 applicationDate: null,
                 workArea: "København",
                 workAreaWithoutZone: "København",
                 workingHours: "Full time (37 hours)",
                 jobType: "Regular position",
                 jobId: 8144099,
                 pageItemNumber: 3,
                 pageItemId: "8144099sitereliabilityengineer"
              );
        internal static PageItem Shared_Page01_PageItem04 = new PageItem(
                 runId: Shared_FakeRunId,
                 pageNumber: 1,
                 url: "https://www.workindenmark.dk/job/8144098/IT-architect-Consultant",
                 title: "IT-architect / Consultant",
                 createDate: new DateTime(2021, 05, 07),
                 applicationDate: null,
                 workArea: "København",
                 workAreaWithoutZone: "København",
                 workingHours: "Full time (37 hours)",
                 jobType: "Regular position",
                 jobId: 8144098,
                 pageItemNumber: 4,
                 pageItemId: "8144098itarchitectconsultant"
              );
        internal static PageItem Shared_Page01_PageItem05 = new PageItem(
                 runId: Shared_FakeRunId,
                 pageNumber: 1,
                 url: "https://www.workindenmark.dk/job/8144090/Student-Worker",
                 title: "Student Worker",
                 createDate: new DateTime(2021, 05, 07),
                 applicationDate: null,
                 workArea: "Nordborg",
                 workAreaWithoutZone: "Nordborg",
                 workingHours: "Full time (37 hours)",
                 jobType: "Regular position",
                 jobId: 8144090,
                 pageItemNumber: 5,
                 pageItemId: "8144090studentworker"
              );
        internal static PageItem Shared_Page01_PageItem06 = new PageItem(
                 runId: Shared_FakeRunId,
                 pageNumber: 1,
                 url: "https://www.workindenmark.dk/job/8144089/Business-Support-Pricing-Manager",
                 title: "Business Support & Pricing Manager",
                 createDate: new DateTime(2021, 05, 07),
                 applicationDate: null,
                 workArea: "Vejle",
                 workAreaWithoutZone: "Vejle",
                 workingHours: "Full time (37 hours)",
                 jobType: "Regular position",
                 jobId: 8144089,
                 pageItemNumber: 6,
                 pageItemId: "8144089businesssupportpricingmanager"
              );
        internal static PageItem Shared_Page01_PageItem07 = new PageItem(
                 runId: Shared_FakeRunId,
                 pageNumber: 1,
                 url: "https://www.workindenmark.dk/job/8144087/Asst-Lead-Engineer-LaC",
                 title: "Asst Lead Engineer, LaC",
                 createDate: new DateTime(2021, 05, 07),
                 applicationDate: null,
                 workArea: "Århus N",
                 workAreaWithoutZone: "Århus",
                 workingHours: "Full time (37 hours)",
                 jobType: "Regular position",
                 jobId: 8144087,
                 pageItemNumber: 7,
                 pageItemId: "8144087asstleadengineerlac"
              );
        internal static PageItem Shared_Page01_PageItem08 = new PageItem(
                 runId: Shared_FakeRunId,
                 pageNumber: 1,
                 url: "https://www.workindenmark.dk/job/8144086/Clinical-Project-Manager-Office-based",
                 title: "Clinical Project Manager (Office based)",
                 createDate: new DateTime(2021, 05, 07),
                 applicationDate: null,
                 workArea: "København K",
                 workAreaWithoutZone: "København",
                 workingHours: "Full time (37 hours)",
                 jobType: "Regular position",
                 jobId: 8144086,
                 pageItemNumber: 8,
                 pageItemId: "8144086clinicalprojectmanagerofficebased"
              );
        internal static PageItem Shared_Page01_PageItem09 = new PageItem(
                 runId: Shared_FakeRunId,
                 pageNumber: 1,
                 url: "https://www.workindenmark.dk/job/8144080/Senior-Developer-Operations",
                 title: "Senior Developer, Operations",
                 createDate: new DateTime(2021, 05, 07),
                 applicationDate: null,
                 workArea: "København V",
                 workAreaWithoutZone: "København",
                 workingHours: "Full time (37 hours)",
                 jobType: "Regular position",
                 jobId: 8144080,
                 pageItemNumber: 9,
                 pageItemId: "8144080seniordeveloperoperations"
              );
        internal static PageItem Shared_Page01_PageItem10 = new PageItem(
                 runId: Shared_FakeRunId,
                 pageNumber: 1,
                 url: "https://www.workindenmark.dk/job/8144079/Manager-Global-Workplace",
                 title: "Manager, Global Workplace",
                 createDate: new DateTime(2021, 05, 07),
                 applicationDate: null,
                 workArea: "København V",
                 workAreaWithoutZone: "København",
                 workingHours: "Full time (37 hours)",
                 jobType: "Regular position",
                 jobId: 8144079,
                 pageItemNumber: 10,
                 pageItemId: "8144079managerglobalworkplace"
              );
        internal static PageItem Shared_Page01_PageItem11 = new PageItem(
                 runId: Shared_FakeRunId,
                 pageNumber: 1,
                 url: "https://www.workindenmark.dk/job/8144075/Supply-Chain-Business-Analyst",
                 title: "Supply Chain Business Analyst",
                 createDate: new DateTime(2021, 05, 07),
                 applicationDate: null,
                 workArea: "Århus N",
                 workAreaWithoutZone: "Århus",
                 workingHours: "Full time (37 hours)",
                 jobType: "Regular position",
                 jobId: 8144075,
                 pageItemNumber: 11,
                 pageItemId: "8144075supplychainbusinessanalyst"
              );
        internal static PageItem Shared_Page01_PageItem12 = new PageItem(
                 runId: Shared_FakeRunId,
                 pageNumber: 1,
                 url: "https://www.workindenmark.dk/job/8144074/Systems-Engineer",
                 title: "Systems Engineer",
                 createDate: new DateTime(2021, 05, 07),
                 applicationDate: null,
                 workArea: "Århus N",
                 workAreaWithoutZone: "Århus",
                 workingHours: "Full time (37 hours)",
                 jobType: "Regular position",
                 jobId: 8144074,
                 pageItemNumber: 12,
                 pageItemId: "8144074systemsengineer"
              );
        internal static PageItem Shared_Page01_PageItem13 = new PageItem(
                 runId: Shared_FakeRunId,
                 pageNumber: 1,
                 url: "https://www.workindenmark.dk/job/8144072/Assistant-Lead-Engineer",
                 title: "Assistant Lead Engineer",
                 createDate: new DateTime(2021, 05, 07),
                 applicationDate: null,
                 workArea: "Lem St",
                 workAreaWithoutZone: "Lem",
                 workingHours: "Full time (37 hours)",
                 jobType: "Regular position",
                 jobId: 8144072,
                 pageItemNumber: 13,
                 pageItemId: "8144072assistantleadengineer"
              );
        internal static PageItem Shared_Page01_PageItem14 = new PageItem(
                 runId: Shared_FakeRunId,
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
        internal static PageItem Shared_Page01_PageItem15 = new PageItem(
                 runId: Shared_FakeRunId,
                 pageNumber: 1,
                 url: "https://www.workindenmark.dk/job/8144070/Maternity-support-Logistics",
                 title: "Maternity support Logistics",
                 createDate: new DateTime(2021, 05, 07),
                 applicationDate: new DateTime(2021, 11, 30),
                 workArea: "Lem St",
                 workAreaWithoutZone: "Lem",
                 workingHours: "Full time (37 hours)",
                 jobType: "Regular position",
                 jobId: 8144070,
                 pageItemNumber: 15,
                 pageItemId: "8144070maternitysupportlogistics"
              );
        internal static PageItem Shared_Page01_PageItem16 = new PageItem(
                 runId: Shared_FakeRunId,
                 pageNumber: 1,
                 url: "https://www.workindenmark.dk/job/8144061/Senior-Model-Risk-Analyst-Stockholm-Copenhagen-or-Warsaw",
                 title: "Senior Model Risk Analyst, Stockholm, Copenhagen or Warsaw",
                 createDate: new DateTime(2021, 05, 07),
                 applicationDate: new DateTime(2021, 05, 16),
                 workArea: "København S",
                 workAreaWithoutZone: "København",
                 workingHours: "Full time (37 hours)",
                 jobType: "Regular position",
                 jobId: 8144061,
                 pageItemNumber: 16,
                 pageItemId: "8144061seniormodelriskanalyststockholm"
              );
        internal static PageItem Shared_Page01_PageItem17 = new PageItem(
                 runId: Shared_FakeRunId,
                 pageNumber: 1,
                 url: "https://www.workindenmark.dk/job/8144054/Quality-Assurance-and-Knowledge-Team-Lead",
                 title: "Quality Assurance and Knowledge Team Lead",
                 createDate: new DateTime(2021, 05, 07),
                 applicationDate: null,
                 workArea: "København K",
                 workAreaWithoutZone: "København",
                 workingHours: "Full time (37 hours)",
                 jobType: "Regular position",
                 jobId: 8144054,
                 pageItemNumber: 17,
                 pageItemId: "8144054qualityassuranceandknowledgeteam"
              );
        internal static PageItem Shared_Page01_PageItem18 = new PageItem(
                 runId: Shared_FakeRunId,
                 pageNumber: 1,
                 url: "https://www.workindenmark.dk/job/8144044/Student-Assistant",
                 title: "Student Assistant",
                 createDate: new DateTime(2021, 05, 07),
                 applicationDate: null,
                 workArea: "København S",
                 workAreaWithoutZone: "København",
                 workingHours: "Full time (37 hours)",
                 jobType: "Limited period",
                 jobId: 8144044,
                 pageItemNumber: 18,
                 pageItemId: "8144044studentassistant"
              );
        internal static PageItem Shared_Page01_PageItem19 = new PageItem(
                 runId: Shared_FakeRunId,
                 pageNumber: 1,
                 url: "https://www.workindenmark.dk/job/8144030/Senior-Consultant-Branding",
                 title: "Senior Consultant - Branding",
                 createDate: new DateTime(2021, 05, 07),
                 applicationDate: new DateTime(2021, 05, 25),
                 workArea: "København S",
                 workAreaWithoutZone: "København",
                 workingHours: "Full time (37 hours)",
                 jobType: "Regular position",
                 jobId: 8144030,
                 pageItemNumber: 19,
                 pageItemId: "8144030seniorconsultantbranding"
              );
        internal static PageItem Shared_Page01_PageItem20 = new PageItem(
                 runId: Shared_FakeRunId,
                 pageNumber: 1,
                 url: "https://www.workindenmark.dk/job/8144023/Business-Development-Manager-ScrewdriverDispenser-m-f-d",
                 title: "Business Development Manager, ScrewdriverDispenser (m/f/d)",
                 createDate: new DateTime(2021, 05, 07),
                 applicationDate: null,
                 workArea: "Odense SØ",
                 workAreaWithoutZone: "Odense",
                 workingHours: "Full time (37 hours)",
                 jobType: "Regular position",
                 jobId: 8144023,
                 pageItemNumber: 20,
                 pageItemId: "8144023businessdevelopmentmanagerscrewdriverdispenserm"
              );

        internal static List<PageItem> Shared_Page01_PageItems = new List<PageItem>()
        {

            Shared_Page01_PageItem01,
            Shared_Page01_PageItem02,
            Shared_Page01_PageItem03,
            Shared_Page01_PageItem04,
            Shared_Page01_PageItem05,
            Shared_Page01_PageItem06,
            Shared_Page01_PageItem07,
            Shared_Page01_PageItem08,
            Shared_Page01_PageItem09,
            Shared_Page01_PageItem10,
            Shared_Page01_PageItem11,
            Shared_Page01_PageItem12,
            Shared_Page01_PageItem13,
            Shared_Page01_PageItem14,
            Shared_Page01_PageItem15,
            Shared_Page01_PageItem16,
            Shared_Page01_PageItem17,
            Shared_Page01_PageItem18,
            Shared_Page01_PageItem19,
            Shared_Page01_PageItem20

        };

        internal static string Shared_Page01_PageItemExtended01_Content = Properties.Resources.Page01_PageItemExtended01;
        internal static PageItemExtended Shared_Page01_PageItemExtended01 = new PageItemExtended(

            pageItem: Shared_Page01_PageItem01,
            description: "This website uses cookiesIf you choose to accept cookies, you agree that Talentech and third-parties store the cookies of your choice. If you don't consent, we only store the cookies necessary for functionality.Allow selection Allow all cookies NecessaryPreferencesStatisticsMarketing\t Show details Warning Your browser is outdated. Get the best experience with speed, security and privacy by using the latest version of Chrome, Firefox, Microsoft Edge, Safari or Opera ×  Learning sales – Fulltime Student PositionApply for this position if-\tYou want to learn and develop you sales skills-\tYou want to work in an rapidly expanding international company-\tYou want to make a difference for renewable energyIn KK Wind Solutions Service, we are looking for talented candidates to join our Spare Parts Sales Team. We are offering a fulltime student position, where you will be learning as well as performing. So if you are looking for a year of lesser studying and an opportunity to start ...",
            seeCompleteTextAt: "https://candidate.hr-manager.net/ApplicationInit.aspx?cid=1119&ProjectId=144192&DepartmentId=18956&MediaId=5&SkipAdvertisement=False",
            bulletPoints: new HashSet<string>{
                "You want to learn and develop you sales skills",
                "You want to work in an rapidly expanding international company"
            },
            employerName: null,
            numberOfOpenings: null,
            advertisementPublishDate: null,
            applicationDeadline: null,
            startDateOfEmployment: null,
            reference: null,
            position: null,
            typeOfEmployment: null,
            contact: null,
            employerAddress: null,
            howToApply: null

        );

        internal static string Shared_Page01_PageItemExtended14_Content = Properties.Resources.Page01_PageItemExtended14;
        internal static PageItemExtended Shared_Page01_PageItemExtended14 = new PageItemExtended(

            pageItem: Shared_Page01_PageItem14,
            description: "Apply now »  Lean Professional DK, Lem | Professional | Full-Time | ID: 14167Are you a role model for continuous improvement and business change? If you’ve got motivation for Lean and Continuous Improvement Culture and are a communicator at all levels, then this is the role for you! Manufacturing & Global Procurement > Blades > Continuous ImprovementVestas Blades Launch & Execution center (BLEC) is a function within the Blades Organisation within Vestas Manufacturing. The function is responsible for delivering our manufacturing production design, inducing special projects, development of process and tooling for the blades in Vestas. In Continuous Improvement (CI), we are responsible for developing and implementing the Vestas Toolbox towards internal and external blade manufacturers. You will take part in developing and deploying continuous improvement activities towards new product projects as well as into our exiting toolbox.You will be working in a multicultural organisati...",
            seeCompleteTextAt: "https://careers.vestas.com/job/Lem-Lean-Professional-6940/672167601/",
            bulletPoints: new HashSet<string> { },
            employerName: null,
            numberOfOpenings: null,
            advertisementPublishDate: null,
            applicationDeadline: null,
            startDateOfEmployment: null,
            reference: null,
            position: null,
            typeOfEmployment: null,
            contact: null,
            employerAddress: null,
            howToApply: null

        );

        internal static string Shared_Page01_Url 
            = "https://www.workindenmark.dk/Search/Job-search?q=&orderBy=date";
        internal static string Shared_Page01_UrlForAnalysis 
            = "https://www.workindenmark.dk/search/Job-search?q=&categories=Analysis&orderBy=date";

        internal static List<Page> Shared_Pages_Page01 = new List<Page>() { Shared_Page01 };
        internal static List<PageItemExtended> Shared_Page01_PageItemsExtended
            = new List<PageItemExtended>()
            {
                Shared_Page01_PageItemExtended01,
                Shared_Page01_PageItemExtended14
            };

        #endregion

        #region Shared_Page02

        internal static string Shared_Page02_Content = Properties.Resources.Page02;
        internal static Page Shared_Page02 = new Page(Shared_FakeRunId, 2, Shared_Page02_Content);

        internal static PageItem Shared_Page02_PageItem01 = new PageItem(
                 runId: Shared_FakeRunId,
                 pageNumber: 2,
                 url: "https://www.workindenmark.dk/job/8144022/Chef-for-PET-Forebyggelse",
                 title: "Chef for PET Forebyggelse",
                 createDate: new DateTime(2021, 05, 07),
                 applicationDate: new DateTime(2021, 05, 24),
                 workArea: "Søborg",
                 workAreaWithoutZone: "Søborg",
                 workingHours: "Full time (37 hours)",
                 jobType: "Regular position",
                 jobId: 8144022,
                 pageItemNumber: 1,
                 pageItemId: "8144022chefforpetforebyggelse"
              );
        internal static PageItem Shared_Page02_PageItem02 = new PageItem(
                 runId: Shared_FakeRunId,
                 pageNumber: 2,
                 url: "https://www.workindenmark.dk/job/8144021/Bliv-procesoperatørelev-hos-FMC",
                 title: "Bliv procesoperatørelev hos FMC",
                 createDate: new DateTime(2021, 05, 07),
                 applicationDate: new DateTime(2021, 06, 23),
                 workArea: "Harboøre",
                 workAreaWithoutZone: "Harboøre",
                 workingHours: "Full time (37 hours)",
                 jobType: "Regular position",
                 jobId: 8144021,
                 pageItemNumber: 2,
                 pageItemId: "8144021blivprocesoperatrelevhosfmc"
              );
        internal static PageItem Shared_Page02_PageItem03 = new PageItem(
                 runId: Shared_FakeRunId,
                 pageNumber: 2,
                 url: "https://www.workindenmark.dk/job/8144020/IT-elev-til-IT-Service",
                 title: "IT-elev til IT-Service",
                 createDate: new DateTime(2021, 05, 07),
                 applicationDate: new DateTime(2021, 05, 31),
                 workArea: "København S",
                 workAreaWithoutZone: "København",
                 workingHours: "Full time (37 hours)",
                 jobType: "Regular position",
                 jobId: 8144020,
                 pageItemNumber: 3,
                 pageItemId: "8144020itelevtilitservice"
              );
        internal static PageItem Shared_Page02_PageItem04 = new PageItem(
                 runId: Shared_FakeRunId,
                 pageNumber: 2,
                 url: "https://www.workindenmark.dk/job/8141253/Junior-Executive-in-Branding",
                 title: "Junior Executive in Branding",
                 createDate: new DateTime(2021, 05, 07),
                 applicationDate: null,
                 workArea: "København V",
                 workAreaWithoutZone: "København",
                 workingHours: "Full time (37 hours)",
                 jobType: "Regular position",
                 jobId: 8141253,
                 pageItemNumber: 4,
                 pageItemId: "8141253juniorexecutiveinbranding"
              );
        internal static PageItem Shared_Page02_PageItem05 = new PageItem(
                 runId: Shared_FakeRunId,
                 pageNumber: 2,
                 url: "https://www.workindenmark.dk/job/8141243/Project-Manager-for-IT-Management",
                 title: "Project Manager for IT Management",
                 createDate: new DateTime(2021, 05, 07),
                 applicationDate: null,
                 workArea: "Århus",
                 workAreaWithoutZone: "Århus",
                 workingHours: "Full time (37 hours)",
                 jobType: "Regular position",
                 jobId: 8141243,
                 pageItemNumber: 5,
                 pageItemId: "8141243projectmanagerforitmanagement"
              );
        internal static PageItem Shared_Page02_PageItem06 = new PageItem(
                 runId: Shared_FakeRunId,
                 pageNumber: 2,
                 url: "https://www.workindenmark.dk/job/8141235/Motivated-warehouseworkers-i-Taulov",
                 title: "Motivated warehouseworkers i Taulov",
                 createDate: new DateTime(2021, 05, 07),
                 applicationDate: new DateTime(2021, 05, 30),
                 workArea: "Vejle",
                 workAreaWithoutZone: "Vejle",
                 workingHours: "Full time (37 hours)",
                 jobType: "Limited period",
                 jobId: 8141235,
                 pageItemNumber: 6,
                 pageItemId: "8141235motivatedwarehouseworkersitaulov"
              );
        internal static PageItem Shared_Page02_PageItem07 = new PageItem(
                 runId: Shared_FakeRunId,
                 pageNumber: 2,
                 url: "https://www.workindenmark.dk/job/8141230/System-Administrator-End-User-Devices",
                 title: "System Administrator - End User Devices",
                 createDate: new DateTime(2021, 05, 07),
                 applicationDate: null,
                 workArea: "Hedehusene",
                 workAreaWithoutZone: "Hedehusene",
                 workingHours: "Full time (37 hours)",
                 jobType: "Regular position",
                 jobId: 8141230,
                 pageItemNumber: 7,
                 pageItemId: "8141230systemadministratorenduserdevices"
              );
        internal static PageItem Shared_Page02_PageItem08 = new PageItem(
                 runId: Shared_FakeRunId,
                 pageNumber: 2,
                 url: "https://www.workindenmark.dk/job/8141229/Manager-for-IT-Building-Device-Management",
                 title: "Manager for IT Building & Device Management",
                 createDate: new DateTime(2021, 05, 07),
                 applicationDate: null,
                 workArea: "Hedehusene",
                 workAreaWithoutZone: "Hedehusene",
                 workingHours: "Full time (37 hours)",
                 jobType: "Regular position",
                 jobId: 8141229,
                 pageItemNumber: 8,
                 pageItemId: "8141229managerforitbuildingdevice"
              );
        internal static PageItem Shared_Page02_PageItem09 = new PageItem(
                 runId: Shared_FakeRunId,
                 pageNumber: 2,
                 url: "https://www.workindenmark.dk/job/8141228/Cloud-Solution-Architect-for-Global-IT",
                 title: "Cloud Solution Architect for Global IT",
                 createDate: new DateTime(2021, 05, 07),
                 applicationDate: null,
                 workArea: "Hedehusene",
                 workAreaWithoutZone: "Hedehusene",
                 workingHours: "Full time (37 hours)",
                 jobType: "Regular position",
                 jobId: 8141228,
                 pageItemNumber: 9,
                 pageItemId: "8141228cloudsolutionarchitectforglobal"
              );
        internal static PageItem Shared_Page02_PageItem10 = new PageItem(
                 runId: Shared_FakeRunId,
                 pageNumber: 2,
                 url: "https://www.workindenmark.dk/job/8140198/Bliv-salgstrainee-hos-Out-of-Home-Media-ApS",
                 title: "Bliv salgstrainee hos Out of Home Media ApS",
                 createDate: new DateTime(2021, 05, 07),
                 applicationDate: null,
                 workArea: "København Ø",
                 workAreaWithoutZone: "København",
                 workingHours: "Full time (37 hours)",
                 jobType: "Regular position",
                 jobId: 8140198,
                 pageItemNumber: 10,
                 pageItemId: "8140198blivsalgstraineehosoutof"
              );
        internal static PageItem Shared_Page02_PageItem11 = new PageItem(
                 runId: Shared_FakeRunId,
                 pageNumber: 2,
                 url: "https://www.workindenmark.dk/job/8138446/Inside-Sales-Account-Manager",
                 title: "Inside Sales Account Manager",
                 createDate: new DateTime(2021, 05, 07),
                 applicationDate: null,
                 workArea: "København S",
                 workAreaWithoutZone: "København",
                 workingHours: "Full time (37 hours)",
                 jobType: "Limited period",
                 jobId: 8138446,
                 pageItemNumber: 11,
                 pageItemId: "8138446insidesalesaccountmanager"
              );
        internal static PageItem Shared_Page02_PageItem12 = new PageItem(
                 runId: Shared_FakeRunId,
                 pageNumber: 2,
                 url: "https://www.workindenmark.dk/job/8144113/Senior-Serialisation-SAP-ATTP-Consultant-I-O-Delivery",
                 title: "Senior Serialisation / SAP ATTP Consultant, I&O Delivery",
                 createDate: new DateTime(2021, 05, 07),
                 applicationDate: new DateTime(2021, 05, 19),
                 workArea: "Ballerup",
                 workAreaWithoutZone: "Ballerup",
                 workingHours: "Full time (37 hours)",
                 jobType: "Regular position",
                 jobId: 8144113,
                 pageItemNumber: 12,
                 pageItemId: "8144113seniorserialisationsapattpconsultant"
              );
        internal static PageItem Shared_Page02_PageItem13 = new PageItem(
                 runId: Shared_FakeRunId,
                 pageNumber: 2,
                 url: "https://www.workindenmark.dk/job/8144112/SDM-Product-Owner-I-O-Delivery",
                 title: "SDM/Product Owner, I&O Delivery",
                 createDate: new DateTime(2021, 05, 07),
                 applicationDate: new DateTime(2021, 05, 19),
                 workArea: "Ballerup",
                 workAreaWithoutZone: "Ballerup",
                 workingHours: "Full time (37 hours)",
                 jobType: "Regular position",
                 jobId: 8144112,
                 pageItemNumber: 13,
                 pageItemId: "8144112sdmproductownerio"
              );
        internal static PageItem Shared_Page02_PageItem14 = new PageItem(
                 runId: Shared_FakeRunId,
                 pageNumber: 2,
                 url: "https://www.workindenmark.dk/job/8144111/Head-of-Third-Party-Management",
                 title: "Head of Third Party Management",
                 createDate: new DateTime(2021, 05, 07),
                 applicationDate: new DateTime(2021, 05, 31),
                 workArea: "København",
                 workAreaWithoutZone: "København",
                 workingHours: "Full time (37 hours)",
                 jobType: "Regular position",
                 jobId: 8144111,
                 pageItemNumber: 14,
                 pageItemId: "8144111headofthirdpartymanagement"
              );
        internal static PageItem Shared_Page02_PageItem15 = new PageItem(
                 runId: Shared_FakeRunId,
                 pageNumber: 2,
                 url: "https://www.workindenmark.dk/job/8144110/00000000",
                 title: "00000000",
                 createDate: new DateTime(2021, 05, 07),
                 applicationDate: new DateTime(2021, 05, 14),
                 workArea: "København",
                 workAreaWithoutZone: "København",
                 workingHours: "Full time (37 hours)",
                 jobType: "Regular position",
                 jobId: 8144110,
                 pageItemNumber: 15,
                 pageItemId: "8144110"
              );
        internal static PageItem Shared_Page02_PageItem16 = new PageItem(
                 runId: Shared_FakeRunId,
                 pageNumber: 2,
                 url: "https://www.workindenmark.dk/job/8144109/Technology-Vendor-Contract-Manager",
                 title: "Technology Vendor & Contract Manager",
                 createDate: new DateTime(2021, 05, 07),
                 applicationDate: new DateTime(2021, 05, 26),
                 workArea: "København",
                 workAreaWithoutZone: "København",
                 workingHours: "Full time (37 hours)",
                 jobType: "Regular position",
                 jobId: 8144109,
                 pageItemNumber: 16,
                 pageItemId: "8144109technologyvendorcontractmanager"
              );
        internal static PageItem Shared_Page02_PageItem17 = new PageItem(
                 runId: Shared_FakeRunId,
                 pageNumber: 2,
                 url: "https://www.workindenmark.dk/job/8144108/EDI-Integration-Architect",
                 title: "EDI Integration Architect",
                 createDate: new DateTime(2021, 05, 07),
                 applicationDate: new DateTime(2021, 05, 28),
                 workArea: "København",
                 workAreaWithoutZone: "København",
                 workingHours: "Full time (37 hours)",
                 jobType: "Regular position",
                 jobId: 8144108,
                 pageItemNumber: 17,
                 pageItemId: "8144108ediintegrationarchitect"
              );
        internal static PageItem Shared_Page02_PageItem18 = new PageItem(
                 runId: Shared_FakeRunId,
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
        internal static PageItem Shared_Page02_PageItem19 = new PageItem(
                 runId: Shared_FakeRunId,
                 pageNumber: 2,
                 url: "https://www.workindenmark.dk/job/8144104/Id-146047-Administrative-Project-Manager-for-the-European-Horizon-2020-Project-REFLOW",
                 title: "Id 146047 - Administrative Project Manager for the European Horizon 2020 Project REFLOW",
                 createDate: new DateTime(2021, 05, 07),
                 applicationDate: new DateTime(2021, 06, 09),
                 workArea: "Frederiksberg",
                 workAreaWithoutZone: "Frederiksberg",
                 workingHours: "Full time (37 hours)",
                 jobType: "Regular position",
                 jobId: 8144104,
                 pageItemNumber: 19,
                 pageItemId: "8144104idadministrativeprojectmanagerfor"
              );
        internal static PageItem Shared_Page02_PageItem20 = new PageItem(
                 runId: Shared_FakeRunId,
                 pageNumber: 2,
                 url: "https://www.workindenmark.dk/job/8144102/Experienced-Embedded-Linux-Developer",
                 title: "Experienced Embedded Linux Developer",
                 createDate: new DateTime(2021, 05, 07),
                 applicationDate: new DateTime(2021, 07, 01),
                 workArea: "Århus N",
                 workAreaWithoutZone: "Århus",
                 workingHours: "Full time (37 hours)",
                 jobType: "Regular position",
                 jobId: 8144102,
                 pageItemNumber: 20,
                 pageItemId: "8144102experiencedembeddedlinuxdeveloper"
              );
        internal static List<PageItem> Shared_Page02_PageItems = new List<PageItem>()
        {

            Shared_Page02_PageItem01,
            Shared_Page02_PageItem02,
            Shared_Page02_PageItem03,
            Shared_Page02_PageItem04,
            Shared_Page02_PageItem05,
            Shared_Page02_PageItem06,
            Shared_Page02_PageItem07,
            Shared_Page02_PageItem08,
            Shared_Page02_PageItem09,
            Shared_Page02_PageItem10,
            Shared_Page02_PageItem11,
            Shared_Page02_PageItem12,
            Shared_Page02_PageItem13,
            Shared_Page02_PageItem14,
            Shared_Page02_PageItem15,
            Shared_Page02_PageItem16,
            Shared_Page02_PageItem17,
            Shared_Page02_PageItem18,
            Shared_Page02_PageItem19,
            Shared_Page02_PageItem20

        };

        internal static string Shared_Page02_PageItemExtended18_Content = Properties.Resources.Page02_PageItemExtended18;
        internal static PageItemExtended Shared_Page02_PageItemExtended18 = new PageItemExtended(

            pageItem: Shared_Page02_PageItem18,
            description: "Bixter.dk ApS in Kolding is looking for several new talented salespeople for the Dutch market. About the position:Bixter.dk ApS is dealing with English- and German-speaking workforce worldwide. We currently have a strong focus on the agricultural area in the Netherlands, which is the reason why we are looking for you! About you...You either have experience from a previous position of telephone sales, cold-calling or have the courage to learn it.You can imagine an everyday life where your phone is your most important work tool.You are smiley, openminded and outgoing by nature.You can easily start a conversation over the phone with people you do not know.You are persistent, and do not give up, even if you experience a lot of resistance in the procedure of selling.You have the ambition and aspiration in the long run, to become a top salesperson, coach, or leader in one of our ever-growing departments. You speak and write English and Dutch fluently.As a seller with us, your most important task will be to contact all types of farmers, employers in the Netherlands over the phone. You must enter into agreements with them in relation to cooperation on the dissemination of English-speaking agricultural trainees from several different countries. You will receive internal sales training, and for the right person, there are many opportunities to grow together with us. We can offer:New and modern premises in a rural setting and with a view to Kolding-fjord.Skilled, sales-oriented colleagues who help each other and have a good humor.An office with high ceilings, where everyone is welcomed regardless of culture, religion and hair color.Lunch arrangement and social events, Christmas lunch and cozy evenings with dinner and such.Salary is agreed at the job interview and depends on experience and qualifications ... If you are interested, send your application and CV to nj@bixter.comor call Nataliya Jørgensen on tel. +45 27 11 78 64 to hear more about the position.",
            seeCompleteTextAt: null,
            bulletPoints: new HashSet<string> { },
            employerName: "Bixter.dk ApS",
            numberOfOpenings: 1,
            advertisementPublishDate: new DateTime(2021, 05, 06),
            applicationDeadline: new DateTime(2021, 07, 01),
            startDateOfEmployment: "As soon as possible",
            reference: "Holland",
            position: "Sales, purchases and marketing / Sales assistants",
            typeOfEmployment: "Regular position",
            contact: "Nataliya Jørgensen",
            employerAddress: "Bixter.dk ApS Mads Kehlets Vej 29 DK 6091 Bjert Denmark",
            howToApply: "Via e-mail: nj@bixter.com Written"

        );

        internal static string Shared_Page02_Url 
            = "https://www.workindenmark.dk/Search/Job-search?q=&orderBy=date&PageNum=2&";
        internal static string Shared_Page02_UrlForAnalysis
            = "https://www.workindenmark.dk/search/Job-search?q=&categories=Analysis&orderBy=date&PageNum=2";

        #endregion

        #region Shared_Page03

        internal static string Shared_Page03_PageItemExtended01_Content = Properties.Resources.Page03_PageItemExtended01;
        internal static PageItem Shared_Page03_PageItem01 = new PageItem(
                         runId: Shared_FakeRunId,
                         pageNumber: 3,
                         url: "https://www.workindenmark.dk/job/8144162/Assistant-professor-adjunkt-position-in-span-class-max-ultrafast-span-span-class-max-photoelectron-span-span-class-max-spectroscopy-span",
                         title: "Assistant professor (adjunkt) position in ultrafast photoelectron spectroscopy",
                         createDate: new DateTime(2021, 05, 08),
                         applicationDate: new DateTime(2021, 05, 26),
                         workArea: "Århus C",
                         workAreaWithoutZone: "Århus",
                         workingHours: "Full time (37 hours)",
                         jobType: "Regular position",
                         jobId: 5339196,
                         pageItemNumber: 1,
                         pageItemId: "5339196assistantprofessoradjunktpositionin"
                      );
        internal static PageItemExtended Shared_Page03_PageItemExtended01 = new PageItemExtended(

            pageItem: Shared_Page03_PageItem01,
            description: "We are seeking applicants for an assistant professor position in the area of ultrafast photoelectron spectroscopy. The successful applicant will establish time-resolved X-ray photoemission spectroscopy and X-ray photoelectron diffraction using free electron lasers and high harmonic laser sources.Starting Date and PeriodThe starting date is September 1, 2021, and the position ends on the 31.3.2024.Job descriptionThe successful applicant will take a leading role in the development of ultrafast X-ray photoelectron spectroscopy (XPS) and photoelectron diffraction techniques, using free electron lasers such as FLASH or LCLS, as well as high harmonic laser sources. Time-resolved XPS is in its infancy and the applicant will address both the technical development of the technique, as well as its application to open problems in selected quantum materials. Exploration of materials with synchrotron radiation-based photoelectron spectroscopy will be an essential part and prerequisite for the time-resolved studies.The applicant is also expected to build up experience in teaching and contribute to the department’s courses.ProfileThe candidate must hold a PhD in physics or in a related field. Having already prior experience as a postdoc and in giving guidance to PhD, master and bachelor students will be an advantage.Experience with synchrotron-radiation based photoemission techniques such as XPS, X-ray photoelectron diffraction, angle-resolved photoemission spectroscopy is essential for this project. Additional experience with time-resolved techniques, especially with work at X-ray free electron lasers is highly desirable. The experiments planned here require an advanced level of computational techniques for data handling and analysis and a solid background in computation and coding is essential. Finally, the experiments are typically carried out by several collaborating groups and it is of high importance that the candidate is able to work in (and lead) a team of scientists.Place of work is Ny Munkegade 120, Aarhus CPlease contact Philip Hofmann (philip@phys.au.dk) for further questions. Application procedureShortlisting is used. This means that after the deadline for applications – and with the assistance from the assessment committee chairman, and the assessment committee if necessary, – the head of department selects the candidates to be evaluated. The selection is made on the basis of an assessment of who of the candidates are most relevant considering the requirements of the advertisement. All applicants will be notified within 6 weeks whether or not their applications have been sent to an expert assessment committee for evaluation. The selected applicants will be informed about the composition of the committee and will receive his/her assessment. Once the recruitment process is completed a final letter of rejection is sent to the deselected applicants.Letter of referenceIf you want a referee to upload a letter of reference on your behalf, please state the referee’s contact information when you submit your application. We strongly recommend that you make an agreement with the person in question before you enter the referee’s contact information, and that you ensure that the referee has enough time to write the letter of reference before the application deadline. Unfortunately, it is not possible to ensure that letters of reference received after the application deadline will be taken into consideration.Formalities and salary range Formalities and salary rangeNatural Sciences refers to the Ministerial Order on the Appointment of Academic Staff at Danish Universities under the Danish Ministry of Science, Technology and Innovation.The application must be in English and include a curriculum vitae, degree certificate, a complete list of publications, a statement of future research plans and information about research activities, teaching portfolio and verified information on previous teaching experience (if any). Guidelines for applicants can be found here.Appointment shall be in accordance with the collective labour agreement between the Danish Ministry of Finance and the Danish Confederation of Professional Associations. Further information on qualification requirements and job content may be found in the Memorandum on Job Structure for Academic Staff at Danish Universities.Salary depends on seniority as agreed between the Danish Ministry of Finance and the Confederation of Professional Associations.All interested candidates are encouraged to apply, regardless of their personal background. Research activities will be evaluated in relation to actual research time. Thus, we encourage applicants to specify periods of leave without research activities, in order to be able to subtract these periods from the span of the scientific career during the evaluation of scientific productivity.Aarhus University offers a broad variety of services for international researchers and accompanying families, including relocation service and career counselling to expat partners. Read more here. Please find more information about entering and working in Denmark here.The application must be submitted via Aarhus University’s recruitment system, which can be accessed under the job advertisement on Aarhus University's website.Aarhus UniversityAarhus University is an academically diverse and research-intensive university with a strong commitment to high-quality research and education and the development of society nationally and globally. The university offers an inspiring research and teaching environment to its 38,000 students (FTEs) and 8,000 employees, and has an annual revenues of EUR 885 million. Learn more at www.international.au.dk/.Deadline26. May 2021.",
            seeCompleteTextAt: null,
            bulletPoints: new HashSet<string> { },
            employerName: "Aarhus Universitet",
            numberOfOpenings: 1,
            advertisementPublishDate: new DateTime(2021, 05, 06),
            applicationDeadline: new DateTime(2021, 05, 26),
            startDateOfEmployment: "2021-06-09",
            reference: null,
            position: "Academical work / University research and teaching positions -  science",
            typeOfEmployment: "Regular position",
            contact: "Philip Hofmann",
            employerAddress: "Aarhus Universitet Ny Munkegade 120 DK 8000 Århus C Denmark",
            howToApply: "Online: Application form"

        );

        internal static string Shared_Page03_PageItemExtended02_Content = Properties.Resources.Page03_PageItemExtended02;
        internal static PageItem Shared_Page03_PageItem02 = new PageItem(
                 runId: Shared_FakeRunId,
                 pageNumber: 3,
                 url: "https://www.workindenmark.dk/job/5339216/Embedded-Software-Developer-for-Medical-Device-Development",
                 title: "Embedded Software Developer for Medical Device Development",
                 createDate: new DateTime(2021, 05, 06),
                 applicationDate: new DateTime(2021, 07, 01),
                 workArea: "Herlev",
                 workAreaWithoutZone: "Herlev",
                 workingHours: "Full time (37 hours)",
                 jobType: "Regular position",
                 jobId: 5339196,
                 pageItemNumber: 2,
                 pageItemId: "5339216embeddedsoftwaredeveloperformedical"
              );
        internal static PageItemExtended Shared_Page03_PageItemExtended02 = new PageItemExtended(

            pageItem: Shared_Page03_PageItem02,
            description: "Are you passionate about embedded software development and would you thrive working in a team dedicated to medical device development? If so, then the job as software developer in the Life Science group at Prevas A/S might be something for you!We are looking for an embedded software developer with experience from medical device development. In this assignment you will be working on development projects, from specifying the features to writing the code and seeing the code through to CE marking. We work with new technology and new ideas and develop embedded systems for many different types of customers from medical device start-up companies to larger medical device development companies.As our new colleague, it is important that you:Have extensive experience with embedded software developmentAre an experienced C/C++ programmerHave experience with software architecture, design documentation and development complying to relevant standardsCan write requirement and test specificationsHave working knowledge of medical device software standards (IEC 62304 and IEC 82304)Have an academic degree in Computer Science, Electrical Engineering, or equivalentAbout Prevas:We are a consultant and development house. For us development is a natural part of all aspects of life – from idea to product and from career to personal life. We believe that ingenuity will save the world.Our values are gathered in the acronym BOAT – Business Driven, Open Minded, Active and Team Player.We are embedded in our DNA and we are focused on being the preferred provider of embedded development to our customers. We often work very closely with our customers, and as Prevas employee, you will often come into close contact with many different customers’ development departments, either as project member at our office in Herlev, or on-site in the customer’s development team.In our department in Herlev, we are 40 employees. We have an informal corporate culture with great opportunity for influence as well as great opportunities for personal- and competence development in some of the most exciting and challenging development projects. We believe that a balance between work and private life is a prerequisite for efficiency and creativity in the office.If you are interested in the job, send your application and CV via the form on our website. We call for interviews on an ongoing basis.If you would like to know more, please contact Team Manager at Herlev, Mette Dahl Meincke at tel: +45 26 77 70 83. You can also read more about Prevas at our homepage and on LinkedIn.",
            seeCompleteTextAt: null,
            bulletPoints: new HashSet<string> {
                  "Have extensive experience with embedded software development",
                  "Are an experienced C/C++ programmer",
                  "Have experience with software architecture, design documentation and development complying to relevant standards",
                  "Can write requirement and test specifications",
                  "Have working knowledge of medical device software standards (IEC 62304 and IEC 82304)",
                  "Have an academic degree in Computer Science, Electrical Engineering, or equivalent"
            },
            employerName: "PREVAS A/S",
            numberOfOpenings: 1,
            advertisementPublishDate: new DateTime(2021, 05, 06),
            applicationDeadline: new DateTime(2021, 07, 01),
            startDateOfEmployment: "As soon as possible",
            reference: null,
            position: "",
            typeOfEmployment: "Regular position",
            contact: "Team Manager - Life Science Mette Meincke Phone: +45 26 77 70 83 Mobile: +45 26 77 70 83",
            employerAddress: "PREVAS A/S Lyskær 3 DK 2730 Herlev Denmark",
            howToApply: "Online: Application form"

        );

        internal static string Shared_Page03_PageItemExtended03_Content = Properties.Resources.Page03_PageItemExtended03;
        internal static PageItem Shared_Page03_PageItem03 = new PageItem(
                 runId: Shared_FakeRunId,
                 pageNumber: 3,
                 url: "https://www.workindenmark.dk/job/5339811/Warehouse-Team-Lead",
                 title: "Warehouse Team Lead",
                 createDate: new DateTime(2021, 05, 07),
                 applicationDate: new DateTime(2021, 07, 02),
                 workArea: "Greve",
                 workAreaWithoutZone: "Greve",
                 workingHours: "Full time (37 hours)",
                 jobType: "Regular position",
                 jobId: 5339811,
                 pageItemNumber: 3,
                 pageItemId: "5339811warehouseteamlead"
              );
        internal static PageItemExtended Shared_Page03_PageItemExtended03 = new PageItemExtended(

                    pageItem: Shared_Page03_PageItem03,
                    description: "Do you want to be a part of a dedicated, competitive and fun team? Then come join us, at our vibrant Warehouse. We’re always on the lookout for new talents, who can help lead our teams across different departments. At Hobbii we sell yarn to tens of thousands of customers every month and we are working day and night to become the favourite shop for all yarn lovers worldwide. In order to keep delivering outstanding service and meet our customers needs, with the high season closing in on us, we are looking for additional team leads.All orders are picked, prepared and shipped from our Warehouse facilities in Greve - we call it Space42. Here our team consists of over 140 employees, they make sure our 10 000 square meters are running smoothly, and that everything is picked and packed correctly amongst over 11000 different products.In this position you will lead a team in either our Outbound, Inbound or Quality departments - where you together with our Department Leaders, will be the one calling the shots when it comes to increasing our production numbers, and work with best in class organizing and process optimizationWe work in a fast-paced environment, which is why always changing procedures should delight you, rather than terrify you.With high-season closing in on us, we expect for you to be able to work in our weekly rotations, with shifting day, evening and weekend shifts.So, would you like to?Work in a fast-paced environment, where a competitive mindset and great colleagues are in focusEnsure our productivity through planning, organizing and allocating tasks between your team membersPick and pack, prepare orders for shipments, receive and deliver goods and help maintain Space42 (If you forgot; our Warehouse)And basically simply make sure that everything is running smoothlyThen maybe you’re the one we’re searching for!Who are you:  You’re positive, outgoing and energeticYou have experience with leading teams - and lead by exampleYou always come up with new ways to solve challengesThe one thriving with multiple things going on at once - you keep cool in every situationCompetitive - as we're driven by performanceA great communicator in English (As English is our Company language) At Hobbii we fundamentally believe that we’re better together, and with rocket speed we’re aiming skyhigh. We were recently named as the fastest growing company in Denmark and won the Børsen Gazelle 2020. So generally, building something from scratch should delight you rather than terrify you. But don’t worry, you won’t be doing it alone. Behind it all we’re an ambitious team, who spend all our time making sure going to work doesn’t suck and that we are the favorite shop for all yarn-lovers worldwide.   Are you the one?Hit the apply button!  We would like to know who you are and the work you are proud of. So please share Resume, LinkedIn or anything else you find relevant.  No cover letter or lengthy essay is necessary. We will get to know you through some questions in the application form.",
                    seeCompleteTextAt: null,
                    bulletPoints: new HashSet<string> {
                      "Work in a fast-paced environment, where a competitive mindset and great colleagues are in focus",
                      "Ensure our productivity through planning, organizing and allocating tasks between your team members",
                      "Pick and pack, prepare orders for shipments, receive and deliver goods and help maintain Space42 (If you forgot; our Warehouse)",
                      "And basically simply make sure that everything is running smoothly",
                      "You’re positive, outgoing and energetic",
                      "You have experience with leading teams - and lead by example",
                      "You always come up with new ways to solve challenges",
                      "The one thriving with multiple things going on at once - you keep cool in every situation",
                      "Competitive - as we're driven by performance",
                      "A great communicator in English (As English is our Company language)"
                    },
                    employerName: "Hobbii A/S",
                    numberOfOpenings: 1,
                    advertisementPublishDate: new DateTime(2021, 05, 07),
                    applicationDeadline: new DateTime(2021, 07, 02),
                    startDateOfEmployment: "As soon as possible",
                    reference: null,
                    position: "Transport / Warehouse and logistics operatives",
                    typeOfEmployment: "Regular position",
                    contact: "Workforce Coordinator Jan Lacjak",
                    employerAddress: "Hobbii A/S Kildebrøndevej 42 DK 2670 Greve Denmark",
                    howToApply: "Online: Application form"

                );

        internal static string Shared_Page03_PageItemExtended04_Content = Properties.Resources.Page03_PageItemExtended04;
        internal static PageItem Shared_Page03_PageItem04 = new PageItem(
                 runId: Shared_FakeRunId,
                 pageNumber: 3,
                 url: "https://www.workindenmark.dk/job/5340215/NVH-Test-Engineer",
                 title: "NVH Test Engineer",
                 createDate: new DateTime(2021, 05, 07),
                 applicationDate: new DateTime(2021, 06, 07),
                 workArea: "Middelfart",
                 workAreaWithoutZone: "Middelfart",
                 workingHours: "Full time (37 hours)",
                 jobType: "Regular position",
                 jobId: 5340215,
                 pageItemNumber: 4,
                 pageItemId: "5340215nvhtestengineer"
              );
        internal static PageItemExtended Shared_Page03_PageItemExtended04 = new PageItemExtended(

                    pageItem: Shared_Page03_PageItem04,
                    description: "Do you want to join our growth journey? Are you ready to walk the extra mile to create results? Dinex is looking for an NVH and Test Engineer, who will support the validation of tomorrows exhaust and emission systems for diesel and gas engines and in co-ordination with our customers. The position holds many personal and professional development opportunities and for the right candidate great career opportunities in an exciting local as well as global environment.QualificationsEngineering degree within acoustics & vibrationDetailed knowledge of material testing and dynamic vibration testingDetailed knowledge within NVH data acquisition systems and electrodynamic test equipmentDetailed knowledge within test data analysisDetailed knowledge in the field of signal analysis, material fatigue & sound transmissionMechatronic experience is an advantageGood English skills both written and oralAbility to apply creative problem solvingAgile, customer-focused, and result-orientedGood level with MS Office packageAble to keep agreements and stick to deadlinesProactive and wants to make a differenceOrganized and systematic mindset with great attention to detailTeam playerFlexible working hours are occasionally requiredRoles & ResponsibilitiesYou will take the role as NVH and Test Engineer with the main responsibility of:Setting up tests and data acquisition for NVH testing.Carry out hot vibration testing on exhaust aftertreatment systems.Analyze road load data and extract vibration profiles for subsequent use in vibration testing.Continuous improvement and standardization of hot vibration testing.Carry out various tests on heater/blower setupMaintenance of hot shake test cell, flow rig and all related measuring equipment and hardware.High focus on securing safety and usage of PPE (personal protective equipment)Responsible for 5S and cleanliness in selected areasHourly registrationBe a good representative of the Test Center in relation to customersTravel to Dinex test centres, customers, and engine test cell suppliers and field vehicle testing 5-10 days per yearAbout us:Dinex GroupThe Dinex Group is a leading global manufacturer and distributor of innovative engineered gas or diesel exhaust aftertreatment emission solutions for the heavy-duty truck, construction & agricultural vehicle industryThe Dinex Group, headquartered in Denmark, operates through 20 companies and 2,000 dedicated people worldwide. Dinex is present in 15 different countries, 4 regions, with 5 global tech centres and facilities in Denmark, USA, India, China, Russia, Turkey, UK, Finland, Germany and Latvia. Additionally, Dinex has sales and distribution companies in Spain, Italy, France, Germany, UK, Poland and Serbia.Dinex OEMThe OEM division of Dinex is a leading global manufacturer and distributor of innovative engineered gas and diesel exhaust aftertreatment emission solutions for the heavy truck, construction & agricultural vehicle industry with activities in Europe, North America, Russia, China and India.With our core technologies within coating and system design, we deliver highly sophisticated aftertreatment solutions to prominent OEM customers globally. For cost efficient solutions we support our customers with global tech & test centres, as well as local application engineering that speaks the language.",
                    seeCompleteTextAt: null,
                    bulletPoints: new HashSet<string> {
                      "Engineering degree within acoustics & vibration",
                      "Detailed knowledge of material testing and dynamic vibration testing",
                      "Detailed knowledge within NVH data acquisition systems and electrodynamic test equipment",
                      "Detailed knowledge within test data analysis",
                      "Detailed knowledge in the field of signal analysis, material fatigue & sound transmission",
                      "Mechatronic experience is an advantage",
                      "Good English skills both written and oral",
                      "Ability to apply creative problem solving",
                      "Agile, customer-focused, and result-oriented",
                      "Good level with MS Office package",
                      "Able to keep agreements and stick to deadlines",
                      "Proactive and wants to make a difference",
                      "Organized and systematic mindset with great attention to detail",
                      "Team player",
                      "Flexible working hours are occasionally required",
                      "Setting up tests and data acquisition for NVH testing.",
                      "Carry out hot vibration testing on exhaust aftertreatment systems.",
                      "Analyze road load data and extract vibration profiles for subsequent use in vibration testing.",
                      "Continuous improvement and standardization of hot vibration testing.",
                      "Carry out various tests on heater/blower setup",
                      "Maintenance of hot shake test cell, flow rig and all related measuring equipment and hardware.",
                      "High focus on securing safety and usage of PPE (personal protective equipment)",
                      "Responsible for 5S and cleanliness in selected areas",
                      "Hourly registration",
                      "Be a good representative of the Test Centerin relation to customers",
                      "Travel to Dinex test centres, customers, and engine test cell suppliers and field vehicle testing 5-10 days per year"
                    },
                    employerName: "DINEX A/S",
                    numberOfOpenings: 1,
                    advertisementPublishDate: new DateTime(2021, 05, 07),
                    applicationDeadline: new DateTime(2021, 06, 07),
                    startDateOfEmployment: "As soon as possible",
                    reference: null,
                    position: "Academical work / Engineering professionals",
                    typeOfEmployment: "Regular position",
                    contact: "Global Test Centre Manager Christian Berg Philipp",
                    employerAddress: "DINEX A/S Fynsvej 39 DK 5500 Middelfart Denmark",
                    howToApply: "Online: Application form"

                );

        public static List<PageItemExtended> Shared_Page03_PageItemsExtended
            = new List<PageItemExtended>()
            {
                Shared_Page03_PageItemExtended01,
                Shared_Page03_PageItemExtended02,
                Shared_Page03_PageItemExtended03,
                Shared_Page03_PageItemExtended04
            };

        #endregion

        #region AdditionalCases

        internal static string AdditionalCases_PageItemScraper01_Title 
            = "Software Engineer â€“ Forecasting and Modelling";
        internal static Func<Page> AdditionalCases_PageItemScraper01_Page =
            () =>
            {

                string content
                = Shared_Page01_Content.Replace(
                        Shared_Page01_PageItem01.Title,
                        AdditionalCases_PageItemScraper01_Title
                    );

                return new Page(
                        Shared_Page01.RunId,
                        Shared_Page01.PageNumber,
                        content
                    );

            };
        internal static string AdditionalCases_PageItemScraper01_ExpectedTitle
            = "Software Engineer  Forecasting and Modelling";
        internal static string AdditionalCases_PageItemScraper01_ExpectedPageItemId
            = "8144115softwareengineerforecastingandmodelling";
        internal static PageItem AdditionalCases_PageItemScraper01_ExpectedPageItem01 
            = SwapTitlePageItemId(
                    Shared_Page01_PageItem01, 
                    AdditionalCases_PageItemScraper01_ExpectedTitle,
                    AdditionalCases_PageItemScraper01_ExpectedPageItemId);
        internal static List<PageItem> AdditionalCases_PageItemScraper01_ExpectedPageItems
            = SwapFirstPageItem(Shared_Page01_PageItems, AdditionalCases_PageItemScraper01_ExpectedPageItem01);


        internal static string AdditionalCases_PageItemScraper02_Title
            = "Student with flair for UX and UI Design\n\u00A0Job Details";
        internal static Func<Page> AdditionalCases_PageItemScraper02_Page =
            () =>
            {

                string content
                = Shared_Page01_Content.Replace(
                        Shared_Page01_PageItem01.Title,
                        AdditionalCases_PageItemScraper02_Title
                    );

                return new Page(
                        Shared_Page01.RunId,
                        Shared_Page01.PageNumber,
                        content
                    );

            };
        internal static string AdditionalCases_PageItemScraper02_ExpectedTitle
            = "Student with flair for UX and UI Design Job Details";
        internal static string AdditionalCases_PageItemScraper02_ExpectedPageItemId
            = "8144115studentwithflairforux";
        internal static PageItem AdditionalCases_PageItemScraper02_ExpectedPageItem01 =
            SwapTitlePageItemId(
                Shared_Page01_PageItem01,
                AdditionalCases_PageItemScraper02_ExpectedTitle,
                AdditionalCases_PageItemScraper02_ExpectedPageItemId);
        internal static List<PageItem> AdditionalCases_PageItemScraper02_ExpectedPageItems
            = SwapFirstPageItem(Shared_Page01_PageItems, AdditionalCases_PageItemScraper02_ExpectedPageItem01);

        internal static string AdditionalCases_PageItemScraper03_Url =
            "https://www.workindenmark.dk/job/8144/Learning-sales-Fulltime-Student-Position";
        internal static Func<Page> AdditionalCases_PageItemScraper03_Page =
            () =>
            {

                string content
                = Shared_Page01_Content.Replace(
                    "/job/8144115/Learning-sales-Fulltime-Student-Position",
                    AdditionalCases_PageItemScraper03_Url.Replace("https://www.workindenmark.dk", string.Empty)
                    );

                return new Page(
                        Shared_Page01.RunId,
                        Shared_Page01.PageNumber,
                        content
                    );

            };

        #endregion

        #region Shared_Page01Alternate

        internal static uint Shared_Page01Alternate_TotalResults = Shared_Page01_TotalResults;
        internal static string Shared_Page01Alternate_Content = Properties.Resources.Page01Alternate;
        internal static Page Shared_Page01Alternate = new Page(Shared_FakeRunId, 1, Shared_Page01Alternate_Content);

        internal static DateTime Shared_Page01Alternate_CreateDate01 = new DateTime(2021, 05, 07);
        internal static DateTime Shared_Page01Alternate_CreateDate02 = new DateTime(2021, 05, 07);
        internal static DateTime Shared_Page01Alternate_CreateDate03 = new DateTime(2021, 05, 07);
        internal static DateTime Shared_Page01Alternate_CreateDate04 = new DateTime(2021, 05, 05);
        internal static DateTime Shared_Page01Alternate_CreateDate05 = new DateTime(2021, 05, 05);
        internal static DateTime Shared_Page01Alternate_CreateDate06 = new DateTime(2021, 05, 05);
        internal static DateTime Shared_Page01Alternate_CreateDate07 = new DateTime(2021, 05, 05);
        internal static DateTime Shared_Page01Alternate_CreateDate08 = new DateTime(2021, 05, 01);
        internal static DateTime Shared_Page01Alternate_CreateDate09 = new DateTime(2021, 05, 01);
        internal static DateTime Shared_Page01Alternate_CreateDate10 = new DateTime(2021, 05, 01);
        internal static DateTime Shared_Page01Alternate_CreateDate11 = new DateTime(2021, 04, 30);
        internal static DateTime Shared_Page01Alternate_CreateDate12 = new DateTime(2021, 04, 30);
        internal static DateTime Shared_Page01Alternate_CreateDate13 = new DateTime(2021, 04, 30);
        internal static DateTime Shared_Page01Alternate_CreateDate14 = new DateTime(2021, 04, 30);
        internal static DateTime Shared_Page01Alternate_CreateDate15 = new DateTime(2021, 04, 30);
        internal static DateTime Shared_Page01Alternate_CreateDate16 = new DateTime(2021, 04, 30);
        internal static DateTime Shared_Page01Alternate_CreateDate17 = new DateTime(2021, 04, 28);
        internal static DateTime Shared_Page01Alternate_CreateDate18 = new DateTime(2021, 04, 28);
        internal static DateTime Shared_Page01Alternate_CreateDate19 = new DateTime(2021, 04, 28);
        internal static DateTime Shared_Page01Alternate_CreateDate20 = new DateTime(2021, 04, 28);

        internal static List<DateTime> Shared_Page01Alternate_CreateDates
            = new List<DateTime>()
            {
                Shared_Page01Alternate_CreateDate01,
                Shared_Page01Alternate_CreateDate02,
                Shared_Page01Alternate_CreateDate03,
                Shared_Page01Alternate_CreateDate04,
                Shared_Page01Alternate_CreateDate05,
                Shared_Page01Alternate_CreateDate06,
                Shared_Page01Alternate_CreateDate07,
                Shared_Page01Alternate_CreateDate08,
                Shared_Page01Alternate_CreateDate09,
                Shared_Page01Alternate_CreateDate10,
                Shared_Page01Alternate_CreateDate11,
                Shared_Page01Alternate_CreateDate12,
                Shared_Page01Alternate_CreateDate13,
                Shared_Page01Alternate_CreateDate14,
                Shared_Page01Alternate_CreateDate15,
                Shared_Page01Alternate_CreateDate16,
                Shared_Page01Alternate_CreateDate17,
                Shared_Page01Alternate_CreateDate18,
                Shared_Page01Alternate_CreateDate19,
                Shared_Page01Alternate_CreateDate20
            };

        internal static PageItem Shared_Page01Alternate_PageItem01
            = SwapCreateDate(Shared_Page01_PageItem01, Shared_Page01Alternate_CreateDate01);
        internal static PageItem Shared_Page01Alternate_PageItem02
            = SwapCreateDate(Shared_Page01_PageItem02, Shared_Page01Alternate_CreateDate02);
        internal static PageItem Shared_Page01Alternate_PageItem03
            = SwapCreateDate(Shared_Page01_PageItem03, Shared_Page01Alternate_CreateDate03);
        internal static PageItem Shared_Page01Alternate_PageItem04
            = SwapCreateDate(Shared_Page01_PageItem04, Shared_Page01Alternate_CreateDate04);
        internal static PageItem Shared_Page01Alternate_PageItem05
            = SwapCreateDate(Shared_Page01_PageItem05, Shared_Page01Alternate_CreateDate05);
        internal static PageItem Shared_Page01Alternate_PageItem06
            = SwapCreateDate(Shared_Page01_PageItem06, Shared_Page01Alternate_CreateDate06);
        internal static PageItem Shared_Page01Alternate_PageItem07
            = SwapCreateDate(Shared_Page01_PageItem07, Shared_Page01Alternate_CreateDate07);
        internal static PageItem Shared_Page01Alternate_PageItem08
            = SwapCreateDate(Shared_Page01_PageItem08, Shared_Page01Alternate_CreateDate08);
        internal static PageItem Shared_Page01Alternate_PageItem09
            = SwapCreateDate(Shared_Page01_PageItem09, Shared_Page01Alternate_CreateDate09);
        internal static PageItem Shared_Page01Alternate_PageItem10
            = SwapCreateDate(Shared_Page01_PageItem10, Shared_Page01Alternate_CreateDate10);
        internal static PageItem Shared_Page01Alternate_PageItem11
            = SwapCreateDate(Shared_Page01_PageItem11, Shared_Page01Alternate_CreateDate11);
        internal static PageItem Shared_Page01Alternate_PageItem12
            = SwapCreateDate(Shared_Page01_PageItem12, Shared_Page01Alternate_CreateDate12);
        internal static PageItem Shared_Page01Alternate_PageItem13
            = SwapCreateDate(Shared_Page01_PageItem13, Shared_Page01Alternate_CreateDate13);
        internal static PageItem Shared_Page01Alternate_PageItem14
            = SwapCreateDate(Shared_Page01_PageItem14, Shared_Page01Alternate_CreateDate14);
        internal static PageItem Shared_Page01Alternate_PageItem15
            = SwapCreateDate(Shared_Page01_PageItem15, Shared_Page01Alternate_CreateDate15);
        internal static PageItem Shared_Page01Alternate_PageItem16
            = SwapCreateDate(Shared_Page01_PageItem16, Shared_Page01Alternate_CreateDate16);
        internal static PageItem Shared_Page01Alternate_PageItem17
            = SwapCreateDate(Shared_Page01_PageItem17, Shared_Page01Alternate_CreateDate17);
        internal static PageItem Shared_Page01Alternate_PageItem18
            = SwapCreateDate(Shared_Page01_PageItem18, Shared_Page01Alternate_CreateDate18);
        internal static PageItem Shared_Page01Alternate_PageItem19
            = SwapCreateDate(Shared_Page01_PageItem19, Shared_Page01Alternate_CreateDate19);
        internal static PageItem Shared_Page01Alternate_PageItem20
            = SwapCreateDate(Shared_Page01_PageItem20, Shared_Page01Alternate_CreateDate20);

        internal static List<PageItem> Shared_Page01Alternate_PageItems
            = new List<PageItem>()
            {
                Shared_Page01Alternate_PageItem01,
                Shared_Page01Alternate_PageItem02,
                Shared_Page01Alternate_PageItem03,
                Shared_Page01Alternate_PageItem04,
                Shared_Page01Alternate_PageItem05,
                Shared_Page01Alternate_PageItem06,
                Shared_Page01Alternate_PageItem07,
                Shared_Page01Alternate_PageItem08,
                Shared_Page01Alternate_PageItem09,
                Shared_Page01Alternate_PageItem10,
                Shared_Page01Alternate_PageItem11,
                Shared_Page01Alternate_PageItem12,
                Shared_Page01Alternate_PageItem13,
                Shared_Page01Alternate_PageItem14,
                Shared_Page01Alternate_PageItem15,
                Shared_Page01Alternate_PageItem16,
                Shared_Page01Alternate_PageItem17,
                Shared_Page01Alternate_PageItem18,
                Shared_Page01Alternate_PageItem19,
                Shared_Page01Alternate_PageItem20
            };

        internal static DateTime Shared_Page01Alternate_ThresholdDate = new DateTime(2021, 04, 30);

        #endregion

        #region Shared_Page02Alternate

        internal static uint Shared_Page02Alternate_TotalResults = 2039;
        internal static string Shared_Page02Alternate_Content = Properties.Resources.Page02Alternate;
        internal static Page Shared_Page02Alternate = new Page(Shared_FakeRunId, 2, Shared_Page02Alternate_Content);

        internal static DateTime Shared_Page02Alternate_CreateDate01 = new DateTime(2021, 04, 28);
        internal static DateTime Shared_Page02Alternate_CreateDate02 = new DateTime(2021, 04, 28);
        internal static DateTime Shared_Page02Alternate_CreateDate03 = new DateTime(2021, 04, 28);
        internal static DateTime Shared_Page02Alternate_CreateDate04 = new DateTime(2021, 04, 28);
        internal static DateTime Shared_Page02Alternate_CreateDate05 = new DateTime(2021, 04, 28);
        internal static DateTime Shared_Page02Alternate_CreateDate06 = new DateTime(2021, 04, 28);
        internal static DateTime Shared_Page02Alternate_CreateDate07 = new DateTime(2021, 04, 28);
        internal static DateTime Shared_Page02Alternate_CreateDate08 = new DateTime(2021, 04, 28);
        internal static DateTime Shared_Page02Alternate_CreateDate09 = new DateTime(2021, 04, 27);
        internal static DateTime Shared_Page02Alternate_CreateDate10 = new DateTime(2021, 04, 27);
        internal static DateTime Shared_Page02Alternate_CreateDate11 = new DateTime(2021, 04, 27);
        internal static DateTime Shared_Page02Alternate_CreateDate12 = new DateTime(2021, 04, 27);
        internal static DateTime Shared_Page02Alternate_CreateDate13 = new DateTime(2021, 04, 25);
        internal static DateTime Shared_Page02Alternate_CreateDate14 = new DateTime(2021, 04, 25);
        internal static DateTime Shared_Page02Alternate_CreateDate15 = new DateTime(2021, 04, 25);
        internal static DateTime Shared_Page02Alternate_CreateDate16 = new DateTime(2021, 04, 25);
        internal static DateTime Shared_Page02Alternate_CreateDate17 = new DateTime(2021, 04, 25);
        internal static DateTime Shared_Page02Alternate_CreateDate18 = new DateTime(2021, 04, 25);
        internal static DateTime Shared_Page02Alternate_CreateDate19 = new DateTime(2021, 04, 25);
        internal static DateTime Shared_Page02Alternate_CreateDate20 = new DateTime(2021, 04, 24);

        internal static List<DateTime> Shared_Page02Alternate_CreateDates
            = new List<DateTime>()
            {
                Shared_Page02Alternate_CreateDate01,
                Shared_Page02Alternate_CreateDate02,
                Shared_Page02Alternate_CreateDate03,
                Shared_Page02Alternate_CreateDate04,
                Shared_Page02Alternate_CreateDate05,
                Shared_Page02Alternate_CreateDate06,
                Shared_Page02Alternate_CreateDate07,
                Shared_Page02Alternate_CreateDate08,
                Shared_Page02Alternate_CreateDate09,
                Shared_Page02Alternate_CreateDate10,
                Shared_Page02Alternate_CreateDate11,
                Shared_Page02Alternate_CreateDate12,
                Shared_Page02Alternate_CreateDate13,
                Shared_Page02Alternate_CreateDate14,
                Shared_Page02Alternate_CreateDate15,
                Shared_Page02Alternate_CreateDate16,
                Shared_Page02Alternate_CreateDate17,
                Shared_Page02Alternate_CreateDate18,
                Shared_Page02Alternate_CreateDate19,
                Shared_Page02Alternate_CreateDate20
            };

        internal static PageItem Shared_Page02Alternate_PageItem01
            = SwapCreateDate(Shared_Page02_PageItem01, Shared_Page02Alternate_CreateDate01);
        internal static PageItem Shared_Page02Alternate_PageItem02
            = SwapCreateDate(Shared_Page02_PageItem02, Shared_Page02Alternate_CreateDate02);
        internal static PageItem Shared_Page02Alternate_PageItem03
            = SwapCreateDate(Shared_Page02_PageItem03, Shared_Page02Alternate_CreateDate03);
        internal static PageItem Shared_Page02Alternate_PageItem04
            = SwapCreateDate(Shared_Page02_PageItem04, Shared_Page02Alternate_CreateDate04);
        internal static PageItem Shared_Page02Alternate_PageItem05
            = SwapCreateDate(Shared_Page02_PageItem05, Shared_Page02Alternate_CreateDate05);
        internal static PageItem Shared_Page02Alternate_PageItem06
            = SwapCreateDate(Shared_Page02_PageItem06, Shared_Page02Alternate_CreateDate06);
        internal static PageItem Shared_Page02Alternate_PageItem07
            = SwapCreateDate(Shared_Page02_PageItem07, Shared_Page02Alternate_CreateDate07);
        internal static PageItem Shared_Page02Alternate_PageItem08
            = SwapCreateDate(Shared_Page02_PageItem08, Shared_Page02Alternate_CreateDate08);
        internal static PageItem Shared_Page02Alternate_PageItem09
            = SwapCreateDate(Shared_Page02_PageItem09, Shared_Page02Alternate_CreateDate09);
        internal static PageItem Shared_Page02Alternate_PageItem10
            = SwapCreateDate(Shared_Page02_PageItem10, Shared_Page02Alternate_CreateDate10);
        internal static PageItem Shared_Page02Alternate_PageItem11
            = SwapCreateDate(Shared_Page02_PageItem11, Shared_Page02Alternate_CreateDate11);
        internal static PageItem Shared_Page02Alternate_PageItem12
            = SwapCreateDate(Shared_Page02_PageItem12, Shared_Page02Alternate_CreateDate12);
        internal static PageItem Shared_Page02Alternate_PageItem13
            = SwapCreateDate(Shared_Page02_PageItem13, Shared_Page02Alternate_CreateDate13);
        internal static PageItem Shared_Page02Alternate_PageItem14
            = SwapCreateDate(Shared_Page02_PageItem14, Shared_Page02Alternate_CreateDate14);
        internal static PageItem Shared_Page02Alternate_PageItem15
            = SwapCreateDate(Shared_Page02_PageItem15, Shared_Page02Alternate_CreateDate15);
        internal static PageItem Shared_Page02Alternate_PageItem16
            = SwapCreateDate(Shared_Page02_PageItem16, Shared_Page02Alternate_CreateDate16);
        internal static PageItem Shared_Page02Alternate_PageItem17
            = SwapCreateDate(Shared_Page02_PageItem17, Shared_Page02Alternate_CreateDate17);
        internal static PageItem Shared_Page02Alternate_PageItem18
            = SwapCreateDate(Shared_Page02_PageItem18, Shared_Page02Alternate_CreateDate18);
        internal static PageItem Shared_Page02Alternate_PageItem19
            = SwapCreateDate(Shared_Page02_PageItem19, Shared_Page02Alternate_CreateDate19);
        internal static PageItem Shared_Page02Alternate_PageItem20
            = SwapCreateDate(Shared_Page02_PageItem20, Shared_Page02Alternate_CreateDate20);

        internal static List<PageItem> Shared_Page02Alternate_PageItems
            = new List<PageItem>()
            {
                Shared_Page02Alternate_PageItem01,
                Shared_Page02Alternate_PageItem02,
                Shared_Page02Alternate_PageItem03,
                Shared_Page02Alternate_PageItem04,
                Shared_Page02Alternate_PageItem05,
                Shared_Page02Alternate_PageItem06,
                Shared_Page02Alternate_PageItem07,
                Shared_Page02Alternate_PageItem08,
                Shared_Page02Alternate_PageItem09,
                Shared_Page02Alternate_PageItem10,
                Shared_Page02Alternate_PageItem11,
                Shared_Page02Alternate_PageItem12,
                Shared_Page02Alternate_PageItem13,
                Shared_Page02Alternate_PageItem14,
                Shared_Page02Alternate_PageItem15,
                Shared_Page02Alternate_PageItem16,
                Shared_Page02Alternate_PageItem17,
                Shared_Page02Alternate_PageItem18,
                Shared_Page02Alternate_PageItem19,
                Shared_Page02Alternate_PageItem20
            };

        internal static DateTime Shared_Page02Alternate_ThresholdDate01 = new DateTime(2021, 04, 25);
        internal static ushort Shared_Page02Alternate_PageItemsIndex01 = 19;
        internal static ushort Shared_Page02Alternate_PageItemsExtendedIndex01 = 39;

        internal static DateTime Shared_Page02Alternate_ThresholdDate02 = new DateTime(2021, 04, 27);
        internal static ushort Shared_Page02Alternate_PageItemsIndex02 = 12;
        internal static ushort Shared_Page02Alternate_PageItemsExtendedIndex02 = 32;

        internal static DateTime Shared_Page02Alternate_ThresholdDate03 = new DateTime(2021, 04, 28);
        internal static ushort Shared_Page02Alternate_PageItemsIndex03 = 8;
        internal static ushort Shared_Page02Alternate_PageItemsExtendedIndex03 = 28;

        #endregion

        #region PageManagerTests       

        internal static PageManager PageManager_WithFakeGetRequestManager
                    = new PageManager(
                            Shared_FakeGetRequestManager.Invoke(Shared_Page01_Url),
                            new PageScraper(),
                            new WIDCategoryManager()
                            );
        #endregion

        #region RunIdManagerTests

        internal static DateTime RunIdManager_Now = new DateTime(2020, 01, 01, 19, 25, 40, 980);
        internal static DateTime RunIdManager_StartDate = new DateTime(2019, 09, 01, 00, 00, 00, 000);
        internal static DateTime RunIdManager_EndDate = new DateTime(2019, 12, 31, 23, 59, 59, 999);
        internal static DateTime RunIdManager_Threshold = new DateTime(2020, 03, 31, 00, 00, 00, 000);
        internal static ushort RunIdManager_InitialPageNumber = 1;
        internal static ushort RunIdManager_FinalPageNumber = 3;
        internal static string RunIdManager_RunId_Now 
            = string.Format(
                RunIdManager.TemplateId,
                RunIdManager_Now.ToString(RunIdManager.FormatDateTime)
            );
        internal static string RunIdManager_RunId_StartDateEndDate
            = string.Format(
                RunIdManager.TemplateFromTo,
                RunIdManager_RunId_Now,
                RunIdManager_StartDate.ToString(RunIdManager.FormatDate),
                RunIdManager_EndDate.ToString(RunIdManager.FormatDate)
            );
        internal static string RunIdManager_RunId_Threshold
            = string.Format(
                RunIdManager.TemplateThreshold,
                RunIdManager_RunId_Now,
                RunIdManager_Threshold.ToString(RunIdManager.FormatDate)
            );
        internal static string RunIdManager_RunId_FromTo
            = string.Format(
                RunIdManager.TemplateFromTo,
                RunIdManager_RunId_Now,
                RunIdManager_InitialPageNumber,
                RunIdManager_FinalPageNumber
            );

        #endregion

        #region XPathManagerTests
        
        internal static string XPathManager_HTML =
            string.Concat(
                "<html>",
                "<body>",
                "<h1>This is the title.</h1>",
                "<p>This is a paragraph.</p>",
                "<ul>",
                "<li><a href=\"https://github.com/numbworks\">This is a link</a></li>",
                "<li><a href=\"https://www.nuget.org/profiles/numbworks\">This is another link</a></li>",
                "</ul>",
                "</html>"
                );
        internal static string XPathManager_GetInnerTexts_XPath = "//ul/li";
        internal static List<string> XPathManager_GetInnerTexts_Results 
            = new List<string>() 
            {
                "This is a link",
                "This is another link"
            };
        internal static string XPathManager_GetAttributeValues_XPath = "//ul/li/a/@href";
        internal static List<string> XPathManager_GetAttributeValues_Results
            = new List<string>()
            {
                "https://github.com/numbworks",
                "https://www.nuget.org/profiles/numbworks"
            };
        internal static string XPathManager_TryGetInnerText_XPath = "//div";
        internal static string XPathManager_TryGetFirstAttributeValue_XPath = "//div/@class";

        // WIDExplorationTests
        internal static string WIDExploration_Exploration01_RunId = RunIdManager_RunId_Now;
        internal static uint WIDExploration_Exploration01_TotalResults = Shared_Page01_TotalResults;
        internal static ushort WIDExploration_Exploration01_TotalEstimatedPages = 102;
        internal static WIDCategories WIDExploration_Exploration01_Category = WIDCategories.AllCategories;
        internal static WIDStages WIDExploration_Exploration01_Stage = WIDStages.Stage1_OnlyMetrics;
        internal static bool WIDExploration_Exploration01_IsCompleted = true;
        internal static List<Page> WIDExploration_Exploration01_Pages = null;
        internal static List<PageItem> WIDExploration_Exploration01_PageItems = null;
        internal static List<PageItemExtended> WIDExploration_Exploration01_PageItemsExtended = null;
        internal static WIDExploration WIDExploration_Exploration01
            = new WIDExploration(
                    WIDExploration_Exploration01_RunId,
                    WIDExploration_Exploration01_TotalResults,
                    WIDExploration_Exploration01_TotalEstimatedPages,
                    WIDExploration_Exploration01_Category,
                    WIDExploration_Exploration01_Stage,
                    WIDExploration_Exploration01_IsCompleted,
                    WIDExploration_Exploration01_Pages,
                    WIDExploration_Exploration01_PageItems,
                    WIDExploration_Exploration01_PageItemsExtended
                    );
        internal static string WIDExploration_Exploration01_ToString
            = string.Concat(
                "{ ",
                $"'{nameof(WIDExploration.RunId)}':'{WIDExploration_Exploration01_RunId}', ",
                $"'{nameof(WIDExploration.TotalResults)}':'{WIDExploration_Exploration01_TotalResults}', ",
                $"'{nameof(WIDExploration.TotalEstimatedPages)}':'{WIDExploration_Exploration01_TotalEstimatedPages}', ",
                $"'{nameof(WIDExploration.Category)}':'{WIDExploration_Exploration01_Category}', ",
                $"'{nameof(WIDExploration.Stage)}':'{WIDExploration_Exploration01_Stage}', ",
                $"'{nameof(WIDExploration.IsCompleted)}':'{WIDExploration_Exploration01_IsCompleted}', ",
                $"'{nameof(WIDExploration.Pages)}':'null', ",
                $"'{nameof(WIDExploration.PageItems)}':'null', ",
                $"'{nameof(WIDExploration.PageItemsExtended)}':'null'",
                " }"
                );
        internal static WIDExploration WIDExploration_Exploration02
            = new WIDExploration(
                    WIDExploration_Exploration01_RunId,
                    WIDExploration_Exploration01_TotalResults,
                    WIDExploration_Exploration01_TotalEstimatedPages,
                    WIDExploration_Exploration01_Category,
                    WIDExploration_Exploration01_Stage,
                    WIDExploration_Exploration01_IsCompleted,
                    Shared_Pages_Page01,
                    Shared_Page01_PageItems,
                    Shared_Page01_PageItemsExtended
                    );
        internal static string WIDExploration_Exploration02_ToString
            = string.Concat(
                "{ ",
                $"'{nameof(WIDExploration.RunId)}':'{WIDExploration_Exploration01_RunId}', ",
                $"'{nameof(WIDExploration.TotalResults)}':'{WIDExploration_Exploration01_TotalResults}', ",
                $"'{nameof(WIDExploration.TotalEstimatedPages)}':'{WIDExploration_Exploration01_TotalEstimatedPages}', ",
                $"'{nameof(WIDExploration.Category)}':'{WIDExploration_Exploration01_Category}', ",
                $"'{nameof(WIDExploration.Stage)}':'{WIDExploration_Exploration01_Stage}', ",
                $"'{nameof(WIDExploration.IsCompleted)}':'{WIDExploration_Exploration01_IsCompleted}', ",
                $"'{nameof(WIDExploration.Pages)}':'{Shared_Pages_Page01.Count}', ",
                $"'{nameof(WIDExploration.PageItems)}':'{Shared_Page01_PageItems.Count}', ",
                $"'{nameof(WIDExploration.PageItemsExtended)}':'{Shared_Page01_PageItemsExtended.Count}'",
                " }"
                );

        #endregion

        #region WIDExplorerTests

        internal static DateTime WIDExplorer_FakeNow = new DateTime(2021, 05, 01);           
        internal static Func<IGetRequestManager> WIDExplorer_FakeGetRequestManagerAlternate
            = () =>
            {

                List<(string url, string content)> tuples = new List<(string url, string content)>()
                {

                    (Shared_Page01_Url, Shared_Page01Alternate_Content),
                    (Shared_Page02_Url, Shared_Page02Alternate_Content),

                    // We return the same *Content for each url, because it only matters that get parsed correctly.
                    (Shared_Page01_PageItem01.Url, Shared_Page01_PageItemExtended01_Content),
                    (Shared_Page01_PageItem02.Url, Shared_Page01_PageItemExtended01_Content),
                    (Shared_Page01_PageItem03.Url, Shared_Page01_PageItemExtended01_Content),
                    (Shared_Page01_PageItem04.Url, Shared_Page01_PageItemExtended01_Content),
                    (Shared_Page01_PageItem05.Url, Shared_Page01_PageItemExtended01_Content),
                    (Shared_Page01_PageItem06.Url, Shared_Page01_PageItemExtended01_Content),
                    (Shared_Page01_PageItem07.Url, Shared_Page01_PageItemExtended01_Content),
                    (Shared_Page01_PageItem08.Url, Shared_Page01_PageItemExtended01_Content),
                    (Shared_Page01_PageItem09.Url, Shared_Page01_PageItemExtended01_Content),
                    (Shared_Page01_PageItem10.Url, Shared_Page01_PageItemExtended01_Content),
                    (Shared_Page01_PageItem11.Url, Shared_Page01_PageItemExtended01_Content),
                    (Shared_Page01_PageItem12.Url, Shared_Page01_PageItemExtended01_Content),
                    (Shared_Page01_PageItem13.Url, Shared_Page01_PageItemExtended01_Content),
                    (Shared_Page01_PageItem14.Url, Shared_Page01_PageItemExtended01_Content),
                    (Shared_Page01_PageItem15.Url, Shared_Page01_PageItemExtended01_Content),
                    (Shared_Page01_PageItem16.Url, Shared_Page01_PageItemExtended01_Content),
                    (Shared_Page01_PageItem17.Url, Shared_Page01_PageItemExtended01_Content),
                    (Shared_Page01_PageItem18.Url, Shared_Page01_PageItemExtended01_Content),
                    (Shared_Page01_PageItem19.Url, Shared_Page01_PageItemExtended01_Content),
                    (Shared_Page01_PageItem20.Url, Shared_Page01_PageItemExtended01_Content),

                    (Shared_Page02_PageItem01.Url, Shared_Page01_PageItemExtended01_Content),
                    (Shared_Page02_PageItem02.Url, Shared_Page01_PageItemExtended01_Content),
                    (Shared_Page02_PageItem03.Url, Shared_Page01_PageItemExtended01_Content),
                    (Shared_Page02_PageItem04.Url, Shared_Page01_PageItemExtended01_Content),
                    (Shared_Page02_PageItem05.Url, Shared_Page01_PageItemExtended01_Content),
                    (Shared_Page02_PageItem06.Url, Shared_Page01_PageItemExtended01_Content),
                    (Shared_Page02_PageItem07.Url, Shared_Page01_PageItemExtended01_Content),
                    (Shared_Page02_PageItem08.Url, Shared_Page01_PageItemExtended01_Content),
                    (Shared_Page02_PageItem09.Url, Shared_Page01_PageItemExtended01_Content),
                    (Shared_Page02_PageItem10.Url, Shared_Page01_PageItemExtended01_Content),
                    (Shared_Page02_PageItem11.Url, Shared_Page01_PageItemExtended01_Content),
                    (Shared_Page02_PageItem12.Url, Shared_Page01_PageItemExtended01_Content),
                    (Shared_Page02_PageItem13.Url, Shared_Page01_PageItemExtended01_Content),
                    (Shared_Page02_PageItem14.Url, Shared_Page01_PageItemExtended01_Content),
                    (Shared_Page02_PageItem15.Url, Shared_Page01_PageItemExtended01_Content),
                    (Shared_Page02_PageItem16.Url, Shared_Page01_PageItemExtended01_Content),
                    (Shared_Page02_PageItem17.Url, Shared_Page01_PageItemExtended01_Content),
                    (Shared_Page02_PageItem18.Url, Shared_Page01_PageItemExtended01_Content),
                    (Shared_Page02_PageItem19.Url, Shared_Page01_PageItemExtended01_Content),
                    (Shared_Page02_PageItem20.Url, Shared_Page01_PageItemExtended01_Content)

                };

                IGetRequestManager fakeGetRequestManager = Substitute.For<IGetRequestManager>();

                foreach ((string url, string content) tuple in tuples)
                    fakeGetRequestManager.Send(tuple.url, Arg.Any<Encoding>()).Returns(tuple.content);
                // We don't consider the case in which we do provide an url that it's not among the ones in the list. 

                return fakeGetRequestManager;

            };
        internal static Func<List<PageItemExtended>> WIDExplorer_FakePageItemsExtended
            = () =>
            {

                List<PageItemExtended> pageItemsExtended = new List<PageItemExtended>();

                pageItemsExtended.Add(CreateDummyPageItemExtended(Shared_Page01Alternate_PageItem01));
                pageItemsExtended.Add(CreateDummyPageItemExtended(Shared_Page01Alternate_PageItem02));
                pageItemsExtended.Add(CreateDummyPageItemExtended(Shared_Page01Alternate_PageItem03));
                pageItemsExtended.Add(CreateDummyPageItemExtended(Shared_Page01Alternate_PageItem04));
                pageItemsExtended.Add(CreateDummyPageItemExtended(Shared_Page01Alternate_PageItem05));
                pageItemsExtended.Add(CreateDummyPageItemExtended(Shared_Page01Alternate_PageItem06));
                pageItemsExtended.Add(CreateDummyPageItemExtended(Shared_Page01Alternate_PageItem07));
                pageItemsExtended.Add(CreateDummyPageItemExtended(Shared_Page01Alternate_PageItem08));
                pageItemsExtended.Add(CreateDummyPageItemExtended(Shared_Page01Alternate_PageItem09));
                pageItemsExtended.Add(CreateDummyPageItemExtended(Shared_Page01Alternate_PageItem10));
                pageItemsExtended.Add(CreateDummyPageItemExtended(Shared_Page01Alternate_PageItem11));
                pageItemsExtended.Add(CreateDummyPageItemExtended(Shared_Page01Alternate_PageItem12));
                pageItemsExtended.Add(CreateDummyPageItemExtended(Shared_Page01Alternate_PageItem13));
                pageItemsExtended.Add(CreateDummyPageItemExtended(Shared_Page01Alternate_PageItem14));
                pageItemsExtended.Add(CreateDummyPageItemExtended(Shared_Page01Alternate_PageItem15));
                pageItemsExtended.Add(CreateDummyPageItemExtended(Shared_Page01Alternate_PageItem16));
                pageItemsExtended.Add(CreateDummyPageItemExtended(Shared_Page01Alternate_PageItem17));
                pageItemsExtended.Add(CreateDummyPageItemExtended(Shared_Page01Alternate_PageItem18));
                pageItemsExtended.Add(CreateDummyPageItemExtended(Shared_Page01Alternate_PageItem19));
                pageItemsExtended.Add(CreateDummyPageItemExtended(Shared_Page01Alternate_PageItem20));

                pageItemsExtended.Add(CreateDummyPageItemExtended(Shared_Page02Alternate_PageItem01));
                pageItemsExtended.Add(CreateDummyPageItemExtended(Shared_Page02Alternate_PageItem02));
                pageItemsExtended.Add(CreateDummyPageItemExtended(Shared_Page02Alternate_PageItem03));
                pageItemsExtended.Add(CreateDummyPageItemExtended(Shared_Page02Alternate_PageItem04));
                pageItemsExtended.Add(CreateDummyPageItemExtended(Shared_Page02Alternate_PageItem05));
                pageItemsExtended.Add(CreateDummyPageItemExtended(Shared_Page02Alternate_PageItem06));
                pageItemsExtended.Add(CreateDummyPageItemExtended(Shared_Page02Alternate_PageItem07));
                pageItemsExtended.Add(CreateDummyPageItemExtended(Shared_Page02Alternate_PageItem08));
                pageItemsExtended.Add(CreateDummyPageItemExtended(Shared_Page02Alternate_PageItem09));
                pageItemsExtended.Add(CreateDummyPageItemExtended(Shared_Page02Alternate_PageItem10));
                pageItemsExtended.Add(CreateDummyPageItemExtended(Shared_Page02Alternate_PageItem11));
                pageItemsExtended.Add(CreateDummyPageItemExtended(Shared_Page02Alternate_PageItem12));
                pageItemsExtended.Add(CreateDummyPageItemExtended(Shared_Page02Alternate_PageItem13));
                pageItemsExtended.Add(CreateDummyPageItemExtended(Shared_Page02Alternate_PageItem14));
                pageItemsExtended.Add(CreateDummyPageItemExtended(Shared_Page02Alternate_PageItem15));
                pageItemsExtended.Add(CreateDummyPageItemExtended(Shared_Page02Alternate_PageItem16));
                pageItemsExtended.Add(CreateDummyPageItemExtended(Shared_Page02Alternate_PageItem17));
                pageItemsExtended.Add(CreateDummyPageItemExtended(Shared_Page02Alternate_PageItem18));
                pageItemsExtended.Add(CreateDummyPageItemExtended(Shared_Page02Alternate_PageItem19));
                pageItemsExtended.Add(CreateDummyPageItemExtended(Shared_Page02Alternate_PageItem20));

                return pageItemsExtended;

            };

        internal static Func<ushort, List<PageItem>> Shared_Page02Alternate_GetPageItemsSubset =
            (index) =>
            {

                List<PageItem> pageItems = new List<PageItem>() { };

                pageItems.AddRange(Shared_Page01Alternate_PageItems);
                pageItems.AddRange(Shared_Page02Alternate_PageItems.GetRange(0, index));

                return pageItems;

            };
        internal static Func<ushort, List<PageItemExtended>> Shared_Page02Alternate_GetPageItemsExtendedSubset =
            (index) =>
            {

                List<PageItemExtended> pageItemsExtended = WIDExplorer_FakePageItemsExtended.Invoke();

                return pageItemsExtended.GetRange(0, index);

            };

        #endregion

        #region WIDMetrics

        internal static Dictionary<string, uint> WIDMetrics_Page01_ItemsByWorkAreaWithoutZone
            = new Dictionary<string, uint>()
            {
                { "København", 9 },
                { "Århus", 3 },
                { "Lem", 3 },
                { "Ikast", 2 },
                { "Nordborg", 1 },
                { "Vejle", 1 },
                { "Odense", 1 }
            };
        internal static Dictionary<string, uint> WIDMetrics_Page01_ItemsByCreateDate
            = new Dictionary<string, uint>()
            {
                { "2021-05-07", 20}
            };
        internal static Dictionary<string, uint> WIDMetrics_Page01_ItemsByApplicationDate
            = new Dictionary<string, uint>()
            {
                { "null", 16 },
                { "2021-11-30", 1 },
                { "2021-06-03", 1 },
                { "2021-05-25", 1 },
                { "2021-05-16", 1 }
            };
        internal static Dictionary<string, uint> WIDMetrics_Page01_ItemsByEmployerName
            = new Dictionary<string, uint>()
            {
                { "null", 2 }
            };
        internal static Dictionary<string, uint> WIDMetrics_Page01_ItemsByNumberOfOpenings
            = new Dictionary<string, uint>()
            {
                { "null", 2 }
            };
        internal static Dictionary<string, uint> WIDMetrics_Page01_ItemsByAdvertisementPublishDate
            = new Dictionary<string, uint>()
            {
                { "null", 2 }
            };
        internal static Dictionary<string, uint> WIDMetrics_Page01_ItemsByApplicationDeadline
            = new Dictionary<string, uint>()
            {
                { "null", 2 }
            };
        internal static Dictionary<string, uint> WIDMetrics_Page01_ItemsByStartDateOfEmployment
            = new Dictionary<string, uint>()
            {
                { "null", 2 }
            };
        internal static Dictionary<string, uint> WIDMetrics_Page01_ItemsByReference
            = new Dictionary<string, uint>()
            {
                { "null", 2 }
            };
        internal static Dictionary<string, uint> WIDMetrics_Page01_ItemsByPosition
            = new Dictionary<string, uint>()
            {
                { "null", 2 }
            };
        internal static Dictionary<string, uint> WIDMetrics_Page01_ItemsByTypeOfEmployment
            = new Dictionary<string, uint>()
            {
                { "null", 2 }
            };
        internal static Dictionary<string, uint> WIDMetrics_Page01_ItemsByContact
            = new Dictionary<string, uint>()
            {
                { "null", 2 }
            };
        internal static Dictionary<string, uint> WIDMetrics_Page01_ItemsByEmployerAddress
            = new Dictionary<string, uint>()
            {
                { "null", 2 }
            };
        internal static Dictionary<string, uint> WIDMetrics_Page01_ItemsByHowToApply
            = new Dictionary<string, uint>()
            {
                { "null", 2 }
            };
        internal static Dictionary<string, uint> WIDMetrics_Page01_DescriptionLengthByPageItemId
            = new Dictionary<string, uint>()
            {
                { "8144071leanprofessional", 992 },
                { "8144115learningsalesfulltimestudentposition", 988 }
            };
        internal static Dictionary<string, uint> WIDMetrics_Page01_BulletPointsByPageItemId
            = new Dictionary<string, uint>()
            {
                { "8144115learningsalesfulltimestudentposition", 2 },
                { "8144071leanprofessional", 0 }
            };
        internal static uint WIDMetrics_Page01_TotalBulletPoints = 2;

        #endregion

        #region WIDMetricsManager

        internal static WIDExploration WIDMetricsManager_ExplorationWithNullPageItems
            = new WIDExploration(
                    Shared_FakeRunId,
                    Shared_Page01_TotalResults,
                    Shared_Page01_TotalEstimatedPages,
                    WIDCategories.AllCategories,
                    WIDStages.Stage3_UpToAllPageItemsExtended,
                    true,
                    Shared_Pages_Page01,
                    null,
                    Shared_Page01_PageItemsExtended
                );
        internal static WIDExploration WIDMetricsManager_ExplorationWithNullPageItemsExtended
            = new WIDExploration(
                    Shared_FakeRunId,
                    Shared_Page01_TotalResults,
                    Shared_Page01_TotalEstimatedPages,
                    WIDCategories.AllCategories,
                    WIDStages.Stage3_UpToAllPageItemsExtended,
                    true,
                    Shared_Pages_Page01,
                    Shared_Page01_PageItems,
                    null
                );

        internal static Dictionary<string, uint> WIDMetricsManager_WorkAreas = new Dictionary<string, uint>()
            {

                { "København", 45 },
                { "Nordborg", 12 },
                { "Vejen", 4 }

            };
        internal static Dictionary<string, string> WIDMetricsManager_WorkAreasAsPercentages = new Dictionary<string, string>()
            {

                { "København", $"{WIDMetricsManager.FormatPercentage(73.77)}" },
                { "Nordborg", $"{WIDMetricsManager.FormatPercentage(19.67)}" },
                { "Vejen", $"{WIDMetricsManager.FormatPercentage(6.56)}" }

            };

        internal static WIDMetrics WIDMetrics_Exploration02_Metrics =
            new WIDMetrics(
                    WIDExploration_Exploration01_RunId,
                    (uint)Shared_Pages_Page01.Count,
                    (uint)Shared_Page01_PageItems.Count,
                    WIDMetrics_Page01_ItemsByWorkAreaWithoutZone,
                    WIDMetrics_Page01_ItemsByCreateDate,
                    WIDMetrics_Page01_ItemsByApplicationDate,
                    WIDMetrics_Page01_ItemsByEmployerName,
                    WIDMetrics_Page01_ItemsByNumberOfOpenings,
                    WIDMetrics_Page01_ItemsByAdvertisementPublishDate,
                    WIDMetrics_Page01_ItemsByApplicationDeadline,
                    WIDMetrics_Page01_ItemsByStartDateOfEmployment,
                    WIDMetrics_Page01_ItemsByReference,
                    WIDMetrics_Page01_ItemsByPosition,
                    WIDMetrics_Page01_ItemsByTypeOfEmployment,
                    WIDMetrics_Page01_ItemsByContact,
                    WIDMetrics_Page01_ItemsByEmployerAddress,
                    WIDMetrics_Page01_ItemsByHowToApply,
                    WIDMetrics_Page01_DescriptionLengthByPageItemId,
                    WIDMetrics_Page01_BulletPointsByPageItemId,
                    WIDMetrics_Page01_TotalBulletPoints
                );

        #endregion

        #region ValidatorTests

        internal static string[] Validator_Array1 = new[] { "Dodge", "Datsun", "Jaguar", "DeLorean" };
        internal static Car Validator_Object1 = new Car()
        {
            Brand = "Dodge",
            Model = "Charger",
            Year = 1966,
            Price = 13500,
            Currency = "USD"
        };
        internal static uint Validator_Length1 = 3;
        internal static string Validator_VariableName_Variable = "variable";
        internal static string Validator_VariableName_Length = "length";
        internal static string Validator_VariableName_N1 = "n1";
        internal static string Validator_VariableName_N2 = "n2";
        internal static List<string> List1 = Validator_Array1.ToList();
        internal static uint Validator_Value = Validator_Length1;
        internal static string Validator_String1 = "Dodge";
        internal static string Validator_StringOnlyWhiteSpaces = "   ";
        internal static Dictionary<string, int> Validator_SubScrapers_Proper = new Dictionary<string, int>()
        {

            { "urls", 20 },
            { "titles", 20 },
            { "createDates", 20 },
            { "applicationDates", 20 },
            { "workAreas", 20 },
            { "workAreasWithoutZones", 20 },
            { "workingHours", 20 },
            { "jobTypes", 20 },
            { "jobIds", 20 }

        };
        internal static Dictionary<string, int> Validator_SubScrapers_Wrong = new Dictionary<string, int>()
        {

            { "urls", 19 },
            { "titles", 20 },
            { "createDates", 20 },
            { "applicationDates", 20 },
            { "workAreas", 20 },
            { "workAreasWithoutZones", 20 },
            { "workingHours", 20 },
            { "jobTypes", 20 },
            { "jobIds", 20 }

        };
        internal static DateTime Validator_DateTimeOlder = new DateTime(2019, 09, 01, 00, 00, 00, 000);
        internal static DateTime Validator_DateTimeNewer = new DateTime(2019, 12, 31, 23, 59, 59, 999);

        #endregion

        #region FileManagerTests

        internal static string FileManager_ContentSingleLine = "First line";
        internal static IEnumerable<string> FileManager_ContentMultipleLines =
            new List<string>() {
                "First line",
                "Second line"
            };
        internal static string FileManager_FileInfoAdapterFullName = @"C:\somefile.txt";
        internal static IFileInfoAdapter FileManager_FileInfoAdapterDoesntExist
            => new FakeFileInfoAdapter(false, FileManager_FileInfoAdapterFullName);
        internal static IFileInfoAdapter FileManager_FileInfoAdapterExists
            => new FakeFileInfoAdapter(true, FileManager_FileInfoAdapterFullName);
        internal static IOException FileManager_FileAdapterIOException = new IOException("Impossible to access the file.");
        internal static IFileAdapter FileManager_FileAdapterReadAllMethodsThrowIOException
            => new FakeFileAdapter(
                    fakeReadAllLines: () => throw FileManager_FileAdapterIOException,
                    fakeReadAllText: () => throw FileManager_FileAdapterIOException
                );
        internal static IFileAdapter FileManager_FileAdapterWriteAllMethodsThrowIOException
            => new FakeFileAdapter(
                    fakeWriteAllLines: () => throw FileManager_FileAdapterIOException,
                    fakeWriteAllText: () => throw FileManager_FileAdapterIOException
                );
        internal static IFileAdapter FileManager_FileAdapterAllMethodsWork
            => new FakeFileAdapter(
                    fakeReadAllLines: () => FileManager_ContentMultipleLines.ToArray(),
                    fakeReadAllText: () => FileManager_ContentSingleLine,
                    fakeWriteAllLines: () => { },
                    fakeWriteAllText: () => { }
                );

        #endregion

        #region Methods

        internal static void Method_ShouldThrowACertainException_WhenUnproperArguments
            (TestDelegate del, Type expectedType, string expectedMessage)
        {

            // Arrange
            // Act
            // Assert
            Exception actual = Assert.Throws(expectedType, del);
            Assert.AreEqual(expectedMessage, actual.Message);

        }
        
        internal static bool AreEqual(Page page1, Page page2)
        {

            return string.Equals(page1.RunId, page2.RunId, StringComparison.InvariantCulture)
                        && (page1.PageNumber == page2.PageNumber)
                        && string.Equals(page1.Content, page2.Content, StringComparison.InvariantCulture);

        }
        internal static bool AreEqual(PageItem pageItem1, PageItem pageItem2)
        {

            return (pageItem1.ApplicationDate == pageItem2.ApplicationDate)
                        && (pageItem1.CreateDate == pageItem2.CreateDate)
                        && (pageItem1.JobId == pageItem2.JobId)
                        && string.Equals(pageItem1.JobType, pageItem2.JobType, StringComparison.InvariantCulture)
                        && string.Equals(pageItem1.PageItemId, pageItem2.PageItemId, StringComparison.InvariantCulture)
                        && (pageItem1.PageItemNumber == pageItem2.PageItemNumber)
                        && (pageItem1.PageNumber == pageItem2.PageNumber)
                        && string.Equals(pageItem1.RunId, pageItem2.RunId, StringComparison.InvariantCulture)
                        && string.Equals(pageItem1.Title, pageItem2.Title, StringComparison.InvariantCulture)
                        && string.Equals(pageItem1.Url, pageItem2.Url, StringComparison.InvariantCulture)
                        && string.Equals(pageItem1.WorkArea, pageItem2.WorkArea, StringComparison.InvariantCulture)
                        && string.Equals(pageItem1.WorkAreaWithoutZone, pageItem2.WorkAreaWithoutZone, StringComparison.InvariantCulture)
                        && string.Equals(pageItem1.WorkingHours, pageItem2.WorkingHours, StringComparison.InvariantCulture);

        }
        internal static bool AreEqual(PageItemExtended pageItemExtended1, PageItemExtended pageItemExtended2)
        {

            return (pageItemExtended1.AdvertisementPublishDate == pageItemExtended2.AdvertisementPublishDate)
                        && (pageItemExtended1.ApplicationDeadline == pageItemExtended2.ApplicationDeadline)
                        && string.Equals(pageItemExtended1.Contact, pageItemExtended2.Contact, StringComparison.InvariantCulture)
                        && string.Equals(pageItemExtended1.Description, pageItemExtended2.Description, StringComparison.InvariantCulture)
                        && AreEqual(pageItemExtended1.DescriptionBulletPoints, pageItemExtended2.DescriptionBulletPoints)
                        && string.Equals(pageItemExtended1.DescriptionSeeCompleteTextAt, pageItemExtended2.DescriptionSeeCompleteTextAt, StringComparison.InvariantCulture)
                        && string.Equals(pageItemExtended1.EmployerAddress, pageItemExtended2.EmployerAddress, StringComparison.InvariantCulture)
                        && string.Equals(pageItemExtended1.EmployerName, pageItemExtended2.EmployerName, StringComparison.InvariantCulture)
                        && string.Equals(pageItemExtended1.HowToApply, pageItemExtended2.HowToApply, StringComparison.InvariantCulture)
                        && (pageItemExtended1.NumberOfOpenings == pageItemExtended2.NumberOfOpenings)
                        && AreEqual(pageItemExtended1.PageItem, pageItemExtended2.PageItem)
                        && string.Equals(pageItemExtended1.Position, pageItemExtended2.Position, StringComparison.InvariantCulture)
                        && string.Equals(pageItemExtended1.Reference, pageItemExtended2.Reference, StringComparison.InvariantCulture)
                        && string.Equals(pageItemExtended1.StartDateOfEmployment, pageItemExtended2.StartDateOfEmployment, StringComparison.InvariantCulture);
        
        }
        internal static bool AreEqual(List<Page> list1, List<Page> list2)
        {

            if (list1 == null && list2 == null)
                return true;

            if (list1 == null || list2 == null)
                return false;

            if (list1.Count != list2.Count)
                return false;

            for (int i = 0; i < list1.Count; i++)
                if (AreEqual(list1[i], list2[i]) == false)
                    return false;

            return true;

        }
        internal static bool AreEqual(List<PageItem> list1, List<PageItem> list2)
        {

            if (list1 == null && list2 == null)
                return true;

            if (list1 == null || list2 == null)
                return false;

            if (list1.Count != list2.Count)
                return false;

            for (int i = 0; i < list1.Count; i++)
                if (AreEqual(list1[i], list2[i]) == false)
                    return false;

            return true;

        }
        internal static bool AreEqual(List<PageItemExtended> list1, List<PageItemExtended> list2)
        {

            if (list1 == null && list2 == null)
                return true;

            if (list1 == null || list2 == null)
                return false;

            if (list1.Count != list2.Count)
                return false;

            for (int i = 0; i < list1.Count; i++)
                if (AreEqual(list1[i], list2[i]) == false)
                    return false;

            return true;

        }
        internal static bool AreEqual(HashSet<string> hashset1, HashSet<string> hashset2)
            => AreEqual(new List<string>(hashset1), new List<string>(hashset2));
        internal static bool AreEqual(List<string> list1, List<string> list2)
        {

            if (list1 == null && list2 == null)
                return true;

            if (list1 == null || list2 == null)
                return false;

            if (list1.Count != list2.Count)
                return false;

            for (int i = 0; i < list1.Count; i++)
                if (string.Equals(list1[i], list2[i], StringComparison.InvariantCulture) == false)
                    return false;

            return true;

        }
        internal static bool AreEqual(WIDExploration exploration1, WIDExploration exploration2)
        {

            return string.Equals(exploration1.RunId, exploration2.RunId, StringComparison.InvariantCulture)
                        && (exploration1.TotalResults == exploration2.TotalResults)
                        && (exploration1.TotalEstimatedPages == exploration2.TotalEstimatedPages)
                        && (exploration1.Category == exploration2.Category)
                        && (exploration1.Stage == exploration2.Stage)
                        && (exploration1.IsCompleted == exploration2.IsCompleted)
                        && AreEqual(exploration1.Pages, exploration2.Pages)
                        && AreEqual(exploration1.PageItems, exploration2.PageItems)
                        && AreEqual(exploration1.PageItemsExtended, exploration2.PageItemsExtended);

        }
        internal static bool AreEqual<TKey, TValue>(Dictionary<TKey, TValue> dict1, Dictionary<TKey, TValue> dict2)
        {

            IEqualityComparer<TValue> valueComparer = EqualityComparer<TValue>.Default;

            return dict1.Count == dict2.Count
                    && dict1.Keys.All(key => dict2.ContainsKey(key)
                    && valueComparer.Equals(dict1[key], dict2[key]));

        }
        internal static bool AreEqual(WIDMetrics metrics1, WIDMetrics metrics2)
        {

            return string.Equals(metrics1.RunId, metrics2.RunId, StringComparison.InvariantCulture)
                        && (metrics1.TotalPages == metrics2.TotalPages)
                        && (metrics1.TotalItems == metrics2.TotalItems)
                        && AreEqual(metrics1.ItemsByWorkAreaWithoutZone, metrics2.ItemsByWorkAreaWithoutZone)
                        && AreEqual(metrics1.ItemsByCreateDate, metrics2.ItemsByCreateDate)
                        && AreEqual(metrics1.ItemsByApplicationDate, metrics2.ItemsByApplicationDate)
                        && AreEqual(metrics1.ItemsByEmployerName, metrics2.ItemsByEmployerName)
                        && AreEqual(metrics1.ItemsByNumberOfOpenings, metrics2.ItemsByNumberOfOpenings)
                        && AreEqual(metrics1.ItemsByAdvertisementPublishDate, metrics2.ItemsByAdvertisementPublishDate)
                        && AreEqual(metrics1.ItemsByApplicationDeadline, metrics2.ItemsByApplicationDeadline)
                        && AreEqual(metrics1.ItemsByStartDateOfEmployment, metrics2.ItemsByStartDateOfEmployment)
                        && AreEqual(metrics1.ItemsByReference, metrics2.ItemsByReference)
                        && AreEqual(metrics1.ItemsByPosition, metrics2.ItemsByPosition)
                        && AreEqual(metrics1.ItemsByTypeOfEmployment, metrics2.ItemsByTypeOfEmployment)
                        && AreEqual(metrics1.ItemsByContact, metrics2.ItemsByContact)
                        && AreEqual(metrics1.ItemsByEmployerAddress, metrics2.ItemsByEmployerAddress)
                        && AreEqual(metrics1.ItemsByHowToApply, metrics2.ItemsByHowToApply)
                        && AreEqual(metrics1.DescriptionLengthByPageItemId, metrics2.DescriptionLengthByPageItemId)
                        && AreEqual(metrics1.BulletPointsByPageItemId, metrics2.BulletPointsByPageItemId)
                        && (metrics1.TotalBulletPoints == metrics2.TotalBulletPoints);

        }
        internal static bool AreEqual(PageItem pageItem, PageItemEntity pageItemEntity)
        {

            return (pageItem.ApplicationDate == pageItemEntity.ApplicationDate)
                        && (pageItem.CreateDate == pageItemEntity.CreateDate)
                        && (pageItem.JobId == pageItemEntity.JobId)
                        && string.Equals(pageItem.JobType, pageItemEntity.JobType, StringComparison.InvariantCulture)
                        && string.Equals(pageItem.PageItemId, pageItemEntity.PageItemId, StringComparison.InvariantCulture)
                        && (pageItem.PageItemNumber == pageItemEntity.PageItemNumber)
                        && (pageItem.PageNumber == pageItemEntity.PageNumber)
                        && string.Equals(pageItem.RunId, pageItemEntity.RunId, StringComparison.InvariantCulture)
                        && string.Equals(pageItem.Title, pageItemEntity.Title, StringComparison.InvariantCulture)
                        && string.Equals(pageItem.Url, pageItemEntity.Url, StringComparison.InvariantCulture)
                        && string.Equals(pageItem.WorkArea, pageItemEntity.WorkArea, StringComparison.InvariantCulture)
                        && string.Equals(pageItem.WorkAreaWithoutZone, pageItemEntity.WorkAreaWithoutZone, StringComparison.InvariantCulture)
                        && string.Equals(pageItem.WorkingHours, pageItemEntity.WorkingHours, StringComparison.InvariantCulture);

        }
        internal static bool AreEqual(PageItemExtended pageItemExtended, PageItemExtendedEntity pageItemExtendedEntity)
        {

            return (pageItemExtended.AdvertisementPublishDate == pageItemExtendedEntity.AdvertisementPublishDate)
                        && (pageItemExtended.ApplicationDeadline == pageItemExtendedEntity.ApplicationDeadline)
                        && string.Equals(pageItemExtended.Contact, pageItemExtendedEntity.Contact, StringComparison.InvariantCulture)
                        && string.Equals(pageItemExtended.Description, pageItemExtendedEntity.Description, StringComparison.InvariantCulture)
                        && string.Equals(pageItemExtended.DescriptionSeeCompleteTextAt, pageItemExtendedEntity.SeeCompleteTextAt, StringComparison.InvariantCulture)
                        && string.Equals(pageItemExtended.EmployerAddress, pageItemExtendedEntity.EmployerAddress, StringComparison.InvariantCulture)
                        && string.Equals(pageItemExtended.EmployerName, pageItemExtendedEntity.EmployerName, StringComparison.InvariantCulture)
                        && string.Equals(pageItemExtended.HowToApply, pageItemExtendedEntity.HowToApply, StringComparison.InvariantCulture)
                        && (pageItemExtended.NumberOfOpenings == pageItemExtendedEntity.NumberOfOpenings)
                        && string.Equals(pageItemExtended.PageItem.PageItemId, pageItemExtendedEntity.PageItemId, StringComparison.InvariantCulture)
                        && string.Equals(pageItemExtended.Position, pageItemExtendedEntity.Position, StringComparison.InvariantCulture)
                        && string.Equals(pageItemExtended.Reference, pageItemExtendedEntity.Reference, StringComparison.InvariantCulture)
                        && string.Equals(pageItemExtended.StartDateOfEmployment, pageItemExtendedEntity.StartDateOfEmployment, StringComparison.InvariantCulture);

        }

        internal static PageItem SwapCreateDate(PageItem pageItem, DateTime createDate)
        {

            return new PageItem(
                     runId: pageItem.RunId,
                     pageNumber: pageItem.PageNumber,
                     url: pageItem.Url,
                     title: pageItem.Title,
                     createDate: createDate,
                     applicationDate: pageItem.ApplicationDate,
                     workArea: pageItem.WorkArea,
                     workAreaWithoutZone: pageItem.WorkAreaWithoutZone,
                     workingHours: pageItem.WorkingHours,
                     jobType: pageItem.JobType,
                     jobId: pageItem.JobId,
                     pageItemNumber: pageItem.PageItemNumber,
                     pageItemId: pageItem.PageItemId
                );

        }
        internal static PageItem SwapTitlePageItemId(PageItem pageItem, string title, string pageItemId)
        {

            return new PageItem(
                     runId: pageItem.RunId,
                     pageNumber: pageItem.PageNumber,
                     url: pageItem.Url,
                     title: title,
                     createDate: pageItem.CreateDate,
                     applicationDate: pageItem.ApplicationDate,
                     workArea: pageItem.WorkArea,
                     workAreaWithoutZone: pageItem.WorkAreaWithoutZone,
                     workingHours: pageItem.WorkingHours,
                     jobType: pageItem.JobType,
                     jobId: pageItem.JobId,
                     pageItemNumber: pageItem.PageItemNumber,
                     pageItemId: pageItemId
                );

        }
        internal static List<PageItem> SwapFirstPageItem(List<PageItem> pageItems, PageItem pageItem)
        {

            List<PageItem> newPageItems = new List<PageItem>();
            newPageItems.Add(pageItem);
            newPageItems.AddRange(pageItems.Where(item => item.PageItemNumber > 1));

            return newPageItems;

        }
        internal static PageItemExtended CreateDummyPageItemExtended(PageItem pageItem)
        {

            return new PageItemExtended(
                        pageItem: pageItem,
                        description: Shared_Page01_PageItemExtended01.Description,
                        seeCompleteTextAt: Shared_Page01_PageItemExtended01.DescriptionSeeCompleteTextAt,
                        bulletPoints: Shared_Page01_PageItemExtended01.DescriptionBulletPoints,
                        employerName: Shared_Page01_PageItemExtended01.EmployerName,
                        numberOfOpenings: Shared_Page01_PageItemExtended01.NumberOfOpenings,
                        advertisementPublishDate: Shared_Page01_PageItemExtended01.AdvertisementPublishDate,
                        applicationDeadline: Shared_Page01_PageItemExtended01.ApplicationDeadline,
                        startDateOfEmployment: Shared_Page01_PageItemExtended01.StartDateOfEmployment,
                        reference: Shared_Page01_PageItemExtended01.Reference,
                        position: Shared_Page01_PageItemExtended01.Position,
                        typeOfEmployment: Shared_Page01_PageItemExtended01.TypeOfEmployment,
                        contact: Shared_Page01_PageItemExtended01.Contact,
                        employerAddress: Shared_Page01_PageItemExtended01.EmployerAddress,
                        howToApply: Shared_Page01_PageItemExtended01.HowToApply
                );

        }

        internal static T CallPrivateMethod<T, U>(string methodName, object[] args)
        {

            Type type = typeof(U);
            WIDMetricsManager obj = new WIDMetricsManager();

            return (T)type.GetTypeInfo().GetDeclaredMethod(methodName).Invoke(obj, args);

        }

        #endregion

    }
}

/*
    Author: numbworks@gmail.com
    Last Update: 30.05.2021
*/