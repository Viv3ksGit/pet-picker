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
            else if (this.GetType() == typeof(SupportPage))
            {
                BindingContext = new SupportPageVM();
            }
            else if (this.GetType() == typeof(SettingsPage))
            {
                BindingContext = new SettingsPageVM();
            }
            else if (this.GetType() == typeof(FavoritesPage))
            {
                BindingContext = new FavoritesPageVM();
            }
            else if (this.GetType() == typeof(DogProfilePage))
            {
                BindingContext = new DogProfilePageVM();
            }
            else if (this.GetType() == typeof(MatchPage))
            {
                BindingContext = new MatchPageVM();
            }
            else if (this.GetType() == typeof(MatchHistoryPage))
            {
                BindingContext = new MatchHistoryPageVM();
            }
        }
    }
}

