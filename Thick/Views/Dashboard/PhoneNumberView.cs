using System;

using Xamarin.Forms;
using XLabs.Forms.Controls;
using XLabs.Platform.Services;
using System.Threading.Tasks;

namespace Thick
{
	public class PhoneNumberView : DashboardBaseView
	{
		ExtendedEntry phoneNumber;

		public PhoneNumberView () : base ("Thick.Resource.Image.dashboard_background2.png", 1)
		{
			Label inform = new Label {
				Text = "We'll send you a message with a 4 digit access code",
				TextColor = Color.FromRgb (30, 187, 215),
				XAlign = TextAlignment.Center,
				WidthRequest = 240
			};
			mainLayout.Children.Add(inform,
				Constraint.RelativeToParent ((Parent) => {
					return (Parent.Width - inform.Width) * 0.5;
				}),
				Constraint.RelativeToParent ((Parent) => {
					return Parent.Height * 0.39;
				})
			);

			Label prefix = new Label {
				Text = "+1",
				FontSize = Device.GetNamedSize(NamedSize.Small, typeof(Label)),
				TextColor = Color.White
			};
					
//			#if __iOS__
//				
//			#endif

			phoneNumber = new ExtendedEntry() {
				Placeholder = "Your phone number",
				TextColor = Color.White,
				Keyboard = Keyboard.Telephone,
				HasBorder = false,
				PlaceholderTextColor = Color.White,
				BackgroundColor = Color.Transparent
			};

			navigationLayout.Children.Add (prefix,
				Constraint.RelativeToParent ((Parent) => {
					return Parent.Width * 0.02;
				}),
				Constraint.RelativeToParent ((Parent) => {
					return (Parent.Height - prefix.Height) * 0.5;
				})
			);
			navigationLayout.Children.Add (phoneNumber,
				Constraint.RelativeToParent ((Parent) => {
					return Parent.Width * 0.13;
				}),
				Constraint.RelativeToParent ((Parent) => {
					return (Parent.Height - phoneNumber.Height) * 0.5;
				})
			);

			navigationLayout.Children.Add (forwardArrow, 
				Constraint.RelativeToParent ((Parent) => {
					return Parent.Width * 0.98 - Parent.Height * 0.55;
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
		}

		public override async void MoveToNextPage (object sender, EventArgs e)
		{
			if (phoneNumber.Text == null) {
				await DisplayAlert ("Error", "Please enter your phone number.", "OK");
				return;
			}

			string number = phoneNumber.Text;
			number = "+17543336811";

			LoadingText = "Sending your phone number to server...";
			LoadingFlag = true;
			JsonResponse response = await App.Server.SendPhoneNumber (number);
			LoadingFlag = false;

			if (response != null) {
				if (response.Code == "Verify") {
					CheckCodeView checkCodeView = new CheckCodeView ();
					checkCodeView.BindingContext = number;
					await Navigation.PushAsync(checkCodeView);
				}
			}
		}
	}
}
