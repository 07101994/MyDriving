// WARNING
//
// This file has been generated automatically by Xamarin Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//
using Foundation;
using System;
using System.CodeDom.Compiler;
using UIKit;

namespace MyTrips.iOS
{
    [Register ("TripSummaryTableViewController")]
    partial class TripSummaryTableViewController
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton doneButton { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITextField tripNameTextField { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITableView tripSummaryTableView { get; set; }

        [Action ("DoneButton_TouchUpInside:")]
        [GeneratedCode ("iOS Designer", "1.0")]
        partial void DoneButton_TouchUpInside (UIKit.UIButton sender);

        void ReleaseDesignerOutlets ()
        {
            if (doneButton != null) {
                doneButton.Dispose ();
                doneButton = null;
            }

            if (tripNameTextField != null) {
                tripNameTextField.Dispose ();
                tripNameTextField = null;
            }

            if (tripSummaryTableView != null) {
                tripSummaryTableView.Dispose ();
                tripSummaryTableView = null;
            }
        }
    }
}