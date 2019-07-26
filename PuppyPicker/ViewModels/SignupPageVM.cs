using System.Diagnostics;
using System.Windows.Input;
using PuppyPicker.Classes;
using PuppyPicker.Models;
using PuppyPicker.ENUMS;
using Plugin.Toast;
using Xamarin.Forms;
using PuppyPicker.BaseClasses;

namespace PuppyPicker.ViewModels
{
    public class SignupPageVM : BaseVM
    {
        public ICommand Submit_Handle_Clicked => new Command(SignUpClicked);
        public string SP_Title { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string EmailId { get; set; }

        private ServerConnect serviceConnect => new ServerConnect();

        public SignupPageVM()
        {
            SP_Title = "Signup";
        }

        async void SignUpClicked()
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
            var result = await serviceConnect.Connect(_user);
            IsBusy = false;

            if (result == ServerReplyStatus.Success)
            {


                Debug.WriteLine(result);
                CrossToastPopUp.Current.ShowToastMessage("Sucessfully registered");
                MyApp.OnSubmit();
                Debug.WriteLine("Auth complete-----");

            }

            else
            {
                Debug.WriteLine(result);
                await MyApp.MainPage.DisplayAlert("Alert!", "Sign up Failed, Try again", "OK");
                Debug.WriteLine("Auth complete-----");
            }

        }
    }
}