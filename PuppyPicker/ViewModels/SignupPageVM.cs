using System.Diagnostics;
using System.Windows.Input;
using PuppyPicker.Classes;
using PuppyPicker.Models;
using PuppyPicker.ENUMS;
using Plugin.Toast;
using Xamarin.Forms;

namespace PuppyPicker.ViewModels
{
    public class SignupPageVM
    {
        public ICommand Submit_Handle_Clicked => new Command(SignUpClicked);
        public string SP_Title { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string EmailId { get; set; }

        private ServerConnect serviceConnect => new ServerConnect();

        public SignupPageVM()
        {
            SP_Title = "Signup Page";
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

            var result = await serviceConnect.Connect(_user);

            var myApp = Application.Current as App;
            myApp.OnSubmit();

            CrossToastPopUp.Current.ShowToastMessage("Sucessfully registered");

        }


    }
}