using System;

using Xamarin.Forms;

namespace Thick
{
	public class InsView : BaseView
	{
		Image eventImage;
		public InsView ()
		{
			Title = "INS";

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

			Grid mainGrid = new Grid {
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

			eventImage = new Image () {
				BackgroundColor = Color.Blue
			};
			RelativeLayout genderLayout = new RelativeLayout {};
			genderLayout.Children.Add (eventImage,
				Constraint.Constant (10),
				Constraint.Constant (10),
				Constraint.RelativeToParent ((Parent) => {
					return Parent.Width - 10;
				}),
				Constraint.RelativeToParent ((Parent) => {
					return Parent.Height - 10;
				})
			);

			mainGrid.Children.Add (genderLayout, 0, 1, 0, 1);
			mainGrid.Children.Add (nameLayout, 1, 3, 0, 1);
			mainGrid.Children.Add (new Label {
				Text = "INS",
				XAlign = TextAlignment.Center,
				YAlign = TextAlignment.Center,
				BackgroundColor = Color.FromRgb (183, 183, 183),
				TextColor = Color.FromRgb(30, 187, 215)
			}, 0, 2, 1, 2);
			mainGrid.Children.Add (new Label {
				Text = "NOW LIVE",
				XAlign = TextAlignment.Center,
				YAlign = TextAlignment.Center,
				BackgroundColor = Color.FromRgb (183, 183, 183),
				TextColor = Color.White
			}, 0, 2, 1, 2);

			RelativeLayout insLayout = new RelativeLayout { };
			mainGrid.Children.Add (insLayout, 0, 3, 0, 1);

			Content = mainGrid;

			ToolbarItems.Add (new ToolbarItem ("", "Thick.Resource.Image.setting_icon.png", async () => {

			}));
		}
	}
}