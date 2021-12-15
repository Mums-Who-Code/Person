// ------------------------------------------------
// Copyright (c) MumsWhoCode. All rights reserved.
// ------------------------------------------------

using System.Collections.Generic;
using PersonApp.ConsoleApp.Models.Person;

namespace PersonApp.ConsoleApp.Brokers.Storages
{
    internal partial class StorageBroker : IStorageBroker
    {
        List<Person> persons = new List<Person>();

        public Person InsertPersons(Person Person)
        {
           persons.Add(Person);

            return Person;
        }
    }
}