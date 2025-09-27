using System.Reflection;
using System.Text.Json.Serialization;
using JetBrains.Annotations;

namespace Conservices.Screen.Models.Convention;

public class Convention
{
	[JsonPropertyName("id")]
	[UsedImplicitly]
	public required string Id { get; set; }

	[JsonPropertyName("name")]
	public required string Name { get; set; }

	[JsonPropertyName("begin")]
	public string ConventionStart { get; set; }

	[JsonPropertyName("end")]
	public string ConventionEnd { get; set; }

	[JsonPropertyName("public")]
	public int IsPublic { get; set; }

	[JsonPropertyName("publish_begin")]
	public string publish_begin { get; set; }

	[JsonPropertyName("publish_end")]
	public string publish_end { get; set; }

	[JsonPropertyName("application_begin")]
	public string application_begin { get; set; }

	[JsonPropertyName("application_end")]
	public string application_end { get; set; }

	[JsonPropertyName("join_begin")]
	public string join_begin { get; set; }

	[JsonPropertyName("join_end")]
	public string join_end { get; set; }

	[JsonPropertyName("homepage")]
	public string homepage { get; set; }

	[JsonPropertyName("terms")]
	public string terms { get; set; }

	[JsonPropertyName("discord")]
	public string discord { get; set; }

	[JsonPropertyName("description")]
	public string description { get; set; }

	[JsonPropertyName("description_application")]
	public object description_application { get; set; }

	[JsonPropertyName("logo")]
	public string logo { get; set; }

	[JsonPropertyName("invoice_prefix")]
	public object invoice_prefix { get; set; }

	[JsonPropertyName("pretix_gamemaster_ticket")]
	public object pretix_gamemaster_ticket { get; set; }

	[JsonPropertyName("map_url")]
	public object map_url { get; set; }

	[JsonPropertyName("description_application_game")]
	public string description_application_game { get; set; }

	[JsonPropertyName("description_application_exhibitor")]
	public string description_application_exhibitor { get; set; }

	[JsonPropertyName("description_application_programm")]
	public string description_application_programm { get; set; }

	[JsonPropertyName("event_series")]
	public ConventionSeries ConventionSeries { get; set; }

	[JsonPropertyName("module")]
	public IList<ConventionModule> ConventionModules { get; set; } = [];
}