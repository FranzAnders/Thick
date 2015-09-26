using System;

using Xamarin.Forms;

namespace Thick
{
	public class DashboardBaseView : BaseView
	{
		public TapGestureRecognizer moveNextHandler;
		public RelativeLayout navigationLayout, mainLayout;
		public Image forwardArrow, backwardArrow;
		int index;

		public DashboardBaseView ()
		{
		}

		public DashboardBaseView (string resourceId, int pageIndex) 
		{
			NavigationPage.SetHasNavigationBar (this, false);

			index = pageIndex;
			Image mainBackground = new Image {
				Source = ImageSource.FromResource (resourceId),
				Aspect = Aspect.Fill
			};
			Image getInBackground = new Image {
				Source = ImageSource.FromResource ("Thick.Resource.Image.round_rectangle.png"),
				Aspect = Aspect.Fill
			};
			forwardArrow = new Image {
				Source = ImageSource.FromResource ("Thick.Resource.Image.forward_arrow.png"),
				Aspect = Aspect.Fill
			};

			backwardArrow = new Image {
				Source = ImageSource.FromResource ("Thick.Resource.Image.backward_arrow.png"),
				Aspect = Aspect.Fill
			};

			TapGestureRecognizer movePrevHandler = new TapGestureRecognizer ();
			movePrevHandler.Tapped += MoveToPrevPage;
			backwardArrow.GestureRecognizers.Add (movePrevHandler);

			navigationLayout = new RelativeLayout ();
			navigationLayout.Children.Add (getInBackground, 
				Constraint.Constant (0),
				Constraint.Constant (0),
				Constraint.RelativeToParent ((Parent) => {
					return Parent.Width;
				}),
				Constraint.RelativeToParent ((Parent) => {
					return Parent.Height;
				}));

			if (index == 0) {
				navigationLayout.Children.Add (forwardArrow, 
					Constraint.RelativeToParent ((Parent) => {
						return Parent.Width * 0.5 + 10;
					}),
					Constraint.RelativeToParent ((Parent) => {
						return Parent.Height * 0.25;
					}),
					Constraint.RelativeToParent ((Parent) => {
						return Parent.Height * 0.55;
					}),
					Constraint.RelativeToParent ((Parent) => {
						return Parent.Height * 0.5;
					})
				);
			} else {
				navigationLayout.Children.Add (forwardArrow, 
					Constraint.RelativeToParent ((Parent) => {
						return Parent.Width * 0.98 - Parent.Height * 0.55;
					}),
					Constraint.RelativeToParent ((Parent) => {
						return Parent.Height * 0.25;
					}),
					Constraint.RelativeToParent ((Parent) => {
						return Parent.Height * 0.55;
					}),
					Constraint.RelativeToParent ((Parent) => {
						return Parent.Height * 0.5;
					})
				);
			}

			moveNextHandler = new TapGestureRecognizer ();
			moveNextHandler.Tapped += MoveToNextPage;
			forwardArrow.GestureRecognizers.Add (moveNextHandler);

			mainLayout = new RelativeLayout ();

			mainLayout.Children.Add (mainBackground, 
				Constraint.Constant (0),
				Constraint.Constant (0),
				Constraint.RelativeToParent ((Parent) => {
					return Parent.Width;
				}),
				Constraint.RelativeToParent ((Parent) => {
					return Parent.Height;
				}));
			if (index != 4) {
				mainLayout.Children.Add (navigationLayout, 
					Constraint.RelativeToParent ((Parent) => {
						return Parent.Width * 0.04;
					}),
					Constraint.RelativeToParent ((Parent) => {
						return Parent.Height * 0.5;
					}),
					Constraint.RelativeToParent ((Parent) => {
						return Parent.Width * 0.92;
					}),
					Constraint.RelativeToParent ((Parent) => {
						return Parent.Height * 0.1;
					}));
			}

			Content = mainLayout;
		}

		public virtual void MoveToNextPage (object sender, EventArgs e) {}

		void MoveToPrevPage (object sender, EventArgs e)
		{
			Navigation.PopAsync ();
		}
	}
}