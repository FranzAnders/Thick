using System;

using Xamarin.Forms;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Thick
{
	class ExtendedContact
	{
		public int Index { get; set;}
		public string Name { get; set;}
		public bool IsSelected { get; set;}
		public string ImageName { get; set;}
	}

	class ExtendedContactCell : ViewCell 
	{
		public ExtendedContactCell()
		{
			var name = new Label {
				HorizontalOptions = LayoutOptions.StartAndExpand,
				VerticalOptions = LayoutOptions.Center
			};
			name.SetBinding (Label.TextProperty, "ContactName");

			var image = new Image {
				HorizontalOptions = LayoutOptions.End,
				VerticalOptions = LayoutOptions.Center,
				Scale = 0.6
			};
			image.SetBinding (Image.SourceProperty, "ImageName");

			var viewLayout = new StackLayout () {
				Padding = new Thickness(20, 0, 0, 0),
				Orientation = StackOrientation.Horizontal,
				VerticalOptions = LayoutOptions.Center,
				Children = {name, image}
			} ;

			View = viewLayout;
		}
	}

	public class ContactsViewForCrew : BaseView
	{
		public ContactsViewForCrew ()
		{
			Title = "THICK AS THIEVES";

			SearchBar searchBar = new SearchBar {
				Placeholder = "Search"
			};
			Label myNumber = new Label {
				Text = "My Number: +1 (416) 731-5560",
				XAlign = TextAlignment.Center
			};

			ListView contactListView = new ListView ();

			ObservableCollection<ExtendedContact> source = new ObservableCollection<ExtendedContact> ();
			for (int i = 0; i < 30; i++) {
				source.Add(new ExtendedContact { Index = i, Name = "Contact" + (i + 1), IsSelected = false, ImageName = "unselected_circle.png"});
			}
			contactListView.ItemsSource = source;
			contactListView.ItemTemplate = new DataTemplate (typeof(ExtendedContactCell));

			contactListView.ItemTapped += (object sender, ItemTappedEventArgs e) => {
				ExtendedContact contact = e.Item as ExtendedContact;
				contact.IsSelected = !contact.IsSelected;
				if (contact.IsSelected) {
					contact.ImageName = "selected_circle.png";
				}
				else {
					contact.ImageName = "unselected_circle.png";
				}
				source[contact.Index] = contact;
			};

			Label doneButton = new Label {
				BackgroundColor = Color.FromRgb (39, 137, 174),
				TextColor = Color.FromRgb (197, 179, 87),
				Text = "Done",
				XAlign = TextAlignment.Center,
				YAlign = TextAlignment.Center,
				HeightRequest = 60
			};

			TapGestureRecognizer tapGesture = new TapGestureRecognizer ();
			tapGesture.Tapped += (object sender, EventArgs e) => {
				Navigation.PopAsync();
			};
			doneButton.GestureRecognizers.Add (tapGesture);

			StackLayout mainLayout = new StackLayout {
				VerticalOptions = LayoutOptions.FillAndExpand,
				Children = {
					searchBar,
					myNumber,
					contactListView,
					doneButton
				}
			};

			ToolbarItems.Clear ();

			Content = mainLayout;
		}
	}
}
