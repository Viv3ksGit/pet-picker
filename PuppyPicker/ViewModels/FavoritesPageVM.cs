using System;
using PuppyPicker.BaseClasses;
namespace PuppyPicker.ViewModels
{
    public class FavoritesPageVM : BaseVM
    {
        public string FP_Title { get; set; }


        public FavoritesPageVM()
        {
            ;
        }

        public string ImageFile
        {
            get { return string.Format("pug.jpeg"); }
        }

        public string DogName
        {
            get { return string.Format("Dog Name"); }
        }
    }
}
