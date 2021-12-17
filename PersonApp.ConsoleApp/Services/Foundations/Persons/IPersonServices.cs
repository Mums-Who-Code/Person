// ------------------------------------------------
// Copyright (c) MumsWhoCode. All rights reserved.
// ------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PersonApp.ConsoleApp.Models.Persons;

namespace PersonApp.ConsoleApp.Services.Foundations.Persons
{
    public interface IPersonServices
    {
        Person AddPerson(Person Person);
    }
}
