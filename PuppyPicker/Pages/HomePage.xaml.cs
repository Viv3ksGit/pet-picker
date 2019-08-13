using System;
using System.Collections.Generic;
using PuppyPicker.ViewModels;
using Xamarin.Forms;
using static PuppyPicker.Tools.Helper;

namespace PuppyPicker
{
    public partial class HomePage : ContentPage
    {

        private List<DogProfilePageVM> dogs;
        //connecting to Google Firebase Realtime DB
        //FirebaseClient firebase = new FirebaseClient("https://puppypicker-dd153.firebaseio.com/");
        FirebaseHelper firebaseHelper = new FirebaseHelper();


        //FirebaseStorage firebaseStorage = new FirebaseStorage("puppypicker-dd153.appspot.com/");
        FirebaseStorageHelper firebaseStorageHelper = new FirebaseStorageHelper();

        protected async override void OnAppearing()
        {
            base.OnAppearing();

            dogs = new List<DogProfilePageVM>(await firebaseHelper.GetAllDogs());

            gridLayout.HorizontalOptions = LayoutOptions.Center;
            gridLayout.ColumnDefinitions.Add(new ColumnDefinition());
            gridLayout.ColumnDefinitions.Add(new ColumnDefinition());
            
            var dogIndex = 0;
            for (int rowIndex = 0; rowIndex < Math.Ceiling((decimal)dogs.Count / 2); rowIndex++)
            {
                gridLayout.RowDefinitions.Add(new RowDefinition { Height = 180 });

                for (int columnIndex = 0; columnIndex < 2; columnIndex++)
                {
                    if (dogIndex >= dogs.Count)
                    {
                        break;
                    }
                    var dog = dogs[dogIndex];
                    dogIndex += 1;

                    var image = new Image
                    {
                        Source = await firebaseStorageHelper.GetFile(dog.ImageFile),
                        Aspect = Aspect.AspectFit,
                        VerticalOptions = LayoutOptions.FillAndExpand,
                        HorizontalOptions = LayoutOptions.FillAndExpand
                    };
                    image.GestureRecognizers.Add((new TapGestureRecognizer((view) => OnChartTapGestureTap())));
                    var label = new Label
                    {
                        Text = dog.DogPP_Title,
                        HeightRequest = 10,
                        HorizontalOptions = LayoutOptions.Center
                    };
                    gridLayout.Children.Add(image, columnIndex, rowIndex);
                    gridLayout.Children.Add(label, columnIndex, rowIndex);
                }
            }
        }

        [Obsolete]
        public HomePage()
        {
            InitializeComponent();
        }

        private async void OnChartTapGestureTap()
        {
            await Navigation.PushAsync(new DogProfilePage());
        }
    }
}
