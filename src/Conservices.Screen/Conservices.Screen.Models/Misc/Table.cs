using System.Text.Json.Serialization;

namespace Conservices.Screen.Models.Misc;

public class Table
{
	[JsonPropertyName("name")]
	public string Name { get; set; }

	[JsonPropertyName("description")]
	public string Description { get; set; }

	[JsonPropertyName("wheelchair_accessible")]
	public bool Accessible { get; set; }

	[JsonPropertyName("location")]
	public Location Location { get; set; }
}