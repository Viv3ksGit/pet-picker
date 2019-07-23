using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using PuppyPicker.ENUMS;
using System.Text;
using Xamarin.Forms;
using PuppyPicker.Classes;
using PuppyPicker.BaseClasses;

namespace PuppyPicker
{
    public partial class LoginPage : BaseClasses.BasePage
    {
        public LoginPage()
        {
            InitializeComponent();
        }



        async void Handle_Clicked(object sender, System.EventArgs e)
        {
            //https://jsonplaceholder.typicode.com/todos/1
            //MyApp.OnLogin();


            var Url = "https://jsonplaceholder.typicode.com/posts";
            string content = "{}";
            using (HttpClient _client = new HttpClient())
            {
                var content2 = new StringContent("", Encoding.UTF8, "application/json");
                var _connectionResponse = await _client.GetAsync(Url);
                Debug.WriteLine("hi");
                // === End
                if (_connectionResponse.IsSuccessStatusCode)
                {
                    Debug.WriteLine("success");

                 

                    var _responseJson = _connectionResponse.Content.ReadAsStringAsync().Result;
                    Debug.WriteLine(_responseJson);
                    

                }
                else
                {
                    Debug.WriteLine($"Connection to service failed:{_connectionResponse.ReasonPhrase}");
                    //isConnectionError = true;
                    //returnMessage = Keys.SvcFail;
                }


            }
        }
    }
}