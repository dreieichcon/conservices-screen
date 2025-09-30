using System.Text.Json.Serialization;
using Conservices.Screen.Models.Sun;

namespace Conservices.Screen.Models.Response;

public class SunStateResponse
{
	[JsonPropertyName("results")]
	public SunState SunState { get; set; }
}