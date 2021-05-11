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