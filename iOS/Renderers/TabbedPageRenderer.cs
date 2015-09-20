using System;
using Xamarin.Forms.Platform.iOS;
using Xamarin.Forms;
using Thick;
using Thick.iOS;

[assembly: ExportRenderer(typeof(TabbedPage), typeof(TabbedPageRenderer))]

namespace Thick.iOS
{
	public class TabbedPageRenderer : TabbedRenderer
	{
		public TabbedPageRenderer ()
		{
			TabBar.BarTintColor = UIKit.UIColor.FromRGB (197, 179, 87);
		}
	}
}

