using System;
using System.Collections.Generic;
using PuppyPicker.ViewModels;
using Xamarin.Forms;

namespace PuppyPicker
{
    public partial class HomePage : ContentPage
    {

        private List<DogProfilePageVM> dogs;

        [Obsolete]
        public HomePage()
        {
            InitializeComponent();

            dogs = new List<DogProfilePageVM>();
            dogs.Add(new DogProfilePageVM { ImageFile = "huskeypuppy.jpg", DogPP_Title = "Husky1" });
            dogs.Add(new DogProfilePageVM { ImageFile = "irishsetter.jpg", DogPP_Title = "Irish setter2" });
            dogs.Add(new DogProfilePageVM { ImageFile = "huskeypuppy.jpg", DogPP_Title = "Husky3" });
            dogs.Add(new DogProfilePageVM { ImageFile = "huskeypuppy.jpg", DogPP_Title = "Husky4" });
            dogs.Add(new DogProfilePageVM { ImageFile = "irishsetter.jpg", DogPP_Title = "Irish setter5" });
            dogs.Add(new DogProfilePageVM { ImageFile = "irishsetter.jpg", DogPP_Title = "Irish setter6" });
            dogs.Add(new DogProfilePageVM { ImageFile = "huskeypuppy.jpg", DogPP_Title = "Husky7" });
            dogs.Add(new DogProfilePageVM { ImageFile = "huskeypuppy.jpg", DogPP_Title = "Husky8" });

            gridLayout.HorizontalOptions = LayoutOptions.Center;
            gridLayout.ColumnDefinitions.Add(new ColumnDefinition());
            gridLayout.ColumnDefinitions.Add(new ColumnDefinition());

            var dogIndex = 0;
            for (int rowIndex = 0; rowIndex < Math.Ceiling((decimal)dogs.Count / 2); rowIndex++)
            {
                gridLayout.RowDefinitions.Add(new RowDefinition { Height=180 });
              
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
                        Source = dog.ImageFile,
                        Aspect = Aspect.AspectFit,
                        VerticalOptions = LayoutOptions.FillAndExpand,
                        HorizontalOptions = LayoutOptions.FillAndExpand
                        

                        //HeightRequest = 300
                    };
                    //image.GestureRecognizers.Add((new TapGestureRecognizer(async (view) => await Navigation.PushAsync(new DogProfilePage()) )));
                    image.GestureRecognizers.Add((new TapGestureRecognizer((view) => OnChartTapGestureTap())));
                    var label = new Label
                    {
                        Text = dog.DogPP_Title,
                        HeightRequest = 10,
                        //VerticalOptions = LayoutOptions.,
                        HorizontalOptions = LayoutOptions.Center
                    };
                    gridLayout.Children.Add(image, columnIndex, rowIndex);
                    gridLayout.Children.Add(label, columnIndex, rowIndex);
                }
            }
        }

        async void OnChartTapGestureTap()
        {
            await Navigation.PushAsync(new DogProfilePage());
        }
    }
}
