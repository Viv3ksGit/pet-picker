using System;
using PuppyPicker.BaseClasses;
using System.Collections.Generic;

using Xamarin.Forms;

namespace PuppyPicker
{
    public partial class MatchPage : BasePage
    {
        public MatchPage()
        {
            InitializeComponent();
            /*
             * var questions = new List<SurveyQuestion>
            {
                new SurveyQuestion { question = "que1", answers = "a111" },
                new SurveyQuestion { question = "que2", answers = "b222" },
            };

            Content = new StackLayout
            {
                Margin = new Thickness(20),
                Children = {
                    new ListView { ItemTemplate = new DataTemplate(typeof(SurveyQuestionCS)), ItemsSource = questions, Margin = new Thickness(0, 20, 0, 0) }
                }
            };
            */
            System.Diagnostics.Debug.WriteLine("You opened Match page");

        }
        /*
        void Handle_Clicked(object sender, System.EventArgs e)
        {
            Navigation.PushAsync(new ResultsPage());
        }
        */
    }
}
