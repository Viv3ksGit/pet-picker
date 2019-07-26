using System.Diagnostics;
using System.Windows.Input;
using PuppyPicker.Classes;
using PuppyPicker.Models;
using PuppyPicker.ENUMS;
using Xamarin.Forms;
using Plugin.Toast;
using System;
using System.Threading.Tasks;
using PuppyPicker.BaseClasses;

namespace PuppyPicker.ViewModels 
{
    public class SettingsPageVM : BaseVM
    {
        public string SP_Title { get; set; }

        public ICommand Image_Size_Handle_Clicked => new Command(ImageSizeClicked);
        public ICommand Notifications_Handle_Clicked => new Command(NotificationsClicked);
        public ICommand Font_Size_Handle_Clicked => new Command(FontSizeClicked);
        public ICommand Themes_Handle_Clicked => new Command(ThemesClicked);

        public SettingsPageVM()
        {
            SP_Title = "Settings";
        }


        private void ImageSizeClicked(object obj)
        {
            MyApp.MainPage.DisplayAlert("", "Coming Soon ", "OK");
        }



        private void NotificationsClicked(object obj)
        {
            MyApp.MainPage.DisplayAlert("", "Coming Soon ", "OK");
        }



        private void FontSizeClicked(object obj)
        {
            MyApp.MainPage.DisplayAlert("", "Coming Soon ", "OK");
        }



        private void ThemesClicked(object obj)
        {
            MyApp.MainPage.DisplayAlert("", "Coming Soon ", "OK");
        }
    }
}
