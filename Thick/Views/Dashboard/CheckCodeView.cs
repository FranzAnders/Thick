using System;

using Xamarin.Forms;
using XLabs.Forms.Controls;

namespace Thick
{
	public class CheckCodeView : DashboardBaseView
	{
		public CheckCodeView () : base ("Thick.Resource.Image.dashboard_background2.png", 2)
		{
			Label inform = new Label {
				Text = "We sent your code to (416)731-5560",
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
				
			ExtendedEntry accessCode = new ExtendedEntry {
				Placeholder = "Your access code",
				TextColor = Color.White,
				HasBorder = false,
				PlaceholderTextColor = Color.White,
				BackgroundColor = Color.Transparent
			};

			navigationLayout.Children.Add (backwardArrow,
				Constraint.RelativeToParent ((Parent) => {
					return Parent.Width * 0.02;
				}),
				Constraint.RelativeToParent ((Parent) => {
					return Parent.Height * 0.25;
				}),
				Constraint.RelativeToParent ((Parent) => {
					return Parent.Height * 0.55;
				}),
				Constraint.RelativeToParent ((Parent) => {
					return Parent.Height * 0.5;
				})
			);
			navigationLayout.Children.Add (accessCode,
				Constraint.RelativeToParent ((Parent) => {
					return (Parent.Width - accessCode.Width) * 0.5;
				}),
				Constraint.RelativeToParent ((Parent) => {
					return (Parent.Height - accessCode.Height) * 0.5;
				})
			);
		}
	}
}
