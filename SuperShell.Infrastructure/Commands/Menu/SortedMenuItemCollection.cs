using System.Collections;
using System.Collections.ObjectModel;
using System.Windows.Controls;
using System.Windows.Data;

namespace SuperShell.Infrastructure.Commands.Menu
{
	public class SortedMenuItemCollection : ObservableCollection<IMenuItem>
	{
		public SortedMenuItemCollection()
		{
			var collectionView = (ListCollectionView)CollectionViewSource.GetDefaultView(this);
			collectionView.CustomSort = new MenuItemSorter();
		}

		internal class MenuItemSorter : IComparer
		{
			#region Implementation of IComparer

			/// <summary>
			/// Compares two objects and returns a value indicating whether one is less than, equal to, or greater than the other.
			/// </summary>
			/// <returns>
			/// A signed integer that indicates the relative values of <paramref name="x"/> and <paramref name="y"/>, as shown in the following table.
			/// Value Meaning Less than zero <paramref name="x"/> is less than <paramref name="y"/>.
			/// Zero <paramref name="x"/> equals <paramref name="y"/>.
			/// Greater than zero <paramref name="x"/> is greater than <paramref name="y"/>. 
			/// </returns>
			/// <param name="x">The first object to compare. </param>
			/// <param name="y">The second object to compare. </param>
			/// <exception cref="T:System.ArgumentException">
			/// Neither <paramref name="x"/> nor <paramref name="y"/> implements the <see cref="T:System.IComparable"/> interface.
			/// -or- <paramref name="x"/> and <paramref name="y"/> are of different types and neither one can handle comparisons with the other.
			/// </exception>
			/// <filterpriority>2</filterpriority>
			public int Compare(object x, object y)
			{
				var menuItemOne = (IMenuItem) x;
				var menuItemTwo = (IMenuItem) y;

				//now need to get metadata
				var metadataOne = MenuUtils.GetMenuItemMetadata(menuItemOne);
				var metadataTwo = MenuUtils.GetMenuItemMetadata(menuItemTwo);

				// level major
				if (metadataOne.OrderMajor < metadataTwo.OrderMajor)
					return -1;

				if (metadataOne.OrderMajor > metadataTwo.OrderMajor)
					return 1;

				// level minor

				if (metadataOne.OrderMinor < metadataTwo.OrderMinor)
					return -1;

				if (metadataOne.OrderMinor > metadataTwo.OrderMinor)
					return 1;

				// TODO: do more comparisons if more fields added
				return 0;
			}

			#endregion
		}
	}
}
