// ------------------------------------------------
// Copyright (c) MumsWhoCode. All rights reserved.
// ------------------------------------------------
using PersonApp.ConsoleApp.Models.Persons;
using PersonApp.ConsoleApp.Models.Persons.Exceptions;
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
        }

        private PersonvalidationException CreateAndlogValidationException(Xeption exception)
        {
            var personValidationException = new PersonvalidationException(exception);
            this.loggingbroker.LogError(personValidationException);

            throw personValidationException;
        }
    }
}