using System.Text.Json;
using Conservices.Screen.Interfaces.Repositories;
using Conservices.Screen.Models.Convention;
using Conservices.Screen.Repositories.Requests;
using Conservices.Screen.Repositories.Serialization;
using Demolite.Http.Repository;

namespace Conservices.Screen.Repositories.Core;

public class ConventionRepository : AbstractHttpRepository, IConventionRepository
{
	private readonly ConservicesSerializer _serializer = new();
	public override void SetGetHeaders()
	{
		base.SetGetHeaders();
		Client.DefaultRequestHeaders.Add("accept", "application/json");
	}

	public async Task<IEnumerable<Convention>> GetAllAsync()
	{
		var uri = new ConservicesRequestUri().WithSegments("event");
		
		var result = await GetAsync(uri);

		if (!result.IsSuccess)
			return [];

		return _serializer.Deserialize<IEnumerable<Convention>>(result.ResponseBody!) ?? [];
	}
}