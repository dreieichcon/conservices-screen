using Conservices.Screen.Models.Sun;

namespace Conservices.Screen.Interfaces.Repositories;

public interface ISunRepository
{
	public Task<SunState> GetSunStateAsync();
}