using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace GeoQuiz
{
    public class Question
    {
        public int TextResID { get; set; }
        public bool IsAnswerTrue { get; set; }

        public Question(int textResId, bool answerTrue)
        {
            TextResID = textResId;
            IsAnswerTrue = answerTrue;
        }
    }
}