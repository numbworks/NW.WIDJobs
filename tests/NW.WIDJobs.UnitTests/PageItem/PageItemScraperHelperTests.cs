using NUnit.Framework;
using System;

namespace NW.WIDJobs.UnitTests
{
    [TestFixture]
    public class PageItemScraperHelperTests
    {

        // Fields
        private static TestCaseData[] convertToAbsoluteUrlTestCases =
        {

            new TestCaseData(
                    "/job/8148174/Technology-Finance-Business-Partner",
                    "https://www.workindenmark.dk/job/8148174/Technology-Finance-Business-Partner"
                ).SetArgDisplayNames($"{nameof(convertToAbsoluteUrlTestCases)}_01")

        };
        private static TestCaseData[] convertToAbsoluteUrlExceptionTestCases =
        {

            new TestCaseData(
                new TestDelegate(
                    () => new PageItemScraperHelper().ConvertToAbsoluteUrl(null)
                ),
                typeof(ArgumentNullException),
                new ArgumentNullException("relativeUrl").Message
            ).SetArgDisplayNames($"{nameof(convertToAbsoluteUrlExceptionTestCases)}_01")

        };

        private static TestCaseData[] cleanWorkAreaTestCases =
        {

            new TestCaseData(
                    "Work area: København K",
                    "København K"
                ).SetArgDisplayNames($"{nameof(cleanWorkAreaTestCases)}_01")

        };
        private static TestCaseData[] cleanWorkAreaExceptionTestCases =
        {

            new TestCaseData(
                new TestDelegate(
                    () => new PageItemScraperHelper().CleanWorkArea(null)
                ),
                typeof(ArgumentNullException),
                new ArgumentNullException("workArea").Message
            ).SetArgDisplayNames($"{nameof(cleanWorkAreaExceptionTestCases)}_01")

        };

        private static TestCaseData[] cleanWorkingHoursTestCases =
        {

            new TestCaseData(
                    "Working hours: Full time (37 hours)",
                    "Full time (37 hours)"
                ).SetArgDisplayNames($"{nameof(cleanWorkingHoursTestCases)}_01")

        };
        private static TestCaseData[] cleanWorkingHoursExceptionTestCases =
        {

            new TestCaseData(
                new TestDelegate(
                    () => new PageItemScraperHelper().CleanWorkingHours(null)
                ),
                typeof(ArgumentNullException),
                new ArgumentNullException("workingHours").Message
            ).SetArgDisplayNames($"{nameof(cleanWorkingHoursExceptionTestCases)}_01")

        };

        private static TestCaseData[] cleanJobTypeTestCases =
        {

            new TestCaseData(
                    "Job type: Limited period",
                    "Limited period"
                ).SetArgDisplayNames($"{nameof(cleanJobTypeTestCases)}_01")

        };
        private static TestCaseData[] cleanJobTypeExceptionTestCases =
        {

            new TestCaseData(
                new TestDelegate(
                    () => new PageItemScraperHelper().CleanJobType(null)
                ),
                typeof(ArgumentNullException),
                new ArgumentNullException("jobType").Message
            ).SetArgDisplayNames($"{nameof(cleanJobTypeExceptionTestCases)}_01")

        };

