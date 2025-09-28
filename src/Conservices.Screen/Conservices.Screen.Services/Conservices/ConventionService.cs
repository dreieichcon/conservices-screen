using Conservices.Screen.Interfaces.Conservices;
using Conservices.Screen.Interfaces.Repositories;
using Conservices.Screen.Models.Convention;

namespace Conservices.Screen.Services.Conservices;

public class ConventionService(IConventionRepository conventionRepository)
	: AbstractConService<Convention>, IConventionService
{
	protected override TimeSpan RefreshInterval => TimeSpan.FromHours(1);

	protected override async Task<IEnumerable<Convention>> GetItemsAsync()
		=> await conventionRepository.GetAllAsync();

	public async Task<IEnumerable<Convention>> GetAllAsync()
	{
		await RefreshIfNeededAsync();
		return Items;
	}

	public async Task<Convention?> GetAsync(string id)
	{
		await RefreshIfNeededAsync();
		return Items.FirstOrDefault(x => x.Id == id);
	}
}