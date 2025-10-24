using Conservices.Screen.Models.Enum;

namespace Conservices.Screen.Interfaces.Display;

public interface IDisplaySyncService
{
	public event EventHandler? DisplayChanged;

	public event EventHandler? PageChanged;
	
	public ActiveDisplay ActiveDisplay { get; set; } 
	
	public int DisplayIndex { get; set; }
	
	public int MaxIndex { get; }
}