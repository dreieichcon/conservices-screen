using System.Text.Json.Serialization;
using Conservices.Screen.Models.Misc;

namespace Conservices.Screen.Models.Program;

public class ProgramItem
{
	[JsonPropertyName("id")]
	public required string Id { get; set; }

	[JsonPropertyName("event_id")]
	public required string EventId { get; set; }

	[JsonPropertyName("accepted")]
	public bool Accepted { get; set; }

	[JsonPropertyName("title")]
	public string Title { get; set; } = string.Empty;

	[JsonPropertyName("teaser")]
	public string Teaser { get; set; } = string.Empty;

	[JsonPropertyName("content_note")]
	public string ContentNote { get; set; } = string.Empty;

	[JsonPropertyName("alias_host")]
	public object HostAlias { get; set; } = string.Empty;

	[JsonPropertyName("start")]
	public DateTime Start { get; set; }

	[JsonPropertyName("duration")]
	public TimeSpan Duration { get; set; }

	[JsonPropertyName("age_min")]
	public int MinimumAge { get; set; }

	[JsonPropertyName("age_max")]
	public int? MaximumAge { get; set; }

	[JsonPropertyName("visitor_min")]
	public int? MinimumVisitors { get; set; }

	[JsonPropertyName("visitor_max")]
	public int? MaximumVisitors { get; set; }

	[JsonPropertyName("visitor_estimated")]
	public int? EstimatedVisitors { get; set; }

	[JsonPropertyName("host")]
	public Host? Host { get; set; }

	[JsonPropertyName("table")]
	public IList<Table> Tables { get; set; } = [];
	
	[JsonPropertyName("label")]
	public IList<Label> Labels { get; set; } = [];
	public Table? Table => Tables.FirstOrDefault();
	
	public Label? Label => Labels.FirstOrDefault();
}