using System.ComponentModel.Composition;
using System.Globalization;
using Microsoft.Practices.Prism.Mvvm;
using SuperShell.Core.Commands.File;

namespace SuperShell.Core.Menu.ViewModels.File
{
	[Export]
	[PartCreationPolicy(CreationPolicy.Shared)]
	public class ExitMenuItemViewModel : BindableBase
	{
		private ExitShellCommand _shellCommand;

		public string Header
		{
			get
			{
				var command = ShellCommand;
				if (command != null)
					return command.HeaderForMenu;

				return string.Empty;
			}
		}

		public string InputGestureText
		{
			get
			{
				var command = ShellCommand;
				if (command == null || command.HotKey == null)
					return null;
				
				var gestureText = command.HotKey.GetDisplayStringForCulture(CultureInfo.CurrentUICulture);

				return gestureText;
			}
		}

		[Import]
		public ExitShellCommand ShellCommand
		{
			get { return _shellCommand; }
			set
			{
				if (_shellCommand != value)
				{
					_shellCommand = value;
					OnPropertyChanged(()=>ShellCommand);
					OnPropertyChanged(()=>InputGestureText);
					OnPropertyChanged(()=>Header);
				}
			}
		}
	}
}
