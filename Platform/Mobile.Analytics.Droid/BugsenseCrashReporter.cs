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
    using BugSense.Model;
    using Android.App;

    // TODO: provide a way to pass in additional information

    public sealed class BugsenseCrashReporter : ICrashReporter
    {
        public BugsenseCrashReporter(string key)
        {
            BugSenseHandler.Instance.InitAndStartSession(new ExceptionManager(), Application.Context, key);
            //BugSenseHandler.Instance.AddCrashExtraData(new BugSense.Core.Model.CrashExtraData("order_id", "1234"));
        }

        public BugsenseCrashReporter(string key, string userId)
        {
            BugSenseHandler.Instance.InitAndStartSession(new ExceptionManager(), Application.Context, key);
            BugSenseHandler.Instance.UserIdentifier = userId;
            //BugSenseHandler.Instance.AddCrashExtraData(new BugSense.Core.Model.CrashExtraData("order_id", "1234"));
        }

        public object Native 
        { 
            get
            {
                return BugSenseHandler.Instance;
            }
        }

        public void SendException(Exception ex)
        {
            BugSenseHandler.Instance.LogException(ex, null);
        }

        public void SendException(Exception ex, bool fatal)
        {
            BugSenseHandler.Instance.LogException(ex, null);
        }
    }
}
