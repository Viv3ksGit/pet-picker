using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace PuppyPicker
{
    public partial class FavoritesPage : ContentPage
    {
        public FavoritesPage()
        {
            InitializeComponent();
        }

        async void OnChartTapGestureTap(object sender, EventArgs args)
        {
            await Navigation.PushAsync(new DogProfilePage());
        }
    }
}
