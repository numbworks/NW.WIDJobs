using System;
using System.Globalization;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace NW.WIDJobs.JsonSerializerConverters
{
    /// <summary>A converter for <see cref="JsonSerializerOptions"/> to serialize <see cref="DateTime"/> to date.</summary>
    public class DateTimeToDateConverter : JsonConverter<DateTime>
    {

        #region Fields
        #endregion

        #region Properties

        public static string DateFormat { get; } = "yyyy-MM-dd";

        #endregion

        #region Constructors

        /// <summary>Initializes a <see cref="DateTimeToDateConverter"/> instance.</summary>
        public DateTimeToDateConverter() { }

        #endregion

        #region Methods_public

        public override DateTime Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {

            string raw = reader.GetString();
            DateTime value = DateTime.ParseExact(raw, DateFormat, CultureInfo.InvariantCulture);

            return value;

        }

        public override void Write(Utf8JsonWriter writer, DateTime value, JsonSerializerOptions options)
            => writer.WriteStringValue(value.ToString(DateFormat));

        #endregion

    }
}

/*
    Author: numbworks@gmail.com
    Last Update: 24.08.2021
*/