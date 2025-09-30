using System.Text.Json;
using Demolite.Http.Serialization;

namespace Conservices.Screen.Repositories.Serialization.Sun;

public class SunStateSerializer : AbstractSerializer
{
	public override JsonSerializerOptions CreateSerializerOptions()
	{
		var options = new JsonSerializerOptions()
		{
			WriteIndented = true,
		};
		
		return options;
	}
}