using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Mobile.Analytics;

namespace Sample.Analytics.Droid
{
    [Activity(Label = "Sample.Analytics.Droid", MainLauncher = true)]
    public class MainActivity : Activity
    {
        int count = 1;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            Mobile.Analytics.Tracker.Init(new Mobile.Analytics.GoogleTracker(this));
            Tracker.SetCurrentScreenName("Test 1");

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            // Get our button from the layout resource,
            // and attach an event to it
            Button button = FindViewById<Button>(Resource.Id.myButton);
            
            button.Click += delegate
            {
                Tracker.SendEvent("c1", "a1", "l1");
                button.Text = string.Format("{0} clicks!", count++);
            };
        }

        protected override void OnStart()
        {
            base.OnStart();
            ////Google.Analytics.EasyTracker.GetInstance(this).ActivityStart(this);
        }
    }
}


