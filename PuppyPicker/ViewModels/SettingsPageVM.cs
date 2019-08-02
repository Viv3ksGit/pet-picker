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

        //Values that will appear in the drop down menus
        string[] ImageSize = { "Small", "Medium", "Large" };
        string[] FontSize = { "Small", "Medium", "Large" };
        string[] ThemeName = { "Default", "Summer", "Beach" };

        public string DefaultImageSize
        {
            get
            {
                //if (settingsImageSize == "")
                //    return("Medium");
                //else
                //    SelectedImageSize = settingsImageSize;
                return settingsImageSize;
            }
        }

        public string DefaultFontSize
        {
            get
            {
                return settingsFontSize;
            }
        }

        public string DefaultThemeName
        {
            get
            {
                return settingsThemeName;
            }

        }

        public string DefaultNotifications
        {
            get
            {
                return settingsNotifications ? "true" : "false";
            }

        }

        public SettingsPageVM()
        {
            SP_Title = "Settings";

        }

        public string[] ImageSizeList
        {
            get {
                return ImageSize; }
            set
            {
                
                if (ImageSize != value)
                {
                    ImageSize = value;
                    OnPropertyChanged();
                   
                }
            }
        }

        public string[] FontSizeList
        {
            get
            {
                return FontSize;
            }
            set
            {

                if (FontSize != value)
                {
                    FontSize = value;
                    OnPropertyChanged();

                }
            }
        }

        public string[] ThemeNameList
        {
            get
            {
                return ThemeName;
            }
            set
            {

                if (ThemeName != value)
                {
                    ThemeName = value;
                    OnPropertyChanged();

                }
            }
        }

        String ImageSizeChoice;
        public string SelectedImageSize
        {
            get { return ImageSizeChoice; }
            set
            {
                if (ImageSizeChoice != value)
                {
                    ImageSizeChoice = value;
                    settingsImageSize = value;
                    OnPropertyChanged();
                }
            }
        }

        String FontSizeChoice;
        public string SelectedFontSize
        {
            get { return FontSizeChoice; }
            set
            {
                if (FontSizeChoice != value)
                {
                    FontSizeChoice = value;
                    settingsFontSize = value;
                    OnPropertyChanged();
                }
            }
        }

        String ThemeNameChoice;
        public string SelectedThemeName
        {
            get { return ThemeNameChoice; }
            set
            {
                if (ThemeNameChoice != value)
                {
                    ThemeNameChoice = value;
                    settingsThemeName = value;
                    OnPropertyChanged();
                }
            }
        }

        //private void NotificationsClicked(object obj)
        //{
        //    MyApp.MainPage.DisplayAlert("", "Coming Soon ", "OK");
        //}



        //private void FontSizeClicked(object obj)
        //{
        //    MyApp.MainPage.DisplayAlert("", "Coming Soon ", "OK");
        //}



        //private void ThemesClicked(object obj)
        //{
        //    MyApp.MainPage.DisplayAlert("", "Coming Soon ", "OK");
        //}
    }
}
