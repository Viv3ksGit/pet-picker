using System;
using PuppyPicker.BaseClasses;
namespace PuppyPicker.ViewModels
{
    public class FavoritesPageVM : BaseVM
    {

        public FavoritesPageVM()
        {

        }

        public string ImageFile
        {
            get { return string.Format("pug.jpeg"); }
        }
    }
}
