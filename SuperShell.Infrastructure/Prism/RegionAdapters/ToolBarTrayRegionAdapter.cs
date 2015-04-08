using System;
using System.Collections.Specialized;
using System.ComponentModel.Composition;
using Microsoft.Practices.Prism.Regions;
using ShellToolBarTray = System.Windows.Controls.ToolBarTray;

namespace SuperShell.Infrastructure.Prism.RegionAdapters
{
	[Export]
	public class ToolBarTrayRegionAdapter : RegionAdapterBase<ShellToolBarTray>
	{
		[ImportingConstructor]
		public ToolBarTrayRegionAdapter(IRegionBehaviorFactory regionBehaviorFactory) : base(regionBehaviorFactory)
		{
		}

		#region Overrides of RegionAdapterBase<ToolBarTray>

		/// <summary>
		/// Template method to adapt the object to an <see cref="T:Microsoft.Practices.Prism.Regions.IRegion"/>.
		/// </summary>
		/// <param name="region">The new region being used.</param><param name="regionTarget">The object to adapt.</param>
		protected override void Adapt(IRegion region, ShellToolBarTray regionTarget)
		{
			region.ActiveViews.CollectionChanged += ActiveViewsOnCollectionChanged;
		}

		private void ActiveViewsOnCollectionChanged(object sender, NotifyCollectionChangedEventArgs notifyCollectionChangedEventArgs)
		{
			switch (notifyCollectionChangedEventArgs.Action)
			{
				case NotifyCollectionChangedAction.Add:
					break;
				case NotifyCollectionChangedAction.Remove:
					break;
				case NotifyCollectionChangedAction.Replace:
					break;
				case NotifyCollectionChangedAction.Move:
					break;
				case NotifyCollectionChangedAction.Reset:
					break;
				default:
					throw new ArgumentOutOfRangeException();
			}
		}

		/// <summary>
		/// Template method to create a new instance of <see cref="T:Microsoft.Practices.Prism.Regions.IRegion"/>
		///             that will be used to adapt the object.
		/// </summary>
		/// <returns>
		/// A new instance of <see cref="T:Microsoft.Practices.Prism.Regions.IRegion"/>.
		/// </returns>
		protected override IRegion CreateRegion()
		{
			return new AllActiveRegion();
		}

		#endregion
	}
}
