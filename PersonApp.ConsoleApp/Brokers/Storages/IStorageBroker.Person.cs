// ------------------------------------------------
// Copyright (c) MumsWhoCode. All rights reserved.
// ------------------------------------------------

using System.Collections.Generic;
using PersonApp.ConsoleApp.Models.Persons;

namespace PersonApp.ConsoleApp.Brokers.Storages
{
    public partial interface IStorageBroker
    {
        Person InsertPerson(Person Person);
        List<Person> SelectAllPersons();
        Person SelectPersonById(int id);
        Person UpdatePerson(Person inputPerson);
        Person DeletePerson(Person person);
    }
}