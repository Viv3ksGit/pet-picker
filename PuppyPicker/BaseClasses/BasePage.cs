using System;
using System.Diagnostics;
using PuppyPicker.ViewModels;
using Xamarin.Forms;

namespace PuppyPicker.BaseClasses
{
    public class BasePage : ContentPage
    {
        public App MyApp = Application.Current as App;
        public BasePage()
        {
            SetbindingContext();
        }

        private void SetbindingContext()
        {
            if (this.GetType() == typeof(MainPage))
            {
                //BindingContext = Activator.CreateInstance(typeof(MainPageVM));
                BindingContext = new MainPageVM();
            }
            else if (this.GetType() == typeof(LoginPage))
            {
                BindingContext = new LoginPageVM();
            }
            else if (this.GetType() == typeof(SignupPage))
            {
                BindingContext = new SignupPageVM();
            }

        }
    }
}

