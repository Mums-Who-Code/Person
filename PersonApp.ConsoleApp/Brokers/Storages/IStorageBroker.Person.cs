// ------------------------------------------------
// Copyright (c) MumsWhoCode. All rights reserved.
// ------------------------------------------------

using PersonApp.ConsoleApp.Models.Persons;
using System.Collections.Generic;

namespace PersonApp.ConsoleApp.Brokers.Storages
{
    public partial interface IStorageBroker
    {
        Person InsertPerson(Person Person);
        List<Person> SelectAllPersons();
        Person SelectPersonById(int id);
        Person updatePerson(Person inputPerson);
    }
}