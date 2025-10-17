using System.Text.Json.Serialization;
using JetBrains.Annotations;

namespace Conservices.Screen.Models.Sun;

[UsedImplicitly]
public class SunState
{
	[JsonPropertyName("date")]
	public DateOnly Date { get; set; }

	[JsonPropertyName("sunrise")]
	public TimeOnly Sunrise { get; set; }

	[JsonPropertyName("sunset")]
	public TimeOnly Sunset { get; set; }

	[JsonPropertyName("first_light")]
	public TimeOnly FirstLight { get; set; }

	[JsonPropertyName("last_light")]
	public TimeOnly LastLight { get; set; }

	[JsonPropertyName("dawn")]
	public TimeOnly Dawn { get; set; }

	[JsonPropertyName("dusk")]
	public TimeOnly Dusk { get; set; }

	[JsonPropertyName("solar_noon")]
	public TimeOnly SolarNoon { get; set; }

	[JsonPropertyName("golden_hour")]
	public TimeOnly GoldenHour { get; set; }

	[JsonPropertyName("day_length")]
	public TimeSpan DayLength { get; set; }

	[JsonPropertyName("timezone")]
	public string Timezone { get; set; } = string.Empty;

	[JsonPropertyName("utc_offset")]
	public int UtcOffset { get; set; }

	public bool IsAfterDark()
	{
		var now = TimeOnly.FromDateTime(DateTime.UtcNow);
		return now >= Sunset.AddHours(-1);
	}

	public bool IsBeforeSunrise()
	{
		var now = TimeOnly.FromDateTime(DateTime.UtcNow);
		return now <= Sunrise.AddHours(1.5);
	}
}