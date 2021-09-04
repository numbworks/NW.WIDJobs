# NW.WIDJobsClient
Contact: numbworks@gmail.com

## Revision History

| Date | Author | Description |
|---|---|---|
| 2021-05-08 | numbworks | Created. |

## Introduction

`NW.WIDJobsClient` (`widjobs.exe`) is an unofficial command-line client for `WorkInDenmark.dk`, based on the `NW.WIDJobs` library and written in in C# (`.NET Core`).

## The CLI

The command-line interface for `NW.WIDJobsClient` is summarized in the following table:

|Command|Sub Command|Options|Exit Codes|
|---|---|---|---|
|about|||Success|
|session|||Success|
|session|calculate|--jsonpath:{path}<br />--output:{jsonfile\|console\|both}<br />*--folderpath:{path}*<br />*--aspercentages*|Success<br />Failure|
|session|convert|--jsonpath:{path}<br />--output:{databasefile}<br />*--folderpath:{path}*|Success<br />Failure|
|session|describe|--output:{jsonfile\|console\|both}<br />*--folderpath:{path}*<br />*--verboseserialization*<br />*--usedemodata*|Success<br />Failure|
|session|explore|--stage:{S2\|S3}<br />--thresholdtype:{finalpagenumber\|thresholddate\|jobpostingid}<br />--thresholdvalue:{finalpagenumber}\|{thresholddate}\|{jobpostingid}<br />--explorationoutput:{databasefile\|jsonfile\|console\|onlyfiles\|all}<br />*--folderpath:{path}*<br />*--verboseserialization*<br />*--metricsoutput:{jsonfile\|console\|both\|none}*<br />*--aspercentages*<br />*--parallelrequests:{number}*<br />*--pausebetweenrequestsms:{number}*<br />*--usedemodata*|Success<br />Failure|
|service|||Success|
|service|explore|...|Success<br />Failure|
|extra|||Success|
|extra|prelabeledbulletpoints|--output:{jsonfile\|console\|both}<br />*--folderpath:{path}*|Success<br />Failure|

The regular font indicates the mandatory options, while the *italic*  font indicates an optional ones.

The exit codes are summarized below:

|Label|Value|
|---|---|
|Success|0|
|Failure|1|

## Getting started

Once you downloaded the application, open a command prompt (such as Windows Terminal) and navigate to the application folder.

The following commands will provide information about each `Command`, `Sub Command` and `Option`:

```powershell
PS C:\widjobs>.\widjobs.exe
PS C:\widjobs>.\widjobs.exe session
PS C:\widjobs>.\widjobs.exe session calculate --help
PS C:\widjobs>.\widjobs.exe session convert --help
PS C:\widjobs>.\widjobs.exe session describe --help
PS C:\widjobs>.\widjobs.exe session explore --help
PS C:\widjobs>.\widjobs.exe service
PS C:\widjobs>.\widjobs.exe extra
PS C:\widjobs>.\widjobs.exe extra prelabeledbulletpoints --help
```
The following command will provide some essential information about the application itself:

```powershell
PS C:\widjobs>.\widjobs.exe about
```

...

## Markdown Toolset

Suggested toolset to view and edit this Markdown file:

- [Visual Studio Code](https://code.visualstudio.com/)
- [Markdown Preview Enhanced](https://marketplace.visualstudio.com/items?itemName=shd101wyy.markdown-preview-enhanced)
- [Markdown PDF](https://marketplace.visualstudio.com/items?itemName=yzane.markdown-pdf)