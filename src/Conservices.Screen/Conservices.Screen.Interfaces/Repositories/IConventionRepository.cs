using Conservices.Screen.Models.Convention;

namespace Conservices.Screen.Interfaces.Repositories;

public interface IConventionRepository
{
	public Task<IEnumerable<Convention>> GetAllAsync();
}