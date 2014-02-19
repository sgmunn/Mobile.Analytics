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
    using Google.Analytics;
    using Android.Content;

    public sealed class GoogleCrashReporter : ICrashReporter
    {
        private readonly Context context; 

        public GoogleCrashReporter(Context context)
        {
            this.context = context;
        }

        public object Native 
        { 
            get
            {
                return EasyTracker.GetInstance(this.context);
            }
        }

        public void SendException(Exception ex)
        {
            this.SendException(ex.ToString(), false);
        }

        public void SendException(Exception ex, bool fatal)
        {
            this.SendException(ex.ToString(), fatal);
        }

        private void SendException(string message, bool fatal)
        {
            var tracker = EasyTracker.GetInstance(this.context);
            if (tracker != null)
            {
                tracker.Send(MapBuilder.CreateException(message, new Java.Lang.Boolean(fatal)).Build());
            }
        }
    }
}
