using Conservices.Screen.Services.Models;

namespace Conservices.Screen.Services.Conservices;

public abstract class AbstractKeyedConService<T>
{
	protected Dictionary<string, ConventionKeyedItems<T>> Items = [];

	protected abstract TimeSpan RefreshInterval { get; }

	protected abstract Task<IEnumerable<T>> GetItemsForConventionAsync(string eventId);

	protected async Task RefreshIfNeededAsync(string eventId)
	{
		if (!Items.TryGetValue(eventId, out var item))
		{
			Items[eventId] = new ConventionKeyedItems<T>(await GetItemsForConventionAsync(eventId));
			return;
		}

		if (item.NeedsUpdate(RefreshInterval))
		{
			item.Items = await GetItemsForConventionAsync(eventId);
			item.LastUpdated = DateTime.UtcNow;
		}
	}
}