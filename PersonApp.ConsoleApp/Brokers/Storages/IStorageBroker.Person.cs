// ------------------------------------------------
// Copyright (c) MumsWhoCode. All rights reserved.
// ------------------------------------------------

using PersonApp.ConsoleApp.Models.Person;

namespace PersonApp.ConsoleApp.Brokers.Storages
{
    internal partial interface IStorageBroker
    {
        Person InsertPersons(Person persons);
    }
}
