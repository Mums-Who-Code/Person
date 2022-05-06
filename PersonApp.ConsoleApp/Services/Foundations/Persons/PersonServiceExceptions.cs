// ------------------------------------------------
// Copyright (c) MumsWhoCode. All rights reserved.
// ------------------------------------------------

using PersonApp.ConsoleApp.Models.Persons;
using PersonApp.ConsoleApp.Models.Persons.Exceptions;
using System;
using System.Collections.Generic;
using Xeptions;

namespace PersonApp.ConsoleApp.Services.Foundations.Persons
{
    public partial class PersonService
    {
        private delegate Person ReturningPersonFunction();
        private delegate List<Person> ReturningPersonsFunction();

        private List<Person> Trycatch(ReturningPersonsFunction returningPersonFunction)
        {
            try
            {
                return returningPersonFunction();
            }
            catch (Exception exception)
            {
                var failedPersonserviceException = new FailedPersonServiceException(exception);
                throw CreateAndLogServiceException(failedPersonserviceException);
            }
        }

        private Person Trycatch(ReturningPersonFunction returningPersonFunction)
        {
            try
            {
                return returningPersonFunction();
            }
            catch (NullPersonException nullPersonException)
            {
                throw CreateAndLogValidationException(nullPersonException);
            }
            catch (InvalidPersonException invalidPersonException)
            {
                throw CreateAndLogValidationException(invalidPersonException);
            }
            catch (Exception exception)
            {
                var failedPersonServiceException =
                    new FailedPersonServiceException(exception);

                throw CreateAndLogServiceException(failedPersonServiceException);
            }
        }

        private PersonvalidationException CreateAndLogValidationException(Xeption exception)
        {
            var personValidationException = new PersonvalidationException(exception);
            this.loggingBroker.LogError(personValidationException);

            return personValidationException;
        }

        private PersonServiceException CreateAndLogServiceException(Xeption exception)
        {
            var personServiceException = new PersonServiceException(exception);
            this.loggingBroker.LogError(personServiceException);

            return personServiceException;
        }
    }
}