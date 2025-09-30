using Conservices.Screen.Interfaces.Repositories;
using Conservices.Screen.Models.Response;
using Conservices.Screen.Models.Sun;
using Conservices.Screen.Repositories.Requests;
using Conservices.Screen.Repositories.Serialization.Sun;
using Demolite.Http.Repository;

namespace Conservices.Screen.Repositories.Sun;

public class SunRepository : AbstractHttpRepository, ISunRepository
{
	private SunState? State { get; set; }

	private DateTime LastUpdate { get; set; }

	private readonly SunStateSerializer _serializer = new();

	public async Task<SunState> GetSunStateAsync()
	{
		if (State is null || DateTime.UtcNow - LastUpdate >= TimeSpan.FromHours(24))
			await UpdateSunStateAsync();

		return State!;
	}

	private async Task UpdateSunStateAsync()
	{
		LastUpdate = DateTime.UtcNow;

		var uri = new SunStateRequestUri().WithParameter("lat", "50.02485985471239")
			.WithParameter("lng", "8.66270997993345")
			.WithParameter("timezone", "UTC")
			.WithParameter("time_format", "24");

		var response = await GetAsync(uri);

		if (!response.IsSuccess)
			return;

		var deserialized = _serializer.Deserialize<SunStateResponse>(response.ResponseBody!);

		State = deserialized?.SunState ?? new SunState()
		{
			Dusk = new TimeOnly(18),
		};
	}
}