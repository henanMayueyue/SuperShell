using System.ComponentModel.Composition;
using System.Windows.Controls;
using SuperShell.Core.Menu.ViewModels.File;
using SuperShell.Infrastructure.Commands.Menu;

namespace SuperShell.Core.Menu.Views.File
{
	/// <summary>
	/// Interaction logic for FileMenuItemView.xaml
	/// </summary>
	[MenuItemExport(typeof(IMenuItem), MenuItemId = Constants.File, OrderMajor = 0)]
	public partial class FileMenuItemView : MenuItem, IMenuItem
	{
		public FileMenuItemView()
		{
			InitializeComponent();
			ItemsSource = new SortedMenuItemCollection();
		}

		[Import]
		public FileMenuItemViewModel ViewModel
		{
			set { DataContext = value; }
		}

		#region Implementation of IMenuItemAdder


		#endregion

		#region Implementation of IMenuItemAdder

		public void AddToParent()
		{
			throw new System.NotImplementedException();
		}

		#endregion
	}
}
