using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Mobile.Analytics;
using System.IO;

namespace Sample.Analytics.Droid
{
    [Activity(Label = "Main", MainLauncher = true)]
    public class MainActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            Mobile.Analytics.Tracking.AddTracker(new Mobile.Analytics.GoogleTracker(Application.Context));

            Mobile.Analytics.Tracking.AddCrashReporter(new Mobile.Analytics.BugsenseCrashReporter(Application.Context, "------"));


            Tracking.SetCurrentScreen<MainActivity>();

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            // Get our button from the layout resource,
            // and attach an event to it
            Button button = FindViewById<Button>(Resource.Id.myButton);
            
            button.Click += delegate
            {
                Tracking.SendEvent<ButtonClick>("clicked 1");

                this.StartActivity(typeof(Screen2Activity));
            };
        }

        protected override void OnStart()
        {
            base.OnStart();
            //Google.Analytics.EasyTracker.GetInstance(Application.Context).ActivityStart(this);
        }
    }

    public class ButtonClick
    {
    }


    [Activity(Label = "Screen 2", MainLauncher = true)]
    public class Screen2Activity : Activity
    {
        int count = 1;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            Mobile.Analytics.Tracking.AddCrashReporter(new Mobile.Analytics.BugsenseCrashReporter(Application.Context, "d429fb1a"));

            Tracking.SetCurrentScreen<Screen2Activity>();

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            // Get our button from the layout resource,
            // and attach an event to it
            Button button = FindViewById<Button>(Resource.Id.myButton);

            button.Click += delegate
            {
                Tracking.SendEvent<ButtonClick>("clicked");
                try
                {
                    throw new ArgumentNullException("joe");
                }
                catch(Exception ex)
                {
                    Tracking.SendException(ex, false);
                    //Tracker.SendEvent("error1", "action", ex.ToString());
                }
                button.Text = string.Format("{0} clicks!", count++);
            };
        }

        protected override void OnStart()
        {
            base.OnStart();
            //Google.Analytics.EasyTracker.GetInstance(Application.Context).ActivityStart(this);
        }
    }

}


