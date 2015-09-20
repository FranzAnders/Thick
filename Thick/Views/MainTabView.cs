using System;
using Xamarin.Forms;
using XLabs.Forms.Controls;

namespace Thick
{
	public class TabItem : RelativeLayout {
		public int Index;
	}
	public class MainTabView : BaseView
	{
		int currentPageIndex = 0;
		Grid mainGrid;
		RelativeLayout[] tabBarItems = new RelativeLayout[5];
		RelativeLayout[] tabPages = new RelativeLayout[5];
		RelativeLayout currentPage;
		ToolbarItem contactItem, crewItem, settingItem; 
		string[] tabBarItemTitles = {"CONTACTS", "CREWS", "", "FEED", "INS"};
		string[] pageTitles = {"THICK AS THIEVES", "CREW RUN RUN", " ", "WHAT'S GOING ON", "MY INS" };
	
		public MainTabView ()
		{
			NavigationPage.SetHasNavigationBar (this, true);
			Title = pageTitles [0];

			mainGrid = new Grid {
				ColumnSpacing = 0,
				RowSpacing = 0,
				HorizontalOptions = LayoutOptions.FillAndExpand,
				RowDefinitions = {
					new RowDefinition { Height = new GridLength (9, GridUnitType.Star) },
					new RowDefinition { Height = new GridLength (1, GridUnitType.Star) }
				},
				ColumnDefinitions = {
					new ColumnDefinition { Width = new GridLength (1, GridUnitType.Star) },
					new ColumnDefinition { Width = new GridLength (1, GridUnitType.Star) },
					new ColumnDefinition { Width = new GridLength (1, GridUnitType.Star) },
					new ColumnDefinition { Width = new GridLength (1, GridUnitType.Star) },
					new ColumnDefinition { Width = new GridLength (1, GridUnitType.Star) }
				}
			};

			BuildTabBar ();
			BuildPages ();

			contactItem = new ToolbarItem ("+", "", async () => {
				await Navigation.PushAsync(new ContactDetailView());
			});
			crewItem = new ToolbarItem ("+", "", () => {
				
			});
			settingItem = new ToolbarItem ("", "setting_icon.png", async () => {
				await Navigation.PushAsync(new ContactDetailView());
			});


			ToolbarItems.Add (contactItem);

			Content = mainGrid;
		}

		void BuildTabBar()
		{
			for (int i = 0; i < 5; i++) {
				tabBarItems[i] = new TabItem {
					BackgroundColor = Color.FromRgb(197, 179, 87),
					Opacity = 0.9,
					Index = i
				};

				if (i == 2) {
					Image eventIcon = new Image {
						Source = ImageSource.FromResource ("Thick.Resource.Image.event_icon.png"),
						Aspect = Aspect.Fill
					};
					tabBarItems [i].Opacity = 0.7;
					tabBarItems [i].Children.Add (eventIcon,
						Constraint.RelativeToParent ((Parent) => {
							return (Parent.Width - Parent.Height * 0.35) * 0.5;
						}),
						Constraint.RelativeToParent ((Parent) => {
							return Parent.Height * 0.15;
						}),
						Constraint.RelativeToParent ((Parent) => {
							return Parent.Height * 0.35;
						}),
						Constraint.RelativeToParent ((Parent) => {
							return Parent.Height * 0.7;
						})
					);
				}

				Label text = new Label {
					FontSize = 10,
					Text = tabBarItemTitles[i],
					XAlign = TextAlignment.Center,
					YAlign = TextAlignment.Start,
					TextColor = Color.White,
					BackgroundColor = Color.Transparent
				};
				tabBarItems[i].Children.Add (text,
					Constraint.Constant (0),
					Constraint.RelativeToParent ((Parent) => {
						return Parent.Height * 0.68;
					}),
					Constraint.RelativeToParent ((Parent) => {
						return Parent.Width;
					}),
					Constraint.RelativeToParent ((Parent) => {
						return Parent.Height * 0.32;
					})
				);
				Image tabBarItemIcon = new Image {
					Source = ImageSource.FromResource ("Thick.Resource.Image." + tabBarItemTitles[i].ToLower() + "_icon.png"),
					Aspect = Aspect.Fill
				};
				tabBarItems[i].Children.Add (tabBarItemIcon,
					Constraint.RelativeToParent ((Parent) => {
						return (Parent.Width - Parent.Height * 0.6) * 0.5;
					}),
					Constraint.RelativeToParent ((Parent) => {
						return (Parent.Height * 0.68 - Parent.Height * 0.6) * 0.5;
					}),
					Constraint.RelativeToParent ((Parent) => {
						return Parent.Height * 0.6;
					}),
					Constraint.RelativeToParent ((Parent) => {
						return Parent.Height * 0.6;
					})
				);

				mainGrid.Children.Add (tabBarItems [i], i, i + 1, 1, 2);

				TapGestureRecognizer TabBarItemTapGesture = new TapGestureRecognizer ();
				if (i != 2) {
					TabBarItemTapGesture.Tapped += OnTabItem;
				} else {
					TabBarItemTapGesture.Tapped += ShowCurrentEventView;
				}

				tabBarItems [i].GestureRecognizers.Add (TabBarItemTapGesture);
			}
			tabBarItems [0].Opacity = 1.0;
		}

