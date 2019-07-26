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
<<<<<<< HEAD
            else if (this.GetType() == typeof(SupportPage))
            {
                BindingContext = new SupportPageVM();
=======
            else if (this.GetType() == typeof(SettingsPage))
            {
                BindingContext = new SettingsPageVM();
>>>>>>> 6ef7f1c9e784a0cc3fd82338c97f2b18996c54d9
            }

        }
    }
}

