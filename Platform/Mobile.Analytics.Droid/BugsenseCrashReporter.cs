// --------------------------------------------------------------------------------------------------------------------
// <copyright file="BugsenseCrashReporter.cs" company="sgmunn">
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
    using BugSense;
    using Android.Content;

    public sealed class BugsenseCrashReporter : ICrashReporter, BugSense.Model.IExceptionManager
    {
        ////private readonly Context context; 

        ////private readonly string key;

        public BugsenseCrashReporter(Context context, string key)
        {
            ////this.context = context;
            ////this.key = key;

            BugSenseHandler.Instance.InitAndStartSession(this, context, key);
            //BugSenseHandler.Instance.UserIdentifier = "greg";
            //BugSenseHandler.Instance.AddCrashExtraData(new BugSense.Core.Model.CrashExtraData("order_id", "1234"));
        }

        public event EventHandler<Android.Runtime.RaiseThrowableEventArgs> UnhandledExceptionRaiser;

        public object Native 
        { 
            get
            {
                return BugSenseHandler.Instance;
            }
        }

        public void SendException(Exception ex)
        {
            BugSenseHandler.Instance.SendExceptionAsync(ex, null);
        }

        public void SendException(Exception ex, bool fatal)
        {
            BugSenseHandler.Instance.SendExceptionAsync(ex, null);
        }
    }
}
