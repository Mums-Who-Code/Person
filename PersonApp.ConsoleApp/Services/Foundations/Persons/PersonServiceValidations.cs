// ------------------------------------------------
// Copyright (c) MumsWhoCode. All rights reserved.
// ------------------------------------------------

using PersonApp.ConsoleApp.Models.Persons;
using PersonApp.ConsoleApp.Models.Persons.Exceptions;

namespace PersonApp.ConsoleApp.Services.Foundations.Persons
{
    public partial class PersonService
    {
        private static void ValidatePerson(Person person)
        {
            if (person == null)
                throw new NullPersonException();
        }
    }
}