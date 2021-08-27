# NW.WIDJobsClient
Contact: numbworks@gmail.com

## Revision History

| Date | Author | Description |
|---|---|---|
| 2021-05-08 | numbworks | Created. |

## Introduction

`NW.WIDJobsClient` is an unofficial command-line client for `WorkInDenmark.dk`, based on the `NW.WIDJobs` library.

# The CLI

The command-line interface for of `NW.WIDJobsClient`:

|Command|Sub Command|Options|Exit Codes|
|---|---|---|---|
|about|||Success|
|exploration|||Success|
|exploration|calculate|--jsonpath:{path}<br />--output:{jsonfile\|console\|both}<br />*--folderpath:{path}*<br />*--aspercentages*|Success<br />Failure|
|exploration|convert|--jsonpath:{path}<br />--output:{databasefile}<br />--folderpath:{path}|Success<br />Failure|
|exploration|describe|--output:{jsonfile\|console\|both}<br />*--folderpath:{path}*<br />*--usedemodata*|Success<br />Failure|
|exploration|explore|--stage:{S2\|S3}<br />--thresholdtype:{pagenumber\|date\|jobpostingid}<br />--thresholdvalue:{pagenumber}\|{date}\|{jobpostingid}<br />--output:{databasefile\|jsonfile\|console\|all}<br />*--folderpath:{path}*<br />*--metrics*<br />*--metricsoutput:{jsonfile\|console\|both}*<br />*--aspercentages*<br />*--parallelrequests:{number}*<br />*--pausebetweenrequestsms:{number}*<br />*--usedemodata*|Success<br />Failure|


|Command|Sub Command|Options|Exit Codes|
|---|---|---|---|
|||||

# Exit codes

Here the exit codes:

|Label|Value|
|---|---|
|Success|0|
|Failure|1|


## Markdown Toolset

Suggested toolset to view and edit this Markdown file:

- [Visual Studio Code](https://code.visualstudio.com/)
- [Markdown Preview Enhanced](https://marketplace.visualstudio.com/items?itemName=shd101wyy.markdown-preview-enhanced)
- [Markdown PDF](https://marketplace.visualstudio.com/items?itemName=yzane.markdown-pdf)