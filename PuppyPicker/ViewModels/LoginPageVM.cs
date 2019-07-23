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
    public class LoginPageVM : BaseVM
    {
        public string LP_Title { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }

        public ICommand Signin_Handle_Clicked => new Command(SignInClicked);
        public ICommand Signup_Handle_Clicked => new Command(SignUpClicked);

        private void SignUpClicked(object obj)
        {
            var myApp = Application.Current as App;
            myApp.OnSignUp();

        }

        private ServerConnect serviceConnect => new ServerConnect();
        public LoginPageVM()
        {
            LP_Title = "Login Page";
        }

        async public void SignInClicked()
        {
            Debug.WriteLine($"check against username:{Username}, password:{Password}");
            var _user = new UserAuthInfoObject
            {
                Email = Username,
                Password = Password,
                AuthType = AuthType.SignIn,
            };

            IsBusy = true;
            var result = await serviceConnect.Connect(_user);
            IsBusy = false;

            if (result == ServerReplyStatus.Success)
            {
                var myApp = Application.Current as App;
                myApp.OnLogin();

                Debug.WriteLine(result);
                // CrossToastPopUp.Current.ShowToastSuccess("Sucessfully loggedin");
                Debug.WriteLine("Auth complete-----");


            }

            else
            {
                Debug.WriteLine(result);
                var myApp = Application.Current as App;
                await myApp.MainPage.DisplayAlert("Alert!", "Sign up Failed, Try again", "OK");
                Debug.WriteLine("Auth complete-----");
            }
        }
    }
}
