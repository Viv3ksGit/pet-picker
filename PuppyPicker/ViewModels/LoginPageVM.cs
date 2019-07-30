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
using PuppyPicker.Tools;

namespace PuppyPicker.ViewModels
{
    public class LoginPageVM : BaseVM
    {
        public string LP_Title { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }


        public ICommand Signin_Handle_Clicked => new Command(SignInClicked);
        public ICommand Signup_Handle_Clicked => new Command(SignUpClicked);
        public ICommand Forgot_Password_Handle_Clicked => new Command(ForgotPasswordClicked);

        private ServerConnect serviceConnect => new ServerConnect();

        public LoginPageVM()
        {
            LP_Title = "Login";
        }


        private void SignUpClicked(object obj)
        {

            MyApp.OnSignUp();

        }

        private void ForgotPasswordClicked(object obj)
        {

            MyApp.OnForgotPassword();

        }

        async public void SignInClicked()
        {

            CheckData();
        }


        async void CheckData()
        {
            //Checking Email input
            if (!StringOperations.ValidateEmailInput(Username))
            {
                await MyApp.MainPage.DisplayAlert("Error!", "Please enter valid email", "ok");
                return;
            }

            //checking the password
            var result = StringOperations.BasicValidation(Password);
            if (result != null)
            {
                await MyApp.MainPage.DisplayAlert("Error!", result, "ok");
                return;
            }

            ContinueSignIn();
        }

        async void ContinueSignIn()
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

            switch (result)
            {
                case ServerReplyStatus.Success:
                    MyApp.OnLogin();
                    break;
                case ServerReplyStatus.NotConfirmed:
                    await MyApp.MainPage.DisplayAlert("Error!", "Email not confirmed, \nPlease check your email to confirm your account", "Ok");
                    break;
                case ServerReplyStatus.InvalidPassword:
                    await MyApp.MainPage.DisplayAlert("Error!", "Invalid password!", "Ok");
                    break;
                case ServerReplyStatus.UserNotFound:
                    await MyApp.MainPage.DisplayAlert("Error!", "Username not found!", "Ok");
                    break;
                default:
                    await MyApp.MainPage.DisplayAlert("Error!", "Something went wrong", "Ok");
                    break;
            }
        }

        
    }
}