		void BuildPages()
		{
			for (int i = 0; i < 5; i++) {
				tabPages [i] = new RelativeLayout{ };
			}
			////////////	Contact Page
			ContactsView contactsView = new ContactsView();
			tabPages [0].Children.Add (contactsView.Content,
				Constraint.Constant (0),
				Constraint.Constant (0),
				Constraint.RelativeToParent ((Parent) => {
					return Parent.Width;
				}),
				Constraint.RelativeToParent ((Parent) => {
					return Parent.Height;
				})
			);

			////////////	Crew Page
			CrewsView crewsView = new CrewsView ();
		
			tabPages [1].Children.Add (crewsView.Content,
				Constraint.Constant (0),
				Constraint.Constant (0),
				Constraint.RelativeToParent ((Parent) => {
					return Parent.Width;
				}),
				Constraint.RelativeToParent ((Parent) => {
					return Parent.Height;
				})
			);

			////////////	Feed Page
			StackLayout feedLayout = new StackLayout {
			};
			tabPages [3].Children.Add (feedLayout,
				Constraint.Constant (0),
				Constraint.Constant (0),
				Constraint.RelativeToParent ((Parent) => {
					return Parent.Width;
				}),
				Constraint.RelativeToParent ((Parent) => {
					return Parent.Height;
				})
			);

			////////////	Ins Page
			Label name = new Label {
				Text = "ADRIANO",
				TextColor = Color.FromRgb(197, 179, 87)
			};
			Label phoneNumber = new Label {
				Text = "416-722-4321"
			};
			StackLayout nameLayout = new StackLayout {
				Orientation = StackOrientation.Vertical,
				Padding = new Thickness(10, 10, 10, 10),
				Children = {
					name,
					phoneNumber
				}
			};

			Grid insGrid = new Grid {
				RowDefinitions = 
				{
					new RowDefinition { Height = new GridLength(11, GridUnitType.Star)},
					new RowDefinition { Height = new GridLength(5, GridUnitType.Star)},
					new RowDefinition { Height = new GridLength(84, GridUnitType.Star)},
				},
				ColumnDefinitions = {
					new ColumnDefinition {Width = new GridLength(15, GridUnitType.Star)},
					new ColumnDefinition {Width = new GridLength(35, GridUnitType.Star)},
					new ColumnDefinition {Width = new GridLength(50, GridUnitType.Star)},
				}
			};

			Image eventImage = new Image () {
				BackgroundColor = Color.Blue
			};
			RelativeLayout eventLayout = new RelativeLayout {};
			eventLayout.Children.Add (eventImage,
				Constraint.Constant (10),
				Constraint.Constant (10),
				Constraint.RelativeToParent ((Parent) => {
					return Parent.Width - 10;
				}),
				Constraint.RelativeToParent ((Parent) => {
					return Parent.Height - 10;
				})
			);

			insGrid.Children.Add (eventLayout, 0, 1, 0, 1);
			insGrid.Children.Add (nameLayout, 1, 3, 0, 1);
			insGrid.Children.Add (new Label {
				Text = "INS",
				XAlign = TextAlignment.Center,
				YAlign = TextAlignment.Center,
				BackgroundColor = Color.FromRgb (183, 183, 183),
				TextColor = Color.FromRgb(30, 187, 215)
			}, 0, 2, 1, 2);
			insGrid.Children.Add (new Label {
				Text = "NOW LIVE",
				XAlign = TextAlignment.Center,
				YAlign = TextAlignment.Center,
				BackgroundColor = Color.FromRgb (183, 183, 183),
				TextColor = Color.White
			}, 0, 2, 1, 2);

			RelativeLayout insLayout = new RelativeLayout { };
			insGrid.Children.Add (insLayout, 0, 3, 0, 1);

			tabPages [4].Children.Add (insGrid,
				Constraint.Constant (0),
				Constraint.Constant (0),
				Constraint.RelativeToParent ((Parent) => {
					return Parent.Width;
				}),
				Constraint.RelativeToParent ((Parent) => {
					return Parent.Height;
				})
			);
			currentPage = tabPages [0];
			mainGrid.Children.Add (currentPage, 0, 5, 0, 1);
		}

		void OnTabItem (object sender, EventArgs e)
		{
			var item = sender as TabItem;
			if (item.Index != currentPageIndex) {
				tabBarItems [currentPageIndex].Opacity = 0.9;
				mainGrid.Children.Remove (currentPage);
				currentPageIndex = item.Index;
				tabBarItems [currentPageIndex].Opacity = 1.0;
				Title = pageTitles [currentPageIndex];
				ToolbarItems.Clear ();
				currentPage = tabPages [currentPageIndex];

				mainGrid.Children.Add (currentPage, 0, 5, 0, 1);

				switch (item.Index) {
				case 0:
					ToolbarItems.Add (contactItem);
					break;
				case 1:
					ToolbarItems.Add (crewItem);
					break;
				case 4:
					ToolbarItems.Add (settingItem);
					break;
				default:
					break;
				}
			}
		}

		async void ShowContactDetailView (object sender, EventArgs e) {
			await Navigation.PushAsync(new ContactDetailView());
		}

		async void ShowCurrentEventView (object sender, EventArgs e) {
			await Navigation.PushAsync(new CurrentEventView());
		}
	}
}

