// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Tracking.cs" company="sgmunn">
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
    using System.Linq;

    public static class Tracking
    {
        private static readonly object locker = new object();

        private static readonly List<ITracker> analytics = new List<ITracker>();

        private static readonly List<ICrashReporter> crashReporters = new List<ICrashReporter>();

        public static void AddTracker(ITracker tracker)
        {
            lock (locker)
            {
                if (tracker == null)
                {
                    throw new ArgumentNullException("tracker");
                }

                if (analytics.All(x => x.GetType() != tracker.GetType()))
                {
                    analytics.Add(tracker);
                }
            }
        }

        public static void RemoveTracker(ITracker tracker)
        {
            lock (locker)
            {
                if (tracker == null)
                {
                    throw new ArgumentNullException("tracker");
                }

                analytics.Remove(tracker);
            }
        }

        public static void ClearTrackers()
        {
            lock (locker)
            {
                analytics.Clear();
            }
        }

        public static void AddCrashReporter(ICrashReporter reporter)
        {
            lock (locker)
            {
                if (reporter == null)
                {
                    throw new ArgumentNullException("reporter");
                }

                if (crashReporters.All(x => x.GetType() != reporter.GetType()))
                {
                    crashReporters.Add(reporter);
                }
            }
        }

        public static void RemoveCrashReporter(ICrashReporter reporter)
        {
            lock (locker)
            {
                if (reporter == null)
                {
                    throw new ArgumentNullException("reporter");
                }

                crashReporters.Remove(reporter);
            }
        }

        public static void ClearCrashReporters()
        {
            lock (locker)
            {
                crashReporters.Clear();
            }
        }

        public static void SendEvent(string category, string action, string label)
        {
            foreach (var instance in GetTrackers())
            {
                instance.SendEvent(category, action, label);
            }
        }

        public static void SendEvent<T>(string action)
        {
            SendEvent<T>(action, null);
        }

        public static void SendEvent<T>(string action, string label)
        {
            var category = typeof(T).FullName;

            foreach (var instance in GetTrackers())
            {
                instance.SendEvent(category, action, label);
            }
        }

        public static void SendException(Exception ex, bool fatal)
        {
            foreach (var instance in GetCrashReporters())
            {
                instance.SendException(ex, fatal);
            }
        }

        public static void SendException(Exception ex)
        {
            foreach (var instance in GetCrashReporters())
            {
                instance.SendException(ex);
            }
        }

        public static void SendTiming(string category, int milliseconds, string name, string label)
        {
            foreach (var instance in GetTrackers())
            {
                instance.SendTiming(category, milliseconds, name, label);
            }
        }

        public static void SetCurrentScreenName(string name)
        {
            foreach (var instance in GetTrackers())
            {
                instance.SetCurrentScreenName(name);
            }
        }

        public static void SetCurrentScreen<T>()
        {
            var name = typeof(T).FullName;

            foreach (var instance in GetTrackers())
            {
                instance.SetCurrentScreenName(name);
            }
        }

        private static List<ITracker> GetTrackers()
        {
            var result = new List<ITracker>();
            lock (locker)
            {
                result.AddRange(analytics);
            }

            return result;
        }

        private static List<ICrashReporter> GetCrashReporters()
        {
            var result = new List<ICrashReporter>();
            lock (locker)
            {
                result.AddRange(crashReporters);
            }

            return result;
        }
    }
}
