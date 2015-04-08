using System.ComponentModel.Composition;
using Microsoft.Practices.Prism.Mvvm;

namespace SuperShell.Core.Menu.ViewModels.File
{
	[Export]
	[PartCreationPolicy(CreationPolicy.Shared)]
	public class FileMenuItemViewModel : BindableBase
	{
		public string Header { get { return "_File"; } }
	}
}
