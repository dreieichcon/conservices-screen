using Conservices.Screen.Interfaces.Conservices;
using Conservices.Screen.Interfaces.Repositories;
using Conservices.Screen.Models.Games;

namespace Conservices.Screen.Services.Conservices;

public class GameService(IGameRepository gameRepository) 
	: AbstractKeyedConService<Game>, IGameService
{
	protected override TimeSpan RefreshInterval  => TimeSpan.FromMinutes(5);

	protected override async Task<IEnumerable<Game>> GetItemsForConventionAsync(string eventId)
	{
		return await gameRepository.GetAllAsync(eventId);
	}

	public async Task<IEnumerable<Game>> GetAllAsync(string eventId)
	{
		await RefreshIfNeededAsync(eventId);
		return Items[eventId].Items;
	}
}