// ------------------------------------------------
// Copyright (c) MumsWhoCode. All rights reserved.
// ------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xeptions;

namespace PersonApp.ConsoleApp.Models.Persons.Exceptions
{
    public class InvalidPersonException : Xeption
    {
        public InvalidPersonException()
            : base(message: "Person is invalid,fix the errors and try again.")
        {

        }
    }
}
