# NW.WIDJobs
Contact: numbworks@gmail.com

## Revision History

| Date | Author | Description |
|---|---|---|
| 2021-05-08 | numbworks | Created. |

## Introduction

`NW.WIDJobs` is a `.NET Standard 2.0` library written in `C#` to explore `WorkInDenmark.dk` and fetch the most recent job ads published. 

## The page URLs

The exploration of `WorkInDenmark.dk` starts from an initial page, which can have three different URLs:

|Criteria|Url|
|---|---|
|`Default`|`https://www.workindenmark.dk/Search/Job-search?q=`|
|`OrderedByDate`|`https://www.workindenmark.dk/Search/Job-search?q=&orderBy=date`|
|`OrderedByRelevance`|`https://www.workindenmark.dk/Search/Job-search?q=&orderBy=`|

The subsequent pages have the following URLs instead:

|Criteria|Url|
|---|---|
|`OrderedByDate`|`https://www.workindenmark.dk/Search/Job-search?q=&orderBy=date&PageNum={pageNumber}&`|
|`OrderedByRelevance`|`https://www.workindenmark.dk/Search/Job-search?q=&orderBy=&PageNum={pageNumber}`|

For the scope of beginning the exploration of the website they are all equivalent, but we do use the the `OrderedByDate` variants.

## Pages, PageItems and PageItemsExtended

The...

...

## How the exploration works

The exploration starts from the initial page, which returns something like this:

![WID_01_Page1.png](Pictures/WID_01_Page1.png)

Every page has twenty `PageItems`:

![WID_02_Page1PageItem1](Pictures/WID_02_Page1PageItem1.png)

Each `PageItem` provides the preliminary information about the job ad, which are:

- JobId
- Url
- Title
- CreatedOn
- WorkArea
- WorkingHours
- JobType

The `Url` brings us to the a `PageItemExtended`, which represents the job ad with the highest amount of information possible. The amount of informational fields provided by the job ad varies considerably, but in the basic case the `PageItemExtended` will contain the same fields found in the original `PageItem` plus the `Description`:

![WID_03_Page1PageItemExtended1](Pictures/WID_03_Page1PageItemExtended1.png)

The following is an example of an `PageItemExtended` containing more fields:

![WID_04_Page2PageItemExtended18](Pictures/WID_04_Page2PageItemExtended18.png)

...

## Page scraping

Every "search result" page contains the number of total results:

```html
...
<!-- Ordering -->
<div class="row" style="padding:15px 0;">
    <div class="col-sm-6">

        
            <strong><strong>2033</strong> results</strong>
        
    </div>
    <div class="col-sm-6">
        <div class="pull-sm-right pull-md-right pull-lg-right">
            <span class="hidden">Order by:</span>
            Date
                        &nbsp;
                        <a href="?q=&orderBy=">Relevance</a>
            
        </div>
    </div>
</div>

<!-- Filter etc. -->
...
```
The XPath pattern to scrape the information out of a page are the following ones:

|Field|Pattern|
|---|---|
|`TotalResults`|`//div[@class='col-sm-9 ']/h1/a/@href`|

The following information are derivative:

|Field|Action|
|---|---|
|`TotalEstimatedPages`|Calculated out of `TotalResults` / 20.|

The following information require extra processing:

|Field|Action|
|---|---|
|`TotalResults`|Parse it to `uint`.|
|`TotalEstimatedPages`|Parse it to `ushort`.|

## PageItems scraping

