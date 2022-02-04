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
    public class NullPersonException:Xeption
    {
        public NullPersonException()
            : base(message:"person is null.") 
        { }

    }
}
