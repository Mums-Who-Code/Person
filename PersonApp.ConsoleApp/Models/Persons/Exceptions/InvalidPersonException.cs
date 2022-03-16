// ------------------------------------------------
// Copyright (c) MumsWhoCode. All rights reserved.
// ------------------------------------------------

using Xeptions;

namespace PersonApp.ConsoleApp.Models.Persons.Exceptions
{
    public class InvalidPersonException : Xeption
    {
        public InvalidPersonException()
            : base(message: "Person is invalid,fix the errors and try again.")
        { }
    }
}