Every page contains twenty (or less, if it's the last page) objects like the following one:

```html
...
<!-- JobResultItemView.ascx -->
<section class="job-item search-new">
    <div class="job-body ">
		  <div class="row nomargin">
				<div class="col-sm-12">

		          <div class="row ">
            <div class="col-sm-9 ">
                <h1><a class="search-link underline visited" href="/job/8148174/Technology-Finance-Business-Partner">Technology Finance Business Partner<small class="visited-text"> &nbsp;</small></a></h1>
                <p> 
Technology Finance Business Partner
Denmark Copenhagen Local Finance/Accounting Last application date: 28/5/2021
A.P. Moller - Maersk is an integrated container logistics company. Connecting and sim</p>
                <p>
                    Created: <time datetime="2021-05-09">May 09, 2021</time>
                    <br />
                    <strong>Application date: <time datetime="2021-05-28">May 28, 2021</time></strong></p>
            </div>
            <div class="col-sm-3 ">
                <div class="dkmap-holder">
                    <img src="/static/img/widk/bg/danmark.png" alt="map of Denmark" />
                    <div class="spot-capitalregionofdenmark"></div>
                </div>
                
            </div>
        </div>

				</div>
		  </div>
    </div>
    <div class="data-list">
		  <div class="row nomargin">
				<div class="col-sm-12">
					 <ul class="list-inline">
						  <li>Work area: København</li>
						  <li>Working hours: Full time (37 hours)</li>
						  <li>Job type: Regular position</li>
					 </ul>
				</div>
		  </div>
    </div>
</section>
<!-- /JobResultItemView.ascx -->
...
```

The XPath patterns to scrape all the `PageItem` fields are the following ones:

|Field|Pattern|
|---|---|
|`Url`|`//div[@class='col-sm-9 ']/h1/a/@href`|
|`Title`|`//div[@class='col-sm-9 ']/h1`|
|`CreateDate`|`//div[@class='col-sm-9 ']/p[contains(.,'Created')]/time/@datetime`|
|`ApplicationDate`|`//div[@class='col-sm-9 ']/p[contains(.,'Application date')]/strong/time/@datetime`|
|`WorkArea`|`//ul[@class='list-inline']/li[contains(.,'Work area')]`|
|`WorkingHours`|`//ul[@class='list-inline']/li[contains(.,'Working hours')]`|
|`JobType`|`//ul[@class='list-inline']/li[contains(.,'Job type')]`|

The following fields are derivative:

|Field|Action|
|---|---|
|`PageItemNumber`|Equals to the item's position in the list increased by 1.|
|`JobId`|Extract it from `Url`.|
|`PageItemId`|`JobId` and `Title` combined.|

The following fields require extra processing:

|Field|Action|
|---|---|
|`Url`|Convert from relative to absolute.|
|`CreateDate`|Parse it to `DateTime`.|
|`ApplicationDate`|Parse it to `DateTime`.|
|`WorkArea`|Remove `Work area: `.|
|`WorkingHours`|Remove `Working hours: `.|
|`JobType`|Remove `Job type: `.|
|`JobId`|Parse it to `ulong`.|

## PageItemsExtended scraping

`Description` and `SeeCompleteTextAt`:

```html
...
<hr class="margin" />

<div class="row">
    <div class="col-sm-11">

        <div class="JobPresentation job-description">
                <br>Technology Finance Business Partner<br>Denmark Copenhagen Local Finance/Accounting Last application date: 28/5/2021<br>A.P. Moller - Maersk is an integrated container logistics company. Connecting and simplifying trade to help our customers grow and thrive. With a dedicated team of over 76,000, operating in 130 countries; we go all the way to enable global trade for a growing world. <br><br>We, being an equal opportunity employer, are renowned for our dedicated and professional staff and global career opportunities. An opportunity is now available for a career-minded individual to join us as a Technology Finance Business Partner – Technology Infrastructure Engineering & Service Operations.<br><br>Technology will enable our digital transformation, drive more customer value, improve business performance and create operational synergies, to help realize our vision of becoming the Global Integrator of container logistics, connecting and simplifying our customers' supply chain. The Maersk Group is on the l...
        </div>

        <a href="https://jobsearch.maersk.com/jobposting/index.html?id=MA-268026" target="_blank">See the complete text at A.P. Møller - Mærsk A/S</a>



    </div>
</div>
...
```

`EmployerName`:

```html
...
<div id="scphpage_0_scphcontent_1_ctl00_uiEntireJobPostingSpan">
		<hr />

					
					<h2>
						DINEX A/S
					</h2>
...
```

`NumberOfOpenings`, `AdvertisementPublishDate`, `ApplicationDeadline` and `StartDateOfEmployment`:

```html
...
<div class="row">
    <div class="col-sm-11 ">

        <dl class="dl-justify nomargin">
            <dt>
                Number of openings:
            </dt>
            <dd>
                    1
                
            </dd>

            <dt>
                Advertisement publish date:
            </dt>
            <dd>
                    07/05/2021
                
            </dd>
            <dt>
                Application deadline:
            </dt>
            <dd>
                    07/06/2021
                
            </dd>
            <dt>
                Start date of employment:

            </dt>
            <dd>
                    As soon as possible
                
            </dd>
        </dl>

    </div>
</div>
...
```

`Reference`, `Position`, `TypeOfEmployment`, `Contact`, `EmployerAddress` and `HowToApply`:

```html
...
<aside>
    <div class="row row-wide aside padding-left-extra">
        <div class="col-sm-12">

            <div class="row">
                <div class="col-ms-6 col-sm-4">


                    
                    <p>
                        
                        
                    </p>
                    <h3 id="scphpage_0_scphcontent_1_ctl00_H1">
                        Position
                    </h3>
                    <p>
                        Academical work / Engineering professionals
                    </p>
                    <h3>
                        Type of employment
                    </h3>
                    <p>
                        Regular position
                        
                    </p>
                    <h3>
                        Weekly working hours
                    </h3>
                    <p>
                        Full time (37 hours)
                        
                    </p>
                    
                    <p>
                        
                        
                    </p>
                </div>
                <div class="col-ms-6 col-sm-4">

                    <h3>
                        Contact
                    </h3>
                    <p>
                        <span id="scphpage_0_scphcontent_1_ctl00_uiContactNameSpan">
                            Global Test Centre Manager Christian Berg Philipp<br />
                        </span>
                    </p>
                    
                    
                    <h3 id="scphpage_0_scphcontent_1_ctl00_uiEmployerHeading">
                        Employer
                    </h3>
                    <p id="scphpage_0_scphcontent_1_ctl00_uiEmployerAddressSpan">
                        DINEX A/S<br />
                        Fynsvej 39<br />
                        DK 5500 Middelfart<br />
                        Denmark<br />
                    </p>
                    <p id="scphpage_0_scphcontent_1_ctl00_uiEmployerWebSiteSpan">
                        Website:
                        <a id="scphpage_0_scphcontent_1_ctl00_uiEmployerWebSiteContent" href="https://www.dinex.net/">www.dinex.net/</a>
                    </p>
                    

                </div>
                <div class="col-ms-6 col-sm-4">
                    <h3 id="scphpage_0_scphcontent_1_ctl00_uiHowToApplyHeading">
                        How to apply
                    </h3>
                    <ul>
                        
                        
                        
                        <li id="scphpage_0_scphcontent_1_ctl00_uiHowToApplyOnlineSpan"><span style="word-wrap: break-word">
                            Online:
                            <a id="scphpage_0_scphcontent_1_ctl00_uiLnkHowToApplyOnline" href="https://dinex.career.emply.com/ad/nvh-test-engineer/03leyh" target="_blank">Application form</a><br />
                        </span></li>
                    </ul>
                    
                    <h3>
                        Job ID
                    </h3>
                    <p>
                        5340215
                    </p>
                </div>

            </div>
        </div>

    </div>
</aside>
...
```
The XPath patterns to scrape all the `PageItemExtended` fields are the following ones:

Type|Field|Pattern|
|---|---|---|
|`Mandatory`|`Description`|`//div[@class='row']/div[@class='col-sm-11']/div[@class='JobPresentation job-description' or @class='job-description']`|
|`Optional`|`DescriptionSeeCompleteTextAt`|`//div[@class='row']/div[@class='col-sm-11']/a/@href`|
|`Optional`|`DescriptionBulletPoints`|`//div[@class='row']/div[@class='col-sm-11']/div[@class='JobPresentation job-description' or @class='job-description']/ul/li`|
|`Optional`|`EmployerName`|`//div[@id='scphpage_0_scphcontent_1_ctl00_uiEntireJobPostingSpan']/h2`|
|`Optional`|`NumberOfOpenings`|`//div[@class='col-sm-11 ']/dl[@class='dl-justify nomargin']/dt[contains(.,'Number of openings')]/following-sibling::dd[1]`|
|`Optional`|`AdvertisementPublishDate`|`//div[@class='col-sm-11 ']/dl[@class='dl-justify nomargin']/dt[contains(.,'Advertisement publish date')]/following-sibling::dd[1]`|
|`Optional`|`ApplicationDeadline`|`//div[@class='col-sm-11 ']/dl[@class='dl-justify nomargin']/dt[contains(.,'Application deadline')]/following-sibling::dd[1]`|
|`Optional`|`StartDateOfEmployment`|`//div[@class='col-sm-11 ']/dl[@class='dl-justify nomargin']/dt[contains(.,'Start date of employment')]/following-sibling::dd[1]`|
|`Optional`|`Reference`|`//div[@class='col-ms-6 col-sm-4']/h3[contains(., 'Reference')]/following-sibling::p[1]`|
|`Optional`|`Position`|`//div[@class='col-ms-6 col-sm-4']/h3[contains(., 'Position')]/following-sibling::p[1]`|
|`Optional`|`TypeOfEmployment`|`//div[@class='col-ms-6 col-sm-4']/h3[contains(., 'Type of employment')]/following-sibling::p[1]`|
|`Optional`|`Contact`|`//div[@class='col-ms-6 col-sm-4']/h3[contains(., 'Contact')]/following-sibling::p[1]`|
|`Optional`|`EmployerAddress`|`//div[@class='col-ms-6 col-sm-4']/h3[contains(., 'Employer')]/following-sibling::p[1]`|
|`Optional`|`HowToApply`|`//div[@class='col-ms-6 col-sm-4']//ul|//a[@id='scphpage_0_scphcontent_1_ctl00_uiLnkHowToApplyOnline']/@href`|



The following fields require extra processing:

|Field|Action|
|---|---|
|`Description`|Requires trimming.|
|`EmployerName`|Requires trimming.|
|`NumberOfOpenings`|Requires trimming and parsing to `ushort` (if not null).|
|`AdvertisementPublishDate`|Requires trimming and parsing to `DateTime` (if not null).|
|`ApplicationDeadline`|Requires trimming and parsing to `DateTime` (if not null).|
|`StartDateOfEmployment`|Requires trimming.|
|`Reference`|Requires trimming.|
|`Position`|Requires trimming.|
|`TypeOfEmployment`|Requires trimming.|
|`Contact`|Requires trimming.|
|`EmployerAddress`|Requires trimming.|
|`HowToApply`|Requires trimming.|

## Markdown Toolset

Suggested toolset to view and edit this Markdown file:

- [Visual Studio Code](https://code.visualstudio.com/)
- [Markdown Preview Enhanced](https://marketplace.visualstudio.com/items?itemName=shd101wyy.markdown-preview-enhanced)
- [Markdown PDF](https://marketplace.visualstudio.com/items?itemName=yzane.markdown-pdf)