// ------------------------------------------------
// Copyright (c) MumsWhoCode. All rights reserved.
// ------------------------------------------------

using System.Collections.Generic;
using PersonApp.ConsoleApp.Models.Persons;

namespace PersonApp.ConsoleApp.Brokers.Storages
{
    internal partial class StorageBroker : IStorageBroker
    {
        List<Person> Persons = new List<Person>();

        public Person InsertPerson(Person Person)
        {
            Persons.Add(Person);

            return Person;

       
        }
    }
}