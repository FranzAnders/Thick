using System;

using Xamarin.Forms;
using Xamarin.Forms.Maps;
using XLabs.Platform.Services.Geolocation;

namespace Thick
{
	public class LocationView : BaseView
	{
		Map map;
		IGeolocator locator;
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

			if (locator.IsGeolocationAvailable) {
				locator.PositionChanged += (object sender, PositionEventArgs e) => ;
			}

			ToolbarItems.Add (new ToolbarItem ("Next", "", async () => {
				await Navigation.PushAsync(new ExperienceView());
			}));
		}
	}
}


