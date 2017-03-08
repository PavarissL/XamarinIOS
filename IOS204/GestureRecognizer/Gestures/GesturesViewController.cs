using Foundation;
using System;
using System.CodeDom.Compiler;
using UIKit;
using CoreGraphics;

namespace Gestures
{
	partial class GesturesViewController : UIViewController
	{
		// Add a private property to track position
		private CGPoint translate = new CGPoint();

		public GesturesViewController(IntPtr handle) : base(handle)
		{
		}

		public override void ViewDidLoad()
		{
			base.ViewDidLoad();

			var panGesture = new UIPanGestureRecognizer(HandlePan);
			this.View.AddGestureRecognizer(panGesture);
		}

		void HandlePan(UIPanGestureRecognizer gesture)
		{
			if (gesture.State == UIGestureRecognizerState.Began)
				gesture.SetTranslation(translate, this.View);

			// Read the translation value from the gesture recognizer
			var pos = gesture.TranslationInView(this.View);

			// and save it to our class level translate property
			translate = pos;

			// and call UpdateTransform ()
			UpdateTransform();
		}

		void UpdateTransform()
		{
			// Create a CGAffineTransform which we'll apply to our target image
			var transform = CGAffineTransform.MakeIdentity();

			// Call the translate method of the transform passing in our translation
			transform.Translate(translate.X, translate.Y);

			// Set the Transform property on our image to our new CGAffineTransform
			// This won't have any effect yet
			imgLogo.Transform = transform;
		}
	}
}