        private static TestCaseData[] createWorkAreaWithoutZoneTestCases =
        {

            new TestCaseData(
                    "København K",
                    "København"
                ).SetArgDisplayNames($"{nameof(createWorkAreaWithoutZoneTestCases)}_01"),

            new TestCaseData(
                    "Kgs. Lyngby",
                    "Kgs. Lyngby"
                ).SetArgDisplayNames($"{nameof(createWorkAreaWithoutZoneTestCases)}_02"),

            new TestCaseData(
                    "København V",
                    "København"
                ).SetArgDisplayNames($"{nameof(createWorkAreaWithoutZoneTestCases)}_03"),

            new TestCaseData(
                    "København Ø",
                    "København"
                ).SetArgDisplayNames($"{nameof(createWorkAreaWithoutZoneTestCases)}_04"),

            new TestCaseData(
                    "København S",
                    "København"
                ).SetArgDisplayNames($"{nameof(createWorkAreaWithoutZoneTestCases)}_05"),

            new TestCaseData(
                    "Aarhus C",
                    "Aarhus"
                ).SetArgDisplayNames($"{nameof(createWorkAreaWithoutZoneTestCases)}_06"),

            new TestCaseData(
                    "Viby J",
                    "Viby"
                ).SetArgDisplayNames($"{nameof(createWorkAreaWithoutZoneTestCases)}_07"),

            new TestCaseData(
                    "Odense S",
                    "Odense"
                ).SetArgDisplayNames($"{nameof(createWorkAreaWithoutZoneTestCases)}_08"),

            new TestCaseData(
                    "Kongens Lyngby",
                    "Kongens Lyngby"
                ).SetArgDisplayNames($"{nameof(createWorkAreaWithoutZoneTestCases)}_09"),

            new TestCaseData(
                    "Billund",
                    "Billund"
                ).SetArgDisplayNames($"{nameof(createWorkAreaWithoutZoneTestCases)}_10"),

            new TestCaseData(
                    "København SV",
                    "København"
                ).SetArgDisplayNames($"{nameof(createWorkAreaWithoutZoneTestCases)}_11"),

            new TestCaseData(
                    "Esbjerg V",
                    "Esbjerg"
                ).SetArgDisplayNames($"{nameof(createWorkAreaWithoutZoneTestCases)}_12"),

            new TestCaseData(
                    "Odense SØ",
                    "Odense"
                ).SetArgDisplayNames($"{nameof(createWorkAreaWithoutZoneTestCases)}_13"),

            new TestCaseData(
                    "Lem St",
                    "Lem"
                ).SetArgDisplayNames($"{nameof(createWorkAreaWithoutZoneTestCases)}_14")

        };
        private static TestCaseData[] createWorkAreaWithoutZoneExceptionTestCases =
        {

            new TestCaseData(
                new TestDelegate(
                    () => new PageItemScraperHelper().CreateWorkAreaWithoutZone(null)
                ),
                typeof(ArgumentNullException),
                new ArgumentNullException("workArea").Message
            ).SetArgDisplayNames($"{nameof(createWorkAreaWithoutZoneExceptionTestCases)}_01")

        };

        private static TestCaseData[] extractJobIdTestCases =
        {

            new TestCaseData(
                    "https://www.workindenmark.dk/job/8148174/Technology-Finance-Business-Partner",
                    "8148174"
                ).SetArgDisplayNames($"{nameof(extractJobIdTestCases)}_01")

        };
        private static TestCaseData[] extractJobIdExceptionTestCases =
        {

            new TestCaseData(
                new TestDelegate(
                    () => new PageItemScraperHelper().ExtractJobId(null)
                ),
                typeof(ArgumentNullException),
                new ArgumentNullException("url").Message
            ).SetArgDisplayNames($"{nameof(extractJobIdExceptionTestCases)}_01")

        };

        private static TestCaseData[] createPageItemIdTestCases =
        {

            new TestCaseData(
                    (uint)8144089,
                    "Business Support & Pricing Manager" ,
                    "8144089businesssupportpricingmanager"
                ).SetArgDisplayNames($"{nameof(createPageItemIdTestCases)}_01"),

            new TestCaseData(
                    (uint)8180759,
                    "Technical Officer, GOARN, Copenhagen, DenmarkOrganization: World Health Organization",
                    "8180759technicalofficergoarncopenhagendenmarkorganization"
                ).SetArgDisplayNames($"{nameof(createPageItemIdTestCases)}_02")

        };
        private static TestCaseData[] createPageItemIdExceptionTestCases =
        {

            new TestCaseData(
                new TestDelegate(
                    () => new PageItemScraperHelper().CreatePageItemId(8144089, null)
                ),
                typeof(ArgumentNullException),
                new ArgumentNullException("title").Message
            ).SetArgDisplayNames($"{nameof(createPageItemIdExceptionTestCases)}_01")

        };

        // SetUp
        // Tests
        [TestCaseSource(nameof(convertToAbsoluteUrlTestCases))]
        public void ConvertToAbsoluteUrl_ShouldReturnExpectedString_WhenProperArgument
            (string relativeUrl, string expected)
        {

            // Arrange
            // Act
            string actual = new PageItemScraperHelper().ConvertToAbsoluteUrl(relativeUrl);

            // Assert
            Assert.AreEqual(expected, actual);

        }
        [TestCaseSource(nameof(convertToAbsoluteUrlExceptionTestCases))]
        public void ConvertToAbsoluteUrl_ShouldThrowACertainException_WhenUnproperArguments
            (TestDelegate del, Type expectedType, string expectedMessage)
                => ObjectMother.Method_ShouldThrowACertainException_WhenUnproperArguments(del, expectedType, expectedMessage);

