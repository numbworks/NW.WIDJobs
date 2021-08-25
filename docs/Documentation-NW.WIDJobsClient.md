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

|Root Command|Command|Sub Command|Options|Exit codes|
|---|---|---|---|---|
|widjobs.exe|about|||Success|
|widjobs.exe|demo|||Success|
|widjobs.exe|demo|run||Success|
|widjobs.exe|exploration|||Success|
|widjobs.exe|exploration|showasmetrics|--jsonpath:{path} <br />--aspercentages|Success<br />Failure|
|widjobs.exe|exploration|exportasmetrics|--jsonpath:{path}<br /> --folderpath:{path}<br /> --aspercentages|Success<br />Failure|

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