using System;
using System.ComponentModel.Composition;
using System.Windows.Controls;

namespace SuperShell.Infrastructure.Commands.Menu
{
	[AttributeUsage(AttributeTargets.Class)]
	[MetadataAttribute]
	public class MenuItemExportAttribute : ExportAttribute, IMenuItemMetadata
	{
		public MenuItemExportAttribute() : base(typeof(MenuItem))
		{
			
		}

		public MenuItemExportAttribute(Type contractType) : base(contractType)
		{
		}

		#region Implementation of IMenuItemMetadata

		public string ParentMenuItemId { get; set; }

		public string MenuItemId { get; set; }

		public int OrderMajor { get; set; }

		public int OrderMinor { get; set; }

		#endregion
	}
}
