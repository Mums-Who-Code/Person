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
  public class PersonvalidationException: Xeption
    {
        public PersonvalidationException(Xeption innerException)
         : base(message: "Person validation error occured , fix the errors and try again.",
               innerException)
        { }
    }
}
