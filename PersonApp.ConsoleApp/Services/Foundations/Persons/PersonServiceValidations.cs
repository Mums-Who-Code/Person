// ------------------------------------------------
// Copyright (c) MumsWhoCode. All rights reserved.
// ------------------------------------------------

using PersonApp.ConsoleApp.Models.Persons;
using PersonApp.ConsoleApp.Models.Persons.Exceptions;
using System;

namespace PersonApp.ConsoleApp.Services.Foundations.Persons
{
    public partial class PersonService
    {
        private static void ValidatePerson(Person person)
        {
            ValidatePersonIsNotNull(person);

            Validate(
                (Rule: IsInvalid(person.Id), Parameter: nameof(Person.Id)),
                (Rule: IsInvalid(namevalue:person.FirstName), Parameter: nameof(Person.FirstName)),
                (Rule: IsInvalid(namevalue:person.LastName), Parameter: nameof(Person.LastName)));
        }

        private static dynamic IsInvalid(int id) => new
        {
            Condition = id == default,
            Message = "ID is required."
        };

        private static dynamic IsInvalid(string namevalue) => new
        {
            Condition = String.IsNullOrWhiteSpace(namevalue),
            Message = "Name is required."
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

            foreach ((dynamic rule, string parameter) in validations)
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