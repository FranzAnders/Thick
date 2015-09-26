using System;

using Xamarin.Forms;

namespace Thick
{
	public class AllowView : DashboardBaseView
	{
		public AllowView () : base ("Thick.Resource.Image.dashboard_background4.png", 5)
		{
			Label inform = new Label {
				Text = "Turn on Notifications and Location Tracking",
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

			navigationLayout.GestureRecognizers.Add (base.moveNextHandler);

			Label caption = new Label {
				Text = "Allow",
				TextColor = Color.White
			};

			navigationLayout.Children.Add (caption, 
				Constraint.RelativeToParent ((Parent) => {
					return Parent.Width * 0.5 - caption.Width * 0.5;
				}),
				Constraint.RelativeToParent ((Parent) => {
					return Parent.Height * 0.5 - caption.Height * 0.5;
				})
			);
		}

		public override async void MoveToNextPage (object sender, EventArgs e) {
			await Navigation.PushAsync(new MainTabView());
		}
	}
}


