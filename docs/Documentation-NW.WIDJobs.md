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

Every...

```html
...

...
```

The XPath patterns to scrape all the `PageItemExtended` fields are the following ones:

Type|Field|Pattern|
|---|---|---|
|`Mandatory`|`Description`||
|`Optional`|`EmployerName`||
|`Optional`|`NumberOfOpenings`||
|`Optional`|`AdvertisementPublishDate`||
|`Optional`|`ApplicationDeadline`||
|`Optional`|`StartDateOfEmployment`||
|`Optional`|`Reference`||
|`Optional`|`Position`||
|`Optional`|`TypeOfEmployment`||
|`Optional`|`Contact`||
|`Optional`|`EmployerAddress`||

HowToApply

The following fields are derivative:

|Field|Action|
|---|---|
|``||

The following fields require extra processing:

|Field|Action|
|---|---|
|``||

## Markdown Toolset

Suggested toolset to view and edit this Markdown file:

- [Visual Studio Code](https://code.visualstudio.com/)
- [Markdown Preview Enhanced](https://marketplace.visualstudio.com/items?itemName=shd101wyy.markdown-preview-enhanced)
- [Markdown PDF](https://marketplace.visualstudio.com/items?itemName=yzane.markdown-pdf)