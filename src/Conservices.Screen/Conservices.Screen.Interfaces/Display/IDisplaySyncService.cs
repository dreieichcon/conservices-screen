namespace Conservices.Screen.Interfaces.Display;

public interface IDisplaySyncService
{
	public event EventHandler? DisplayChanged;
	
	public int DisplayIndex { get; set; }
}