// WARNING
//
// This file has been generated automatically by Xamarin Studio to store outlets and
// actions made in the UI designer. If it is removed, they will be lost.
// Manual changes to this file may not be handled correctly.
//
using MonoTouch.Foundation;
using System.CodeDom.Compiler;

namespace CodePad.iOS.UI
{
	[Register ("ReplViewController")]
	partial class ReplViewController
	{
		[Outlet]
		MonoTouch.UIKit.UITextView historyView { get; set; }

		[Outlet]
		MonoTouch.UIKit.UITextField inputBox { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (historyView != null) {
				historyView.Dispose ();
				historyView = null;
			}

			if (inputBox != null) {
				inputBox.Dispose ();
				inputBox = null;
			}
		}
	}
}
