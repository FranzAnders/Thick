using System;

using Xamarin.Forms;
using System.Collections.Generic;

namespace Thick
{
	class Crew
	{
		public int CellIndex { get; set;}
		public string Name { get; set;}
//		public bool CellType
	}

	class IndexedButton : Button {
		public static readonly BindableProperty ButtonIndexProperty = 
			BindableProperty.Create<IndexedButton, int> (w => w.ButtonIndex, default(int));
		public int ButtonIndex {
			get { return (int)GetValue (ButtonIndexProperty); }
			set { SetValue (ButtonIndexProperty, value); }
		}
	}
	
	class CrewCell : ViewCell 
	{
		public CrewCell()
		{
			var name = new Label {
				HorizontalOptions = LayoutOptions.StartAndExpand,
				VerticalOptions = LayoutOptions.Center
			};
			name.SetBinding (Label.TextProperty, "Name");

			var plus = new IndexedButton {
				Text = "+",
				FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Label)),
				TextColor = Color.FromRgb (30, 187, 215),
				HorizontalOptions = LayoutOptions.End,
				VerticalOptions = LayoutOptions.Center
			};

			plus.SetBinding (IndexedButton.ButtonIndexProperty, "CellIndex");

			plus.Clicked += async(object sender, EventArgs e) => {
				IndexedButton button = sender as IndexedButton;
				await ParentView.ParentView.ParentView.ParentView.ParentView.ParentView.Navigation.PushAsync(new ContactsViewForCrew());
			};
				
			var viewLayout = new StackLayout () {
				Padding = new Thickness(20, 0, 0, 0),
				Orientation = StackOrientation.Horizontal,
				VerticalOptions = LayoutOptions.Center,
				Children = {name, plus}
			} ;

			View = viewLayout;
		}
	}
		

	public class CrewsView : BaseView
	{
		public CrewsView ()
		{
			Title = "CREWS";

			ListView crewListView = new ListView ();
			List<Crew> source = new List<Crew> ();
			for (int i = 0; i <= 4; i++) {
				source.Add( new Crew { CellIndex = i, Name = "Crew" + (i + 1) });
			}
			crewListView.ItemsSource = source;
			crewListView.ItemTemplate = new DataTemplate (typeof(CrewCell));
			crewListView.ItemTapped += async (object sender, ItemTappedEventArgs e) => {
//				await this.Content.ParentView.Navigation.PushAsync(new ContactDetailView());
			};

			StackLayout mainLayout = new StackLayout {
				VerticalOptions = LayoutOptions.FillAndExpand,
				Children = {
					crewListView
				}
			};

			Content = mainLayout;
		}
	}
}


