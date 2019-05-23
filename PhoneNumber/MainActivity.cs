using System;
using Android.App;
using Android.OS;
using Android.Runtime;
using Android.Support.Design.Widget;
using Android.Support.V7.App;
using Android.Views;
using Android.Widget;
using System.Collections.Generic;
using Android.Content;

namespace PhoneNumber
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme.NoActionBar", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        static readonly List<string> phoneNumbers = new List<string>();

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.activity_main);

            EditText phoneNumberText = FindViewById<EditText>(Resource.Id.PhoneNumberText);
            TextView translateView = FindViewById<TextView>(Resource.Id.TranslatedView);
            Button translateButton = FindViewById<Button>(Resource.Id.TranslateButton);
            Button historyButton = FindViewById<Button>(Resource.Id.HistoryButton);

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
                    phoneNumbers.Add(translatedNumber);
                    historyButton.Enabled = true;
                }
            };

            historyButton.Click += (sender, e) =>
            {
                var intent = new Intent(this, typeof(TranslationHistoryActivity));
                intent.PutStringArrayListExtra("phone_numbers", phoneNumbers);
                StartActivity(intent);
            };
        }
	}
}

