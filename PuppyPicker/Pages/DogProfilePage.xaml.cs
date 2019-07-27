using System;
using System.Collections.Generic;
using PuppyPicker.BaseClasses;

using Xamarin.Forms;

namespace PuppyPicker
{
    public partial class DogProfilePage : BasePage
    {
        public DogProfilePage()
        {
            InitializeComponent();
        }

        async void OnChartTapGestureTap(object sender, EventArgs args)
        {
            //await Navigation.PushAsync(new DogProfilePage());
        }
    }
}
