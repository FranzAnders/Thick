using System;

using Xamarin.Forms;
using XLabs.Forms.Controls;

namespace Thick
{
	public class NameView : DashboardBaseView
	{
		public NameView () : base ("Thick.Resource.Image.dashboard_background3.png", 3)
		{
			Label inform = new Label {
				Text = "Your name identifies you to your contacts",
				TextColor = Color.FromRgb (30, 187, 215),
				XAlign = TextAlignment.Center,
				WidthRequest = 200
			};
			mainLayout.Children.Add(inform,
				Constraint.RelativeToParent ((Parent) => {
					return (Parent.Width - inform.Width) * 0.5;
				}),
				Constraint.RelativeToParent ((Parent) => {
					return Parent.Height * 0.39;
				})
			);

			ExtendedEntry fullName = new ExtendedEntry {
				Placeholder = "First name | last name",
				TextColor = Color.White,
				PlaceholderTextColor = Color.White,
				BackgroundColor = Color.FromRgb(197, 179, 87),
				HasBorder = false
			};
			navigationLayout.Children.Add (fullName,
				Constraint.RelativeToParent ((Parent) => {
					return Parent.Width * 0.08;
				}),
				Constraint.RelativeToParent ((Parent) => {
					return (Parent.Height - fullName.Height) * 0.5;
				})
			);
		}
	}
}


