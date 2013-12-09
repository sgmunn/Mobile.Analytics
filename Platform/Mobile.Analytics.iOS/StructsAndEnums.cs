// --------------------------------------------------------------------------------------------------------------------
// Original source:
// https://github.com/therealjohn/GoogleAnalytics// <copyright file=".cs" company="sgmunn">
// --------------------------------------------------------------------------------------------------------------------

namespace Mobile.Analytics.Google
{
    using System;

    public enum GAILogLevel
    {
        None = 0,
        Error = 1,
        Warning = 2,
        Info = 3,
        Verbose = 4
    }

    public enum GAIErrorCode
    {
        NoError = 0,
        DatabaseError = 1,
        NetworkError = 2
    }
}

