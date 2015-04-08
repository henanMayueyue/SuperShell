using System.Windows.Input;
using System.Windows.Media;

namespace SuperShell.Infrastructure.Commands
{
	/// <summary>
	/// Represents the command which can be executed within the Shell
	/// It is just a wrapper around ordinary <see cref="ICommand">ICommand</see>
	/// </summary>
	public interface IShellCommand
	{
		string Header { get; }
		string HeaderForMenu { get; }

		ImageSource Icon { get; }

		KeyGesture HotKey { get; }

		ICommand Command { get; }
	}
}