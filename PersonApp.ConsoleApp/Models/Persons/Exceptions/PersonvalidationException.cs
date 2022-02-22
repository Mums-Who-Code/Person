// ------------------------------------------------
// Copyright (c) MumsWhoCode. All rights reserved.
// ------------------------------------------------

using Xeptions;

namespace PersonApp.ConsoleApp.Models.Persons.Exceptions
{
    public class PersonvalidationException : Xeption
    {
        public PersonvalidationException(Xeption innerException)
         : base(message: "Person validation error occured , fix the errors and try again.",
               innerException)
        { }
    }
}
