using NUnit.Framework;

namespace NW.WIDJobs.UnitTests
{
    [TestFixture]
    public class WIDCategoryManagerTests
    {

        // Fields
        private static TestCaseData[] getCategoryTokenTestCases =
        {

            new TestCaseData(
                    WIDCategories.NotSpecified,
                    "Not%20specified"
                ).SetArgDisplayNames($"{nameof(getCategoryTokenTestCases)}_01"),

            new TestCaseData(
                    WIDCategories.Management,
                    "Management"
                ).SetArgDisplayNames($"{nameof(getCategoryTokenTestCases)}_02"),

            new TestCaseData(
                    WIDCategories.ResearchEducation,
                    "Research/Education"
                ).SetArgDisplayNames($"{nameof(getCategoryTokenTestCases)}_03"),

            new TestCaseData(
                    WIDCategories.ItTech,
                    "It/Tech"
                ).SetArgDisplayNames($"{nameof(getCategoryTokenTestCases)}_04"),

            new TestCaseData(
                    WIDCategories.Engineering,
                    "Engineering"
                ).SetArgDisplayNames($"{nameof(getCategoryTokenTestCases)}_05"),

            new TestCaseData(
                    WIDCategories.StudentGraduate,
                    "Student/Graduate"
                ).SetArgDisplayNames($"{nameof(getCategoryTokenTestCases)}_06"),

            new TestCaseData(
                    WIDCategories.BusinessMarketing,
                    "Business/Marketing"
                ).SetArgDisplayNames($"{nameof(getCategoryTokenTestCases)}_07"),

            new TestCaseData(
                    WIDCategories.Consulting,
                    "Consulting"
                ).SetArgDisplayNames($"{nameof(getCategoryTokenTestCases)}_08"),

            new TestCaseData(
                    WIDCategories.Others,
                    "Others"
                ).SetArgDisplayNames($"{nameof(getCategoryTokenTestCases)}_09"),

            new TestCaseData(
                    WIDCategories.FinanceEconomics,
                    "Finance/Economics"
                ).SetArgDisplayNames($"{nameof(getCategoryTokenTestCases)}_10"),

            new TestCaseData(
                    WIDCategories.FoodRestaurant,
                    "Food/Restaurant"
                ).SetArgDisplayNames($"{nameof(getCategoryTokenTestCases)}_11"),

            new TestCaseData(
                    WIDCategories.HealthMedical,
                    "Health/Medical"
                ).SetArgDisplayNames($"{nameof(getCategoryTokenTestCases)}_12"),

            new TestCaseData(
                    WIDCategories.Analysis,
                    "Analysis"
                ).SetArgDisplayNames($"{nameof(getCategoryTokenTestCases)}_13"),

            new TestCaseData(
                    WIDCategories.Quality,
                    "Quality"
                ).SetArgDisplayNames($"{nameof(getCategoryTokenTestCases)}_14"),

            new TestCaseData(
                    WIDCategories.BiologyChemistry,
                    "Biology/Chemistry"
                ).SetArgDisplayNames($"{nameof(getCategoryTokenTestCases)}_15"),

            new TestCaseData(
                    WIDCategories.Support,
                    "Support"
                ).SetArgDisplayNames($"{nameof(getCategoryTokenTestCases)}_16"),

            new TestCaseData(
                    WIDCategories.TransportationLogistics,
                    "Transportation/Logistics"
                ).SetArgDisplayNames($"{nameof(getCategoryTokenTestCases)}_17"),

            new TestCaseData(
                    WIDCategories.Design,
                    "Design"
                ).SetArgDisplayNames($"{nameof(getCategoryTokenTestCases)}_18"),

            new TestCaseData(
                    WIDCategories.Cleaning,
                    "Cleaning"
                ).SetArgDisplayNames($"{nameof(getCategoryTokenTestCases)}_19"),

            new TestCaseData(
                    WIDCategories.SafetySecurity,
                    "Safety/Security"
                ).SetArgDisplayNames($"{nameof(getCategoryTokenTestCases)}_20"),

            new TestCaseData(
                    WIDCategories.Communication,
                    "Communication"
                ).SetArgDisplayNames($"{nameof(getCategoryTokenTestCases)}_21"),

            new TestCaseData(
                    WIDCategories.Legal,
                    "Legal"
                ).SetArgDisplayNames($"{nameof(getCategoryTokenTestCases)}_22"),

            new TestCaseData(
                    WIDCategories.HR,
                    "HR"
                ).SetArgDisplayNames($"{nameof(getCategoryTokenTestCases)}_23"),

            new TestCaseData(
                    WIDCategories.AllCategories,
                    "AllCategories"
                ).SetArgDisplayNames($"{nameof(getCategoryTokenTestCases)}_24")

        };

        // SetUp
        // Tests
        [TestCaseSource(nameof(getCategoryTokenTestCases))]
        public void GetCategoryToken_ShouldReturnExpectedToken_WhenInvoked
            (WIDCategories category, string expected)
        {

            // Arrange
            // Act
            string actual = new WIDCategoryManager().GetCategoryToken(category);

            // Assert
            Assert.AreEqual(expected, actual);

        }

        // TearDown

    }
}

/*
    Author: numbworks@gmail.com
    Last Update: 16.05.2021
*/