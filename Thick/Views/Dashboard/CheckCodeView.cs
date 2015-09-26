using System;

using Xamarin.Forms;
using XLabs.Forms.Controls;

namespace Thick
{
	public class CheckCodeView : DashboardBaseView
	{
		ExtendedEntry accessCode;

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
				
			accessCode = new ExtendedEntry {
				Placeholder = "Your access code",
				Keyboard = Keyboard.Numeric,
				MaxLength = 4,
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

		public override async void MoveToNextPage (object sender, EventArgs e)
		{
			if (accessCode.Text == null || accessCode.Text.Length != 4) {
				await DisplayAlert ("Error", "Please enter 4 digits.", "OK");
				return;
			}

			string phoneNumber = BindingContext as string;
			LoadingText = "Verifying the code...";
			LoadingFlag = true;
			JsonResponse response = await App.Server.VerifyPhoneNumber (phoneNumber, accessCode.Text);
			LoadingFlag = false;

			if (response != null) {
				if (response.Code == "Error") {
					await DisplayAlert (response.Code, response.Message, "OK");
				} else if (response.Code == "Success") {
					App.Database.SaveLoginItem (new LoginItem { PhoneNumber = phoneNumber});
					NameView nameView = new NameView ();
					nameView.BindingContext = phoneNumber;
					await Navigation.PushAsync(nameView);
				}
			}
		}
	}
}
