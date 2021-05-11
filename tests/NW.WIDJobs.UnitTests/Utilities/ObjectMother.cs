using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using NSubstitute;

namespace NW.WIDJobs.UnitTests
{
    public static class ObjectMother
    {

        // ValidatorTests
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

        // PageItemScraperTests ?
        internal static Func<IGetRequestManager> PageItemScraper_FuncEmptyHTML
            = new Func<IGetRequestManager>(() =>
            {
                IGetRequestManager fakeGetRequest = Substitute.For<IGetRequestManager>();
                fakeGetRequest.Send(Arg.Any<string>()).Returns("<html></<html>");
                return fakeGetRequest;
            });

        // PageItemScraperTests
        #region

        internal static PageItem WorkInDenmark_Page1_PageItem01 = new PageItem(
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
        internal static PageItem WorkInDenmark_Page1_PageItem02 = new PageItem(
                 runId: "fake_runId",
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
        internal static PageItem WorkInDenmark_Page1_PageItem03 = new PageItem(
                 runId: "fake_runId",
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
        internal static PageItem WorkInDenmark_Page1_PageItem04 = new PageItem(
                 runId: "fake_runId",
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
        internal static PageItem WorkInDenmark_Page1_PageItem05 = new PageItem(
                 runId: "fake_runId",
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
        internal static PageItem WorkInDenmark_Page1_PageItem06 = new PageItem(
                 runId: "fake_runId",
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
        internal static PageItem WorkInDenmark_Page1_PageItem07 = new PageItem(
                 runId: "fake_runId",
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
        internal static PageItem WorkInDenmark_Page1_PageItem08 = new PageItem(
                 runId: "fake_runId",
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
        internal static PageItem WorkInDenmark_Page1_PageItem09 = new PageItem(
                 runId: "fake_runId",
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
        internal static PageItem WorkInDenmark_Page1_PageItem10 = new PageItem(
                 runId: "fake_runId",
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
        internal static PageItem WorkInDenmark_Page1_PageItem11 = new PageItem(
                 runId: "fake_runId",
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
        internal static PageItem WorkInDenmark_Page1_PageItem12 = new PageItem(
                 runId: "fake_runId",
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
        internal static PageItem WorkInDenmark_Page1_PageItem13 = new PageItem(
                 runId: "fake_runId",
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
        internal static PageItem WorkInDenmark_Page1_PageItem14 = new PageItem(
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
        internal static PageItem WorkInDenmark_Page1_PageItem15 = new PageItem(
                 runId: "fake_runId",
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
        internal static PageItem WorkInDenmark_Page1_PageItem16 = new PageItem(
                 runId: "fake_runId",
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
                 pageItemId: "8144061seniormodelriskanalyststockholmcopenhagenorwarsaw"
              );
        internal static PageItem WorkInDenmark_Page1_PageItem17 = new PageItem(
                 runId: "fake_runId",
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
                 pageItemId: "8144054qualityassuranceandknowledgeteamlead"
              );
        internal static PageItem WorkInDenmark_Page1_PageItem18 = new PageItem(
                 runId: "fake_runId",
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
        internal static PageItem WorkInDenmark_Page1_PageItem19 = new PageItem(
                 runId: "fake_runId",
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
        internal static PageItem WorkInDenmark_Page1_PageItem20 = new PageItem(
                 runId: "fake_runId",
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
                 pageItemId: "8144023businessdevelopmentmanagerscrewdriverdispensermfd"
              );

        internal static PageItem WorkInDenmark_Page2_PageItem01 = new PageItem(
                 runId: "fake_runid",
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
        internal static PageItem WorkInDenmark_Page2_PageItem02 = new PageItem(
                 runId: "fake_runid",
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
        internal static PageItem WorkInDenmark_Page2_PageItem03 = new PageItem(
                 runId: "fake_runid",
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
        internal static PageItem WorkInDenmark_Page2_PageItem04 = new PageItem(
                 runId: "fake_runid",
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
        internal static PageItem WorkInDenmark_Page2_PageItem05 = new PageItem(
                 runId: "fake_runid",
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
        internal static PageItem WorkInDenmark_Page2_PageItem06 = new PageItem(
                 runId: "fake_runid",
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
        internal static PageItem WorkInDenmark_Page2_PageItem07 = new PageItem(
                 runId: "fake_runid",
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
        internal static PageItem WorkInDenmark_Page2_PageItem08 = new PageItem(
                 runId: "fake_runid",
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
                 pageItemId: "8141229managerforitbuildingdevicemanagement"
              );
        internal static PageItem WorkInDenmark_Page2_PageItem09 = new PageItem(
                 runId: "fake_runid",
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
                 pageItemId: "8141228cloudsolutionarchitectforglobalit"
              );
        internal static PageItem WorkInDenmark_Page2_PageItem10 = new PageItem(
                 runId: "fake_runid",
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
                 pageItemId: "8140198blivsalgstraineehosoutofhomemediaaps"
              );
        internal static PageItem WorkInDenmark_Page2_PageItem11 = new PageItem(
                 runId: "fake_runid",
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
        internal static PageItem WorkInDenmark_Page2_PageItem12 = new PageItem(
                 runId: "fake_runid",
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
                 pageItemId: "8144113seniorserialisationsapattpconsultantiodelivery"
              );
        internal static PageItem WorkInDenmark_Page2_PageItem13 = new PageItem(
                 runId: "fake_runid",
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
                 pageItemId: "8144112sdmproductowneriodelivery"
              );
        internal static PageItem WorkInDenmark_Page2_PageItem14 = new PageItem(
                 runId: "fake_runid",
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
        internal static PageItem WorkInDenmark_Page2_PageItem15 = new PageItem(
                 runId: "fake_runid",
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
        internal static PageItem WorkInDenmark_Page2_PageItem16 = new PageItem(
                 runId: "fake_runid",
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
        internal static PageItem WorkInDenmark_Page2_PageItem17 = new PageItem(
                 runId: "fake_runid",
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
        internal static PageItem WorkInDenmark_Page2_PageItem18 = new PageItem(
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
        internal static PageItem WorkInDenmark_Page2_PageItem19 = new PageItem(
                 runId: "fake_runid",
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
                 pageItemId: "8144104idadministrativeprojectmanagerfortheeuropeanhorizonprojectreflow"
              );
        internal static PageItem WorkInDenmark_Page2_PageItem20 = new PageItem(
                 runId: "fake_runid",
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

        #endregion

        // PageItemExtendedScraperTests
        #region

        internal static PageItemExtended WorkInDenmark_Page1_PageItemExtended01 = new PageItemExtended(

            pageItem: WorkInDenmark_Page1_PageItem01,
            description: "This website uses cookiesIf you choose to accept cookies, you agree that Talentech and third-parties store the cookies of your choice. If you don't consent, we only store the cookies necessary for functionality.Allow selection Allow all cookies NecessaryPreferencesStatisticsMarketing\t Show details Warning Your browser is outdated. Get the best experience with speed, security and privacy by using the latest version of Chrome, Firefox, Microsoft Edge, Safari or Opera ×  Learning sales – Fulltime Student PositionApply for this position if-\tYou want to learn and develop you sales skills-\tYou want to work in an rapidly expanding international company-\tYou want to make a difference for renewable energyIn KK Wind Solutions Service, we are looking for talented candidates to join our Spare Parts Sales Team. We are offering a fulltime student position, where you will be learning as well as performing.\u00A0So if you are looking for a year of lesser studying and an opportunity to start ...",
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

        #endregion

        // Methods
        internal static void Method_ShouldThrowACertainException_WhenUnproperArguments
            (TestDelegate del, Type expectedType, string expectedMessage)
        {

            // Arrange
            // Act
            // Assert
            Exception actual = Assert.Throws(expectedType, del);
            Assert.AreEqual(expectedMessage, actual.Message);

        }

        internal static List<PageItem> RemoveItems(List<PageItem> pageItems, int index, int count)
        {

            List<PageItem> result = new List<PageItem>(pageItems);
            result.RemoveRange(index, count);

            return result;

        }
        internal static bool AreEqual(PageItem pageItem1, PageItem pageItem2)
            => throw new NotImplementedException();

    }
}

/*
    Author: numbworks@gmail.com
    Last Update: 11.05.2021
*/