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

            MyApp.OnSignUp();

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
                Debug.WriteLine(result);
                MyApp.OnLogin();
                Debug.WriteLine("Auth complete-----");
            }

            else
            {
                Debug.WriteLine(result);
                Debug.WriteLine("Auth complete-----");
            }
        }
    }
}
