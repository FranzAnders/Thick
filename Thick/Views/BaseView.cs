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

		public bool LoadingFlag {
			get {
				return (bool)GetValue (LoadingFlagProperty);
			}
			set {
				SetValue (LoadingFlagProperty, value);
			}
		}

		public string LoadingText {
			get {
				return (string)GetValue (LodingTextProperty);
			}
			set {
				SetValue (LodingTextProperty, value);
			}
		}

		public static readonly BindableProperty ShowLeftBarButtonProperty = 
			BindableProperty.Create ((BaseView w) => w.ShowLeftFlag, false);
		public static readonly BindableProperty LeftBarButtonTitleProperty = 
			BindableProperty.Create ((BaseView w) => w.LeftTitle, "");
		public static readonly BindableProperty LodingTextProperty = 
			BindableProperty.Create ((BaseView w) => w.LoadingText, "");
		public static readonly BindableProperty LoadingFlagProperty = 
			BindableProperty.Create ((BaseView w) => w.LoadingFlag, false);
		#endregion
	}
}


