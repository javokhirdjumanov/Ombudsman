using System.Text.Json;
using System.Text.Json.Serialization;

namespace ServiceLayer.ConverterFormat
{
    public class DateOnlyConverter : JsonConverter<DateOnly>
    {
        public override DateOnly Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            string dateString = reader.GetString();
            if (DateTime.TryParse(dateString, out DateTime dateTime))
            {
                return new DateOnly(dateTime.Year, dateTime.Month, dateTime.Day);
            }

            throw new JsonException($"Unable to parse '{dateString}' as DateOnly.");
        }

        public override void Write(Utf8JsonWriter writer, DateOnly value, JsonSerializerOptions options)
        {
            writer.WriteStringValue(value.ToString());
        }
    }
}
