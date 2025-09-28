using Conservices.Screen.Models.Program;

namespace Conservices.Screen.Interfaces.Repositories;

public interface IProgramRepository
{
	public Task<IEnumerable<ProgramItem>> GetAllAsync(string eventId);
}