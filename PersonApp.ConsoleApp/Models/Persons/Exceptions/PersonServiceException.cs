// ------------------------------------------------
// Copyright (c) MumsWhoCode. All rights reserved.
// ------------------------------------------------

using Xeptions;

namespace PersonApp.ConsoleApp.Models.Persons.Exceptions
{
    public class PersonServiceException : Xeption
    {
        public PersonServiceException(Xeption innerException)
            : base(message: "Person service error occurred, contact Support.",
                  innerException)
        { }
    }
}