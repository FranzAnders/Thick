using System;

using Xamarin.Forms;
using System.Collections.Generic;

namespace Thick
{
	class Crew
	{
		public int Index { get; set;}
		public string Name { get; set;}
		public bool IsOpened { get; set;}
		public bool IsCrew { get; set; }
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

			plus.SetBinding (IndexedButton.ButtonIndexProperty, "Index");

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
			List<Crew> originalSource = new List<Crew> ();
			List<Crew> realSource = new List<Crew> ();
//			for (int i = 0; i <= 4; i++) {
//				originalSource.Add( new Crew { Index = i, Name = "Crew" + (i + 1), IsCrew = true, IsOpened = false });
//			}
			originalSource.Add( new Crew { Index = 0, Name = "Crew1", IsCrew = true, IsOpened = false });
			originalSource.Add( new Crew { Index = 1, Name = "Contact1", IsCrew = false, IsOpened = false });
			originalSource.Add( new Crew { Index = 2, Name = "Contact2", IsCrew = false, IsOpened = false });
			originalSource.Add( new Crew { Index = 3, Name = "Contact3", IsCrew = true, IsOpened = false });
			originalSource.Add( new Crew { Index = 4, Name = "Crew2", IsCrew = true, IsOpened = false });
			originalSource.Add( new Crew { Index = 5, Name = "Contact3", IsCrew = true, IsOpened = false });
			originalSource.Add( new Crew { Index = 6, Name = "Contact4", IsCrew = true, IsOpened = false });

			for (int i = 0; i < originalSource.Count; i++) {
				if (originalSource[i].IsCrew) {
					realSource.Add (originalSource [i]);
				}
			}

			crewListView.ItemsSource = realSource;
			crewListView.ItemTemplate = new DataTemplate (typeof(CrewCell));
			crewListView.ItemTapped += async (object sender, ItemTappedEventArgs e) => {
				Crew item = e.Item as Crew;
				if (item.IsCrew) {
					if (!item.IsOpened) {
						for (int i = 0; i < ; i++) {
							
						}
					}
				}

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


