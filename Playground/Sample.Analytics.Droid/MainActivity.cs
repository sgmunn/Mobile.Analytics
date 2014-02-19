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

            Mobile.Analytics.Tracker.AddTracker(new Mobile.Analytics.GoogleTracker(Application.Context));

            Mobile.Analytics.Tracker.AddCrashReporter(new Mobile.Analytics.BugsenseCrashReporter(Application.Context, "--------"));


            Tracker.SetCurrentScreenName("Screen 1");

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            // Get our button from the layout resource,
            // and attach an event to it
            Button button = FindViewById<Button>(Resource.Id.myButton);
            
            button.Click += delegate
            {
                Tracker.SendEvent("button 1", "clicked", "1");

                this.StartActivity(typeof(Screen2Activity));
            };
        }

        protected override void OnStart()
        {
            base.OnStart();
            //Google.Analytics.EasyTracker.GetInstance(Application.Context).ActivityStart(this);
        }
    }


    [Activity(Label = "Screen 2", MainLauncher = true)]
    public class Screen2Activity : Activity
    {
        int count = 1;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            Mobile.Analytics.Tracker.AddCrashReporter(new Mobile.Analytics.BugsenseCrashReporter(Application.Context, "d429fb1a"));


            Tracker.SetCurrentScreenName("Sceen 2");

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            // Get our button from the layout resource,
            // and attach an event to it
            Button button = FindViewById<Button>(Resource.Id.myButton);

            button.Click += delegate
            {
                Tracker.SendEvent("button 2", "clicked", "1");
                try
                {
                    throw new ArgumentNullException("joe");
                }
                catch(Exception ex)
                {
                    Tracker.SendException(ex, false);
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


