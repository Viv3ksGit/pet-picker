using System;
using PuppyPicker.Classes;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PuppyPicker
{
    public partial class App : Application
    {


        public App()
        {
            InitializeComponent();

            if(Properties.ContainsKey("Username"))
                OnLogin();
            else

            MainPage = new LoginPage();
        }

        public void OnAlreadyRegistered()
        {

            MainPage = new LoginPage();

        }

        public void OnSignUp()
        {

            MainPage = new SignupPage();

        }

        public void OnLogin()
        {

            MainPage = new MainPage();

        }

        async public void OnLogout()
        {
            Properties.Remove("Username");
            Properties.Remove("Password");
            await SavePropertiesAsync();

            MainPage = new NavigationPage(new LoginPage());
        }
        public void OnSubmit()
        {

            MainPage = new LoginPage();

        }

        public void OnForgotPassword()
        {

            //MainPage = new ForgotPasswordPage();

        }

     
        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }

        public void SetSessionData(SignInContext _sessionData)
        {

            Properties["Username"] = _sessionData.UserName;
            Properties["Password"] = _sessionData.UserPassword;
            SavePropertiesAsync();
        }
    }
}
    