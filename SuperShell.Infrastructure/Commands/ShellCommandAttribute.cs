using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperShell.Infrastructure.Commands
{
	/// <summary>
	/// Attribute to decorate shell commands with.
	/// </summary>
	[AttributeUsage(AttributeTargets.Class, Inherited = false)]
	public class ShellCommandAttribute : ExportAttribute
	{
	}
}
