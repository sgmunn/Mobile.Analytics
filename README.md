Mobile.Analytics
================

Portable wrapper for Google Analytics and BugSense

see also:
  * https://github.com/therealjohn/GoogleAnalytics
  * https://github.com/Hitcents/GoogleAnalytics
  * http://www.bugsense.com

# Crash Reporting

Add an ICrashReporter:

    Mobile.Analytics.Tracking.AddCrashReporter(new Mobile.Analytics.BugsenseCrashReporter(“app”Id));

Report a handled exception:

    Tracking.SendException(ex);

# Analytics 

Add an ITracker:

    Mobile.Analytics.Tracking.AddTracker(new Mobile.Analytics.GoogleTracker(Application.Context));

for Android you need to add an analytics.xml with your tracking key.

Track the current screen:

    Tracking.SetCurrentScreen<MainActivity>();

Track events:

    Tracking.SendEvent<ButtonClick>("clicked the button”);
