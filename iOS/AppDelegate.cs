using System;
using System.Collections.Generic;
using System.Linq;

using Foundation;
using UIKit;
using XLabs.Forms.Controls;

namespace Thick.iOS
{
	[Register ("AppDelegate")]
	public partial class AppDelegate : global::Xamarin.Forms.Platform.iOS.FormsApplicationDelegate
	{
		public override bool FinishedLaunching (UIApplication app, NSDictionary options)
		{
			var extLabel = new ExtendedEntryRenderer ();

			global::Xamarin.Forms.Forms.Init ();
			global::Xamarin.FormsMaps.Init ();

			// Code for starting up the Xamarin Test Cloud Agent
			#if ENABLE_TEST_CLOUD
//			Xamarin.Calabash.Start();
			#endif

			LoadApplication (new App ());

			UITabBar.Appearance.TintColor = UIColor.FromRGB (0, 160, 74);
//			UITabBar.Appearance.SelectionIndicatorImage = UIImage.

			return base.FinishedLaunching (app, options);
		}
	}
}

