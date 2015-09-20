using System;

using Xamarin.Forms;

namespace Thick
{
	public class CurrentEventView : BaseView
	{
		bool bNow = true;
		Image nowImage, dateImage;

		public CurrentEventView ()
		{
			ShowLeftFlag = true;
			LeftTitle = "Close";

			Title = "THICK";

			Label when = new Label {
				Text = "When",
				TextColor = Color.Black
			};

			Label now = new Label {
				Text = "Now",
				TextColor = Color.White
			};
			nowImage = new Image {
				Source = ImageSource.FromResource ("Thick.Resource.Image.selected_circle.png"),
				Aspect = Aspect.Fill
			};
			RelativeLayout nowLayout = new RelativeLayout {
				BackgroundColor = Color.FromRgb(197, 179, 87)
			};
			nowLayout.Children.Add (now,
				Constraint.RelativeToParent ((Parent) => {
					return (Parent.Width - now.Width) * 0.5;
				}),
				Constraint.RelativeToParent ((Parent) => {
					return (Parent.Height - now.Height) * 0.5;
				})
			);
			nowLayout.Children.Add (nowImage,
				Constraint.RelativeToParent ((Parent) => {
					return Parent.Width - Parent.Height * 0.85 - 10;
				}),
				Constraint.RelativeToParent ((Parent) => {
					return (Parent.Height * 0.15) * 0.5;
				}),
				Constraint.RelativeToParent ((Parent) => {
					return Parent.Height * 0.85;
				}),
				Constraint.RelativeToParent ((Parent) => {
					return Parent.Height * 0.85;
				})
			);
			TapGestureRecognizer nowGesture = new TapGestureRecognizer ();
			nowGesture.Tapped += (object sender, EventArgs e) => {
				if (!bNow) {
					nowImage.Source = ImageSource.FromResource ("Thick.Resource.Image.selected_circle.png");
					dateImage.Source = ImageSource.FromResource ("Thick.Resource.Image.unselected_circle.png");
					bNow = true;
				}
			};
			nowLayout.GestureRecognizers.Add (nowGesture);

			Image calendar = new Image {
				Source = ImageSource.FromResource ("Thick.Resource.Image.calendar_icon.png"),
				Aspect = Aspect.Fill
			};
			dateImage = new Image {
				Source = ImageSource.FromResource ("Thick.Resource.Image.unselected_circle.png"),
				Aspect = Aspect.Fill
			};
			RelativeLayout dateLayout = new RelativeLayout {
				BackgroundColor = Color.FromRgb(197, 179, 87)
			};
			dateLayout.Children.Add (calendar,
				Constraint.RelativeToParent ((Parent) => {
					return (Parent.Width - Parent.Height * 0.75) * 0.5;
				}),
				Constraint.RelativeToParent ((Parent) => {
					return (Parent.Height * 0.25) * 0.5;
				}),
				Constraint.RelativeToParent ((Parent) => {
					return Parent.Height * 0.75;
				}),
				Constraint.RelativeToParent ((Parent) => {
					return Parent.Height * 0.75;
				})
			);
			dateLayout.Children.Add (dateImage,
				Constraint.RelativeToParent ((Parent) => {
					return Parent.Width - Parent.Height * 0.85 - 10;
				}),
				Constraint.RelativeToParent ((Parent) => {
					return (Parent.Height * 0.15) * 0.5;
				}),
				Constraint.RelativeToParent ((Parent) => {
					return Parent.Height * 0.85;
				}),
				Constraint.RelativeToParent ((Parent) => {
					return Parent.Height * 0.85;
				})
			);
			TapGestureRecognizer dateGesture = new TapGestureRecognizer ();
			dateGesture.Tapped += (object sender, EventArgs e) => {
				if (bNow) {
					nowImage.Source = ImageSource.FromResource ("Thick.Resource.Image.unselected_circle.png");
					dateImage.Source = ImageSource.FromResource ("Thick.Resource.Image.selected_circle.png");
					bNow = false;
				}
			};
			dateLayout.GestureRecognizers.Add (dateGesture);

			TimePicker timePicker = new TimePicker {
				Time = new TimeSpan (17, 0, 0)
			};

			RelativeLayout mainLayout = new RelativeLayout {};
			mainLayout.Children.Add (when,
				Constraint.RelativeToParent ((Parent) => {
					return Parent.Width * 0.06;
				}),
				Constraint.RelativeToParent ((Parent) => {
					return Parent.Height * 0.41;
				})
			);
			mainLayout.Children.Add (nowLayout,
				Constraint.RelativeToParent ((Parent) => {
					return Parent.Width * 0.06;
				}),
				Constraint.RelativeToParent ((Parent) => {
					return Parent.Height * 0.46;
				}),
				Constraint.RelativeToParent ((Parent) => {
					return Parent.Width * 0.88;
				}),
				Constraint.RelativeToParent ((Parent) => {
					return Parent.Height * 0.04;
				})
			);
			mainLayout.Children.Add (dateLayout,
				Constraint.RelativeToParent ((Parent) => {
					return Parent.Width * 0.06;
				}),
				Constraint.RelativeToParent ((Parent) => {
					return Parent.Height * 0.51;
				}),
				Constraint.RelativeToParent ((Parent) => {
					return Parent.Width * 0.88;
				}),
				Constraint.RelativeToParent ((Parent) => {
					return Parent.Height * 0.04;
				})
			);
			mainLayout.Children.Add (timePicker,
				Constraint.Constant(0),
				Constraint.RelativeToParent ((Parent) => {
					return Parent.Height * 0.59;
				})
			);

			ToolbarItems.Add (new ToolbarItem ("Next", "", async () => {
				await Navigation.PushAsync(new LocationView());
			}));

			Content = mainLayout;
		}
	}
}


