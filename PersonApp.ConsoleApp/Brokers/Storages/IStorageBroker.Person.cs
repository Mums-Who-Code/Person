// ------------------------------------------------
// Copyright (c) MumsWhoCode. All rights reserved.
// ------------------------------------------------

using PersonApp.ConsoleApp.Models.Persons;

namespace PersonApp.ConsoleApp.Brokers.Storages
{
    public partial interface IStorageBroker
    {
        Person InsertPerson(Person Person);

    }
}