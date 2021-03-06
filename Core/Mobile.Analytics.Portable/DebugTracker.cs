// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DebugTracker.cs" company="sgmunn">
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

    public sealed class DebugTracker : ITracker
    {
        public readonly static ITracker Instance = new DebugTracker();

        private DebugTracker()
        {
        }

        public object Native
        {
            get
            {
                return null;
            }
        }

        public void SendEvent(string category, string action, string label)
        {
            System.Diagnostics.Debug.WriteLine(string.Format("EVENT: {0} - {1} - {2}", category, action, label));
        }

        public void SendTiming(string category, int milliseconds, string name, string label)
        {
            System.Diagnostics.Debug.WriteLine(string.Format("TIMING: {0} - {1} - {2} - {3}", category, milliseconds, name, label));
        }

        public void SetCurrentScreenName(string name)
        {
            System.Diagnostics.Debug.WriteLine(string.Format("SCREEN: {0}", name));
        }
    }
}
