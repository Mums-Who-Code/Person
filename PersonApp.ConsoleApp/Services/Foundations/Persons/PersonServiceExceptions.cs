// ------------------------------------------------
// Copyright (c) MumsWhoCode. All rights reserved.
// ------------------------------------------------
using PersonApp.ConsoleApp.Models.Persons;
using PersonApp.ConsoleApp.Models.Persons.Exceptions;
using System;
using Xeptions;

namespace PersonApp.ConsoleApp.Services.Foundations.Persons
{
    public partial class PersonService
    {
        private delegate Person ReturningPersonFunction();

        private Person Trycatch(ReturningPersonFunction returningPersonFunction)
        {
            try
            {
                return returningPersonFunction();
            }
            catch (NullPersonException nullPersonException)
            {
                throw CreateAndlogValidationException(nullPersonException);
            }
            catch (InvalidPersonException invalidPersonException)
            {
                throw CreateAndlogValidationException(invalidPersonException);
            }
            catch (Exception exception)
            {
                var failedPersonException =
                    new FailedPersonServiceException(exception);

                throw CreateAndlogServiceException(failedPersonException);
            }
        }

        private PersonvalidationException CreateAndlogValidationException(Xeption exception)
        {
            var personValidationException = new PersonvalidationException(exception);
            this.loggingbroker.LogError(personValidationException);

            return personValidationException;
        }
       private PersonServiceException CreateAndlogServiceException(Xeption exception)
        {
            var personServiceException = new PersonServiceException(exception);
            this.loggingbroker.LogError(personServiceException);

            return personServiceException;
        }
    }
}