using Android.App;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Widget;
using AndroidX.AppCompat.App;
using System;
using Xamarin.Essentials;

namespace AnVibrate
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {


        private Button button;
        private EditText text1;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);
            button = FindViewById<Button>(Resource.Id.button1);
            text1 = FindViewById<EditText>(Resource.Id.editText1);
            button.Click += Button_Click;
            text1.Click += Text1_Click;

        }

        private void Text1_Click(object sender, EventArgs e)
        {
            try
            {

                HapticFeedback.Perform(HapticFeedbackType.Click);
                Toast.MakeText(this, "ONLY CLICK", ToastLength.Short).Show();

                // Or use long press    
                HapticFeedback.Perform(HapticFeedbackType.LongPress);
                Toast.MakeText(this, "LONGPRESS", ToastLength.Short).Show();

            }
            catch (FeatureNotSupportedException ex)
            {
                // Feature not supported on device
            }
            catch (Exception ex)
            {
                // Other error has occurred.
            }
        }

        private void Button_Click(object sender, EventArgs e)
        {
            try
            {
                // Use default vibration length
                Vibration.Vibrate();

                // Or use specified time
                var duration = TimeSpan.FromSeconds(3);
                Vibration.Vibrate(duration);
                Toast.MakeText(this, "VIBRATION ", ToastLength.Short).Show();
            }
            catch (FeatureNotSupportedException ex)
            {
                Log.Debug("hjhhg", ex.Message);
            }
            catch (Exception ex)
            {
                // Other error has occurred.
            }
        }

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }
}