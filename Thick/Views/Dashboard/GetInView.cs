using System;
using System.Linq;

using Xamarin.Forms;
using System.Collections.Generic;

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

		public override async void MoveToNextPage (object sender, EventArgs e){
			List<LoginItem> loginItems = new List<LoginItem> ();
			loginItems = App.Database.GetLoginItems() as List<LoginItem>;
			if (loginItems.Count == 0) {
				await Navigation.PushAsync (new PhoneNumberView ());
			} else {
				string phoneNumber = loginItems [0].PhoneNumber;LoadingText = "Loading...";
				LoadingFlag = true;
				JsonResponse response = await App.Server.SendPhoneNumber (phoneNumber);
				LoadingFlag = false;
				if (response != null) {
					if (response.Code == "Success") {
						if (response.Data.Gender != "") {
							await Navigation.PushAsync (new MainTabView ());
						} else {
							if (response.Data.FirstName == "") {
								NameView nameView = new NameView ();
								nameView.BindingContext = phoneNumber;
								await Navigation.PushAsync (nameView);
							} else {
								GenderView genderView = new GenderView ();
								genderView.BindingContext = phoneNumber;
								await Navigation.PushAsync (genderView);
							}
						}
					}
				}
			}
		}
	}
}


