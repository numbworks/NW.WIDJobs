# NW.WIDJobs

| <sub>Library</sub> | <sub>Client</sub> |
|---|---|
|![codecoverage_library.svg](codecoverage_library.svg)|![codecoverage_client.svg](codecoverage_client.svg)|

Contact: numbworks@gmail.com

## Revision History

| Date | Author | Description |
|---|---|---|
| 2021-09-26 | numbworks | Created. |

## In Short

From the documentation:

> `NW.WIDJobs` is a `.NET Standard` library written in C# to explore `WorkInDenmark.dk` and fetch the most recent job ads. It enriches the original data model by using machine learning techniques, and it's designed with data analysis and data science tasks in mind.

> `NW.WIDJobsClient` (`widjobs.exe`) is an unofficial command-line client for `WorkInDenmark.dk`, based on the `NW.WIDJobs` library and written in in C# (`.NET Core`).

## Download the source code

I assume you are on `Windows`, but the library should compile without issues on `Linux` as well. Please:

1. Install [Git for Windows](https://git-scm.com/download/win);
2. Open `Windows Powershell` (or `Windows Terminal` or similar) and type:

```powershell
PS C:\> mkdir NW.WIDJobs
PS C:\> cd .\NW.WIDJobs\
PS C:\NW.WIDJobs> git clone https://github.com/numbworks/NW.WIDJobs.git
```

3. Open `NW.WIDJobs.sln` with `Visual Studio` or other IDE;
4. Done!

## Download the library's binary package

If you are a .NET developer and you want to use the library from within your projects, the binary packages are available on [NuGet](https://www.nuget.org/packages/NW.WIDJobs/).

## Download the client's binary package

If you are an non-developer user, you can download the client from GitHub packages.

## Getting Started

- [Documentation: Library](docs/Documentation-NW.WIDJobs.md)
- [Documentation: Client](docs/Documentation-NW.WIDJobsClient.md)

## Other Links

- [LICENSE](LICENSE)