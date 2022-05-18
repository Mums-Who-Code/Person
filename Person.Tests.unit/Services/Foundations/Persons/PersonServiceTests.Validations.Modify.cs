// ------------------------------------------------
// Copyright (c) MumsWhoCode. All rights reserved.
// ------------------------------------------------

using Moq;
using PersonApp.ConsoleApp.Models.Persons;
using PersonApp.ConsoleApp.Models.Persons.Exceptions;
using System;
using Xunit;

namespace PersonApp.Tests.unit.Services.Foundations.Persons
{
    public partial class PersonServiceTests
    {
        [Fact]
        public void ShouldThrowValidateExceptionOnModifyIfPersonIsNullAndLogIt()
        {
            //given
            Person nullPerson = null;

            var nullPersonExpection = new NullPersonException();

            var expectedPersonValidationException =
                new PersonValidationException(nullPersonExpection);

            //when
            Action modifyPersonAction = () => this.personService.ModifyPerson(nullPerson);

            //then
            Assert.Throws<PersonValidationException>(modifyPersonAction);

            this.loggingBrokerMock.Verify(broker =>
                broker.LogError(It.Is(SameExceptionAs(
                    expectedPersonValidationException))),
                        Times.Once);

            this.storageBrokerMock.Verify(broker =>
                broker.UpdatePerson(It.IsAny<Person>()),
                    Times.Never);

            this.storageBrokerMock.VerifyNoOtherCalls();
            this.loggingBrokerMock.VerifyNoOtherCalls();
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData(" ")]
        public void ShouldThrowValidationExceptionOnModifyIfPersonIsInvalidAndLogIt(
            string invalidText)
        {
            //given
            var invalidPerson = new Person
            {
                FirstName = invalidText,
                LastName = invalidText,
            };

            var invalidPersonExpection = new InvalidPersonException();

            invalidPersonExpection.AddData(
                key: nameof(Person.Id),
                values: "ID is required.");

            invalidPersonExpection.AddData(
                key: nameof(Person.FirstName),
                values: "Name is required.");

            invalidPersonExpection.AddData(
                key: nameof(Person.LastName),
                values: "Name is required.");

            var expectedPersonValidationException =
                new PersonValidationException(invalidPersonExpection);

            //when
            Action modifyPersonAction = () => this.personService.ModifyPerson(invalidPerson);

            //then
            Assert.Throws<PersonValidationException>(modifyPersonAction);

            this.loggingBrokerMock.Verify(broker =>
                broker.LogError(It.Is(SameExceptionAs(
                    expectedPersonValidationException))),
                        Times.Once);

            this.storageBrokerMock.Verify(broker =>
                broker.UpdatePerson(It.IsAny<Person>()),
                    Times.Never);

            this.loggingBrokerMock.VerifyNoOtherCalls();
            this.storageBrokerMock.VerifyNoOtherCalls();
        }
    }
}