using System;

using Xamarin.Forms;

namespace Thick
{
	public class AddCommentView : BaseView
	{
		public AddCommentView ()
		{
			Content = new StackLayout { 
				Children = {
					new Label { Text = "Hello ContentPage" }
				}
			};
		}
	}
}


