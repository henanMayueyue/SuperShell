using System.ComponentModel.Composition.Hosting;
using System.Windows;
using System.Windows.Controls;
using Microsoft.Practices.Prism.MefExtensions;
using Microsoft.Practices.Prism.Regions;
using Microsoft.Practices.ServiceLocation;
using SuperShell.Infrastructure;
using SuperShell.Infrastructure.Behaviors;
using SuperShell.Infrastructure.Prism.RegionAdapters;

namespace SuperShell
{
	public class Bootstrapper : MefBootstrapper
	{
		protected override DependencyObject CreateShell()
		{
			return ServiceLocator.Current.GetInstance<Shell>();
		}

		protected override void InitializeShell()
		{
			Application.Current.MainWindow = (Window) Shell;
			Application.Current.MainWindow.Show();
		}

		protected override void ConfigureAggregateCatalog()
		{
			AggregateCatalog.Catalogs.Add(new AssemblyCatalog(typeof (Bootstrapper).Assembly)); // this assembly
			AggregateCatalog.Catalogs.Add(new AssemblyCatalog(typeof(RegionNames).Assembly)); // infrastructure
			AggregateCatalog.Catalogs.Add(new AssemblyCatalog(typeof(Core.Module).Assembly)); // infrastructure
		}

		protected override RegionAdapterMappings ConfigureRegionAdapterMappings()
		{
			var regionAdapterMappings = base.ConfigureRegionAdapterMappings();

			// custom region adapters to populate menu and toolbars
			regionAdapterMappings.RegisterMapping(typeof(Menu), ServiceLocator.Current.GetInstance<MenuRegionAdapter>());
			regionAdapterMappings.RegisterMapping(typeof(ToolBarTray), ServiceLocator.Current.GetInstance<ToolBarTrayRegionAdapter>());

			return regionAdapterMappings;
		}

		protected override IRegionBehaviorFactory ConfigureDefaultRegionBehaviors()
		{
			var factory =  base.ConfigureDefaultRegionBehaviors();

			factory.AddIfMissing(AutoPopulateMenuBehavior.BehaviorKey, typeof(AutoPopulateMenuBehavior));

			return factory;
		}
	}
}
