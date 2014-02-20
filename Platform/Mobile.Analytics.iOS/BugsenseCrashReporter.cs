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
    using System.Collections.Generic;
    using BugSense;
    using BugSense.Core.Model;

    public sealed class BugsenseCrashReporter : ICrashReporter
    {
        public BugsenseCrashReporter(string key)
        {
            BugSenseHandler.Instance.InitAndStartSession(key);
        }

        public BugsenseCrashReporter(string key, string userId)
        {
            BugSenseHandler.Instance.InitAndStartSession(key);
            BugSenseHandler.Instance.UserIdentifier = userId;
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

        public void SendException(Exception ex, IDictionary<string, string> extra)
        {
            BugSenseHandler.Instance.LogException(ex, GetExtra(extra));
        }

        public void SendException(Exception ex, bool fatal, IDictionary<string, string> extra)
        {
            BugSenseHandler.Instance.LogException(ex, GetExtra(extra));
        }

        private LimitedCrashExtraDataList GetExtra(IDictionary<string, string> extra)
        {
            var data = new BugSense.Core.Model.LimitedCrashExtraDataList();

            foreach (var pair in extra)
            {
                try
                {
                    data.Add(new CrashExtraData(pair.Key, pair.Value));
                }
                catch
                {
                    System.Diagnostics.Debug.WriteLine("Could not add value to Bugsense additional data");
                }
            }

            return data;
        }
    }
}
