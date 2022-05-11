// ------------------------------------------------
// Copyright (c) MumsWhoCode. All rights reserved.
// ------------------------------------------------

using PersonApp.ConsoleApp.Models.Persons;
using System.Collections.Generic;

namespace PersonApp.ConsoleApp.Services.Foundations.Persons
{
    public interface IPersonService
    {
        Person AddPerson(Person person);
        List<Person> RetrieveAllPersons();

        Person RetrievePersonById(int id);
    }
}