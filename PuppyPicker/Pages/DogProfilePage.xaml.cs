using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using PuppyPicker.BaseClasses;
using PuppyPicker.ViewModels;
using Xamarin.Forms;
using static PuppyPicker.Tools.Helper;

namespace PuppyPicker
{
    public partial class DogProfilePage : BasePage
    {
        private DogProfilePageVM dog;
        string dogName;
        FirebaseHelper firebaseHelper = new FirebaseHelper();
        FirebaseStorageHelper firebaseStorageHelper = new FirebaseStorageHelper();

        public DogProfilePage()
        {
            InitializeComponent();
        }

        public DogProfilePage(string title)
        {
            InitializeComponent();
            dogName = title;
            OnAppearing();
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();
            dog = await firebaseHelper.GetDog(dogName);
            dogImage.Source = await firebaseStorageHelper.GetFile(dog.ImageFile);
            dogTitle.Text = dog.DogPP_Title;
            dogDescription.Text = dog.Description.ToString().Replace("\\n", "\n"); //firebase adds extra \ to a value with \n
        }

        void OnChartTapGestureTap(object sender, EventArgs args)
        {
            //await Navigation.PushAsync(new DogProfilePage());
        }
    }
}
