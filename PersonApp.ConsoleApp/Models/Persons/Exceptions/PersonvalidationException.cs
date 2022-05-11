// ------------------------------------------------
// Copyright (c) MumsWhoCode. All rights reserved.
// ------------------------------------------------

using Xeptions;

namespace PersonApp.ConsoleApp.Models.Persons.Exceptions
{
    public class PersonValidationException : Xeption
    {
        public PersonValidationException(Xeption innerException)
         : base(message: "Person validation error occurred, fix the errors and try again.",
               innerException)
        { }
    }
}