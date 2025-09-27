namespace Conservices.Screen.Interfaces.Timers;

public interface ITimerService
{
	public event EventHandler TickSecond;

	public event EventHandler TickItem;

	public event EventHandler TickPage;
	
	public event EventHandler? TickFiveMinutes;
}