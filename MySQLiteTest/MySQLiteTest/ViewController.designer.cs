// WARNING
//
// This file has been generated automatically by Visual Studio to store outlets and
// actions made in the UI designer. If it is removed, they will be lost.
// Manual changes to this file may not be handled correctly.
//
using Foundation;
using System.CodeDom.Compiler;

namespace MySQLiteTest
{
	[Register ("ViewController")]
	partial class ViewController
	{
		[Outlet]
		UIKit.UIButton MyAddButton { get; set; }

		[Outlet]
		UIKit.UIButton MyExitButton { get; set; }

		[Outlet]
		UIKit.UIButton MyRemoveButton { get; set; }

		[Outlet]
		UIKit.UITableView MyTablveView { get; set; }

		[Outlet]
		UIKit.UIButton MyUpdateButton { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (MyAddButton != null) {
				MyAddButton.Dispose ();
				MyAddButton = null;
			}

			if (MyRemoveButton != null) {
				MyRemoveButton.Dispose ();
				MyRemoveButton = null;
			}

			if (MyTablveView != null) {
				MyTablveView.Dispose ();
				MyTablveView = null;
			}

			if (MyUpdateButton != null) {
				MyUpdateButton.Dispose ();
				MyUpdateButton = null;
			}

			if (MyExitButton != null) {
				MyExitButton.Dispose ();
				MyExitButton = null;
			}
		}
	}
}
