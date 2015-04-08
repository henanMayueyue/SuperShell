using ShellMenu = System.Windows.Controls.Menu;

namespace SuperShell.Infrastructure.Commands.Menu
{
	public interface IMenuService
	{
		void RegisterMenuItem(ShellMenu parentMenu, IMenuItem menuItem);
	}
}
