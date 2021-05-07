using System;
using NUnit.Framework;

namespace NW.WIDJobs.UnitTests
{
    [TestFixture]
    public class PageItemScraperTests
    {

        // Fields
        private static TestCaseData[] pageItemScraperTestCases = {

                new TestCaseData(
                    ObjectMother.PageItemScraper_FuncItem,
                    ObjectMother.PageItemScraper_Item1Before,
                    ObjectMother.PageItemScraper_Item1After
                    )
                    .SetName(nameof(Do_ShouldReturnTheExpectedPageItem_WhenInvoked) + " {01}")
                    .SetDescription("Should add the missing properties to the provided partial ResultsPageItem when proper webpage."),

                new TestCaseData(
                    ObjectMother.PageItemScraper_FuncEmptyHTML,
                    ObjectMother.PageItemScraper_Item1Before,
                    ObjectMother.PageItemScraper_Item1After
                    )
                    .SetName(nameof(Do_ShouldReturnTheExpectedPageItem_WhenInvoked) + " {02}")
                    .SetDescription("Should return the provided partial ResultsPageItem as-is when empty webpage."),

                new TestCaseData(
                    ObjectMother.PageItemScraper_FuncItem,
                    null,
                    null
                    )
                    .SetName(nameof(Do_ShouldReturnTheExpectedPageItem_WhenInvoked) + " {03}")
                    .SetDescription("Should return an exception Outcome when ResultsPageItem is null."),

                new TestCaseData(
                    ObjectMother.PageItemScraper_FuncItem,
                    ObjectMother.PageItemScraper_ItemOnlyAbsoluteUrl,
                    null
                    )
                    .SetName(nameof(Do_ShouldReturnTheExpectedPageItem_WhenInvoked) + " {04}")
                    .SetDescription("Should return a failure Outcome when only AbsoluteUrl is assigned."),

                new TestCaseData(
                    ObjectMother.PageItemScraper_FuncItem,
                    ObjectMother.PageItemScraper_ItemOnlyItemId,
                    null
                    )
                    .SetName(nameof(Do_ShouldReturnTheExpectedPageItem_WhenInvoked) + " {05}")
                    .SetDescription("Should return a failure Outcome when only ItemId is assigned."),

                new TestCaseData(
                    ObjectMother.PageItemScraper_FuncItemWithoutUrl,
                    ObjectMother.PageItemScraper_Item1Before,
                    ObjectMother.PageItemScraper_Item1After
                    )
                    .SetName(nameof(Do_ShouldReturnTheExpectedPageItem_WhenInvoked) + " {09}")
                    .SetDescription("Should add the missing properties to the provided partial ResultsPageItem when HowToApply has an empty url."),

                new TestCaseData(
                    ObjectMother.PageItemScraper_FuncItemWithoutHowToApplyURL,
                    ObjectMother.PageItemScraper_Item1Before,
                    ObjectMother.PageItemScraper_Item1After
                    )
                    .SetName(nameof(Do_ShouldReturnTheExpectedPageItem_WhenInvoked) + " {10}")
                    .SetDescription("Should add the missing properties to the provided partial ResultsPageItem when HowToApply lacks of the HREF attribute."),

                new TestCaseData(
                    ObjectMother.PageItemScraper_FuncItemWithoutHowToApply,
                    ObjectMother.PageItemScraper_Item1Before,
                    ObjectMother.PageItemScraper_Item1After
                    )
                    .SetName(nameof(Do_ShouldReturnTheExpectedPageItem_WhenInvoked) + " {11}")
                    .SetDescription("Should add the missing properties to the provided partial ResultsPageItem when HowToApply lacks of the <a> tag."),

            new TestCaseData(
                    ObjectMother.PageItemScraper_FuncItemWithPresentationHTML,
                    ObjectMother.PageItemScraper_Item2Before,
                    ObjectMother.PageItemScraper_Item2After
                    )
                    .SetName(nameof(Do_ShouldReturnTheExpectedPageItem_WhenInvoked) + " {12}")
                    .SetDescription("Should add the missing properties to the provided partial ResultsPageItem when presentation instead of description."),

            new TestCaseData(
                    ObjectMother.PageItemScraper_FuncItemWithPresentationHTMLEdit1,
                    ObjectMother.PageItemScraper_Item2Before,
                    ObjectMother.PageItemScraper_Item2AfterEdit1
                    )
                    .SetName(nameof(Do_ShouldReturnTheExpectedPageItem_WhenInvoked) + " {13}")
                    .SetDescription("Should add the missing properties to the provided partial ResultsPageItem when empty presentation."),

                new TestCaseData(
                    ObjectMother.PageItemScraper_FuncItemWithPresentationHTMLEdit2,
                    ObjectMother.PageItemScraper_Item2Before,
                    ObjectMother.PageItemScraper_Item2AfterEdit2
                    )
                    .SetName(nameof(Do_ShouldReturnTheExpectedPageItem_WhenInvoked) + " {14}")
                    .SetDescription("Should add the missing properties to the provided partial ResultsPageItem when presentation lacks of the HREF attribute."),

            new TestCaseData(
                    ObjectMother.PageItemScraper_FuncItemWithPresentationHTMLEdit3,
                    ObjectMother.PageItemScraper_Item2Before,
                    ObjectMother.PageItemScraper_Item2AfterEdit3
                    )
                    .SetName(nameof(Do_ShouldReturnTheExpectedPageItem_WhenInvoked) + " {15}")
                    .SetDescription("Should add the missing properties to the provided partial ResultsPageItem when presentation has an empty url.")

        };

        // SetUp
        // Tests
        [TestCaseSource(nameof(pageItemScraperTestCases))]
        public void Do_ShouldReturnTheExpectedPageItem_WhenInvoked
            (Func<IGetRequestManager> func, PageItem pageItem, PageItem expected)
        {

            // Arrange
            PageItemScraper pageItemScraper = new PageItemScraper(new XPathManager(), func.Invoke());

            // Act
            PageItem actual = pageItemScraper.Do(pageItem);

            // Assert
            Assert.IsTrue(
                    ObjectMother.AreEqual(expected, actual));

        }

        // TearDown

    }
}

/*
    Author: numbworks@gmail.com
    Last Update: 06.05.2021
*/