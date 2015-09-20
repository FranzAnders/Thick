using System;

using Xamarin.Forms;

namespace Thick
{
	public class ContactsView : BaseView
	{
		public ContactsView ()
		{
			Title = "CONTACTS";

			SearchBar searchBar = new SearchBar {
				Placeholder = "Search"
			};
			Label myNumber = new Label {
				Text = "My Number: +1 (416) 731-5560",
				XAlign = TextAlignment.Center
			};

			ListView contactListView = new ListView ();
			string[] source = new string[30];
			for (int i = 1; i <= 30; i++) {
				source [i - 1] = "Contact" + i;
			}
			contactListView.ItemsSource = source;

			contactListView.ItemTapped += ShowContactDetailView;

			StackLayout mainLayout = new StackLayout {
				VerticalOptions = LayoutOptions.FillAndExpand,
				Children = {
					searchBar,
					myNumber,
					contactListView
				}
			};

			Content = mainLayout;
		}

		async void ShowContactDetailView (object sender, EventArgs e) {
			await Content.ParentView.Navigation.PushAsync(new ContactDetailView());
		}
	}
}
