using System;
using PuppyPicker.BaseClasses;
using PuppyPicker.ViewModels;
using System.Collections.Generic;

using Xamarin.Forms;
using static PuppyPicker.Tools.Helper;

namespace PuppyPicker
{
    public partial class MatchPage : BasePage
    {
        private List<MatchPageVM> quiz;
        FirebaseHelper firebaseHelper = new FirebaseHelper();

        protected async override void OnAppearing()
        {
            base.OnAppearing();
            quiz = new List<MatchPageVM>(await firebaseHelper.GetQuizQuestions());

            gridLayoutQuiz.HorizontalOptions = LayoutOptions.Center;
            gridLayoutQuiz.ColumnDefinitions.Add(new ColumnDefinition());

            var row = 0;
            for (int quizIndex = 0; quizIndex < quiz.Count; quizIndex++)
            {
                gridLayoutQuiz.RowDefinitions.Add(new RowDefinition { Height = 40 });
                if (quizIndex >= quiz.Count)
                {
                    break;
                }
                var item = quiz[quizIndex];

                var label = new Label
                {
                    Text = item.question,
                    HeightRequest = 10,
                    HorizontalOptions = LayoutOptions.Center
                };
                gridLayoutQuiz.Children.Add(label, 0, row);
                row++;
                var picker = new Picker
                {
                    HorizontalOptions = LayoutOptions.FillAndExpand,
                    FontSize = 12,
                    Title = "Choose an option",
                    Items = { item.answer1, item.answer2, item.answer3, item.answer4, item.answer5 }
                };
                gridLayoutQuiz.Children.Add(picker, 0, row);
                row++;
            }
        }

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
    }
}
