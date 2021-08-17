using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace NW.WIDJobs.Miscellaneous
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
            => throw new NotImplementedException($"'{nameof(DateTimeToDateConverter)}' doesn't implement  the '{nameof(Read)}' method.");

        public override void Write(Utf8JsonWriter writer, DateTime value, JsonSerializerOptions options)
            => writer.WriteStringValue(value.ToString(DateFormat));

        #endregion

    }
}

/*
    Author: numbworks@gmail.com
    Last Update: 28.05.2021
*/