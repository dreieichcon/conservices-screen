using Conservices.Screen.Models.Games;
using Conservices.Screen.Models.Misc;

namespace Conservices.Screen.Interfaces.Conservices;

public interface IGameService
{
	public Task<IEnumerable<Game>> GetAllAsync(string eventId);
	
	public Task<IEnumerable<Location>> GetAllBuildings(string eventId);
}