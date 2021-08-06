using System;
using System.Text.Json;

namespace NW.WIDJobs
{
    /// <inheritdoc cref="IJobPageDeserializer"/>
    public class JobPageDeserializer : IJobPageDeserializer
    {

        #region Fields
        #endregion

        #region Properties
        #endregion

        #region Constructors

        /// <summary>Initializes a <see cref="JobPageDeserializer"/> instance.</summary>
        public JobPageDeserializer() { }

        #endregion

        #region Methods_public

        public ushort GetTotalJobPostings(string response)
        {

            /*             
                {
                    ...
                    "TotalResultCount": 2265
                } 
            */

            Validator.ValidateStringNullOrWhiteSpace(response, nameof(response));

            using JsonDocument jsonRoot = JsonDocument.Parse(response);
                ushort totalJobPostings = jsonRoot.RootElement.GetProperty("TotalResultCount").GetUInt16();

            return totalJobPostings;

        }

        #endregion

    }
}

/*
    Author: numbworks@gmail.com
    Last Update: 25.06.2021
*/