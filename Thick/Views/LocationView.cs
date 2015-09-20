using System;

using Xamarin.Forms;
using Xamarin.Forms.Maps;

namespace Thick
{
	public class LocationView : BaseView
	{
		Map map;
		public LocationView ()
		{
			ShowLeftFlag = true;
			LeftTitle = "Back";

			Title = "OF THINGS";
			map = new Map (
				MapSpan.FromCenterAndRadius(
					new Position(37, -122), Distance.FromMiles(0.3))) {
					IsShowingUser = true,
					HeightRequest = 100,
					WidthRequest = 960,
					VerticalOptions = LayoutOptions.FillAndExpand
				};

			Content = new StackLayout { 
				Children = {
					map
				}
			};

			ToolbarItems.Add (new ToolbarItem ("Next", "", async () => {
				await Navigation.PushAsync(new ExperienceView());
			}));
		}
	}
}


