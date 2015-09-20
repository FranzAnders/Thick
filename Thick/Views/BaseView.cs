using System;

using Xamarin.Forms;

namespace Thick
{
	public class BaseView : ContentPage
	{
		public BaseView ()
		{
		}

		#region PROPERTIES
		public bool ShowLeftFlag {
			get {
				return (bool)GetValue (ShowLeftBarButtonProperty);
			}
			set {
				SetValue (ShowLeftBarButtonProperty, value);
			}
		}
		public string LeftTitle {
			get {
				return (string)GetValue (LeftBarButtonTitleProperty);
			}
			set {
				SetValue (LeftBarButtonTitleProperty, value);
			}
		}

		public static readonly BindableProperty ShowLeftBarButtonProperty = 
			BindableProperty.Create ((BaseView w) => w.ShowLeftFlag, false);
		public static readonly BindableProperty LeftBarButtonTitleProperty = 
			BindableProperty.Create ((BaseView w) => w.LeftTitle, "");
		#endregion
	}
}


