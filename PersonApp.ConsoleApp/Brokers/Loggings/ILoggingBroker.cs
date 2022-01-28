// ------------------------------------------------
// Copyright (c) MumsWhoCode. All rights reserved.
// ------------------------------------------------

using System;

namespace PersonApp.ConsoleApp.Brokers.Loggings
{
    internal interface ILoggingBroker
    {
        void LogError(Exception exception);
    }
}
