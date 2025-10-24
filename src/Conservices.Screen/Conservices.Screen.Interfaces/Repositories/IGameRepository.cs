using Conservices.Screen.Models.Games;

namespace Conservices.Screen.Interfaces.Repositories;

public interface IGameRepository
{
	public Task<IEnumerable<Game>> GetAllAsync(string eventId);
}