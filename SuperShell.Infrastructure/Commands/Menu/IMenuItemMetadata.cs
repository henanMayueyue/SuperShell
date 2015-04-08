namespace SuperShell.Infrastructure.Commands.Menu
{
	public interface IMenuItemMetadata
	{
		string ParentMenuItemId { get; }
		string MenuItemId { get; }
		int OrderMajor { get; }
		int OrderMinor { get; }
	}
}