using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace PuppyPicker
{
    public partial class SignupPage : ContentPage
    {
        public SignupPage()
        {
            InitializeComponent();
        }
		void Submit_Handle_Clicked(object sender, System.EventArgs e)
		{
			var myApp = Application.Current as App;
			myApp.OnSubmit();

		}
	}
}
