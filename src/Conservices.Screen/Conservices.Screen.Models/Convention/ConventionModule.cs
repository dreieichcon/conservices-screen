using System.Text.Json.Serialization;

namespace Conservices.Screen.Models.Convention;

public class ConventionModule
{
	[JsonPropertyName("id")]
	public int id { get; set; }

	[JsonPropertyName("name")]
	public string name { get; set; }

	[JsonPropertyName("public")]
	public int IsPublic { get; set; }
}