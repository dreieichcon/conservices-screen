using System.Text.Json.Serialization;
using JetBrains.Annotations;

namespace Conservices.Screen.Models.Games;

[UsedImplicitly]
public class GameMaster
{
	[JsonPropertyName("name")]
	public required string Name { get; set; }
}