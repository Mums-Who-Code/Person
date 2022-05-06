﻿// ------------------------------------------------
// Copyright (c) MumsWhoCode. All rights reserved.
// ------------------------------------------------

using PersonApp.ConsoleApp.Brokers.Loggings;
using PersonApp.ConsoleApp.Brokers.Storages;
using PersonApp.ConsoleApp.Models.Persons;
using System.Collections.Generic;

namespace PersonApp.ConsoleApp.Services.Foundations.Persons
{
    public partial class PersonService : IPersonService
    {
        private readonly IStorageBroker storageBroker;
        private readonly ILoggingBroker loggingBroker;

        public PersonService(IStorageBroker storageBroker,
                             ILoggingBroker loggingBroker)

        {
            this.storageBroker = storageBroker;
            this.loggingBroker = loggingBroker;
        }

        public Person AddPerson(Person person) =>
        Trycatch(() =>
        {
            ValidatePerson(person);

            return this.storageBroker.InsertPerson(person);
        });

        public List<Person> RetrieveAllPersons()
        {
            throw new System.NotImplementedException();
        }
    }
}