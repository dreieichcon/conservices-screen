namespace Conservices.Screen.Models.Response;

public class ConservicesListResponse<T>
{
	public Dictionary<string, T> ItemsDict { get; set; } = [];
}