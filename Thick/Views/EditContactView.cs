using System;

using Xamarin.Forms;

namespace Thick
{
	public class EditContactView : BaseView
	{

		bool bGender = true;

		Label gender;

		public EditContactView ()
		{
			ShowLeftFlag = true;
			LeftTitle = "CANCEL";

			Grid mainGrid = new Grid {
				RowDefinitions = 
				{
					new RowDefinition { Height = new GridLength(11, GridUnitType.Star)},
					new RowDefinition { Height = new GridLength(89, GridUnitType.Star)}
				}
			};

			Entry firstName = new Entry {
				HorizontalOptions = LayoutOptions.FillAndExpand,
				Text = "ADRIANO",
				Placeholder = "First"
			};
			Entry lastName = new Entry {
				Placeholder = "Last"
			};
			StackLayout nameLayout = new StackLayout {
				Orientation = StackOrientation.Vertical,
				HorizontalOptions = LayoutOptions.FillAndExpand,
				Padding = new Thickness(10, 10, 10, 10),
				Children = {
					firstName,
					lastName
				}
			};

			gender = new Label {
				BackgroundColor = Color.Blue
			};
			TapGestureRecognizer tapGesture = new TapGestureRecognizer ();
			tapGesture.Tapped += (object sender, EventArgs e) => {
				bGender = !bGender;
				if (bGender) {
					gender.BackgroundColor = Color.Blue;
				}
				else {
					gender.BackgroundColor = Color.Pink;
				}
			};
			gender.GestureRecognizers.Add (tapGesture);
			RelativeLayout basicLayout = new RelativeLayout {
//				Padding = new Thickness (10, 10, 10, 10)
			};
			basicLayout.Children.Add (gender,
				Constraint.Constant (10),
				Constraint.Constant (10),
				Constraint.RelativeToParent ((Parent) => {
					return Parent.Width * 0.15 - 10;
				}),
				Constraint.RelativeToParent ((Parent) => {
					return Parent.Height - 10;
				})
			);
			basicLayout.Children.Add (nameLayout,
				Constraint.RelativeToParent ((Parent) => {
					return Parent.Width * 0.15;
				}),
				Constraint.Constant (0)
			);

			mainGrid.Children.Add(basicLayout, 0, 1, 0, 1);
	

			Content = mainGrid;

			ToolbarItems.Add (new ToolbarItem ("DONE", "", async () => {
				await Navigation.PopAsync();
			}));

		}
	}
}


