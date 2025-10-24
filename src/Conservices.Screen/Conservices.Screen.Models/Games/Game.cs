using System.Text.Json.Serialization;
using Conservices.Screen.Models.Interfaces;
using Conservices.Screen.Models.Misc;

namespace Conservices.Screen.Models.Games;

// ReSharper disable UnusedAutoPropertyAccessor.Global
public class Game : IHasStartTime
{
	[JsonPropertyName("id")]
	public required string Id { get; set; }

	[JsonPropertyName("event_id")]
	public required string EventId { get; set; }

	[JsonPropertyName("title")]
	public required string Title { get; set; }

	[JsonPropertyName("system")]
	public string System { get; set; } = string.Empty;

	[JsonPropertyName("system_version")]
	public object SystemVersion { get; set; } = string.Empty;

	[JsonPropertyName("chars")]
	public string Characters { get; set; } = string.Empty;

	[JsonPropertyName("content_note")]
	public string? ContentNote { get; set; }

	[JsonPropertyName("teaser")]
	public string Teaser { get; set; } = string.Empty;

	[JsonPropertyName("alias_game_master")]
	public string? AliasGameMaster { get; set; } = string.Empty;

	[JsonPropertyName("duration")]
	public TimeSpan Duration { get; set; }

	[JsonPropertyName("player_min")]
	public int PlayerMin { get; set; }

	[JsonPropertyName("player_max")]
	public int PlayerMax { get; set; }

	[JsonPropertyName("age_min")]
	public int AgeMin { get; set; }

	[JsonPropertyName("age_max")]
	public int? AgeMax { get; set; }

	[JsonPropertyName("game_master")]
	public required GameMaster GameMaster { get; set; }

	[JsonPropertyName("start_timestamp")]
	public int StartTimestamp { get; set; }
	
	[JsonIgnore]
	public DateTime Start
	{
		get => DateTimeOffset.FromUnixTimeSeconds(StartTimestamp)
			.UtcDateTime;
		set => _ = value;
	}

	public DateTime? End => Start + Duration;

	[JsonPropertyName("player")]
	public IList<Player> Players { get; set; } = [];

	[JsonPropertyName("label")]
	public IList<Label> Labels { get; set; } = [];

	[JsonPropertyName("table")]
	public IList<Table> Tables { get; set; } = [];
}