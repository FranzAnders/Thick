using System;

using Xamarin.Forms;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Thick
{
	class ExtendedListView : ListView 
	{
		public CrewsView ParentCrewsView { get; set;}

		public ExtendedListView() {}

		public ExtendedListView(CrewsView parent)
		{
			ParentCrewsView = parent;
		}
	}

	class Crew
	{
		public int Index { get; set; }
		public int ParentIndex { get; set; }
		public string Name { get; set; }
		public bool IsOpened { get; set; }
		public bool IsClosed { get; set; }
		public bool IsChild { get; set; }
		public int ChildCount { get; set; }
		public Color TextColor { get; set; }
		public Color BackgroundColor { get; set; }
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
			name.SetBinding (Label.TextColorProperty, "TextColor");

			var closedContactAddButton = new IndexedButton {
				Text = "+",
				FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Label)),
				TextColor = Color.FromRgb (30, 187, 215),
				HorizontalOptions = LayoutOptions.End,
				VerticalOptions = LayoutOptions.Center
			};
			closedContactAddButton.IsVisible = false;
			closedContactAddButton.SetBinding (IndexedButton.ButtonIndexProperty, "Index");
			closedContactAddButton.SetBinding (Button.IsVisibleProperty, "IsClosed");
			closedContactAddButton.Clicked += OnAddContact;

			var openedContactAddButton = new IndexedButton {
				Text = "+",
				FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Label)),
				TextColor = Color.FromRgb (30, 187, 215),
				HorizontalOptions = LayoutOptions.End,
				VerticalOptions = LayoutOptions.Center
			};
			openedContactAddButton.SetBinding (IndexedButton.ButtonIndexProperty, "Index");
			openedContactAddButton.Clicked += OnAddContact;

			var crewDeleteButton = new IndexedButton {
				Text = "-",
				FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Label)),
				TextColor = Color.Red,
				HorizontalOptions = LayoutOptions.End,
				VerticalOptions = LayoutOptions.Center
			};
			crewDeleteButton.SetBinding (IndexedButton.ButtonIndexProperty, "Index");
			crewDeleteButton.Clicked += (object sender, EventArgs e) => {
				IndexedButton button = sender as IndexedButton;
				int index = button.ButtonIndex;
				ExtendedListView listView = Parent as ExtendedListView;
				CrewsView view = listView.ParentCrewsView;
				view.DeleteCrew(index);
			};

			var crewHideButton = new IndexedButton {
				Text = "hide",
				TextColor = Color.Black,
				FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Label)),
				HorizontalOptions = LayoutOptions.End,
				VerticalOptions = LayoutOptions.Center
			};
			crewHideButton.SetBinding (IndexedButton.ButtonIndexProperty, "Index");
			crewHideButton.Clicked += (object sender, EventArgs e) => {
				IndexedButton button = sender as IndexedButton;
				int index = button.ButtonIndex;
				ExtendedListView listView = Parent as ExtendedListView;
				CrewsView view = listView.ParentCrewsView;
				view.HideCrew(index);
			};

			StackLayout crewOpenedButtonLayout = new StackLayout {
				Padding = new Thickness(0, 0, 10, 0),
				Orientation = StackOrientation.Horizontal,
				HorizontalOptions = LayoutOptions.End,
				VerticalOptions = LayoutOptions.Center,
				Children = { openedContactAddButton, crewDeleteButton, crewHideButton }
			};
			crewOpenedButtonLayout.IsVisible = false;
			crewOpenedButtonLayout.SetBinding (StackLayout.IsVisibleProperty, "IsOpened");

			var contactDeleteButton = new IndexedButton {
				Text = "-",
				FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Label)),
				TextColor = Color.Red,
				HorizontalOptions = LayoutOptions.End,
				VerticalOptions = LayoutOptions.Center
			};
			contactDeleteButton.IsVisible = false;
			contactDeleteButton.SetBinding (IndexedButton.ButtonIndexProperty, "Index");
			contactDeleteButton.SetBinding (Button.IsVisibleProperty, "IsChild");
			contactDeleteButton.Clicked += (object sender, EventArgs e) => 
			{
				IndexedButton button = sender as IndexedButton;
				int index = button.ButtonIndex;
				ExtendedListView listView = Parent as ExtendedListView;
				CrewsView view = listView.ParentCrewsView;
				view.DeleteContact(index);
			};

			var viewLayout = new StackLayout () {
				Padding = new Thickness(10, 0, 0, 0),
				Orientation = StackOrientation.Horizontal,
				VerticalOptions = LayoutOptions.Center,
				Children = {name, closedContactAddButton, crewOpenedButtonLayout, contactDeleteButton }
			};

			viewLayout.SetBinding (RelativeLayout.IsVisibleProperty, "HideButton");
			viewLayout.SetBinding (RelativeLayout.BackgroundColorProperty, "BackgroundColor");

			View = viewLayout;
		}

		public async void OnAddContact(object sender, EventArgs e)
		{
			IndexedButton button = sender as IndexedButton;
			int index = button.ButtonIndex;
			ExtendedListView listView = Parent as ExtendedListView;
			CrewsView view = listView.ParentCrewsView;
			await ParentView.ParentView.ParentView.ParentView.ParentView.ParentView.Navigation.PushAsync(new ContactsViewForCrew());
		}
	}

	public class CrewsView : BaseView
	{
		ObservableCollection<Crew> originalSource; 
		ObservableCollection<Crew> realSource;

		ExtendedListView crewListView = new ExtendedListView ();

		public CrewsView ()
		{
			Title = "CREWS";

			originalSource = new ObservableCollection<Crew> ();
			realSource = new ObservableCollection<Crew> ();

			crewListView.ParentCrewsView = this;
			crewListView.SeparatorColor = Color.Transparent;
		
			Crew parentItem = new Crew {Index = 0, ParentIndex = -1, Name = "Crew1", IsChild = false, IsOpened = false, IsClosed = true, ChildCount = 3, BackgroundColor = Color.White};
			originalSource.Add (parentItem);
			for (int i = 0; i < 3; i++) {
				Crew childItem = new Crew {
					Index = i + 1, 
					ParentIndex = 0, 
					Name = "Contact" + (i + 1), 
					IsChild = true, 
					IsOpened = false, 
					IsClosed = false, 
					ChildCount = 0, 
					BackgroundColor = Color.Gray
				};
				originalSource.Add (childItem);
			}
			parentItem = new Crew {Index = 4, ParentIndex = -1, Name = "Crew2", IsChild = false, IsOpened = false, IsClosed = true, ChildCount = 2, BackgroundColor = Color.White};
			originalSource.Add (parentItem);
			for (int i = 0; i < 2; i++) {
				Crew childItem = new Crew {
					Index = i + 5, 
					ParentIndex = 4, 
					Name = "Contact" + (i + 1), 
					IsChild = true, 
					IsOpened = false, 
					IsClosed = false, 
					ChildCount = 0, 
					BackgroundColor = Color.Gray
				};
				originalSource.Add (childItem);
			}

			for (int i = 0; i < originalSource.Count; i++) {
				if (!originalSource[i].IsChild) {
					realSource.Add (originalSource [i]);
				}
			}

			crewListView.ItemsSource = realSource;
			crewListView.ItemTemplate = new DataTemplate (typeof(CrewCell));
			crewListView.ItemTapped += (object sender, ItemTappedEventArgs e) => {
				Crew item = e.Item as Crew;
				if (!item.IsChild) {
					if (!item.IsOpened && (item.ChildCount > 0)) {
						int realCellIndex = realSource.IndexOf(item);
						int originalCellIndex = originalSource.IndexOf(item);
						for (int i = 1; i <= item.ChildCount; i++) {
							realSource.Insert(realCellIndex + i, originalSource[originalCellIndex + i]);
						}
						item.IsOpened = true; item.IsClosed = false;
						realSource[realCellIndex] = item;
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

		public void DeleteContact(int index) 
		{
			Crew crewItem = null;

			for (int i = 0; i < realSource.Count; i++) {
				crewItem = realSource[i];
				if (crewItem.Index == index) {
					realSource.RemoveAt(i);
					break;
				}
			}
			originalSource.Remove(crewItem);

			int parentIndex = crewItem.ParentIndex;

			for (int i = 0; i < realSource.Count; i++) {
				crewItem = realSource[i];
				if (crewItem.Index == parentIndex) {
					crewItem.ChildCount--;
					if (crewItem.ChildCount == 0) {
						crewItem.IsOpened = false;
						crewItem.IsClosed = true;
					}
					realSource [i] = crewItem;
					break;
				}
			}
		}

		public void DeleteCrew(int index)
		{
			int childCount = 0, realIndex = 0;
			for (int i = 0; i < realSource.Count; i++) {
				if (realSource[i].Index == index) {
					realIndex = i;
					break;
				}
			}

			Crew parent = realSource [realIndex];
			childCount = parent.ChildCount;
			for (int i = 1; i <= childCount; i++) {
				Crew crew = realSource[realIndex + childCount - (i - 1)];
				originalSource.Remove (crew);
				realSource.Remove (crew);
			}

			originalSource.Remove (parent);
			realSource.Remove (parent);
		}

		public void HideCrew(int index) 
		{
			int parentIndex = 0;
			Crew crewItem = null;
			for (int i = 0; i < realSource.Count; i++) {
				if (realSource[i].Index == index) {
					parentIndex = i;
					break;
				}
			}
			int childCount = realSource [parentIndex].ChildCount;
			for (int i = 1; i <= childCount; i++) {
				realSource.RemoveAt (parentIndex + childCount - (i - 1));
			}

			crewItem = realSource [parentIndex];
			crewItem.IsClosed = true;
			crewItem.IsOpened = false;
			realSource [parentIndex] = crewItem;
		}
	}
}


