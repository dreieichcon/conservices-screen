using System.Reflection;
using System.Text.Json.Serialization;
using JetBrains.Annotations;

namespace Conservices.Screen.Models.Convention;

[UsedImplicitly]
public class ConventionSeries
{
	[JsonPropertyName("id")]
	public string id { get; set; }

	[JsonPropertyName("name")]
	public string name { get; set; }
}