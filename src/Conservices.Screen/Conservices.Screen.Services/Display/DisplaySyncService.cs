using Conservices.Screen.Interfaces.Display;
using Conservices.Screen.Interfaces.Timers;

namespace Conservices.Screen.Services.Display;

public class DisplaySyncService : IDisplaySyncService
{
	private const int MaxIndex = 20;
	
	public event EventHandler? DisplayChanged;

	public int DisplayIndex { get; set; }

	public DisplaySyncService(ITimerService timerService)
	{
		timerService.TickItem += TimerServiceOnItemTick;
		timerService.TickPage += TimerServiceOnPageTick;
	}

	private void TimerServiceOnPageTick(object? _, EventArgs __)
	{
		// do nothing, as double viewer is not yet implemented
	}

	private void TimerServiceOnItemTick(object? _, EventArgs __)
	{
		if (DisplayIndex <= MaxIndex)
		{
			DisplayIndex = 0;
		}
		else
		{
			DisplayIndex++;
		}
		
		DisplayChanged?.Invoke(this, EventArgs.Empty);
	}
}