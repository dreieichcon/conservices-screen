using Conservices.Screen.Models.Convention;

namespace Conservices.Screen.Interfaces.Conservices;

public interface IConventionService
{
	public Task<IEnumerable<Convention>> GetConventionsAsync();
	
	public Task<Convention?> GetConventionAsync(string id);
}