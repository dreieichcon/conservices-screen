namespace Conservices.Screen.Util;

public static class IterationHelper
{
	public static IEnumerable<Tuple<T, int>> WithIterator<T>(this IEnumerable<T> items)
		=> items.Select((item, index) => new Tuple<T, int>(item, index));
}