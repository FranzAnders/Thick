using System;

using Xamarin.Forms;

namespace Thick
{
	public class ShareEventView : BaseView
	{
		public ShareEventView ()
		{
			ShowLeftFlag = true;
			LeftTitle = "Back";

			Title = "WITH THE BEST I KNOW";
			Content = new StackLayout { 
				Children = {
					new Label { Text = "Hello ContentPage" }
				}
			};
		}
	}
}


