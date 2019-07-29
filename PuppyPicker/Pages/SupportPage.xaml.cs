using System;
using System.Collections.Generic;
using System.Diagnostics;
using Plugin.Messaging;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace PuppyPicker
{
    public partial class SupportPage : ContentPage
    {
        public SupportPage()
        {
            InitializeComponent();
        }

        void Support_Clicked(object sender, System.EventArgs e)
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
                DisplayAlert("Application not found", "Please install application to use this service", "OK");

            }

           
        }

        void Call_Clicked(object sender, System.EventArgs e)
        {
            var phoneDialer = CrossMessaging.Current.PhoneDialer;
            if (phoneDialer.CanMakePhoneCall)
                phoneDialer.MakePhoneCall("+27219333000");
            else
            {
                DisplayAlert("Call function not found", "Please install application to use this service", "OK");
            }
        }
    }
}


