using System.Diagnostics;
using System.Windows.Input;
using PuppyPicker.Classes;
using PuppyPicker.Models;
using PuppyPicker.ENUMS;
using Plugin.Toast;
using PuppyPicker.Tools;
using Xamarin.Forms;
using PuppyPicker.BaseClasses;
using System;
using System.Threading.Tasks;

namespace PuppyPicker.ViewModels
{
    public class SignupPageVM : BaseVM
    {
        public ICommand Submit_Handle_Clicked => new Command(SignUpClicked);
        public ICommand Signin_Handle_Clicked => new Command(SignInClicked);
        //public string SP_Title { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string EmailId { get; set; }
        public string PasswordVerif { get; set; }

        private ServerConnect serviceConnect => new ServerConnect();

        public SignupPageVM()
        {
           // SP_Title = "Signup";
        }

    

        async void SignUpClicked()
        {

            DataCheck();
        }

        async void DataCheck()
        {
            var usertype = StringOperations.BasicValidation(UserName);
            if(usertype != null)
            {
                await MyApp.MainPage.DisplayAlert("Username field should be empty or less than 3 chars", usertype, "ok");
                return;
            }


            //Checking Email input
            if (!StringOperations.ValidateEmailInput(EmailId))
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

            if (!StringOperations.ValidatePasswordInput(Password))
            {
                await MyApp.MainPage.DisplayAlert("Error!", "Password policy mismatch", "ok");
                return;
            }


            if (Password != PasswordVerif)
            {
                await MyApp.MainPage.DisplayAlert("Error!", "Password verify mismatch", "ok");
                return;
            }

            ContinueSignUp();
        }

        

        async void ContinueSignUp()
        {
            Debug.WriteLine($"am sign up clicked: username:{UserName}, password:{Password}, email id:{EmailId}");
            var _user = new UserAuthInfoObject
            {
                User = UserName,
                Email = EmailId,
                Password = Password,
                AuthType = AuthType.SignUp,
            };

            IsBusy = true;

            TestAsync();

            var result = await serviceConnect.Connect(_user);

            IsBusy = false;


            switch (result)
            {
                case ServerReplyStatus.Fail:
                    await MyApp.MainPage.DisplayAlert("Error!", "Something bad has occured", "Ok");
                    break;
                case ServerReplyStatus.UserNameAlreadyUsed:
                    await MyApp.MainPage.DisplayAlert("Error!", "Username already exists!", "Ok");
                    break;
                case ServerReplyStatus.PasswordRequirementsFailed:
                   await MyApp.MainPage.DisplayAlert("Error!", "Password policy mismatch!", "Ok");
                    break;
                case ServerReplyStatus.Success:
                    await MyApp.MainPage.DisplayAlert("Success", "Sign up succeeded!. \nPlease check you email for activating your account before logging in", "Ok");
                    break;
            }

        }

        private void SignInClicked(object obj)
        {

            MyApp.OnAlreadyRegistered();

        }
    }
}