        [TestCaseSource(nameof(cleanWorkAreaTestCases))]
        public void CleanWorkArea_ShouldReturnExpectedString_WhenProperArgument
            (string workArea, string expected)
        {

            // Arrange
            // Act
            string actual = new PageItemScraperHelper().CleanWorkArea(workArea);

            // Assert
            Assert.AreEqual(expected, actual);

        }
        [TestCaseSource(nameof(cleanWorkAreaExceptionTestCases))]
        public void CleanWorkArea_ShouldThrowACertainException_WhenUnproperArguments
            (TestDelegate del, Type expectedType, string expectedMessage)
                => ObjectMother.Method_ShouldThrowACertainException_WhenUnproperArguments(del, expectedType, expectedMessage);

        [TestCaseSource(nameof(cleanWorkingHoursTestCases))]
        public void CleanWorkingHours_ShouldReturnExpectedString_WhenProperArgument
            (string workingHours, string expected)
        {

            // Arrange
            // Act
            string actual = new PageItemScraperHelper().CleanWorkingHours(workingHours);

            // Assert
            Assert.AreEqual(expected, actual);

        }
        [TestCaseSource(nameof(cleanWorkingHoursExceptionTestCases))]
        public void CleanWorkingHours_ShouldThrowACertainException_WhenUnproperArguments
            (TestDelegate del, Type expectedType, string expectedMessage)
                => ObjectMother.Method_ShouldThrowACertainException_WhenUnproperArguments(del, expectedType, expectedMessage);

        [TestCaseSource(nameof(cleanJobTypeTestCases))]
        public void CleanJobType_ShouldReturnExpectedString_WhenProperArgument
            (string jobType, string expected)
        {

            // Arrange
            // Act
            string actual = new PageItemScraperHelper().CleanJobType(jobType);

            // Assert
            Assert.AreEqual(expected, actual);

        }
        [TestCaseSource(nameof(cleanJobTypeExceptionTestCases))]
        public void CleanJobType_ShouldThrowACertainException_WhenUnproperArguments
            (TestDelegate del, Type expectedType, string expectedMessage)
                => ObjectMother.Method_ShouldThrowACertainException_WhenUnproperArguments(del, expectedType, expectedMessage);

        [TestCaseSource(nameof(createWorkAreaWithoutZoneTestCases))]
        public void CreateWorkAreaWithoutZone_ShouldReturnExpectedString_WhenProperArgument
            (string workArea, string expected)
        {

            // Arrange
            // Act
            string actual = new PageItemScraperHelper().CreateWorkAreaWithoutZone(workArea);

            // Assert
            Assert.AreEqual(expected, actual);

        }
        [TestCaseSource(nameof(createWorkAreaWithoutZoneExceptionTestCases))]
        public void CreateWorkAreaWithoutZone_ShouldThrowACertainException_WhenUnproperArguments
            (TestDelegate del, Type expectedType, string expectedMessage)
                => ObjectMother.Method_ShouldThrowACertainException_WhenUnproperArguments(del, expectedType, expectedMessage);

        [TestCaseSource(nameof(extractJobIdTestCases))]
        public void ExtractJobId_ShouldReturnExpectedString_WhenProperArgument
            (string url, string expected)
        {

            // Arrange
            // Act
            string actual = new PageItemScraperHelper().ExtractJobId(url);

            // Assert
            Assert.AreEqual(expected, actual);

        }
        [TestCaseSource(nameof(extractJobIdExceptionTestCases))]
        public void ExtractJobId_ShouldThrowACertainException_WhenUnproperArguments
            (TestDelegate del, Type expectedType, string expectedMessage)
                => ObjectMother.Method_ShouldThrowACertainException_WhenUnproperArguments(del, expectedType, expectedMessage);

        [TestCaseSource(nameof(createPageItemIdTestCases))]
        public void CreatePageItemId_ShouldReturnExpectedString_WhenProperArgument
            (ulong jobId, string title, string expected)
        {

            // Arrange
            // Act
            string actual = new PageItemScraperHelper().CreatePageItemId(jobId, title);

            // Assert
            Assert.AreEqual(expected, actual);

        }
        [TestCaseSource(nameof(createPageItemIdExceptionTestCases))]
        public void CreatePageItemId_ShouldThrowACertainException_WhenUnproperArguments
            (TestDelegate del, Type expectedType, string expectedMessage)
                => ObjectMother.Method_ShouldThrowACertainException_WhenUnproperArguments(del, expectedType, expectedMessage);

        // TearDown		

    }
}

/*
    Author: numbworks@gmail.com
    Last Update: 10.06.2021
*/