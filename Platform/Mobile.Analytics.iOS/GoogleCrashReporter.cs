// --------------------------------------------------------------------------------------------------------------------
// <copyright file="GoogleCrashReporter.cs" company="sgmunn">
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
    using System.Collections.Generic;
    using Google.Analytics;

    public sealed class GoogleCrashReporter : ICrashReporter
    {
        private readonly string trackingId;

        public GoogleCrashReporter(string trackingId)
        {
            this.trackingId = trackingId;    
        }

        public object Native 
        { 
            get
            {
                return GAI.SharedInstance.TrackerWithTrackingId(this.trackingId);
            }
        }

        public static void Init(int dispatchInterval, bool unCaughtExceptions = true)
        {
            GAI.SharedInstance.TrackUncaughtExceptions = unCaughtExceptions;
            GAI.SharedInstance.DispatchInterval = dispatchInterval;
        }

        public void SendException(Exception ex)
        {
            this.SendException(ex.ToString(), false);
        }

        public void SendException(Exception ex, bool fatal)
        {
            this.SendException(ex.ToString(), fatal);
        }

        public void SendException(Exception ex, IDictionary<string, string> extra)
        {
            this.SendException(DebugCrashReporter.FormatException(ex, false, extra), false);
        }

        public void SendException(Exception ex, bool fatal, IDictionary<string, string> extra)
        {
            this.SendException(DebugCrashReporter.FormatException(ex, fatal, extra), fatal);
        }

        private void SendException(string message, bool fatal)
        {
            var tracker = GAI.SharedInstance.TrackerWithTrackingId(this.trackingId);
            if (tracker != null)
            {
                tracker.Send(GAIDictionaryBuilder.CreateExceptionWithDescription(message, fatal ? 1 : 0).Build());
            }
        }
    }
}
