using System;

using Xamarin.Forms;

namespace Thick
{
	public class App : Application
	{
		static MainDatabase database;
		static Communication server;

		public App ()
		{
			// The root page of your application
			MainPage = new NavigationPage (new SplashView()) {
				BarBackgroundColor = Color.FromRgb(197, 179, 87),
				BarTextColor = Color.White
			};
		}

		public static MainDatabase Database {
			get { 
				if (database == null) {
					database = new MainDatabase ();
				}
				return database;
			}
		}

		public static Communication Server {
			get { 
				if (server == null) {
					server = new Communication ();
				}
				return server;
			}
		}

		protected override void OnStart ()
		{
			// Handle when your app starts
		}

		protected override void OnSleep ()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume ()
		{
			// Handle when your app resumes
		}
	}
}

