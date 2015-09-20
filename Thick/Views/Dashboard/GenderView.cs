using System;

using Xamarin.Forms;

namespace Thick
{
	public class GenderView : DashboardBaseView
	{
		public GenderView () : base ("Thick.Resource.Image.dashboard_background3.png", 4)
		{
			Label inform = new Label {
				Text = "Select the gender you identify with",
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

			Image maleButton = new Image {
				Source = ImageSource.FromResource ("Thick.Resource.Image.male.png"),
				Aspect = Aspect.Fill
			};
			mainLayout.Children.Add (maleButton,
				Constraint.RelativeToParent ((Parent) => {
					return Parent.Width * 0.21;
				}),
				Constraint.RelativeToParent ((Parent) => {
					return Parent.Height * 0.51;
				}),
				Constraint.RelativeToParent ((Parent) => {
					return Parent.Width * 0.2;
				}),
				Constraint.RelativeToParent ((Parent) => {
					return Parent.Height * 0.09;
				})
			);
			TapGestureRecognizer maleGesture = new TapGestureRecognizer ();
			maleGesture.Tapped += async (object sender, EventArgs e) => {
				await Navigation.PushAsync(new AllowView());	
			};
			maleButton.GestureRecognizers.Add (maleGesture);

			Image femaleButton = new Image {
				Source = ImageSource.FromResource ("Thick.Resource.Image.female.png"),
				Aspect = Aspect.Fill
			};
			mainLayout.Children.Add (femaleButton,
				Constraint.RelativeToParent ((Parent) => {
					return Parent.Width * 0.54;
				}),
				Constraint.RelativeToParent ((Parent) => {
					return Parent.Height * 0.51;
				}),
				Constraint.RelativeToParent ((Parent) => {
					return Parent.Width * 0.2;
				}),
				Constraint.RelativeToParent ((Parent) => {
					return Parent.Height * 0.09;
				})
			);
			TapGestureRecognizer femaleGesture = new TapGestureRecognizer ();
			femaleGesture.Tapped += async (object sender, EventArgs e) => {
				await Navigation.PushAsync(new AllowView());	
			};
			femaleButton.GestureRecognizers.Add (femaleGesture);
		}
	}
}


