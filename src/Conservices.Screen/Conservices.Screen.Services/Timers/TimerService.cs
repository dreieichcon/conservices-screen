using Conservices.Screen.Interfaces.Timers;

namespace Conservices.Screen.Services.Timers;

public class TimerService : ITimerService
{
	private readonly PeriodicTimer _timer = new(TimeSpan.FromSeconds(1));
	
	private readonly PeriodicTimer _minuteTimer = new(TimeSpan.FromMinutes(1));

	private readonly PeriodicTimer _fiveMinuteTimer = new(TimeSpan.FromMinutes(5));

	private int _elapsedTicks;

	private const int TimePerItem = 5;

	private const int TimePerPage = TimePerItem * 20;

	public event EventHandler? TickSecond;

	public event EventHandler? TickItem;

	public event EventHandler? TickPage;

	public event EventHandler? TickOneMinute;

	public event EventHandler? TickFiveMinutes;

	public TimerService()
	{
		Task.Run(async () => await Tick());
		Task.Run(async () => await TickMinute());
		Task.Run(async () => await TickMinutes());
	}

	private async Task TickMinutes()
	{
		while (await _fiveMinuteTimer.WaitForNextTickAsync(cancellationToken: CancellationToken.None))
		{
			TickFiveMinutes?.Invoke(this, EventArgs.Empty);
		}
	}
	
	private async Task TickMinute()
	{
		while (await _minuteTimer.WaitForNextTickAsync(cancellationToken: CancellationToken.None))
		{
			TickFiveMinutes?.Invoke(this, EventArgs.Empty);
		}
	}

	private async Task Tick()
	{
		while (await _timer.WaitForNextTickAsync(cancellationToken: CancellationToken.None))
		{
			_elapsedTicks++;

			TickSecond?.Invoke(this, EventArgs.Empty);

			if (_elapsedTicks % TimePerItem == 0)
				TickItem?.Invoke(this, EventArgs.Empty);

			if (_elapsedTicks % TimePerPage != 0)
				continue;

			TickPage?.Invoke(this, EventArgs.Empty);
			_elapsedTicks = 0;
		}
	}
}