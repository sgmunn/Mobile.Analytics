// --------------------------------------------------------------------------------------------------------------------
// <copyright file=".cs" company="sgmunn">
//   (c) sgmunn 2013  
//
//   Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated 
//   documentation files (the "Software"), to deal in the Software without restriction, including without limitation 
//   the rights to use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of the Software, and 
//   to permit persons to whom the Software is furnished to do so, subject to the following conditions:
//
//   The above copyright notice and this permission notice shall be included in all copies or substantial portions of 
//   the Software.
//
//   THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO 
//   THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE 
//   AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF 
//   CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS 
//   IN THE SOFTWARE.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Linq;
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using Mobile.Analytics;
using Mono.Security.X509;
using Google.Analytics;

namespace Sample.Analytics.Touch
{
    // The UIApplicationDelegate for the application. This class is responsible for launching the
    // User Interface of the application, as well as listening (and optionally responding) to
    // application events from iOS.
    [Register("AppDelegate")]
    public partial class AppDelegate : UIApplicationDelegate
    {
        // class-level declarations
        UIWindow window;
        //
        // This method is invoked when the application has loaded and is ready to run. In this
        // method you should instantiate the window, load the UI into it and then make the window
        // visible.
        //
        // You have 17 seconds to return from this method, or iOS will terminate your application.
        //
        public override bool FinishedLaunching(UIApplication app, NSDictionary options)
        {
            Tracker.Init(new GoogleTracker("xxxx"));


            // create a new window instance based on the screen size
            window = new UIWindow(UIScreen.MainScreen.Bounds);
            
            // If you have defined a root view controller, set it here:
            // window.RootViewController = myViewController;
            
            // make the window visible
            window.MakeKeyAndVisible();

            GAI.SharedInstance.TrackUncaughtExceptions = true;
            GAI.SharedInstance.DispatchInterval = 1;


            // Tracker.SendEvent("ui_action", "button_press 1", "play_me");

            // Tracker.SendTiming("timing category", 100, "timing name", "timing label 1");

            Tracker.SetCurrentScreenName("main App Screen xx");
            Tracker.SendEvent("ui_action", "button_press 1", "play_me");

            //var tracker = GAI.SharedInstance.TrackerWithTrackingId("UA-46263709-1");
            //tracker.Send(GAIDictionaryBuilder.CreateEventWithCategory("ui_acton", "button_press", "play_me", new NSNumber(0)).Build());

            //tracker.Send(GAIDictionaryBuilder.CreateExceptionWithDescription("error description --  1", new NSNumber(1)).Build());

            //tracker.Send(GAIDictionaryBuilder.CreateTimingWithCategory("timing category", new NSNumber(100), "timing name", "timing label").Build());

            //            tracker.Set(Mobile.Analytics.Google.GAIFields.ScreenName);

            return true;
        }
    }
}

