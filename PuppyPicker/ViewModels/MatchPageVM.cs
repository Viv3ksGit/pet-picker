using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Input;
using PuppyPicker.BaseClasses;
using Xamarin.Forms;

namespace PuppyPicker.ViewModels 
{
    public class MatchPageVM : BaseVM
    {
        string[] Answer1 = { "a", "b", "c", "d" };
        string[] Answer2 = { "a", "b", "c", "d" };
        string[] Answer3 = { "a", "b", "c", "d" };
        string[] Answer4 = { "a", "b", "c", "d" };
        string[] Answer5 = { "a", "b", "c", "d" };
        string[] Answer6 = { "a", "b", "c", "d" };
        string[] Answer7 = { "a", "b", "c", "d" };
        string[] Answer8 = { "a", "b", "c", "d" };
        string[] Answer9 = { "a", "b", "c", "d" };
        string[] Answer10 = { "a", "b", "c", "d" };



        public MatchPageVM()
        {

        }

        public string Question1
        {
            get { return string.Format("Enter the Question here?????????????????????????????????????????????????????????????????????????????"); }
        }

        public string Question2
        {
            get { return string.Format("Enter the Question 2 here?"); }
        }

        public string Question3
        {
            get { return string.Format("Enter the Question 3 here?"); }
        }

        public string Question4
        {
            get { return string.Format("Enter the Question 4 here?"); }
        }

        public string Question5
        {
            get { return string.Format("Enter the Question 5 here?"); }
        }

        public string Question6
        {
            get { return string.Format("Enter the Question 6 here?"); }
        }

        public string Question7
        {
            get { return string.Format("Enter the Question 7 here?"); }
        }

        public string Question8
        {
            get { return string.Format("Enter the Question 8 here?"); }
        }

        public string Question9
        {
            get { return string.Format("Enter the Question 9 here?"); }
        }

        public string Question10
        {
            get { return string.Format("Enter the Question 10 here?"); }
        }


        public string[] Answer1List
        {
            get { return Answer1; }
            set
            {
                if (Answer1 != value)
                {
                    Answer1 = value;
                    OnPropertyChanged();
                }
            }
        }

        public string[] Answer2List
        {
            get { return Answer2; }
            set
            {
                if (Answer2 != value)
                {
                    Answer2 = value;
                    OnPropertyChanged();
                }
            }
        }

        public string[] Answer3List
        {
            get { return Answer3; }
            set
            {
                if (Answer3 != value)
                {
                    Answer3 = value;
                    OnPropertyChanged();
                }
            }
        }

        public string[] Answer4List
        {
            get { return Answer4; }
            set
            {
                if (Answer4 != value)
                {
                    Answer4 = value;
                    OnPropertyChanged();
                }
            }
        }

        public string[] Answer5List
        {
            get { return Answer5; }
            set
            {
                if (Answer5 != value)
                {
                    Answer5 = value;
                    OnPropertyChanged();
                }
            }
        }

        public string[] Answer6List
        {
            get { return Answer6; }
            set
            {
                if (Answer6 != value)
                {
                    Answer6 = value;
                    OnPropertyChanged();
                }
            }
        }

        public string[] Answer7List
        {
            get { return Answer7; }
            set
            {
                if (Answer7 != value)
                {
                    Answer7 = value;
                    OnPropertyChanged();
                }
            }
        }

        public string[] Answer8List
        {
            get { return Answer8; }
            set
            {
                if (Answer8 != value)
                {
                    Answer8 = value;
                    OnPropertyChanged();
                }
            }
        }

        public string[] Answer9List
        {
            get { return Answer9; }
            set
            {
                if (Answer9 != value)
                {
                    Answer9 = value;
                    OnPropertyChanged();
                }
            }
        }

        public string[] Answer10List
        {
            get { return Answer10; }
            set
            {
                if (Answer10 != value)
                {
                    Answer10 = value;
                    OnPropertyChanged();
                }
            }
        }


        String Answer1choice;
        public string SelectedAnswer1
        {
            get { return Answer1choice; }
            set
            {
                if (Answer1choice != value)
                {
                    Answer1choice = value;
                    OnPropertyChanged();
                }
            }
        }

    }
}
