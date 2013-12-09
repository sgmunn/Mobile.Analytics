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
    using Android.Content;

    public sealed class GoogleTracker : ITracker
    {
        private readonly Context context; 

        public GoogleTracker(Context context)
        {
            this.context = context;
        }

        public void SendEvent(string category, string action, string label)
        {
            var tracker = EasyTracker.GetInstance(this.context);
            if (tracker != null)
            {
                tracker.Send(MapBuilder.CreateEvent(category, action, label, null).Build());
            }
        }

        public void SendException(string message, bool fatal)
        {
            var tracker = EasyTracker.GetInstance(this.context);
            if (tracker != null)
            {
                tracker.Send(MapBuilder.CreateException(message, new Java.Lang.Boolean(fatal)).Build());
            }
        }

        public void SendTiming(string category, int milliseconds, string name, string label)
        {
            var tracker = EasyTracker.GetInstance(this.context);
            if (tracker != null)
            {
                tracker.Send(MapBuilder.CreateTiming(category, new Java.Lang.Long(milliseconds), name, label).Build());
            }
        }

        public void SetCurrentScreenName(string name)
        {
            var tracker = EasyTracker.GetInstance(this.context);
            if (tracker != null)
            {
                tracker.Set(Fields.ScreenName, name);
            }
        }
    }
}

