using Conservices.Screen.Models.Convention;

namespace Conservices.Screen.Interfaces.Conservices;

public interface IConventionService
{
	public Task<IEnumerable<Convention>> GetAllAsync();
	
	public Task<Convention?> GetAsync(string id);
}