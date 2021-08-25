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
|demo|||Success|
|demo|run||Success|
|exploration|||Success|
|exploration|showasmetrics|--jsonpath:{path} <br />*--aspercentages*|Success<br />Failure|
|exploration|saveasmetrics|--jsonpath:{path}<br />--folderpath:{path} <br />*--aspercentages*|Success<br />Failure|
|exploration|saveasdatabase|--jsonpath:{path}<br />--folderpath:{path}|Success<br />Failure|
|exploration|describe|--output:{jsonfile\|console\|all}<br />*--folderpath:{path}*|Success<br />Failure|
|exploration|explore|--stage:{2\|3}<br />--thresholdtype:{pagenumber\|date\|jobpostingid}<br />--threshold:{pagenumber}\|{date}\|{jobpostingid}<br />--explorationoutput:{database\|jsonfile\|console\|all}<br />*--folderpath:{path}*<br />*--metrics*<br />*--metricsoutput:{jsonfile\|console\|all}*<br />*--parallelrequests*<br />*--pausebetweenrequestsms*|Success<br />Failure|

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