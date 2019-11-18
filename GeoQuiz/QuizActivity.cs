using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace GeoQuiz
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class QuizActivity : AppCompatActivity
    {
        public Button FalseButton { get; set; }
        private Button TrueButton { get; set; }
        private ImageButton NextButton { get; set; }
        private ImageButton PrevButton { get; set; }
        private TextView QuestionTextView { get; set; }
        private readonly Question[] questionBank =
        {
            new Question(Resource.String.question_australia, true),
            new Question(Resource.String.question_oceans, true),
            new Question(Resource.String.question_mideast, true),
            new Question(Resource.String.question_africa, true),
            new Question(Resource.String.question_americas, true),
            new Question(Resource.String.question_asia, true)
        };
        private int currentIndex = 0;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_quiz);

            TrueButton = FindViewById<Button>(Resource.Id.true_button);
            TrueButton.Click += delegate
            {
                CheckAnswer(true);
            };

            FalseButton = FindViewById<Button>(Resource.Id.false_button);
            FalseButton.Click += delegate
            {
                CheckAnswer(false);
            };

            QuestionTextView = FindViewById<TextView>(Resource.Id.question_text_view);
            QuestionTextView.Click += delegate
            {
                currentIndex = (currentIndex + 1) % questionBank.Length;
                UpdateQuestion();
            };
            QuestionTextView.SetText(questionBank[0].TextResID);

            NextButton = FindViewById<ImageButton>(Resource.Id.next_button);
            NextButton.Click += delegate
            {
                currentIndex = (currentIndex + 1) % questionBank.Length;
                UpdateQuestion();
            };

            PrevButton = FindViewById<ImageButton>(Resource.Id.previous_button);
            PrevButton.Click += delegate
            {
                if (currentIndex == 0)
                    currentIndex = questionBank.Length - 1;
                else
                    currentIndex -= 1;
                UpdateQuestion();
            };

        }
        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
        private void UpdateQuestion()
        {
            int question = questionBank[currentIndex].TextResID;
            QuestionTextView.SetText(question);
        }
        private void CheckAnswer(bool userPressedTrue)
        {
            bool answerIsTrue = questionBank[currentIndex].IsAnswerTrue;
            int messageResId = 0;

            if (userPressedTrue == answerIsTrue)
                messageResId = Resource.String.correct_toast;
            else
                messageResId = Resource.String.incorrect_toast;

            var newToast = Toast.MakeText(this, messageResId, ToastLength.Short);
            newToast.SetGravity(GravityFlags.Top, 0, 200);
            newToast.Show();
        }
    }
}