using System.Text.Json.Serialization;

namespace Conservices.Screen.Models.Misc;

public class Location
{
	[JsonPropertyName("table")]
	public required string Table { get; set; }

	[JsonPropertyName("room")]
	public required string Room { get; set; }

	[JsonPropertyName("building")]
	public required string Building { get; set; }
}