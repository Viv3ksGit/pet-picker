using System;
using System.ComponentModel;
using System.Threading.Tasks;
using System.Windows.Input;
using PuppyPicker.BaseClasses;
using Xamarin.Forms;
using static PuppyPicker.Tools.Helper;

namespace PuppyPicker.ViewModels
{
    public class DogProfilePageVM : INotifyPropertyChanged
    {
        public string DogPP_Title { get; set; }
        //public string url_image { get; set; }
        private string myText;
        public event PropertyChangedEventHandler PropertyChanged;

        //public ICommand Favorite_Handle_Clicked => new Command(FavoriteClicked);

        public DogProfilePageVM()
        {
            DogPP_Title = "Profile";
            myText = "Favorite";
        }

        public string About
        {
            get { return string.Format("Enter the description here, basic details about the dog"); }
        }

        public string Charateristics
        {
            get { return string.Format("Charateristics"); }
        }

        public string ImageFile
        {
            get; set;
        }


        public string MyText
        {
            get => this.myText;


            set
            {
                this.myText = value;
                this.PropertyChanged(this, new PropertyChangedEventArgs(nameof(this.MyText)));
            }
        }

        public ICommand Favorite_Handle_Clicked => new Command(FavoriteClicked);

        private void FavoriteClicked(object obj)
        {
            if (myText == "Favorite")
            { this.MyText = "Unfavorite"; }
            else
            { this.MyText = "Favorite"; }
        }

        // public ICommand Favorite_Handle_Clicked => new Command(() => { this.MyText = "Unfavorite"; });






        /*
        public string CommandText
        {
            get => _commandText;
            set
            {
                _commandText = value;
                NotifyPropertyChanged(nameof(CommandText));
            }
        }

        private void DoWork()
        {
            // ***
            // Do some work here
            // ***
            CommandText = "Finish";
        }*/


    }
}
