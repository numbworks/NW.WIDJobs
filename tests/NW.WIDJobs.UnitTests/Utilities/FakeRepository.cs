using NW.WIDJobs.Database;
using NW.WIDJobs.JobPostings;
using NW.WIDJobs.JobPostingsExtended;
using System.Collections.Generic;

namespace NW.WIDJobs.UnitTests
{
    public class FakeRepository : IRepository
    {

        #region Fields

        #endregion

        #region Properties

        public string DatabaseFilePath { get; }
        public int AffectedRows { get; }

        #endregion

        #region Constructors

        public FakeRepository(string databaseFilePath, int affectedRows) 
        {

            DatabaseFilePath = databaseFilePath;
            AffectedRows = affectedRows;

        }

        #endregion

        #region Methods_public

        public int ConditionallyInsert(JobPosting jobPosting) => AffectedRows;
        public int ConditionallyInsert(List<JobPosting> jobPostings) => AffectedRows;
        public int ConditionallyInsert(JobPostingExtended jobPostingExtended) => AffectedRows;
        public int ConditionallyInsert(List<JobPostingExtended> jobPostingsExtended) => AffectedRows;

        #endregion

        #region Methods_private

        #endregion

    }
}

/*
    Author: numbworks@gmail.com
    Last Update: 18.08.2021
*/