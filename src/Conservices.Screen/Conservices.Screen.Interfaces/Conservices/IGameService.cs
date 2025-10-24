using Conservices.Screen.Models.Games;

namespace Conservices.Screen.Interfaces.Conservices;

public interface IGameService
{
	public Task<IEnumerable<Game>> GetAllAsync(string eventId);
}