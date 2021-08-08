# NW.WIDJobs
Contact: numbworks@gmail.com

## Revision History

| Date | Author | Description |
|---|---|---|
| 2021-05-08 | numbworks | Created. |

## Introduction

`NW.WIDJobs` is a `.NET Standard 2.0` library written in `C#` to explore `WorkInDenmark.dk` and fetch the most recent job ads published.

# The URLs

The exploration of `WorkInDenmark.dk` starts from an initial page and then it continues for x subsequent pages. The page URLs have have different schema according to given criteria:

|Type|Criteria|Page|Url|
|---|---|---|---|
|Search|`Default`|1|`...`|
|Search|`OrderByCreationDate`|1|`https://job.jobnet.dk/CV/FindWork?Offset=0&SortValue=CreationDate&widk=true`|
|Search|`OrderByCreationDate`|2|`https://job.jobnet.dk/CV/FindWork?Offset=20&SortValue=CreationDate&widk=true`|
|...|...|...|...|

For the scope of this library we do use the the `OrderByCreationDate` variants.

The detail pages for each job have the following URLs instead:

|Type|Criteria|Url|
|---|---|---|
|JobDetails|`Standard`|`https://job.jobnet.dk/CV/FindWork/JobDetailJsonWIDK?id={ID}`|
|JobDetails|`PreviewToken`|`https://job.jobnet.dk/CV/FindWork/JobDetailJsonWIDK?id={ID}&previewtoken=`|
|JobDetails|`Alternative`|`https://job.jobnet.dk/CV/FindWork/DetailsWidk/{ID}`|

For the scope of this library we do use the the `Standard` variant.

## The object model

The three objects that have been identified during the exploration of `WorkInDenmark.dk` are the following ones:

- `JobPage`
- `JobPosting`
- `JobPostingExtended`

The relationship between these objects is summarized in the diagram below:

![Diagram-TheObjectModel](Diagrams/Diagram-TheObjectModel.png)

## The API endpoints

`WorkInDenmark.dk` relies upon an internal API, which has the following endpoints:

