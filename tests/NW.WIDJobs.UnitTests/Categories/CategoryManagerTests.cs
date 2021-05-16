using NUnit.Framework;

namespace NW.WIDJobs.UnitTests
{
    [TestFixture]
    public class CategoryManagerTests
    {

        // Fields
        private static TestCaseData[] getCategoryTokenTestCases =
        {

            new TestCaseData(
                    Categories.NotSpecified,
                    "Not%20specified"
                ).SetArgDisplayNames($"{nameof(getCategoryTokenTestCases)}_01"),

            new TestCaseData(
                    Categories.Management,
                    "Management"
                ).SetArgDisplayNames($"{nameof(getCategoryTokenTestCases)}_02"),

            new TestCaseData(
                    Categories.ResearchEducation,
                    "Research/Education"
                ).SetArgDisplayNames($"{nameof(getCategoryTokenTestCases)}_03"),

            new TestCaseData(
                    Categories.ItTech,
                    "It/Tech"
                ).SetArgDisplayNames($"{nameof(getCategoryTokenTestCases)}_04"),

            new TestCaseData(
                    Categories.Engineering,
                    "Engineering"
                ).SetArgDisplayNames($"{nameof(getCategoryTokenTestCases)}_05"),

            new TestCaseData(
                    Categories.StudentGraduate,
                    "Student/Graduate"
                ).SetArgDisplayNames($"{nameof(getCategoryTokenTestCases)}_06"),

            new TestCaseData(
                    Categories.BusinessMarketing,
                    "Business/Marketing"
                ).SetArgDisplayNames($"{nameof(getCategoryTokenTestCases)}_07"),

            new TestCaseData(
                    Categories.Consulting,
                    "Consulting"
                ).SetArgDisplayNames($"{nameof(getCategoryTokenTestCases)}_08"),

            new TestCaseData(
                    Categories.Others,
                    "Others"
                ).SetArgDisplayNames($"{nameof(getCategoryTokenTestCases)}_09"),

            new TestCaseData(
                    Categories.FinanceEconomics,
                    "Finance/Economics"
                ).SetArgDisplayNames($"{nameof(getCategoryTokenTestCases)}_10"),

            new TestCaseData(
                    Categories.FoodRestaurant,
                    "Food/Restaurant"
                ).SetArgDisplayNames($"{nameof(getCategoryTokenTestCases)}_11"),

            new TestCaseData(
                    Categories.HealthMedical,
                    "Health/Medical"
                ).SetArgDisplayNames($"{nameof(getCategoryTokenTestCases)}_12"),

            new TestCaseData(
                    Categories.Analysis,
                    "Analysis"
                ).SetArgDisplayNames($"{nameof(getCategoryTokenTestCases)}_13"),

            new TestCaseData(
                    Categories.Quality,
                    "Quality"
                ).SetArgDisplayNames($"{nameof(getCategoryTokenTestCases)}_14"),

            new TestCaseData(
                    Categories.BiologyChemistry,
                    "Biology/Chemistry"
                ).SetArgDisplayNames($"{nameof(getCategoryTokenTestCases)}_15"),

            new TestCaseData(
                    Categories.Support,
                    "Support"
                ).SetArgDisplayNames($"{nameof(getCategoryTokenTestCases)}_16"),

            new TestCaseData(
                    Categories.TransportationLogistics,
                    "Transportation/Logistics"
                ).SetArgDisplayNames($"{nameof(getCategoryTokenTestCases)}_17"),

            new TestCaseData(
                    Categories.Design,
                    "Design"
                ).SetArgDisplayNames($"{nameof(getCategoryTokenTestCases)}_18"),

            new TestCaseData(
                    Categories.Cleaning,
                    "Cleaning"
                ).SetArgDisplayNames($"{nameof(getCategoryTokenTestCases)}_19"),

            new TestCaseData(
                    Categories.SafetySecurity,
                    "Safety/Security"
                ).SetArgDisplayNames($"{nameof(getCategoryTokenTestCases)}_20"),

            new TestCaseData(
                    Categories.Communication,
                    "Communication"
                ).SetArgDisplayNames($"{nameof(getCategoryTokenTestCases)}_21"),

            new TestCaseData(
                    Categories.Legal,
                    "Legal"
                ).SetArgDisplayNames($"{nameof(getCategoryTokenTestCases)}_22"),

            new TestCaseData(
                    Categories.HR,
                    "HR"
                ).SetArgDisplayNames($"{nameof(getCategoryTokenTestCases)}_23"),


        };

        // SetUp
        // Tests
        [TestCaseSource(nameof(getCategoryTokenTestCases))]
        public void GetCategoryToken_ShouldReturnExpectedToken_WhenInvoked
            (Categories category, string expected)
        {

            // Arrange
            // Act
            string actual = new CategoryManager().GetCategoryToken(category);

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