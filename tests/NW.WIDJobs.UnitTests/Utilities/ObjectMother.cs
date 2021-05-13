using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using NSubstitute;
using System.Globalization;

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
        internal static PageItemExtended WorkInDenmark_Page1_PageItemExtended14 = new PageItemExtended(

            pageItem: WorkInDenmark_Page1_PageItem14,
            description: "Apply now »  Lean Professional DK, Lem | Professional | Full-Time | ID: 14167Are you a role model for continuous improvement and business change? If you’ve got motivation for Lean and Continuous Improvement Culture and are a communicator at all levels, then this is the role for you! Manufacturing & Global Procurement > Blades > Continuous ImprovementVestas Blades Launch & Execution center (BLEC) is a function within the Blades Organisation within Vestas Manufacturing. The function is responsible for delivering our manufacturing production design, inducing special projects, development of process and tooling for the blades in Vestas. In Continuous Improvement (CI), we are responsible for developing and implementing the Vestas Toolbox towards internal and external blade manufacturers. You will take part in developing and deploying continuous improvement activities towards new product projects as well as into our exiting toolbox.You will be working in a multicultural organisati...",
            seeCompleteTextAt: "https://careers.vestas.com/job/Lem-Lean-Professional-6940/672167601/",
            bulletPoints: new HashSet<string>{},
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
        internal static PageItemExtended WorkInDenmark_Page2_PageItemExtended18 = new PageItemExtended(

            pageItem: WorkInDenmark_Page2_PageItem18,
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

        internal static PageItem WorkInDenmark_Page4PageItem14 = new PageItem(
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
        internal static PageItemExtended WorkInDenmark_Page4PageItemExtended14 = new PageItemExtended(

            pageItem: WorkInDenmark_Page4PageItem14,
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

        internal static PageItem WorkInDenmark_Page4PageItem15 = new PageItem(
                 runId: "fake_runid",
                 pageNumber: 4,
                 url: "https://www.workindenmark.dk/job/5339216/Embedded-Software-Developer-for-Medical-Device-Development",
                 title: "Embedded Software Developer for Medical Device Development",
                 createDate: new DateTime(2021, 05, 06),
                 applicationDate: new DateTime(2021, 07, 01),
                 workArea: "Herlev",
                 workAreaWithoutZone: "Herlev",
                 workingHours: "Full time (37 hours)",
                 jobType: "Regular position",
                 jobId: 5339196,
                 pageItemNumber: 15,
                 pageItemId: "5339216embeddedsoftwaredeveloperformedicaldevicedevelopment"
              );
        internal static PageItemExtended WorkInDenmark_Page4PageItemExtended15 = new PageItemExtended(

            pageItem: WorkInDenmark_Page4PageItem15,
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
            startDateOfEmployment: null,
            reference: null,
            position: "",
            typeOfEmployment: "Regular position",
            contact: "Team Manager - Life Science Mette Meincke Phone: +45 26 77 70 83 Mobile: +45 26 77 70 83",
            employerAddress: "PREVAS A/S Lyskær 3 DK 2730 Herlev Denmark",
            howToApply: "Online: Application form"

        );

        internal static PageItem WorkInDenmark_Page4PageItem19 = new PageItem(
                 runId: "fake_runid",
                 pageNumber: 4,
                 url: "https://www.workindenmark.dk/job/5339811/Warehouse-Team-Lead",
                 title: "Warehouse Team Lead",
                 createDate: new DateTime(2021, 05, 07),
                 applicationDate: new DateTime(2021, 07, 02),
                 workArea: "Greve",
                 workAreaWithoutZone: "Greve",
                 workingHours: "Full time (37 hours)",
                 jobType: "Regular position",
                 jobId: 5339811,
                 pageItemNumber: 19,
                 pageItemId: "5339811warehouseteamlead"
              );
        internal static PageItemExtended WorkInDenmark_Page4PageItemExtended19 = new PageItemExtended(

                    pageItem: WorkInDenmark_Page4PageItem19,
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
                    startDateOfEmployment: null,
                    reference: null,
                    position: "Transport / Warehouse and logistics operatives",
                    typeOfEmployment: "Regular position",
                    contact: "Workforce Coordinator Jan Lacjak",
                    employerAddress: "Hobbii A/S Kildebrøndevej 42 DK 2670 Greve Denmark",
                    howToApply: "Online: Application form"

                );

        internal static PageItem WorkInDenmark_Page5PageItem1 = new PageItem(
                 runId: "fake_runid",
                 pageNumber: 5,
                 url: "https://www.workindenmark.dk/job/5340215/NVH-Test-Engineer",
                 title: "NVH Test Engineer",
                 createDate: new DateTime(2021, 05, 07),
                 applicationDate: new DateTime(2021, 06, 07),
                 workArea: "Middelfart",
                 workAreaWithoutZone: "Middelfart",
                 workingHours: "Full time (37 hours)",
                 jobType: "Regular position",
                 jobId: 5340215,
                 pageItemNumber: 1,
                 pageItemId: "5340215nvhtestengineer"
              );
        internal static PageItemExtended WorkInDenmark_Page5PageItemExtended1 = new PageItemExtended(

                    pageItem: WorkInDenmark_Page5PageItem1,
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
                    startDateOfEmployment: null,
                    reference: null,
                    position: "Academical work / Engineering professionals",
                    typeOfEmployment: "Regular position",
                    contact: "Global Test Centre Manager Christian Berg Philipp",
                    employerAddress: "DINEX A/S Fynsvej 39 DK 5500 Middelfart Denmark",
                    howToApply: "Online: Application form"

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
                        && (pageItemExtended1.DescriptionBulletPoints == pageItemExtended2.DescriptionBulletPoints)
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

    }
}

/*
    Author: numbworks@gmail.com
    Last Update: 13.05.2021
*/