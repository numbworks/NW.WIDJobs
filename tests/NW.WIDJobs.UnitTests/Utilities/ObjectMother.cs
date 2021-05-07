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

        // ExplorationSummary ?
        internal static uint ExplorationSummary_Summary1_TotalResults = 1200;
        internal static ushort ExplorationSummary_Summary1_TotalPagesExpected = 60;
        internal static List<Page> ExplorationSummary_Summary1_Pages
            = new List<Page>() {
                    new Page() {
                        AbsoluteUrl = "https://www.workindenmark.dk/Search/Job-search?q=",
                        PageNumber = 1,
                        Items = new List<PageItem>() {
                                    new PageItem() {
                                            Title = "Country Sales & Product Responsible",
                                            AbsoluteUrl = "https://www.workindenmark.dk/job/6755865/COUNTRY-SALES-PRODUCT-RESPONSIBLE",
                                            ItemId = "6755865COUNTRY-SALES-PRODUCT-RESPONSIBLE",
                                            WorkArea = "Brande",
                                            Employer = "Bestseller A/S",
                                            Openings = 1,
                                            AdvertisementPublishDate = new DateTime(2018, 08, 08),
                                            ApplicationDeadline = new DateTime(2018, 08, 29),
                                            EmploymentStartDate = "As soon as possible",
                                            Description = "some description",
                                            Position = "Management / Sales and marketing managers",
                                            EmploymentType = "Regular position",
                                            WeeklyWorkingHours = "Full time (37 hours)",
                                            Contact = "Apply online",
                                            HowToApply = "Online:\nApplication form<http://about.bestseller.com/jobs/job-search/country-sales-product-responsible-153696>",
                                            EmployerAddress = "BESTSELLER A/S\nFredskovvej 5\nDK 7330 Brande\nDenmark"
                                            }
                                },
                        IsLastForCurrentExploration = true,
                        IsLastOnWebsite = true
                    }
                };
        internal static ExplorationSummary ExplorationSummary_Summary1
            = new ExplorationSummary(
                    ExplorationSummary_Summary1_TotalResults,
                    ExplorationSummary_Summary1_TotalPagesExpected,
                    ExplorationSummary_Summary1_Pages
                );

        // PageItemManager ?
        internal static PageItem PageItemManager_PageItem1
            = new PageItem()
            {
                Title = "Country Sales & Product Responsible",
                AbsoluteUrl = "https://www.workindenmark.dk/job/6755865/COUNTRY-SALES-PRODUCT-RESPONSIBLE",
                ItemId = "6755865COUNTRY-SALES-PRODUCT-RESPONSIBLE",
                WorkArea = "Brande"
            };
        internal static PageItem PageItemManager_PageItem2
            = new PageItem()
            {
                Title = "Country Sales & Product Responsible",
                AbsoluteUrl = "https://www.workindenmark.dk/job/6755865/COUNTRY-SALES-PRODUCT-RESPONSIBLE",
                ItemId = "6755865COUNTRY-SALES-PRODUCT-RESPONSIBLE"
            };
        internal static PageItem PageItemManager_PageItem3
            = new PageItem()
            {
                Title = "Country Sales & Product Responsible",
                AbsoluteUrl = "https://www.workindenmark.dk/job/6755865/COUNTRY-SALES-PRODUCT-RESPONSIBLE",
                ItemId = "6755865COUNTRY-SALES-PRODUCT-RESPONSIBLE",
                WorkArea = "Brande",
                Description = "some description"
            };

        // ExplorerTests
        internal static string Explorer_Url1 = "https://www.workindenmark.dk/Search/Job-search?q=";
        internal static string Explorer_Url2 = "https://www.workindenmark.dk/Search/Job-search?q=&PageNum=2";
        internal static string Explorer_Page1HTML = Properties.Resources.WorkInDenmark_Page1;
        internal static string Explorer_Page2HTML = Properties.Resources.WorkInDenmark_Page2;
        internal static Page Explorer_Page1 = new Page()
        {
            AbsoluteUrl = Explorer_Url1,
            PageNumber = 1,
            Items = new List<PageItem>() {
                            new PageItem() {
                                Title = "Logistics Specialist",
                                AbsoluteUrl = "https://www.workindenmark.dk/job/6765129/Logistics-Specialist",
                                ItemId = "6765129Logistics-Specialist",
                                WorkArea = "Kolding"
                            },
                            new PageItem() {
                                Title = "Project Manager",
                                AbsoluteUrl = "https://www.workindenmark.dk/job/6765122/Project-Manager",
                                ItemId = "6765122Project-Manager",
                                WorkArea = "Vejle"
                            },
                            new PageItem() {
                                Title = "Senior Project Manager",
                                AbsoluteUrl = "https://www.workindenmark.dk/job/6765120/Senior-Project-Manager",
                                ItemId = "6765120Senior-Project-Manager",
                                WorkArea = "Nordborg"
                            },
                            new PageItem() {
                                Title = "Manager",
                                AbsoluteUrl = "https://www.workindenmark.dk/job/6765117/Manager",
                                ItemId = "6765117Manager",
                                WorkArea = "Nordborg"
                            },
                            new PageItem() {
                                Title = "Project Engineer",
                                AbsoluteUrl = "https://www.workindenmark.dk/job/6765114/Project-Engineer",
                                ItemId = "6765114Project-Engineer",
                                WorkArea = "Nordborg"
                            },
                            new PageItem() {
                                Title = "Software Engineer",
                                AbsoluteUrl = "https://www.workindenmark.dk/job/6765113/Software-Engineer",
                                ItemId = "6765113Software-Engineer",
                                WorkArea = "Gråsten"
                            },
                            new PageItem() {
                                Title = "Manager",
                                AbsoluteUrl = "https://www.workindenmark.dk/job/6765112/Manager",
                                ItemId = "6765112Manager",
                                WorkArea = "Nordborg"
                            },
                            new PageItem() {
                                Title = "Director",
                                AbsoluteUrl = "https://www.workindenmark.dk/job/6765109/Director",
                                ItemId = "6765109Director",
                                WorkArea = "Nordborg"
                            },
                            new PageItem() {
                                Title = "Logistics Manager",
                                AbsoluteUrl = "https://www.workindenmark.dk/job/6765108/Logistics-Manager",
                                ItemId = "6765108Logistics-Manager",
                                WorkArea = "Viby J"
                            },
                            new PageItem() {
                                Title = "Electronics Engineer",
                                AbsoluteUrl = "https://www.workindenmark.dk/job/6765106/Electronics-Engineer",
                                ItemId = "6765106Electronics-Engineer",
                                WorkArea = "Nordborg"
                            },
                            new PageItem() {
                                Title = "Supply Chain Specialist",
                                AbsoluteUrl = "https://www.workindenmark.dk/job/6765105/Supply-Chain-Specialist",
                                ItemId = "6765105Supply-Chain-Specialist",
                                WorkArea = "Nordborg"
                            },
                            new PageItem() {
                                Title = "Application Specialist",
                                AbsoluteUrl = "https://www.workindenmark.dk/job/6765103/Application-Specialist",
                                ItemId = "6765103Application-Specialist",
                                WorkArea = "Nordborg"
                            },
                            new PageItem() {
                                Title = "Software Engineer",
                                AbsoluteUrl = "https://www.workindenmark.dk/job/6765102/Software-Engineer",
                                ItemId = "6765102Software-Engineer",
                                WorkArea = "Nordborg"
                            },
                            new PageItem() {
                                Title = "Director",
                                AbsoluteUrl = "https://www.workindenmark.dk/job/6765101/Director",
                                ItemId = "6765101Director",
                                WorkArea = "Nordborg"
                            },
                            new PageItem() {
                                Title = "Process Engineer",
                                AbsoluteUrl = "https://www.workindenmark.dk/job/6765100/Process-Engineer",
                                ItemId = "6765100Process-Engineer",
                                WorkArea = "Nordborg"
                            },
                            new PageItem() {
                                Title = "Senior Director",
                                AbsoluteUrl = "https://www.workindenmark.dk/job/6765098/Senior-Director",
                                ItemId = "6765098Senior-Director",
                                WorkArea = "Nordborg"
                            },
                            new PageItem() {
                                Title = "Consultant",
                                AbsoluteUrl = "https://www.workindenmark.dk/job/6765097/Consultant",
                                ItemId = "6765097Consultant",
                                WorkArea = "Nordborg"
                            },
                            new PageItem() {
                                Title = "Leader",
                                AbsoluteUrl = "https://www.workindenmark.dk/job/6765094/Leader",
                                ItemId = "6765094Leader",
                                WorkArea = "Nordborg"
                            },
                            new PageItem() {
                                Title = "Consultant",
                                AbsoluteUrl = "https://www.workindenmark.dk/job/6765093/Consultant",
                                ItemId = "6765093Consultant",
                                WorkArea = "Nordborg"
                            },
                            new PageItem() {
                                Title = "Account Manager",
                                AbsoluteUrl = "https://www.workindenmark.dk/job/6765090/Account-Manager",
                                ItemId = "6765090Account-Manager",
                                WorkArea = "Nordborg"
                            }
                        },
            IsLastForCurrentExploration = false
        };
        internal static Page Explorer_Page2 = new Page()
        {
            AbsoluteUrl = Explorer_Url2,
            PageNumber = 2,
            Items = new List<PageItem>() {
                            new PageItem() {
                                Title = "Application Specialist",
                                AbsoluteUrl = "https://www.workindenmark.dk/job/6765088/Application-Specialist",
                                ItemId = "6765088Application-Specialist",
                                WorkArea = "Nordborg"
                            },
                            new PageItem() {
                                Title = "Test Engineer",
                                AbsoluteUrl = "https://www.workindenmark.dk/job/6765087/Test-Engineer",
                                ItemId = "6765087Test-Engineer",
                                WorkArea = "Gråsten"
                            },
                            new PageItem() {
                                Title = "Test Engineer",
                                AbsoluteUrl = "https://www.workindenmark.dk/job/6765085/Test-Engineer",
                                ItemId = "6765085Test-Engineer",
                                WorkArea = "Gråsten"
                            },
                            new PageItem() {
                                Title = "Communicator",
                                AbsoluteUrl = "https://www.workindenmark.dk/job/6765084/Communicator",
                                ItemId = "6765084Communicator",
                                WorkArea = "Nordborg"
                            },
                            new PageItem() {
                                Title = "Application Specialist",
                                AbsoluteUrl = "https://www.workindenmark.dk/job/6765083/Application-Specialist",
                                ItemId = "6765083Application-Specialist",
                                WorkArea = "Nordborg"
                            },
                            new PageItem() {
                                Title = "Engineer",
                                AbsoluteUrl = "https://www.workindenmark.dk/job/6765082/Engineer",
                                ItemId = "6765082Engineer",
                                WorkArea = "Gråsten"
                            },
                            new PageItem() {
                                Title = "Project Manager",
                                AbsoluteUrl = "https://www.workindenmark.dk/job/6765081/Project-Manager",
                                ItemId = "6765081Project-Manager",
                                WorkArea = "Nordborg"
                            },
                            new PageItem() {
                                Title = "Plant Manager",
                                AbsoluteUrl = "https://www.workindenmark.dk/job/6765078/Plant-Manager",
                                ItemId = "6765078Plant-Manager",
                                WorkArea = "Nordborg"
                            },
                            new PageItem() {
                                Title = "Communicator",
                                AbsoluteUrl = "https://www.workindenmark.dk/job/6765077/Communicator",
                                ItemId = "6765077Communicator",
                                WorkArea = "Nordborg"
                            },
                            new PageItem() {
                                Title = "Marketing Specialist",
                                AbsoluteUrl = "https://www.workindenmark.dk/job/6765076/Marketing-Specialist",
                                ItemId = "6765076Marketing-Specialist",
                                WorkArea = "Gråsten"
                            },
                            new PageItem() {
                                Title = "Recruiter",
                                AbsoluteUrl = "https://www.workindenmark.dk/job/6765075/Recruiter",
                                ItemId = "6765075Recruiter",
                                WorkArea = "Nordborg"
                            },
                            new PageItem() {
                                Title = "Mælkeproducent ved Farsø søger deltidsmedarbejder A cow farmer near Farsø (9640) is looking for a part time worker",
                                AbsoluteUrl = "https://www.workindenmark.dk/job/6765074/Mælkeproducent-ved-Farsø-søger-deltidsmedarbejder-A-cow-farmer-near-Farsø-9640-is-looking-for-a-part-time-worker",
                                ItemId = "6765074Mælkeproducent-ved-Farsø-søger-deltidsmedarbejder-A-cow-farmer-near-Farsø-9640-is-looking-for-a-part-time-worker",
                                WorkArea = "Aars"
                            },
                            new PageItem() {
                                Title = "PhD scholarship in Super Resolution Ultrasound Imaging",
                                AbsoluteUrl = "https://www.workindenmark.dk/job/6765073/PhD-scholarship-in-Super-Resolution-Ultrasound-Imaging",
                                ItemId = "6765073PhD-scholarship-in-Super-Resolution-Ultrasound-Imaging",
                                WorkArea = "Kgs. Lyngby"
                            },
                            new PageItem() {
                                Title = "Test Center Manager",
                                AbsoluteUrl = "https://www.workindenmark.dk/job/6765072/Test-Center-Manager",
                                ItemId = "6765072Test-Center-Manager",
                                WorkArea = "Middelfart"
                            },
                            new PageItem() {
                                Title = "Manufacturing Associates",
                                AbsoluteUrl = "https://www.workindenmark.dk/job/6765071/Manufacturing-Associates",
                                ItemId = "6765071Manufacturing-Associates",
                                WorkArea = "Hillerød"
                            },
                            new PageItem() {
                                Title = "Regulatory Affairs Professional Labelling",
                                AbsoluteUrl = "https://www.workindenmark.dk/job/6765070/Regulatory-Affairs-Professional-Labelling",
                                ItemId = "6765070Regulatory-Affairs-Professional-Labelling",
                                WorkArea = "Ballerup"
                            },
                            new PageItem() {
                                Title = "Scientist Senior Scientist advanced analytical chemistry",
                                AbsoluteUrl = "https://www.workindenmark.dk/job/6765069/Scientist-Senior-Scientist-advanced-analytical-chemistry",
                                ItemId = "6765069Scientist-Senior-Scientist-advanced-analytical-chemistry",
                                WorkArea = "Ballerup"
                            },
                            new PageItem() {
                                Title = "Senior Principal Biostatistician",
                                AbsoluteUrl = "https://www.workindenmark.dk/job/6765068/Senior-Principal-Biostatistician",
                                ItemId = "6765068Senior-Principal-Biostatistician",
                                WorkArea = "Ballerup"
                            },
                            new PageItem() {
                                Title = "People Manager",
                                AbsoluteUrl = "https://www.workindenmark.dk/job/6765067/People-Manager",
                                ItemId = "6765067People-Manager",
                                WorkArea = "Nordborg"
                            },
                            new PageItem() {
                                Title = "Technician analytical chemistry in Early Drug Development",
                                AbsoluteUrl = "https://www.workindenmark.dk/job/6765066/Technician-analytical-chemistry-in-Early-Drug-Development",
                                ItemId = "6765066Technician-analytical-chemistry-in-Early-Drug-Development",
                                WorkArea = "Ballerup"
                            }
                },
            IsLastForCurrentExploration = true
        };
        internal static Func<IGetRequestManager> Explorer_FuncPage1Page2
            = new Func<IGetRequestManager>(() =>
            {
                IGetRequestManager fakeGetRequestManager = Substitute.For<IGetRequestManager>();
                fakeGetRequestManager.Send(Arg.Any<string>()).Returns(Explorer_Page1HTML, Explorer_Page2HTML);
                return fakeGetRequestManager;
            });
        internal static Func<IGetRequestManager> Explorer_FuncPage1
            = new Func<IGetRequestManager>(() =>
            {
                IGetRequestManager fakeGetRequestManager = Substitute.For<IGetRequestManager>();
                fakeGetRequestManager.Send(Arg.Is<string>(x => x.Equals(Explorer_Url1))).Returns(Explorer_Page1HTML);
                return fakeGetRequestManager;
            });
        internal static Func<IGetRequestManager> Explorer_FuncPage1WithoutDivColSm9
            = new Func<IGetRequestManager>(() =>
            {
                IGetRequestManager fakeGetRequestManager = Substitute.For<IGetRequestManager>();
                fakeGetRequestManager.Send(Arg.Is<string>(x => x.Equals(Explorer_Url1))).Returns(Explorer_Page1HTML.Replace("<div class=\"col-sm-9 \">", "<div class=\"gibberish\">"));
                return fakeGetRequestManager;
            });
        internal static Func<IGetRequestManager> Explorer_FuncSomeMessage
            = new Func<IGetRequestManager>(() =>
            {
                IGetRequestManager fakeGetRequestManager = Substitute.For<IGetRequestManager>();
                fakeGetRequestManager.Send(Arg.Any<string>()).Returns("somemessage");
                return fakeGetRequestManager;
            });
        internal static Func<IGetRequestManager> Explorer_FuncEmptyString
            = new Func<IGetRequestManager>(() =>
            {
                IGetRequestManager fakeGetRequestManager = Substitute.For<IGetRequestManager>();
                fakeGetRequestManager.Send(Arg.Any<string>()).Returns(string.Empty);
                return fakeGetRequestManager;
            });
        internal static Func<IGetRequestManager> Explorer_FuncPage1WithoutColSm6
            = new Func<IGetRequestManager>(() =>
            {
                IGetRequestManager fakeGetRequestManager = Substitute.For<IGetRequestManager>();
                fakeGetRequestManager.Send(Arg.Is<string>(x => x.Equals(Explorer_Url1))).Returns(Explorer_Page1HTML.Replace("col-sm-6", "fakeclass"));
                return fakeGetRequestManager;
            });
        internal static Func<IGetRequestManager> Explorer_FuncPage1WithoutStrong1234
            = new Func<IGetRequestManager>(() =>
            {
                IGetRequestManager fakeGetRequestManager = Substitute.For<IGetRequestManager>();
                fakeGetRequestManager.Send(Arg.Is<string>(x => x.Equals(Explorer_Url1))).Returns(Explorer_Page1HTML.Replace("<strong>1243</strong>", "<strong>gibberish</strong>"));
                return fakeGetRequestManager;
            });
        internal static Func<IGetRequestManager> Explorer_FuncPage1WithoutColSm12
            = new Func<IGetRequestManager>(() =>
            {
                IGetRequestManager fakeGetRequestManager = Substitute.For<IGetRequestManager>();
                fakeGetRequestManager.Send(Arg.Is<string>(x => x.Equals(Explorer_Url1))).Returns(Explorer_Page1HTML.Replace("col-sm-12", "fakeclass"));
                return fakeGetRequestManager;
            });
        internal static Func<IGetRequestManager> Explorer_FuncPage1WithoutFirstColSm9
            = new Func<IGetRequestManager>(() =>
            {
                IGetRequestManager fakeGetRequestManager = Substitute.For<IGetRequestManager>();
                fakeGetRequestManager.Send(Arg.Is<string>(x => x.Equals(Explorer_Url1))).Returns(ReplaceFirstOccurrence(Explorer_Page1HTML, "col-sm-9 ", "fakeclass"));
                return fakeGetRequestManager;
            });
        internal static ExplorationSummary Explorer_Summary1
            = new ExplorationSummary(
                        1243,
                        63,
                        new List<Page>() {
                            Explorer_Page1,
                            new Page() {
                                AbsoluteUrl = Explorer_Page2.AbsoluteUrl,
                                PageNumber = Explorer_Page2.PageNumber,
                                IsLastForCurrentExploration = Explorer_Page2.IsLastForCurrentExploration,
                                Items = RemoveItems(Explorer_Page2.Items, 19, 1)
                            }
                        }); // Page1: new items, Page2: 19 new items + 1 already imported.
        internal static ExplorationSummary Explorer_Summary2
            = new ExplorationSummary(
                         1243,
                         63,
                         new List<Page>() {
                            new Page() {
                                AbsoluteUrl = Explorer_Page1.AbsoluteUrl,
                                PageNumber = Explorer_Page1.PageNumber,
                                IsLastForCurrentExploration = Explorer_Page1.IsLastForCurrentExploration,
                                Items = RemoveItems(Explorer_Page1.Items, 18, 2)
                            }
                         }); // Page1: 18 new items + 2 already imported.

        // PageItemScraperTests
        internal static string PageItemScraper_ItemHTML = Properties.Resources.WorkInDenmark_Item;
        internal static string PageItemScraper_ItemDescriptionHTML = Properties.Resources.WorkInDenmark_Item_Description;
        internal static string PageItemScraper_ItemWithPresentationHTML = Properties.Resources.WorkInDenmark_ItemWithPresentation;
        internal static string PageItemScraper_ItemPresentationHTML = Properties.Resources.WorkInDenmark_Item_Presentation;
        internal static Func<IGetRequestManager> PageItemScraper_FuncItem
            = new Func<IGetRequestManager>(() =>
            {
                IGetRequestManager fakeGetRequest = Substitute.For<IGetRequestManager>();
                fakeGetRequest.Send(Arg.Any<string>()).Returns(PageItemScraper_ItemHTML);
                return fakeGetRequest;
            });
        internal static Func<IGetRequestManager> PageItemScraper_FuncEmptyHTML
            = new Func<IGetRequestManager>(() =>
            {
                IGetRequestManager fakeGetRequest = Substitute.For<IGetRequestManager>();
                fakeGetRequest.Send(Arg.Any<string>()).Returns("<html></<html>");
                return fakeGetRequest;
            });
        internal static Func<IGetRequestManager> PageItemScraper_FuncItemWithoutUrl
            = new Func<IGetRequestManager>(() =>
            {
                IGetRequestManager fakeGetRequest = Substitute.For<IGetRequestManager>();
                fakeGetRequest.Send(Arg.Any<string>()).Returns(PageItemScraper_ItemHTML.Replace("http://about.bestseller.com/jobs/job-search/country-sales-product-responsible-153696", string.Empty));
                return fakeGetRequest;
            });
        internal static Func<IGetRequestManager> PageItemScraper_FuncItemWithoutHowToApplyURL
            = new Func<IGetRequestManager>(() =>
            {
                IGetRequestManager fakeGetRequest = Substitute.For<IGetRequestManager>();
                fakeGetRequest.Send(Arg.Any<string>())
                    .Returns(PageItemScraper_ItemHTML
                    .Replace(
                        "<a id=\"scphpage_0_scphcontent_1_ctl00_uiLnkHowToApplyOnline\" href=\"http://about.bestseller.com/jobs/job-search/country-sales-product-responsible-153696\" target=\"_blank\">",
                        "<a id=\"scphpage_0_scphcontent_1_ctl00_uiLnkHowToApplyOnline\">"
                        ));
                return fakeGetRequest;
            });
        internal static Func<IGetRequestManager> PageItemScraper_FuncItemWithoutHowToApply
            = new Func<IGetRequestManager>(() =>
            {
                IGetRequestManager fakeGetRequest = Substitute.For<IGetRequestManager>();
                fakeGetRequest.Send(Arg.Any<string>())
                    .Returns(PageItemScraper_ItemHTML
                    .Replace(
                        "<a id=\"scphpage_0_scphcontent_1_ctl00_uiLnkHowToApplyOnline\" href=\"http://about.bestseller.com/jobs/job-search/country-sales-product-responsible-153696\" target=\"_blank\">",
                        string.Empty
                        ));
                return fakeGetRequest;
            });
        internal static Func<IGetRequestManager> PageItemScraper_FuncItemWithPresentationHTML
            = new Func<IGetRequestManager>(() =>
            {
                IGetRequestManager fakeGetRequest = Substitute.For<IGetRequestManager>();
                fakeGetRequest.Send(Arg.Any<string>()).Returns(PageItemScraper_ItemWithPresentationHTML);
                return fakeGetRequest;
            });
        internal static Func<IGetRequestManager> PageItemScraper_FuncItemWithPresentationHTMLEdit1
            = new Func<IGetRequestManager>(() =>
            {
                IGetRequestManager fakeGetRequest = Substitute.For<IGetRequestManager>();
                fakeGetRequest.Send(Arg.Any<string>()).Returns(PageItemScraper_ItemWithPresentationHTML.Replace("See the complete text at Bestseller A/S", string.Empty));
                return fakeGetRequest;
            });
        internal static Func<IGetRequestManager> PageItemScraper_FuncItemWithPresentationHTMLEdit2
            = new Func<IGetRequestManager>(() =>
            {
                IGetRequestManager fakeGetRequest = Substitute.For<IGetRequestManager>();
                fakeGetRequest.Send(Arg.Any<string>())
                    .Returns(
                        PageItemScraper_ItemWithPresentationHTML.Replace(
                            "<a href=\"http://about.bestseller.com/jobs/job-search/money-maker-for-international-sales-team-154406\">",
                            "<a>"
                        ));
                return fakeGetRequest;
            });
        internal static Func<IGetRequestManager> PageItemScraper_FuncItemWithPresentationHTMLEdit3
            = new Func<IGetRequestManager>(() =>
            {
                IGetRequestManager fakeGetRequest = Substitute.For<IGetRequestManager>();
                fakeGetRequest.Send(Arg.Any<string>())
                    .Returns(
                        PageItemScraper_ItemWithPresentationHTML.Replace(
                            "<a href=\"http://about.bestseller.com/jobs/job-search/money-maker-for-international-sales-team-154406\">",
                            "<a href=\"\">"));
                return fakeGetRequest;
            });

        internal static PageItem PageItemScraper_Item1Before
            = new PageItem()
            {
                Title = "Country Sales & Product Responsible",
                AbsoluteUrl = "https://www.workindenmark.dk/job/6755865/COUNTRY-SALES-PRODUCT-RESPONSIBLE",
                ItemId = "6755865COUNTRY-SALES-PRODUCT-RESPONSIBLE",
                WorkArea = "Brande"
            };
        internal static PageItem PageItemScraper_Item1After
            = new PageItem()
            {
                Title = "Country Sales & Product Responsible",
                AbsoluteUrl = "https://www.workindenmark.dk/job/6755865/COUNTRY-SALES-PRODUCT-RESPONSIBLE",
                ItemId = "6755865COUNTRY-SALES-PRODUCT-RESPONSIBLE",
                WorkArea = "Brande",
                Employer = "Bestseller A/S",
                Openings = 1,
                AdvertisementPublishDate = new DateTime(2018, 08, 08),
                ApplicationDeadline = new DateTime(2018, 08, 29),
                EmploymentStartDate = "As soon as possible",
                Description = PageItemScraper_ItemDescriptionHTML,
                Position = "Management / Sales and marketing managers",
                EmploymentType = "Regular position",
                WeeklyWorkingHours = "Full time (37 hours)",
                Contact = "Apply online",
                HowToApply = "Online:\nApplication form<http://about.bestseller.com/jobs/job-search/country-sales-product-responsible-153696>",
                EmployerAddress = "BESTSELLER A/S\nFredskovvej 5\nDK 7330 Brande\nDenmark"
            };
        internal static PageItem PageItemScraper_ItemOnlyAbsoluteUrl
            = new PageItem()
            {
                AbsoluteUrl = "https://www.workindenmark.dk/job/6755865/COUNTRY-SALES-PRODUCT-RESPONSIBLE"
            };
        internal static PageItem PageItemScraper_ItemOnlyItemId
            = new PageItem()
            {
                ItemId = "6755865COUNTRY-SALES-PRODUCT-RESPONSIBLE"
            };
        internal static PageItem PageItemScraper_Item2Before
            = new PageItem()
            {
                Title = "Job agent",
                AbsoluteUrl = "https://www.workindenmark.dk/job/6806252/Job-agent",
                ItemId = "6806252Job-agent",
                WorkArea = "Brande"
            };
        internal static PageItem PageItemScraper_Item2After
            = new PageItem()
            {
                Title = "Job agent",
                AbsoluteUrl = "https://www.workindenmark.dk/job/6806252/Job-agent",
                ItemId = "6806252Job-agent",
                WorkArea = "Brande",
                AdvertisementPublishDate = new DateTime(2018, 09, 15),
                ApplicationDeadline = new DateTime(2018, 12, 31),
                Description = PageItemScraper_ItemPresentationHTML
            };
        internal static PageItem PageItemScraper_Item2AfterEdit1
            = new PageItem()
            {
                Title = "Job agent",
                AbsoluteUrl = "https://www.workindenmark.dk/job/6806252/Job-agent",
                ItemId = "6806252Job-agent",
                WorkArea = "Brande",
                AdvertisementPublishDate = new DateTime(2018, 09, 15),
                ApplicationDeadline = new DateTime(2018, 12, 31),
                Description = PageItemScraper_ItemPresentationHTML
                                .Replace("See the complete text at Bestseller A/S", string.Empty)
                                .Replace("http://about.bestseller.com/jobs/job-search/money-maker-for-international-sales-team-154406", string.Empty)
                                .Replace(Environment.NewLine, string.Empty)
            };
        internal static PageItem PageItemScraper_Item2AfterEdit2
            = new PageItem()
            {
                Title = "Job agent",
                AbsoluteUrl = "https://www.workindenmark.dk/job/6806252/Job-agent",
                ItemId = "6806252Job-agent",
                WorkArea = "Brande",
                AdvertisementPublishDate = new DateTime(2018, 09, 15),
                ApplicationDeadline = new DateTime(2018, 12, 31),
                Description = PageItemScraper_ItemPresentationHTML
                                .Replace("http://about.bestseller.com/jobs/job-search/money-maker-for-international-sales-team-154406", string.Empty)
                                .Replace("See the complete text at Bestseller A/S" + Environment.NewLine, "See the complete text at Bestseller A/S")
            };
        internal static PageItem PageItemScraper_Item2AfterEdit3
            = new PageItem()
            {
                Title = "Job agent",
                AbsoluteUrl = "https://www.workindenmark.dk/job/6806252/Job-agent",
                ItemId = "6806252Job-agent",
                WorkArea = "Brande",
                AdvertisementPublishDate = new DateTime(2018, 09, 15),
                ApplicationDeadline = new DateTime(2018, 12, 31),
                Description = PageItemScraper_ItemPresentationHTML
                                .Replace("http://about.bestseller.com/jobs/job-search/money-maker-for-international-sales-team-154406", String.Empty)
            };


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

        internal static bool IsPreliminary(PageItem pageItem)
        {

            return pageItem.AbsoluteUrl != null
                    && pageItem.ItemId != null
                    // WorkArea can be both null and not null
                    && pageItem.Title != null
                    && pageItem.Employer == null
                    && pageItem.Openings == null
                    && pageItem.AdvertisementPublishDate == null
                    && pageItem.ApplicationDeadline == null
                    && pageItem.EmploymentStartDate == null
                    && pageItem.Description == null
                    && pageItem.EmploymentType == null
                    && pageItem.WeeklyWorkingHours == null
                    && pageItem.EmployerAddress == null
                    && pageItem.Contact == null
                    && pageItem.HowToApply == null;

        }
        internal static string ReplaceLettersWithWhiteSpaces(string str)
        {

            if (string.IsNullOrEmpty(str))
                return str;

            string result = null;
            for (int i = 0; i < str.Length; i++)
                result = result + " ";

            return result;

        }
        internal static string ReplaceFirstOccurrence(string text, string before, string after)
        {

            int position = text.IndexOf(before);
            if (position < 0)
                return text;

            return string.Concat(
                    text.Substring(0, position),
                    after,
                    text.Substring(position + before.Length));

        }
        internal static List<PageItem> RemoveItems(List<PageItem> pageItems, int index, int count)
        {

            List<PageItem> result = new List<PageItem>(pageItems);
            result.RemoveRange(index, count);

            return result;

        }

        internal static Tuple<string, Page> GeneratePageFour()
        {

            /*

                This method generates a Page4 (right) out of Page2 (left):

                    ...
                    <li>Work area: Ballerup</li>					=> 
                    ...
                
                    <li>Job type: Limited period</li>				=>
                    ...
                
                    /job/6765071/Manufacturing-Associates 			=> /job/0000001/Manufacturing-Associates
                    ...
                    <li>Work area: Hillerød</li>					 
                    <li>Working hours: Full time (37 hours)</li>	=>	<li>Working hours: Full time (37 hours)</li>
                    <li>Job type: Regular position</li>					<li>Job type: Regular position</li>
                    ...

                This is useful for testing one of these scenarios:

                    ...
                    Work area: Nordborg
                    Working hours: Full time (37 hours)
                    Job type: Regular position

                    <missing>
                    Working hours: Full time (37 hours)
                    Job type: Regular position

                    <missing>
                    Working hours: Full time (37 hours)
                    Job type: Regular position

                    Work area: Middelfart
                    Working hours: Full time (37 hours)
                    <missing>
                    ...                    

                The JobIds are replaced to make them uniquely identifiable by RemoveAlreadyImportedItems().

            */

            string url4 = "https://www.workindenmark.dk/Search/Job-search?q=&PageNum=4";
            string ballerup = "<li>Work area: Ballerup</li>"; // 4 hits
            string limitedPeriod = "<li>Job type: Limited period</li>"; // 2 hits
            string hillerod = "<li>Work area: Hillerød</li>"; // 1 hit

            string page4HTML = Properties.Resources.WorkInDenmark_Page2
                                .Replace(ballerup, ReplaceLettersWithWhiteSpaces(ballerup))
                                .Replace(limitedPeriod, ReplaceLettersWithWhiteSpaces(limitedPeriod))
                                .Replace("/job/6765071/", "/job/0000001/")
                                .Replace(hillerod, ReplaceLettersWithWhiteSpaces(hillerod))
                                .Replace("/job/6765070/", "/job/0000002/")
                                .Replace("/job/6765069/", "/job/0000003/")
                                .Replace("/job/6765068/", "/job/0000004/")
                                .Replace("/job/6765067/", "/job/0000005/")
                                .Replace("/job/6765066/", "/job/0000006/");

            Page page4 = new Page()
            {
                AbsoluteUrl = url4,
                PageNumber = 4,
                Items = new List<PageItem>() {
                            Explorer_Page2.Items[0],
                            Explorer_Page2.Items[1],
                            Explorer_Page2.Items[2],
                            Explorer_Page2.Items[3],
                            Explorer_Page2.Items[4],
                            Explorer_Page2.Items[5],
                            Explorer_Page2.Items[6],
                            Explorer_Page2.Items[7],
                            Explorer_Page2.Items[8],
                            Explorer_Page2.Items[9],
                            Explorer_Page2.Items[10],
                            Explorer_Page2.Items[11],
                            Explorer_Page2.Items[12],
                            Explorer_Page2.Items[13],
                            new PageItem() {
                                Title = "Manufacturing Associates",
                                AbsoluteUrl = "https://www.workindenmark.dk/job/0000001/Manufacturing-Associates",
                                ItemId = "0000001Manufacturing-Associates"
                            },
                            new PageItem() {
                                Title = "Regulatory Affairs Professional Labelling",
                                AbsoluteUrl = "https://www.workindenmark.dk/job/0000002/Regulatory-Affairs-Professional-Labelling",
                                ItemId = "0000002Regulatory-Affairs-Professional-Labelling"
                            },
                            new PageItem() {
                                Title = "Scientist Senior Scientist advanced analytical chemistry",
                                AbsoluteUrl = "https://www.workindenmark.dk/job/0000003/Scientist-Senior-Scientist-advanced-analytical-chemistry",
                                ItemId = "0000003Scientist-Senior-Scientist-advanced-analytical-chemistry"
                            },
                            new PageItem() {
                                Title = "Senior Principal Biostatistician",
                                AbsoluteUrl = "https://www.workindenmark.dk/job/0000004/Senior-Principal-Biostatistician",
                                ItemId = "0000004Senior-Principal-Biostatistician"
                            },
                            new PageItem() {
                                Title = "People Manager",
                                AbsoluteUrl = "https://www.workindenmark.dk/job/0000005/People-Manager",
                                ItemId = "0000005People-Manager",
                                WorkArea = "Nordborg"
                            },
                            new PageItem() {
                                Title = "Technician analytical chemistry in Early Drug Development",
                                AbsoluteUrl = "https://www.workindenmark.dk/job/0000006/Technician-analytical-chemistry-in-Early-Drug-Development",
                                ItemId = "0000006Technician-analytical-chemistry-in-Early-Drug-Development"
                            }
                },
                IsLastForCurrentExploration = true
            };

            return new Tuple<string, Page>(page4HTML, page4);

        }
        internal static TestCaseData GenerateScenarioPageFour()
        {

            string newPage1 = Explorer_Page1HTML.Replace("<strong>1243</strong>", "<strong>80</strong>");
            string page4HTML = GeneratePageFour().Item1;
            Page page4 = GeneratePageFour().Item2;

            return
                new TestCaseData(
                    new Func<IGetRequestManager>(() =>
                    {
                        IGetRequestManager fakeGetRequest = Substitute.For<IGetRequestManager>();
                        fakeGetRequest.Send(Arg.Any<string>()).Returns(newPage1, Explorer_Page2HTML, Explorer_Page2HTML, page4HTML);
                        return fakeGetRequest;
                    }),
                    new ExplorationSummary
                        (
                            80,
                            4,
                            new List<Page>() {
                                Explorer_Page1,
                                new Page() {
                                    AbsoluteUrl = Explorer_Page2.AbsoluteUrl,
                                    PageNumber = Explorer_Page2.PageNumber,
                                    Items = Explorer_Page2.Items,
                                    IsLastForCurrentExploration = false
                                },
                                new Page() {
                                    AbsoluteUrl = Explorer_Page2.AbsoluteUrl,
                                    PageNumber = Explorer_Page2.PageNumber,
                                    Items = Explorer_Page2.Items,
                                    IsLastForCurrentExploration = false
                                },
                                new Page() {
                                    AbsoluteUrl = page4.AbsoluteUrl,
                                    PageNumber = page4.PageNumber,
                                    Items = RemoveItems(page4.Items, 14, 6),
                                    IsLastForCurrentExploration = page4.IsLastForCurrentExploration,
                                    IsLastOnWebsite = true
                                }
                            }
                        )
                );

        }

        internal static bool AreEqual(ExplorationSummary explorationSummary1, ExplorationSummary explorationSummary2)
            => throw new NotImplementedException();
        internal static bool AreEqual(PageItem pageItem1, PageItem pageItem2)
            => throw new NotImplementedException();

    }
}

/*

    Author: numbworks@gmail.com
    Last Update: 30.09.2020

*/