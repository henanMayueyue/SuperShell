using System;
using System.ComponentModel.Composition;
using System.Linq;
using Microsoft.Practices.Prism.Regions;
using SuperShell.Infrastructure.Commands.Menu;

namespace SuperShell.Infrastructure.Behaviors
{
	[Export(typeof(AutoPopulateMenuBehavior))]
	[PartCreationPolicy(CreationPolicy.NonShared)]
	public class AutoPopulateMenuBehavior : RegionBehavior, IPartImportsSatisfiedNotification
	{
		public const string BehaviorKey = "AutoPopulateMenuBehavior";

		protected override void OnAttach()
		{
			PopulateMenu();
		}

		#region Implementation of IPartImportsSatisfiedNotification

		public void OnImportsSatisfied()
		{
			PopulateMenu();
		}

		#endregion

		private void PopulateMenu()
		{
			if (Region != null && Region.Name == RegionNames.MainMenuRegion)
			{
				foreach (var registeredMenu in RegisteredMenus.OrderByDescending(menu=>menu.Metadata.MenuItemId))
				{
					var view = registeredMenu.Value;

					if (!Region.Views.Contains(view))
					{
						Region.Add(view);
					}
				}
			}
		}

		[ImportMany(AllowRecomposition = true)]
		public Lazy<IMenuItem, IMenuItemMetadata>[] RegisteredMenus { get; set; }
	}
}
