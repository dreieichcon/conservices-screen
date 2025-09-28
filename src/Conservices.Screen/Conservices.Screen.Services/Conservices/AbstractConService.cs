namespace Conservices.Screen.Services.Conservices;

public abstract class AbstractConService<T>
{
	protected abstract TimeSpan RefreshInterval { get; }

	protected abstract Task<IEnumerable<T>> GetItemsAsync();

	private DateTime _lastUpdated = DateTime.UtcNow;

	protected IEnumerable<T> Items = [];

	protected async Task RefreshIfNeededAsync()
	{
		if (!Items.Any() || DateTime.UtcNow - _lastUpdated > RefreshInterval)
		{
			Items = await GetItemsAsync();
			_lastUpdated = DateTime.UtcNow;
		}
	}
}