namespace Conservices.Screen.Services.Models;

public class ConventionKeyedItems<T>(IEnumerable<T> items)
{
	public DateTime LastUpdated { get; set; } = DateTime.UtcNow;

	public IEnumerable<T> Items { get; set; } = items;

	public bool NeedsUpdate(TimeSpan refreshInterval)
		=> !Items.Any() || DateTime.UtcNow - LastUpdated > refreshInterval;
}