using System;
using System.Windows.Input;
using Plugin.Messaging;
using PuppyPicker.BaseClasses;
using Xamarin.Forms;

namespace PuppyPicker.ViewModels
{
    public class SupportPageVM : BaseVM
    {
        public string SSP_Title { get; set; }

        public ICommand Email_Clicked => new Command(EmailClicked);
        public ICommand Call_Clicked => new Command(CallClicked);

        public SupportPageVM()
        {
            SSP_Title = "Support";
        }

        private void CallClicked(object obj)
        {

            var phoneDialer = CrossMessaging.Current.PhoneDialer;
            if (phoneDialer.CanMakePhoneCall)
                phoneDialer.MakePhoneCall("+27219333000");
            else
            {
                MyApp.MainPage.DisplayAlert("Call function not found", "Please install application to use this service", "OK");
            }
        }


            private void EmailClicked(object obj)

            {
                var emailMessenger = CrossMessaging.Current.EmailMessenger;
                if (emailMessenger.CanSendEmail)
                {

                    var email = new EmailMessageBuilder()
                      .To("to.Vivekmohan.rhul@gmail.com")
                      .Subject("Suggestion/Feedback")
                      .Body("Hello Developer")
                      .Build();

                    emailMessenger.SendEmail(email);
                }

                else
                {
                   MyApp.MainPage.DisplayAlert("Application not found", "Please install application to use this service", "OK");

                }

            }
    }
}
