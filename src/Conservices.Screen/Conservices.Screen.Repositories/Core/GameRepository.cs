using Conservices.Screen.Interfaces.Repositories;
using Conservices.Screen.Models;
using Conservices.Screen.Models.Games;
using Conservices.Screen.Repositories.Requests;

namespace Conservices.Screen.Repositories.Core;

public class GameRepository : AbstractConservicesRepository, IGameRepository
{
	public async Task<IEnumerable<Game>> GetAllAsync(string eventId)
	{
		var uri = new ConservicesRequestUri().WithSegments("event", eventId, "game");

		var request = await GetAsync(uri);

		if (!request.IsSuccess || string.IsNullOrEmpty(request.ResponseBody))
			return [];

		var result = Serializer.Deserialize<Dictionary<string, Game>>(request.ResponseBody);

		return result is null ? [] : result.Values.ToArray();
	}
}