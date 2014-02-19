// --------------------------------------------------------------------------------------------------------------------
// <copyright file="GoogleTracker.cs" company="sgmunn">
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

namespace Mobile.Analytics
{
    using System;
    using Google.Analytics;
    using MonoTouch.Foundation;

    public sealed class GoogleTracker : ITracker
    {
        private readonly string trackingId;

        public GoogleTracker(string trackingId)
        {
            this.trackingId = trackingId;    
        }

        public static void Init(int dispatchInterval)
        {
            GAI.SharedInstance.DispatchInterval = dispatchInterval;
        }

        public void SendEvent(string category, string action, string label)
        {
            var tracker = GAI.SharedInstance.TrackerWithTrackingId(this.trackingId);
            if (tracker != null)
            {
                tracker.Send(GAIDictionaryBuilder.CreateEventWithCategory(category, action, label, new NSNumber(0)).Build());
            }
        }

        public void SendException(string message, bool fatal)
        {
            var tracker = GAI.SharedInstance.TrackerWithTrackingId(this.trackingId);
            if (tracker != null)
            {
                tracker.Send(GAIDictionaryBuilder.CreateExceptionWithDescription(message, fatal ? 1 : 0).Build());
            }
        }

        public void SendTiming(string category, int milliseconds, string name, string label)
        {
            var tracker = GAI.SharedInstance.TrackerWithTrackingId(this.trackingId);
            if (tracker != null)
            {
                tracker.Send(GAIDictionaryBuilder.CreateTimingWithCategory(category, milliseconds, name, label).Build());
            }
        }

        public void SetCurrentScreenName(string name)
        {
            var tracker = GAI.SharedInstance.TrackerWithTrackingId(this.trackingId);
            if (tracker != null)
            {
                tracker.Set(GAIFields.ScreenName, name);
                tracker.Send(GAIDictionaryBuilder.CreateAppView().Build());
            }
        }
    }
}