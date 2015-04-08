using System.Reflection;
using System.Windows.Controls;

namespace SuperShell.Infrastructure.Commands.Menu
{
	public static class MenuUtils
	{
		public static IMenuItemMetadata GetMenuItemMetadata(IMenuItem menuItem)
		{
			return (MenuItemExportAttribute)menuItem.GetType().GetCustomAttribute(typeof(MenuItemExportAttribute));
		}
	}
}
