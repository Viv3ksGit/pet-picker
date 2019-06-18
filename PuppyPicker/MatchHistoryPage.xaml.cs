using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace PuppyPicker
{
    public partial class MatchHistoryPage : ContentPage
    {
        public MatchHistoryPage()
        {
            InitializeComponent();
        }

        async void OnChartTapGestureTap(object sender, EventArgs args)
        {
            await Navigation.PushAsync(new DogProfilePage());
        }
    }
}
