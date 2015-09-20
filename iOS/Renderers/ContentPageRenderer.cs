using System;
using System.ComponentModel;
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
		BaseView baseView;
		UIBarButtonItem leftBarButton;

		public override void ViewWillAppear(bool animated)
		{
			base.ViewWillAppear (animated);
			ViewController.ParentViewController.NavigationItem.SetHidesBackButton (true, false);

			if (baseView.ShowLeftFlag) {
				leftBarButton = new UIBarButtonItem ();
				leftBarButton.Clicked += (object s, EventArgs args) => {
					ViewController.NavigationController.PopViewController(true);
				};
				ViewController.ParentViewController.NavigationItem.LeftBarButtonItem = leftBarButton;
				leftBarButton.Title = baseView.LeftTitle;

				if (ViewController.ParentViewController.NavigationItem.RightBarButtonItem != null) {
					ViewController.ParentViewController.NavigationItem.RightBarButtonItem.SetTitleTextAttributes
						(new UITextAttributes {
							TextColor = UIColor.FromRGB (30, 187, 215)
					}, UIControlState.Normal);
				}
			}
		}
		
		void onBack(object sender, EventArgs e) {
			ViewController.NavigationController.PopViewController(true);
		}

		protected override void OnElementChanged (VisualElementChangedEventArgs e)
		{
			base.OnElementChanged (e);

			var page = e.NewElement as BaseView;
			baseView = page;

			page.PropertyChanged += OnElementPropertyChanged;
		}

		private void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
		{
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