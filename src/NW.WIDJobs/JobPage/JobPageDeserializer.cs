using System;
using System.Text.Json;
using System.Text.Encodings.Web;

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

            JsonSerializerOptions jso = new JsonSerializerOptions();
            jso.Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping;

            dynamic dyn = JsonSerializer.Deserialize<dynamic>(response, jso);
            ushort totalJobPostings = ushort.Parse(dyn.fields["TotalResultCount"]);

            return totalJobPostings;

        }

        #endregion

    }
}

/*
    Author: numbworks@gmail.com
    Last Update: 25.06.2021
*/