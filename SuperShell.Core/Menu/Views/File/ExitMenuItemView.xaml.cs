using System;
using System.ComponentModel.Composition;
using System.Linq;
using System.Windows.Controls;
using SuperShell.Core.Menu.ViewModels.File;
using SuperShell.Infrastructure.Commands.Menu;

namespace SuperShell.Core.Menu.Views.File
{
	/// <summary>
	/// Interaction logic for ExitMenuItemView.xaml
	/// </summary>
	[MenuItemExport(typeof(IMenuItem), ParentMenuItemId = Constants.File, MenuItemId = Constants.FileExit, OrderMajor = 1000, OrderMinor = 1)]
	public partial class ExitShellCommandView : MenuItem, IMenuItem
	{
		public ExitShellCommandView()
		{
			InitializeComponent();
		}

		[Import]
		public ExitMenuItemViewModel ViewModel
		{
			set { DataContext = value; }
		}
	}
}
