using Foundation;
using System;
using System.CodeDom.Compiler;
using UIKit;
using CoreGraphics;

namespace Gestures
{
	partial class GesturesViewController : UIViewController
	{
		private nfloat rotation = 0;

		private nfloat scale = 1;

		private CGPoint translate = new CGPoint();

		public GesturesViewController(IntPtr handle) : base(handle)
		{
		}

		public override void ViewDidLoad()
		{
			base.ViewDidLoad();

			var rotationGesture = new UIRotationGestureRecognizer(HandleRotation);
			this.View.AddGestureRecognizer(rotationGesture);

			var pinchGesture = new UIPinchGestureRecognizer(HandlePinch);
			this.View.AddGestureRecognizer(pinchGesture);

			var panGesture = new UIPanGestureRecognizer(HandlePan);
			this.View.AddGestureRecognizer(panGesture);

			// Set the ShouldRecognizeSimultaneously delegate for both gestures 
			// to the ShouldRecognizeSimultaneously method we just created
			// run the app
			rotationGesture.ShouldRecognizeSimultaneously = ShouldRecognizeSimultaneously;
			pinchGesture.ShouldRecognizeSimultaneously = ShouldRecognizeSimultaneously;
			panGesture.ShouldRecognizeSimultaneously = ShouldRecognizeSimultaneously;
		}

		// In order to execute more than one gesture simultaniously, 
		// We'll need to handle the "ShouldRecognizeSimultaniously property on each gesture
		// For this exercise we'll set the delegates to a named method and return true for all cases
		public bool ShouldRecognizeSimultaneously(UIGestureRecognizer gestureRecognizer, UIGestureRecognizer otherGestureRecognizer)
		{
			return true;
		}

		void HandleRotation(UIRotationGestureRecognizer gesture)
		{
			// Save the Rotation value 
			this.rotation = gesture.Rotation;
			// and call UpdateTransform
			UpdateTransform();
		}

		void HandlePinch(UIPinchGestureRecognizer gesture)
		{
			// Save the scale value from the gesture recognizer
			// And apply some basic bounds checking so it doesn't get to large or to small
			// For the scale value, we're going to look at relative changes 
			// so we'll multiply our class level property instead of just setting it
			this.scale *= gesture.Scale;

			//bounds checking
			if (scale > 2.5f)
				scale = 2.5f;
			else if (scale < 0.01)
				scale = 0.1f;

			// And we'll set the gesture's Scale value back to 1
			// because we're looking for relative changes
			gesture.Scale = 1;

			// And again call UpdateTransform
			UpdateTransform();
		}

		void HandlePan(UIPanGestureRecognizer gesture)
		{
			if (gesture.State == UIGestureRecognizerState.Began)
				gesture.SetTranslation(translate, this.View);

			var pos = gesture.TranslationInView(this.View);

			translate = pos;

			UpdateTransform();
		}

		void UpdateTransform()
		{
			var transform = CGAffineTransform.MakeIdentity();

			transform.Rotate(rotation);

			transform.Scale(scale, scale);

			transform.Translate(translate.X, translate.Y);

			imgLogo.Transform = transform;
		}
	}
}
