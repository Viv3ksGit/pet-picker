using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace PuppyPicker
{
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            InitializeComponent();
        }

		void Signin_Handle_Clicked(object sender, System.EventArgs e)
		{
			var myApp = Application.Current as App;
			myApp.OnLogin();

		}
		void Signup_Handle_Clicked(object sender, System.EventArgs e)
		{
			var myApp = Application.Current as App;
			myApp.OnSignUp();

		}
	}
}
