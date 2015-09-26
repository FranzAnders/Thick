using System;

using Xamarin.Forms;
using System.Threading.Tasks;

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
				await SetGender(true);
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
				await SetGender(false);
			};
			femaleButton.GestureRecognizers.Add (femaleGesture);
		}

		public async Task SetGender(bool bMale)
		{
			string phoneNumber = BindingContext as string;
			string gender;
			if (bMale) {
				gender = "1";
			} else {
				gender = "0";
			}

			LoadingText = "Sending data to server...";
			LoadingFlag = true;
			JsonResponse response = await App.Server.SaveGender (phoneNumber, gender);
			LoadingFlag = false;
			if (response != null) {
				if (response.Code == "Error") {
					await DisplayAlert (response.Code, response.Message, "OK");
				} else if (response.Code == "Success") {
					AllowView allowView = new AllowView ();
					allowView.BindingContext = phoneNumber;
					await Navigation.PushAsync(allowView);
				}
			}
		}
	}
}


