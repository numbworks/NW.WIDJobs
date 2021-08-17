using System;
using System.Text.Json;
using NW.WIDJobs.Validation;

namespace NW.WIDJobs.JobPages
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

        public ushort GetTotalResultCount(string response)
        {

            /*             
                {
                    ...
                    "TotalResultCount": 2265
                } 
            */

            Validator.ValidateStringNullOrWhiteSpace(response, nameof(response));

            using JsonDocument jsonRoot = JsonDocument.Parse(response);
                ushort totalResultCount = jsonRoot.RootElement.GetProperty("TotalResultCount").GetUInt16();

            return totalResultCount;

        }

        #endregion

    }
}

/*
    Author: numbworks@gmail.com
    Last Update: 25.06.2021
*/