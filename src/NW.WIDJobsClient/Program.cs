using System;
using NW.WIDJobs.JobPostings;
using NW.WIDJobs.JobPostingsExtended;
using NW.WIDJobsClient.CommandLine;

namespace NW.WIDJobsClient
{
    class Program
    {

        static int Main(string[] args)
        {

			JobPosting jobPosting
				= new JobPosting(
						runId: "ID:20210909191436674|FROM:1|TO:4",
						pageNumber: 1,
						response: "some response",
						title: "PhD fellowship in RASOPTA",
						presentation: "<br> A 3-year PhD fellowship is available at Centre for Diagnostics, DTU Health Technology, DTU, Lyngby, Denmark, with an expected start January 1st 2022. <br><br> The fellowship is funded by th",
						hiringOrgName: "Danmarks Tekniske Universitet",
						workPlaceAddress: "Anker Engelunds Vej 101",
						workPlacePostalCode: 2800,
						workPlaceCity: "Kongens Lyngby",
						postingCreated: new DateTime(2021, 09, 09),
						lastDateApplication: new DateTime(2021, 09, 15),
						url: "https://job.jobnet.dk/CV/FindWork/Details/5424719",
						region: "Hovedstaden og Bornholm",
						municipality: "Gladsaxe",
						country: "Danmark",
						employmentType: null,
						workHours: "Fuldtid",
						occupation: "PhD, science and engineering",
						workplaceId: 83955,
						organisationId: 66175,
						hiringOrgCVR: 30060946,
						id: 5424719,
						workPlaceCityWithoutZone: "Kongens Lyngby",
						jobPostingNumber: 1,
						jobPostingId: "5424719phdfellowshipinrasopta"
					);

			JobPostingExtendedManager jobPostingExtendedManager = new JobPostingExtendedManager();
			JobPostingExtended jobPostingExtended = jobPostingExtendedManager.GetJobPostingExtended(jobPosting);

			return 0;

        }

    }

}

/*
    Author: numbworks@gmail.com
    Last Update: 31.08.2021
*/