using System;

using Xamarin.Forms;

namespace Thick
{
	public class MainEventView : BaseView
	{
		public MainEventView ()
		{
			Content = new StackLayout { 
				Children = {
					new Label { Text = "Hello ContentPage" }
				}
			};
		}
	}
}


