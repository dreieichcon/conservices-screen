using Conservices.Screen.Interfaces.Conservices;
using Conservices.Screen.Interfaces.Repositories;
using Conservices.Screen.Models.Program;

namespace Conservices.Screen.Services.Conservices;

public class ProgramService(IProgramRepository programRepository)
	: AbstractKeyedConService<ProgramItem>, IProgramService
{
	protected override TimeSpan RefreshInterval => TimeSpan.FromMinutes(10);

	protected override async Task<IEnumerable<ProgramItem>> GetItemsForConventionAsync(string eventId)
	{
		return (await programRepository.GetAllAsync(eventId)).Where(x => x.Start > DateTime.Now);
	}

	public async Task<IEnumerable<ProgramItem>> GetAllAsync(string eventId)
	{
		await RefreshIfNeededAsync(eventId);
		return Items[eventId].Items;
	}
}