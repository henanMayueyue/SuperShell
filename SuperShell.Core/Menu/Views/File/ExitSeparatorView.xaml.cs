using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using SuperShell.Infrastructure.Commands.Menu;

namespace SuperShell.Core.Menu.Views.File
{
	/// <summary>
	/// Interaction logic for ExitSeparatorView.xaml
	/// </summary>
	[MenuItemExport(typeof(IMenuItem), ParentMenuItemId = Constants.File, OrderMajor = 1000, OrderMinor = 0)]
	public partial class ExitSeparatorView : Separator, IMenuItem
	{
		public ExitSeparatorView()
		{
			InitializeComponent();
		}
	}
}
