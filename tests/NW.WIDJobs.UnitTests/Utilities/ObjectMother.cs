using Microsoft.EntityFrameworkCore;
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

        #region WIDExplorationTests

        internal static string WIDExploration_Exploration01_RunId = RunIdManager_RunId_Now;
        internal static ushort WIDExploration_Exploration01_TotalResultCount = Shared_JobPage01_TotalResultCount;
        internal static ushort WIDExploration_Exploration01_TotalJobPages = Shared_JobPage01_TotalJobPages;
        internal static bool WIDExploration_Exploration01_IsCompleted = true;
        internal static List<JobPage> WIDExploration_Exploration01_JobPages = null;
        internal static List<JobPosting> WIDExploration_Exploration01_JobPostings = null;
        internal static List<JobPostingExtended> WIDExploration_Exploration01_JobPostingsExtended = null;
        internal static WIDExploration WIDExploration_Exploration01
            = new WIDExploration(
                    WIDExploration_Exploration01_RunId,
                    WIDExploration_Exploration01_TotalResultCount,
                    WIDExploration_Exploration01_TotalJobPages,
                    WIDExploration_Exploration01_IsCompleted,
                    WIDExploration_Exploration01_JobPages,
                    WIDExploration_Exploration01_JobPostings,
                    WIDExploration_Exploration01_JobPostingsExtended
                    );
        internal static string WIDExploration_Exploration01_ToString
            = string.Concat(
                "{ ",
                $"'{nameof(WIDExploration.RunId)}':'{WIDExploration_Exploration01_RunId}', ",
                $"'{nameof(WIDExploration.TotalResultCount)}':'{WIDExploration_Exploration01_TotalResultCount}', ",
                $"'{nameof(WIDExploration.TotalJobPages)}':'{WIDExploration_Exploration01_TotalJobPages}', ",
                $"'{nameof(WIDExploration.IsCompleted)}':'{WIDExploration_Exploration01_IsCompleted}', ",
                $"'{nameof(WIDExploration.JobPages)}':'null', ",
                $"'{nameof(WIDExploration.JobPostings)}':'null', ",
                $"'{nameof(WIDExploration.JobPostingsExtended)}':'null'",
                " }"
                );

        internal static string WIDExploration_Exploration02_RunId = RunIdManager_RunId_Now;
        internal static ushort WIDExploration_Exploration02_TotalResultCount = Shared_JobPage01_TotalResultCount;
        internal static ushort WIDExploration_Exploration02_TotalJobPages = Shared_JobPage01_TotalJobPages;
        internal static bool WIDExploration_Exploration02_IsCompleted = true;
        internal static List<JobPage> WIDExploration_Exploration02_JobPages
            = new List<JobPage>() 
            {
                Shared_JobPage01_Object,
                Shared_JobPage02_Object
            };
        internal static List<JobPosting> WIDExploration_Exploration02_JobPostings 
            = new List<JobPosting>()
            {
                Shared_JobPage01_JobPosting01,
                Shared_JobPage01_JobPosting02,
                Shared_JobPage01_JobPosting03,
                Shared_JobPage01_JobPosting04,
                Shared_JobPage01_JobPosting05,
                Shared_JobPage01_JobPosting06,
                Shared_JobPage01_JobPosting07,
                Shared_JobPage01_JobPosting08,
                Shared_JobPage01_JobPosting09,
                Shared_JobPage01_JobPosting10,
                Shared_JobPage01_JobPosting11,
                Shared_JobPage01_JobPosting12,
                Shared_JobPage01_JobPosting13,
                Shared_JobPage01_JobPosting14,
                Shared_JobPage01_JobPosting15,
                Shared_JobPage01_JobPosting16,
                Shared_JobPage01_JobPosting17,
                Shared_JobPage01_JobPosting18,
                Shared_JobPage01_JobPosting19,
                Shared_JobPage01_JobPosting20,
                Shared_JobPage02_JobPosting01,
                Shared_JobPage02_JobPosting02,
                Shared_JobPage02_JobPosting03,
                Shared_JobPage02_JobPosting04,
                Shared_JobPage02_JobPosting05,
                Shared_JobPage02_JobPosting06,
                Shared_JobPage02_JobPosting07,
                Shared_JobPage02_JobPosting08,
                Shared_JobPage02_JobPosting09,
                Shared_JobPage02_JobPosting10,
                Shared_JobPage02_JobPosting11,
                Shared_JobPage02_JobPosting12,
                Shared_JobPage02_JobPosting13,
                Shared_JobPage02_JobPosting14,
                Shared_JobPage02_JobPosting15,
                Shared_JobPage02_JobPosting16,
                Shared_JobPage02_JobPosting17,
                Shared_JobPage02_JobPosting18,
                Shared_JobPage02_JobPosting19,
                Shared_JobPage02_JobPosting20
            };
        internal static List<JobPostingExtended> WIDExploration_Exploration02_JobPostingsExtended
            = new List<JobPostingExtended>()
            {
                Shared_JobPage01_JobPostingExtended01,
                Shared_JobPage01_JobPostingExtended02,
                Shared_JobPage01_JobPostingExtended03,
                Shared_JobPage01_JobPostingExtended04,
                Shared_JobPage01_JobPostingExtended05,
                Shared_JobPage01_JobPostingExtended06,
                Shared_JobPage01_JobPostingExtended07,
                Shared_JobPage01_JobPostingExtended08,
                Shared_JobPage01_JobPostingExtended09,
                Shared_JobPage01_JobPostingExtended10,
                Shared_JobPage01_JobPostingExtended11,
                Shared_JobPage01_JobPostingExtended12,
                Shared_JobPage01_JobPostingExtended13,
                Shared_JobPage01_JobPostingExtended14,
                Shared_JobPage01_JobPostingExtended15,
                Shared_JobPage01_JobPostingExtended16,
                Shared_JobPage01_JobPostingExtended17,
                Shared_JobPage01_JobPostingExtended18,
                Shared_JobPage01_JobPostingExtended19,
                Shared_JobPage01_JobPostingExtended20,
                Shared_JobPage02_JobPostingExtended01,
                Shared_JobPage02_JobPostingExtended02,
                Shared_JobPage02_JobPostingExtended03,
                Shared_JobPage02_JobPostingExtended04,
                Shared_JobPage02_JobPostingExtended05,
                Shared_JobPage02_JobPostingExtended06,
                Shared_JobPage02_JobPostingExtended07,
                Shared_JobPage02_JobPostingExtended08,
                Shared_JobPage02_JobPostingExtended09,
                Shared_JobPage02_JobPostingExtended10,
                Shared_JobPage02_JobPostingExtended11,
                Shared_JobPage02_JobPostingExtended12,
                Shared_JobPage02_JobPostingExtended13,
                Shared_JobPage02_JobPostingExtended14,
                Shared_JobPage02_JobPostingExtended15,
                Shared_JobPage02_JobPostingExtended16,
                Shared_JobPage02_JobPostingExtended17,
                Shared_JobPage02_JobPostingExtended18,
                Shared_JobPage02_JobPostingExtended19,
                Shared_JobPage02_JobPostingExtended20
            };
        internal static WIDExploration WIDExploration_Exploration02
            = new WIDExploration(
                    WIDExploration_Exploration01_RunId,
                    WIDExploration_Exploration01_TotalResultCount,
                    WIDExploration_Exploration01_TotalJobPages,
                    WIDExploration_Exploration01_IsCompleted,
                    WIDExploration_Exploration02_JobPages,
                    WIDExploration_Exploration02_JobPostings,
                    WIDExploration_Exploration02_JobPostingsExtended
                    );
        internal static string WIDExploration_Exploration02_ToString
            = string.Concat(
                "{ ",
                $"'{nameof(WIDExploration.RunId)}':'{WIDExploration_Exploration01_RunId}', ",
                $"'{nameof(WIDExploration.TotalResultCount)}':'{WIDExploration_Exploration01_TotalResultCount}', ",
                $"'{nameof(WIDExploration.TotalJobPages)}':'{WIDExploration_Exploration01_TotalJobPages}', ",
                $"'{nameof(WIDExploration.IsCompleted)}':'{WIDExploration_Exploration01_IsCompleted}', ",
                $"'{nameof(WIDExploration.JobPages)}':'{WIDExploration_Exploration02_JobPages.Count}', ",
                $"'{nameof(WIDExploration.JobPostings)}':'{WIDExploration_Exploration02_JobPostings.Count}', ",
                $"'{nameof(WIDExploration.JobPostingsExtended)}':'{WIDExploration_Exploration02_JobPostingsExtended.Count}'",
                " }"
                );

        #endregion

        #region WIDExplorerTests

        internal static DateTime WIDExplorer_FakeNow = new DateTime(2021, 05, 01);
        internal static Func<DateTime> WIDExplorer_FakeNowFunction = () => WIDExplorer_FakeNow;
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

        internal static WIDExploration WIDExplorer_ExplorationPage01
            = new WIDExploration(
                        Shared_FakeRunId,
                        Shared_Page01_TotalResults,
                        Shared_Page01_TotalEstimatedPages,
                        WIDCategories.AllCategories,
                        WIDStages.Stage3_UpToAllPageItemsExtended,
                        true,
                        Shared_Pages_Page01,
                        Shared_Page01_PageItems,
                        Shared_Page01_PageItemsExtended                
                );

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

        /* -------------------------------------------- */

        #region Shared_JobPage01

        internal static string Shared_FakeResponse = "Fake response";
        internal static string Shared_FakePurpose = "Fake purpose";

        internal static string Shared_JobPage01_Content 
            = Properties.Resources.JobPage01_json;
        internal static string Shared_JobPage01_JobPostingExtended01_Content
            = Properties.Resources.JobPage01_JobPostingExtended01_json;
        internal static string Shared_JobPage01_JobPostingExtended02_Content
            = Properties.Resources.JobPage01_JobPostingExtended02_json;
        internal static string Shared_JobPage01_JobPostingExtended03_Content
            = Properties.Resources.JobPage01_JobPostingExtended03_json;
        internal static string Shared_JobPage01_JobPostingExtended04_Content
            = Properties.Resources.JobPage01_JobPostingExtended04_json;
        internal static string Shared_JobPage01_JobPostingExtended05_Content
            = Properties.Resources.JobPage01_JobPostingExtended05_json;
        internal static string Shared_JobPage01_JobPostingExtended06_Content
            = Properties.Resources.JobPage01_JobPostingExtended06_json;
        internal static string Shared_JobPage01_JobPostingExtended07_Content
            = Properties.Resources.JobPage01_JobPostingExtended07_json;
        internal static string Shared_JobPage01_JobPostingExtended08_Content
            = Properties.Resources.JobPage01_JobPostingExtended08_json;
        internal static string Shared_JobPage01_JobPostingExtended09_Content
            = Properties.Resources.JobPage01_JobPostingExtended09_json;
        internal static string Shared_JobPage01_JobPostingExtended10_Content
            = Properties.Resources.JobPage01_JobPostingExtended10_json;
        internal static string Shared_JobPage01_JobPostingExtended11_Content
            = Properties.Resources.JobPage01_JobPostingExtended11_json;
        internal static string Shared_JobPage01_JobPostingExtended12_Content
            = Properties.Resources.JobPage01_JobPostingExtended12_json;
        internal static string Shared_JobPage01_JobPostingExtended13_Content
            = Properties.Resources.JobPage01_JobPostingExtended13_json;
        internal static string Shared_JobPage01_JobPostingExtended14_Content
            = Properties.Resources.JobPage01_JobPostingExtended14_json;
        internal static string Shared_JobPage01_JobPostingExtended15_Content
            = Properties.Resources.JobPage01_JobPostingExtended15_json;
        internal static string Shared_JobPage01_JobPostingExtended16_Content
            = Properties.Resources.JobPage01_JobPostingExtended16_json;
        internal static string Shared_JobPage01_JobPostingExtended17_Content
            = Properties.Resources.JobPage01_JobPostingExtended17_json;
        internal static string Shared_JobPage01_JobPostingExtended18_Content
            = Properties.Resources.JobPage01_JobPostingExtended18_json;
        internal static string Shared_JobPage01_JobPostingExtended19_Content
            = Properties.Resources.JobPage01_JobPostingExtended19_json;
        internal static string Shared_JobPage01_JobPostingExtended20_Content
            = Properties.Resources.JobPage01_JobPostingExtended20_json;

        internal static JobPosting Shared_JobPage01_JobPosting01
            = new JobPosting(
                    runId: Shared_FakeRunId,
                    pageNumber: 1,
                    response: "{\r\n            \"AutomatchType\": 0,\r\n            \"Abroad\": false,\r\n            \"Weight\": 1.0,\r\n            \"Title\": \"Linux Specialist\",\r\n            \"JobHeadline\": \"Linux Specialist\",\r\n            \"Presentation\": \"<p>PARKEN, COPENHAGEN /</p>\\n<p>ENGINEERING – SYSTEM ADMINISTRATION /</p>\\n<p>FULL TIME, PERMANENT CONTRACT</p>\\n\",\r\n            \"HiringOrgName\": \"Keepit A/S\",\r\n            \"WorkPlaceAddress\": \"Per Henrik Lings Allé 4 7\",\r\n            \"WorkPlacePostalCode\": \"2100\",\r\n            \"WorkPlaceCity\": \"København Ø\",\r\n            \"WorkPlaceOtherAddress\": false,\r\n            \"WorkPlaceAbroad\": false,\r\n            \"WorkPlaceNotStatic\": false,\r\n            \"UseWorkPlaceAddressForJoblog\": true,\r\n            \"PostingCreated\": \"2021-07-02T00:00:00\",\r\n            \"LastDateApplication\": \"2021-08-27T00:00:00\",\r\n            \"FormattedLastDateApplication\": \"27. august 2021\",\r\n            \"AssignmentStartDate\": \"0001-01-01T00:00:00\",\r\n            \"IsHotjob\": false,\r\n            \"IsExternal\": false,\r\n            \"Url\": \"https://job.jobnet.dk/CV/FindWork/Details/5332213\",\r\n            \"Region\": \"Hovedstaden og Bornholm\",\r\n            \"Municipality\": \"København\",\r\n            \"Country\": \"Danmark\",\r\n            \"PostalCode\": \"2100\",\r\n            \"PostalCodeName\": null,\r\n            \"JobAnnouncementType\": \"\",\r\n            \"EmploymentType\": \"\",\r\n            \"WorkHours\": \"Fuldtid\",\r\n            \"OccupationArea\": \"\",\r\n            \"OccupationGroup\": \"\",\r\n            \"Occupation\": \"Programmør og systemudvikler\",\r\n            \"Location\": {\r\n                \"Latitude\": 55.7038,\r\n                \"Longitude\": 12.5721\r\n            },\r\n            \"JoblogWorkTime\": {\r\n                \"WorkHour\": null,\r\n                \"DailyWorkTime\": null\r\n            },\r\n            \"WorkplaceID\": 133543,\r\n            \"OrganisationId\": \"117090\",\r\n            \"HiringOrgCVR\": 30806883,\r\n            \"UserLoggedIn\": false,\r\n            \"AnonymousEmployer\": false,\r\n            \"ShareUrl\": \"https://job.jobnet.dk/CV/FindWork/DetailsSocialmedia/5332213\",\r\n            \"DetailsUrl\": \"https://job.jobnet.dk/CV/FindWork/DetailsWidk/5332213\",\r\n            \"JobLogUrl\": \"https://job.jobnet.dk/CV/FindWork/Details/5332213\",\r\n            \"HasLocationValues\": true,\r\n            \"ID\": \"5332213\",\r\n            \"Latitude\": 55.7038,\r\n            \"Longitude\": 12.5721\r\n        }",
                    title: "Linux Specialist",
                    presentation: "<p>PARKEN, COPENHAGEN /</p>\n<p>ENGINEERING – SYSTEM ADMINISTRATION /</p>\n<p>FULL TIME, PERMANENT CONTRACT</p>\n",
                    hiringOrgName: "Keepit A/S",
                    workPlaceAddress: "Per Henrik Lings Allé 4 7",
                    workPlacePostalCode: 2100,
                    workPlaceCity: "København Ø",
                    postingCreated: new DateTime(2021, 07, 02),
                    lastDateApplication: new DateTime(2021, 08, 27),
                    url: "https://job.jobnet.dk/CV/FindWork/Details/5332213",
                    region: "Hovedstaden og Bornholm",
                    municipality: "København",
                    country: "Danmark",
                    employmentType: "",
                    workHours: "Fuldtid",
                    occupation: "Programmør og systemudvikler",
                    workplaceId: 133543,
                    organisationId: 117090,
                    hiringOrgCVR: 30806883,
                    id: 5332213,
                    workPlaceCityWithoutZone: "København",
                    jobPostingNumber: 1,
                    jobPostingId: "5332213linuxspecialist"
                );
        internal static JobPostingExtended Shared_JobPage01_JobPostingExtended01
            = new JobPostingExtended(
                    jobPosting: Shared_JobPage01_JobPosting01,
                    response: Shared_FakeResponse,                      // Ignored
                    hiringOrgDescription: null,
                    publicationStartDate: new DateTime(2021, 07, 02),
                    publicationEndDate: new DateTime(2021, 08, 27),
                    purpose: Shared_FakePurpose,                        // Ignored
                    numberToFill: 1,
                    contactEmail: "edc@keepit.com",
                    contactPersonName: "Emil Daniel Christensen",
                    employmentDate: null,
                    applicationDeadlineDate: new DateTime(2021, 08, 27),
                    bulletPoints: new HashSet<string>()
                    {
                        "Performance troubleshooting - if a service is not performing as expected, troubleshooting the process interactions on a live server in order to identify the root cause and propose a remedy, possibly in collaboration with the development team.",
                        "Planning, testing, and executing Postgres database cluster migration from an older version to a newer version with little or no user-visible interruptions.",
                        "Designing the next iteration of our network infrastructure for high-performance multi-site communication, and planning and executing the transition from the previous iteration with no customer visible downtime."
                    },
                    bulletPointScenario: "keepit"
                );

        internal static JobPosting Shared_JobPage01_JobPosting02
            = new JobPosting(
                    runId: Shared_FakeRunId,
                    pageNumber: 1,
                    response: "{\r\n            \"AutomatchType\": 0,\r\n            \"Abroad\": false,\r\n            \"Weight\": 1.0,\r\n            \"Title\": \"Motivated forklift drivers for temporary positions during the summer in Skanderborg\",\r\n            \"JobHeadline\": \"Motivated forklift drivers for temporary positions during the summer in Skanderborg\",\r\n            \"Presentation\": \" Are you looking to work during the Summer in the weeks between 27 to 36, then we have the job for you. \\n  We offer  \\n \\n Good work conditions \\n\",\r\n            \"HiringOrgName\": \"TeamVikaren.dk, Århus ApS, Horsens Afdeling\",\r\n            \"WorkPlaceAddress\": \"\",\r\n            \"WorkPlacePostalCode\": \"8660\",\r\n            \"WorkPlaceCity\": \"Skanderborg\",\r\n            \"WorkPlaceOtherAddress\": true,\r\n            \"WorkPlaceAbroad\": false,\r\n            \"WorkPlaceNotStatic\": false,\r\n            \"UseWorkPlaceAddressForJoblog\": false,\r\n            \"PostingCreated\": \"2021-07-02T00:00:00\",\r\n            \"LastDateApplication\": \"2021-08-04T00:00:00\",\r\n            \"FormattedLastDateApplication\": \"4. august 2021\",\r\n            \"AssignmentStartDate\": \"0001-01-01T00:00:00\",\r\n            \"IsHotjob\": false,\r\n            \"IsExternal\": false,\r\n            \"Url\": \"https://job.jobnet.dk/CV/FindWork/Details/5365786\",\r\n            \"Region\": \"Midtjylland\",\r\n            \"Municipality\": \"Skanderborg\",\r\n            \"Country\": \"Danmark\",\r\n            \"PostalCode\": \"8660\",\r\n            \"PostalCodeName\": null,\r\n            \"JobAnnouncementType\": \"\",\r\n            \"EmploymentType\": \"\",\r\n            \"WorkHours\": \"Fuldtid\",\r\n            \"OccupationArea\": \"\",\r\n            \"OccupationGroup\": \"\",\r\n            \"Occupation\": \"Truckfører\",\r\n            \"Location\": {\r\n                \"Latitude\": 56.0239,\r\n                \"Longitude\": 9.8924\r\n            },\r\n            \"JoblogWorkTime\": {\r\n                \"WorkHour\": null,\r\n                \"DailyWorkTime\": \"Dag, aften\"\r\n            },\r\n            \"WorkplaceID\": 126565,\r\n            \"OrganisationId\": \"71174\",\r\n            \"HiringOrgCVR\": 30899695,\r\n            \"UserLoggedIn\": false,\r\n            \"AnonymousEmployer\": false,\r\n            \"ShareUrl\": \"https://job.jobnet.dk/CV/FindWork/DetailsSocialmedia/5365786\",\r\n            \"DetailsUrl\": \"https://job.jobnet.dk/CV/FindWork/DetailsWidk/5365786\",\r\n            \"JobLogUrl\": \"https://job.jobnet.dk/CV/FindWork/Details/5365786\",\r\n            \"HasLocationValues\": true,\r\n            \"ID\": \"5365786\",\r\n            \"Latitude\": 56.0239,\r\n            \"Longitude\": 9.8924\r\n        }",
                    title: "Motivated forklift drivers for temporary positions during the summer in Skanderborg",
                    presentation: " Are you looking to work during the Summer in the weeks between 27 to 36, then we have the job for you. \n  We offer  \n \n Good work conditions \n",
                    hiringOrgName: "TeamVikaren.dk, Århus ApS, Horsens Afdeling",
                    workPlaceAddress: "",
                    workPlacePostalCode: 8660,
                    workPlaceCity: "Skanderborg",
                    postingCreated: new DateTime(2021, 07, 02),
                    lastDateApplication: new DateTime(2021, 08, 04),
                    url: "https://job.jobnet.dk/CV/FindWork/Details/5365786",
                    region: "Midtjylland",
                    municipality: "Skanderborg",
                    country: "Danmark",
                    employmentType: "",
                    workHours: "Fuldtid",
                    occupation: "Truckfører",
                    workplaceId: 126565,
                    organisationId: 71174,
                    hiringOrgCVR: 30899695,
                    id: 5365786,
                    workPlaceCityWithoutZone: "Skanderborg",
                    jobPostingNumber: 2,
                    jobPostingId: "5365786motivatedforkliftdriversfortemporary"
                );
        internal static JobPostingExtended Shared_JobPage01_JobPostingExtended02
            = new JobPostingExtended(
                    jobPosting: Shared_JobPage01_JobPosting02,
                    response: Shared_FakeResponse,                      // Ignored
                    hiringOrgDescription: null,
                    publicationStartDate: new DateTime(2021, 07, 02),
                    publicationEndDate: new DateTime(2021, 08, 04),
                    purpose: Shared_FakePurpose,                        // Ignored
                    numberToFill: 5,
                    contactEmail: null,
                    contactPersonName: "Majken Lorentzen",
                    employmentDate: null,
                    applicationDeadlineDate: new DateTime(2021, 08, 04),
                    bulletPoints: new HashSet<string>()
                    {
                        "Good work conditions",
                        "A social workplace with good colleagues",
                        "Flexibility regarding shifts",
                        "Possibility for day and evening shifts",
                        "You want to work in warehousing and logistics",
                        "You can work a minimum of 3 weeks in the period week 27 - 36",
                        "You can work either day or evening",
                        "You have experience with forklift driving",
                        "You like working in teams"
                    },
                    bulletPointScenario: "generic"
                );

        internal static JobPosting Shared_JobPage01_JobPosting03
            = new JobPosting(
                    runId: Shared_FakeRunId,
                    pageNumber: 1,
                    response: "{\r\n            \"AutomatchType\": 0,\r\n            \"Abroad\": false,\r\n            \"Weight\": 1.0,\r\n            \"Title\": \"Selvstændige truckførere til status og tælleopgave i Kolding/Forklift drivers for inventory assignment in Kolding\",\r\n            \"JobHeadline\": \"Selvstændige truckførere til status og tælleopgave i Kolding/Forklift drivers for inventory assignment in Kolding\",\r\n            \"Presentation\": \"<p><strong>English version below the Danish</strong></p>\\n\",\r\n            \"HiringOrgName\": \"TeamVikaren.dk, Århus ApS, Horsens Afdeling\",\r\n            \"WorkPlaceAddress\": \"\",\r\n            \"WorkPlacePostalCode\": \"6000\",\r\n            \"WorkPlaceCity\": \"Kolding\",\r\n            \"WorkPlaceOtherAddress\": true,\r\n            \"WorkPlaceAbroad\": false,\r\n            \"WorkPlaceNotStatic\": false,\r\n            \"UseWorkPlaceAddressForJoblog\": false,\r\n            \"PostingCreated\": \"2021-07-02T00:00:00\",\r\n            \"LastDateApplication\": \"2021-08-13T00:00:00\",\r\n            \"FormattedLastDateApplication\": \"13. august 2021\",\r\n            \"AssignmentStartDate\": \"0001-01-01T00:00:00\",\r\n            \"IsHotjob\": false,\r\n            \"IsExternal\": false,\r\n            \"Url\": \"https://job.jobnet.dk/CV/FindWork/Details/5372675\",\r\n            \"Region\": \"Syddanmark\",\r\n            \"Municipality\": \"Kolding\",\r\n            \"Country\": \"Danmark\",\r\n            \"PostalCode\": \"6000\",\r\n            \"PostalCodeName\": null,\r\n            \"JobAnnouncementType\": \"\",\r\n            \"EmploymentType\": \"\",\r\n            \"WorkHours\": \"Fuldtid\",\r\n            \"OccupationArea\": \"\",\r\n            \"OccupationGroup\": \"\",\r\n            \"Occupation\": \"Truckfører\",\r\n            \"Location\": {\r\n                \"Latitude\": 55.5022,\r\n                \"Longitude\": 9.4685\r\n            },\r\n            \"JoblogWorkTime\": {\r\n                \"WorkHour\": null,\r\n                \"DailyWorkTime\": \"Dag\"\r\n            },\r\n            \"WorkplaceID\": 126565,\r\n            \"OrganisationId\": \"71174\",\r\n            \"HiringOrgCVR\": 30899695,\r\n            \"UserLoggedIn\": false,\r\n            \"AnonymousEmployer\": false,\r\n            \"ShareUrl\": \"https://job.jobnet.dk/CV/FindWork/DetailsSocialmedia/5372675\",\r\n            \"DetailsUrl\": \"https://job.jobnet.dk/CV/FindWork/DetailsWidk/5372675\",\r\n            \"JobLogUrl\": \"https://job.jobnet.dk/CV/FindWork/Details/5372675\",\r\n            \"HasLocationValues\": true,\r\n            \"ID\": \"5372675\",\r\n            \"Latitude\": 55.5022,\r\n            \"Longitude\": 9.4685\r\n        }",
                    title: "Selvstændige truckførere til status og tælleopgave i Kolding/Forklift drivers for inventory assignment in Kolding",
                    presentation: "<p><strong>English version below the Danish</strong></p>\n",
                    hiringOrgName: "TeamVikaren.dk, Århus ApS, Horsens Afdeling",
                    workPlaceAddress: "",
                    workPlacePostalCode: 6000,
                    workPlaceCity: "Kolding",
                    postingCreated: new DateTime(2021, 07, 02),
                    lastDateApplication: new DateTime(2021, 08, 13),
                    url: "https://job.jobnet.dk/CV/FindWork/Details/5372675",
                    region: "Syddanmark",
                    municipality: "Kolding",
                    country: "Danmark",
                    employmentType: "",
                    workHours: "Fuldtid",
                    occupation: "Truckfører",
                    workplaceId: 126565,
                    organisationId: 71174,
                    hiringOrgCVR: 30899695,
                    id: 5372675,
                    workPlaceCityWithoutZone: "Kolding",
                    jobPostingNumber: 3,
                    jobPostingId: "5372675selvstndigetruckfreretil"
                );
        internal static JobPostingExtended Shared_JobPage01_JobPostingExtended03
            = new JobPostingExtended(
                    jobPosting: Shared_JobPage01_JobPosting03,
                    response: Shared_FakeResponse,                      // Ignored
                    hiringOrgDescription: null,
                    publicationStartDate: new DateTime(2021, 07, 02),
                    publicationEndDate: new DateTime(2021, 08, 13),
                    purpose: Shared_FakePurpose,                        // Ignored
                    numberToFill: 2,
                    contactEmail: null,
                    contactPersonName: "Majken Lorentzen",
                    employmentDate: null,
                    applicationDeadlineDate: new DateTime(2021, 08, 13),
                    bulletPoints: new HashSet<string>()
                    {
                        "Ordnede forhold",
                        "Attraktiv løn",
                        "En social arbejdsplads med gode kollegaer",
                        "Mulighed for vagter på daghold",
                        "Du har lyst til at arbejde inden for lager og logistik",
                        "Du kan arbejde om dagen",
                        "Du har gerne erfaring med truckkørsel – dog ikke et krav",
                        "Du kan lide at arbejde i teams",
                        "Du må ikke være talblind",
                        "Du kan arbejde i ugerne 29 og 30, eller en af ugerne",
                        "Orderly conditions",
                        "Attractive salary",
                        "A social workplace with good colleagues",
                        "Day shifts",
                        "You want to work in warehousing and logistics",
                        "You can work during the day",
                        "You would like to have experience with truck driving - but not a requirement",
                        "You must be able to count",
                        "You can work in weeks 29 and 30, or one of the weeks"
                    },
                    bulletPointScenario: "generic"
                );

        internal static JobPosting Shared_JobPage01_JobPosting04
            = new JobPosting(
                    runId: Shared_FakeRunId,
                    pageNumber: 1,
                    response: "{\r\n            \"AutomatchType\": 0,\r\n            \"Abroad\": false,\r\n            \"Weight\": 1.0,\r\n            \"Title\": \"Erfaren og selvstændig truckfører til virksomhed i Skanderborg/Experienced forklift driver for a company in Skanderborg\",\r\n            \"JobHeadline\": \"Erfaren og selvstændig truckfører til virksomhed i Skanderborg/Experienced forklift driver for a company in Skanderborg\",\r\n            \"Presentation\": \"<p><strong>English version below the Danish</strong></p>\\n<p>Har du erfaring med lager og truckkørsel og kan du lide af arbejde aftener, så har vi jobbet til dig.</p>\\n<p><strong>Jobbet</strong></p>\\n\",\r\n            \"HiringOrgName\": \"TeamVikaren.dk, Århus ApS, Horsens Afdeling\",\r\n            \"WorkPlaceAddress\": \"\",\r\n            \"WorkPlacePostalCode\": \"8660\",\r\n            \"WorkPlaceCity\": \"Skanderborg\",\r\n            \"WorkPlaceOtherAddress\": true,\r\n            \"WorkPlaceAbroad\": false,\r\n            \"WorkPlaceNotStatic\": false,\r\n            \"UseWorkPlaceAddressForJoblog\": false,\r\n            \"PostingCreated\": \"2021-07-02T00:00:00\",\r\n            \"LastDateApplication\": \"2021-08-24T00:00:00\",\r\n            \"FormattedLastDateApplication\": \"24. august 2021\",\r\n            \"AssignmentStartDate\": \"0001-01-01T00:00:00\",\r\n            \"IsHotjob\": false,\r\n            \"IsExternal\": false,\r\n            \"Url\": \"https://job.jobnet.dk/CV/FindWork/Details/5379659\",\r\n            \"Region\": \"Midtjylland\",\r\n            \"Municipality\": \"Skanderborg\",\r\n            \"Country\": \"Danmark\",\r\n            \"PostalCode\": \"8660\",\r\n            \"PostalCodeName\": null,\r\n            \"JobAnnouncementType\": \"\",\r\n            \"EmploymentType\": \"\",\r\n            \"WorkHours\": \"Fuldtid\",\r\n            \"OccupationArea\": \"\",\r\n            \"OccupationGroup\": \"\",\r\n            \"Occupation\": \"Truckfører\",\r\n            \"Location\": {\r\n                \"Latitude\": 56.0239,\r\n                \"Longitude\": 9.8924\r\n            },\r\n            \"JoblogWorkTime\": {\r\n                \"WorkHour\": null,\r\n                \"DailyWorkTime\": \"Aften\"\r\n            },\r\n            \"WorkplaceID\": 126565,\r\n            \"OrganisationId\": \"71174\",\r\n            \"HiringOrgCVR\": 30899695,\r\n            \"UserLoggedIn\": false,\r\n            \"AnonymousEmployer\": false,\r\n            \"ShareUrl\": \"https://job.jobnet.dk/CV/FindWork/DetailsSocialmedia/5379659\",\r\n            \"DetailsUrl\": \"https://job.jobnet.dk/CV/FindWork/DetailsWidk/5379659\",\r\n            \"JobLogUrl\": \"https://job.jobnet.dk/CV/FindWork/Details/5379659\",\r\n            \"HasLocationValues\": true,\r\n            \"ID\": \"5379659\",\r\n            \"Latitude\": 56.0239,\r\n            \"Longitude\": 9.8924\r\n        }",
                    title: "Erfaren og selvstændig truckfører til virksomhed i Skanderborg/Experienced forklift driver for a company in Skanderborg",
                    presentation: "<p><strong>English version below the Danish</strong></p>\n<p>Har du erfaring med lager og truckkørsel og kan du lide af arbejde aftener, så har vi jobbet til dig.</p>\n<p><strong>Jobbet</strong></p>\n",
                    hiringOrgName: "TeamVikaren.dk, Århus ApS, Horsens Afdeling",
                    workPlaceAddress: "",
                    workPlacePostalCode: 8660,
                    workPlaceCity: "Skanderborg",
                    postingCreated: new DateTime(2021, 07, 02),
                    lastDateApplication: new DateTime(2021, 08, 24),
                    url: "https://job.jobnet.dk/CV/FindWork/Details/5379659",
                    region: "Midtjylland",
                    municipality: "Skanderborg",
                    country: "Danmark",
                    employmentType: "",
                    workHours: "Fuldtid",
                    occupation: "Truckfører",
                    workplaceId: 126565,
                    organisationId: 71174,
                    hiringOrgCVR: 30899695,
                    id: 5379659,
                    workPlaceCityWithoutZone: "Skanderborg",
                    jobPostingNumber: 4,
                    jobPostingId: "5379659erfarenogselvstndigtruckf"
                );
        internal static JobPostingExtended Shared_JobPage01_JobPostingExtended04
            = new JobPostingExtended(
                    jobPosting: Shared_JobPage01_JobPosting04,
                    response: Shared_FakeResponse,                      // Ignored
                    hiringOrgDescription: null,
                    publicationStartDate: new DateTime(2021, 07, 02),
                    publicationEndDate: new DateTime(2021, 08, 24),
                    purpose: Shared_FakePurpose,                        // Ignored
                    numberToFill: 1,
                    contactEmail: null,
                    contactPersonName: "Majken Lorentzen",
                    employmentDate: null,
                    applicationDeadlineDate: new DateTime(2021, 08, 24),
                    bulletPoints: new HashSet<string>()
                    {
                        "Du har truckkort",
                        "Du kan lide at arbejde om aftenen",
                        "Du kan tale, skrive og læse dansk eller engelsk",
                        "Du kan arbejde selvstændigt",
                        "Du er grundig i dit arbejde",
                        "You have a forklift licence",
                        "You like working in the evenings",
                        "You can speak, write and read Danish or English",
                        "You can work independently",
                        "You are thorough in your work"
                    },
                    bulletPointScenario: "generic"
                );

        internal static JobPosting Shared_JobPage01_JobPosting05
            = new JobPosting(
                    runId: Shared_FakeRunId,
                    pageNumber: 1,
                    response: "{\r\n            \"AutomatchType\": 0,\r\n            \"Abroad\": false,\r\n            \"Weight\": 1.0,\r\n            \"Title\": \"Vi søger rengøringsassistenter til weekendarbejde i Vejers Strand/We are looking for cleaning assistants for weekend work in Vejers Strand\",\r\n            \"JobHeadline\": \"Vi søger rengøringsassistenter til weekendarbejde i Vejers Strand/We are looking for cleaning assistants for weekend work in Vejers Strand\",\r\n            \"Presentation\": \"<p><strong>English version below the Danish</strong></p>\\n<p>Vi søger rengøringsassistenter til weekendarbejde i Vejers Strand.</p>\\n\",\r\n            \"HiringOrgName\": \"TeamVikaren.dk, Århus ApS, Horsens Afdeling\",\r\n            \"WorkPlaceAddress\": \"\",\r\n            \"WorkPlacePostalCode\": \"6853\",\r\n            \"WorkPlaceCity\": \"Vejers Strand\",\r\n            \"WorkPlaceOtherAddress\": true,\r\n            \"WorkPlaceAbroad\": false,\r\n            \"WorkPlaceNotStatic\": false,\r\n            \"UseWorkPlaceAddressForJoblog\": false,\r\n            \"PostingCreated\": \"2021-07-02T00:00:00\",\r\n            \"LastDateApplication\": \"2021-08-19T00:00:00\",\r\n            \"FormattedLastDateApplication\": \"19. august 2021\",\r\n            \"AssignmentStartDate\": \"0001-01-01T00:00:00\",\r\n            \"IsHotjob\": false,\r\n            \"IsExternal\": false,\r\n            \"Url\": \"https://job.jobnet.dk/CV/FindWork/Details/5376524\",\r\n            \"Region\": \"Syddanmark\",\r\n            \"Municipality\": \"Varde\",\r\n            \"Country\": \"Danmark\",\r\n            \"PostalCode\": \"6853\",\r\n            \"PostalCodeName\": null,\r\n            \"JobAnnouncementType\": \"\",\r\n            \"EmploymentType\": \"\",\r\n            \"WorkHours\": \"Deltid\",\r\n            \"OccupationArea\": \"\",\r\n            \"OccupationGroup\": \"\",\r\n            \"Occupation\": \"Rengøringsassistent\",\r\n            \"Location\": {\r\n                \"Latitude\": 55.4329,\r\n                \"Longitude\": 5.2422\r\n            },\r\n            \"JoblogWorkTime\": {\r\n                \"WorkHour\": \"(0 - 12 timer ugentligt)\",\r\n                \"DailyWorkTime\": \"Weekend\"\r\n            },\r\n            \"WorkplaceID\": 126565,\r\n            \"OrganisationId\": \"71174\",\r\n            \"HiringOrgCVR\": 30899695,\r\n            \"UserLoggedIn\": false,\r\n            \"AnonymousEmployer\": false,\r\n            \"ShareUrl\": \"https://job.jobnet.dk/CV/FindWork/DetailsSocialmedia/5376524\",\r\n            \"DetailsUrl\": \"https://job.jobnet.dk/CV/FindWork/DetailsWidk/5376524\",\r\n            \"JobLogUrl\": \"https://job.jobnet.dk/CV/FindWork/Details/5376524\",\r\n            \"HasLocationValues\": true,\r\n            \"ID\": \"5376524\",\r\n            \"Latitude\": 55.4329,\r\n            \"Longitude\": 5.2422\r\n        }",
                    title: "Vi søger rengøringsassistenter til weekendarbejde i Vejers Strand/We are looking for cleaning assistants for weekend work in Vejers Strand",
                    presentation: "<p><strong>English version below the Danish</strong></p>\n<p>Vi søger rengøringsassistenter til weekendarbejde i Vejers Strand.</p>\n",
                    hiringOrgName: "TeamVikaren.dk, Århus ApS, Horsens Afdeling",
                    workPlaceAddress: "",
                    workPlacePostalCode: 6853,
                    workPlaceCity: "Vejers Strand",
                    postingCreated: new DateTime(2021, 07, 02),
                    lastDateApplication: new DateTime(2021, 08, 19),
                    url: "https://job.jobnet.dk/CV/FindWork/Details/5376524",
                    region: "Syddanmark",
                    municipality: "Varde",
                    country: "Danmark",
                    employmentType: "",
                    workHours: "Deltid",
                    occupation: "Rengøringsassistent",
                    workplaceId: 126565,
                    organisationId: 71174,
                    hiringOrgCVR: 30899695,
                    id: 5376524,
                    workPlaceCityWithoutZone: "Vejers Strand",
                    jobPostingNumber: 5,
                    jobPostingId: "5376524visgerrengringsassistenter"
                );
        internal static JobPostingExtended Shared_JobPage01_JobPostingExtended05
            = new JobPostingExtended(
                    jobPosting: Shared_JobPage01_JobPosting05,
                    response: Shared_FakeResponse,                      // Ignored
                    hiringOrgDescription: null,
                    publicationStartDate: new DateTime(2021, 07, 02),
                    publicationEndDate: new DateTime(2021, 08, 19),
                    purpose: Shared_FakePurpose,                        // Ignored
                    numberToFill: 20,
                    contactEmail: null,
                    contactPersonName: "Majken Lorentzen",
                    employmentDate: null,
                    applicationDeadlineDate: new DateTime(2021, 08, 19),
                    bulletPoints: new HashSet<string>()
                    {
                        "Fleksible arbejdstider",
                        "Attraktiv løn (DKK 180,- per time)",
                        "Kørselsgodtgørelse (statens takst)",
                        "Aktivt og alsidigt arbejde",
                        "Du kan arbejde i weekender",
                        "Du har egen bil til rådighed",
                        "Du kan lide aktivt arbejde",
                        "Du har erfaring fra tidligere arbejde – dog ikke et krav",
                        "Du taler, læser og skriver dansk, engelsk eller tysk",
                        "Flexible hours",
                        "Attractive salary (DKK 180 per hour)",
                        "Travel allowance (state tariff)",
                        "Active and versatile work",
                        "You can work on weekends",
                        "You have your own car available",
                        "You like active work",
                        "You have experience from previous work - not a requirement",
                        "You speak, read and write Danish, English or German"
                    },
                    bulletPointScenario: "generic"
                );

        internal static JobPosting Shared_JobPage01_JobPosting06
            = new JobPosting(
                    runId: Shared_FakeRunId,
                    pageNumber: 1,
                    response: "{\r\n            \"AutomatchType\": 0,\r\n            \"Abroad\": false,\r\n            \"Weight\": 1.0,\r\n            \"Title\": \"Motivated employees for warehouse work in Vejen, start-up as soon as possible\",\r\n            \"JobHeadline\": \"Motivated employees for warehouse work in Vejen, start-up as soon as possible\",\r\n            \"Presentation\": \" Do you want to help make a difference at our customer in Vejen, and can you start with short notice? Then we have the job for you. \\n  We offer  \\n \\n A social workplace\",\r\n            \"HiringOrgName\": \"TeamVikaren.dk, Århus ApS, Horsens Afdeling\",\r\n            \"WorkPlaceAddress\": \"\",\r\n            \"WorkPlacePostalCode\": \"6600\",\r\n            \"WorkPlaceCity\": \"Vejen\",\r\n            \"WorkPlaceOtherAddress\": true,\r\n            \"WorkPlaceAbroad\": false,\r\n            \"WorkPlaceNotStatic\": false,\r\n            \"UseWorkPlaceAddressForJoblog\": false,\r\n            \"PostingCreated\": \"2021-07-02T00:00:00\",\r\n            \"LastDateApplication\": \"2021-08-27T00:00:00\",\r\n            \"FormattedLastDateApplication\": \"27. august 2021\",\r\n            \"AssignmentStartDate\": \"0001-01-01T00:00:00\",\r\n            \"IsHotjob\": false,\r\n            \"IsExternal\": false,\r\n            \"Url\": \"https://job.jobnet.dk/CV/FindWork/Details/5303321\",\r\n            \"Region\": \"Syddanmark\",\r\n            \"Municipality\": \"Vejen\",\r\n            \"Country\": \"Danmark\",\r\n            \"PostalCode\": \"6600\",\r\n            \"PostalCodeName\": null,\r\n            \"JobAnnouncementType\": \"\",\r\n            \"EmploymentType\": \"\",\r\n            \"WorkHours\": \"Fuldtid\",\r\n            \"OccupationArea\": \"\",\r\n            \"OccupationGroup\": \"\",\r\n            \"Occupation\": \"Lager- og logistikmedarbejder\",\r\n            \"Location\": {\r\n                \"Latitude\": 55.4784,\r\n                \"Longitude\": 9.112\r\n            },\r\n            \"JoblogWorkTime\": {\r\n                \"WorkHour\": null,\r\n                \"DailyWorkTime\": \"Dag\"\r\n            },\r\n            \"WorkplaceID\": 126565,\r\n            \"OrganisationId\": \"71174\",\r\n            \"HiringOrgCVR\": 30899695,\r\n            \"UserLoggedIn\": false,\r\n            \"AnonymousEmployer\": false,\r\n            \"ShareUrl\": \"https://job.jobnet.dk/CV/FindWork/DetailsSocialmedia/5303321\",\r\n            \"DetailsUrl\": \"https://job.jobnet.dk/CV/FindWork/DetailsWidk/5303321\",\r\n            \"JobLogUrl\": \"https://job.jobnet.dk/CV/FindWork/Details/5303321\",\r\n            \"HasLocationValues\": true,\r\n            \"ID\": \"5303321\",\r\n            \"Latitude\": 55.4784,\r\n            \"Longitude\": 9.112\r\n        }",
                    title: "Motivated employees for warehouse work in Vejen, start-up as soon as possible",
                    presentation: " Do you want to help make a difference at our customer in Vejen, and can you start with short notice? Then we have the job for you. \n  We offer  \n \n A social workplace",
                    hiringOrgName: "TeamVikaren.dk, Århus ApS, Horsens Afdeling",
                    workPlaceAddress: "",
                    workPlacePostalCode: 6600,
                    workPlaceCity: "Vejen",
                    postingCreated: new DateTime(2021, 07, 02),
                    lastDateApplication: new DateTime(2021, 08, 27),
                    url: "https://job.jobnet.dk/CV/FindWork/Details/5303321",
                    region: "Syddanmark",
                    municipality: "Vejen",
                    country: "Danmark",
                    employmentType: "",
                    workHours: "Fuldtid",
                    occupation: "Lager- og logistikmedarbejder",
                    workplaceId: 126565,
                    organisationId: 71174,
                    hiringOrgCVR: 30899695,
                    id: 5303321,
                    workPlaceCityWithoutZone: "Vejen",
                    jobPostingNumber: 6,
                    jobPostingId: "5303321motivatedemployeesforwarehousework"
                );
        internal static JobPostingExtended Shared_JobPage01_JobPostingExtended06
            = new JobPostingExtended(
                    jobPosting: Shared_JobPage01_JobPosting06,
                    response: Shared_FakeResponse,                      // Ignored
                    hiringOrgDescription: null,
                    publicationStartDate: new DateTime(2021, 07, 02),
                    publicationEndDate: new DateTime(2021, 08, 27),
                    purpose: Shared_FakePurpose,                        // Ignored
                    numberToFill: 12,
                    contactEmail: null,
                    contactPersonName: "Majken Lorentzen",
                    employmentDate: null,
                    applicationDeadlineDate: new DateTime(2021, 08, 27),
                    bulletPoints: new HashSet<string>()
                    {
                        "A social workplace",
                        "Day shifts",
                        "A healthy working environment",
                        "Good colleagues",
                        "Training in warehouse work such as picking, packing, sorting and much more",
                        "You would like to work in a warehouse",
                        "You like active work",
                        "You can work full time – part time work can also be arranged",
                        "You can work independently"
                    },
                    bulletPointScenario: "generic"
                );

        internal static JobPosting Shared_JobPage01_JobPosting07
            = new JobPosting(
                    runId: Shared_FakeRunId,
                    pageNumber: 1,
                    response: "{\r\n            \"AutomatchType\": 0,\r\n            \"Abroad\": false,\r\n            \"Weight\": 1.0,\r\n            \"Title\": \"Motivated employees for warehouse work in Kolding - full time and part time work , start-up as soon as possible\",\r\n            \"JobHeadline\": \"Motivated employees for warehouse work in Kolding - full time and part time work , start-up as soon as possible\",\r\n            \"Presentation\": \" Do you want to help make a difference at our customer in Kolding, and can you start with short notice? Then we have the job for you. \\n  We offer  \\n \\n\",\r\n            \"HiringOrgName\": \"TeamVikaren.dk, Århus ApS, Horsens Afdeling\",\r\n            \"WorkPlaceAddress\": \"\",\r\n            \"WorkPlacePostalCode\": \"6000\",\r\n            \"WorkPlaceCity\": \"Kolding\",\r\n            \"WorkPlaceOtherAddress\": true,\r\n            \"WorkPlaceAbroad\": false,\r\n            \"WorkPlaceNotStatic\": false,\r\n            \"UseWorkPlaceAddressForJoblog\": false,\r\n            \"PostingCreated\": \"2021-07-02T00:00:00\",\r\n            \"LastDateApplication\": \"2021-08-27T00:00:00\",\r\n            \"FormattedLastDateApplication\": \"27. august 2021\",\r\n            \"AssignmentStartDate\": \"0001-01-01T00:00:00\",\r\n            \"IsHotjob\": false,\r\n            \"IsExternal\": false,\r\n            \"Url\": \"https://job.jobnet.dk/CV/FindWork/Details/5290988\",\r\n            \"Region\": \"Syddanmark\",\r\n            \"Municipality\": \"Kolding\",\r\n            \"Country\": \"Danmark\",\r\n            \"PostalCode\": \"6000\",\r\n            \"PostalCodeName\": null,\r\n            \"JobAnnouncementType\": \"\",\r\n            \"EmploymentType\": \"\",\r\n            \"WorkHours\": \"Deltid\",\r\n            \"OccupationArea\": \"\",\r\n            \"OccupationGroup\": \"\",\r\n            \"Occupation\": \"Lager- og logistikmedarbejder\",\r\n            \"Location\": {\r\n                \"Latitude\": 55.5022,\r\n                \"Longitude\": 9.4685\r\n            },\r\n            \"JoblogWorkTime\": {\r\n                \"WorkHour\": \"(1 - 36 timer ugentligt)\",\r\n                \"DailyWorkTime\": \"Dag, aften\"\r\n            },\r\n            \"WorkplaceID\": 126565,\r\n            \"OrganisationId\": \"71174\",\r\n            \"HiringOrgCVR\": 30899695,\r\n            \"UserLoggedIn\": false,\r\n            \"AnonymousEmployer\": false,\r\n            \"ShareUrl\": \"https://job.jobnet.dk/CV/FindWork/DetailsSocialmedia/5290988\",\r\n            \"DetailsUrl\": \"https://job.jobnet.dk/CV/FindWork/DetailsWidk/5290988\",\r\n            \"JobLogUrl\": \"https://job.jobnet.dk/CV/FindWork/Details/5290988\",\r\n            \"HasLocationValues\": true,\r\n            \"ID\": \"5290988\",\r\n            \"Latitude\": 55.5022,\r\n            \"Longitude\": 9.4685\r\n        }",
                    title: "Motivated employees for warehouse work in Kolding - full time and part time work , start-up as soon as possible",
                    presentation: " Do you want to help make a difference at our customer in Kolding, and can you start with short notice? Then we have the job for you. \n  We offer  \n \n",
                    hiringOrgName: "TeamVikaren.dk, Århus ApS, Horsens Afdeling",
                    workPlaceAddress: "",
                    workPlacePostalCode: 6000,
                    workPlaceCity: "Kolding",
                    postingCreated: new DateTime(2021, 07, 02),
                    lastDateApplication: new DateTime(2021, 08, 27),
                    url: "https://job.jobnet.dk/CV/FindWork/Details/5290988",
                    region: "Syddanmark",
                    municipality: "Kolding",
                    country: "Danmark",
                    employmentType: "",
                    workHours: "Deltid",
                    occupation: "Lager- og logistikmedarbejder",
                    workplaceId: 126565,
                    organisationId: 71174,
                    hiringOrgCVR: 30899695,
                    id: 5290988,
                    workPlaceCityWithoutZone: "Kolding",
                    jobPostingNumber: 7,
                    jobPostingId: "5290988motivatedemployeesforwarehousework"
                );
        internal static JobPostingExtended Shared_JobPage01_JobPostingExtended07
            = new JobPostingExtended(
                    jobPosting: Shared_JobPage01_JobPosting07,
                    response: Shared_FakeResponse,                      // Ignored
                    hiringOrgDescription: null,
                    publicationStartDate: new DateTime(2021, 07, 02),
                    publicationEndDate: new DateTime(2021, 08, 27),
                    purpose: Shared_FakePurpose,                        // Ignored
                    numberToFill: 12,
                    contactEmail: null,
                    contactPersonName: "Majken Lorentzen",
                    employmentDate: null,
                    applicationDeadlineDate: new DateTime(2021, 08, 27),
                    bulletPoints: new HashSet<string>()
                    {
                        "A social workplace",
                        "Day and evening shifts",
                        "Full time work and part time work",
                        "A healthy working environment",
                        "Good colleagues",
                        "Training in warehouse work such as picking, packing, sorting and much more",
                        "You would like to work in a warehouse",
                        "You like active work",
                        "You can work full time or part time",
                        "You can work independently"
                    },
                    bulletPointScenario: "generic"
                );

        internal static JobPosting Shared_JobPage01_JobPosting08
            = new JobPosting(
                    runId: Shared_FakeRunId,
                    pageNumber: 1,
                    response: "{\r\n            \"AutomatchType\": 0,\r\n            \"Abroad\": false,\r\n            \"Weight\": 1.0,\r\n            \"Title\": \"Vice President of Product Marketing\",\r\n            \"JobHeadline\": \"Vice President of Product Marketing\",\r\n            \"Presentation\": \"<p><strong>PARKEN, COPENHAGEN /</strong></p>\\n<p><strong>BRAND AND MARKETING – PRODUCT MARKETING /</strong></p>\\n<p><strong>FULL TIME, PERMANENT CONTRACT</strong></p>\\n\",\r\n            \"HiringOrgName\": \"Keepit A/S\",\r\n            \"WorkPlaceAddress\": \"Per Henrik Lings Allé 4 7\",\r\n            \"WorkPlacePostalCode\": \"2100\",\r\n            \"WorkPlaceCity\": \"København Ø\",\r\n            \"WorkPlaceOtherAddress\": false,\r\n            \"WorkPlaceAbroad\": false,\r\n            \"WorkPlaceNotStatic\": false,\r\n            \"UseWorkPlaceAddressForJoblog\": true,\r\n            \"PostingCreated\": \"2021-07-02T00:00:00\",\r\n            \"LastDateApplication\": \"2021-08-27T00:00:00\",\r\n            \"FormattedLastDateApplication\": \"27. august 2021\",\r\n            \"AssignmentStartDate\": \"0001-01-01T00:00:00\",\r\n            \"IsHotjob\": false,\r\n            \"IsExternal\": false,\r\n            \"Url\": \"https://job.jobnet.dk/CV/FindWork/Details/5383229\",\r\n            \"Region\": \"Hovedstaden og Bornholm\",\r\n            \"Municipality\": \"København\",\r\n            \"Country\": \"Danmark\",\r\n            \"PostalCode\": \"2100\",\r\n            \"PostalCodeName\": null,\r\n            \"JobAnnouncementType\": \"\",\r\n            \"EmploymentType\": \"\",\r\n            \"WorkHours\": \"Fuldtid\",\r\n            \"OccupationArea\": \"\",\r\n            \"OccupationGroup\": \"\",\r\n            \"Occupation\": \"Marketingchef\",\r\n            \"Location\": {\r\n                \"Latitude\": 55.7038,\r\n                \"Longitude\": 12.5721\r\n            },\r\n            \"JoblogWorkTime\": {\r\n                \"WorkHour\": null,\r\n                \"DailyWorkTime\": null\r\n            },\r\n            \"WorkplaceID\": 133543,\r\n            \"OrganisationId\": \"117090\",\r\n            \"HiringOrgCVR\": 30806883,\r\n            \"UserLoggedIn\": false,\r\n            \"AnonymousEmployer\": false,\r\n            \"ShareUrl\": \"https://job.jobnet.dk/CV/FindWork/DetailsSocialmedia/5383229\",\r\n            \"DetailsUrl\": \"https://job.jobnet.dk/CV/FindWork/DetailsWidk/5383229\",\r\n            \"JobLogUrl\": \"https://job.jobnet.dk/CV/FindWork/Details/5383229\",\r\n            \"HasLocationValues\": true,\r\n            \"ID\": \"5383229\",\r\n            \"Latitude\": 55.7038,\r\n            \"Longitude\": 12.5721\r\n        }",
                    title: "Vice President of Product Marketing",
                    presentation: "<p><strong>PARKEN, COPENHAGEN /</strong></p>\n<p><strong>BRAND AND MARKETING – PRODUCT MARKETING /</strong></p>\n<p><strong>FULL TIME, PERMANENT CONTRACT</strong></p>\n",
                    hiringOrgName: "Keepit A/S",
                    workPlaceAddress: "Per Henrik Lings Allé 4 7",
                    workPlacePostalCode: 2100,
                    workPlaceCity: "København Ø",
                    postingCreated: new DateTime(2021, 07, 02),
                    lastDateApplication: new DateTime(2021, 08, 27),
                    url: "https://job.jobnet.dk/CV/FindWork/Details/5383229",
                    region: "Hovedstaden og Bornholm",
                    municipality: "København",
                    country: "Danmark",
                    employmentType: "",
                    workHours: "Fuldtid",
                    occupation: "Marketingchef",
                    workplaceId: 133543,
                    organisationId: 117090,
                    hiringOrgCVR: 30806883,
                    id: 5383229,
                    workPlaceCityWithoutZone: "København",
                    jobPostingNumber: 8,
                    jobPostingId: "5383229vicepresidentofproductmarketing"
                );
        internal static JobPostingExtended Shared_JobPage01_JobPostingExtended08
                = new JobPostingExtended(
                        jobPosting: Shared_JobPage01_JobPosting08,
                        response: Shared_FakeResponse,                      // Ignored
                        hiringOrgDescription: null,
                        publicationStartDate: new DateTime(2021, 07, 02),
                        publicationEndDate: new DateTime(2021, 08, 27),
                        purpose: Shared_FakePurpose,                        // Ignored
                        numberToFill: 1,
                        contactEmail: "edc@keepit.com",
                        contactPersonName: "Emil Daniel Christensen",
                        employmentDate: null,
                        applicationDeadlineDate: new DateTime(2021, 08, 27),
                        bulletPoints: new HashSet<string>()
                        {
                            "As a Vice President, we expect a truly transparent and inclusive leadership style, empowering your team to perform at their maximum abilities.",
                            "Facilitate outstanding collaborations between the product marketing team and the full brand & marketing team as well as internal core stakeholders such as product management and sales",
                            "Help us articulate and implement a global product marketing strategy ·Serve as an evangelist for our products through thought leadership",
                            "Keep the company up-to-date with market trends and competition",
                            "Product Marketing Strategy: We are looking for a profile that can help us define the right strategies that will fuel our continued growth. Having experience with making product marketing strategies for SaaS products is a requirement.",
                            "Product Marketing: The right candidate has a solid product marketing skill-set with an entrepreneurial spirit. You know how to deliver sales enablement content and can execute marketing initiatives, including aligning and getting buy-in from stakeholders across the organization (including marketing, product, and sales).",
                            "Leadership Style: We believe that the right candidate has the ability to inspire the team with an including and transparent leadership style.",
                            "Language: We use English as our preferred language, and being fluent in English, both written and spoken, is essential for this role.",
                            "Entrepreneurial spirit: We are passionate about winning in the market. However, we are also passionate about our workplace, and we know that a good work environment and great collaboration across our organization are crucial to achieving our ambitious goals. Therefore, we are searching for team leaders who, like us, are being motivated by building a fair and fun work environment at Keepit."
                        },
                        bulletPointScenario: "generic"
                    );

        internal static JobPosting Shared_JobPage01_JobPosting09
            = new JobPosting(
                    runId: Shared_FakeRunId,
                    pageNumber: 1,
                    response: "{\r\n            \"AutomatchType\": 0,\r\n            \"Abroad\": false,\r\n            \"Weight\": 1.0,\r\n            \"Title\": \"Friske og oplagte medarbejdere til sortering af pakker på stort lager i Horsens/Motivated employees for sorting packages in a large warehouse in Horsens\",\r\n            \"JobHeadline\": \"Friske og oplagte medarbejdere til sortering af pakker på stort lager i Horsens/Motivated employees for sorting packages in a large warehouse in Horsens\",\r\n            \"Presentation\": \"<p><strong>English version below the Danish</strong></p>\\n\",\r\n            \"HiringOrgName\": \"TeamVikaren.dk, Århus ApS, Horsens Afdeling\",\r\n            \"WorkPlaceAddress\": \"Strandpromenaden 6\",\r\n            \"WorkPlacePostalCode\": \"8700\",\r\n            \"WorkPlaceCity\": \"Horsens\",\r\n            \"WorkPlaceOtherAddress\": false,\r\n            \"WorkPlaceAbroad\": false,\r\n            \"WorkPlaceNotStatic\": false,\r\n            \"UseWorkPlaceAddressForJoblog\": true,\r\n            \"PostingCreated\": \"2021-07-02T00:00:00\",\r\n            \"LastDateApplication\": \"2021-07-15T00:00:00\",\r\n            \"FormattedLastDateApplication\": \"15. juli 2021\",\r\n            \"AssignmentStartDate\": \"0001-01-01T00:00:00\",\r\n            \"IsHotjob\": false,\r\n            \"IsExternal\": false,\r\n            \"Url\": \"https://job.jobnet.dk/CV/FindWork/Details/5331002\",\r\n            \"Region\": \"Midtjylland\",\r\n            \"Municipality\": \"Horsens\",\r\n            \"Country\": \"Danmark\",\r\n            \"PostalCode\": \"8700\",\r\n            \"PostalCodeName\": null,\r\n            \"JobAnnouncementType\": \"\",\r\n            \"EmploymentType\": \"\",\r\n            \"WorkHours\": \"Deltid\",\r\n            \"OccupationArea\": \"\",\r\n            \"OccupationGroup\": \"\",\r\n            \"Occupation\": \"Lager- og logistikmedarbejder\",\r\n            \"Location\": {\r\n                \"Latitude\": 55.861,\r\n                \"Longitude\": 9.8732\r\n            },\r\n            \"JoblogWorkTime\": {\r\n                \"WorkHour\": \"(8 - 20 timer ugentligt)\",\r\n                \"DailyWorkTime\": \"Aften\"\r\n            },\r\n            \"WorkplaceID\": 126565,\r\n            \"OrganisationId\": \"71174\",\r\n            \"HiringOrgCVR\": 30899695,\r\n            \"UserLoggedIn\": false,\r\n            \"AnonymousEmployer\": false,\r\n            \"ShareUrl\": \"https://job.jobnet.dk/CV/FindWork/DetailsSocialmedia/5331002\",\r\n            \"DetailsUrl\": \"https://job.jobnet.dk/CV/FindWork/DetailsWidk/5331002\",\r\n            \"JobLogUrl\": \"https://job.jobnet.dk/CV/FindWork/Details/5331002\",\r\n            \"HasLocationValues\": true,\r\n            \"ID\": \"5331002\",\r\n            \"Latitude\": 55.861,\r\n            \"Longitude\": 9.8732\r\n        }",
                    title: "Friske og oplagte medarbejdere til sortering af pakker på stort lager i Horsens/Motivated employees for sorting packages in a large warehouse in Horsens",
                    presentation: "<p><strong>English version below the Danish</strong></p>\n",
                    hiringOrgName: "TeamVikaren.dk, Århus ApS, Horsens Afdeling",
                    workPlaceAddress: "Strandpromenaden 6",
                    workPlacePostalCode: 8700,
                    workPlaceCity: "Horsens",
                    postingCreated: new DateTime(2021, 07, 02),
                    lastDateApplication: new DateTime(2021, 07, 15),
                    url: "https://job.jobnet.dk/CV/FindWork/Details/5331002",
                    region: "Midtjylland",
                    municipality: "Horsens",
                    country: "Danmark",
                    employmentType: "",
                    workHours: "Deltid",
                    occupation: "Lager- og logistikmedarbejder",
                    workplaceId: 126565,
                    organisationId: 71174,
                    hiringOrgCVR: 30899695,
                    id: 5331002,
                    workPlaceCityWithoutZone: "Horsens",
                    jobPostingNumber: 9,
                    jobPostingId: "5331002friskeogoplagtemedarbejderetil"
                );
        internal static JobPostingExtended Shared_JobPage01_JobPostingExtended09
            = new JobPostingExtended(
                    jobPosting: Shared_JobPage01_JobPosting09,
                    response: Shared_FakeResponse,                      // Ignored
                    hiringOrgDescription: null,
                    publicationStartDate: new DateTime(2021, 07, 02),
                    publicationEndDate: new DateTime(2021, 07, 15),
                    purpose: Shared_FakePurpose,                        // Ignored
                    numberToFill: 5,
                    contactEmail: null,
                    contactPersonName: "Majken Lorentzen",
                    employmentDate: null,
                    applicationDeadlineDate: new DateTime(2021, 07, 15),
                    bulletPoints: new HashSet<string>()
                    {
                        "Ordnede forhold",
                        "En social arbejdsplads med gode kollegaer",
                        "Fleksibilitet vedr. vagter",
                        "Mulighed for vagter både på hverdage og i weekender",
                        "Du har lyst til at arbejde inden for lager og logistik",
                        "Du er fleksibel",
                        "Du kan arbejde minimum 2 dage om ugen",
                        "Du kan arbejde om eftermiddagen og aftenen",
                        "Du har en god fysik",
                        "Du kan lide at arbejde i teams",
                        "Orderly conditions",
                        "A social workplace with good colleagues",
                        "Flexibility regarding shifts",
                        "Possibility of shifts both on weekdays and on weekends",
                        "You want to work in warehousing and logistics",
                        "You are flexible",
                        "You can work a minimum of 2 days a week",
                        "You can work in the afternoon and evening time",
                        "You have a good physique",
                        "You like working in teams"
                    },
                    bulletPointScenario: "generic"
                );

        internal static JobPosting Shared_JobPage01_JobPosting10
            = new JobPosting(
                    runId: Shared_FakeRunId,
                    pageNumber: 1,
                    response: "{\r\n            \"AutomatchType\": 0,\r\n            \"Abroad\": false,\r\n            \"Weight\": 1.0,\r\n            \"Title\": \"Tenure track assistant professor in applied statistics\",\r\n            \"JobHeadline\": \"Tenure track assistant professor in applied statistics\",\r\n            \"Presentation\": \"Department of Agroecology, Aarhus University, invites applications for a tenure track position in applied statistics.<br><br>The main activity will be research and support in statistical methods and\",\r\n            \"HiringOrgName\": \"Aarhus Universitet\",\r\n            \"WorkPlaceAddress\": \"Blichers Alle 20\",\r\n            \"WorkPlacePostalCode\": \"8830\",\r\n            \"WorkPlaceCity\": \"Tjele\",\r\n            \"WorkPlaceOtherAddress\": false,\r\n            \"WorkPlaceAbroad\": false,\r\n            \"WorkPlaceNotStatic\": false,\r\n            \"UseWorkPlaceAddressForJoblog\": true,\r\n            \"PostingCreated\": \"2021-07-02T00:00:00\",\r\n            \"LastDateApplication\": \"2021-08-13T00:00:00\",\r\n            \"FormattedLastDateApplication\": \"13. august 2021\",\r\n            \"AssignmentStartDate\": \"0001-01-01T00:00:00\",\r\n            \"IsHotjob\": false,\r\n            \"IsExternal\": false,\r\n            \"Url\": \"https://job.jobnet.dk/CV/FindWork/Details/5383212\",\r\n            \"Region\": \"Midtjylland\",\r\n            \"Municipality\": \"Viborg\",\r\n            \"Country\": \"Danmark\",\r\n            \"PostalCode\": \"8830\",\r\n            \"PostalCodeName\": null,\r\n            \"JobAnnouncementType\": \"\",\r\n            \"EmploymentType\": \"\",\r\n            \"WorkHours\": \"Fuldtid\",\r\n            \"OccupationArea\": \"\",\r\n            \"OccupationGroup\": \"\",\r\n            \"Occupation\": \"Adjunkt, naturvidenskab og teknik\",\r\n            \"Location\": {\r\n                \"Latitude\": 56.4883,\r\n                \"Longitude\": 9.5833\r\n            },\r\n            \"JoblogWorkTime\": {\r\n                \"WorkHour\": null,\r\n                \"DailyWorkTime\": null\r\n            },\r\n            \"WorkplaceID\": 100437,\r\n            \"OrganisationId\": \"90880\",\r\n            \"HiringOrgCVR\": 31119103,\r\n            \"UserLoggedIn\": false,\r\n            \"AnonymousEmployer\": false,\r\n            \"ShareUrl\": \"https://job.jobnet.dk/CV/FindWork/DetailsSocialmedia/5383212\",\r\n            \"DetailsUrl\": \"https://job.jobnet.dk/CV/FindWork/DetailsWidk/5383212\",\r\n            \"JobLogUrl\": \"https://job.jobnet.dk/CV/FindWork/Details/5383212\",\r\n            \"HasLocationValues\": true,\r\n            \"ID\": \"5383212\",\r\n            \"Latitude\": 56.4883,\r\n            \"Longitude\": 9.5833\r\n        }",
                    title: "Tenure track assistant professor in applied statistics",
                    presentation: "Department of Agroecology, Aarhus University, invites applications for a tenure track position in applied statistics.<br><br>The main activity will be research and support in statistical methods and",
                    hiringOrgName: "Aarhus Universitet",
                    workPlaceAddress: "Blichers Alle 20",
                    workPlacePostalCode: 8830,
                    workPlaceCity: "Tjele",
                    postingCreated: new DateTime(2021, 07, 02),
                    lastDateApplication: new DateTime(2021, 08, 13),
                    url: "https://job.jobnet.dk/CV/FindWork/Details/5383212",
                    region: "Midtjylland",
                    municipality: "Viborg",
                    country: "Danmark",
                    employmentType: "",
                    workHours: "Fuldtid",
                    occupation: "Adjunkt, naturvidenskab og teknik",
                    workplaceId: 100437,
                    organisationId: 90880,
                    hiringOrgCVR: 31119103,
                    id: 5383212,
                    workPlaceCityWithoutZone: "Tjele",
                    jobPostingNumber: 10,
                    jobPostingId: "5383212tenuretrackassistantprofessorin"
                );
        internal static JobPostingExtended Shared_JobPage01_JobPostingExtended10
            = new JobPostingExtended(
                    jobPosting: Shared_JobPage01_JobPosting10,
                    response: Shared_FakeResponse,                      // Ignored
                    hiringOrgDescription: null,
                    publicationStartDate: null,
                    publicationEndDate: null,
                    purpose: Shared_FakePurpose,                        // Ignored
                    numberToFill: null,
                    contactEmail: null,
                    contactPersonName: null,
                    employmentDate: null,
                    applicationDeadlineDate: null,
                    bulletPoints: new HashSet<string>()
                    {
                        "PhD degree and post doc research experience within applied statistics or similar aspects",
                        "Proven publication record in international peer-reviewed ISI journals",
                        "Strong expertise in classical statistical methods (analysis of variance, regression analysis, mixed model analysis, generalized linear models, categorical data analysis, non-parametric analysis, multivariate data analysis) and in areas such as spatial statistics, image analysis, time series analysis and machine learning. We are aware that candidates may not have strong expertise in all areas, but we expect the applicant to have at least some knowledge in the areas mentioned.",
                        "The ability to manage, participate, collaborate and communicate in interdisciplinary research, and to participate in joint projects with other scientists.",
                        "Skills in clearly communicating statistical methods and results to persons with non-statistical background.",
                        "attract outstanding talented individuals that are competitive at an international level",
                        "to promote the early development of independent research success early in the career of scientists",
                        "to create transparency in the academic career path",
                        "access to research infrastructure",
                        "capability development, including postgraduate teacher training",
                        "a mentoring programme",
                        "support to develop scientific networks and to secure interdisciplinary research at the highest level"
                    },
                    bulletPointScenario: "generic"
                );

        internal static JobPosting Shared_JobPage01_JobPosting11
            = new JobPosting(
                    runId: Shared_FakeRunId,
                    pageNumber: 1,
                    response: "{\r\n            \"AutomatchType\": 0,\r\n            \"Abroad\": false,\r\n            \"Weight\": 1.0,\r\n            \"Title\": \"Committed employees for assembling displays in a large warehouse in Hedensted.\",\r\n            \"JobHeadline\": \"Committed employees for assembling displays in a large warehouse in Hedensted.\",\r\n            \"Presentation\": \" Our costumer is busy and they need employees to help in their warehouse. \\n  We offer  \\n \\n Work in a large international company \\n Possibility of day shifts\",\r\n            \"HiringOrgName\": \"TeamVikaren.dk, Århus ApS, Horsens Afdeling\",\r\n            \"WorkPlaceAddress\": \"\",\r\n            \"WorkPlacePostalCode\": \"8722\",\r\n            \"WorkPlaceCity\": \"Hedensted\",\r\n            \"WorkPlaceOtherAddress\": true,\r\n            \"WorkPlaceAbroad\": false,\r\n            \"WorkPlaceNotStatic\": false,\r\n            \"UseWorkPlaceAddressForJoblog\": false,\r\n            \"PostingCreated\": \"2021-07-02T00:00:00\",\r\n            \"LastDateApplication\": \"2021-07-29T00:00:00\",\r\n            \"FormattedLastDateApplication\": \"29. juli 2021\",\r\n            \"AssignmentStartDate\": \"0001-01-01T00:00:00\",\r\n            \"IsHotjob\": false,\r\n            \"IsExternal\": false,\r\n            \"Url\": \"https://job.jobnet.dk/CV/FindWork/Details/5361275\",\r\n            \"Region\": \"Midtjylland\",\r\n            \"Municipality\": \"Hedensted\",\r\n            \"Country\": \"Danmark\",\r\n            \"PostalCode\": \"8722\",\r\n            \"PostalCodeName\": null,\r\n            \"JobAnnouncementType\": \"\",\r\n            \"EmploymentType\": \"\",\r\n            \"WorkHours\": \"Fuldtid\",\r\n            \"OccupationArea\": \"\",\r\n            \"OccupationGroup\": \"\",\r\n            \"Occupation\": \"Lager- og logistikmedarbejder\",\r\n            \"Location\": {\r\n                \"Latitude\": 55.7651,\r\n                \"Longitude\": 9.7113\r\n            },\r\n            \"JoblogWorkTime\": {\r\n                \"WorkHour\": null,\r\n                \"DailyWorkTime\": \"Dag\"\r\n            },\r\n            \"WorkplaceID\": 126565,\r\n            \"OrganisationId\": \"71174\",\r\n            \"HiringOrgCVR\": 30899695,\r\n            \"UserLoggedIn\": false,\r\n            \"AnonymousEmployer\": false,\r\n            \"ShareUrl\": \"https://job.jobnet.dk/CV/FindWork/DetailsSocialmedia/5361275\",\r\n            \"DetailsUrl\": \"https://job.jobnet.dk/CV/FindWork/DetailsWidk/5361275\",\r\n            \"JobLogUrl\": \"https://job.jobnet.dk/CV/FindWork/Details/5361275\",\r\n            \"HasLocationValues\": true,\r\n            \"ID\": \"5361275\",\r\n            \"Latitude\": 55.7651,\r\n            \"Longitude\": 9.7113\r\n        }",
                    title: "Committed employees for assembling displays in a large warehouse in Hedensted.",
                    presentation: " Our costumer is busy and they need employees to help in their warehouse. \n  We offer  \n \n Work in a large international company \n Possibility of day shifts",
                    hiringOrgName: "TeamVikaren.dk, Århus ApS, Horsens Afdeling",
                    workPlaceAddress: "",
                    workPlacePostalCode: 8722,
                    workPlaceCity: "Hedensted",
                    postingCreated: new DateTime(2021, 07, 02),
                    lastDateApplication: new DateTime(2021, 07, 29),
                    url: "https://job.jobnet.dk/CV/FindWork/Details/5361275",
                    region: "Midtjylland",
                    municipality: "Hedensted",
                    country: "Danmark",
                    employmentType: "",
                    workHours: "Fuldtid",
                    occupation: "Lager- og logistikmedarbejder",
                    workplaceId: 126565,
                    organisationId: 71174,
                    hiringOrgCVR: 30899695,
                    id: 5361275,
                    workPlaceCityWithoutZone: "Hedensted",
                    jobPostingNumber: 11,
                    jobPostingId: "5361275committedemployeesforassemblingdisplays"
                );
        internal static JobPostingExtended Shared_JobPage01_JobPostingExtended11
            = new JobPostingExtended(
                    jobPosting: Shared_JobPage01_JobPosting11,
                    response: Shared_FakeResponse,                      // Ignored
                    hiringOrgDescription: null,
                    publicationStartDate: new DateTime(2021, 07, 02),
                    publicationEndDate: new DateTime(2021, 07, 29),
                    purpose: Shared_FakePurpose,                        // Ignored
                    numberToFill: 1,
                    contactEmail: null,
                    contactPersonName: "Majken Lorentzen",
                    employmentDate: null,
                    applicationDeadlineDate: new DateTime(2021, 07, 29),
                    bulletPoints: new HashSet<string>()
                    {
                        "Work in a large international company",
                        "Possibility of day shifts",
                        "A social workplace with good colleagues",
                        "Thorough training",
                        "You are flexible during busy periods",
                        "You have an eye for detail",
                        "You can work full time",
                        "You can work independently",
                        "You are thorough and take pride in your work"
                    },
                    bulletPointScenario: "generic"
                );

        internal static JobPosting Shared_JobPage01_JobPosting12
            = new JobPosting(
                    runId: Shared_FakeRunId,
                    pageNumber: 1,
                    response: "{\r\n            \"AutomatchType\": 0,\r\n            \"Abroad\": false,\r\n            \"Weight\": 1.0,\r\n            \"Title\": \"We are looking for forklift drivers for temporary positions during the summer in Skanderborg, Horsens and Fredericia\",\r\n            \"JobHeadline\": \"We are looking for forklift drivers for temporary positions during the summer in Skanderborg, Horsens and Fredericia\",\r\n            \"Presentation\": \"<p>We are looking for forklift drivers for temporary positions during the summer in Skanderborg, Horsens and Fredericia</p>\\n\",\r\n            \"HiringOrgName\": \"TeamVikaren.dk, Århus ApS, Horsens Afdeling\",\r\n            \"WorkPlaceAddress\": \"\",\r\n            \"WorkPlacePostalCode\": \"8700\",\r\n            \"WorkPlaceCity\": \"Horsens\",\r\n            \"WorkPlaceOtherAddress\": false,\r\n            \"WorkPlaceAbroad\": false,\r\n            \"WorkPlaceNotStatic\": false,\r\n            \"UseWorkPlaceAddressForJoblog\": true,\r\n            \"PostingCreated\": \"2021-07-02T00:00:00\",\r\n            \"LastDateApplication\": \"2021-07-28T00:00:00\",\r\n            \"FormattedLastDateApplication\": \"28. juli 2021\",\r\n            \"AssignmentStartDate\": \"0001-01-01T00:00:00\",\r\n            \"IsHotjob\": false,\r\n            \"IsExternal\": false,\r\n            \"Url\": \"https://job.jobnet.dk/CV/FindWork/Details/5359775\",\r\n            \"Region\": \"Midtjylland\",\r\n            \"Municipality\": \"Horsens\",\r\n            \"Country\": \"Danmark\",\r\n            \"PostalCode\": \"8700\",\r\n            \"PostalCodeName\": null,\r\n            \"JobAnnouncementType\": \"\",\r\n            \"EmploymentType\": \"\",\r\n            \"WorkHours\": \"Fuldtid\",\r\n            \"OccupationArea\": \"\",\r\n            \"OccupationGroup\": \"\",\r\n            \"Occupation\": \"Truckfører\",\r\n            \"Location\": {\r\n                \"Latitude\": 55.866,\r\n                \"Longitude\": 9.893\r\n            },\r\n            \"JoblogWorkTime\": {\r\n                \"WorkHour\": null,\r\n                \"DailyWorkTime\": \"Dag, aften, nat\"\r\n            },\r\n            \"WorkplaceID\": 126565,\r\n            \"OrganisationId\": \"71174\",\r\n            \"HiringOrgCVR\": 30899695,\r\n            \"UserLoggedIn\": false,\r\n            \"AnonymousEmployer\": false,\r\n            \"ShareUrl\": \"https://job.jobnet.dk/CV/FindWork/DetailsSocialmedia/5359775\",\r\n            \"DetailsUrl\": \"https://job.jobnet.dk/CV/FindWork/DetailsWidk/5359775\",\r\n            \"JobLogUrl\": \"https://job.jobnet.dk/CV/FindWork/Details/5359775\",\r\n            \"HasLocationValues\": true,\r\n            \"ID\": \"5359775\",\r\n            \"Latitude\": 55.866,\r\n            \"Longitude\": 9.893\r\n        }",
                    title: "We are looking for forklift drivers for temporary positions during the summer in Skanderborg, Horsens and Fredericia",
                    presentation: "<p>We are looking for forklift drivers for temporary positions during the summer in Skanderborg, Horsens and Fredericia</p>\n",
                    hiringOrgName: "TeamVikaren.dk, Århus ApS, Horsens Afdeling",
                    workPlaceAddress: "",
                    workPlacePostalCode: 8700,
                    workPlaceCity: "Horsens",
                    postingCreated: new DateTime(2021, 07, 02),
                    lastDateApplication: new DateTime(2021, 07, 28),
                    url: "https://job.jobnet.dk/CV/FindWork/Details/5359775",
                    region: "Midtjylland",
                    municipality: "Horsens",
                    country: "Danmark",
                    employmentType: "",
                    workHours: "Fuldtid",
                    occupation: "Truckfører",
                    workplaceId: 126565,
                    organisationId: 71174,
                    hiringOrgCVR: 30899695,
                    id: 5359775,
                    workPlaceCityWithoutZone: "Horsens",
                    jobPostingNumber: 12,
                    jobPostingId: "5359775wearelookingforforklift"
                );
        internal static JobPostingExtended Shared_JobPage01_JobPostingExtended12
            = new JobPostingExtended(
                    jobPosting: Shared_JobPage01_JobPosting12,
                    response: Shared_FakeResponse,                      // Ignored
                    hiringOrgDescription: null,
                    publicationStartDate: new DateTime(2021, 07, 02),
                    publicationEndDate: new DateTime(2021, 07, 28),
                    purpose: Shared_FakePurpose,                        // Ignored
                    numberToFill: 6,
                    contactEmail: null,
                    contactPersonName: "Majken Lorentzen",
                    employmentDate: null,
                    applicationDeadlineDate: new DateTime(2021, 07, 28),
                    bulletPoints: new HashSet<string>()
                    {
                        "Good work conditions",
                        "A social workplace with good colleagues",
                        "Flexibility regarding shifts",
                        "Possibility for day shifts, evening shifts and night shifts.",
                        "You want to work in warehousing and logistics",
                        "You are flexible",
                        "You can work a minimum of 3 weeks in the period week 24 - 34",
                        "You can work either day, evening or night shift",
                        "You have experience with forklift driving",
                        "You like working in teams",
                        "in Horsens from 06.00–14.00 or 07.00-15.00",
                        "in Skanderborg from 08.00-16.00",
                        "in Fredericia from 06.00-14.00",
                        "in Horsens from00-22.00 / 15.00-23.00",
                        "in Skanderborg from 15.00-23.00",
                        "in Horsens from 22.00-06.00",
                        "in Skanderborg from 22.00-06.00",
                        "in Fredericia from 23.00-06.30",
                        "Uporządkowane warunki",
                        "Socjalne miejsce pracy z dobrymi kolegami",
                        "Elastyczność w zakresie zmian pracy",
                        "Możliwość pracy na zmianach dziennych, wieczornych i nocnych.",
                        "Masz ochotę pracować w magazynach i logistyce",
                        "Jesteś elastyczny",
                        "Możesz pracować minimum 3 tygodnie w okresie od 24 do 34 tygodnia",
                        "Możesz pracować na dziennej, wieczornej lub nocnej zmianie",
                        "Masz doświadczenie w prowadzeniu wózka widłowego",
                        "Lubisz prace w grupach",
                        "Potrafisz mówić ,czytać i rozumieć duński lub angielski",
                        "w Horsens w 06.00-14.00 / 07.00-15.00",
                        "w Skanderborgu w 08.00-16.00",
                        "w Fredericii w 06.00-14.00",
                        "w Horsens w 14.00-22.00 / 15.00-23.00",
                        "w Skanderborgu w 15.00-23.00",
                        "w Horsens w 22.00-06.00",
                        "w Skanderborgu w 22.00-06.00",
                        "w Fredericii w 23.00-06.30"
                    },
                    bulletPointScenario: "generic"
                );

        internal static JobPosting Shared_JobPage01_JobPosting13
            = new JobPosting(
                    runId: Shared_FakeRunId,
                    pageNumber: 1,
                    response: "{\r\n            \"AutomatchType\": 0,\r\n            \"Abroad\": false,\r\n            \"Weight\": 1.0,\r\n            \"Title\": \"Laboratory technician for plant analysis and microbiology, Department of Food Science, Aarhus University\",\r\n            \"JobHeadline\": \"Laboratory technician for plant analysis and microbiology, Department of Food Science, Aarhus University\",\r\n            \"Presentation\": \"At the Department of Food Science, the Science Team for Food Technology (FT), a full-time position as a laboratory technician is available for appointment as from 15 September 2021 or soon thereafter.\",\r\n            \"HiringOrgName\": \"Aarhus Universitet\",\r\n            \"WorkPlaceAddress\": \"Ag\",\r\n            \"WorkPlacePostalCode\": \"8200\",\r\n            \"WorkPlaceCity\": \"Aarhus N\",\r\n            \"WorkPlaceOtherAddress\": false,\r\n            \"WorkPlaceAbroad\": false,\r\n            \"WorkPlaceNotStatic\": false,\r\n            \"UseWorkPlaceAddressForJoblog\": true,\r\n            \"PostingCreated\": \"2021-07-02T00:00:00\",\r\n            \"LastDateApplication\": \"2021-08-02T00:00:00\",\r\n            \"FormattedLastDateApplication\": \"2. august 2021\",\r\n            \"AssignmentStartDate\": \"0001-01-01T00:00:00\",\r\n            \"IsHotjob\": false,\r\n            \"IsExternal\": false,\r\n            \"Url\": \"https://job.jobnet.dk/CV/FindWork/Details/5383201\",\r\n            \"Region\": \"Midtjylland\",\r\n            \"Municipality\": \"Aarhus\",\r\n            \"Country\": \"Danmark\",\r\n            \"PostalCode\": \"8200\",\r\n            \"PostalCodeName\": null,\r\n            \"JobAnnouncementType\": \"\",\r\n            \"EmploymentType\": \"\",\r\n            \"WorkHours\": \"Fuldtid\",\r\n            \"OccupationArea\": \"\",\r\n            \"OccupationGroup\": \"\",\r\n            \"Occupation\": \"Laboratorietekniker\",\r\n            \"Location\": {\r\n                \"Latitude\": 56.2017,\r\n                \"Longitude\": 10.1592\r\n            },\r\n            \"JoblogWorkTime\": {\r\n                \"WorkHour\": null,\r\n                \"DailyWorkTime\": null\r\n            },\r\n            \"WorkplaceID\": 0,\r\n            \"OrganisationId\": \"90880\",\r\n            \"HiringOrgCVR\": 31119103,\r\n            \"UserLoggedIn\": false,\r\n            \"AnonymousEmployer\": false,\r\n            \"ShareUrl\": \"https://job.jobnet.dk/CV/FindWork/DetailsSocialmedia/5383201\",\r\n            \"DetailsUrl\": \"https://job.jobnet.dk/CV/FindWork/DetailsWidk/5383201\",\r\n            \"JobLogUrl\": \"https://job.jobnet.dk/CV/FindWork/Details/5383201\",\r\n            \"HasLocationValues\": true,\r\n            \"ID\": \"5383201\",\r\n            \"Latitude\": 56.2017,\r\n            \"Longitude\": 10.1592\r\n        }",
                    title: "Laboratory technician for plant analysis and microbiology, Department of Food Science, Aarhus University",
                    presentation: "At the Department of Food Science, the Science Team for Food Technology (FT), a full-time position as a laboratory technician is available for appointment as from 15 September 2021 or soon thereafter.",
                    hiringOrgName: "Aarhus Universitet",
                    workPlaceAddress: "Ag",
                    workPlacePostalCode: 8200,
                    workPlaceCity: "Aarhus N",
                    postingCreated: new DateTime(2021, 07, 02),
                    lastDateApplication: new DateTime(2021, 08, 02),
                    url: "https://job.jobnet.dk/CV/FindWork/Details/5383201",
                    region: "Midtjylland",
                    municipality: "Aarhus",
                    country: "Danmark",
                    employmentType: "",
                    workHours: "Fuldtid",
                    occupation: "Laboratorietekniker",
                    workplaceId: 0,
                    organisationId: 90880,
                    hiringOrgCVR: 31119103,
                    id: 5383201,
                    workPlaceCityWithoutZone: "Aarhus",
                    jobPostingNumber: 13,
                    jobPostingId: "5383201laboratorytechnicianforplantanalysis"
                );
        internal static JobPostingExtended Shared_JobPage01_JobPostingExtended13
            = new JobPostingExtended(
                    jobPosting: Shared_JobPage01_JobPosting13,
                    response: Shared_FakeResponse,                      // Ignored
                    hiringOrgDescription: null,
                    publicationStartDate: null,
                    publicationEndDate: null,
                    purpose: Shared_FakePurpose,                        // Ignored
                    numberToFill: null,
                    contactEmail: null,
                    contactPersonName: null,
                    employmentDate: null,
                    applicationDeadlineDate: null,
                    bulletPoints: new HashSet<string>()
                    {
                        "Analysis of plant ingredients e.g. phenols, carbohydrates, polyacetylenes, glucosinolates, etc. using HPLC, GC-MS, and IC",
                        "Microbiology",
                        "Laboratory guidance of students and researchers",
                        "Method development",
                        "Sample collection, sample preparation and data processing",
                        "Maintenance of various analysis equipment and laboratory management",
                        "Photography in studios and ‘on the spot’ plants, plant products and experimental setup as documentation of the experimental work."
                    },
                    bulletPointScenario: "generic"
                );

        internal static JobPosting Shared_JobPage01_JobPosting14
            = new JobPosting(
                    runId: Shared_FakeRunId,
                    pageNumber: 1,
                    response: "{\r\n            \"AutomatchType\": 0,\r\n            \"Abroad\": false,\r\n            \"Weight\": 1.0,\r\n            \"Title\": \"Laboratory technician for food processing and ingredients analysis, Department of Food Science, Aarhus University\",\r\n            \"JobHeadline\": \"Laboratory technician for food processing and ingredients analysis, Department of Food Science, Aarhus University\",\r\n            \"Presentation\": \"At the Department of Food Science, the Science Team for Food Technology (FT), a full-time position as a laboratory technician is available for appointment as from 15 September 2021 or soon thereafter.\",\r\n            \"HiringOrgName\": \"Aarhus Universitet\",\r\n            \"WorkPlaceAddress\": \"Agro Food Park 48\",\r\n            \"WorkPlacePostalCode\": \"8200\",\r\n            \"WorkPlaceCity\": \"Aarhus N\",\r\n            \"WorkPlaceOtherAddress\": false,\r\n            \"WorkPlaceAbroad\": false,\r\n            \"WorkPlaceNotStatic\": false,\r\n            \"UseWorkPlaceAddressForJoblog\": true,\r\n            \"PostingCreated\": \"2021-07-02T00:00:00\",\r\n            \"LastDateApplication\": \"2021-08-02T00:00:00\",\r\n            \"FormattedLastDateApplication\": \"2. august 2021\",\r\n            \"AssignmentStartDate\": \"0001-01-01T00:00:00\",\r\n            \"IsHotjob\": false,\r\n            \"IsExternal\": false,\r\n            \"Url\": \"https://job.jobnet.dk/CV/FindWork/Details/5383195\",\r\n            \"Region\": \"Midtjylland\",\r\n            \"Municipality\": \"Aarhus\",\r\n            \"Country\": \"Danmark\",\r\n            \"PostalCode\": \"8200\",\r\n            \"PostalCodeName\": null,\r\n            \"JobAnnouncementType\": \"\",\r\n            \"EmploymentType\": \"\",\r\n            \"WorkHours\": \"Fuldtid\",\r\n            \"OccupationArea\": \"\",\r\n            \"OccupationGroup\": \"\",\r\n            \"Occupation\": \"Laboratorietekniker\",\r\n            \"Location\": {\r\n                \"Latitude\": 56.1985,\r\n                \"Longitude\": 10.1558\r\n            },\r\n            \"JoblogWorkTime\": {\r\n                \"WorkHour\": null,\r\n                \"DailyWorkTime\": null\r\n            },\r\n            \"WorkplaceID\": 0,\r\n            \"OrganisationId\": \"90880\",\r\n            \"HiringOrgCVR\": 31119103,\r\n            \"UserLoggedIn\": false,\r\n            \"AnonymousEmployer\": false,\r\n            \"ShareUrl\": \"https://job.jobnet.dk/CV/FindWork/DetailsSocialmedia/5383195\",\r\n            \"DetailsUrl\": \"https://job.jobnet.dk/CV/FindWork/DetailsWidk/5383195\",\r\n            \"JobLogUrl\": \"https://job.jobnet.dk/CV/FindWork/Details/5383195\",\r\n            \"HasLocationValues\": true,\r\n            \"ID\": \"5383195\",\r\n            \"Latitude\": 56.1985,\r\n            \"Longitude\": 10.1558\r\n        }",
                    title: "Laboratory technician for food processing and ingredients analysis, Department of Food Science, Aarhus University",
                    presentation: "At the Department of Food Science, the Science Team for Food Technology (FT), a full-time position as a laboratory technician is available for appointment as from 15 September 2021 or soon thereafter.",
                    hiringOrgName: "Aarhus Universitet",
                    workPlaceAddress: "Agro Food Park 48",
                    workPlacePostalCode: 8200,
                    workPlaceCity: "Aarhus N",
                    postingCreated: new DateTime(2021, 07, 02),
                    lastDateApplication: new DateTime(2021, 08, 02),
                    url: "https://job.jobnet.dk/CV/FindWork/Details/5383195",
                    region: "Midtjylland",
                    municipality: "Aarhus",
                    country: "Danmark",
                    employmentType: "",
                    workHours: "Fuldtid",
                    occupation: "Laboratorietekniker",
                    workplaceId: 0,
                    organisationId: 90880,
                    hiringOrgCVR: 31119103,
                    id: 5383195,
                    workPlaceCityWithoutZone: "Aarhus",
                    jobPostingNumber: 14,
                    jobPostingId: "5383195laboratorytechnicianforfoodprocessing"
                );
        internal static JobPostingExtended Shared_JobPage01_JobPostingExtended14
            = new JobPostingExtended(
                    jobPosting: Shared_JobPage01_JobPosting14,
                    response: Shared_FakeResponse,                      // Ignored
                    hiringOrgDescription: null,
                    publicationStartDate: null,
                    publicationEndDate: null,
                    purpose: Shared_FakePurpose,                        // Ignored
                    numberToFill: null,
                    contactEmail: null,
                    contactPersonName: null,
                    employmentDate: null,
                    applicationDeadlineDate: null,
                    bulletPoints: new HashSet<string>()
                    {
                        "Analysis with ICP-MS and HPLC",
                        "Working with food processing in laboratory / pilot scale",
                        "Laboratory guidance of students and researchers",
                        "Method development",
                        "Sample collection, sample preparation and data processing",
                        "Maintenance of various analysis equipment and laboratory management",
                        "Purchase of consumables and minor equipment for the laboratory."
                    },
                    bulletPointScenario: "generic"
                );

        internal static JobPosting Shared_JobPage01_JobPosting15
            = new JobPosting(
                    runId: Shared_FakeRunId,
                    pageNumber: 1,
                    response: "{\r\n            \"AutomatchType\": 0,\r\n            \"Abroad\": false,\r\n            \"Weight\": 1.0,\r\n            \"Title\": \"Lagermedarbejdere til pakkeopgaver på daghold i Horsens / Warehouse worker for packing line on day shifts in Horsens\",\r\n            \"JobHeadline\": \"Lagermedarbejdere til pakkeopgaver på daghold i Horsens / Warehouse worker for packing line on day shifts in Horsens\",\r\n            \"Presentation\": \"<p><strong>English version below the Danish</strong>\u00A0 \u00A0 \u00A0 \u00A0 \u00A0 \u00A0 \u00A0 \u00A0 \u00A0 \u00A0 \u00A0 \u00A0 \u00A0 \u00A0 \u00A0 \u00A0 \u00A0 \u00A0 \u00A0 \u00A0 \u00A0 \u00A0 \u00A0 \u00A0 \u00A0 \u00A0</p>\\n<p>Har du lyst til at arbejde inden for lager, og kan du lige aktivt arbejde, så se her.</p>\",\r\n            \"HiringOrgName\": \"TeamVikaren.dk, Århus ApS, Horsens Afdeling\",\r\n            \"WorkPlaceAddress\": \"\",\r\n            \"WorkPlacePostalCode\": \"8700\",\r\n            \"WorkPlaceCity\": \"Horsens\",\r\n            \"WorkPlaceOtherAddress\": false,\r\n            \"WorkPlaceAbroad\": false,\r\n            \"WorkPlaceNotStatic\": false,\r\n            \"UseWorkPlaceAddressForJoblog\": true,\r\n            \"PostingCreated\": \"2021-07-02T00:00:00\",\r\n            \"LastDateApplication\": \"2021-08-27T00:00:00\",\r\n            \"FormattedLastDateApplication\": \"27. august 2021\",\r\n            \"AssignmentStartDate\": \"0001-01-01T00:00:00\",\r\n            \"IsHotjob\": false,\r\n            \"IsExternal\": false,\r\n            \"Url\": \"https://job.jobnet.dk/CV/FindWork/Details/5383165\",\r\n            \"Region\": \"Midtjylland\",\r\n            \"Municipality\": \"Horsens\",\r\n            \"Country\": \"Danmark\",\r\n            \"PostalCode\": \"8700\",\r\n            \"PostalCodeName\": null,\r\n            \"JobAnnouncementType\": \"\",\r\n            \"EmploymentType\": \"\",\r\n            \"WorkHours\": \"Fuldtid\",\r\n            \"OccupationArea\": \"\",\r\n            \"OccupationGroup\": \"\",\r\n            \"Occupation\": \"Lager- og logistikmedarbejder\",\r\n            \"Location\": {\r\n                \"Latitude\": 55.866,\r\n                \"Longitude\": 9.893\r\n            },\r\n            \"JoblogWorkTime\": {\r\n                \"WorkHour\": null,\r\n                \"DailyWorkTime\": \"Dag\"\r\n            },\r\n            \"WorkplaceID\": 126565,\r\n            \"OrganisationId\": \"71174\",\r\n            \"HiringOrgCVR\": 30899695,\r\n            \"UserLoggedIn\": false,\r\n            \"AnonymousEmployer\": false,\r\n            \"ShareUrl\": \"https://job.jobnet.dk/CV/FindWork/DetailsSocialmedia/5383165\",\r\n            \"DetailsUrl\": \"https://job.jobnet.dk/CV/FindWork/DetailsWidk/5383165\",\r\n            \"JobLogUrl\": \"https://job.jobnet.dk/CV/FindWork/Details/5383165\",\r\n            \"HasLocationValues\": true,\r\n            \"ID\": \"5383165\",\r\n            \"Latitude\": 55.866,\r\n            \"Longitude\": 9.893\r\n        }",
                    title: "Lagermedarbejdere til pakkeopgaver på daghold i Horsens / Warehouse worker for packing line on day shifts in Horsens",
                    presentation: "<p><strong>English version below the Danish</strong>\u00A0 \u00A0 \u00A0 \u00A0 \u00A0 \u00A0 \u00A0 \u00A0 \u00A0 \u00A0 \u00A0 \u00A0 \u00A0 \u00A0 \u00A0 \u00A0 \u00A0 \u00A0 \u00A0 \u00A0 \u00A0 \u00A0 \u00A0 \u00A0 \u00A0 \u00A0</p>\n<p>Har du lyst til at arbejde inden for lager, og kan du lige aktivt arbejde, så se her.</p>",
                    hiringOrgName: "TeamVikaren.dk, Århus ApS, Horsens Afdeling",
                    workPlaceAddress: "",
                    workPlacePostalCode: 8700,
                    workPlaceCity: "Horsens",
                    postingCreated: new DateTime(2021, 07, 02),
                    lastDateApplication: new DateTime(2021, 08, 27),
                    url: "https://job.jobnet.dk/CV/FindWork/Details/5383165",
                    region: "Midtjylland",
                    municipality: "Horsens",
                    country: "Danmark",
                    employmentType: "",
                    workHours: "Fuldtid",
                    occupation: "Lager- og logistikmedarbejder",
                    workplaceId: 126565,
                    organisationId: 71174,
                    hiringOrgCVR: 30899695,
                    id: 5383165,
                    workPlaceCityWithoutZone: "Horsens",
                    jobPostingNumber: 15,
                    jobPostingId: "5383165lagermedarbejderetilpakkeopgaverpdaghold"
                );
        internal static JobPostingExtended Shared_JobPage01_JobPostingExtended15
            = new JobPostingExtended(
                    jobPosting: Shared_JobPage01_JobPosting15,
                    response: Shared_FakeResponse,                      // Ignored
                    hiringOrgDescription: null,
                    publicationStartDate: new DateTime(2021, 07, 02),
                    publicationEndDate: new DateTime(2021, 08, 27),
                    purpose: Shared_FakePurpose,                        // Ignored
                    numberToFill: 1,
                    contactEmail: null,
                    contactPersonName: "Majken Lorentzen",
                    employmentDate: null,
                    applicationDeadlineDate: new DateTime(2021, 08, 27),
                    bulletPoints: null,
                    bulletPointScenario: null
                );

        internal static JobPosting Shared_JobPage01_JobPosting16
            = new JobPosting(
                    runId: Shared_FakeRunId,
                    pageNumber: 1,
                    response: "{\r\n            \"AutomatchType\": 0,\r\n            \"Abroad\": false,\r\n            \"Weight\": 1.0,\r\n            \"Title\": \"Motivated employee for emptying containers in a warehouse in Horsens, start-up as soon as possible\",\r\n            \"JobHeadline\": \"Motivated employee for emptying containers in a warehouse in Horsens, start-up as soon as possible\",\r\n            \"Presentation\": \" Do you like active work, do you prefer to work morning shifts? Then we have the job for you. \\n  We offer  \\n \\n A social workplace \\n Active work \\n\",\r\n            \"HiringOrgName\": \"TeamVikaren.dk, Århus ApS, Horsens Afdeling\",\r\n            \"WorkPlaceAddress\": \"\",\r\n            \"WorkPlacePostalCode\": \"8700\",\r\n            \"WorkPlaceCity\": \"Horsens\",\r\n            \"WorkPlaceOtherAddress\": false,\r\n            \"WorkPlaceAbroad\": false,\r\n            \"WorkPlaceNotStatic\": false,\r\n            \"UseWorkPlaceAddressForJoblog\": true,\r\n            \"PostingCreated\": \"2021-07-02T00:00:00\",\r\n            \"LastDateApplication\": \"2021-07-12T00:00:00\",\r\n            \"FormattedLastDateApplication\": \"12. juli 2021\",\r\n            \"AssignmentStartDate\": \"0001-01-01T00:00:00\",\r\n            \"IsHotjob\": false,\r\n            \"IsExternal\": false,\r\n            \"Url\": \"https://job.jobnet.dk/CV/FindWork/Details/5346333\",\r\n            \"Region\": \"Midtjylland\",\r\n            \"Municipality\": \"Horsens\",\r\n            \"Country\": \"Danmark\",\r\n            \"PostalCode\": \"8700\",\r\n            \"PostalCodeName\": null,\r\n            \"JobAnnouncementType\": \"\",\r\n            \"EmploymentType\": \"\",\r\n            \"WorkHours\": \"Fuldtid\",\r\n            \"OccupationArea\": \"\",\r\n            \"OccupationGroup\": \"\",\r\n            \"Occupation\": \"Lager- og logistikmedarbejder\",\r\n            \"Location\": {\r\n                \"Latitude\": 55.866,\r\n                \"Longitude\": 9.893\r\n            },\r\n            \"JoblogWorkTime\": {\r\n                \"WorkHour\": null,\r\n                \"DailyWorkTime\": \"Dag\"\r\n            },\r\n            \"WorkplaceID\": 126565,\r\n            \"OrganisationId\": \"71174\",\r\n            \"HiringOrgCVR\": 30899695,\r\n            \"UserLoggedIn\": false,\r\n            \"AnonymousEmployer\": false,\r\n            \"ShareUrl\": \"https://job.jobnet.dk/CV/FindWork/DetailsSocialmedia/5346333\",\r\n            \"DetailsUrl\": \"https://job.jobnet.dk/CV/FindWork/DetailsWidk/5346333\",\r\n            \"JobLogUrl\": \"https://job.jobnet.dk/CV/FindWork/Details/5346333\",\r\n            \"HasLocationValues\": true,\r\n            \"ID\": \"5346333\",\r\n            \"Latitude\": 55.866,\r\n            \"Longitude\": 9.893\r\n        }",
                    title: "Motivated employee for emptying containers in a warehouse in Horsens, start-up as soon as possible",
                    presentation: " Do you like active work, do you prefer to work morning shifts? Then we have the job for you. \n  We offer  \n \n A social workplace \n Active work \n",
                    hiringOrgName: "TeamVikaren.dk, Århus ApS, Horsens Afdeling",
                    workPlaceAddress: "",
                    workPlacePostalCode: 8700,
                    workPlaceCity: "Horsens",
                    postingCreated: new DateTime(2021, 07, 02),
                    lastDateApplication: new DateTime(2021, 07, 12),
                    url: "https://job.jobnet.dk/CV/FindWork/Details/5346333",
                    region: "Midtjylland",
                    municipality: "Horsens",
                    country: "Danmark",
                    employmentType: "",
                    workHours: "Fuldtid",
                    occupation: "Lager- og logistikmedarbejder",
                    workplaceId: 126565,
                    organisationId: 71174,
                    hiringOrgCVR: 30899695,
                    id: 5346333,
                    workPlaceCityWithoutZone: "Horsens",
                    jobPostingNumber: 16,
                    jobPostingId: "5346333motivatedemployeeforemptyingcontainers"
                );
        internal static JobPostingExtended Shared_JobPage01_JobPostingExtended16
            = new JobPostingExtended(
                    jobPosting: Shared_JobPage01_JobPosting16,
                    response: Shared_FakeResponse,                      // Ignored
                    hiringOrgDescription: null,
                    publicationStartDate: new DateTime(2021, 07, 02),
                    publicationEndDate: new DateTime(2021, 07, 12),
                    purpose: Shared_FakePurpose,                        // Ignored
                    numberToFill: 5,
                    contactEmail: null,
                    contactPersonName: "Majken Lorentzen",
                    employmentDate: null,
                    applicationDeadlineDate: new DateTime(2021, 07, 12),
                    bulletPoints: new HashSet<string>()
                    {
                        "A social workplace",
                        "Active work",
                        "Day and evening shifts",
                        "A healthy working environment",
                        "Good colleagues",
                        "You would like to work in a warehouse",
                        "You like active and physical work",
                        "You can work full time or part time",
                        "You can work independently"
                    },
                    bulletPointScenario: "generic"
                );

        internal static JobPosting Shared_JobPage01_JobPosting17
            = new JobPosting(
                    runId: Shared_FakeRunId,
                    pageNumber: 1,
                    response: "{\r\n            \"AutomatchType\": 0,\r\n            \"Abroad\": false,\r\n            \"Weight\": 1.0,\r\n            \"Title\": \"Medarbejdere til sommer vikariater på lager i Kolding/Employees for temporary summer positions in a warehouse in Kolding\",\r\n            \"JobHeadline\": \"Medarbejdere til sommer vikariater på lager i Kolding/Employees for temporary summer positions in a warehouse in Kolding\",\r\n            \"Presentation\": \" \u00A0 \\n  English version below the Danish  \\n Har du lyst til at arbejde på lager, og kan du arbejde i perioden 12/7 til 30/9 på daghold, så har vi arbejde til dig. \\n \",\r\n            \"HiringOrgName\": \"TeamVikaren.dk, Århus ApS, Horsens Afdeling\",\r\n            \"WorkPlaceAddress\": \"\",\r\n            \"WorkPlacePostalCode\": \"6000\",\r\n            \"WorkPlaceCity\": \"Kolding\",\r\n            \"WorkPlaceOtherAddress\": true,\r\n            \"WorkPlaceAbroad\": false,\r\n            \"WorkPlaceNotStatic\": false,\r\n            \"UseWorkPlaceAddressForJoblog\": false,\r\n            \"PostingCreated\": \"2021-07-02T00:00:00\",\r\n            \"LastDateApplication\": \"2021-08-19T00:00:00\",\r\n            \"FormattedLastDateApplication\": \"19. august 2021\",\r\n            \"AssignmentStartDate\": \"0001-01-01T00:00:00\",\r\n            \"IsHotjob\": false,\r\n            \"IsExternal\": false,\r\n            \"Url\": \"https://job.jobnet.dk/CV/FindWork/Details/5376709\",\r\n            \"Region\": \"Syddanmark\",\r\n            \"Municipality\": \"Kolding\",\r\n            \"Country\": \"Danmark\",\r\n            \"PostalCode\": \"6000\",\r\n            \"PostalCodeName\": null,\r\n            \"JobAnnouncementType\": \"\",\r\n            \"EmploymentType\": \"\",\r\n            \"WorkHours\": \"Fuldtid\",\r\n            \"OccupationArea\": \"\",\r\n            \"OccupationGroup\": \"\",\r\n            \"Occupation\": \"Lager- og logistikmedarbejder\",\r\n            \"Location\": {\r\n                \"Latitude\": 55.5022,\r\n                \"Longitude\": 9.4685\r\n            },\r\n            \"JoblogWorkTime\": {\r\n                \"WorkHour\": null,\r\n                \"DailyWorkTime\": \"Dag\"\r\n            },\r\n            \"WorkplaceID\": 126565,\r\n            \"OrganisationId\": \"71174\",\r\n            \"HiringOrgCVR\": 30899695,\r\n            \"UserLoggedIn\": false,\r\n            \"AnonymousEmployer\": false,\r\n            \"ShareUrl\": \"https://job.jobnet.dk/CV/FindWork/DetailsSocialmedia/5376709\",\r\n            \"DetailsUrl\": \"https://job.jobnet.dk/CV/FindWork/DetailsWidk/5376709\",\r\n            \"JobLogUrl\": \"https://job.jobnet.dk/CV/FindWork/Details/5376709\",\r\n            \"HasLocationValues\": true,\r\n            \"ID\": \"5376709\",\r\n            \"Latitude\": 55.5022,\r\n            \"Longitude\": 9.4685\r\n        }",
                    title: "Medarbejdere til sommer vikariater på lager i Kolding/Employees for temporary summer positions in a warehouse in Kolding",
                    presentation: " \u00A0 \n  English version below the Danish  \n Har du lyst til at arbejde på lager, og kan du arbejde i perioden 12/7 til 30/9 på daghold, så har vi arbejde til dig. \n ",
                    hiringOrgName: "TeamVikaren.dk, Århus ApS, Horsens Afdeling",
                    workPlaceAddress: "",
                    workPlacePostalCode: 6000,
                    workPlaceCity: "Kolding",
                    postingCreated: new DateTime(2021, 07, 02),
                    lastDateApplication: new DateTime(2021, 08, 19),
                    url: "https://job.jobnet.dk/CV/FindWork/Details/5376709",
                    region: "Syddanmark",
                    municipality: "Kolding",
                    country: "Danmark",
                    employmentType: "",
                    workHours: "Fuldtid",
                    occupation: "Lager- og logistikmedarbejder",
                    workplaceId: 126565,
                    organisationId: 71174,
                    hiringOrgCVR: 30899695,
                    id: 5376709,
                    workPlaceCityWithoutZone: "Kolding",
                    jobPostingNumber: 17,
                    jobPostingId: "5376709medarbejderetilsommervikariaterp"
                );
        internal static JobPostingExtended Shared_JobPage01_JobPostingExtended17
            = new JobPostingExtended(
                    jobPosting: Shared_JobPage01_JobPosting17,
                    response: Shared_FakeResponse,                      // Ignored
                    hiringOrgDescription: null,
                    publicationStartDate: new DateTime(2021, 07, 02),
                    publicationEndDate: new DateTime(2021, 08, 19),
                    purpose: Shared_FakePurpose,                        // Ignored
                    numberToFill: 10,
                    contactEmail: null,
                    contactPersonName: "Majken Lorentzen",
                    employmentDate: null,
                    applicationDeadlineDate: new DateTime(2021, 08, 19),
                    bulletPoints: new HashSet<string>()
                    {
                        "Arbejde på daghold",
                        "Gode kollegaer",
                        "Grundig oplæring",
                        "Mulighed for aktivt arbejde",
                        "Du kan lide aktivt arbejde",
                        "Du kan lide at veksle mellem forskellige arbejdsopgaver",
                        "Du har en god fysik",
                        "Du kan arbejde daghold på fuldtid – deltid kan også arrangeres",
                        "Du er grundig i dit arbejde og har en positiv tilgang til dine arbejdsopgaver",
                        "Du er fleksibel i travle perioder",
                        "Work on day shifts",
                        "Good colleagues",
                        "Thorough training",
                        "Opportunity for active work",
                        "You like active work",
                        "You like to have different work tasks",
                        "You have a good physique",
                        "You can work day shifts full time - part time can also be arranged",
                        "You are thorough in your work and have a positive approach to your work tasks",
                        "You are flexible during busy periods"
                    },
                    bulletPointScenario: "generic"
                );

        internal static JobPosting Shared_JobPage01_JobPosting18
            = new JobPosting(
                    runId: Shared_FakeRunId,
                    pageNumber: 1,
                    response: "{\r\n            \"AutomatchType\": 0,\r\n            \"Abroad\": false,\r\n            \"Weight\": 1.0,\r\n            \"Title\": \"Tenure Track Assistant Professorships in Strategy and Innovation\",\r\n            \"JobHeadline\": \"Tenure Track Assistant Professorships in Strategy and Innovation\",\r\n            \"Presentation\": \"Copenhagen Business School invites applications for a number of Tenure Track Assistant Professorships at the Department of Strategy and Innovation. Expected starting date is 1 September 2022.<br>\",\r\n            \"HiringOrgName\": \"Copenhagen Business School\",\r\n            \"WorkPlaceAddress\": \"Solbjerg Plads 3\",\r\n            \"WorkPlacePostalCode\": \"2000\",\r\n            \"WorkPlaceCity\": \"Frederiksberg\",\r\n            \"WorkPlaceOtherAddress\": false,\r\n            \"WorkPlaceAbroad\": false,\r\n            \"WorkPlaceNotStatic\": false,\r\n            \"UseWorkPlaceAddressForJoblog\": true,\r\n            \"PostingCreated\": \"2021-07-02T00:00:00\",\r\n            \"LastDateApplication\": \"2021-08-23T00:00:00\",\r\n            \"FormattedLastDateApplication\": \"23. august 2021\",\r\n            \"AssignmentStartDate\": \"0001-01-01T00:00:00\",\r\n            \"IsHotjob\": false,\r\n            \"IsExternal\": false,\r\n            \"Url\": \"https://job.jobnet.dk/CV/FindWork/Details/5382809\",\r\n            \"Region\": \"Hovedstaden og Bornholm\",\r\n            \"Municipality\": \"Frederiksberg\",\r\n            \"Country\": \"Danmark\",\r\n            \"PostalCode\": \"2000\",\r\n            \"PostalCodeName\": null,\r\n            \"JobAnnouncementType\": \"\",\r\n            \"EmploymentType\": \"\",\r\n            \"WorkHours\": \"Fuldtid\",\r\n            \"OccupationArea\": \"\",\r\n            \"OccupationGroup\": \"\",\r\n            \"Occupation\": \"Adjunkt, samfundsvidenskab\",\r\n            \"Location\": {\r\n                \"Latitude\": 55.6815,\r\n                \"Longitude\": 12.5304\r\n            },\r\n            \"JoblogWorkTime\": {\r\n                \"WorkHour\": null,\r\n                \"DailyWorkTime\": null\r\n            },\r\n            \"WorkplaceID\": 79401,\r\n            \"OrganisationId\": \"26360\",\r\n            \"HiringOrgCVR\": 19596915,\r\n            \"UserLoggedIn\": false,\r\n            \"AnonymousEmployer\": false,\r\n            \"ShareUrl\": \"https://job.jobnet.dk/CV/FindWork/DetailsSocialmedia/5382809\",\r\n            \"DetailsUrl\": \"https://job.jobnet.dk/CV/FindWork/DetailsWidk/5382809\",\r\n            \"JobLogUrl\": \"https://job.jobnet.dk/CV/FindWork/Details/5382809\",\r\n            \"HasLocationValues\": true,\r\n            \"ID\": \"5382809\",\r\n            \"Latitude\": 55.6815,\r\n            \"Longitude\": 12.5304\r\n        }",
                    title: "Tenure Track Assistant Professorships in Strategy and Innovation",
                    presentation: "Copenhagen Business School invites applications for a number of Tenure Track Assistant Professorships at the Department of Strategy and Innovation. Expected starting date is 1 September 2022.<br>",
                    hiringOrgName: "Copenhagen Business School",
                    workPlaceAddress: "Solbjerg Plads 3",
                    workPlacePostalCode: 2000,
                    workPlaceCity: "Frederiksberg",
                    postingCreated: new DateTime(2021, 07, 02),
                    lastDateApplication: new DateTime(2021, 08, 23),
                    url: "https://job.jobnet.dk/CV/FindWork/Details/5382809",
                    region: "Hovedstaden og Bornholm",
                    municipality: "Frederiksberg",
                    country: "Danmark",
                    employmentType: "",
                    workHours: "Fuldtid",
                    occupation: "Adjunkt, samfundsvidenskab",
                    workplaceId: 79401,
                    organisationId: 26360,
                    hiringOrgCVR: 19596915,
                    id: 5382809,
                    workPlaceCityWithoutZone: "Frederiksberg",
                    jobPostingNumber: 18,
                    jobPostingId: "5382809tenuretrackassistantprofessorshipsin"
                );
        internal static JobPostingExtended Shared_JobPage01_JobPostingExtended18
            = new JobPostingExtended(
                    jobPosting: Shared_JobPage01_JobPosting18,
                    response: Shared_FakeResponse,                      // Ignored
                    hiringOrgDescription: null,
                    publicationStartDate: null,
                    publicationEndDate: null,
                    purpose: Shared_FakePurpose,                        // Ignored
                    numberToFill: null,
                    contactEmail: null,
                    contactPersonName: null,
                    employmentDate: null,
                    applicationDeadlineDate: null,
                    bulletPoints: new HashSet<string>()
                    {
                        "Teaching and examination in various study programs",
                        "Development of existing and or new study programs",
                        "Individual and group based research activities of high international standard",
                        "Promotion of CBS’s academic reputation",
                        "Communicating findings to the public in general and to CBS’s stakeholders in particular",
                        "Responsibility for publishing, scientific communication and research-based teaching",
                        "Attracting external funding opportunities",
                        "A cover letter",
                        "Proof of qualifications and a full CV",
                        "Documentation of relevant, significant, original research at an international level, including publications in the field’s internationally recognized journals and citations in the Social Science Citation Index and/or Google Scholar",
                        "Documentation of pedagogical qualifications or other material for the evaluation of his/her pedagogical level * Information indicating experience in research management, industry co-operation and international co-operation",
                        "A complete, numbered list of publications (indicating titles, co-authors, page numbers and year) with an * marking of the academic productions to be considered during the review. A maximum of 10 publications for review are allowed. Applicants are requested to prioritize their publications in relation to the field of this job advertisement.",
                        "Copies of the publications marked with an *."
                    },
                    bulletPointScenario: "generic"
                );

        internal static JobPosting Shared_JobPage01_JobPosting19
            = new JobPosting(
                    runId: Shared_FakeRunId,
                    pageNumber: 1,
                    response: "{\r\n            \"AutomatchType\": 0,\r\n            \"Abroad\": false,\r\n            \"Weight\": 1.0,\r\n            \"Title\": \"warehouse employee\",\r\n            \"JobHeadline\": \"warehouse employee\",\r\n            \"Presentation\": \"  Warehouse employee  \\n Do you want to join the evening team at DSV in Horsens? It is a permanent day shift, and for the right person it will be a permanent employment. \",\r\n            \"HiringOrgName\": \"RANDSTAD A/S\",\r\n            \"WorkPlaceAddress\": \"\",\r\n            \"WorkPlacePostalCode\": \"8700\",\r\n            \"WorkPlaceCity\": \"Horsens\",\r\n            \"WorkPlaceOtherAddress\": true,\r\n            \"WorkPlaceAbroad\": false,\r\n            \"WorkPlaceNotStatic\": false,\r\n            \"UseWorkPlaceAddressForJoblog\": false,\r\n            \"PostingCreated\": \"2021-07-02T00:00:00\",\r\n            \"LastDateApplication\": \"2021-08-27T00:00:00\",\r\n            \"FormattedLastDateApplication\": \"27. august 2021\",\r\n            \"AssignmentStartDate\": \"0001-01-01T00:00:00\",\r\n            \"IsHotjob\": false,\r\n            \"IsExternal\": false,\r\n            \"Url\": \"https://job.jobnet.dk/CV/FindWork/Details/5382781\",\r\n            \"Region\": \"Midtjylland\",\r\n            \"Municipality\": \"Horsens\",\r\n            \"Country\": \"Danmark\",\r\n            \"PostalCode\": \"8700\",\r\n            \"PostalCodeName\": null,\r\n            \"JobAnnouncementType\": \"\",\r\n            \"EmploymentType\": \"\",\r\n            \"WorkHours\": \"Fuldtid\",\r\n            \"OccupationArea\": \"\",\r\n            \"OccupationGroup\": \"\",\r\n            \"Occupation\": \"Lager- og logistikmedarbejder\",\r\n            \"Location\": {\r\n                \"Latitude\": 55.866,\r\n                \"Longitude\": 9.893\r\n            },\r\n            \"JoblogWorkTime\": {\r\n                \"WorkHour\": null,\r\n                \"DailyWorkTime\": \"Dag\"\r\n            },\r\n            \"WorkplaceID\": 120191,\r\n            \"OrganisationId\": \"106608\",\r\n            \"HiringOrgCVR\": 25050541,\r\n            \"UserLoggedIn\": false,\r\n            \"AnonymousEmployer\": false,\r\n            \"ShareUrl\": \"https://job.jobnet.dk/CV/FindWork/DetailsSocialmedia/5382781\",\r\n            \"DetailsUrl\": \"https://job.jobnet.dk/CV/FindWork/DetailsWidk/5382781\",\r\n            \"JobLogUrl\": \"https://job.jobnet.dk/CV/FindWork/Details/5382781\",\r\n            \"HasLocationValues\": true,\r\n            \"ID\": \"5382781\",\r\n            \"Latitude\": 55.866,\r\n            \"Longitude\": 9.893\r\n        }",
                    title: "warehouse employee",
                    presentation: "  Warehouse employee  \n Do you want to join the evening team at DSV in Horsens? It is a permanent day shift, and for the right person it will be a permanent employment. ",
                    hiringOrgName: "RANDSTAD A/S",
                    workPlaceAddress: "",
                    workPlacePostalCode: 8700,
                    workPlaceCity: "Horsens",
                    postingCreated: new DateTime(2021, 07, 02),
                    lastDateApplication: new DateTime(2021, 08, 27),
                    url: "https://job.jobnet.dk/CV/FindWork/Details/5382781",
                    region: "Midtjylland",
                    municipality: "Horsens",
                    country: "Danmark",
                    employmentType: "",
                    workHours: "Fuldtid",
                    occupation: "Lager- og logistikmedarbejder",
                    workplaceId: 120191,
                    organisationId: 106608,
                    hiringOrgCVR: 25050541,
                    id: 5382781,
                    workPlaceCityWithoutZone: "Horsens",
                    jobPostingNumber: 19,
                    jobPostingId: "5382781warehouseemployee"
                );
        internal static JobPostingExtended Shared_JobPage01_JobPostingExtended19
            = new JobPostingExtended(
                    jobPosting: Shared_JobPage01_JobPosting19,
                    response: Shared_FakeResponse,                      // Ignored
                    hiringOrgDescription: "Randstad er en del af den internationale Randstad Group, der er verdens andenstørste udbyder af HR-løsninger. Hver dag formidler Randstad arbejde til mere end 500.000 mennesker i hele verden. I Danmark er vi blandt de førende vikar- og rekrutteringsbureauer med fire afdelinger fordelt over hele landet. En position vi har opnået, fordi vi som eksperter på arbejdsmarkedet formår at matche kvalificerede kandidater med de rette jobmuligheder.",
                    publicationStartDate: new DateTime(2021, 07, 02),
                    publicationEndDate: new DateTime(2021, 08, 27),
                    purpose: Shared_FakePurpose,                        // Ignored
                    numberToFill: 1,
                    contactEmail: "charlotte.meck@randstad.dk",
                    contactPersonName: "Charlotte Meck",
                    employmentDate: null,
                    applicationDeadlineDate: new DateTime(2021, 08, 27),
                    bulletPoints: new HashSet<string>()
                    {
                        "Picking/packing tasks",
                        "Loading/unloading tasks",
                        "Receipt of goods",
                        "Truck driving, most often reach truck",
                        "Scanner operation",
                        "Various warehouse tasks",
                        "You will of course receive a thorough training in the work tasks, so you will have the best conditions for success.",
                        "The company generally has an informal work environment with the opportunity to take responsibility for work tasks and planning.",
                        "Are ready to take on evening work",
                        "Have experience from working at a warehouse",
                        "Have a truck certificate",
                        "Are ready to taking up the challenge when it comes to new tasks and flexible working days",
                        "Are able to perform a good job",
                        "Can represent Randstad as an external employee in a positive way at the customer’s premises",
                        "Danish- and English-speaking at a reasonable level",
                        "Basic salary according to qualifications and in addition to this, cf. collective agreement, pension scheme and holiday",
                        "A generally informal work environment with the opportunity to take responsibility for work tasks and planning",
                        "Start-up: As soon as possible, please send your CV",
                        "All inquiries are treated confidentially. Interviews will take place on an ongoing basis."
                    },
                    bulletPointScenario: "randstad"
                );

        internal static JobPosting Shared_JobPage01_JobPosting20
            = new JobPosting(
                    runId: Shared_FakeRunId,
                    pageNumber: 1,
                    response: "{\r\n            \"AutomatchType\": 0,\r\n            \"Abroad\": false,\r\n            \"Weight\": 1.0,\r\n            \"Title\": \"Postdoc on Digital Platforms and Ecosystems Innovation Dynamics\",\r\n            \"JobHeadline\": \"Postdoc on Digital Platforms and Ecosystems Innovation Dynamics\",\r\n            \"Presentation\": \"Copenhagen Business School, as part of a new initiative to launch a European research network to foster multidisciplinary research on the digital economy, invites applications for a postdoc position a\",\r\n            \"HiringOrgName\": \"Copenhagen Business School\",\r\n            \"WorkPlaceAddress\": \"Solbjerg Plads 3\",\r\n            \"WorkPlacePostalCode\": \"2000\",\r\n            \"WorkPlaceCity\": \"Frederiksberg\",\r\n            \"WorkPlaceOtherAddress\": false,\r\n            \"WorkPlaceAbroad\": false,\r\n            \"WorkPlaceNotStatic\": false,\r\n            \"UseWorkPlaceAddressForJoblog\": true,\r\n            \"PostingCreated\": \"2021-07-02T00:00:00\",\r\n            \"LastDateApplication\": \"2021-08-26T00:00:00\",\r\n            \"FormattedLastDateApplication\": \"26. august 2021\",\r\n            \"AssignmentStartDate\": \"0001-01-01T00:00:00\",\r\n            \"IsHotjob\": false,\r\n            \"IsExternal\": false,\r\n            \"Url\": \"https://job.jobnet.dk/CV/FindWork/Details/5382486\",\r\n            \"Region\": \"Hovedstaden og Bornholm\",\r\n            \"Municipality\": \"Frederiksberg\",\r\n            \"Country\": \"Danmark\",\r\n            \"PostalCode\": \"2000\",\r\n            \"PostalCodeName\": null,\r\n            \"JobAnnouncementType\": \"\",\r\n            \"EmploymentType\": \"\",\r\n            \"WorkHours\": \"Fuldtid\",\r\n            \"OccupationArea\": \"\",\r\n            \"OccupationGroup\": \"\",\r\n            \"Occupation\": \"Forsker, samfundsvidenskab\",\r\n            \"Location\": {\r\n                \"Latitude\": 55.6815,\r\n                \"Longitude\": 12.5304\r\n            },\r\n            \"JoblogWorkTime\": {\r\n                \"WorkHour\": null,\r\n                \"DailyWorkTime\": null\r\n            },\r\n            \"WorkplaceID\": 79401,\r\n            \"OrganisationId\": \"26360\",\r\n            \"HiringOrgCVR\": 19596915,\r\n            \"UserLoggedIn\": false,\r\n            \"AnonymousEmployer\": false,\r\n            \"ShareUrl\": \"https://job.jobnet.dk/CV/FindWork/DetailsSocialmedia/5382486\",\r\n            \"DetailsUrl\": \"https://job.jobnet.dk/CV/FindWork/DetailsWidk/5382486\",\r\n            \"JobLogUrl\": \"https://job.jobnet.dk/CV/FindWork/Details/5382486\",\r\n            \"HasLocationValues\": true,\r\n            \"ID\": \"5382486\",\r\n            \"Latitude\": 55.6815,\r\n            \"Longitude\": 12.5304\r\n        }",
                    title: "Postdoc on Digital Platforms and Ecosystems Innovation Dynamics",
                    presentation: "Copenhagen Business School, as part of a new initiative to launch a European research network to foster multidisciplinary research on the digital economy, invites applications for a postdoc position a",
                    hiringOrgName: "Copenhagen Business School",
                    workPlaceAddress: "Solbjerg Plads 3",
                    workPlacePostalCode: 2000,
                    workPlaceCity: "Frederiksberg",
                    postingCreated: new DateTime(2021, 07, 02),
                    lastDateApplication: new DateTime(2021, 08, 26),
                    url: "https://job.jobnet.dk/CV/FindWork/Details/5382486",
                    region: "Hovedstaden og Bornholm",
                    municipality: "Frederiksberg",
                    country: "Danmark",
                    employmentType: "",
                    workHours: "Fuldtid",
                    occupation: "Forsker, samfundsvidenskab",
                    workplaceId: 79401,
                    organisationId: 26360,
                    hiringOrgCVR: 19596915,
                    id: 5382486,
                    workPlaceCityWithoutZone: "Frederiksberg",
                    jobPostingNumber: 20,
                    jobPostingId: "5382486postdocondigitalplatformsand"
                );
        internal static JobPostingExtended Shared_JobPage01_JobPostingExtended20
            = new JobPostingExtended(
                    jobPosting: Shared_JobPage01_JobPosting20,
                    response: Shared_FakeResponse,                      // Ignored
                    hiringOrgDescription: null,
                    publicationStartDate: null,
                    publicationEndDate: null,
                    purpose: Shared_FakePurpose,                        // Ignored
                    numberToFill: null,
                    contactEmail: null,
                    contactPersonName: null,
                    employmentDate: null,
                    applicationDeadlineDate: null,
                    bulletPoints: new HashSet<string>()
                    {
                        "How does digital platform design affect user behaviors and outcomes?",
                        "How do complementors compete within and across digital ecosystems?",
                        "How do ecosystems compete?",
                        "What is the role of data and algorithms in steering interactions and value in platform markets and ecosystems (exploiting or correcting consumer behavioral biases)?",
                        "Are data exclusionary or non-rivalry? How do they affect a firm’s competitive advantage in (platform) digital markets?",
                        "How does data enable value creation (for organizations and their stakeholder)?",
                        "How to organize the effective and efficient creation, sharing and usage of data in digital ecosystems?",
                        "Applicants must have completed a PhD in Management, Economics, or other related social science discipline before the beginning the fellowship. Prior work (including but not limited to dissertation) should involve working with large datasets.",
                        "Excellent academic record and work ethic required.",
                        "Excellent organizational and oral/written communication skills required.",
                        "Enthusiasm for research required. The ideal candidate will be thinking of this position as a platform to build skills towards taking on a research professorship in the future.",
                        "Willingness to move to and live in Denmark.",
                        "Cover letter.",
                        "Proof of qualifications and a full CV.",
                        "Any relevant information indicating experience in research management, industry co-operation and international cooperation.",
                        "A complete, numbered list of publications (indicating titles, co-authors, page numbers and year) with an * marking of the academic productions to be considered during the review. A maximum of 10 publications for review are allowed. Applicants are requested to prioritize their publications in relation to the field of this job advertisement.",
                        "Copies of the publications marked with an *. Only publications written in English (or another specified principal language, according to research tradition) or one of the Scandinavian languages will be taken into consideration."
                    },
                    bulletPointScenario: "generic"
                );

        internal static List<JobPosting> Shared_JobPage01_JobPostings
            = new List<JobPosting>()
            {
                Shared_JobPage01_JobPosting01,
                Shared_JobPage01_JobPosting02,
                Shared_JobPage01_JobPosting03,
                Shared_JobPage01_JobPosting04,
                Shared_JobPage01_JobPosting05,
                Shared_JobPage01_JobPosting06,
                Shared_JobPage01_JobPosting07,
                Shared_JobPage01_JobPosting08,
                Shared_JobPage01_JobPosting09,
                Shared_JobPage01_JobPosting10,
                Shared_JobPage01_JobPosting11,
                Shared_JobPage01_JobPosting12,
                Shared_JobPage01_JobPosting13,
                Shared_JobPage01_JobPosting14,
                Shared_JobPage01_JobPosting15,
                Shared_JobPage01_JobPosting16,
                Shared_JobPage01_JobPosting17,
                Shared_JobPage01_JobPosting18,
                Shared_JobPage01_JobPosting19,
                Shared_JobPage01_JobPosting20
            };

        internal static JobPage Shared_JobPage01_Object
            = new JobPage(Shared_FakeRunId, 1, Shared_JobPage01_Content);
        internal static JobPage Shared_JobPage01WithEmptyResponse_Object
            = new JobPage(Shared_FakeRunId, 1, "{ }");

        internal static ushort Shared_JobPage01_TotalResultCount = 2177;
        internal static ushort Shared_JobPage01_TotalJobPages = 109;

        #endregion

        #region Shared_JobPage02

        internal static string Shared_JobPage02_Content
            = Properties.Resources.JobPage02_json;
        internal static string Shared_JobPage02_JobPostingExtended01_Content
            = Properties.Resources.JobPage02_JobPostingExtended01_json;
        internal static string Shared_JobPage02_JobPostingExtended02_Content
            = Properties.Resources.JobPage02_JobPostingExtended02_json;
        internal static string Shared_JobPage02_JobPostingExtended03_Content
            = Properties.Resources.JobPage02_JobPostingExtended03_json;
        internal static string Shared_JobPage02_JobPostingExtended04_Content
            = Properties.Resources.JobPage02_JobPostingExtended04_json;
        internal static string Shared_JobPage02_JobPostingExtended05_Content
            = Properties.Resources.JobPage02_JobPostingExtended05_json;
        internal static string Shared_JobPage02_JobPostingExtended06_Content
            = Properties.Resources.JobPage02_JobPostingExtended06_json;
        internal static string Shared_JobPage02_JobPostingExtended07_Content
            = Properties.Resources.JobPage02_JobPostingExtended07_json;
        internal static string Shared_JobPage02_JobPostingExtended08_Content
            = Properties.Resources.JobPage02_JobPostingExtended08_json;
        internal static string Shared_JobPage02_JobPostingExtended09_Content
            = Properties.Resources.JobPage02_JobPostingExtended09_json;
        internal static string Shared_JobPage02_JobPostingExtended10_Content
            = Properties.Resources.JobPage02_JobPostingExtended10;
        internal static string Shared_JobPage02_JobPostingExtended11_Content
            = Properties.Resources.JobPage02_JobPostingExtended11;
        internal static string Shared_JobPage02_JobPostingExtended12_Content
            = Properties.Resources.JobPage02_JobPostingExtended12;
        internal static string Shared_JobPage02_JobPostingExtended13_Content
            = Properties.Resources.JobPage02_JobPostingExtended13;
        internal static string Shared_JobPage02_JobPostingExtended14_Content
            = Properties.Resources.JobPage02_JobPostingExtended14;
        internal static string Shared_JobPage02_JobPostingExtended15_Content
            = Properties.Resources.JobPage02_JobPostingExtended15;
        internal static string Shared_JobPage02_JobPostingExtended16_Content
            = Properties.Resources.JobPage02_JobPostingExtended16;
        internal static string Shared_JobPage02_JobPostingExtended17_Content
            = Properties.Resources.JobPage02_JobPostingExtended17;
        internal static string Shared_JobPage02_JobPostingExtended18_Content
            = Properties.Resources.JobPage02_JobPostingExtended18;
        internal static string Shared_JobPage02_JobPostingExtended19_Content
            = Properties.Resources.JobPage02_JobPostingExtended19;
        internal static string Shared_JobPage02_JobPostingExtended20_Content
            = Properties.Resources.JobPage02_JobPostingExtended20;

        internal static JobPosting Shared_JobPage02_JobPosting01
            = new JobPosting(
                    runId: Shared_FakeRunId,
                    pageNumber: 2,
                    response: "{\r\n            \"AutomatchType\": 0,\r\n            \"Abroad\": false,\r\n            \"Weight\": 1.0,\r\n            \"Title\": \"Assistant or associate professorship in general didactics and empirical school research\",\r\n            \"JobHeadline\": \"Assistant or associate professorship in general didactics and empirical school research\",\r\n            \"Presentation\": \"The Department of Educational Theory and Curriculum Studies at the Danish School of Education, Aarhus University invites applications for an assistant/associate professorship in the field of general d\",\r\n            \"HiringOrgName\": \"Aarhus Universitet\",\r\n            \"WorkPlaceAddress\": \"Tuborgvej 164\",\r\n            \"WorkPlacePostalCode\": \"2400\",\r\n            \"WorkPlaceCity\": \"København NV\",\r\n            \"WorkPlaceOtherAddress\": false,\r\n            \"WorkPlaceAbroad\": false,\r\n            \"WorkPlaceNotStatic\": false,\r\n            \"UseWorkPlaceAddressForJoblog\": true,\r\n            \"PostingCreated\": \"2021-07-02T00:00:00\",\r\n            \"LastDateApplication\": \"2021-08-09T00:00:00\",\r\n            \"FormattedLastDateApplication\": \"9. august 2021\",\r\n            \"AssignmentStartDate\": \"0001-01-01T00:00:00\",\r\n            \"IsHotjob\": false,\r\n            \"IsExternal\": false,\r\n            \"Url\": \"https://job.jobnet.dk/CV/FindWork/Details/5382440\",\r\n            \"Region\": \"Hovedstaden og Bornholm\",\r\n            \"Municipality\": \"København\",\r\n            \"Country\": \"Danmark\",\r\n            \"PostalCode\": \"2400\",\r\n            \"PostalCodeName\": null,\r\n            \"JobAnnouncementType\": \"\",\r\n            \"EmploymentType\": \"\",\r\n            \"WorkHours\": \"Fuldtid\",\r\n            \"OccupationArea\": \"\",\r\n            \"OccupationGroup\": \"\",\r\n            \"Occupation\": \"Adjunkt, samfundsvidenskab\",\r\n            \"Location\": {\r\n                \"Latitude\": 55.7217,\r\n                \"Longitude\": 12.5432\r\n            },\r\n            \"JoblogWorkTime\": {\r\n                \"WorkHour\": null,\r\n                \"DailyWorkTime\": null\r\n            },\r\n            \"WorkplaceID\": 106637,\r\n            \"OrganisationId\": \"90880\",\r\n            \"HiringOrgCVR\": 31119103,\r\n            \"UserLoggedIn\": false,\r\n            \"AnonymousEmployer\": false,\r\n            \"ShareUrl\": \"https://job.jobnet.dk/CV/FindWork/DetailsSocialmedia/5382440\",\r\n            \"DetailsUrl\": \"https://job.jobnet.dk/CV/FindWork/DetailsWidk/5382440\",\r\n            \"JobLogUrl\": \"https://job.jobnet.dk/CV/FindWork/Details/5382440\",\r\n            \"HasLocationValues\": true,\r\n            \"ID\": \"5382440\",\r\n            \"Latitude\": 55.7217,\r\n            \"Longitude\": 12.5432\r\n        }",
                    title: "Assistant or associate professorship in general didactics and empirical school research",
                    presentation: "The Department of Educational Theory and Curriculum Studies at the Danish School of Education, Aarhus University invites applications for an assistant/associate professorship in the field of general d",
                    hiringOrgName: "Aarhus Universitet",
                    workPlaceAddress: "Tuborgvej 164",
                    workPlacePostalCode: 2400,
                    workPlaceCity: "København NV",
                    postingCreated: new DateTime(2021, 07, 02),
                    lastDateApplication: new DateTime(2021, 08, 09),
                    url: "https://job.jobnet.dk/CV/FindWork/Details/5382440",
                    region: "Hovedstaden og Bornholm",
                    municipality: "København",
                    country: "Danmark",
                    employmentType: "",
                    workHours: "Fuldtid",
                    occupation: "Adjunkt, samfundsvidenskab",
                    workplaceId: 106637,
                    organisationId: 90880,
                    hiringOrgCVR: 31119103,
                    id: 5382440,
                    workPlaceCityWithoutZone: "København",
                    jobPostingNumber: 1,
                    jobPostingId: "5382440assistantorassociateprofessorshipin"
                );
        internal static JobPostingExtended Shared_JobPage02_JobPostingExtended01
            = new JobPostingExtended(
                    jobPosting: Shared_JobPage02_JobPosting01,
                    response: Shared_FakeResponse,                      // Ignored
                    hiringOrgDescription: null,
                    publicationStartDate: null,
                    publicationEndDate: null,
                    purpose: Shared_FakePurpose,                        // Ignored
                    numberToFill: null,
                    contactEmail: null,
                    contactPersonName: null,
                    employmentDate: null,
                    applicationDeadlineDate: null,
                    bulletPoints: new HashSet<string>()
                    {
                        "Has specific research experience in the field of empirically informed teaching, learning outcome and/or student motivation",
                        "Has specific research experience connected to the role of digital technologies in shaping teaching and subject areas",
                        "Can demonstrate skills in collaborative and cross-disciplinary research",
                        "Can demonstrate skills in handling various qualitative and quantitative scientific methods.",
                        "Substantial research experience in general didactics in relation to empirical school research",
                        "An internationally oriented research profile",
                        "A relevant and internationally oriented publication profile",
                        "Experience of or interest in participation in national and international research networks",
                        "Experience of or interest in communication and knowledge exchange",
                        "Experience of or interest in interdisciplinary collaboration as well as interdisciplinary research",
                        "Experience of or the potential for obtaining external research funding",
                        "Teaching experience at university level within the field of general didactics and educational research methods",
                        "Experience of or interest in interdisciplinary teaching including innovative teaching methods",
                        "Experience of or interest in supervising student projects, and interest in researcher talent development.",
                        "Substantial research experience in the field of general didactics and empirical school research",
                        "Substantial experience of empirical research related to didactics, learning outcomes and student motivation",
                        "Skills in collaborative and cross-disciplinary school research",
                        "Skills in empirical school research and empirically informed teaching, including mixed methods",
                        "A strong, relevant international publication profile",
                        "Participation in national and international research networks",
                        "Experience of participation in collective research projects",
                        "Teaching experience at university level within the field general didactics and educational research methods, including innovative teaching methods, and mastery of academic English in the classroom",
                        "Proficiency in languages relevant to the area of research",
                        "Experience of interdisciplinary cooperation outreach activities",
                        "Experience of attracting external research funding",
                        "Experience of supervising student projects and an interest in researcher talent development.",
                        "Faculty of Arts refers to the Ministerial Order on the Appointment of Academic Staff at Danish Universities (the Appointment Order).",
                        "Appointment shall be in accordance with the collective labour agreement between the Danish Ministry of Finance and the Danish Confederation of Professional Associations.",
                        "Further information on qualification requirements and job content may be found in the Memorandum on Job Structure for Academic Staff at Danish Universities .",
                        "Further information on the application and supplementary materials may be found in Application Guidelines.",
                        "The application must outline the your motivation for applying for the position, attaching a curriculum vitae, copies of relevant degree certificates, and (if relevant for the position) a teaching portfolio. Please upload this material electronically along with your application.",
                        "If you submit your application for the assistant professorship, please upload a maximum of five samples of your scholarly output (mandatory).",
                        "If you submit your application for the associate professorship, please upload a maximum of eight samples of your scholarly output (mandatory).",
                        "Faculty of Arts refers to the Ministerial Order on the Appointment of Academic Staff at Danish Universities(the Appointment Order).",
                        "Further information on qualification requirements and job content may be found in theMemorandum on Job Structure for Academic Staff at Danish Universities."
                    },
                    bulletPointScenario: "generic"
                );

        internal static JobPosting Shared_JobPage02_JobPosting02
            = new JobPosting(
                    runId: Shared_FakeRunId,
                    pageNumber: 2,
                    response: "{\r\n            \"AutomatchType\": 0,\r\n            \"Abroad\": false,\r\n            \"Weight\": 1.0,\r\n            \"Title\": \"carpenter\",\r\n            \"JobHeadline\": \"carpenter\",\r\n            \"Presentation\": \"\",\r\n            \"HiringOrgName\": \"Lokal Boligservice ApS\",\r\n            \"WorkPlaceAddress\": \"\",\r\n            \"WorkPlacePostalCode\": \"\",\r\n            \"WorkPlaceCity\": \"\",\r\n            \"WorkPlaceOtherAddress\": false,\r\n            \"WorkPlaceAbroad\": false,\r\n            \"WorkPlaceNotStatic\": true,\r\n            \"UseWorkPlaceAddressForJoblog\": false,\r\n            \"PostingCreated\": \"2021-07-02T00:00:00\",\r\n            \"LastDateApplication\": \"2021-08-27T00:00:00\",\r\n            \"FormattedLastDateApplication\": \"27. august 2021\",\r\n            \"AssignmentStartDate\": \"0001-01-01T00:00:00\",\r\n            \"IsHotjob\": false,\r\n            \"IsExternal\": false,\r\n            \"Url\": \"https://job.jobnet.dk/CV/FindWork/Details/5316797\",\r\n            \"Region\": \"\",\r\n            \"Municipality\": \"\",\r\n            \"Country\": \"Danmark\",\r\n            \"PostalCode\": \"2800\",\r\n            \"PostalCodeName\": null,\r\n            \"JobAnnouncementType\": \"\",\r\n            \"EmploymentType\": \"\",\r\n            \"WorkHours\": \"Fuldtid\",\r\n            \"OccupationArea\": \"\",\r\n            \"OccupationGroup\": \"\",\r\n            \"Occupation\": \"Tømrer\",\r\n            \"Location\": {\r\n                \"Latitude\": 55.7857,\r\n                \"Longitude\": 12.5208\r\n            },\r\n            \"JoblogWorkTime\": {\r\n                \"WorkHour\": null,\r\n                \"DailyWorkTime\": \"Dag\"\r\n            },\r\n            \"WorkplaceID\": 138690,\r\n            \"OrganisationId\": \"121402\",\r\n            \"HiringOrgCVR\": 41075899,\r\n            \"UserLoggedIn\": false,\r\n            \"AnonymousEmployer\": false,\r\n            \"ShareUrl\": \"https://job.jobnet.dk/CV/FindWork/DetailsSocialmedia/5316797\",\r\n            \"DetailsUrl\": \"https://job.jobnet.dk/CV/FindWork/DetailsWidk/5316797\",\r\n            \"JobLogUrl\": \"https://job.jobnet.dk/CV/FindWork/Details/5316797\",\r\n            \"HasLocationValues\": true,\r\n            \"ID\": \"5316797\",\r\n            \"Latitude\": 55.7857,\r\n            \"Longitude\": 12.5208\r\n        }",
                    title: "carpenter",
                    presentation: "",
                    hiringOrgName: "Lokal Boligservice ApS",
                    workPlaceAddress: "",
                    workPlacePostalCode: null,
                    workPlaceCity: "",
                    postingCreated: new DateTime(2021, 07, 02),
                    lastDateApplication: new DateTime(2021, 08, 27),
                    url: "https://job.jobnet.dk/CV/FindWork/Details/5316797",
                    region: "",
                    municipality: "",
                    country: "Danmark",
                    employmentType: "",
                    workHours: "Fuldtid",
                    occupation: "Tømrer",
                    workplaceId: 138690,
                    organisationId: 121402,
                    hiringOrgCVR: 41075899,
                    id: 5316797,
                    workPlaceCityWithoutZone: "",
                    jobPostingNumber: 2,
                    jobPostingId: "5316797carpenter"
                );
        internal static JobPostingExtended Shared_JobPage02_JobPostingExtended02
            = new JobPostingExtended(
                    jobPosting: Shared_JobPage02_JobPosting02,
                    response: Shared_FakeResponse,                      // Ignored
                    hiringOrgDescription: null,
                    publicationStartDate: new DateTime(2021, 07, 02),
                    publicationEndDate: new DateTime(2021, 08, 27),
                    purpose: Shared_FakePurpose,                        // Ignored
                    numberToFill: 1,
                    contactEmail: "kontakt@lokalboligservice.dk",
                    contactPersonName: "Emil Bertelsen",
                    employmentDate: null,
                    applicationDeadlineDate: new DateTime(2021, 08, 27),
                    bulletPoints: null,
                    bulletPointScenario: null
                );

        internal static JobPosting Shared_JobPage02_JobPosting03
            = new JobPosting(
                    runId: Shared_FakeRunId,
                    pageNumber: 2,
                    response: "{\r\n            \"AutomatchType\": 0,\r\n            \"Abroad\": false,\r\n            \"Weight\": 1.0,\r\n            \"Title\": \"Solution Architect\",\r\n            \"JobHeadline\": \"Solution Architect\",\r\n            \"Presentation\": \" \",\r\n            \"HiringOrgName\": \"Plecto ApS\",\r\n            \"WorkPlaceAddress\": \"Viby Ringvej 11\",\r\n            \"WorkPlacePostalCode\": \"8260\",\r\n            \"WorkPlaceCity\": \"Viby J\",\r\n            \"WorkPlaceOtherAddress\": false,\r\n            \"WorkPlaceAbroad\": false,\r\n            \"WorkPlaceNotStatic\": false,\r\n            \"UseWorkPlaceAddressForJoblog\": true,\r\n            \"PostingCreated\": \"2021-07-02T00:00:00\",\r\n            \"LastDateApplication\": \"2021-08-27T00:00:00\",\r\n            \"FormattedLastDateApplication\": \"27. august 2021\",\r\n            \"AssignmentStartDate\": \"0001-01-01T00:00:00\",\r\n            \"IsHotjob\": false,\r\n            \"IsExternal\": false,\r\n            \"Url\": \"https://job.jobnet.dk/CV/FindWork/Details/5382367\",\r\n            \"Region\": \"Midtjylland\",\r\n            \"Municipality\": \"Aarhus\",\r\n            \"Country\": \"Danmark\",\r\n            \"PostalCode\": \"8260\",\r\n            \"PostalCodeName\": null,\r\n            \"JobAnnouncementType\": \"\",\r\n            \"EmploymentType\": \"\",\r\n            \"WorkHours\": \"Fuldtid\",\r\n            \"OccupationArea\": \"\",\r\n            \"OccupationGroup\": \"\",\r\n            \"Occupation\": \"Kundeservicemedarbejder\",\r\n            \"Location\": {\r\n                \"Latitude\": 56.1288,\r\n                \"Longitude\": 10.161\r\n            },\r\n            \"JoblogWorkTime\": {\r\n                \"WorkHour\": null,\r\n                \"DailyWorkTime\": null\r\n            },\r\n            \"WorkplaceID\": 107348,\r\n            \"OrganisationId\": \"96927\",\r\n            \"HiringOrgCVR\": 34737460,\r\n            \"UserLoggedIn\": false,\r\n            \"AnonymousEmployer\": false,\r\n            \"ShareUrl\": \"https://job.jobnet.dk/CV/FindWork/DetailsSocialmedia/5382367\",\r\n            \"DetailsUrl\": \"https://job.jobnet.dk/CV/FindWork/DetailsWidk/5382367\",\r\n            \"JobLogUrl\": \"https://job.jobnet.dk/CV/FindWork/Details/5382367\",\r\n            \"HasLocationValues\": true,\r\n            \"ID\": \"5382367\",\r\n            \"Latitude\": 56.1288,\r\n            \"Longitude\": 10.161\r\n        }",
                    title: "Solution Architect",
                    presentation: " ",
                    hiringOrgName: "Plecto ApS",
                    workPlaceAddress: "Viby Ringvej 11",
                    workPlacePostalCode: 8260,
                    workPlaceCity: "Viby J",
                    postingCreated: new DateTime(2021, 07, 02),
                    lastDateApplication: new DateTime(2021, 08, 27),
                    url: "https://job.jobnet.dk/CV/FindWork/Details/5382367",
                    region: "Midtjylland",
                    municipality: "Aarhus",
                    country: "Danmark",
                    employmentType: "",
                    workHours: "Fuldtid",
                    occupation: "Kundeservicemedarbejder",
                    workplaceId: 107348,
                    organisationId: 96927,
                    hiringOrgCVR: 34737460,
                    id: 5382367,
                    workPlaceCityWithoutZone: "Viby",
                    jobPostingNumber: 3,
                    jobPostingId: "5382367solutionarchitect"
                );
        internal static JobPostingExtended Shared_JobPage02_JobPostingExtended03
            = new JobPostingExtended(
                    jobPosting: Shared_JobPage02_JobPosting03,
                    response: Shared_FakeResponse,                      // Ignored
                    hiringOrgDescription: null,
                    publicationStartDate: new DateTime(2021, 07, 02),
                    publicationEndDate: new DateTime(2021, 08, 27),
                    purpose: Shared_FakePurpose,                        // Ignored
                    numberToFill: 1,
                    contactEmail: "justyna@plecto.com",
                    contactPersonName: "Justyna Płaczkiewicz",
                    employmentDate: null,
                    applicationDeadlineDate: new DateTime(2021, 08, 27),
                    bulletPoints: new HashSet<string>()
                    {
                        "Join and hold meetings with prospects and customers to assist with any questions related to SQL, API or Plecto in general",
                        "Handle complex support cases and customer queries  in a timely and efficient manner",
                        "Guide customers and prospects on best practices in using Plecto",
                        "Assist customers in setting up their Plecto account",
                        "Assist in initial integration research",
                        "Reading technical API documentation - JSON, REST and OAuth",
                        "Solve customer problems under complex constraints and come up with solutions without any additional development of Plecto",
                        "Maintaining and creating internal knowledge base articles",
                        "Experience in delivering outstanding technical support",
                        "Experience in database operations including reading and writing basic to intermediate database SQL queries and troubleshooting connection issues",
                        "Experience and knowledge in API and SQL Server Databases",
                        "Interest and knowledge in other programming languages is a plus, but not a requirement",
                        "Ability to effectively communicate technical concepts to a variety of audiences with different levels of technical expertise",
                        "Multi-tasking and time-management to prioritize and switch between varied tasks",
                        "Technical writing skills to create and maintain Knowledge Base articles",
                        "Technical skills and an eye for detail used in troubleshooting and implementing fixes",
                        "You are fluent in English, both spoken and written + another additional language. Danish is a plus, but not a requirement"
                    },
                    bulletPointScenario: "generic"
                );

        internal static JobPosting Shared_JobPage02_JobPosting04
            = new JobPosting(
                    runId: Shared_FakeRunId,
                    pageNumber: 2,
                    response: "{\r\n            \"AutomatchType\": 0,\r\n            \"Abroad\": false,\r\n            \"Weight\": 1.0,\r\n            \"Title\": \"Project Officer - Impact Assessment and Adaptation Analysis\",\r\n            \"JobHeadline\": \"Project Officer - Impact Assessment and Adaptation Analysis\",\r\n            \"Presentation\": \"<br>\\n UNEP DTU Partnership (UDP) is a leading international research and advisory institution on energy, climate and sustainable development. UDP is part of the Department for Technology, Management \",\r\n            \"HiringOrgName\": \"Danmarks Tekniske Universitet\",\r\n            \"WorkPlaceAddress\": \"Anker Engelunds Vej 101\",\r\n            \"WorkPlacePostalCode\": \"2800\",\r\n            \"WorkPlaceCity\": \"Kongens Lyngby\",\r\n            \"WorkPlaceOtherAddress\": false,\r\n            \"WorkPlaceAbroad\": false,\r\n            \"WorkPlaceNotStatic\": false,\r\n            \"UseWorkPlaceAddressForJoblog\": true,\r\n            \"PostingCreated\": \"2021-07-02T00:00:00\",\r\n            \"LastDateApplication\": \"2021-07-16T00:00:00\",\r\n            \"FormattedLastDateApplication\": \"16. juli 2021\",\r\n            \"AssignmentStartDate\": \"0001-01-01T00:00:00\",\r\n            \"IsHotjob\": false,\r\n            \"IsExternal\": false,\r\n            \"Url\": \"https://job.jobnet.dk/CV/FindWork/Details/5382358\",\r\n            \"Region\": \"Hovedstaden og Bornholm\",\r\n            \"Municipality\": \"Gladsaxe\",\r\n            \"Country\": \"Danmark\",\r\n            \"PostalCode\": \"2800\",\r\n            \"PostalCodeName\": null,\r\n            \"JobAnnouncementType\": \"\",\r\n            \"EmploymentType\": \"\",\r\n            \"WorkHours\": \"Fuldtid\",\r\n            \"OccupationArea\": \"\",\r\n            \"OccupationGroup\": \"\",\r\n            \"Occupation\": \"Miljøingeniør\",\r\n            \"Location\": {\r\n                \"Latitude\": 55.7859,\r\n                \"Longitude\": 12.5241\r\n            },\r\n            \"JoblogWorkTime\": {\r\n                \"WorkHour\": null,\r\n                \"DailyWorkTime\": null\r\n            },\r\n            \"WorkplaceID\": 83955,\r\n            \"OrganisationId\": \"66175\",\r\n            \"HiringOrgCVR\": 30060946,\r\n            \"UserLoggedIn\": false,\r\n            \"AnonymousEmployer\": false,\r\n            \"ShareUrl\": \"https://job.jobnet.dk/CV/FindWork/DetailsSocialmedia/5382358\",\r\n            \"DetailsUrl\": \"https://job.jobnet.dk/CV/FindWork/DetailsWidk/5382358\",\r\n            \"JobLogUrl\": \"https://job.jobnet.dk/CV/FindWork/Details/5382358\",\r\n            \"HasLocationValues\": true,\r\n            \"ID\": \"5382358\",\r\n            \"Latitude\": 55.7859,\r\n            \"Longitude\": 12.5241\r\n        }",
                    title: "Project Officer - Impact Assessment and Adaptation Analysis",
                    presentation: "<br>\n UNEP DTU Partnership (UDP) is a leading international research and advisory institution on energy, climate and sustainable development. UDP is part of the Department for Technology, Management ",
                    hiringOrgName: "Danmarks Tekniske Universitet",
                    workPlaceAddress: "Anker Engelunds Vej 101",
                    workPlacePostalCode: 2800,
                    workPlaceCity: "Kongens Lyngby",
                    postingCreated: new DateTime(2021, 07, 02),
                    lastDateApplication: new DateTime(2021, 07, 16),
                    url: "https://job.jobnet.dk/CV/FindWork/Details/5382358",
                    region: "Hovedstaden og Bornholm",
                    municipality: "Gladsaxe",
                    country: "Danmark",
                    employmentType: "",
                    workHours: "Fuldtid",
                    occupation: "Miljøingeniør",
                    workplaceId: 83955,
                    organisationId: 66175,
                    hiringOrgCVR: 30060946,
                    id: 5382358,
                    workPlaceCityWithoutZone: "Kongens Lyngby",
                    jobPostingNumber: 4,
                    jobPostingId: "5382358projectofficerimpactassessmentand"
                );
        internal static JobPostingExtended Shared_JobPage02_JobPostingExtended04
            = new JobPostingExtended(
                    jobPosting: Shared_JobPage02_JobPosting04,
                    response: Shared_FakeResponse,                      // Ignored
                    hiringOrgDescription: null,
                    publicationStartDate: new DateTime(2021, 07, 02),
                    publicationEndDate: new DateTime(2021, 07, 16),
                    purpose: Shared_FakePurpose,                        // Ignored
                    numberToFill: 1,
                    contactEmail: null,
                    contactPersonName: "Henry Neufeldt",
                    employmentDate: null,
                    applicationDeadlineDate: new DateTime(2021, 07, 16),
                    bulletPoints: new HashSet<string>()
                    {
                        "Lead the development of tools and guidance materials within adaptation assessment, tracking and transparency.",
                        "Support the production of UNEP's Adaptation Gap Report;",
                        "Contribute to the section's work on private sector adaptation, and adaptation business models.",
                        "Contribute to the section's work on impact assessments of mitigation and adaptation actions and their contribution to sustainable development;",
                        "Contribute to the section's work on adaptation finance tracking;",
                        "Contribute to the development of scientific papers, briefs, and reports;",
                        "Other tasks as assigned by the head of section.",
                        "M.Sc. degree in environmental science, environmental engineering, sustainability studies, environmental economics, or other relevant field;",
                        "Understanding of the Paris Agreement, in particular of the Enhanced Transparency Framework;",
                        "Good knowledge of methods and approaches for adaptation assessment and tracking at aggregated levels (i.e. national and global-levels)",
                        "Good knowledge of the adaptation finance landscape, and methods and approaches for tracking adaptation finance",
                        "Good knowledge of the Sustainable Development Goal framework, including of the SDG targets and indicators, particularly in the context of impact assessment;",
                        "Good knowledge of private sector adaptation is an asset;",
                        "Strong analytical skills, an innovative mindset, and the ability to adapt to different tasks and workloads quickly and effectively;",
                        "Demonstrated excellent writing, communication, and presentation skills in English; proficiency in other languages, in particular Spanish and/or French is an asset",
                        "Ability to work effectively both individually as well as in teams, with people from different academic and cultural backgrounds;",
                        "Experience in preparing technical and/or policy-relevant reports and papers is considered a strong asset;",
                        "Experience in working with developing countries is an asset;",
                        "Application letter;",
                        "CV with full personal data and contact details;",
                        "Indication of three references; and,",
                        "A copy of your diploma(s)"
                    },
                    bulletPointScenario: "generic"
                );

        internal static JobPosting Shared_JobPage02_JobPosting05
            = new JobPosting(
                    runId: Shared_FakeRunId,
                    pageNumber: 2,
                    response: "{\r\n            \"AutomatchType\": 0,\r\n            \"Abroad\": false,\r\n            \"Weight\": 1.0,\r\n            \"Title\": \"Warehouse workers\",\r\n            \"JobHeadline\": \"Warehouse workers\",\r\n            \"Presentation\": \"<p>For our client in Middelfart, we are looking for warehouse workers to empty containers daily - Monday to Friday from 8 AM to 4 PM.</p>\\n\",\r\n            \"HiringOrgName\": \"RANDSTAD A/S\",\r\n            \"WorkPlaceAddress\": \"\",\r\n            \"WorkPlacePostalCode\": \"5500\",\r\n            \"WorkPlaceCity\": \"Middelfart\",\r\n            \"WorkPlaceOtherAddress\": true,\r\n            \"WorkPlaceAbroad\": false,\r\n            \"WorkPlaceNotStatic\": false,\r\n            \"UseWorkPlaceAddressForJoblog\": false,\r\n            \"PostingCreated\": \"2021-07-02T00:00:00\",\r\n            \"LastDateApplication\": \"2021-08-27T00:00:00\",\r\n            \"FormattedLastDateApplication\": \"27. august 2021\",\r\n            \"AssignmentStartDate\": \"0001-01-01T00:00:00\",\r\n            \"IsHotjob\": false,\r\n            \"IsExternal\": false,\r\n            \"Url\": \"https://job.jobnet.dk/CV/FindWork/Details/5382226\",\r\n            \"Region\": \"Syddanmark\",\r\n            \"Municipality\": \"Middelfart\",\r\n            \"Country\": \"Danmark\",\r\n            \"PostalCode\": \"5500\",\r\n            \"PostalCodeName\": null,\r\n            \"JobAnnouncementType\": \"\",\r\n            \"EmploymentType\": \"\",\r\n            \"WorkHours\": \"Fuldtid\",\r\n            \"OccupationArea\": \"\",\r\n            \"OccupationGroup\": \"\",\r\n            \"Occupation\": \"Lager- og logistikmedarbejder\",\r\n            \"Location\": {\r\n                \"Latitude\": 55.4893,\r\n                \"Longitude\": 9.7849\r\n            },\r\n            \"JoblogWorkTime\": {\r\n                \"WorkHour\": null,\r\n                \"DailyWorkTime\": \"Dag\"\r\n            },\r\n            \"WorkplaceID\": 120191,\r\n            \"OrganisationId\": \"106608\",\r\n            \"HiringOrgCVR\": 25050541,\r\n            \"UserLoggedIn\": false,\r\n            \"AnonymousEmployer\": false,\r\n            \"ShareUrl\": \"https://job.jobnet.dk/CV/FindWork/DetailsSocialmedia/5382226\",\r\n            \"DetailsUrl\": \"https://job.jobnet.dk/CV/FindWork/DetailsWidk/5382226\",\r\n            \"JobLogUrl\": \"https://job.jobnet.dk/CV/FindWork/Details/5382226\",\r\n            \"HasLocationValues\": true,\r\n            \"ID\": \"5382226\",\r\n            \"Latitude\": 55.4893,\r\n            \"Longitude\": 9.7849\r\n        }",
                    title: "Warehouse workers",
                    presentation: "<p>For our client in Middelfart, we are looking for warehouse workers to empty containers daily - Monday to Friday from 8 AM to 4 PM.</p>\n",
                    hiringOrgName: "RANDSTAD A/S",
                    workPlaceAddress: "",
                    workPlacePostalCode: 5500,
                    workPlaceCity: "Middelfart",
                    postingCreated: new DateTime(2021, 07, 02),
                    lastDateApplication: new DateTime(2021, 08, 27),
                    url: "https://job.jobnet.dk/CV/FindWork/Details/5382226",
                    region: "Syddanmark",
                    municipality: "Middelfart",
                    country: "Danmark",
                    employmentType: "",
                    workHours: "Fuldtid",
                    occupation: "Lager- og logistikmedarbejder",
                    workplaceId: 120191,
                    organisationId: 106608,
                    hiringOrgCVR: 25050541,
                    id: 5382226,
                    workPlaceCityWithoutZone: "Middelfart",
                    jobPostingNumber: 5,
                    jobPostingId: "5382226warehouseworkers"
                );
        internal static JobPostingExtended Shared_JobPage02_JobPostingExtended05
            = new JobPostingExtended(
                    jobPosting: Shared_JobPage02_JobPosting05,
                    response: Shared_FakeResponse,                      // Ignored
                    hiringOrgDescription: "Randstad er en del af den internationale Randstad Group, der er verdens andenstørste udbyder af HR-løsninger. Hver dag formidler Randstad arbejde til mere end 500.000 mennesker i hele verden. I Danmark er vi blandt de førende vikar- og rekrutteringsbureauer med fire afdelinger fordelt over hele landet. En position vi har opnået, fordi vi som eksperter på arbejdsmarkedet formår at matche kvalificerede kandidater med de rette jobmuligheder.",
                    publicationStartDate: new DateTime(2021, 07, 02),
                    publicationEndDate: new DateTime(2021, 08, 27),
                    purpose: Shared_FakePurpose,                        // Ignored
                    numberToFill: 2,
                    contactEmail: "claus.kjaerbo@randstad.dk",
                    contactPersonName: "Claus Kjærbo",
                    employmentDate: null,
                    applicationDeadlineDate: new DateTime(2021, 08, 27),
                    bulletPoints: new HashSet<string>()
                    {
                        "You speak English or Danish",
                        "You are interested in working in a warehouse",
                        "You have a pair of safety shoes"
                    },
                    bulletPointScenario: "generic"
                );

        internal static JobPosting Shared_JobPage02_JobPosting06
            = new JobPosting(
                    runId: Shared_FakeRunId,
                    pageNumber: 2,
                    response: "{\r\n            \"AutomatchType\": 0,\r\n            \"Abroad\": false,\r\n            \"Weight\": 1.0,\r\n            \"Title\": \"Cleaning / Housekeeping\",\r\n            \"JobHeadline\": \"Cleaning / Housekeeping\",\r\n            \"Presentation\": \"   Are you the new fantastic employee at BH HotelService?    \u00A0\u00A0\u00A0\u00A0\u00A0\u00A0\u00A0\u00A0\u00A0\u00A0\u00A0\u00A0\u00A0\u00A0\u00A0\u00A0\u00A0\u00A0\u00A0\u00A0\u00A0\u00A0\u00A0\u00A0\u00A0\u00A0\u00A0\u00A0\u00A0\u00A0\u00A0\u00A0\u00A0     \u00A0\u00A0\u00A0\u00A0\u00A0\u00A0\u00A0\u00A0\u00A0\u00A0\u00A0\u00A0\u00A0\u00A0\u00A0\u00A0\u00A0\u00A0\u00A0\u00A0\u00A0\u00A0\u00A0\u00A0\u00A0\u00A0\u00A0\u00A0\u00A0\u00A0\u00A0\u00A0\u00A0\u00A0\u00A0\u00A0\u00A0\u00A0\u00A0\u00A0\u00A0\u00A0 \",\r\n            \"HiringOrgName\": \"BH HotelService ApS\",\r\n            \"WorkPlaceAddress\": \"Amagerbrogade 44, 1. tv.\",\r\n            \"WorkPlacePostalCode\": \"2300\",\r\n            \"WorkPlaceCity\": \"København S\",\r\n            \"WorkPlaceOtherAddress\": false,\r\n            \"WorkPlaceAbroad\": false,\r\n            \"WorkPlaceNotStatic\": false,\r\n            \"UseWorkPlaceAddressForJoblog\": true,\r\n            \"PostingCreated\": \"2021-07-02T00:00:00\",\r\n            \"LastDateApplication\": \"2021-07-30T00:00:00\",\r\n            \"FormattedLastDateApplication\": \"30. juli 2021\",\r\n            \"AssignmentStartDate\": \"0001-01-01T00:00:00\",\r\n            \"IsHotjob\": false,\r\n            \"IsExternal\": false,\r\n            \"Url\": \"https://job.jobnet.dk/CV/FindWork/Details/5339477\",\r\n            \"Region\": \"Hovedstaden og Bornholm\",\r\n            \"Municipality\": \"København\",\r\n            \"Country\": \"Danmark\",\r\n            \"PostalCode\": \"2300\",\r\n            \"PostalCodeName\": null,\r\n            \"JobAnnouncementType\": \"\",\r\n            \"EmploymentType\": \"\",\r\n            \"WorkHours\": \"Deltid\",\r\n            \"OccupationArea\": \"\",\r\n            \"OccupationGroup\": \"\",\r\n            \"Occupation\": \"Rengøringsassistent, hotel\",\r\n            \"Location\": {\r\n                \"Latitude\": 55.6636,\r\n                \"Longitude\": 12.601\r\n            },\r\n            \"JoblogWorkTime\": {\r\n                \"WorkHour\": \"(20 - 30 timer ugentligt)\",\r\n                \"DailyWorkTime\": \"Dag, weekend\"\r\n            },\r\n            \"WorkplaceID\": 84451,\r\n            \"OrganisationId\": \"78371\",\r\n            \"HiringOrgCVR\": 32286550,\r\n            \"UserLoggedIn\": false,\r\n            \"AnonymousEmployer\": false,\r\n            \"ShareUrl\": \"https://job.jobnet.dk/CV/FindWork/DetailsSocialmedia/5339477\",\r\n            \"DetailsUrl\": \"https://job.jobnet.dk/CV/FindWork/DetailsWidk/5339477\",\r\n            \"JobLogUrl\": \"https://job.jobnet.dk/CV/FindWork/Details/5339477\",\r\n            \"HasLocationValues\": true,\r\n            \"ID\": \"5339477\",\r\n            \"Latitude\": 55.6636,\r\n            \"Longitude\": 12.601\r\n        }",
                    title: "Cleaning / Housekeeping",
                    presentation: "   Are you the new fantastic employee at BH HotelService?    \u00A0\u00A0\u00A0\u00A0\u00A0\u00A0\u00A0\u00A0\u00A0\u00A0\u00A0\u00A0\u00A0\u00A0\u00A0\u00A0\u00A0\u00A0\u00A0\u00A0\u00A0\u00A0\u00A0\u00A0\u00A0\u00A0\u00A0\u00A0\u00A0\u00A0\u00A0\u00A0\u00A0     \u00A0\u00A0\u00A0\u00A0\u00A0\u00A0\u00A0\u00A0\u00A0\u00A0\u00A0\u00A0\u00A0\u00A0\u00A0\u00A0\u00A0\u00A0\u00A0\u00A0\u00A0\u00A0\u00A0\u00A0\u00A0\u00A0\u00A0\u00A0\u00A0\u00A0\u00A0\u00A0\u00A0\u00A0\u00A0\u00A0\u00A0\u00A0\u00A0\u00A0\u00A0\u00A0 ",
                    hiringOrgName: "BH HotelService ApS",
                    workPlaceAddress: "Amagerbrogade 44, 1. tv.",
                    workPlacePostalCode: 2300,
                    workPlaceCity: "København S",
                    postingCreated: new DateTime(2021, 07, 02),
                    lastDateApplication: new DateTime(2021, 07, 30),
                    url: "https://job.jobnet.dk/CV/FindWork/Details/5339477",
                    region: "Hovedstaden og Bornholm",
                    municipality: "København",
                    country: "Danmark",
                    employmentType: "",
                    workHours: "Deltid",
                    occupation: "Rengøringsassistent, hotel",
                    workplaceId: 84451,
                    organisationId: 78371,
                    hiringOrgCVR: 32286550,
                    id: 5339477,
                    workPlaceCityWithoutZone: "København",
                    jobPostingNumber: 6,
                    jobPostingId: "5339477cleaninghousekeeping"
                );
        internal static JobPostingExtended Shared_JobPage02_JobPostingExtended06
            = new JobPostingExtended(
                    jobPosting: Shared_JobPage02_JobPosting06,
                    response: Shared_FakeResponse,                      // Ignored
                    hiringOrgDescription: null,
                    publicationStartDate: new DateTime(2021, 07, 02),
                    publicationEndDate: new DateTime(2021, 07, 30),
                    purpose: Shared_FakePurpose,                        // Ignored
                    numberToFill: 20,
                    contactEmail: "anja@bh-hotelservice.dk",
                    contactPersonName: "Anja Løvhøj",
                    employmentDate: null,
                    applicationDeadlineDate: new DateTime(2021, 07, 30),
                    bulletPoints: new HashSet<string>()
                    {
                        "you get to clean the finest hotel rooms in Copenhagen",
                        "you are guaranteed a minimum of 80-130 hours per month with the possibility to work more (depending on your situation)",
                        "we offer career opportunities through promotions and/or management classes",
                        "we offer health insurance after 6 months of employment",
                        "Salary according to the collective bargaining agreement",
                        "Speaking English",
                        "Service minded",
                        "Ready to work primarily in the daytime on weekdays and/or weekends",
                        "Able to work in weekends as well",
                        "Ready to work in a fast and exiting environment",
                        "Definitely the one we are looking for!"
                    },
                    bulletPointScenario: "generic"
                );

        internal static JobPosting Shared_JobPage02_JobPosting07
            = new JobPosting(
                    runId: Shared_FakeRunId,
                    pageNumber: 2,
                    response: "{\r\n            \"AutomatchType\": 0,\r\n            \"Abroad\": false,\r\n            \"Weight\": 1.0,\r\n            \"Title\": \"B2B Sales Specialist\",\r\n            \"JobHeadline\": \"B2B Sales Specialist\",\r\n            \"Presentation\": \" \",\r\n            \"HiringOrgName\": \"Plecto ApS\",\r\n            \"WorkPlaceAddress\": \"Viby Ringvej 11\",\r\n            \"WorkPlacePostalCode\": \"8260\",\r\n            \"WorkPlaceCity\": \"Viby J\",\r\n            \"WorkPlaceOtherAddress\": false,\r\n            \"WorkPlaceAbroad\": false,\r\n            \"WorkPlaceNotStatic\": false,\r\n            \"UseWorkPlaceAddressForJoblog\": true,\r\n            \"PostingCreated\": \"2021-07-02T00:00:00\",\r\n            \"LastDateApplication\": \"2021-07-30T00:00:00\",\r\n            \"FormattedLastDateApplication\": \"30. juli 2021\",\r\n            \"AssignmentStartDate\": \"0001-01-01T00:00:00\",\r\n            \"IsHotjob\": false,\r\n            \"IsExternal\": false,\r\n            \"Url\": \"https://job.jobnet.dk/CV/FindWork/Details/5345782\",\r\n            \"Region\": \"Midtjylland\",\r\n            \"Municipality\": \"Aarhus\",\r\n            \"Country\": \"Danmark\",\r\n            \"PostalCode\": \"8260\",\r\n            \"PostalCodeName\": null,\r\n            \"JobAnnouncementType\": \"\",\r\n            \"EmploymentType\": \"\",\r\n            \"WorkHours\": \"Fuldtid\",\r\n            \"OccupationArea\": \"\",\r\n            \"OccupationGroup\": \"\",\r\n            \"Occupation\": \"Salgskonsulent\",\r\n            \"Location\": {\r\n                \"Latitude\": 56.1288,\r\n                \"Longitude\": 10.161\r\n            },\r\n            \"JoblogWorkTime\": {\r\n                \"WorkHour\": null,\r\n                \"DailyWorkTime\": null\r\n            },\r\n            \"WorkplaceID\": 107348,\r\n            \"OrganisationId\": \"96927\",\r\n            \"HiringOrgCVR\": 34737460,\r\n            \"UserLoggedIn\": false,\r\n            \"AnonymousEmployer\": false,\r\n            \"ShareUrl\": \"https://job.jobnet.dk/CV/FindWork/DetailsSocialmedia/5345782\",\r\n            \"DetailsUrl\": \"https://job.jobnet.dk/CV/FindWork/DetailsWidk/5345782\",\r\n            \"JobLogUrl\": \"https://job.jobnet.dk/CV/FindWork/Details/5345782\",\r\n            \"HasLocationValues\": true,\r\n            \"ID\": \"5345782\",\r\n            \"Latitude\": 56.1288,\r\n            \"Longitude\": 10.161\r\n        }",
                    title: "B2B Sales Specialist",
                    presentation: " ",
                    hiringOrgName: "Plecto ApS",
                    workPlaceAddress: "Viby Ringvej 11",
                    workPlacePostalCode: 8260,
                    workPlaceCity: "Viby J",
                    postingCreated: new DateTime(2021, 07, 02),
                    lastDateApplication: new DateTime(2021, 07, 30),
                    url: "https://job.jobnet.dk/CV/FindWork/Details/5345782",
                    region: "Midtjylland",
                    municipality: "Aarhus",
                    country: "Danmark",
                    employmentType: "",
                    workHours: "Fuldtid",
                    occupation: "Salgskonsulent",
                    workplaceId: 107348,
                    organisationId: 96927,
                    hiringOrgCVR: 34737460,
                    id: 5345782,
                    workPlaceCityWithoutZone: "Viby",
                    jobPostingNumber: 7,
                    jobPostingId: "5345782bbsalesspecialist"
                );
        internal static JobPostingExtended Shared_JobPage02_JobPostingExtended07
            = new JobPostingExtended(
                    jobPosting: Shared_JobPage02_JobPosting07,
                    response: Shared_FakeResponse,                      // Ignored
                    hiringOrgDescription: null,
                    publicationStartDate: new DateTime(2021, 07, 02),
                    publicationEndDate: new DateTime(2021, 07, 30),
                    purpose: Shared_FakePurpose,                        // Ignored
                    numberToFill: 1,
                    contactEmail: "justyna@plecto.com",
                    contactPersonName: "Justyna Płaczkiewicz",
                    employmentDate: null,
                    applicationDeadlineDate: new DateTime(2021, 07, 30),
                    bulletPoints: new HashSet<string>()
                    {
                        "Develop a strong base of customers",
                        "Find leads and potential customers through for example networks and social platforms",
                        "Identify areas where you can expand business with your existing customers",
                        "Negotiate contracts and close deals while clearly predicting your pipeline",
                        "You have excellent skills in both written and oral English",
                        "You have a good business understanding and a structured work approach",
                        "You are a team player with the ability to collaborate across teams",
                        "You are able to identify needs and identify where Plecto can create value for potential customers",
                        "It is an advantage if you have previous experience in the insurance-, telecommunications-, energy- or media industry",
                        "It is an advantage if you have previous experience from B2B and/or sales",
                        "You have a bubbly positive personality that we will love to get to know and work with"
                    },
                    bulletPointScenario: "generic"
                );

        internal static JobPosting Shared_JobPage02_JobPosting08
            = new JobPosting(
                    runId: Shared_FakeRunId,
                    pageNumber: 2,
                    response: "{\r\n            \"AutomatchType\": 0,\r\n            \"Abroad\": false,\r\n            \"Weight\": 1.0,\r\n            \"Title\": \"warwhose worker with in experince using a runner\",\r\n            \"JobHeadline\": \"warwhose worker with in experince using a runner\",\r\n            \"Presentation\": \"<p>10 persons needed for warehouse work in Horsens on both day and evening shift starting as soon as possible until the end of August.</p>\\n<p>\u00A0</p>\\n\",\r\n            \"HiringOrgName\": \"Vikar DK A/S\",\r\n            \"WorkPlaceAddress\": \"Egeskovvej 17\",\r\n            \"WorkPlacePostalCode\": \"8700\",\r\n            \"WorkPlaceCity\": \"Horsens\",\r\n            \"WorkPlaceOtherAddress\": false,\r\n            \"WorkPlaceAbroad\": false,\r\n            \"WorkPlaceNotStatic\": false,\r\n            \"UseWorkPlaceAddressForJoblog\": true,\r\n            \"PostingCreated\": \"2021-07-02T00:00:00\",\r\n            \"LastDateApplication\": \"2021-08-05T00:00:00\",\r\n            \"FormattedLastDateApplication\": \"5. august 2021\",\r\n            \"AssignmentStartDate\": \"0001-01-01T00:00:00\",\r\n            \"IsHotjob\": false,\r\n            \"IsExternal\": false,\r\n            \"Url\": \"https://job.jobnet.dk/CV/FindWork/Details/5366564\",\r\n            \"Region\": \"Midtjylland\",\r\n            \"Municipality\": \"Horsens\",\r\n            \"Country\": \"Danmark\",\r\n            \"PostalCode\": \"8700\",\r\n            \"PostalCodeName\": null,\r\n            \"JobAnnouncementType\": \"\",\r\n            \"EmploymentType\": \"\",\r\n            \"WorkHours\": \"Fuldtid\",\r\n            \"OccupationArea\": \"\",\r\n            \"OccupationGroup\": \"\",\r\n            \"Occupation\": \"Lager- og logistikmedarbejder\",\r\n            \"Location\": {\r\n                \"Latitude\": 55.923,\r\n                \"Longitude\": 9.8219\r\n            },\r\n            \"JoblogWorkTime\": {\r\n                \"WorkHour\": null,\r\n                \"DailyWorkTime\": \"Dag, aften\"\r\n            },\r\n            \"WorkplaceID\": 99015,\r\n            \"OrganisationId\": \"90677\",\r\n            \"HiringOrgCVR\": 34046956,\r\n            \"UserLoggedIn\": false,\r\n            \"AnonymousEmployer\": false,\r\n            \"ShareUrl\": \"https://job.jobnet.dk/CV/FindWork/DetailsSocialmedia/5366564\",\r\n            \"DetailsUrl\": \"https://job.jobnet.dk/CV/FindWork/DetailsWidk/5366564\",\r\n            \"JobLogUrl\": \"https://job.jobnet.dk/CV/FindWork/Details/5366564\",\r\n            \"HasLocationValues\": true,\r\n            \"ID\": \"5366564\",\r\n            \"Latitude\": 55.923,\r\n            \"Longitude\": 9.8219\r\n        }",
                    title: "warwhose worker with in experince using a runner",
                    presentation: "<p>10 persons needed for warehouse work in Horsens on both day and evening shift starting as soon as possible until the end of August.</p>\n<p>\u00A0</p>\n",
                    hiringOrgName: "Vikar DK A/S",
                    workPlaceAddress: "Egeskovvej 17",
                    workPlacePostalCode: 8700,
                    workPlaceCity: "Horsens",
                    postingCreated: new DateTime(2021, 07, 02),
                    lastDateApplication: new DateTime(2021, 08, 05),
                    url: "https://job.jobnet.dk/CV/FindWork/Details/5366564",
                    region: "Midtjylland",
                    municipality: "Horsens",
                    country: "Danmark",
                    employmentType: "",
                    workHours: "Fuldtid",
                    occupation: "Lager- og logistikmedarbejder",
                    workplaceId: 99015,
                    organisationId: 90677,
                    hiringOrgCVR: 34046956,
                    id: 5366564,
                    workPlaceCityWithoutZone: "Horsens",
                    jobPostingNumber: 8,
                    jobPostingId: "5366564warwhoseworkerwithinexperince"
                );
        internal static JobPostingExtended Shared_JobPage02_JobPostingExtended08
            = new JobPostingExtended(
                    jobPosting: Shared_JobPage02_JobPosting08,
                    response: Shared_FakeResponse,                      // Ignored
                    hiringOrgDescription: null,
                    publicationStartDate: new DateTime(2021, 07, 02),
                    publicationEndDate: new DateTime(2021, 08, 05),
                    purpose: Shared_FakePurpose,                        // Ignored
                    numberToFill: 10,
                    contactEmail: "bbo@vikardk.dk",
                    contactPersonName: "Bettina Bonde Thygesen",
                    employmentDate: null,
                    applicationDeadlineDate: new DateTime(2021, 08, 05),
                    bulletPoints: null,
                    bulletPointScenario: null
                );

        internal static JobPosting Shared_JobPage02_JobPosting09
            = new JobPosting(
                    runId: Shared_FakeRunId,
                    pageNumber: 2,
                    response: "{\r\n            \"AutomatchType\": 0,\r\n            \"Abroad\": false,\r\n            \"Weight\": 1.0,\r\n            \"Title\": \"Tenure Track Assistant Professor in paleoecology, ancient genomics and conservation biology\",\r\n            \"JobHeadline\": \"Tenure Track Assistant Professor in paleoecology, ancient genomics and conservation biology\",\r\n            \"Presentation\": \"The GLOBE Institute at the Faculty of Health and Medical Sciences, University of Copenhagen seeks to appoint a tenure track assistant professor in paleoecology, ancient genomics and conservation biolo\",\r\n            \"HiringOrgName\": \"KU - SCIENCE - SNM\",\r\n            \"WorkPlaceAddress\": \"Øster Voldgade 5-7\",\r\n            \"WorkPlacePostalCode\": \"1350\",\r\n            \"WorkPlaceCity\": \"København K\",\r\n            \"WorkPlaceOtherAddress\": false,\r\n            \"WorkPlaceAbroad\": false,\r\n            \"WorkPlaceNotStatic\": false,\r\n            \"UseWorkPlaceAddressForJoblog\": true,\r\n            \"PostingCreated\": \"2021-07-02T00:00:00\",\r\n            \"LastDateApplication\": \"2021-07-21T00:00:00\",\r\n            \"FormattedLastDateApplication\": \"21. juli 2021\",\r\n            \"AssignmentStartDate\": \"0001-01-01T00:00:00\",\r\n            \"IsHotjob\": false,\r\n            \"IsExternal\": false,\r\n            \"Url\": \"https://job.jobnet.dk/CV/FindWork/Details/5363343\",\r\n            \"Region\": \"Hovedstaden og Bornholm\",\r\n            \"Municipality\": \"København\",\r\n            \"Country\": \"Danmark\",\r\n            \"PostalCode\": \"1350\",\r\n            \"PostalCodeName\": null,\r\n            \"JobAnnouncementType\": \"\",\r\n            \"EmploymentType\": \"\",\r\n            \"WorkHours\": \"Fuldtid\",\r\n            \"OccupationArea\": \"\",\r\n            \"OccupationGroup\": \"\",\r\n            \"Occupation\": \"Adjunkt, sundhedsvidenskab\",\r\n            \"Location\": {\r\n                \"Latitude\": 55.6872,\r\n                \"Longitude\": 12.5772\r\n            },\r\n            \"JoblogWorkTime\": {\r\n                \"WorkHour\": null,\r\n                \"DailyWorkTime\": null\r\n            },\r\n            \"WorkplaceID\": 105129,\r\n            \"OrganisationId\": \"57758\",\r\n            \"HiringOrgCVR\": 29979812,\r\n            \"UserLoggedIn\": false,\r\n            \"AnonymousEmployer\": false,\r\n            \"ShareUrl\": \"https://job.jobnet.dk/CV/FindWork/DetailsSocialmedia/5363343\",\r\n            \"DetailsUrl\": \"https://job.jobnet.dk/CV/FindWork/DetailsWidk/5363343\",\r\n            \"JobLogUrl\": \"https://job.jobnet.dk/CV/FindWork/Details/5363343\",\r\n            \"HasLocationValues\": true,\r\n            \"ID\": \"5363343\",\r\n            \"Latitude\": 55.6872,\r\n            \"Longitude\": 12.5772\r\n        }",
                    title: "Tenure Track Assistant Professor in paleoecology, ancient genomics and conservation biology",
                    presentation: "The GLOBE Institute at the Faculty of Health and Medical Sciences, University of Copenhagen seeks to appoint a tenure track assistant professor in paleoecology, ancient genomics and conservation biolo",
                    hiringOrgName: "KU - SCIENCE - SNM",
                    workPlaceAddress: "Øster Voldgade 5-7",
                    workPlacePostalCode: 1350,
                    workPlaceCity: "København K",
                    postingCreated: new DateTime(2021, 07, 02),
                    lastDateApplication: new DateTime(2021, 07, 21),
                    url: "https://job.jobnet.dk/CV/FindWork/Details/5363343",
                    region: "Hovedstaden og Bornholm",
                    municipality: "København",
                    country: "Danmark",
                    employmentType: "",
                    workHours: "Fuldtid",
                    occupation: "Adjunkt, sundhedsvidenskab",
                    workplaceId: 105129,
                    organisationId: 57758,
                    hiringOrgCVR: 29979812,
                    id: 5363343,
                    workPlaceCityWithoutZone: "København",
                    jobPostingNumber: 9,
                    jobPostingId: "5363343tenuretrackassistantprofessorin"
                );
        internal static JobPostingExtended Shared_JobPage02_JobPostingExtended09
            = new JobPostingExtended(
                    jobPosting: Shared_JobPage02_JobPosting09,
                    response: Shared_FakeResponse,                      // Ignored
                    hiringOrgDescription: null,
                    publicationStartDate: null,
                    publicationEndDate: null,
                    purpose: Shared_FakePurpose,                        // Ignored
                    numberToFill: null,
                    contactEmail: null,
                    contactPersonName: null,
                    employmentDate: null,
                    applicationDeadlineDate: null,
                    bulletPoints: new HashSet<string>()
                    {
                        "research, including publication/academic dissemination",
                        "research-based teaching",
                        "sharing knowledge with society",
                        "participation in formal pedagogical training programme for assistant professors",
                        "a PhD degree or similar qualifications within the subject area",
                        "research experience within the field of the position",
                        "Application, including motivation for applying for this position (Maximum 2 pages)",
                        "Curriculum vitae, including information about funding",
                        "Diplomas (Master’s, PhD and other relevant diplomas)",
                        "A complete list of publications",
                        "Research plan (2-4 pages)",
                        "Teaching plan",
                        "Uploads of maximum 5 publications to be considered in the assessment",
                        "Teaching portfolio, if applicable (Guidelines: https://employment.ku.dk/faculty/recruitment-process/job-application-portfolio)"
                    },
                    bulletPointScenario: "generic"
                );

        internal static JobPosting Shared_JobPage02_JobPosting10
            = new JobPosting(
                    runId: Shared_FakeRunId,
                    pageNumber: 2,
                    response: "{\r\n            \"AutomatchType\": 0,\r\n            \"Abroad\": true,\r\n            \"Weight\": 1.0,\r\n            \"Title\": \"Receptionist\",\r\n            \"JobHeadline\": \"Security Receptionist\",\r\n            \"Presentation\": \"Stilling\\n\\nSecurity Receptionist\\nJobbeskrivelse\\nJobbeskrivelse\\n\\nPlacering\\n\\nBagsværd, Denmark\\n\\nJobkategori\\n\\nGeneral Management and Administration\\n\\nAnsøg nu\\n\\n\u00A0 \u00A0\\n\\nSecurity receptionist in Novo Nordisk – \",\r\n            \"HiringOrgName\": \"Novo Nordisk A/S\",\r\n            \"WorkPlaceAddress\": \"Novo alle 1\",\r\n            \"WorkPlacePostalCode\": \"2880\",\r\n            \"WorkPlaceCity\": \"Bagsværd\",\r\n            \"WorkPlaceOtherAddress\": false,\r\n            \"WorkPlaceAbroad\": false,\r\n            \"WorkPlaceNotStatic\": false,\r\n            \"UseWorkPlaceAddressForJoblog\": true,\r\n            \"PostingCreated\": \"2021-07-02T00:00:00\",\r\n            \"LastDateApplication\": \"2021-07-06T00:00:00\",\r\n            \"FormattedLastDateApplication\": \"6. juli 2021\",\r\n            \"AssignmentStartDate\": \"2021-07-07T00:00:00\",\r\n            \"IsHotjob\": false,\r\n            \"IsExternal\": true,\r\n            \"Url\": \"https://www.novonordisk.dk/content/nncorp/dk/da/careers/find-a-job/job-ad.199941.en_GB.html\",\r\n            \"Region\": \"Hovedstaden og Bornholm\",\r\n            \"Municipality\": \"Lyngby-Taarbæk\",\r\n            \"Country\": \"\",\r\n            \"PostalCode\": \"2880\",\r\n            \"PostalCodeName\": null,\r\n            \"JobAnnouncementType\": \"Almindelige vilkår\",\r\n            \"EmploymentType\": \"Tidsbegrænset ansættelse\",\r\n            \"WorkHours\": \"Fuldtid\",\r\n            \"OccupationArea\": \"\",\r\n            \"OccupationGroup\": \"\",\r\n            \"Occupation\": \"\",\r\n            \"Location\": {\r\n                \"Latitude\": 55.7546,\r\n                \"Longitude\": 12.4552\r\n            },\r\n            \"JoblogWorkTime\": {\r\n                \"WorkHour\": null,\r\n                \"DailyWorkTime\": null\r\n            },\r\n            \"WorkplaceID\": 0,\r\n            \"OrganisationId\": \"\",\r\n            \"HiringOrgCVR\": 0,\r\n            \"UserLoggedIn\": false,\r\n            \"AnonymousEmployer\": false,\r\n            \"ShareUrl\": \"https://www.novonordisk.dk/content/nncorp/dk/da/careers/find-a-job/job-ad.199941.en_GB.html\",\r\n            \"DetailsUrl\": null,\r\n            \"JobLogUrl\": \"https://www.novonordisk.dk/content/nncorp/dk/da/careers/find-a-job/job-ad.199941.en_GB.html\",\r\n            \"HasLocationValues\": true,\r\n            \"ID\": \"E8251052\",\r\n            \"Latitude\": 55.7546,\r\n            \"Longitude\": 12.4552\r\n        }",
                    title: "Receptionist",
                    presentation: "Stilling\n\nSecurity Receptionist\nJobbeskrivelse\nJobbeskrivelse\n\nPlacering\n\nBagsværd, Denmark\n\nJobkategori\n\nGeneral Management and Administration\n\nAnsøg nu\n\n\u00A0 \u00A0\n\nSecurity receptionist in Novo Nordisk – ",
                    hiringOrgName: "Novo Nordisk A/S",
                    workPlaceAddress: "Novo alle 1",
                    workPlacePostalCode: 2880,
                    workPlaceCity: "Bagsværd",
                    postingCreated: new DateTime(2021, 07, 02),
                    lastDateApplication: new DateTime(2021, 07, 06),
                    url: "https://www.novonordisk.dk/content/nncorp/dk/da/careers/find-a-job/job-ad.199941.en_GB.html",
                    region: "Hovedstaden og Bornholm",
                    municipality: "Lyngby-Taarbæk",
                    country: "",
                    employmentType: "Tidsbegrænset ansættelse",
                    workHours: "Fuldtid",
                    occupation: "",
                    workplaceId: 0,
                    organisationId: null,
                    hiringOrgCVR: 0,
                    id: 8251052,
                    workPlaceCityWithoutZone: "Bagsværd",
                    jobPostingNumber: 10,
                    jobPostingId: "8251052receptionist"
                );
        internal static JobPostingExtended Shared_JobPage02_JobPostingExtended10
            = new JobPostingExtended(
                    jobPosting: Shared_JobPage02_JobPosting10,
                    response: Shared_FakeResponse,                      // Ignored
                    hiringOrgDescription: null,
                    publicationStartDate: null,
                    publicationEndDate: null,
                    purpose: Shared_FakePurpose,                        // Ignored
                    numberToFill: null,
                    contactEmail: null,
                    contactPersonName: null,
                    employmentDate: null,
                    applicationDeadlineDate: null,
                    bulletPoints: new HashSet<string>()
                    {
                        "The most important in this job is your personality. We\n weigh discretion highly and the importance of our customers\n getting a professional service when they are welcomed by you\n at our receptions.",
                        "We are an active part of the security setup and it will\n be an advantage if you have worked as an Security\n Receptionist before.",
                        "As you will have colleagues from very different\n backgrounds, it will require tolerance and understanding to\n positively gain from the differences.",
                        "You will need a good deal of curiosity and have the\n ability to work very thorough with your tasks.",
                        "You have a solid language background, speak and write\n Danish and English at a high level. It will be an advantage\n if you master another foreign language. You have the ability\n to absorb and handle large amounts of information and in\n depth organisational knowledge.",
                        "You are used to working in a large company and handling\n many different stakeholders. You are a super user in regards\n to the Office-package, are used to working with data and Key\n Performance Indicators (KPIs) and you have technical insight\n into SAP and IT systems including maintenance hereof."
                    },
                    bulletPointScenario: "novonordisk"
                );

        internal static JobPosting Shared_JobPage02_JobPosting11
            = new JobPosting(
                    runId: Shared_FakeRunId,
                    pageNumber: 2,
                    response: "{\r\n            \"AutomatchType\": 0,\r\n            \"Abroad\": true,\r\n            \"Weight\": 1.0,\r\n            \"Title\": \"Security Officer\",\r\n            \"JobHeadline\": \"Security officer\",\r\n            \"Presentation\": \"Stilling\\n\\nSecurity officer\\nJobbeskrivelse\\nJobbeskrivelse\\n\\nPlacering\\n\\nBagsværd, Denmark\\n\\nJobkategori\\n\\nQuality\\n\\nAnsøg nu\\n\\n\u00A0 \u00A0\\n\\nSecurity Officer, Novo Nordisk Alarm Response centre\\n\\nDo you wish to be par\",\r\n            \"HiringOrgName\": \"Novo Nordisk A/S\",\r\n            \"WorkPlaceAddress\": \"Novo alle 1\",\r\n            \"WorkPlacePostalCode\": \"2880\",\r\n            \"WorkPlaceCity\": \"Bagsværd\",\r\n            \"WorkPlaceOtherAddress\": false,\r\n            \"WorkPlaceAbroad\": false,\r\n            \"WorkPlaceNotStatic\": false,\r\n            \"UseWorkPlaceAddressForJoblog\": true,\r\n            \"PostingCreated\": \"2021-07-02T00:00:00\",\r\n            \"LastDateApplication\": \"2021-07-06T00:00:00\",\r\n            \"FormattedLastDateApplication\": \"6. juli 2021\",\r\n            \"AssignmentStartDate\": \"2021-07-07T00:00:00\",\r\n            \"IsHotjob\": false,\r\n            \"IsExternal\": true,\r\n            \"Url\": \"https://www.novonordisk.dk/content/nncorp/dk/da/careers/find-a-job/job-ad.199961.en_GB.html\",\r\n            \"Region\": \"Hovedstaden og Bornholm\",\r\n            \"Municipality\": \"Lyngby-Taarbæk\",\r\n            \"Country\": \"\",\r\n            \"PostalCode\": \"2880\",\r\n            \"PostalCodeName\": null,\r\n            \"JobAnnouncementType\": \"Almindelige vilkår\",\r\n            \"EmploymentType\": \"Fastansættelse\",\r\n            \"WorkHours\": \"Fuldtid\",\r\n            \"OccupationArea\": \"\",\r\n            \"OccupationGroup\": \"\",\r\n            \"Occupation\": \"\",\r\n            \"Location\": {\r\n                \"Latitude\": 55.7546,\r\n                \"Longitude\": 12.4552\r\n            },\r\n            \"JoblogWorkTime\": {\r\n                \"WorkHour\": null,\r\n                \"DailyWorkTime\": null\r\n            },\r\n            \"WorkplaceID\": 0,\r\n            \"OrganisationId\": \"\",\r\n            \"HiringOrgCVR\": 0,\r\n            \"UserLoggedIn\": false,\r\n            \"AnonymousEmployer\": false,\r\n            \"ShareUrl\": \"https://www.novonordisk.dk/content/nncorp/dk/da/careers/find-a-job/job-ad.199961.en_GB.html\",\r\n            \"DetailsUrl\": null,\r\n            \"JobLogUrl\": \"https://www.novonordisk.dk/content/nncorp/dk/da/careers/find-a-job/job-ad.199961.en_GB.html\",\r\n            \"HasLocationValues\": true,\r\n            \"ID\": \"E8251051\",\r\n            \"Latitude\": 55.7546,\r\n            \"Longitude\": 12.4552\r\n        }",
                    title: "Security Officer",
                    presentation: "Stilling\n\nSecurity officer\nJobbeskrivelse\nJobbeskrivelse\n\nPlacering\n\nBagsværd, Denmark\n\nJobkategori\n\nQuality\n\nAnsøg nu\n\n\u00A0 \u00A0\n\nSecurity Officer, Novo Nordisk Alarm Response centre\n\nDo you wish to be par",
                    hiringOrgName: "Novo Nordisk A/S",
                    workPlaceAddress: "Novo alle 1",
                    workPlacePostalCode: 2880,
                    workPlaceCity: "Bagsværd",
                    postingCreated: new DateTime(2021, 07, 02),
                    lastDateApplication: new DateTime(2021, 07, 06),
                    url: "https://www.novonordisk.dk/content/nncorp/dk/da/careers/find-a-job/job-ad.199961.en_GB.html",
                    region: "Hovedstaden og Bornholm",
                    municipality: "Lyngby-Taarbæk",
                    country: "",
                    employmentType: "Fastansættelse",
                    workHours: "Fuldtid",
                    occupation: "",
                    workplaceId: 0,
                    organisationId: null,
                    hiringOrgCVR: 0,
                    id: 8251051,
                    workPlaceCityWithoutZone: "Bagsværd",
                    jobPostingNumber: 11,
                    jobPostingId: "8251051securityofficer"
                );
        internal static JobPostingExtended Shared_JobPage02_JobPostingExtended11
            = new JobPostingExtended(
                    jobPosting: Shared_JobPage02_JobPosting11,
                    response: Shared_FakeResponse,                      // Ignored
                    hiringOrgDescription: null,
                    publicationStartDate: null,
                    publicationEndDate: null,
                    purpose: Shared_FakePurpose,                        // Ignored
                    numberToFill: null,
                    contactEmail: null,
                    contactPersonName: null,
                    employmentDate: null,
                    applicationDeadlineDate: null,
                    bulletPoints: new HashSet<string>()
                    {
                        "Behandlings-områder",
                        "Sundheds-personale",
                        "Videnskab &amp; teknologi",
                        "Bæredygtig forretning",
                        "Karriere",
                        "Om Novo Nordisk",
                        "",
                        "Få mere viden",
                        "Nyheder og presse",
                        "Kontakt os"
                    },
                    bulletPointScenario: "generic"
                );

        internal static JobPosting Shared_JobPage02_JobPosting12
            = new JobPosting(
                    runId: Shared_FakeRunId,
                    pageNumber: 2,
                    response: "{\r\n            \"AutomatchType\": 0,\r\n            \"Abroad\": true,\r\n            \"Weight\": 1.0,\r\n            \"Title\": \"PhD\",\r\n            \"JobHeadline\": \"PhD\",\r\n            \"Presentation\": \"Center for Permafrost (CENPERM) at University of Copenhagen is recruiting two postdoctoral associates to work with field-based ecosystem manipulations and process-based ecosystem modelling with a focu\",\r\n            \"HiringOrgName\": \"Københavns Universitet\",\r\n            \"WorkPlaceAddress\": \"\",\r\n            \"WorkPlacePostalCode\": \"\",\r\n            \"WorkPlaceCity\": \"\",\r\n            \"WorkPlaceOtherAddress\": false,\r\n            \"WorkPlaceAbroad\": false,\r\n            \"WorkPlaceNotStatic\": false,\r\n            \"UseWorkPlaceAddressForJoblog\": false,\r\n            \"PostingCreated\": \"2021-07-02T00:00:00\",\r\n            \"LastDateApplication\": \"2021-09-01T00:00:00\",\r\n            \"FormattedLastDateApplication\": \"1. september 2021\",\r\n            \"AssignmentStartDate\": \"2021-11-01T00:00:00\",\r\n            \"IsHotjob\": false,\r\n            \"IsExternal\": true,\r\n            \"Url\": \"https://jobportal.ku.dk/videnskabelige-stillinger/?show=154356\",\r\n            \"Region\": \"Hovedstaden og Bornholm\",\r\n            \"Municipality\": \"København\",\r\n            \"Country\": \"\",\r\n            \"PostalCode\": \"1000\",\r\n            \"PostalCodeName\": null,\r\n            \"JobAnnouncementType\": \"Almindelige vilkår\",\r\n            \"EmploymentType\": \"Tidsbegrænset ansættelse\",\r\n            \"WorkHours\": \"Fuldtid\",\r\n            \"OccupationArea\": \"\",\r\n            \"OccupationGroup\": \"\",\r\n            \"Occupation\": \"\",\r\n            \"Location\": null,\r\n            \"JoblogWorkTime\": {\r\n                \"WorkHour\": null,\r\n                \"DailyWorkTime\": null\r\n            },\r\n            \"WorkplaceID\": 0,\r\n            \"OrganisationId\": \"\",\r\n            \"HiringOrgCVR\": 0,\r\n            \"UserLoggedIn\": false,\r\n            \"AnonymousEmployer\": false,\r\n            \"ShareUrl\": \"https://jobportal.ku.dk/videnskabelige-stillinger/?show=154356\",\r\n            \"DetailsUrl\": null,\r\n            \"JobLogUrl\": \"https://jobportal.ku.dk/videnskabelige-stillinger/?show=154356\",\r\n            \"HasLocationValues\": false,\r\n            \"ID\": \"E8251042\",\r\n            \"Latitude\": 0.0,\r\n            \"Longitude\": 0.0\r\n        }",
                    title: "PhD",
                    presentation: "Center for Permafrost (CENPERM) at University of Copenhagen is recruiting two postdoctoral associates to work with field-based ecosystem manipulations and process-based ecosystem modelling with a focu",
                    hiringOrgName: "Københavns Universitet",
                    workPlaceAddress: "",
                    workPlacePostalCode: null,
                    workPlaceCity: "",
                    postingCreated: new DateTime(2021, 07, 02),
                    lastDateApplication: new DateTime(2021, 09, 01),
                    url: "https://jobportal.ku.dk/videnskabelige-stillinger/?show=154356",
                    region: "Hovedstaden og Bornholm",
                    municipality: "København",
                    country: "",
                    employmentType: "Tidsbegrænset ansættelse",
                    workHours: "Fuldtid",
                    occupation: "",
                    workplaceId: 0,
                    organisationId: null,
                    hiringOrgCVR: 0,
                    id: 8251042,
                    workPlaceCityWithoutZone: "",
                    jobPostingNumber: 12,
                    jobPostingId: "8251042phd"
                );
        internal static JobPostingExtended Shared_JobPage02_JobPostingExtended12
            = new JobPostingExtended(
                    jobPosting: Shared_JobPage02_JobPosting12,
                    response: Shared_FakeResponse,                      // Ignored
                    hiringOrgDescription: null,
                    publicationStartDate: null,
                    publicationEndDate: null,
                    purpose: Shared_FakePurpose,                        // Ignored
                    numberToFill: null,
                    contactEmail: null,
                    contactPersonName: null,
                    employmentDate: null,
                    applicationDeadlineDate: null,
                    bulletPoints: new HashSet<string>()
                    {
                        "Field-based ecosystem manipulations experiments and monitoring of greenhouse gas production",
                        "Measurements of subsurface and snow gas concentrations, diffusion and greenhouse gas fluxes",
                        "Process-based models to simulate changes in climate-soil-plant-microbial characteristics",
                        "Structural equation modelling",
                        "Letter of application",
                        "Curriculum vita, incl. education, experience, previous employments, language skills and other relevant skills (max 5 pages).",
                        "Detailed outline of proposed research, including research questions and methods (max 5 pages)",
                        "Diplomas (Master and PhD degree or equivalent)",
                        "Complete publication list, highlighting the 3 most important ones",
                        "Separate reprints of 3 particularly relevant papers",
                        "Two letters of recommendation."
                    },
                    bulletPointScenario: "jobportal"
                );

        internal static JobPosting Shared_JobPage02_JobPosting13
            = new JobPosting(
                    runId: Shared_FakeRunId,
                    pageNumber: 2,
                    response: "{\r\n            \"AutomatchType\": 0,\r\n            \"Abroad\": true,\r\n            \"Weight\": 1.0,\r\n            \"Title\": \"Specialist\",\r\n            \"JobHeadline\": \"Clinical disclosure specialist\",\r\n            \"Presentation\": \"Are you an expert in clinical disclosure regulations and can you drive the implementation and ensure compliance? Then continue reading!\\n\u00A0\\n\\nLEO Pharma has embarked on a very ambitious journey to become\",\r\n            \"HiringOrgName\": \"LEO Pharma A/S\",\r\n            \"WorkPlaceAddress\": \"Industriparken 55\",\r\n            \"WorkPlacePostalCode\": \"2750\",\r\n            \"WorkPlaceCity\": \"Ballerup\",\r\n            \"WorkPlaceOtherAddress\": false,\r\n            \"WorkPlaceAbroad\": false,\r\n            \"WorkPlaceNotStatic\": false,\r\n            \"UseWorkPlaceAddressForJoblog\": true,\r\n            \"PostingCreated\": \"2021-07-02T00:00:00\",\r\n            \"LastDateApplication\": \"2021-08-01T00:00:00\",\r\n            \"FormattedLastDateApplication\": \"1. august 2021\",\r\n            \"AssignmentStartDate\": \"2021-08-02T00:00:00\",\r\n            \"IsHotjob\": false,\r\n            \"IsExternal\": true,\r\n            \"Url\": \"https://leopharma.easycruit.com/vacancy/2738279/127513?iso=dk\",\r\n            \"Region\": \"Hovedstaden og Bornholm\",\r\n            \"Municipality\": \"Ballerup\",\r\n            \"Country\": \"\",\r\n            \"PostalCode\": \"2750\",\r\n            \"PostalCodeName\": null,\r\n            \"JobAnnouncementType\": \"Almindelige vilkår\",\r\n            \"EmploymentType\": \"Fastansættelse\",\r\n            \"WorkHours\": \"Fuldtid\",\r\n            \"OccupationArea\": \"\",\r\n            \"OccupationGroup\": \"\",\r\n            \"Occupation\": \"\",\r\n            \"Location\": {\r\n                \"Latitude\": 55.7268,\r\n                \"Longitude\": 12.3937\r\n            },\r\n            \"JoblogWorkTime\": {\r\n                \"WorkHour\": null,\r\n                \"DailyWorkTime\": null\r\n            },\r\n            \"WorkplaceID\": 0,\r\n            \"OrganisationId\": \"\",\r\n            \"HiringOrgCVR\": 0,\r\n            \"UserLoggedIn\": false,\r\n            \"AnonymousEmployer\": false,\r\n            \"ShareUrl\": \"https://leopharma.easycruit.com/vacancy/2738279/127513?iso=dk\",\r\n            \"DetailsUrl\": null,\r\n            \"JobLogUrl\": \"https://leopharma.easycruit.com/vacancy/2738279/127513?iso=dk\",\r\n            \"HasLocationValues\": true,\r\n            \"ID\": \"E8251041\",\r\n            \"Latitude\": 55.7268,\r\n            \"Longitude\": 12.3937\r\n        }",
                    title: "Specialist",
                    presentation: "Are you an expert in clinical disclosure regulations and can you drive the implementation and ensure compliance? Then continue reading!\n\u00A0\n\nLEO Pharma has embarked on a very ambitious journey to become",
                    hiringOrgName: "LEO Pharma A/S",
                    workPlaceAddress: "Industriparken 55",
                    workPlacePostalCode: 2750,
                    workPlaceCity: "Ballerup",
                    postingCreated: new DateTime(2021, 07, 02),
                    lastDateApplication: new DateTime(2021, 08, 01),
                    url: "https://leopharma.easycruit.com/vacancy/2738279/127513?iso=dk",
                    region: "Hovedstaden og Bornholm",
                    municipality: "Ballerup",
                    country: "",
                    employmentType: "Fastansættelse",
                    workHours: "Fuldtid",
                    occupation: "",
                    workplaceId: 0,
                    organisationId: null,
                    hiringOrgCVR: 0,
                    id: 8251041,
                    workPlaceCityWithoutZone: "Ballerup",
                    jobPostingNumber: 13,
                    jobPostingId: "8251041specialist"
                );
        internal static JobPostingExtended Shared_JobPage02_JobPostingExtended13
            = new JobPostingExtended(
                    jobPosting: Shared_JobPage02_JobPosting13,
                    response: Shared_FakeResponse,                      // Ignored
                    hiringOrgDescription: null,
                    publicationStartDate: null,
                    publicationEndDate: null,
                    purpose: Shared_FakePurpose,                        // Ignored
                    numberToFill: null,
                    contactEmail: null,
                    contactPersonName: null,
                    employmentDate: null,
                    applicationDeadlineDate: null,
                    bulletPoints: new HashSet<string>()
                    {
                        "Subject matter expert with responsibility for planning, advising on, coordinating, and handling public disclosure of clinical trial information.",
                        "Monitor and evaluate the clinical trial disclosure landscape, including regulatory requirements and industry trends.",
                        "Develop, pilot, implement, update, and maintain procedures to ensure compliance with regulations and other commitments for clinical data transparency.",
                        "University degree in health or biological science (MD, MSc, MSc Pharm or equivalent).",
                        "Thorough knowledge of clinical development, GCP, scientific research methods, and applicable regulatory guidelines. Understanding of clinical statistics.",
                        "Strong IT flair – documented through previous experience, either professional or private.",
                        "Prior experience with clinical disclosure will be an advantage."
                    },
                    bulletPointScenario: "easycruit"
                );

        internal static JobPosting Shared_JobPage02_JobPosting14
            = new JobPosting(
                    runId: Shared_FakeRunId,
                    pageNumber: 2,
                    response: "{\r\n            \"AutomatchType\": 0,\r\n            \"Abroad\": true,\r\n            \"Weight\": 1.0,\r\n            \"Title\": \"Support Engineer\",\r\n            \"JobHeadline\": \"Customer Support Engineer for Alfa Laval Aalborg\",\r\n            \"Presentation\": \"Customer Support Engineer for Alfa Laval Aalborg\\nAalborg\\nApply\\n\\nAt Alfa Laval, we always go that extra mile to overcome the toughest challenges. Our driving force is to accelerate success for our cust\",\r\n            \"HiringOrgName\": \"Alfa Laval Aalborg A/S\",\r\n            \"WorkPlaceAddress\": \"Gasværksvej 21\",\r\n            \"WorkPlacePostalCode\": \"9000\",\r\n            \"WorkPlaceCity\": \"Aalborg\",\r\n            \"WorkPlaceOtherAddress\": false,\r\n            \"WorkPlaceAbroad\": false,\r\n            \"WorkPlaceNotStatic\": false,\r\n            \"UseWorkPlaceAddressForJoblog\": true,\r\n            \"PostingCreated\": \"2021-07-02T00:00:00\",\r\n            \"LastDateApplication\": \"2021-07-20T00:00:00\",\r\n            \"FormattedLastDateApplication\": \"20. juli 2021\",\r\n            \"AssignmentStartDate\": \"2021-07-21T00:00:00\",\r\n            \"IsHotjob\": false,\r\n            \"IsExternal\": true,\r\n            \"Url\": \"https://alfalaval.wd3.myworkdayjobs.com/en-US/Alfa_Laval_jobs/job/Aalborg/Customer-Support-Engineer-for-Alfa-Laval-Aalborg_JR0007198\",\r\n            \"Region\": \"Nordjylland\",\r\n            \"Municipality\": \"Aalborg\",\r\n            \"Country\": \"\",\r\n            \"PostalCode\": \"9000\",\r\n            \"PostalCodeName\": null,\r\n            \"JobAnnouncementType\": \"Almindelige vilkår\",\r\n            \"EmploymentType\": \"Fastansættelse\",\r\n            \"WorkHours\": \"Fuldtid\",\r\n            \"OccupationArea\": \"\",\r\n            \"OccupationGroup\": \"\",\r\n            \"Occupation\": \"\",\r\n            \"Location\": {\r\n                \"Latitude\": 57.0493,\r\n                \"Longitude\": 9.9485\r\n            },\r\n            \"JoblogWorkTime\": {\r\n                \"WorkHour\": null,\r\n                \"DailyWorkTime\": null\r\n            },\r\n            \"WorkplaceID\": 0,\r\n            \"OrganisationId\": \"\",\r\n            \"HiringOrgCVR\": 0,\r\n            \"UserLoggedIn\": false,\r\n            \"AnonymousEmployer\": false,\r\n            \"ShareUrl\": \"https://alfalaval.wd3.myworkdayjobs.com/en-US/Alfa_Laval_jobs/job/Aalborg/Customer-Support-Engineer-for-Alfa-Laval-Aalborg_JR0007198\",\r\n            \"DetailsUrl\": null,\r\n            \"JobLogUrl\": \"https://alfalaval.wd3.myworkdayjobs.com/en-US/Alfa_Laval_jobs/job/Aalborg/Customer-Support-Engineer-for-Alfa-Laval-Aalborg_JR0007198\",\r\n            \"HasLocationValues\": true,\r\n            \"ID\": \"E8251039\",\r\n            \"Latitude\": 57.0493,\r\n            \"Longitude\": 9.9485\r\n        }",
                    title: "Support Engineer",
                    presentation: "Customer Support Engineer for Alfa Laval Aalborg\nAalborg\nApply\n\nAt Alfa Laval, we always go that extra mile to overcome the toughest challenges. Our driving force is to accelerate success for our cust",
                    hiringOrgName: "Alfa Laval Aalborg A/S",
                    workPlaceAddress: "Gasværksvej 21",
                    workPlacePostalCode: 9000,
                    workPlaceCity: "Aalborg",
                    postingCreated: new DateTime(2021, 07, 02),
                    lastDateApplication: new DateTime(2021, 07, 20),
                    url: "https://alfalaval.wd3.myworkdayjobs.com/en-US/Alfa_Laval_jobs/job/Aalborg/Customer-Support-Engineer-for-Alfa-Laval-Aalborg_JR0007198",
                    region: "Nordjylland",
                    municipality: "Aalborg",
                    country: "",
                    employmentType: "Fastansættelse",
                    workHours: "Fuldtid",
                    occupation: "",
                    workplaceId: 0,
                    organisationId: null,
                    hiringOrgCVR: 0,
                    id: 8251039,
                    workPlaceCityWithoutZone: "Aalborg",
                    jobPostingNumber: 14,
                    jobPostingId: "8251039supportengineer"
                );
        internal static JobPostingExtended Shared_JobPage02_JobPostingExtended14
            = new JobPostingExtended(
                    jobPosting: Shared_JobPage02_JobPosting14,
                    response: Shared_FakeResponse,                      // Ignored
                    hiringOrgDescription: null,
                    publicationStartDate: null,
                    publicationEndDate: null,
                    purpose: Shared_FakePurpose,                        // Ignored
                    numberToFill: null,
                    contactEmail: null,
                    contactPersonName: null,
                    employmentDate: null,
                    applicationDeadlineDate: null,
                    bulletPoints: null,
                    bulletPointScenario: null
                );

        internal static JobPosting Shared_JobPage02_JobPosting15
            = new JobPosting(
                    runId: Shared_FakeRunId,
                    pageNumber: 2,
                    response: "{\r\n            \"AutomatchType\": 0,\r\n            \"Abroad\": true,\r\n            \"Weight\": 1.0,\r\n            \"Title\": \"Software Developer\",\r\n            \"JobHeadline\": \"Software Developers (Back End & Full Stack)\",\r\n            \"Presentation\": \" \\nSoftware Developers (Back End & Full Stack)\\nDenmark Copenhagen Local IT Last application date: 17/7/2021\\nMaersk is going through times of unprecedented change. We are rethinking the way we engage wi\",\r\n            \"HiringOrgName\": \"A.P. Møller - Mærsk A/S\",\r\n            \"WorkPlaceAddress\": \"\",\r\n            \"WorkPlacePostalCode\": \"\",\r\n            \"WorkPlaceCity\": \"\",\r\n            \"WorkPlaceOtherAddress\": false,\r\n            \"WorkPlaceAbroad\": false,\r\n            \"WorkPlaceNotStatic\": false,\r\n            \"UseWorkPlaceAddressForJoblog\": false,\r\n            \"PostingCreated\": \"2021-07-02T00:00:00\",\r\n            \"LastDateApplication\": \"2021-07-17T00:00:00\",\r\n            \"FormattedLastDateApplication\": \"17. juli 2021\",\r\n            \"AssignmentStartDate\": \"2021-07-18T00:00:00\",\r\n            \"IsHotjob\": false,\r\n            \"IsExternal\": true,\r\n            \"Url\": \"https://jobsearch.maersk.com/jobposting/index.html?id=MA-275828\",\r\n            \"Region\": \"Hovedstaden og Bornholm\",\r\n            \"Municipality\": \"København\",\r\n            \"Country\": \"\",\r\n            \"PostalCode\": \"1000\",\r\n            \"PostalCodeName\": null,\r\n            \"JobAnnouncementType\": \"Almindelige vilkår\",\r\n            \"EmploymentType\": \"Fastansættelse\",\r\n            \"WorkHours\": \"Fuldtid\",\r\n            \"OccupationArea\": \"\",\r\n            \"OccupationGroup\": \"\",\r\n            \"Occupation\": \"\",\r\n            \"Location\": null,\r\n            \"JoblogWorkTime\": {\r\n                \"WorkHour\": null,\r\n                \"DailyWorkTime\": null\r\n            },\r\n            \"WorkplaceID\": 0,\r\n            \"OrganisationId\": \"\",\r\n            \"HiringOrgCVR\": 0,\r\n            \"UserLoggedIn\": false,\r\n            \"AnonymousEmployer\": false,\r\n            \"ShareUrl\": \"https://jobsearch.maersk.com/jobposting/index.html?id=MA-275828\",\r\n            \"DetailsUrl\": null,\r\n            \"JobLogUrl\": \"https://jobsearch.maersk.com/jobposting/index.html?id=MA-275828\",\r\n            \"HasLocationValues\": false,\r\n            \"ID\": \"E8251038\",\r\n            \"Latitude\": 0.0,\r\n            \"Longitude\": 0.0\r\n        }",
                    title: "Software Developer",
                    presentation: " \nSoftware Developers (Back End & Full Stack)\nDenmark Copenhagen Local IT Last application date: 17/7/2021\nMaersk is going through times of unprecedented change. We are rethinking the way we engage wi",
                    hiringOrgName: "A.P. Møller - Mærsk A/S",
                    workPlaceAddress: "",
                    workPlacePostalCode: null,
                    workPlaceCity: "",
                    postingCreated: new DateTime(2021, 07, 02),
                    lastDateApplication: new DateTime(2021, 07, 17),
                    url: "https://jobsearch.maersk.com/jobposting/index.html?id=MA-275828",
                    region: "Hovedstaden og Bornholm",
                    municipality: "København",
                    country: "",
                    employmentType: "Fastansættelse",
                    workHours: "Fuldtid",
                    occupation: "",
                    workplaceId: 0,
                    organisationId: null,
                    hiringOrgCVR: 0,
                    id: 8251038,
                    workPlaceCityWithoutZone: "",
                    jobPostingNumber: 15,
                    jobPostingId: "8251038softwaredeveloper"
                );
        internal static JobPostingExtended Shared_JobPage02_JobPostingExtended15
            = new JobPostingExtended(
                    jobPosting: Shared_JobPage02_JobPosting15,
                    response: Shared_FakeResponse,                      // Ignored
                    hiringOrgDescription: null,
                    publicationStartDate: null,
                    publicationEndDate: null,
                    purpose: Shared_FakePurpose,                        // Ignored
                    numberToFill: null,
                    contactEmail: null,
                    contactPersonName: null,
                    employmentDate: null,
                    applicationDeadlineDate: null,
                    bulletPoints: new HashSet<string>()
                    {
                        "",
                        "Facebook",
                        "Linkedin",
                        "Google+",
                        "Twitter",
                        "Email",
                        "Print"
                    },
                    bulletPointScenario: "generic"
                );

        internal static JobPosting Shared_JobPage02_JobPosting16
            = new JobPosting(
                    runId: Shared_FakeRunId,
                    pageNumber: 2,
                    response: "{\r\n            \"AutomatchType\": 0,\r\n            \"Abroad\": true,\r\n            \"Weight\": 1.0,\r\n            \"Title\": \"PhD\",\r\n            \"JobHeadline\": \"PhD\",\r\n            \"Presentation\": \"PhD Stipend in State of Temperature Estimation in Smart Batteries using Artificial Intelligence (14-21065) At the Faculty of Engineering and Science, Department of Energy Technology a PhD stipend is a\",\r\n            \"HiringOrgName\": \"Aalborg Universitet\",\r\n            \"WorkPlaceAddress\": \"\",\r\n            \"WorkPlacePostalCode\": \"9000\",\r\n            \"WorkPlaceCity\": \"Aalborg\",\r\n            \"WorkPlaceOtherAddress\": false,\r\n            \"WorkPlaceAbroad\": false,\r\n            \"WorkPlaceNotStatic\": false,\r\n            \"UseWorkPlaceAddressForJoblog\": true,\r\n            \"PostingCreated\": \"2021-07-02T00:00:00\",\r\n            \"LastDateApplication\": \"2021-07-28T00:00:00\",\r\n            \"FormattedLastDateApplication\": \"28. juli 2021\",\r\n            \"AssignmentStartDate\": \"2021-11-01T00:00:00\",\r\n            \"IsHotjob\": false,\r\n            \"IsExternal\": true,\r\n            \"Url\": \"https://www.stillinger.aau.dk/vis-stilling/?vacancy=1159620\",\r\n            \"Region\": \"Nordjylland\",\r\n            \"Municipality\": \"Aalborg\",\r\n            \"Country\": \"\",\r\n            \"PostalCode\": \"9000\",\r\n            \"PostalCodeName\": null,\r\n            \"JobAnnouncementType\": \"Almindelige vilkår\",\r\n            \"EmploymentType\": \"Tidsbegrænset ansættelse\",\r\n            \"WorkHours\": \"Fuldtid\",\r\n            \"OccupationArea\": \"\",\r\n            \"OccupationGroup\": \"\",\r\n            \"Occupation\": \"\",\r\n            \"Location\": {\r\n                \"Latitude\": 57.0517,\r\n                \"Longitude\": 9.835\r\n            },\r\n            \"JoblogWorkTime\": {\r\n                \"WorkHour\": null,\r\n                \"DailyWorkTime\": null\r\n            },\r\n            \"WorkplaceID\": 0,\r\n            \"OrganisationId\": \"\",\r\n            \"HiringOrgCVR\": 0,\r\n            \"UserLoggedIn\": false,\r\n            \"AnonymousEmployer\": false,\r\n            \"ShareUrl\": \"https://www.stillinger.aau.dk/vis-stilling/?vacancy=1159620\",\r\n            \"DetailsUrl\": null,\r\n            \"JobLogUrl\": \"https://www.stillinger.aau.dk/vis-stilling/?vacancy=1159620\",\r\n            \"HasLocationValues\": true,\r\n            \"ID\": \"E8251036\",\r\n            \"Latitude\": 57.0517,\r\n            \"Longitude\": 9.835\r\n        }",
                    title: "PhD",
                    presentation: "PhD Stipend in State of Temperature Estimation in Smart Batteries using Artificial Intelligence (14-21065) At the Faculty of Engineering and Science, Department of Energy Technology a PhD stipend is a",
                    hiringOrgName: "Aalborg Universitet",
                    workPlaceAddress: "",
                    workPlacePostalCode: 9000,
                    workPlaceCity: "Aalborg",
                    postingCreated: new DateTime(2021, 07, 02),
                    lastDateApplication: new DateTime(2021, 07, 28),
                    url: "https://www.stillinger.aau.dk/vis-stilling/?vacancy=1159620",
                    region: "Nordjylland",
                    municipality: "Aalborg",
                    country: "",
                    employmentType: "Tidsbegrænset ansættelse",
                    workHours: "Fuldtid",
                    occupation: "",
                    workplaceId: 0,
                    organisationId: null,
                    hiringOrgCVR: 0,
                    id: 8251036,
                    workPlaceCityWithoutZone: "Aalborg",
                    jobPostingNumber: 16,
                    jobPostingId: "8251036phd"
                );
        internal static JobPostingExtended Shared_JobPage02_JobPostingExtended16
            = new JobPostingExtended(
                    jobPosting: Shared_JobPage02_JobPosting16,
                    response: Shared_FakeResponse,                      // Ignored
                    hiringOrgDescription: null,
                    publicationStartDate: null,
                    publicationEndDate: null,
                    purpose: Shared_FakePurpose,                        // Ignored
                    numberToFill: null,
                    contactEmail: null,
                    contactPersonName: null,
                    employmentDate: null,
                    applicationDeadlineDate: null,
                    bulletPoints: new HashSet<string>()
                    {
                        "Nyheder",
                        "Arrangementer",
                        "Kontakt og find rundt",
                        "Campusområder",
                        "For Pressen",
                        "For alumni",
                        "Genveje \n \n Nyheder \n Arrangementer \n Kontakt og find rundt \n Campusområder \n For Pressen \n For alumni",
                        "aau uddannelse",
                        "aau forskning",
                        "aau samarbejde",
                        "Om AAU",
                        "Ledige stillinger",
                        "Ansatte og studerende",
                        "",
                        "Ledige stillinger på AAU",
                        "/",
                        "Vis stilling",
                        "Alle videnskabelige stillinger",
                        "Alle teknisk-administrative stillinger",
                        "Alle Phd stillinger",
                        "Alle ledige stillinger",
                        "AAU som arbejdsplads",
                        "AAU&#039;s personalepolitik",
                        "Organisation",
                        "Problembaseret læring",
                        "Strategi og udvikling",
                        "Internationalt samarbejde",
                        "Historie, priser og hæder",
                        "Uddannelseskvalitet",
                        "AAU i tal",
                        "Facebook",
                        "LinkedIn",
                        "Instagram",
                        "Snapchat",
                        "YouTube"
                    },
                    bulletPointScenario: "generic"
                );

        internal static JobPosting Shared_JobPage02_JobPosting17
            = new JobPosting(
                    runId: Shared_FakeRunId,
                    pageNumber: 2,
                    response: "{\r\n            \"AutomatchType\": 0,\r\n            \"Abroad\": true,\r\n            \"Weight\": 1.0,\r\n            \"Title\": \"Leader\",\r\n            \"JobHeadline\": \"Commercial Excellence Manager\",\r\n            \"Presentation\": \" \\nCommercial Excellence Manager\\nDenmark Nordhavn, Copenhagen Local Commercial/Sales/Business Development Last application date: 5/8/2021\\nHello, this is Elijah, Betha, and Suraj and we are looking for \",\r\n            \"HiringOrgName\": \"Rederiet A.P. Møller A/S\",\r\n            \"WorkPlaceAddress\": \"\",\r\n            \"WorkPlacePostalCode\": \"\",\r\n            \"WorkPlaceCity\": \"\",\r\n            \"WorkPlaceOtherAddress\": false,\r\n            \"WorkPlaceAbroad\": false,\r\n            \"WorkPlaceNotStatic\": false,\r\n            \"UseWorkPlaceAddressForJoblog\": false,\r\n            \"PostingCreated\": \"2021-07-02T00:00:00\",\r\n            \"LastDateApplication\": \"2021-08-05T00:00:00\",\r\n            \"FormattedLastDateApplication\": \"5. august 2021\",\r\n            \"AssignmentStartDate\": \"2021-08-06T00:00:00\",\r\n            \"IsHotjob\": false,\r\n            \"IsExternal\": true,\r\n            \"Url\": \"https://jobsearch.maersk.com/jobposting/index.html?id=SV-275846\",\r\n            \"Region\": \"Hovedstaden og Bornholm\",\r\n            \"Municipality\": \"København\",\r\n            \"Country\": \"\",\r\n            \"PostalCode\": \"1000\",\r\n            \"PostalCodeName\": null,\r\n            \"JobAnnouncementType\": \"Almindelige vilkår\",\r\n            \"EmploymentType\": \"Fastansættelse\",\r\n            \"WorkHours\": \"Fuldtid\",\r\n            \"OccupationArea\": \"\",\r\n            \"OccupationGroup\": \"\",\r\n            \"Occupation\": \"\",\r\n            \"Location\": null,\r\n            \"JoblogWorkTime\": {\r\n                \"WorkHour\": null,\r\n                \"DailyWorkTime\": null\r\n            },\r\n            \"WorkplaceID\": 0,\r\n            \"OrganisationId\": \"\",\r\n            \"HiringOrgCVR\": 0,\r\n            \"UserLoggedIn\": false,\r\n            \"AnonymousEmployer\": false,\r\n            \"ShareUrl\": \"https://jobsearch.maersk.com/jobposting/index.html?id=SV-275846\",\r\n            \"DetailsUrl\": null,\r\n            \"JobLogUrl\": \"https://jobsearch.maersk.com/jobposting/index.html?id=SV-275846\",\r\n            \"HasLocationValues\": false,\r\n            \"ID\": \"E8251035\",\r\n            \"Latitude\": 0.0,\r\n            \"Longitude\": 0.0\r\n        }",
                    title: "Leader",
                    presentation: " \nCommercial Excellence Manager\nDenmark Nordhavn, Copenhagen Local Commercial/Sales/Business Development Last application date: 5/8/2021\nHello, this is Elijah, Betha, and Suraj and we are looking for ",
                    hiringOrgName: "Rederiet A.P. Møller A/S",
                    workPlaceAddress: "",
                    workPlacePostalCode: null,
                    workPlaceCity: "",
                    postingCreated: new DateTime(2021, 07, 02),
                    lastDateApplication: new DateTime(2021, 08, 05),
                    url: "https://jobsearch.maersk.com/jobposting/index.html?id=SV-275846",
                    region: "Hovedstaden og Bornholm",
                    municipality: "København",
                    country: "",
                    employmentType: "Fastansættelse",
                    workHours: "Fuldtid",
                    occupation: "",
                    workplaceId: 0,
                    organisationId: null,
                    hiringOrgCVR: 0,
                    id: 8251035,
                    workPlaceCityWithoutZone: "",
                    jobPostingNumber: 17,
                    jobPostingId: "8251035leader"
                );
        internal static JobPostingExtended Shared_JobPage02_JobPostingExtended17
            = new JobPostingExtended(
                    jobPosting: Shared_JobPage02_JobPosting17,
                    response: Shared_FakeResponse,                      // Ignored
                    hiringOrgDescription: null,
                    publicationStartDate: null,
                    publicationEndDate: null,
                    purpose: Shared_FakePurpose,                        // Ignored
                    numberToFill: null,
                    contactEmail: null,
                    contactPersonName: null,
                    employmentDate: null,
                    applicationDeadlineDate: null,
                    bulletPoints: new HashSet<string>()
                    {
                        "",
                        "Facebook",
                        "Linkedin",
                        "Google+",
                        "Twitter",
                        "Email",
                        "Print"
                    },
                    bulletPointScenario: "generic"
                );

        internal static JobPosting Shared_JobPage02_JobPosting18
            = new JobPosting(
                    runId: Shared_FakeRunId,
                    pageNumber: 2,
                    response: "{\r\n            \"AutomatchType\": 0,\r\n            \"Abroad\": true,\r\n            \"Weight\": 1.0,\r\n            \"Title\": \"Product Owner\",\r\n            \"JobHeadline\": \"Lead Logistics Orchestration Product Owner\",\r\n            \"Presentation\": \" \\nLead Logistics Orchestration Product Owner\\nDenmark Copenhagen Local Supply Chain/Logistics Operations Last application date: 16/7/2021\\nAs part of the core product team, the Senior Business Product M\",\r\n            \"HiringOrgName\": \"A.P. Møller - Mærsk A/S\",\r\n            \"WorkPlaceAddress\": \"\",\r\n            \"WorkPlacePostalCode\": \"\",\r\n            \"WorkPlaceCity\": \"\",\r\n            \"WorkPlaceOtherAddress\": false,\r\n            \"WorkPlaceAbroad\": false,\r\n            \"WorkPlaceNotStatic\": false,\r\n            \"UseWorkPlaceAddressForJoblog\": false,\r\n            \"PostingCreated\": \"2021-07-02T00:00:00\",\r\n            \"LastDateApplication\": \"2021-07-16T00:00:00\",\r\n            \"FormattedLastDateApplication\": \"16. juli 2021\",\r\n            \"AssignmentStartDate\": \"2021-07-17T00:00:00\",\r\n            \"IsHotjob\": false,\r\n            \"IsExternal\": true,\r\n            \"Url\": \"https://jobsearch.maersk.com/jobposting/index.html?id=MA-275792\",\r\n            \"Region\": \"Hovedstaden og Bornholm\",\r\n            \"Municipality\": \"København\",\r\n            \"Country\": \"\",\r\n            \"PostalCode\": \"1000\",\r\n            \"PostalCodeName\": null,\r\n            \"JobAnnouncementType\": \"Almindelige vilkår\",\r\n            \"EmploymentType\": \"Fastansættelse\",\r\n            \"WorkHours\": \"Fuldtid\",\r\n            \"OccupationArea\": \"\",\r\n            \"OccupationGroup\": \"\",\r\n            \"Occupation\": \"\",\r\n            \"Location\": null,\r\n            \"JoblogWorkTime\": {\r\n                \"WorkHour\": null,\r\n                \"DailyWorkTime\": null\r\n            },\r\n            \"WorkplaceID\": 0,\r\n            \"OrganisationId\": \"\",\r\n            \"HiringOrgCVR\": 0,\r\n            \"UserLoggedIn\": false,\r\n            \"AnonymousEmployer\": false,\r\n            \"ShareUrl\": \"https://jobsearch.maersk.com/jobposting/index.html?id=MA-275792\",\r\n            \"DetailsUrl\": null,\r\n            \"JobLogUrl\": \"https://jobsearch.maersk.com/jobposting/index.html?id=MA-275792\",\r\n            \"HasLocationValues\": false,\r\n            \"ID\": \"E8251034\",\r\n            \"Latitude\": 0.0,\r\n            \"Longitude\": 0.0\r\n        }",
                    title: "Product Owner",
                    presentation: " \nLead Logistics Orchestration Product Owner\nDenmark Copenhagen Local Supply Chain/Logistics Operations Last application date: 16/7/2021\nAs part of the core product team, the Senior Business Product M",
                    hiringOrgName: "A.P. Møller - Mærsk A/S",
                    workPlaceAddress: "",
                    workPlacePostalCode: null,
                    workPlaceCity: "",
                    postingCreated: new DateTime(2021, 07, 02),
                    lastDateApplication: new DateTime(2021, 07, 16),
                    url: "https://jobsearch.maersk.com/jobposting/index.html?id=MA-275792",
                    region: "Hovedstaden og Bornholm",
                    municipality: "København",
                    country: "",
                    employmentType: "Fastansættelse",
                    workHours: "Fuldtid",
                    occupation: "",
                    workplaceId: 0,
                    organisationId: null,
                    hiringOrgCVR: 0,
                    id: 8251034,
                    workPlaceCityWithoutZone: "",
                    jobPostingNumber: 18,
                    jobPostingId: "8251034productowner"
                );
        internal static JobPostingExtended Shared_JobPage02_JobPostingExtended18
            = new JobPostingExtended(
                    jobPosting: Shared_JobPage02_JobPosting18,
                    response: Shared_FakeResponse,                      // Ignored
                    hiringOrgDescription: null,
                    publicationStartDate: null,
                    publicationEndDate: null,
                    purpose: Shared_FakePurpose,                        // Ignored
                    numberToFill: null,
                    contactEmail: null,
                    contactPersonName: null,
                    employmentDate: null,
                    applicationDeadlineDate: null,
                    bulletPoints: new HashSet<string>()
                    {
                        "",
                        "Facebook",
                        "Linkedin",
                        "Google+",
                        "Twitter",
                        "Email",
                        "Print"
                    },
                    bulletPointScenario: "generic"
                );

        internal static JobPosting Shared_JobPage02_JobPosting19
            = new JobPosting(
                    runId: Shared_FakeRunId,
                    pageNumber: 2,
                    response: "{\r\n            \"AutomatchType\": 0,\r\n            \"Abroad\": true,\r\n            \"Weight\": 1.0,\r\n            \"Title\": \"Senior Manager\",\r\n            \"JobHeadline\": \"Senior Manager, Sales Excellence\",\r\n            \"Presentation\": \"Senior Manager, Sales Excellence\\n\\nLocation:\u00A0 Humlebæk, DK\\nJob Family:\u00A0 Marketing\\nCountry/Region:\u00A0 Denmark\\n \\nSenior Manager, Sales Excellence\u00A0\\nSales Force Excellence (Senior) Manager for our Consumer s\",\r\n            \"HiringOrgName\": \"Coloplast Danmark A/S\",\r\n            \"WorkPlaceAddress\": \"Holtedam 1\",\r\n            \"WorkPlacePostalCode\": \"3050\",\r\n            \"WorkPlaceCity\": \"Humlebæk\",\r\n            \"WorkPlaceOtherAddress\": false,\r\n            \"WorkPlaceAbroad\": false,\r\n            \"WorkPlaceNotStatic\": false,\r\n            \"UseWorkPlaceAddressForJoblog\": true,\r\n            \"PostingCreated\": \"2021-07-02T00:00:00\",\r\n            \"LastDateApplication\": \"1900-01-01T00:00:00\",\r\n            \"FormattedLastDateApplication\": \"Ikke oplyst\",\r\n            \"AssignmentStartDate\": \"2021-08-01T15:48:43.9414636+02:00\",\r\n            \"IsHotjob\": false,\r\n            \"IsExternal\": true,\r\n            \"Url\": \"https://careers.coloplast.com/job/Humlebæk-Senior-Manager,-Sales-Excellence/689406301/\",\r\n            \"Region\": \"Hovedstaden og Bornholm\",\r\n            \"Municipality\": \"Fredensborg\",\r\n            \"Country\": \"\",\r\n            \"PostalCode\": \"3050\",\r\n            \"PostalCodeName\": null,\r\n            \"JobAnnouncementType\": \"Almindelige vilkår\",\r\n            \"EmploymentType\": \"Fastansættelse\",\r\n            \"WorkHours\": \"Fuldtid\",\r\n            \"OccupationArea\": \"\",\r\n            \"OccupationGroup\": \"\",\r\n            \"Occupation\": \"\",\r\n            \"Location\": {\r\n                \"Latitude\": 55.9651,\r\n                \"Longitude\": 12.4947\r\n            },\r\n            \"JoblogWorkTime\": {\r\n                \"WorkHour\": null,\r\n                \"DailyWorkTime\": null\r\n            },\r\n            \"WorkplaceID\": 0,\r\n            \"OrganisationId\": \"\",\r\n            \"HiringOrgCVR\": 0,\r\n            \"UserLoggedIn\": false,\r\n            \"AnonymousEmployer\": false,\r\n            \"ShareUrl\": \"https://careers.coloplast.com/job/Humlebæk-Senior-Manager,-Sales-Excellence/689406301/\",\r\n            \"DetailsUrl\": null,\r\n            \"JobLogUrl\": \"https://careers.coloplast.com/job/Humlebæk-Senior-Manager,-Sales-Excellence/689406301/\",\r\n            \"HasLocationValues\": true,\r\n            \"ID\": \"E8251030\",\r\n            \"Latitude\": 55.9651,\r\n            \"Longitude\": 12.4947\r\n        }",
                    title: "Senior Manager",
                    presentation: "Senior Manager, Sales Excellence\n\nLocation:\u00A0 Humlebæk, DK\nJob Family:\u00A0 Marketing\nCountry/Region:\u00A0 Denmark\n \nSenior Manager, Sales Excellence\u00A0\nSales Force Excellence (Senior) Manager for our Consumer s",
                    hiringOrgName: "Coloplast Danmark A/S",
                    workPlaceAddress: "Holtedam 1",
                    workPlacePostalCode: 3050,
                    workPlaceCity: "Humlebæk",
                    postingCreated: new DateTime(2021, 07, 02),
                    lastDateApplication: new DateTime(1900, 01, 01),
                    url: "https://careers.coloplast.com/job/Humlebæk-Senior-Manager,-Sales-Excellence/689406301/",
                    region: "Hovedstaden og Bornholm",
                    municipality: "Fredensborg",
                    country: "",
                    employmentType: "Fastansættelse",
                    workHours: "Fuldtid",
                    occupation: "",
                    workplaceId: 0,
                    organisationId: null,
                    hiringOrgCVR: 0,
                    id: 8251030,
                    workPlaceCityWithoutZone: "Humlebæk",
                    jobPostingNumber: 19,
                    jobPostingId: "8251030seniormanager"
                );
        internal static JobPostingExtended Shared_JobPage02_JobPostingExtended19
            = new JobPostingExtended(
                    jobPosting: Shared_JobPage02_JobPosting19,
                    response: Shared_FakeResponse,                      // Ignored
                    hiringOrgDescription: null,
                    publicationStartDate: null,
                    publicationEndDate: null,
                    purpose: Shared_FakePurpose,                        // Ignored
                    numberToFill: null,
                    contactEmail: null,
                    contactPersonName: null,
                    employmentDate: null,
                    applicationDeadlineDate: null,
                    bulletPoints: new HashSet<string>()
                    {
                        "Set a clear direction for sales capabilities within the Consumer channel, ensure that we have the right toolbox in place for in- and outbound calls and that these align with HQ requirements",
                        "Ensure that we locally have the tools necessary to give our customers get the highest level of quality in terms of service and sales",
                        "Work with stakeholders to identify training needs and opportunities and determine what areas should be included in training modules",
                        "Motivate and develop consumer care managers",
                        "Have a couple of years of experience in a commercial role",
                        "Know your way around change management",
                        "Probably have training experience preferably from a sales or service organisation",
                        "Have impactful PowerPoint presentation skills and the ability to conduct meetings and workshops",
                        "Are fluent in English – any other languages are a plus"
                    },
                    bulletPointScenario: "coloplast"
                );

        internal static JobPosting Shared_JobPage02_JobPosting20
            = new JobPosting(
                    runId: Shared_FakeRunId,
                    pageNumber: 2,
                    response: "{\r\n            \"AutomatchType\": 0,\r\n            \"Abroad\": true,\r\n            \"Weight\": 1.0,\r\n            \"Title\": \"Business Intelligence Analyst\",\r\n            \"JobHeadline\": \"International Business Intelligence Consultant\",\r\n            \"Presentation\": \"GN Careers\\nInternational Business Intelligence Consultant\\nBallerup\\nApply\\n\\nJabra\u00A0\u00A0Any EMEA location\\nAbout the job\\nWould you like to grow your career in a truly global role? Are you passionate about bus\",\r\n            \"HiringOrgName\": \"GN Store Nord A/S\",\r\n            \"WorkPlaceAddress\": \"Lautrupbjerg 7\",\r\n            \"WorkPlacePostalCode\": \"2750\",\r\n            \"WorkPlaceCity\": \"Ballerup\",\r\n            \"WorkPlaceOtherAddress\": false,\r\n            \"WorkPlaceAbroad\": false,\r\n            \"WorkPlaceNotStatic\": false,\r\n            \"UseWorkPlaceAddressForJoblog\": true,\r\n            \"PostingCreated\": \"2021-07-02T00:00:00\",\r\n            \"LastDateApplication\": \"2021-07-20T00:00:00\",\r\n            \"FormattedLastDateApplication\": \"20. juli 2021\",\r\n            \"AssignmentStartDate\": \"2021-07-21T00:00:00\",\r\n            \"IsHotjob\": false,\r\n            \"IsExternal\": true,\r\n            \"Url\": \"https://gn.wd3.myworkdayjobs.com/en-US/GN-Careers/job/Ballerup/International-Business-Intelligence-Consultant_R9793-1\",\r\n            \"Region\": \"Hovedstaden og Bornholm\",\r\n            \"Municipality\": \"Ballerup\",\r\n            \"Country\": \"\",\r\n            \"PostalCode\": \"2750\",\r\n            \"PostalCodeName\": null,\r\n            \"JobAnnouncementType\": \"Almindelige vilkår\",\r\n            \"EmploymentType\": \"Fastansættelse\",\r\n            \"WorkHours\": \"Fuldtid\",\r\n            \"OccupationArea\": \"\",\r\n            \"OccupationGroup\": \"\",\r\n            \"Occupation\": \"\",\r\n            \"Location\": {\r\n                \"Latitude\": 55.7387,\r\n                \"Longitude\": 12.3871\r\n            },\r\n            \"JoblogWorkTime\": {\r\n                \"WorkHour\": null,\r\n                \"DailyWorkTime\": null\r\n            },\r\n            \"WorkplaceID\": 0,\r\n            \"OrganisationId\": \"\",\r\n            \"HiringOrgCVR\": 0,\r\n            \"UserLoggedIn\": false,\r\n            \"AnonymousEmployer\": false,\r\n            \"ShareUrl\": \"https://gn.wd3.myworkdayjobs.com/en-US/GN-Careers/job/Ballerup/International-Business-Intelligence-Consultant_R9793-1\",\r\n            \"DetailsUrl\": null,\r\n            \"JobLogUrl\": \"https://gn.wd3.myworkdayjobs.com/en-US/GN-Careers/job/Ballerup/International-Business-Intelligence-Consultant_R9793-1\",\r\n            \"HasLocationValues\": true,\r\n            \"ID\": \"E8251029\",\r\n            \"Latitude\": 55.7387,\r\n            \"Longitude\": 12.3871\r\n        }",
                    title: "Business Intelligence Analyst",
                    presentation: "GN Careers\nInternational Business Intelligence Consultant\nBallerup\nApply\n\nJabra\u00A0\u00A0Any EMEA location\nAbout the job\nWould you like to grow your career in a truly global role? Are you passionate about bus",
                    hiringOrgName: "GN Store Nord A/S",
                    workPlaceAddress: "Lautrupbjerg 7",
                    workPlacePostalCode: 2750,
                    workPlaceCity: "Ballerup",
                    postingCreated: new DateTime(2021, 07, 02),
                    lastDateApplication: new DateTime(2021, 07, 20),
                    url: "https://gn.wd3.myworkdayjobs.com/en-US/GN-Careers/job/Ballerup/International-Business-Intelligence-Consultant_R9793-1",
                    region: "Hovedstaden og Bornholm",
                    municipality: "Ballerup",
                    country: "",
                    employmentType: "Fastansættelse",
                    workHours: "Fuldtid",
                    occupation: "",
                    workplaceId: 0,
                    organisationId: null,
                    hiringOrgCVR: 0,
                    id: 8251029,
                    workPlaceCityWithoutZone: "Ballerup",
                    jobPostingNumber: 20,
                    jobPostingId: "8251029businessintelligenceanalyst"
                );
        internal static JobPostingExtended Shared_JobPage02_JobPostingExtended20
            = new JobPostingExtended(
                    jobPosting: Shared_JobPage02_JobPosting20,
                    response: Shared_FakeResponse,                      // Ignored
                    hiringOrgDescription: null,
                    publicationStartDate: null,
                    publicationEndDate: null,
                    purpose: Shared_FakePurpose,                        // Ignored
                    numberToFill: null,
                    contactEmail: null,
                    contactPersonName: null,
                    employmentDate: null,
                    applicationDeadlineDate: null,
                    bulletPoints: null,
                    bulletPointScenario: null
                );

        internal static List<JobPosting> Shared_JobPage02_JobPostings
            = new List<JobPosting>()
            {
                Shared_JobPage02_JobPosting01,
                Shared_JobPage02_JobPosting02,
                Shared_JobPage02_JobPosting03,
                Shared_JobPage02_JobPosting04,
                Shared_JobPage02_JobPosting05,
                Shared_JobPage02_JobPosting06,
                Shared_JobPage02_JobPosting07,
                Shared_JobPage02_JobPosting08,
                Shared_JobPage02_JobPosting09,
                Shared_JobPage02_JobPosting10,
                Shared_JobPage02_JobPosting11,
                Shared_JobPage02_JobPosting12,
                Shared_JobPage02_JobPosting13,
                Shared_JobPage02_JobPosting14,
                Shared_JobPage02_JobPosting15,
                Shared_JobPage02_JobPosting16,
                Shared_JobPage02_JobPosting17,
                Shared_JobPage02_JobPosting18,
                Shared_JobPage02_JobPosting19,
                Shared_JobPage02_JobPosting20
            };

        internal static JobPage Shared_JobPage02_Object
            = new JobPage(Shared_FakeRunId, 2, Shared_JobPage02_Content);

        internal static ushort Shared_JobPage02_TotalResultCount = 2177;

        #endregion

        #region Shared_JobPage01_Entities

        internal static JobPostingEntity Shared_JobPage01_JobPostingEntity01
            = new JobPostingEntity(Shared_JobPage01_JobPosting01);
        internal static List<JobPostingEntity> Shared_JobPage01_JobPostingEntities = new List<JobPostingEntity>()
        {

            new JobPostingEntity(Shared_JobPage01_JobPosting01),
            new JobPostingEntity(Shared_JobPage01_JobPosting02),
            new JobPostingEntity(Shared_JobPage01_JobPosting03),
            new JobPostingEntity(Shared_JobPage01_JobPosting04),
            new JobPostingEntity(Shared_JobPage01_JobPosting05),
            new JobPostingEntity(Shared_JobPage01_JobPosting06),
            new JobPostingEntity(Shared_JobPage01_JobPosting07),
            new JobPostingEntity(Shared_JobPage01_JobPosting08),
            new JobPostingEntity(Shared_JobPage01_JobPosting09),
            new JobPostingEntity(Shared_JobPage01_JobPosting10),
            new JobPostingEntity(Shared_JobPage01_JobPosting11),
            new JobPostingEntity(Shared_JobPage01_JobPosting12),
            new JobPostingEntity(Shared_JobPage01_JobPosting13),
            new JobPostingEntity(Shared_JobPage01_JobPosting14),
            new JobPostingEntity(Shared_JobPage01_JobPosting15),
            new JobPostingEntity(Shared_JobPage01_JobPosting16),
            new JobPostingEntity(Shared_JobPage01_JobPosting17),
            new JobPostingEntity(Shared_JobPage01_JobPosting18),
            new JobPostingEntity(Shared_JobPage01_JobPosting19),
            new JobPostingEntity(Shared_JobPage01_JobPosting20)

        };

        internal static JobPostingExtendedEntity Shared_JobPage01_JobPostingExtendedEntity01
            = new JobPostingExtendedEntity(Shared_JobPage01_JobPostingExtended01);
        internal static List<JobPostingExtendedEntity> Shared_JobPage01_JobPostingExtendedEntities
            = new List<JobPostingExtendedEntity>()
            {
                new JobPostingExtendedEntity(Shared_JobPage01_JobPostingExtended01),
                new JobPostingExtendedEntity(Shared_JobPage01_JobPostingExtended02),
                new JobPostingExtendedEntity(Shared_JobPage01_JobPostingExtended03),
                new JobPostingExtendedEntity(Shared_JobPage01_JobPostingExtended04),
                new JobPostingExtendedEntity(Shared_JobPage01_JobPostingExtended05),
                new JobPostingExtendedEntity(Shared_JobPage01_JobPostingExtended06),
                new JobPostingExtendedEntity(Shared_JobPage01_JobPostingExtended07),
                new JobPostingExtendedEntity(Shared_JobPage01_JobPostingExtended08),
                new JobPostingExtendedEntity(Shared_JobPage01_JobPostingExtended09),
                new JobPostingExtendedEntity(Shared_JobPage01_JobPostingExtended10),
                new JobPostingExtendedEntity(Shared_JobPage01_JobPostingExtended11),
                new JobPostingExtendedEntity(Shared_JobPage01_JobPostingExtended12),
                new JobPostingExtendedEntity(Shared_JobPage01_JobPostingExtended13),
                new JobPostingExtendedEntity(Shared_JobPage01_JobPostingExtended14),
                new JobPostingExtendedEntity(Shared_JobPage01_JobPostingExtended15),
                new JobPostingExtendedEntity(Shared_JobPage01_JobPostingExtended16),
                new JobPostingExtendedEntity(Shared_JobPage01_JobPostingExtended17),
                new JobPostingExtendedEntity(Shared_JobPage01_JobPostingExtended18),
                new JobPostingExtendedEntity(Shared_JobPage01_JobPostingExtended19),
                new JobPostingExtendedEntity(Shared_JobPage01_JobPostingExtended20)
            };

        internal static BulletPointEntity Shared_JobPage01_JobPostingExtended01BulletPointEntity01
            = new BulletPointEntity(
                    Shared_JobPage01_JobPostingExtended01.JobPosting.JobPostingId,
                    Shared_JobPage01_JobPostingExtended01.BulletPoints.ToList()[0]);
        internal static List<BulletPointEntity> Shared_JobPage01_JobPostingExtended01BulletPointEntities
            = Shared_JobPage01_JobPostingExtended01
                .BulletPoints
                .Select(bulletPoint => new BulletPointEntity(Shared_JobPage01_JobPostingExtended01.JobPosting.JobPostingId, bulletPoint))
                .ToList();

        #endregion

        #region Shared_JobPage02_Entities

        #endregion

        #region DatabaseContextTests

        internal static string DatabaseContext_DatabasePath = @"c:\";
        internal static string DatabaseContext_DatabaseName01 = "widjobs.db";
        internal static string DatabaseContext_DatabaseName02 = "widjobs";
        internal static string DatabaseContext_ConnectionString
            = DatabaseContext.ConnectionStringTemplate.Invoke(@"c:\widjobs.db");

        #endregion

        #region DbSetExtensionMethodsTests

        internal static DatabaseContext DbSetExtensionMethods_InMemoryDatabaseContext
            = CreateInMemoryContext();
        internal static List<JobPostingEntity> DbSetExtensionMethods_NotExistingPageItemEntities;

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

        #region RunIdManagerTests

        internal static DateTime RunIdManager_Now = new DateTime(2020, 01, 01, 19, 25, 40, 980);
        internal static DateTime RunIdManager_StartDate = new DateTime(2019, 09, 01, 00, 00, 00, 000);
        internal static DateTime RunIdManager_EndDate = new DateTime(2019, 12, 31, 23, 59, 59, 999);
        internal static DateTime RunIdManager_Threshold = new DateTime(2020, 03, 31, 00, 00, 00, 000);
        internal static ushort RunIdManager_InitialPageNumber = 1;
        internal static ushort RunIdManager_FinalPageNumber = 3;
        internal static string RunIdManager_RunId_Now
            = string.Format(
                RunIdManager.DefaultTemplateId,
                RunIdManager_Now.ToString(RunIdManager.DefaultFormatDateTime)
            );
        internal static string RunIdManager_RunId_StartDateEndDate
            = string.Format(
                RunIdManager.DefaultTemplateFromTo,
                RunIdManager_RunId_Now,
                RunIdManager_StartDate.ToString(RunIdManager.DefaultFormatDate),
                RunIdManager_EndDate.ToString(RunIdManager.DefaultFormatDate)
            );
        internal static string RunIdManager_RunId_Threshold
            = string.Format(
                RunIdManager.DefaultTemplateThreshold,
                RunIdManager_RunId_Now,
                RunIdManager_Threshold.ToString(RunIdManager.DefaultFormatDate)
            );
        internal static string RunIdManager_RunId_FromTo
            = string.Format(
                RunIdManager.DefaultTemplateFromTo,
                RunIdManager_RunId_Now,
                RunIdManager_InitialPageNumber,
                RunIdManager_FinalPageNumber
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

        #endregion

        #region WIDFileNameFactory

        internal static string WIDFileNameFactory_FakeFilePath = @"C:\";
        internal static string WIDFileNameFactory_FakeToken = "fake";
        internal static DateTime WIDFileNameFactory_FakeNow = new DateTime(2021, 05, 01);
        internal static string WIDFileNameFactory_FakeNowString
            = WIDFileNameFactory_FakeNow.ToString(WIDFileNameFactory.DefaultFormatNow);

        internal static string WIDFileNameFactory_FakeDatabaseFileName = "fakedb.db";

        internal static string WIDFileNameFactory_DatabaseNameIfFilePath
            = string.Concat(
                        WIDFileNameFactory_FakeFilePath,
                        WIDFileNameFactory.DefaultDatabaseToken,
                        ".",
                        WIDFileNameFactory.DefaultDatabaseExtension
                        );
        internal static string WIDFileNameFactory_DatabaseNameIfFilePathFileName
            = string.Concat(
                        WIDFileNameFactory_FakeFilePath,
                        WIDFileNameFactory_FakeDatabaseFileName
                        );
        internal static string WIDFileNameFactory_DatabaseNameIfFilePathTokenNow
            = string.Concat(
                        WIDFileNameFactory_FakeFilePath,
                        WIDFileNameFactory_FakeToken,
                        "_",
                        WIDFileNameFactory_FakeNowString,
                        ".",
                        WIDFileNameFactory.DefaultDatabaseExtension
                        );
        internal static string WIDFileNameFactory_DatabaseNameIfFilePathNow
            = string.Concat(
                        WIDFileNameFactory_FakeFilePath,
                        WIDFileNameFactory.DefaultDatabaseToken,
                        "_",
                        WIDFileNameFactory_FakeNowString,
                        ".",
                        WIDFileNameFactory.DefaultDatabaseExtension
                        );

        internal static string WIDFileNameFactory_MetricsJsonIfTrue
            = string.Concat(
                        WIDFileNameFactory_FakeFilePath,
                        WIDFileNameFactory.DefaultMetricsPctJsonToken,
                        "_",
                        WIDFileNameFactory_FakeNowString,
                        ".",
                        WIDFileNameFactory.DefaultJsonExtension
                        );
        internal static string WIDFileNameFactory_MetricsJsonIfFalse
            = string.Concat(
                        WIDFileNameFactory_FakeFilePath,
                        WIDFileNameFactory.DefaultMetricsJsonToken,
                        "_",
                        WIDFileNameFactory_FakeNowString,
                        ".",
                        WIDFileNameFactory.DefaultJsonExtension
                        );

        internal static string WIDFileNameFactory_ExplorationJsonIfFilePathNow
            = string.Concat(
                        WIDFileNameFactory_FakeFilePath,
                        WIDFileNameFactory.DefaultExplorationJsonToken,
                        "_",
                        WIDFileNameFactory_FakeNowString,
                        ".",
                        WIDFileNameFactory.DefaultJsonExtension
                        );
        internal static string WIDFileNameFactory_ExplorationJsonIfFilePathTokenNow
            = string.Concat(
                        WIDFileNameFactory_FakeFilePath,
                        WIDFileNameFactory_FakeToken,
                        "_",
                        WIDFileNameFactory_FakeNowString,
                        ".",
                        WIDFileNameFactory.DefaultJsonExtension
                        );

        #endregion

        /* -------------------------------------------- */

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
        internal static DatabaseContext CreateInMemoryContext()
        {

            string databaseName = Guid.NewGuid().ToString();
            DbContextOptions<DatabaseContext> options
                = new DbContextOptionsBuilder<DatabaseContext>().UseInMemoryDatabase(databaseName).Options;

            return new DatabaseContext(options);

        }
        internal static Repository CreateInMemoryRepository()
            => new Repository(CreateInMemoryContext(), false);
        internal static TReturn CallPrivateMethod<TClass, TReturn>
            (TClass obj, string methodName, object[] args)
        {

            Type type = typeof(TClass);

            return (TReturn)type.GetTypeInfo().GetDeclaredMethod(methodName).Invoke(obj, args);

        }

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
        internal static bool AreEqual(HashSet<string> hashset1, HashSet<string> hashset2)
        {

            if (hashset1 == null && hashset2 == null)
                return true;

            if (hashset1 == null || hashset2 == null)
                return false;

            return AreEqual(new List<string>(hashset1), new List<string>(hashset2));

        }
        internal static bool AreEqual<TKey, TValue>(Dictionary<TKey, TValue> dict1, Dictionary<TKey, TValue> dict2)
        {

            IEqualityComparer<TValue> valueComparer = EqualityComparer<TValue>.Default;

            return dict1.Count == dict2.Count
                    && dict1.Keys.All(key => dict2.ContainsKey(key)
                    && valueComparer.Equals(dict1[key], dict2[key]));

        }

        internal static bool AreEqual(JobPage jobPage1, JobPage jobPage2)
        {

            return (jobPage1.PageNumber == jobPage2.PageNumber)
                    && string.Equals(jobPage1.Response, jobPage2.Response, StringComparison.InvariantCulture)
                    && string.Equals(jobPage1.RunId, jobPage2.RunId, StringComparison.InvariantCulture);

        }
        internal static bool AreEqual(JobPosting jobPosting1, JobPosting jobPosting2)
        {

            return string.Equals(jobPosting1.Country, jobPosting2.Country, StringComparison.InvariantCulture)
                        && string.Equals(jobPosting1.EmploymentType, jobPosting2.EmploymentType, StringComparison.InvariantCulture)
                        && (jobPosting1.HiringOrgCVR == jobPosting2.HiringOrgCVR)
                        && string.Equals(jobPosting1.HiringOrgName, jobPosting2.HiringOrgName, StringComparison.InvariantCulture)
                        && (jobPosting1.Id == jobPosting2.Id)
                        && string.Equals(jobPosting1.JobPostingId, jobPosting2.JobPostingId, StringComparison.InvariantCulture)
                        && (jobPosting1.JobPostingNumber == jobPosting2.JobPostingNumber)
                        && (jobPosting1.LastDateApplication == jobPosting2.LastDateApplication)
                        && string.Equals(jobPosting1.Municipality, jobPosting2.Municipality, StringComparison.InvariantCulture)
                        && string.Equals(jobPosting1.Occupation, jobPosting2.Occupation, StringComparison.InvariantCulture)
                        && (jobPosting1.OrganisationId == jobPosting2.OrganisationId)
                        && (jobPosting1.PageNumber == jobPosting2.PageNumber)
                        && (jobPosting1.PostingCreated == jobPosting2.PostingCreated)
                        && string.Equals(jobPosting1.Presentation, jobPosting2.Presentation, StringComparison.InvariantCulture)
                        && string.Equals(jobPosting1.Region, jobPosting2.Region, StringComparison.InvariantCulture)
                        && string.Equals(jobPosting1.Response, jobPosting2.Response, StringComparison.InvariantCulture)
                        && string.Equals(jobPosting1.RunId, jobPosting2.RunId, StringComparison.InvariantCulture)
                        && string.Equals(jobPosting1.Title, jobPosting2.Title, StringComparison.InvariantCulture)
                        && string.Equals(jobPosting1.Url, jobPosting2.Url, StringComparison.InvariantCulture)
                        && string.Equals(jobPosting1.WorkHours, jobPosting2.WorkHours, StringComparison.InvariantCulture)
                        && string.Equals(jobPosting1.WorkPlaceAddress, jobPosting2.WorkPlaceAddress, StringComparison.InvariantCulture)
                        && string.Equals(jobPosting1.WorkPlaceCity, jobPosting2.WorkPlaceCity, StringComparison.InvariantCulture)
                        && string.Equals(jobPosting1.WorkPlaceCityWithoutZone, jobPosting2.WorkPlaceCityWithoutZone, StringComparison.InvariantCulture)
                        && (jobPosting1.WorkplaceId == jobPosting2.WorkplaceId)
                        && (jobPosting1.WorkPlacePostalCode == jobPosting2.WorkPlacePostalCode);

        }
        internal static bool AreEqual(List<JobPosting> list1, List<JobPosting> list2)
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
        internal static bool AreEqual(JobPostingExtended jobPostingExtended1, JobPostingExtended jobPostingExtended2, bool ignorePurposeResponse = true)
        {

            if (ignorePurposeResponse)
                return (jobPostingExtended1.ApplicationDeadlineDate == jobPostingExtended2.ApplicationDeadlineDate)
                            && AreEqual(jobPostingExtended1.BulletPoints, jobPostingExtended2.BulletPoints)
                            && string.Equals(jobPostingExtended1.BulletPointScenario, jobPostingExtended2.BulletPointScenario, StringComparison.InvariantCulture)
                            && string.Equals(jobPostingExtended1.ContactEmail, jobPostingExtended2.ContactEmail, StringComparison.InvariantCulture)
                            && string.Equals(jobPostingExtended1.ContactPersonName, jobPostingExtended2.ContactPersonName, StringComparison.InvariantCulture)
                            && (jobPostingExtended1.EmploymentDate == jobPostingExtended2.EmploymentDate)
                            && string.Equals(jobPostingExtended1.HiringOrgDescription, jobPostingExtended2.HiringOrgDescription, StringComparison.InvariantCulture)
                            && AreEqual(jobPostingExtended1.JobPosting, jobPostingExtended2.JobPosting)
                            && (jobPostingExtended1.NumberToFill == jobPostingExtended2.NumberToFill)
                            && (jobPostingExtended1.PublicationStartDate == jobPostingExtended2.PublicationStartDate)
                            && (jobPostingExtended1.PublicationEndDate == jobPostingExtended2.PublicationEndDate);

            return (jobPostingExtended1.ApplicationDeadlineDate == jobPostingExtended2.ApplicationDeadlineDate)
                        && AreEqual(jobPostingExtended1.BulletPoints, jobPostingExtended2.BulletPoints)
                        && string.Equals(jobPostingExtended1.BulletPointScenario, jobPostingExtended2.BulletPointScenario, StringComparison.InvariantCulture)
                        && string.Equals(jobPostingExtended1.ContactEmail, jobPostingExtended2.ContactEmail, StringComparison.InvariantCulture)
                        && string.Equals(jobPostingExtended1.ContactPersonName, jobPostingExtended2.ContactPersonName, StringComparison.InvariantCulture)
                        && (jobPostingExtended1.EmploymentDate == jobPostingExtended2.EmploymentDate)
                        && string.Equals(jobPostingExtended1.HiringOrgDescription, jobPostingExtended2.HiringOrgDescription, StringComparison.InvariantCulture)
                        && AreEqual(jobPostingExtended1.JobPosting, jobPostingExtended2.JobPosting)
                        && (jobPostingExtended1.NumberToFill == jobPostingExtended2.NumberToFill)
                        && (jobPostingExtended1.PublicationStartDate == jobPostingExtended2.PublicationStartDate)
                        && (jobPostingExtended1.PublicationEndDate == jobPostingExtended2.PublicationEndDate)
                        && string.Equals(jobPostingExtended1.Purpose, jobPostingExtended2.Purpose, StringComparison.InvariantCulture)
                        && string.Equals(jobPostingExtended1.Response, jobPostingExtended2.Response, StringComparison.InvariantCulture);

        }
        internal static bool AreEqual(List<JobPostingExtended> list1, List<JobPostingExtended> list2, bool ignorePurposeResponse = true)
        {

            if (list1 == null && list2 == null)
                return true;

            if (list1 == null || list2 == null)
                return false;

            if (list1.Count != list2.Count)
                return false;

            for (int i = 0; i < list1.Count; i++)
                if (AreEqual(list1[i], list2[i], ignorePurposeResponse) == false)
                    return false;

            return true;

        }

        internal static bool AreEqual(JobPosting jobPosting, JobPostingEntity jobPostingEntity)
        {

            return string.Equals(jobPosting.Country, jobPostingEntity.Country, StringComparison.InvariantCulture)
                        && string.Equals(jobPosting.EmploymentType, jobPostingEntity.EmploymentType, StringComparison.InvariantCulture)
                        && (jobPosting.HiringOrgCVR == jobPostingEntity.HiringOrgCVR)
                        && string.Equals(jobPosting.HiringOrgName, jobPostingEntity.HiringOrgName, StringComparison.InvariantCulture)
                        && (jobPosting.Id == jobPostingEntity.Id)
                        && string.Equals(jobPosting.JobPostingId, jobPostingEntity.JobPostingId, StringComparison.InvariantCulture)
                        && (jobPosting.JobPostingNumber == jobPostingEntity.JobPostingNumber)
                        && (jobPosting.LastDateApplication == jobPostingEntity.LastDateApplication)
                        && string.Equals(jobPosting.Municipality, jobPostingEntity.Municipality, StringComparison.InvariantCulture)
                        && string.Equals(jobPosting.Occupation, jobPostingEntity.Occupation, StringComparison.InvariantCulture)
                        && (jobPosting.OrganisationId == jobPostingEntity.OrganisationId)
                        && (jobPosting.PageNumber == jobPostingEntity.PageNumber)
                        && (jobPosting.PostingCreated == jobPostingEntity.PostingCreated)
                        && string.Equals(jobPosting.Presentation, jobPostingEntity.Presentation, StringComparison.InvariantCulture)
                        && string.Equals(jobPosting.Region, jobPostingEntity.Region, StringComparison.InvariantCulture)
                        && string.Equals(jobPosting.Response, jobPostingEntity.Response, StringComparison.InvariantCulture)
                        && string.Equals(jobPosting.RunId, jobPostingEntity.RunId, StringComparison.InvariantCulture)
                        && string.Equals(jobPosting.Title, jobPostingEntity.Title, StringComparison.InvariantCulture)
                        && string.Equals(jobPosting.Url, jobPostingEntity.Url, StringComparison.InvariantCulture)
                        && string.Equals(jobPosting.WorkHours, jobPostingEntity.WorkHours, StringComparison.InvariantCulture)
                        && string.Equals(jobPosting.WorkPlaceAddress, jobPostingEntity.WorkPlaceAddress, StringComparison.InvariantCulture)
                        && string.Equals(jobPosting.WorkPlaceCity, jobPostingEntity.WorkPlaceCity, StringComparison.InvariantCulture)
                        && string.Equals(jobPosting.WorkPlaceCityWithoutZone, jobPostingEntity.WorkPlaceCityWithoutZone, StringComparison.InvariantCulture)
                        && (jobPosting.WorkplaceId == jobPostingEntity.WorkplaceId)
                        && (jobPosting.WorkPlacePostalCode == jobPostingEntity.WorkPlacePostalCode)
                        && (jobPostingEntity.RowId == default(uint))
                        && (jobPostingEntity.RowCreatedOn == default(DateTime))
                        && (jobPostingEntity.RowModifiedOn == default(DateTime));

        }
        internal static bool AreEqual(JobPostingExtended jobPostingExtended, JobPostingExtendedEntity jobPostingExtendedEntity, bool ignorePurposeResponse = true)
        {

            if (ignorePurposeResponse)
                return (jobPostingExtended.ApplicationDeadlineDate == jobPostingExtendedEntity.ApplicationDeadlineDate)
                            && string.Equals(jobPostingExtended.BulletPointScenario, jobPostingExtendedEntity.BulletPointScenario, StringComparison.InvariantCulture)
                            && string.Equals(jobPostingExtended.ContactEmail, jobPostingExtendedEntity.ContactEmail, StringComparison.InvariantCulture)
                            && string.Equals(jobPostingExtended.ContactPersonName, jobPostingExtendedEntity.ContactPersonName, StringComparison.InvariantCulture)
                            && (jobPostingExtended.EmploymentDate == jobPostingExtendedEntity.EmploymentDate)
                            && string.Equals(jobPostingExtended.HiringOrgDescription, jobPostingExtendedEntity.HiringOrgDescription, StringComparison.InvariantCulture)
                            && string.Equals(jobPostingExtended.JobPosting.JobPostingId, jobPostingExtendedEntity.JobPostingId, StringComparison.InvariantCulture)
                            && (jobPostingExtended.NumberToFill == jobPostingExtendedEntity.NumberToFill)
                            && (jobPostingExtended.PublicationStartDate == jobPostingExtendedEntity.PublicationStartDate)
                            && (jobPostingExtended.PublicationEndDate == jobPostingExtendedEntity.PublicationEndDate)
                            && (jobPostingExtendedEntity.RowId == default(uint))
                            && (jobPostingExtendedEntity.RowCreatedOn == default(DateTime))
                            && (jobPostingExtendedEntity.RowModifiedOn == default(DateTime));

            return (jobPostingExtended.ApplicationDeadlineDate == jobPostingExtendedEntity.ApplicationDeadlineDate)
                        && string.Equals(jobPostingExtended.BulletPointScenario, jobPostingExtendedEntity.BulletPointScenario, StringComparison.InvariantCulture)
                        && string.Equals(jobPostingExtended.ContactEmail, jobPostingExtendedEntity.ContactEmail, StringComparison.InvariantCulture)
                        && string.Equals(jobPostingExtended.ContactPersonName, jobPostingExtendedEntity.ContactPersonName, StringComparison.InvariantCulture)
                        && (jobPostingExtended.EmploymentDate == jobPostingExtendedEntity.EmploymentDate)
                        && string.Equals(jobPostingExtended.HiringOrgDescription, jobPostingExtendedEntity.HiringOrgDescription, StringComparison.InvariantCulture)
                        && string.Equals(jobPostingExtended.JobPosting.JobPostingId, jobPostingExtendedEntity.JobPostingId, StringComparison.InvariantCulture)
                        && (jobPostingExtended.NumberToFill == jobPostingExtendedEntity.NumberToFill)
                        && (jobPostingExtended.PublicationStartDate == jobPostingExtendedEntity.PublicationStartDate)
                        && (jobPostingExtended.PublicationEndDate == jobPostingExtendedEntity.PublicationEndDate)
                        && string.Equals(jobPostingExtended.Purpose, jobPostingExtendedEntity.Purpose, StringComparison.InvariantCulture)
                        && string.Equals(jobPostingExtended.Response, jobPostingExtendedEntity.Response, StringComparison.InvariantCulture)
                        && (jobPostingExtendedEntity.RowId == default(uint))
                        && (jobPostingExtendedEntity.RowCreatedOn == default(DateTime))
                        && (jobPostingExtendedEntity.RowModifiedOn == default(DateTime));

        }
        internal static bool AreEqual(BulletPointEntity bulletPointEntity1, BulletPointEntity bulletPointEntity2)
        {

            return (bulletPointEntity1.RowId == bulletPointEntity2.RowId)
                    && string.Equals(bulletPointEntity1.JobPostingId, bulletPointEntity2.JobPostingId, StringComparison.InvariantCulture)
                    && string.Equals(bulletPointEntity1.BulletPoint, bulletPointEntity2.BulletPoint, StringComparison.InvariantCulture)
                    && (bulletPointEntity1.RowCreatedOn == bulletPointEntity2.RowCreatedOn)
                    && (bulletPointEntity1.RowModifiedOn == bulletPointEntity2.RowModifiedOn);

        }
        internal static bool AreEqual(BulletPoint bulletPoint1, BulletPoint bulletPoint2)
        {

            return string.Equals(bulletPoint1.Label, bulletPoint2.Label, StringComparison.InvariantCulture)
                    && string.Equals(bulletPoint1.Text, bulletPoint2.Text, StringComparison.InvariantCulture);

        }
        internal static bool AreEqual(List<BulletPoint> list1, List<BulletPoint> list2)
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

        /* -------------------------------------------- */

        internal static bool AreEqual(WIDExploration exploration1, WIDExploration exploration2)
        {

            return string.Equals(exploration1.RunId, exploration2.RunId, StringComparison.InvariantCulture)
                        && (exploration1.TotalResultCount == exploration2.TotalResultCount)
                        && (exploration1.TotalJobPages == exploration2.TotalJobPages)
                        && (exploration1.Category == exploration2.Category)
                        && (exploration1.Stage == exploration2.Stage)
                        && (exploration1.IsCompleted == exploration2.IsCompleted)
                        && AreEqual(exploration1.JobPages, exploration2.JobPages)
                        && AreEqual(exploration1.JobPostings, exploration2.JobPostings)
                        && AreEqual(exploration1.JobPostingsExtended, exploration2.JobPostingsExtended);

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

        #endregion

    }
}

/*
    Author: numbworks@gmail.com
    Last Update: 05.08.2021
*/