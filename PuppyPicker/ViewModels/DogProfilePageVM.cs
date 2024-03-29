﻿using System;
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
        public string Description { get; set; }
        private Task<DogProfilePageVM> task;

        public event PropertyChangedEventHandler PropertyChanged;

        //public ICommand Favorite_Handle_Clicked => new Command(FavoriteClicked);

        public DogProfilePageVM()
        {
            DogPP_Title = "Profile";
            myText = "Favorite";
        }

        public string Charateristics
        {
            get { return string.Format("Weight"); }
        }
        public string Charateristics1
        {
            get { return string.Format("Height"); }
        }
        public string Charateristics2
        {
            get { return string.Format("Engery Level"); }
        }
        public string Charateristics3
        {
            get { return string.Format("Colors"); }
        }
        public string Charateristics4
        {
            get { return string.Format("Coat Length"); }
        }
        public string Charateristics5
        {
            get { return string.Format("Tendency to Bark"); }
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
