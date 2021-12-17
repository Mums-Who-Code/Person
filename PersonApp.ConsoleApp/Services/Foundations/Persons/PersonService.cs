// ------------------------------------------------
// Copyright (c) MumsWhoCode. All rights reserved.
// ------------------------------------------------

using System;
using PersonApp.ConsoleApp.Brokers.Storages;
using PersonApp.ConsoleApp.Models.Persons;

namespace PersonApp.ConsoleApp.Services.Foundations.Persons
{
    public class PersonService : IPersonServices
    {
        private readonly IStorageBroker storageBroker;

        
        
            public PersonService(IStorageBroker storageBroker) =>
                this.storageBroker = storageBroker;

            public Person AddPerson(Person person) =>
             throw new NotImplementedException();
        
    }
}
