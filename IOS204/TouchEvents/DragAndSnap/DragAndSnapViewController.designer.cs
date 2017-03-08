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

namespace DragAndSnap
{
    [Register ("DragAndSnapViewController")]
    partial class DragAndSnapViewController
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIView boxOne { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIView boxTwo { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIImageView imgLogo { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (boxOne != null) {
                boxOne.Dispose ();
                boxOne = null;
            }

            if (boxTwo != null) {
                boxTwo.Dispose ();
                boxTwo = null;
            }

            if (imgLogo != null) {
                imgLogo.Dispose ();
                imgLogo = null;
            }
        }
    }
}