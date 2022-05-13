// ------------------------------------------------
// Copyright (c) MumsWhoCode. All rights reserved.
// ------------------------------------------------

using System;
using Xeptions;

namespace PersonApp.ConsoleApp.Models.Persons.Exceptions
{
    public class NullArgumentPersonException : Xeption
    {
        public NullArgumentPersonException(Exception innerException)
            : base(message: "Null argument person error occurred, fix the errors and try again.",
                  innerException)
        { }
    }
}