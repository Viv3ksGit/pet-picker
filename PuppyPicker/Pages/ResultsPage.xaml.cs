using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace PuppyPicker
{
    public partial class ResultsPage : ContentPage
    {
        public ResultsPage()
        {
            InitializeComponent();
        }

        async void OnChartTapGestureTap(object sender, EventArgs args)
        {
            await Navigation.PushAsync(new DogProfilePage());
        }
    }
}
