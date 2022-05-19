// ------------------------------------------------
// Copyright (c) MumsWhoCode. All rights reserved.
// ------------------------------------------------

using System.Collections.Generic;
using PersonApp.ConsoleApp.Models.Persons;

namespace PersonApp.ConsoleApp.Services.Foundations.Persons
{
    public interface IPersonService
    {
        Person AddPerson(Person person);
        List<Person> RetrieveAllPersons();
        Person RetrievePersonById(int id);
        Person ModifyPerson(Person person);
    }
}