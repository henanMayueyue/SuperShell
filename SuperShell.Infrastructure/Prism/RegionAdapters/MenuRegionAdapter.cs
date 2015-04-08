using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel.Composition;
using System.Linq;
using System.Windows.Controls;
using Microsoft.Practices.Prism.Regions;
using SuperShell.Infrastructure.Commands.Menu;
using ShellMenu = System.Windows.Controls.Menu;

namespace SuperShell.Infrastructure.Prism.RegionAdapters
{
	[Export]
	public class MenuRegionAdapter : RegionAdapterBase<ShellMenu>
	{
		private readonly IMenuService _menuService;
		private ShellMenu _menu;

		[ImportingConstructor]
		public MenuRegionAdapter(IRegionBehaviorFactory regionBehaviorFactory, IMenuService menuService) : base(regionBehaviorFactory)
		{
			_menuService = menuService;
		}

		#region Overrides of RegionAdapterBase<Menu>

		protected override void Adapt(IRegion region, ShellMenu regionTarget)
		{
			_menu = regionTarget;

			_menu.ItemsSource = new SortedMenuItemCollection();

			region.ActiveViews.CollectionChanged += ActiveViewsOnCollectionChanged;
		}

		private void ActiveViewsOnCollectionChanged(object sender, NotifyCollectionChangedEventArgs notifyCollectionChangedEventArgs)
		{
			switch (notifyCollectionChangedEventArgs.Action)
			{
				case NotifyCollectionChangedAction.Add:
					foreach (var menuItem in notifyCollectionChangedEventArgs.NewItems.Cast<IMenuItem>())
					{
						_menuService.RegisterMenuItem(_menu, menuItem);
					}
					break;
				case NotifyCollectionChangedAction.Remove:
					throw new NotImplementedException("Removing menu items is not implemented yet.");
					break;
				case NotifyCollectionChangedAction.Reset:
					// just do nothing for reset
					break;
				case NotifyCollectionChangedAction.Replace:
				case NotifyCollectionChangedAction.Move:
				throw new InvalidOperationException(string.Format("Operation {0} is not allowed here.",
						notifyCollectionChangedEventArgs.Action));
				default:
					throw new ArgumentOutOfRangeException();
			}
		}

		protected override IRegion CreateRegion()
		{
			return new AllActiveRegion();
		}

		#endregion
	}
}
