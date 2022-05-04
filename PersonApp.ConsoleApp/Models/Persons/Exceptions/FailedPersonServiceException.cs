// ------------------------------------------------
// Copyright (c) MumsWhoCode. All rights reserved.
// ------------------------------------------------

using System;
using Xeptions;

namespace PersonApp.ConsoleApp.Models.Persons.Exceptions
{
    public class FailedPersonServiceException : Xeption
    {
        public FailedPersonServiceException(Exception innerException)
            : base(message: "Failed person service error occurred,contact support",
                  innerException)
        { }
    }
}