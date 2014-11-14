// WARNING
//
// This file has been generated automatically by Xamarin Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//
using System;
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using System.CodeDom.Compiler;

namespace V.TouchIdExample
{
	[Register ("VTouchIdExampleViewController")]
	partial class VTouchIdExampleViewController
	{
		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UIButton authenticateButton { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UILabel AuthenticatedLabel { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UISwitch touchIdSwitch { get; set; }

		[Action ("AuthenticateUser:")]
		[GeneratedCode ("iOS Designer", "1.0")]
		partial void AuthenticateUser (UIButton sender);

		[Action ("TouchIdEnableDisable:")]
		[GeneratedCode ("iOS Designer", "1.0")]
		partial void TouchIdEnableDisable (UISwitch sender);

		void ReleaseDesignerOutlets ()
		{
			if (authenticateButton != null) {
				authenticateButton.Dispose ();
				authenticateButton = null;
			}
			if (AuthenticatedLabel != null) {
				AuthenticatedLabel.Dispose ();
				AuthenticatedLabel = null;
			}
			if (touchIdSwitch != null) {
				touchIdSwitch.Dispose ();
				touchIdSwitch = null;
			}
		}
	}
}
