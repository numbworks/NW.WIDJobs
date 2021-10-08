using System.Collections.Generic;

namespace NW.WIDJobs.UnitTests
{
    public class FakeLogger
    {

        #region Fields
        #endregion

        #region Properties

        public List<string> Messages { get; }

        #endregion

        #region Constructors

        public FakeLogger()
        {

            Messages = new List<string>();

        }

        #endregion

        #region Methods_public

        public void Log(string message)
            => Messages.Add(message);

        #endregion

    }
}

/*
    Author: numbworks@gmail.com
    Last Update: 08.10.2021
*/