﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace PuppyPicker.BaseClasses
{
    public class BaseVM : INotifyPropertyChanged
    {
        //Default values for the settings
        protected string settingsImageSize = "Medium";
        protected string settingsFontSize = "Medium";
        protected string settingsThemeName = "Default";
        protected Boolean settingsNotifications = true;

        private bool _IsBusy;
        public bool IsBusy
        {
            get { return _IsBusy; }
            set { SetValue(ref _IsBusy, value); }

        }
        protected App MyApp = Application.Current as App;

        public BaseVM()
        {

        }

       

        protected async void TestAsync()
        {
            await Task.Delay(10000);
            Debug.WriteLine("10 sec past");
            IsBusy = false;

        }

        //Start Inotify from here
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        protected void SetValue<T>(ref T backingField, T value, [CallerMemberName]string propertyName = null)
        {
            if (EqualityComparer<T>.Default.Equals(backingField, value))
                return;
            backingField = value;
            OnPropertyChanged(propertyName);
        }
        //End Inotify from here
    }
}
