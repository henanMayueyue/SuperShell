using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Windows.Controls;
using ShellMenu = System.Windows.Controls.Menu;

namespace SuperShell.Infrastructure.Commands.Menu
{
	[Export(typeof(IMenuService))]
	public class MenuService : IMenuService
	{
		#region Implementation of IMenuService

		public void RegisterMenuItem(ShellMenu parentMenu, IMenuItem menuItem)
		{
			// get metadata
			var menuItemMetadata = MenuUtils.GetMenuItemMetadata(menuItem);
			// var menuItemId = menuItemMetadata.MenuItemId;
			var parentMenuItemId = menuItemMetadata.ParentMenuItemId;

			ICollection<IMenuItem> collectionToAdd;

			if (string.IsNullOrWhiteSpace(parentMenuItemId))
			{
				// adding top level menu
				collectionToAdd = (ICollection<IMenuItem>) parentMenu.ItemsSource;
			}
			else
			{
				// adding submenu
				var parentMenuItem = AllMenuItems.Single(item => item.Metadata.MenuItemId == parentMenuItemId);
				collectionToAdd = (ICollection<IMenuItem>) ((MenuItem) parentMenuItem.Value).ItemsSource;
			}

			collectionToAdd.Add(menuItem);
		}

		#endregion

		[ImportMany(AllowRecomposition = true)]
		private Lazy<IMenuItem, IMenuItemMetadata>[] AllMenuItems { get; set; }
	}
}