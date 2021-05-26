using System.ComponentModel;

namespace NW.WIDJobs
{
    /// <summary>Categories of <see cref="PageItem"/> to include in the exploration.</summary>
    public enum WIDCategories
    {
        AllCategories,
        [Description("Not%20specified")] NotSpecified,
        Management,
        [Description("Research/Education")] ResearchEducation,
        [Description("It/Tech")] ItTech,
        Engineering,
        [Description("Student/Graduate")] StudentGraduate,
        [Description("Business/Marketing")] BusinessMarketing,
        Consulting,
        Others,
        [Description("Finance/Economics")] FinanceEconomics,
        [Description("Food/Restaurant")] FoodRestaurant,
        [Description("Health/Medical")] HealthMedical,
        Analysis,
        Quality,
        [Description("Biology/Chemistry")] BiologyChemistry,
        Support,
        [Description("Transportation/Logistics")] TransportationLogistics,
        Design,
        Cleaning,
        [Description("Safety/Security")] SafetySecurity,
        Communication,
        Legal,
        HR
    }
}

/*
    Author: numbworks@gmail.com
    Last Update: 19.05.2021
*/