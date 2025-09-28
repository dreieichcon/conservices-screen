using Conservices.Screen.Interfaces.Repositories;
using Conservices.Screen.Models.Program;
using Conservices.Screen.Models.Response;
using Conservices.Screen.Repositories.Requests;

namespace Conservices.Screen.Repositories.Core;

public class ProgramRepository : AbstractConservicesRepository, IProgramRepository
{
	public async Task<IEnumerable<ProgramItem>> GetAllAsync(string eventId)
	{
		var uri = new ConservicesRequestUri().WithSegments("event", eventId, "programm");

		var request = await GetAsync(uri);

		if (!request.IsSuccess || string.IsNullOrEmpty(request.ResponseBody))
			return [];

		var result = Serializer.Deserialize<Dictionary<string, ProgramItem>>(request.ResponseBody);

		return result is null ? [] : result.Values.ToArray();
	}
}