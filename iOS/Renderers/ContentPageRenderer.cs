using System;
using System.ComponentModel;
using System.Drawing;
using Xamarin.Forms.Platform.iOS;
using Xamarin.Forms;
using Thick;
using Thick.iOS;
using UIKit;

[assembly: ExportRenderer(typeof(BaseView), typeof(ContentPageRenderer))]

namespace Thick.iOS
{
	public class ContentPageRenderer : PageRenderer
	{
		BaseView MainBaseView;
		UIBarButtonItem leftBarButton;
		UIView MainUIView = null;
		UIView LoadingView = null;
		string LoadingText = null;

		public override void ViewWillAppear(bool animated)
		{
			base.ViewWillAppear (animated);
			ViewController.ParentViewController.NavigationItem.SetHidesBackButton (true, false);

			if (MainBaseView.ShowLeftFlag) {
				leftBarButton = new UIBarButtonItem ();
				leftBarButton.Clicked += (object s, EventArgs args) => {
					ViewController.NavigationController.PopViewController(true);
				};
				ViewController.ParentViewController.NavigationItem.LeftBarButtonItem = leftBarButton;
				leftBarButton.Title = MainBaseView.LeftTitle;

				if (ViewController.ParentViewController.NavigationItem.RightBarButtonItem != null) {
					ViewController.ParentViewController.NavigationItem.RightBarButtonItem.SetTitleTextAttributes
						(new UITextAttributes {
							TextColor = UIColor.FromRGB (30, 187, 215)
					}, UIControlState.Normal);
				}
			}
//			PhoneService phoneService = new PhoneService ();
//			string str = phoneService.ICC;
		}
		
		void onBack(object sender, EventArgs e) {
			ViewController.NavigationController.PopViewController(true);
		}

		protected override void OnElementChanged (VisualElementChangedEventArgs e)
		{
			base.OnElementChanged (e);

			var page = e.NewElement as BaseView;
			MainBaseView = page;
			MainUIView = NativeView;

			page.PropertyChanged += OnElementPropertyChanged;
		}

		private void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
		{
			if (e.PropertyName == BaseView.LodingTextProperty.PropertyName) {
				LoadingText = MainBaseView.LoadingText;
			}
			if (e.PropertyName == BaseView.LoadingFlagProperty.PropertyName && MainBaseView!= null && MainUIView != null) {
				bool isShow = MainBaseView.LoadingFlag;
				if (isShow == true) {
					LoadingView = new UIView ();
					LoadingView.Frame = new RectangleF (0, 0, (float)MainUIView.Frame.Width, (float)MainUIView.Frame.Height);
					LoadingView.Alpha = 0.5f;
					LoadingView.BackgroundColor = UIColor.Black;

					var label = new UILabel (new RectangleF ((float)MainUIView.Frame.Width / 2 - 100, (float)MainUIView.Frame.Height / 2 - 20, 200, 40));
					label.AdjustsFontSizeToFitWidth = true;
					label.TextColor = UIColor.White;
					label.TextAlignment = UITextAlignment.Center;
					label.Text = LoadingText;

					LoadingView.Add (label);

					MainUIView.Add (LoadingView);
					MainUIView.BringSubviewToFront (LoadingView);
				} else {
					if (LoadingView != null) {
						LoadingView.RemoveFromSuperview ();
					}
				}
			}
/*			if (e.PropertyName == BaseView.ShowLeftBarButtonProperty.PropertyName) {
				if (baseView.ShowLeftFlag) {
					leftBarButton = new UIBarButtonItem ();
					leftBarButton.Clicked += (object s, EventArgs args) => {
						ViewController.NavigationController.PopViewController(true);
					};
					ViewController.ParentViewController.NavigationItem.LeftBarButtonItem = leftBarButton;
				}
			}
			if (e.PropertyName == BaseView.LeftBarButtonTitleProperty.PropertyName) {
				leftBarButton.Title = baseView.LeftTitle;
			}*/
		}
	}
}