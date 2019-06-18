using System;
using Xamarin.Forms;

namespace PuppyPicker
{
    public class SurveyQuestionCS : ViewCell
    {
        public SurveyQuestionCS()
        {

            var grid = new Grid();
            var questionLabel = new Label { FontAttributes = FontAttributes.Bold };
            var answerLabel = new Label();

            questionLabel.SetBinding(Label.TextProperty, "question");
            answerLabel.SetBinding(Label.TextProperty, "answers");

            grid.Children.Add(questionLabel);
            grid.Children.Add(answerLabel, 1, 0);

            View = grid;
        }
    }
}
