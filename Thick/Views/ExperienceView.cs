using System;

using Xamarin.Forms;

namespace Thick
{
	public class ExperienceView : BaseView
	{
		public ExperienceView ()
		{
			ShowLeftFlag = true;
			LeftTitle = "Back";

			Title = "TO EXPERIENCE";
			Content = new StackLayout { 
				Children = {
					
				}
			};

			ToolbarItems.Add (new ToolbarItem ("Next", "", async () => {
				await Navigation.PushAsync(new ShareEventView());
			}));
		}
	}
}


