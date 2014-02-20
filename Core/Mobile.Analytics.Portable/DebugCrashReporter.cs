// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DebugCrashReporter.cs" company="sgmunn">
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
    using System.Text;

    public sealed class DebugCrashReporter : ICrashReporter
    {
        public readonly static ICrashReporter Instance = new DebugCrashReporter();

        private DebugCrashReporter()
        {
        }

        public object Native
        {
            get
            {
                return null;
            }
        }

        public static string FormatException(Exception ex, bool fatal, IDictionary<string, string> extra)
        {
            var additionalInfo = string.Empty;

            if (extra != null)
            {
                var builder = new StringBuilder();
                foreach (var pair in extra)
                {
                    builder.AppendLine(string.Format("{0} - {1}", pair.Key, pair.Value));
                }

                additionalInfo = builder + "\n";
            }

            var msg = string.Format("{0}{1}\n{2}{3}", fatal ? "FATAL - " : string.Empty, ex.Message, additionalInfo, ex);
            return msg;
        }

        public void SendException(Exception ex, bool fatal)
        {
            this.SendException(ex, fatal, null);
        }

        public void SendException(Exception ex)
        {
            this.SendException(ex, false, null);
        }

        public void SendException(Exception ex, IDictionary<string, string> extra)
        {
            this.SendException(ex, false, extra);
        }

        public void SendException(Exception ex, bool fatal, IDictionary<string, string> extra)
        {
            System.Diagnostics.Debug.WriteLine(string.Format("EXCEPTION: {0}", DebugCrashReporter.FormatException(ex, fatal, extra)));
        }
    }
}
