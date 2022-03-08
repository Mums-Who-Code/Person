// ------------------------------------------------
// Copyright (c) MumsWhoCode. All rights reserved.
// ------------------------------------------------
using System;
using PersonApp.ConsoleApp.Models.Persons;
using PersonApp.ConsoleApp.Models.Persons.Exceptions;

namespace PersonApp.ConsoleApp.Services.Foundations.Persons
{
    public partial class PersonService
    {
        private static void ValidationPerson(Person person)
        {
            ValidatePersonIsNotNull(person);

            Validate(
                (Rule: IsInvalid(person.Id), Parameter: nameof(Person.Id)),
                (Rule: IsInvalid(person.FirstName), Parameter: nameof(Person.FirstName)));
        }
        

        private static dynamic IsInvalid(int id) => new
        {
            Condition = id == default,
            Message = "ID is required."
        };

        private static dynamic IsInvalid(string firstname) => new
        {
            Condition = String.IsNullOrWhiteSpace(firstname),
            Message = "FirstName is required"
        };

        private static void ValidatePersonIsNotNull(Person person)
        {
            if (person == null)
            {
                throw new NullPersonException();
            }
        }

        private static void Validate(params (dynamic Rule, string Parameter)[] validations)
        {
            var invalidPersonException = new InvalidPersonException();

            foreach ((dynamic rule, string parameter) in  validations)
            {
                if (rule.Condition)
                {
                    invalidPersonException.UpsertDataList(
                        key: parameter,
                        value: rule.Message);
                }

            }

            invalidPersonException.ThrowIfContainsErrors();
        }
    }
}