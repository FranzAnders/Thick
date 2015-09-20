using System;

using Xamarin.Forms;

namespace Thick
{
	public class GetInView : DashboardBaseView
	{
		public GetInView () : base ("Thick.Resource.Image.dashboard_background1.png", 0)
		{
			navigationLayout.GestureRecognizers.Add (base.moveNextHandler);
			Label caption = new Label {
				Text = "Get in",
				TextColor = Color.FromRgb (30, 187, 215)
			};

			navigationLayout.Children.Add (caption, 
				Constraint.RelativeToParent ((Parent) => {
					return Parent.Width * 0.5 - caption.Width - 10;
				}),
				Constraint.RelativeToParent ((Parent) => {
					return Parent.Height * 0.5 - caption.Height * 0.5;
				})
			);
		}
	}
}


