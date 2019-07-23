using System.Diagnostics;
using System.Windows.Input;
using PuppyPicker.Classes;
using PuppyPicker.Models;
using PuppyPicker.ENUMS;
using Xamarin.Forms;
using Android.Widget;
using Plugin.Toast;
using System;
using System.Threading.Tasks;

namespace PuppyPicker.ViewModels
{
    public class LoginPageVM
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

            var result = await serviceConnect.Connect(_user);

            if (result == ServerReplyStatus.Success)
            {
                var myApp = Application.Current as App;
                myApp.OnLogin();

               // CrossToastPopUp.Current.ShowToastSuccess("Sucessfully loggedin");

                await DisplayAlert("Alert", "You have been alerted", "OK");

                Debug.WriteLine("Auth complete-----");
                Debug.WriteLine(result);

            }

            else
            {
                Debug.WriteLine("Auth complete-----");
                Debug.WriteLine(result);

            }




        }

        private Task DisplayAlert(string v1, string v2, string v3)
        {
            throw new NotImplementedException();
        }
    }

}