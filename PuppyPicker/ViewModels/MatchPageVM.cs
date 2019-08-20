using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Input;
using PuppyPicker.BaseClasses;
using Xamarin.Forms;
using System.Threading.Tasks;

namespace PuppyPicker.ViewModels 
{
    public class MatchPageVM : BaseVM
    {

        public string entryTitle { get; set; }
        string SurveyTitle;
        public string question { get; set; }
        public string answer1 { get; set; }
        public string answer2 { get; set; }
        public string answer3 { get; set; }
        public string answer4 { get; set; }
        public string answer5 { get; set; }

        public MatchPageVM()
        {
            question = "Quiz";
            SurveyTitle = "MY";
        }

        public ICommand Finish_Handle_Clicked => new Command(FinishHandleClicked);

        public void FinishHandleClicked(object obj)
        {
            SurveyTitle = entryTitle;

            var myPage = MyApp.MainPage as MasterDetailPage;
            myPage.Detail.Navigation.PushAsync(new ResultsPage());
        }

        //public string Question1
        //{
        //    get { return string.Format("Enter the Question here?????????????????????????????????????????????????????????????????????????????"); }
        //}

        //public string[] Answer1List
        //{
        //    get { return Answer1; }
        //    set
        //    {
        //        if (Answer1 != value)
        //        {
        //            Answer1 = value;
        //            OnPropertyChanged();
        //        }
        //    }
        //}

        //String Answer1choice;
        //public string SelectedAnswer1
        //{
        //    get { return Answer1choice; }
        //    set
        //    {
        //        if (Answer1choice != value)
        //        {
        //            Answer1choice = value;
        //            OnPropertyChanged();
        //        }
        //    }
        //}

    }
}
