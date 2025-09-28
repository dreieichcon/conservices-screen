using Conservices.Screen.Models.Program;

namespace Conservices.Screen.Interfaces.Conservices;

public interface IProgramService
{
	public Task<IEnumerable<ProgramItem>> GetAllAsync(string eventId);
}