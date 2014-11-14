using System;
using System.Drawing;
using MonoTouch.Foundation;
using MonoTouch.Security;
using MonoTouch.UIKit;

namespace V.TouchIdExample
{
    public partial class VTouchIdExampleViewController : UIViewController
    {
        static bool UserInterfaceIdiomIsPhone
        {
            get { return UIDevice.CurrentDevice.UserInterfaceIdiom == UIUserInterfaceIdiom.Phone; }
        }

        public VTouchIdExampleViewController(IntPtr handle)
            : base(handle)
        {
        }

		/// <summary>
		/// Enable/Disable Touch ID
		/// </summary>
		/// <param name="sender">Sender.</param>
        partial void TouchIdEnableDisable(UISwitch sender)
        {
            if (sender.On)
            {
				//enable Touch ID
                
				//set our record
				//note what you fill in here doesn't matter, just needs to be consistent across all uses of the record
                var secRecord = new SecRecord(SecKind.GenericPassword)
                {
                    Label = "Keychain Item",
                    Description = "fake item for keychain access",
                    Account = "Account",
                    Service = "com.goallineapps.touchIdExample",
                    Comment = "Your comment here",
                    ValueData = NSData.FromString("my-secret-password"),
                    Generic = NSData.FromString("foo")
                };

				secRecord.AccessControl = new SecAccessControl(SecAccessible.WhenPasscodeSetThisDeviceOnly, SecAccessControlCreateFlags.UserPresence);
				SecKeyChain.Add(secRecord);
				                
                authenticateButton.Enabled = true;
            }
            else
            {
                //disable Touch ID
                var record = new SecRecord(SecKind.GenericPassword)
                {
                    Service = "com.goallineapps.touchIdExample",
                    UseOperationPrompt = "Authenticate to Remove Touch ID / Passcode from Test App"
                };

                SecStatusCode result;

                //query one last time to ensure they can remove it
				SecKeyChain.QueryAsRecord(record, out result);
                if (SecStatusCode.Success == result || SecStatusCode.ItemNotFound == result)
                {
                    //remove the record
					SecKeyChain.Remove(record);
                    authenticateButton.Enabled = false;
                }
                else
                {
                    //could not authenticate, leave switch on
                    sender.On = true;
                }                
            }
        }

        /// <summary>
        /// Present Touch ID to user and evaluate authentication
        /// </summary>
        /// <param name="sender">Sender.</param>
        partial void AuthenticateUser(UIButton sender)
        {
            var rec = new SecRecord(SecKind.GenericPassword)
            {
                Service = "com.goallineapps.touchIdExample",
                UseOperationPrompt = "Authenticate to access Test App"
            };
            SecStatusCode res;
            SecKeyChain.QueryAsRecord(rec, out res);
            if (SecStatusCode.Success == res || SecStatusCode.ItemNotFound == res)
            {
				//Success!!  
				//add your code here to continue into your application
                AuthenticatedLabel.Hidden = false;
            }
            else
            {
				//Failure
                AuthenticatedLabel.Hidden = true;
            }
        }

        public override void DidReceiveMemoryWarning()
        {
            // Releases the view if it doesn't have a superview.
            base.DidReceiveMemoryWarning();

            // Release any cached data, images, etc that aren't in use.
        }

        #region View lifecycle

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            // Perform any additional setup after loading the view, typically from a nib.
        }

        public override void ViewWillAppear(bool animated)
        {
            base.ViewWillAppear(animated);
        }

        public override void ViewDidAppear(bool animated)
        {
            base.ViewDidAppear(animated);
        }

        public override void ViewWillDisappear(bool animated)
        {
            base.ViewWillDisappear(animated);
        }

        public override void ViewDidDisappear(bool animated)
        {
            base.ViewDidDisappear(animated);
        }

        #endregion
    }
}