using System.Globalization;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Conservices.Screen.Repositories.Serialization;

public class ConservicesDatetimeConverter : JsonConverter<DateTime?>
{
	public override DateTime? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
	{
		var content = reader.GetString();

		if (string.IsNullOrEmpty(content))
			return null;

		content = content.Trim();

		if (DateTime.TryParseExact(content, "yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture, DateTimeStyles.AssumeLocal, out var date))
			return date;
		
		Console.WriteLine($"Could not parse date: {content}");

		return null;
	}

	public override void Write(Utf8JsonWriter writer, DateTime? value, JsonSerializerOptions options)
	{
		throw new NotImplementedException();
	}
}