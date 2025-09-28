using System.Text.Json.Serialization;

namespace Conservices.Screen.Models.Program;

public class Host
{
	[JsonPropertyName("name")]
	public required string Name { get; set; }

	[JsonPropertyName("gdpr")]
	public string Gdpr { get; set; } = string.Empty;

	[JsonPropertyName("imprint")]
	public string Imprint { get; set; } = string.Empty;

	[JsonPropertyName("sold_products")]
	public string ProductsSold { get; set; } = string.Empty;
}