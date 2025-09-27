using Conservices.Screen.Interfaces.Conservices;
using Conservices.Screen.Interfaces.Repositories;
using Conservices.Screen.Models.Convention;

namespace Conservices.Screen.Services.Conservices;

public class ConventionService(IConventionRepository conventionRepository) : IConventionService
{
	private DateTime _lastUpdated = DateTime.UtcNow;

	private IEnumerable<Convention> _conventions = [];
	public async Task<IEnumerable<Convention>> GetConventionsAsync()
	{
		await RefreshIfNeededAsync();
		return _conventions;
	}

	public async Task<Convention?> GetConventionAsync(string id)
	{
		await RefreshIfNeededAsync();
		return _conventions.FirstOrDefault(x => x.Id == id);
	}

	private async Task RefreshIfNeededAsync()
	{
		if (!_conventions.Any() || DateTime.UtcNow - _lastUpdated > TimeSpan.FromHours(1))
		{
			_conventions = await conventionRepository.GetAllAsync();
			_lastUpdated = DateTime.UtcNow;
		}
	}
}