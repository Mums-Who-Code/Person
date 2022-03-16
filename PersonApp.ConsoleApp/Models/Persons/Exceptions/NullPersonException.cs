// ------------------------------------------------
// Copyright (c) MumsWhoCode. All rights reserved.
// ------------------------------------------------

using Xeptions;

namespace PersonApp.ConsoleApp.Models.Persons.Exceptions
{
    public class NullPersonException : Xeption
    {
        public NullPersonException()
            : base(message: "person is null.")
        { }
    }
}