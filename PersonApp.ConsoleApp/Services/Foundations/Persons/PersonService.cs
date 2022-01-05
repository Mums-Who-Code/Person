// ------------------------------------------------
// Copyright (c) MumsWhoCode. All rights reserved.
// ------------------------------------------------

using System;
using PersonApp.ConsoleApp.Brokers.Storages;
using PersonApp.ConsoleApp.Models.Persons;

namespace PersonApp.ConsoleApp.Services.Foundations.Persons
{
    public class PersonService : IPersonService
    {
        private readonly IStorageBroker storageBroker;

        public PersonService(IStorageBroker storageBroker) =>
            this.storageBroker = storageBroker;

        public Person ADDPerson(Person person) =>
          throw new NotImplementedException();
    }
}