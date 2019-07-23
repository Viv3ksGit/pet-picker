using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace PuppyPicker.BaseClasses
{
    public class BaseVM : INotifyPropertyChanged
    {
        private bool _IsBusy;

        public BaseVM()
        {
        }

        public bool IsBusy
        {
            get { return _IsBusy; }
            set { SetValue(ref _IsBusy, value); }
        }

        private async void TestAsync()
        {
            await Task.Delay(10000);
            Debug.WriteLine("got response from server");
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
