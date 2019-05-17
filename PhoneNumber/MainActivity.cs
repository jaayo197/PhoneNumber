using System;
using Android.App;
using Android.OS;
using Android.Runtime;
using Android.Support.Design.Widget;
using Android.Support.V7.App;
using Android.Views;
using Android.Widget;

namespace PhoneNumber
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme.NoActionBar", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.activity_main);

            EditText phoneNumberText = FindViewById<EditText>(Resource.Id.PhoneNumberText);
            TextView translateView = FindViewById<TextView>(Resource.Id.TranslatedView);
            Button translateButton = FindViewById<Button>(Resource.Id.TranslateButton);

            translateButton.Click += (sender, e) =>
            {
                string translatedNumber = PhoneNumber.PhoneTranslator.ToNumber(phoneNumberText.Text);
                if (string.IsNullOrWhiteSpace(translatedNumber))
                {
                    translateView.Text = string.Empty;
                }
                else
                {
                    translateView.Text = translatedNumber;
                }
            };
        }
	}
}

