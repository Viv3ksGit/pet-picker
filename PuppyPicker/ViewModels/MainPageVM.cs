using System;
using System.Diagnostics;
using System.Windows.Input;
using Xamarin.Forms;
using PuppyPicker.ENUMS;

namespace PuppyPicker.ViewModels
{
    public class MainPageVM
    {
        public string PH_Title { get; set; }
        public ICommand SignupCommand => new Command(OnSignUpClicked);

        public MainPageVM()
        {
            PH_Title = "Puppy Picker app";
        }

        void OnSignUpClicked()
        {
            Debug.WriteLine("sign up clicked");
        }
    }
}
