// ------------------------------------------------
// Copyright (c) MumsWhoCode. All rights reserved.
// ------------------------------------------------

using System.Collections.Generic;
using PersonApp.ConsoleApp.Models.Persons;

namespace PersonApp.ConsoleApp.Brokers.Storages
{
    public partial class StorageBroker : IStorageBroker
    {
        List<Person> Persons = new List<Person>();

        public Person InsertPerson(Person Person)
        {
            Persons.Add(Person);

            return Person;
        }

        public List<Person> SelectAllPersons() => Persons;

        public Person SelectPersonById(int id) =>
            Persons.Find(person => person.Id == id);

        public Person UpdatePerson(Person inputPerson)
        {
            Persons.RemoveAll(person => person.Id == inputPerson.Id);
            Persons.Add(inputPerson);

            return inputPerson;
        }

        public Person DeletePerson(Person person)
        {
            Persons.Remove(person);

            return person;
        }
    }
}