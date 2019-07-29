using System;
using System.Collections.Generic;
using System.Diagnostics;
using Plugin.Messaging;
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
        }

        }
    }

