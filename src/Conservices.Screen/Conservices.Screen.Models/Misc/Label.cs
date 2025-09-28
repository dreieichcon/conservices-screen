using System.Text.Json.Serialization;

namespace Conservices.Screen.Models.Misc;

public class Label
{
	[JsonPropertyName("id")]
	public string Id { get; set; }

	[JsonPropertyName("event_id")]
	public string EventId { get; set; }

	[JsonPropertyName("name")]
	public string Name { get; set; }
}