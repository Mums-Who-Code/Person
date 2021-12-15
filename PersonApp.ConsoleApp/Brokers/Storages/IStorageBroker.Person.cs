// ------------------------------------------------
// Copyright (c) MumsWhoCode. All rights reserved.
// ------------------------------------------------

using PersonApp.ConsoleApp.Models.Persons;

namespace PersonApp.ConsoleApp.Brokers.Storages
{
    internal partial interface IStorageBroker
    {
        Person InsertPerson(Person Person);
    }
}
