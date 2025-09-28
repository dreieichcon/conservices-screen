using System.Text.Json;
using System.Text.Json.Serialization;

namespace Conservices.Screen.Repositories.Serialization;

public class ConservicesBoolConverter : JsonConverter<bool>
{
	public override bool Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
	{
		var text = reader.GetInt32().ToString();

		var parsed = text switch
		{
			"1" or "yes" or "true" => true,
			"0" or "no" or "false" => false,
			"" => false,
		};
		
		return parsed;
	}

	public override void Write(Utf8JsonWriter writer, bool value, JsonSerializerOptions options)
	{
		throw new NotImplementedException();
	}
}