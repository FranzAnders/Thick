using System;
using Xamarin.Forms;

namespace Thick
{
	public class SettingPage : BaseView
	{
		public SettingPage ()
		{
			string[] settingItemTitle = { "Edit Account", "Push Notification Settings", "Network Status", "System Status", "Report a Problem", "About" };
			ListView contactListView = new ListView ();
			string[] source = new string[30];
			for (int i = 1; i <= 30; i++) {
				source [i - 1] = "Contact" + i;
			}
			contactListView.ItemsSource = source;

			contactListView.ItemTapped += OnSettingItem;

			StackLayout mainLayout = new StackLayout {
				VerticalOptions = LayoutOptions.FillAndExpand,
				Children = {
					contactListView
				}
			};
		}

		async void OnSettingItem(object sender, EventArgs e)
		{
			
		}
	}
}

