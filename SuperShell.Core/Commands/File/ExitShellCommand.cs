using System.ComponentModel.Composition;
using System.Windows;
using System.Windows.Input;
using Microsoft.Practices.Prism.Commands;
using SuperShell.Infrastructure.Commands;

namespace SuperShell.Core.Commands.File
{
	[Export]
	[PartCreationPolicy(CreationPolicy.Shared)]
	public sealed class ExitShellCommand : ShellCommandBase
	{
		public ExitShellCommand()
		{
			Command = new DelegateCommand(ExitShellCommandExecute);
		}

		#region Implementation of IShellCommand

		public override string Header
		{
			get { return "Exit"; }
		}

		public override string HeaderForMenu
		{
			get { return "E_xit"; }
		}

		public override KeyGesture HotKey
		{
			get { return new KeyGesture(Key.F4, ModifierKeys.Alt); }
		}

		public override ICommand Command { get; protected set; }

		#endregion

		private void ExitShellCommandExecute()
		{
			Application.Current.Shutdown(0);
		}
	}
}