|Endpoint|Description|
|---|---|
|`GetJobPage()`|Returns a certain `JobPage`, which corresponds to twenty `JobPostings` (or less, if it's the last one).|
|`GetJobPostingExtended()`|Returns a certain `JobPageExtended`.|

Side note: the names of the API endpoints are arbitrary and adapted to our object model to maximize understanding.

## GetJobPage - The endpoint

**Request:**

|Method|Url|Authentication|Body|
|---|---|---|---|
|`POST`|`https://job.jobnet.dk/CV/FindWork/SearchWIDK`|No|Yes|

**Body:**

This example retrieves the first `JobPage` (which equals to the first twenty `JobPostings`) sorted by `CreationDate`:

```json
{
    "model": {
        "Offset": "0",
        "Count": 20,
        "SearchString": "",
        "SortValue": "CreationDate",
        "Id": [],
        "EarliestPublicationDate": null,
        "HotJob": null,
        "Abroad": null,
        "NearBy": "",
        "OnlyGeoPoints": false,
        "WorkPlaceNotStatic": null,
        "WorkHourMin": null,
        "WorkHourMax": null,
        "Facets": {
            "Region": null,
            "Country": null,
            "Municipality": null,
            "PostalCode": null,
            "OccupationAreas": null,
            "OccupationGroups": null,
            "Occupations": null,
            "EmploymentType": null,
            "WorkHours": null,
            "WorkHourPartTime": null,
            "JobAnnouncementType": null,
            "WorkPlaceNotStatic": null
        },
        "LocatedIn": null,
        "LocationZip": null,
        "Location": null,
        "SearchInGeoDistance": 0
    },
    "url": "/CV/FindWork?Offset=0&SortValue=CreationDate&widk=true"
}
```

The `Count` field accepts only `20` as value. You can change it to whatever value you want, but it will return 20 job postings anyway.

The `Offset` field identifies the starting point and can only be 0 or a number that can be divided by 20:

```json
...
        "Offset": "0",
...
```
```json
...
        "Offset": "20",
...
```

```json
...
        "Offset": "2260",
...
```

**Response:**

```json
{
    "Expression": {
        ...
    },
    "Facets": {
        ...
    },
    "JobPositionPostings": [
        {
            "AutomatchType": 0,
            "Abroad": false,
            "Weight": 1.0,
            "Title": "Demolition",
            "JobHeadline": "Demolition",
            "Presentation": "<p>Xterna is looking for unskilled workers for a demolition project in Denmark. The work is situated in the weekend.</p>\n",
            "HiringOrgName": "Xterna A/S",
            "WorkPlaceAddress": "Fabriksparken 13",
            "WorkPlacePostalCode": "9230",
            "WorkPlaceCity": "Svenstrup J",
            "WorkPlaceOtherAddress": false,
            "WorkPlaceAbroad": false,
            "WorkPlaceNotStatic": false,
            "UseWorkPlaceAddressForJoblog": true,
            "PostingCreated": "2021-06-22T00:00:00",
            "LastDateApplication": "2021-06-25T00:00:00",
            "FormattedLastDateApplication": "25. juni 2021",
            "AssignmentStartDate": "0001-01-01T00:00:00",
            "IsHotjob": false,
            "IsExternal": false,
            "Url": "https://job.jobnet.dk/CV/FindWork/Details/5374939",
            "Region": "Nordjylland",
            "Municipality": "Aalborg",
            "Country": "Danmark",
            "PostalCode": "9230",
            "PostalCodeName": null,
            "JobAnnouncementType": "",
            "EmploymentType": "",
            "WorkHours": "Deltid",
            "OccupationArea": "",
            "OccupationGroup": "",
            "Occupation": "Specialarbejder, byggeri",
            "Location": {
                "Latitude": 56.9811,
                "Longitude": 9.8538
            },
            "JoblogWorkTime": {
                "WorkHour": "(34 - 36 timer ugentligt)",
                "DailyWorkTime": "Aften, nat, weekend"
            },
            "WorkplaceID": 119356,
            "OrganisationId": "105966",
            "HiringOrgCVR": 37800902,
            "UserLoggedIn": false,
            "AnonymousEmployer": false,
            "ShareUrl": "https://job.jobnet.dk/CV/FindWork/DetailsSocialmedia/5374939",
            "DetailsUrl": "https://job.jobnet.dk/CV/FindWork/Details/5374939",
            "JobLogUrl": "https://job.jobnet.dk/CV/FindWork/Details/5374939",
            "HasLocationValues": true,
            "ID": "5374939",
            "Latitude": 56.9811,
            "Longitude": 9.8538
        },
        ...       
        {
            ...
            "IsExternal": true,
            "Url": "https://jobs.danfoss.com/job/Nordborg-Ufaglærte-produktionsmedarbejdere-til-maleområde/730219002/",
            ...
            "ID": "E8232793",
            ...
        },
    ...
    ],
    "TotalResultCount": 2265
}
```
## GetJobPage - The TotalResultCount value 

|Type|Field|ExampleValue|Action|
|---|---|---|---|
|`Mandatory`|`TotalResultCount`|2265|Parse to `uint16`.|

## GetJobPage - The JobPage object

The following fields will be extracted from the response:

|Type|Field|Description|
|---|---|---|
|`Mandatory`|`Response`|In JSON format.|

The following fields are provided or derivative:

|Type|Field|Description|
|---|---|---|
|`Mandatory`|`RunId`||
|`Mandatory`|`PageNumber`||

## GetJobPage - The JobPosting object

The following fields will be extracted from the response:

|Type|Field|ExampleValue|
|---|---|---|
|`Mandatory`|`Response`|In JSON format.|
|`Mandatory`|`Title`|"Demolition"|
|`Optional`|`Presentation`|"Xterna is looking for..."|
|`Mandatory`|`HiringOrgName`|"Xterna A/S"|
|`Optional`|`WorkPlaceAddress`|"Fabriksparken 13" or ""|
|`Optional`|`WorkPlacePostalCode`|"9230"|
|`Optional`|`WorkPlaceCity`|"Svenstrup J"|
|`Mandatory`|`PostingCreated`|"2021-06-22T00:00:00"|
|`Mandatory`|`LastDateApplication`|"2021-06-25T00:00:00"|
|`Mandatory`|`Url`|"https://job.jobnet.dk/CV/FindWork/Details/5374939" or "https://jobs.danfoss.com/job//730219002/"|
|`Optional`|`Region`|"Nordjylland"|
|`Optional`|`Municipality`|"Aalborg"|
|`Optional`|`Country`|"Danmark"|
|`Optional`|`EmploymentType`|"Fastansættelse" or ""|
|`Mandatory`|`WorkHours`|"Fuldtid" or "Deltid"|
|`Optional`|`Occupation`|"Specialarbejder, byggeri"|
|`Mandatory`|`WorkplaceID`|119356|
|`Optional`|`OrganisationId`|"105966"|
|`Mandatory`|`HiringOrgCVR`|37800902|
|`Mandatory`|`ID`|"5374939" or "E8232793"|Remove "E" when needed and parse to integer.|

The following fields are derivative:

|Field|Description|
|---|---|
|`WorkPlaceCityWithoutZone`|`WorkPlaceCity` without zone or `WorkPlaceCity`.|
|`JobPostingNumber`|Equals to the item's position in the list starting from 1.|
|`JobPostingId`|`ID` and `Title` combined. If `Title` is longer than five words, only the first five words are used.|

The following fields require extra processing:

|Field|Action|
|---|---|
|`WorkPlacePostalCode`|Parse it to `uint16` or `null`.|
|`PostingCreated`|Parse it to `DateTime`.|
|`LastDateApplication`|Parse it to `DateTime`.|
|`WorkplaceID`|Parse it to `uint64`.|
|`OrganisationId`|Parse it to `uint64` or `null`.|
|`HiringOrgCVR`|Parse it to `uint64`.|
|`ID`|Remove "E" (when required) and parse it to `uint64`.|

The `WorkPlaceCityWithoutZone` field is required, because in many cases `WorkPlaceCity` comes with the "zone" suffix by default, which could limit further data processing activities on the `JobPosting` objects such as grouping. Here some of the most common cases:

|WorkPlaceCity|WorkPlaceCityWithoutZone|
|---|---|
|København K|København|
|Kgs. Lyngby|Kgs. Lyngby|
|København V|København|
|København Ø|København|
|København S|København|
|Aarhus C|Aarhus|
|Viby J|Viby|
|Odense S|Odense|
|Kongens Lyngby|Kongens Lyngby|
|Billund|Billund|
|København SV|København|
|Esbjerg V|Esbjerg|
|Odense SØ|Odense|
|Lem St|Lem|

## GetJobPostingExtended - The endpoint

**Request:**

|Method|Url|Authentication|Body|
|---|---|---|---|
|`GET`|`https://job.jobnet.dk/CV/FindWork/JobDetailJsonWIDK?id={ID}`|No|No|

**Response:**

```json
{
    ...
    "JobPositionPosting": {
        ...
        "HiringOrg": {
            ...
            "Description": "Xterna har profiler indenfor flere fagområder. Det er vigtigt for Xterna, at vores kunder får de medarbejdere, der har de bedste kvalifikationer til lige netop den opgave, der søges løst. \nVi har bemanding inden for, og rekrutterer kvalificeret arbejdskraft til, bygge-, anlæg og industr",
            ...
        },
        ...
        "PublicationStartDate": "2021-06-22T00:00:00",
        "PublicationEndDate": "2021-06-25T00:00:00",
        "JobPositionInformation": {
            ...
            "Purpose": "<p>Xterna is looking for unskilled workers for a demolition project in Denmark. The work is situated in the weekend.</p>\n<p>If you have&nbsp;experience with light weight handtools and working in conctruction, then this job for you. You are going to be a part of a large, well-established company.</p>\n<p>Start-up the 16.07.21.</p>\n<p><strong>Tasks:</strong></p>\n<p>Hard physical labor&nbsp;for decomposition of buildings.</p>\n<p><strong>Qualifications: </strong></p>\n<p>- Used to work on building site</p>\n<p>- Used to use handtools</p>\n<p>- You have a great commitment and can take responsibility</p>\n<p>- You are conscientious with good collaboration skills</p>\n<p><strong>You as a person: </strong></p>\n<p>You are a positive fire soul with an energy that spreads to the tasks and people around you. You work proactively and see opportunities rather than limitations. You also work independently with a good overview and take great ownership of your tasks. You possess good communication skills and work team-oriented. You are also quality-conscious and emphasize orderliness in the execution of your work. You are structured and know how to prioritize your tasks according to set goals.</p>\n<p><strong>We offer:</strong></p>\n<p>In addition to orderly pay and working conditions, where you receive the same salary and terms as the company's own employees, you also get the opportunity to join one of our attractive employee schemes. We want to attract the best candidates and offer several different attractive add-on and bonus programs.</p>\n<p><strong>Application: </strong></p>\n<p>To apply for this position, send your application and your CV to ansoegning@xterna.dk and mark it with \"Electrician - Aarhus North\" Applications are processed on an ongoing basis - and the positions may be filled before expiration. If you have further questions, you are welcome to contact us on tel .: 72 301 302</p>",
            ...
            "NumberToFill": 10,
            ...
            "JppContacts": [
                {
                    ...
                    "Email": "cf@xterna.dk",
                    ...
                    "PersonName": "Christian Frydenlund",
                    ...
                }
            ],
            "EmploymentDate": "2021-07-16T00:00:00"
        },
        ...
        "ApplicationDetails": {
            ...
            "ApplicationDeadlineDate": "2021-06-25T00:00:00"
        },
        ...
    },
    ...
}
```

## GetJobPostingExtended - The JobPostingExtended object

The following fields will be extracted from the response:

|Type|Field|ExampleValue|
|---|---|---|
|`Mandatory`|`Response`|In JSON format (when internal URL) or in HTML format (when external URL).|
|`Optional`|`HiringOrgDescription`|"Xterna har profiler indenfor..."|
|`Optional`|`PublicationStartDate`|"2021-06-22T00:00:00"|
|`Optional`|`PublicationEndDate`|"2021-06-25T00:00:00"|
|`Optional`|`Purpose`|"Xterna is looking for..."|
|`Optional`|`NumberToFill`|10|
|`Optional`|`ContactEmail`|"cf@xterna.dk"|
|`Optional`|`ContactPersonName`|"Christian Frydenlund"|
|`Optional`|`EmploymentDate`|"2021-07-16T00:00:00"|
|`Optional`|`ApplicationDeadlineDate`|"2021-06-25T00:00:00"|

The following fields are derivative:

|Field|Description|
|---|---|
|`BulletPoints`|If the `Response` is in JSON format, these are tentatively extracted from the `Purpose` field. If the `Response` is in HTML format instead, the `Response` itself is used.|
|`BulletPointScenario`|A label that specifies how the `BulletPoints` have been extracted.|

The following fields require extra processing:

|Field|Action|
|---|---|
|`PublicationStartDate`|Parse it to `DateTime` or `null`.|
|`PublicationEndDate`|Parse it to `DateTime` or `null`.|
|`Purpose`|Run it thru Html decoding.|
|`NumberToFill`|Parse it to `uint16` or `null`.|
|`EmploymentDate`|Parse it to `DateTime` or `null`.|
|`ApplicationDeadlineDate`|Parse it to `DateTime` or `null`.|

## GetJobPostingExtended - Extracting Bullet Points via XPath

This approach works on both `Purpose` (internal URLs) and `Response` (external URLs). 

Considering that the external URLs could have endless different layouts, we do provide one XPath pattern for each of the most recurrent scenarios:

|#|Scenario|Pattern|
|---|---|---|
|1|novonordisk|`//ul/li/span/span/span/span`|

```html
...
<p>
  <span>
    <span>
      <span>
        <b>
          <span>Qualifications</span></b></span></span></span></p>
<ul>
  <li>
    <span>
      <span>
        <span>
          <span>The most important in this job is your personality. We
            weigh discretion highly and the importance of our customers
            getting a professional service when they are welcomed by you
            at our receptions.</span></span></span></span></li>
...
```

|#|Scenario|Pattern|
|---|---|---|
|2|jobportal|`//div[@class='vacancy_details_area']/ul/li`|

```html
...
    <div class="vacancy_details_area">
	...
<ul>
	<li>Field-based ecosystem manipulations experiments and monitoring of greenhouse gas production</li>
	<li>Measurements of subsurface and snow gas concentrations, diffusion and greenhouse gas fluxes</li>
	<li>Process-based models to simulate changes in climate-soil-plant-microbial characteristics</li>
	<li>Structural equation modelling</li>
</ul>	
...
```

|#|Scenario|Pattern|
|---|---|---|
|3|easycruit|`//div[@class='jd-description']/ul/li`|

```html
...
<div class="jd-description">
			...
			<ul><li>Subject matter expert with responsibility for planning, advising on, coordinating, and handling public disclosure of clinical trial information.</li>
			...
...
```

|#|Scenario|Pattern|
|---|---|---|
|4|coloplast|`//span[@class='jobdescription']/ul/li`|

```html
...
<span class="jobdescription">
...
	<ul>
		<li>Set a clear direction for sales capabilities within the Consumer channel, ensure that we have the right toolbox in place for in- and outbound calls and that these align with HQ requirements</li>
		<li>Ensure that we locally have the tools necessary to give our customers get the highest level of quality in terms of service and sales </li>
		<li>Work with stakeholders to identify training needs and opportunities and determine what areas should be included in training modules </li>
		<li>Motivate and develop consumer care managers </li>
	</ul>
...
```

|#|Scenario|Pattern|
|---|---|---|
|5|randstad|`//p[starts-with(., '-') and .//br]/text()`|

```html
...
<p>- Picking/packing tasks<br />- Loading/unloading tasks<br />- Receipt of goods<br />-
    Truck driving, most often reach truck<br />- Scanner operation<br />- Various warehouse tasks<br /><br />
...
```

|#|Scenario|Pattern|
|---|---|---|
|6|keepit|`//p[starts-with(., '-')]`|

```html
...
\n<p><strong>The types of technical challenges that you will be solving with your team could
        be:</strong></p>\n<p>-       Performance troubleshooting - if a service is not performing as expected,
    troubleshooting the process interactions on a live server in order to identify the root cause and propose a remedy,
    possibly in collaboration with the development team.</p>\n<p>-       Planning, testing, and executing Postgres
    database cluster migration from an older version to a newer version with little or no user-visible interruptions.
</p>\n<p>-       Designing the next iteration ...
...
```

As last resort, a generic one is also available:

|#|Scenario|Pattern|
|---|---|---|
|7|generic|`//ul/li|//ol/li`|

## GetJobPostingExtended - Extracting Bullet Points via regex

This is mainly intended for the `Purpose` field:

|Pattern|Description|
|---|---|
|`(?<=-\\t)[\w ]{1,}(?=-\\t)`|The latest bullet point migth lost.|

## GetJobPostingExtended - Cleaning extracted Bullet Points

The following self-explanatory cleaning actions are applied on the extracted bullet points:

|Field|Action|
|---|---|
|`BulletPoints`|`RemoveNewLines()`.|
|`BulletPoints`|`RemoveExtraWhiteSpaces()`.|
|`BulletPoints`|`RemoveInitialHyphen()`.|
|`BulletPoints`|`FixNonBreakingSpaceCharacters()`.|

## The data model

`WIDExplorer` allows to export data into a SQLite database thru the `ToSQLite()` method. 

The data model of this database is the following one:

![Diagram-WIDJobsDataModel](Diagrams/Diagram-WIDJobsDataModel.png)

## Appendix - The TotalResultCount value via XPath

```html
...
<span data-ng-show="resultCount >= 0" aria-live="polite" class="ng-binding" aria-hidden="false" style="">2265 Job postings<span class="sr-only">&nbsp;matches your search criteria</span></span>
...
```

|Type|Field|Pattern|
|---|---|---|
|`Mandatory`|`TotalJobPostings`|`//*[@id="ResultToolbar"]/div[1]/h2/span[1]/text()'|

|Field|Action|
|---|---|
|`TotalJobPostings`|Requires removal of " Job postings".|

## Markdown Toolset

Suggested toolset to view and edit this Markdown file:

- [Visual Studio Code](https://code.visualstudio.com/)
- [Markdown Preview Enhanced](https://marketplace.visualstudio.com/items?itemName=shd101wyy.markdown-preview-enhanced)
- [Markdown PDF](https://marketplace.visualstudio.com/items?itemName=yzane.markdown-pdf)