using System;
using System.Text.RegularExpressions;
using PuppyPicker.Classes;
using Xamarin.Forms;

namespace PuppyPicker.Tools
{
    public class StringOperations
    {


        public static string BasicValidation(String txt, string type = "default")
        {
            var app = Application.Current as App;
            string _error = null;

            string text = txt != null ? txt.Trim() : txt;
            //check for null value
            if (!NotEmpty(txt))
                return "Field_Is_Empty";
            //check for minimum length
            if (text.Length < 3)
                return "FL_Min_Length";

            //Only for person names allow alphabits and ' ' space
            if (type == "PersonName")
            {
                if (!Keys.Regex_EntryName.IsMatch(text))
                {
                    return "FL_PersonNamePolicy";
                }
            }

            return _error;
        }
        public static bool IPValidate(string ip)
        {
            if (Keys.Regex_EntryIP.Match(ip).Success)
                return true;
            else
                return false;
        }
        public static bool NotEmpty(string _txt)
        {
            if (_txt != null)
            {
                string text = _txt.Trim();
                if (text == "" | text.Length < 1)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
            else
            {
                return false;
            }
        }
        public static bool Numeric(string _txt)
        {
            if (_txt != null)
            {
                string text = _txt.Trim();
                if (text == "" | text.Length < 1)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
            else
            {
                return false;
            }
        }

        public static bool ValidateEmailInput(string _email)
        {
            if (StringOperations.NotEmpty(_email))
            {
                bool result = (Regex.IsMatch(_email, Keys.emailRegex, RegexOptions.IgnoreCase, TimeSpan.FromMilliseconds(250)));
                return result;
            }
            return false;
        }

        public static bool ValidatePasswordInput(string _pass)
        {
            if (StringOperations.NotEmpty(_pass))
            {
                bool result = (Regex.IsMatch(_pass, Keys.passwordRegex));
                return result;
            }
            return false;
        }
    }
}
