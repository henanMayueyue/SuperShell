using System.Windows.Input;
using System.Windows.Media;

namespace SuperShell.Infrastructure.Commands
{
	public abstract class ShellCommandBase : IShellCommand
	{
		#region Implementation of IShellCommand

		public abstract string Header { get; }
		public virtual string HeaderForMenu { get { return Header; } }
		public virtual ImageSource Icon { get { return null; } }
		public virtual KeyGesture HotKey { get { return null; } }
		public abstract ICommand Command { get; protected set; }

		#endregion
	}
}