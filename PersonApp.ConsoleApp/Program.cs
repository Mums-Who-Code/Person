// ------------------------------------------------
// Copyright (c) MumsWhoCode. All rights reserved.
// ------------------------------------------------

using Microsoft.Extensions.Logging;
using PersonApp.ConsoleApp.Brokers.Loggings;
using PersonApp.ConsoleApp.Brokers.Storages;
using PersonApp.ConsoleApp.Models.Persons;
using PersonApp.ConsoleApp.Services.Foundations.Persons;
using System.Collections.Generic;

namespace PersonApp.ConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var storageBroker = new StorageBroker();
            var loggerFactory = new LoggerFactory();
            var logger = new Logger<LoggingBroker>(loggerFactory);
            var loggingBroker = new LoggingBroker(logger);
            var personService = new PersonService(storageBroker, loggingBroker);

            var inputPerson = new Person
            {
                Id = 24,
                FirstName = "mmn",
                LastName = "rjk"
            };

            personService.AddPerson(inputPerson);

            inputPerson = new Person
            {
                Id = 5647,
                FirstName = "Test Record",
                LastName = "mnk"
            };

            personService.AddPerson(inputPerson);
            List<Person> storedPersons = personService.RetrieveAllPersons();
            Person returningPerson = personService.RetrievePersonById(24);

            inputPerson = new Person()
            {
                Id = 24,
                FirstName ="ritu",
                LastName ="rjk"
            };

           Person modifiedPerson = personService.ModifyPerson(inputPerson);
        }
    }
}