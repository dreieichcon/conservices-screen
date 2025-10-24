using Conservices.Screen.Interfaces.Display;
using Conservices.Screen.Interfaces.Timers;
using Conservices.Screen.Models.Enum;

namespace Conservices.Screen.Services.Display;

public class DisplaySyncService : IDisplaySyncService
{
	public int MaxIndex => 20;

	public ActiveDisplay ActiveDisplay { get; set; } = ActiveDisplay.Program;
	
	public event EventHandler? DisplayChanged;

	public event EventHandler? PageChanged;

	public int DisplayIndex { get; set; }
	
	public int PageIndex { get; set; }

	public DisplaySyncService(ITimerService timerService)
	{
		timerService.TickItem += TimerServiceOnItemTick;
		timerService.TickPage += TimerServiceOnPageTick;
	}

	private void TimerServiceOnPageTick(object? _, EventArgs __)
	{
		ActiveDisplay = ActiveDisplay switch
		{
			ActiveDisplay.Program => ActiveDisplay.Games,
			ActiveDisplay.Games => ActiveDisplay.Program,
			var _ => ActiveDisplay,
		};

		PageChanged?.Invoke(this, EventArgs.Empty);
	}

	private void TimerServiceOnItemTick(object? _, EventArgs __)
	{
		if (DisplayIndex >= MaxIndex - 1)
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