// ------------------------------------------------
// Copyright (c) MumsWhoCode. All rights reserved.
// ------------------------------------------------

using System.Collections.Generic;
using PersonApp.ConsoleApp.Models.Persons;

namespace PersonApp.ConsoleApp.Brokers.Storages
{
    internal partial class StorageBroker : IStorageBroker
    {
        List<Persons> persons = new List<Persons>();

        public Persons InsertPersons(Persons Persons)
        {
           persons.Add(Persons);

            return Persons;
        }
    }
}