using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Runtime;
using Android.Support.V7.View.Menu;
using Android.Views;
using Android.Widget;

namespace GeoQuiz
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class QuizActivity : AppCompatActivity
    {
        private Button mTrueButton;
        private Button mFalseButton;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_quiz);

            mTrueButton = FindViewById<Button>(Resource.Id.true_button);
            mFalseButton = FindViewById<Button>(Resource.Id.false_button);

            mTrueButton.Click += delegate
            {
                Toast.MakeText(this, Resource.String.correct_toast, ToastLength.Short).Show();
            };

            mFalseButton.Click += delegate
            {
                Toast.MakeText(this, Resource.String.incorrect_toast, ToastLength.Short).Show();
            };
        }
        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }
}