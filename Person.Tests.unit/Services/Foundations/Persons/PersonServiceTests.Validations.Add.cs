// ------------------------------------------------
// Copyright (c) MumsWhoCode. All rights reserved.
// ------------------------------------------------

using System;
using Moq;
using PersonApp.ConsoleApp.Models.Persons;
using PersonApp.ConsoleApp.Models.Persons.Exceptions;
using Xunit;

namespace PersonApp.Tests.unit.Services.Foundations.Persons
{
    public partial class PersonServiceTests
    {
        [Fact]
        public void ShouldThrowValidationExceptionOnAddIfPersonIsNullAndLogIt()
        {
            // given
            Person nullPerson = null;
            var nullPersonException = new NullPersonException();
            var exceptedPersonValidationException = new PersonValidationException(nullPersonException);

            //when
            Action addPersonAction = () => this.personService.AddPerson(nullPerson);

            //then
            Assert.Throws<PersonValidationException>(addPersonAction);

            this.loggingBrokerMock.Verify(broker =>
               broker.LogError(It.Is(SameExceptionAs
                 (exceptedPersonValidationException))),
                    Times.Once);

            this.storageBrokerMock.Verify(broker =>
               broker.InsertPerson(It.IsAny<Person>()),
                  Times.Never);

            this.loggingBrokerMock.VerifyNoOtherCalls();
            this.storageBrokerMock.VerifyNoOtherCalls();
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("  ")]
        public void ShouldThrowValidationExceptionOnAddIfPersonIsInvalidAndLogIt(
            string invalidFirstName)
        {
            //given 
            var invalidPerson = new Person
            {
                FirstName = invalidFirstName
            };

            var invalidPersonException = new InvalidPersonException();

            invalidPersonException.AddData(
                key: nameof(Person.Id),
                values: "ID is required.");

            invalidPersonException.AddData(
                key: nameof(Person.FirstName),
                values: "Name is required.");

            invalidPersonException.AddData(
                key: nameof(Person.LastName),
                values: "Name is required.");

            var exceptedPersonvalidationException = new PersonValidationException(invalidPersonException);

            //when 
            Action addPersonAction = () => this.personService.AddPerson(invalidPerson);

            //then
            Assert.Throws<PersonValidationException>(addPersonAction);

            this.loggingBrokerMock.Verify(broker =>
               broker.LogError(It.Is(SameExceptionAs
                  (exceptedPersonvalidationException))),
                     Times.Once);

            this.storageBrokerMock.Verify(broker =>
               broker.InsertPerson(It.IsAny<Person>()),
                  Times.Never);

            this.loggingBrokerMock.VerifyNoOtherCalls();
            this.storageBrokerMock.VerifyNoOtherCalls();
        }
    }
}